using MapFileReader.Attributes;
using MapFileReader.KMLObjects;
using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Parser
{
    public class KMLParser
    {
        public List<Token> TokenList { get; set; }
        public List<Token> ErrorTokens { get; set; }

        public KMLParser(List<Token> tokenList)
        {
            TokenList = tokenList;
        }

        public FileKML ParseTokens()
        {
            int listPointer = 0;
            ErrorTokens = new List<Token>();
            Stack<KMLObjectStackVersion> kmlObjectStack = new Stack<KMLObjectStackVersion>();
            kmlObjectStack.Push(new KMLObjectStackVersion() { KmlObject = new FileKML() } );

            while (listPointer < TokenList.Count)
            {
                Token currentToken = TokenList[listPointer++];
                if (currentToken.TokenType == TokenType.OPENING)
                {
                    //pobiera taki properties, dla którego Atrybut ma wartość równą pobranemu tokenowi
                    PropertyInfo property = kmlObjectStack.Peek().KmlObject.GetType().GetProperties().Where(p => (p.GetCustomAttribute<KMLMarkNameAttribute>() == null ? false : p.GetCustomAttribute<KMLMarkNameAttribute>().Name.Equals(currentToken.Value))).FirstOrDefault();
                    if (property.PropertyType.IsSubclassOf(typeof(KMLBase)))
                    {
                        Type newObjectType = property.PropertyType;
                        KMLBase newObject = (KMLBase)Activator.CreateInstance(newObjectType);
                        property.SetValue(kmlObjectStack.Peek().KmlObject, newObject);
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
                else if (currentToken.TokenType == TokenType.CLOSING)
                {
                    if (currentToken.Value.Equals(kmlObjectStack.Peek().TokenName))
                        kmlObjectStack.Pop();
                }
                else
                    ErrorTokens.Add(currentToken);
            }

            return (FileKML)kmlObjectStack.Pop().KmlObject;
        }
    }
}
