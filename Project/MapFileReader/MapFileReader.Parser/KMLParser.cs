using MapFileReader.Attributes;
using MapFileReader.DTO;
using MapFileReader.Errors;
using MapFileReader.KMLObjects;
using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Parser
{
    public class KMLParser
    {
        public List<Token> TokenList { get; set; }
        public List<ReaderError> ReaderErrorList { get; set; }

        public KMLParser(List<Token> tokenList)
        {
            TokenList = tokenList;
        }

        public ParserResponse ParseTokens()
        {
            ReaderErrorList = new List<ReaderError>();
            KMLBase finalObject = null;

            try
            {
                string tokenListText = TransformTokenListIntoGrammaticaVersion();
                MapParser parser = new MapParser(new StringReader(tokenListText));
                var result = parser.Parse();

                int listPointer = 0;
                Stack<KMLObjectStackVersion> kmlObjectStack = new Stack<KMLObjectStackVersion>();
                kmlObjectStack.Push(new KMLObjectStackVersion() { KmlObject = new FileKML() });

                while (listPointer < TokenList.Count)
                {
                    Token currentToken = TokenList[listPointer++];
                    if (currentToken.TokenType == TokenType.OPENING)
                    {
                        //pobiera taki properties, dla którego Atrybut ma wartość równą pobranemu tokenowi
                        PropertyInfo property = kmlObjectStack.Peek().KmlObject.GetType().GetProperties().Where(p => (p.GetCustomAttribute<KMLMarkNameAttribute>() == null ? false : p.GetCustomAttribute<KMLMarkNameAttribute>().Name.Equals(currentToken.Value))).FirstOrDefault();
                        if (property != null)
                        {
                            if (property.PropertyType.IsSubclassOf(typeof(KMLBase)))
                            {
                                Type newObjectType = property.PropertyType;
                                KMLBase newObject = (KMLBase)Activator.CreateInstance(newObjectType);
                                property.SetValue(kmlObjectStack.Peek().KmlObject, newObject);
                                kmlObjectStack.Push(new KMLObjectStackVersion() { KmlObject = newObject, TokenName = currentToken.Value });
                            }
                            else if (property.PropertyType.GenericTypeArguments != null && property.PropertyType.GenericTypeArguments.Count() > 0 && property.PropertyType.GenericTypeArguments[0].BaseType == typeof(KMLBase))
                            {
                                Type newObjectType = property.PropertyType.GenericTypeArguments[0];
                                KMLBase newObject = (KMLBase)Activator.CreateInstance(newObjectType);
                                if (property.GetValue(kmlObjectStack.Peek().KmlObject) == null)
                                    property.SetValue(kmlObjectStack.Peek().KmlObject, new List<PlacemarkKML>());
                                ((List<PlacemarkKML>)property.GetValue(kmlObjectStack.Peek().KmlObject)).Add((PlacemarkKML)newObject);
                                kmlObjectStack.Push(new KMLObjectStackVersion() { KmlObject = newObject, TokenName = currentToken.Value });
                            }
                            else
                            {
                                Token value = TokenList[listPointer++];
                                Token closingToken = TokenList[listPointer++];
                                if (closingToken.TokenType == TokenType.CLOSING && closingToken.Value.Equals(currentToken.Value))
                                {
                                    property.SetValue(kmlObjectStack.Peek().KmlObject, value.Value);
                                }
                            }
                        }
                    }
                    else if (currentToken.TokenType == TokenType.CLOSING)
                    {
                        if (currentToken.Value.Equals(kmlObjectStack.Peek().TokenName))
                            kmlObjectStack.Pop();
                        else
                        {
                            ReaderErrorList.Add(new ReaderError("Niespodziewane zakończenie znacznika", currentToken.Value, ReaderErrorsType.PARSER));
                            kmlObjectStack.Pop();
                        }
                    }
                    else if (currentToken.TokenType == TokenType.ERROR)
                    {
                        ReaderErrorList.Add(new ReaderError(currentToken));
                    }
                    else if (currentToken.TokenType == TokenType.VALUE)
                    {
                        ReaderErrorList.Add(new ReaderError("Niespodziewana wartość", currentToken.Value, ReaderErrorsType.PARSER));
                    }
                }

                finalObject = kmlObjectStack.Pop().KmlObject;
            }
            catch (PerCederberg.Grammatica.Runtime.ParserLogException plex)
            {
                ReaderErrorList.Add(new ReaderError(plex.Message, "GRAMMATICA-ERROR", ReaderErrorsType.PARSER));
            }

            return new ParserResponse()
            {
                ResponseObject = finalObject,
                ResponseErrorList = ReaderErrorList
            };
        }

        private string TransformTokenListIntoGrammaticaVersion()
        {
            string resultVersion = string.Empty;

            for(int a=0; a<TokenList.Count(); a++)
            {
                Token token = TokenList[a];
                if (token.TokenType == TokenType.OPENING)
                {
                    if (a + 1 < TokenList.Count())
                    {
                        if (TokenList[a + 1].TokenType == TokenType.VALUE) 
                        { 
                            resultVersion += token.Value.ToUpper() + "_V ";
                            a = a + 2;
                            continue;
                        }
                    }
                    resultVersion += token.Value.ToUpper() + "_O ";
                }
                else if (token.TokenType == TokenType.CLOSING)
                    resultVersion += token.Value.ToUpper() + "_C ";
                else if (token.TokenType == TokenType.VALUE)
                    resultVersion += token.Value.ToUpper() + "_V ";
            }

            return resultVersion;
        }
    }
}
