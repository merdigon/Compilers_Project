using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Scanner
{
    public class KMLScanner
    {
        private string FilePath { get; set; }
        private string MapValue { get; set; }
        private KMLFileReader fileReader { get; set; }
        private List<TokenDictionary> tokenDictionaryList;

        private string IgnoreMarksList
        {
            get
            {
                return "\n \r\t";
            }
        }

        public KMLScanner()
        {
            InitTokenDictList();
        }

        private void InitTokenDictList()
        {
            tokenDictionaryList = new TokenDictListBuilder().CreateTokenList().GetTokenList();
        }

        public void SetFileReader(string path)
        {
            this.FilePath = path;
            fileReader = new KMLFileReader();
            fileReader.ReadFile(FilePath);
        }

        public void SetMapValue(string value)
        {
            this.MapValue = value;
            fileReader = new KMLFileReader();
            fileReader.ReadString(value);
        }

        public List<Token> GetTokens()
        {
            List<Token> tokensList = new List<Token>();
            Token returnToken;
            while ((returnToken = ReadToken()) != null)
            {
                if(returnToken.TokenType != TokenType.IGNORE)
                    tokensList.Add(returnToken);
            }
            return tokensList;
        }

        private Token ReadToken()
        {
            int buffer;
            if ((buffer = fileReader.Read()) != -1)
            {
                if ((char)buffer == '<')
                    return ReadMarkup();
                else if (IgnoreMarksList.Contains((char)buffer))
                    return new Token() { TokenType = TokenType.IGNORE };
                else
                {
                    fileReader.MovePointer(-1);
                    return ReadValue();
                }
            }
            return null;
        }

        private Token ReadMarkup()
        {
            int buffer;
            if ((buffer = fileReader.Read()) != -1)
            {
                if ((char)buffer == '/')
                    return ReadMarkupName(TokenType.CLOSING);
                else
                {
                    fileReader.MovePointer(-1);
                    return ReadMarkupName(TokenType.OPENING);
                }
            }
            else
                return ErrorTokenBuilder.EndOfFileErrorToken();
        }

        private Token ReadMarkupName(TokenType tokenType)
        {
            int buffer;
            string value = string.Empty;
            List<TokenDictionary> possibleTokens = tokenDictionaryList.Select(p => (TokenDictionary)p.Clone()).ToList();
            while (true)
            {
                if ((buffer = fileReader.Read()) != -1)
                {
                    if ((char)buffer == '>')
                    {
                        if (string.IsNullOrEmpty(value))
                            return ErrorTokenBuilder.EmptyMarkup();
                        if (possibleTokens.Where(p => p.Value.Equals(value)).FirstOrDefault() == null)
                            return ErrorTokenBuilder.UnknownMarkup(value);

                        return new Token()
                        {
                            TokenType = tokenType,
                            Value = value
                        };
                    }
                    else
                    {
                        value += ((char)buffer).ToString();
                        possibleTokens = possibleTokens.Where(p => p.Value.StartsWith(value)).ToList();
                    }
                }
                else
                    return ErrorTokenBuilder.EndOfFileErrorToken();
            }
        }

        private Token ReadValue()
        {
            int buffer;
            string value = string.Empty;
            while (true)
            {
                if ((buffer = fileReader.Read()) != -1)
                {
                    if((char)buffer == '<')
                    {
                        fileReader.MovePointer(-1);
                        return new Token() { TokenType = TokenType.VALUE, Value = value };
                    }
                    else if ("\r".Contains((char)buffer))
                    {
                        value += ";";
                    }
                    else
                    {
                        value += ((char)buffer).ToString();
                    }
                }
                else
                {
                    return ErrorTokenBuilder.EndOfFileErrorToken();
                }
            }
        }
    }
}
