using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scanner.Tokens;

namespace Scanner.CharAnalizeLinks
{
    public class DigitLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (Char.IsDigit(charac))
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.LICZBA_CALKOWITA || tempToken.Type == TokenType.LICZBA_WYMIERNA)
                    {
                        tempToken.Value += charac;
                        return tempToken;
                    }
                    else if(tempToken.Type == TokenType.NIEZNANE)
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

            return base.GetRequest(tempToken, charac);
        }
    }
}
