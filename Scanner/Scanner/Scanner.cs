using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner
{
    public class Scanner
    {
        public string Input { get; set; }
        public List<Token> tokens { get; set; }

        public Scanner()
        {
            tokens = new List<Token>();
            Input = "(34*+\"2.4  .\"class(-4)";
        }

        public void AnalizeInput()
        {
            Token currentToken = null;
            foreach (char charac in Input)
            {
                currentToken = AnalizeCharac(charac, currentToken);
            }
            if (currentToken != null)
            {
                AddToken(currentToken);
            }
        }

        public Token AnalizeCharac(char charac, Token tempToken)
        {
            if (tempToken != null)
            {
                if (tempToken.Type == TokenType.STRING)
                {
                    if (charac == '"')
                    {
                        tempToken.Value += charac;
                        AddToken(tempToken);
                        return null;
                    }
                    else
                    {
                        tempToken.Value += charac;
                        return tempToken;
                    }
                }
            }
            if (charac == '(' || charac == ')' || charac == '{' || charac == '}' || charac == ']' || charac == '[')
            {
                if (tempToken != null)
                {
                    if(tempToken.Type == TokenType.NIEZNANE)
                    {
                        tempToken.Type = Token.CheckUnknownElem(tempToken, true);
                    }
                    AddToken(tempToken);
                }
                AddToken(new Token() { Type = TokenType.NAWIAS, Value = charac.ToString() });
                return null;
            }
            if (charac == '+')
            {
                if (tempToken != null)
                    AddToken(tempToken);
                AddToken(new Token() { Type = TokenType.OP_ARYT, Value = "+" });
                return null;
            }
            if (charac == '/')
            {
                if (tempToken != null)
                    AddToken(tempToken);
                AddToken(new Token() { Type = TokenType.OP_ARYT, Value = "/" });
                return null;
            }
            if (charac == '-')
            {
                if (tempToken != null)
                    AddToken(tempToken);
                AddToken(new Token() { Type = TokenType.OP_ARYT, Value = "-" });
                return null;
            }
            if (charac == '*')
            {
                if (tempToken != null)
                    AddToken(tempToken);
                AddToken(new Token() { Type = TokenType.OP_ARYT, Value = "*" });
                return null;
            }
            if (Char.IsDigit(charac))
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.LICZBA_CALKOWITA || tempToken.Type == TokenType.LICZBA_WYMIERNA)
                    {
                        tempToken.Value += charac;
                        return tempToken;
                    }
                    else
                    {
                        AddToken(tempToken);
                        return new Token() { Type = TokenType.LICZBA_CALKOWITA, Value = charac.ToString() };
                    }
                }
                else
                {
                    return new Token() { Type = TokenType.LICZBA_CALKOWITA, Value = charac.ToString() };
                }
            }
            if(charac == '.')
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.LICZBA_CALKOWITA)
                    {
                        tempToken.Value += charac;
                        tempToken.Type = TokenType.LICZBA_WYMIERNA;
                        return tempToken;
                    }
                    else if (tempToken.Type == TokenType.LICZBA_WYMIERNA)
                    {
                        tempToken.Value += charac;
                        tempToken.Type = TokenType.ERROR;
                        AddToken(tempToken);
                        return null;
                    }
                    else
                    {
                        AddToken(tempToken);
                        AddToken(new Token() { Type = TokenType.KROPKA, Value = charac.ToString() });
                        return null;
                    }
                }
                else
                {
                    AddToken(new Token() { Type = TokenType.KROPKA, Value = charac.ToString() });
                    return null;
                }
            }
            if(charac=='"')
            {
                if (tempToken != null)
                {
                    AddToken(tempToken);                    
                }
                return new Token() { Type = TokenType.STRING, Value = charac.ToString() };
            }
            if(charac==' ')
            {
                if (tempToken != null)
                {
                    if(tempToken.Type==TokenType.NIEZNANE)
                    {
                        tempToken.Type = Token.CheckUnknownElem(tempToken, false);
                        AddToken(tempToken);
                    }
                    else
                    {
                        AddToken(tempToken);
                    }
                }
                return null;
            }
            if (true)
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.NIEZNANE)
                    {
                        tempToken.Value += charac;
                        return tempToken;
                    }
                    else
                    {
                        tokens.Add(tempToken);
                        return new Token() { Type = TokenType.NIEZNANE, Value = charac.ToString() };
                    }
                }
                else
                {
                    return new Token() { Type = TokenType.NIEZNANE, Value = charac.ToString() };
                }
            }
        }

        public void AddToken(Token tokToAdd)
        {
            if (tokToAdd.Type == TokenType.LICZBA_WYMIERNA && tokToAdd.Value.Last() == '.')
            {
                tokToAdd.Type = TokenType.ERROR;
            }
            if (tokToAdd.Type == TokenType.STRING && tokToAdd.Value.Last() != '"')
            {
                tokToAdd.Type = TokenType.ERROR;
            }
            tokens.Add(tokToAdd);
        }

        public void ShowTokens()
        {
            foreach (Token tok in tokens)
            {
                Console.WriteLine(tok.Type.ToString() + " - " + tok.Value);
            }
        }
    }
}
