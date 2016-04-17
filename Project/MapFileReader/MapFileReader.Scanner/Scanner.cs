using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Scanner
{
    public class Scanner
    {
        private string FilePath { get; set; }
        private List<TokenDictionary> tokenDictionaryList;

        public Scanner(string filePath)
        {
            this.FilePath = filePath;
            InitTokenDictList();
        }

        private void InitTokenDictList()
        {
            tokenDictionaryList = new TokenDictListBuilder().CreateTokenList().GetTokenList();
        }

        private List<Token> GetTokensFromFile()
        {
            List<Token> tokensList = new List<Token>();
            using (StreamReader strReader = new StreamReader(FilePath))
            {
                int filePointer = 0;
                Token returnToken;
                while ((returnToken = ReadToken(strReader, ref filePointer)) != null)
                {
                    tokensList.Add(returnToken);
                }
            }
            return tokensList;
        }

        private Token ReadToken(StreamReader strReader, ref int filePointer)
        {
            int buffer;
            if ((buffer = strReader.Read()) != -1)
            {
                filePointer++;
                if ((char)buffer == '<')
                    return ReadMarkup(strReader, ref filePointer);
                else if ((char)buffer == '\n') { }
                else
                    return ReadValue(strReader, ref filePointer);
            }
            return null;
        }

        private Token ReadMarkup(StreamReader strReader, ref int filePointer)
        {
            int buffer;
            if ((buffer = strReader.Read()) != -1)
            {
                filePointer++;
                if ((char)buffer == '/')
                    return ReadMarkupName(strReader, ref filePointer, TokenType.CLOSING);
                else
                {
                    return ReadMarkupName(strReader, ref filePointer, TokenType.OPENING);
                }
            }
            else
                return ErrorTokenBuilder.EndOfFileErrorToken();
        }

        private Token ReadMarkupName(StreamReader strReader, ref int filePointer, TokenType tokenType)
        {
            int buffer;
            string value = string.Empty;
            List<TokenDictionary> possibleTokens = tokenDictionaryList.Select(p => p.Clone()).ToList();
            while (true)
            {
                if ((buffer = strReader.Read()) != -1)
                {
                    filePointer++;
                    if ((char)buffer == '>')
                    {
                        if (string.IsNullOrEmpty(value))
                            return ErrorTokenBuilder.EmptyMarkup();
                        TokenDictionary possibleToken = possibleTokens.FirstOrDefault();
                        if (possibleToken == null)
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

        private Token ReadValue(StreamReader strReader, ref int filePointer)
        {

        }

    }
}
