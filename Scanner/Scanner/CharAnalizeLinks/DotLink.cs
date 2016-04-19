using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class DotLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '.')
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
                    else if (tempToken.Type == TokenType.NIEZNANE)
                    {
                        tempToken.Type = TokenManager.CheckUnknownElem(tempToken, false);
                        AddToken(tempToken);
                        AddToken(new Token() { Type = TokenType.KROPKA, Value = charac.ToString() });
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

            return base.GetRequest(tempToken, charac);
        }
    }
}
