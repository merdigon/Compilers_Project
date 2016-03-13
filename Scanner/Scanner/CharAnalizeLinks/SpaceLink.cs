using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class SpaceLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == ' ')
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.NIEZNANE)
                    {
                        tempToken.Type = TokenManager.CheckUnknownElem(tempToken, false);
                        AddToken(tempToken);
                        return new Token() { Type = TokenType.SPACE, Value = charac.ToString() };
                    }
                    else if (tempToken.Type == TokenType.SPACE)
                    {
                        tempToken.Value += charac.ToString();
                        return tempToken;
                    }
                    else
                    {
                        AddToken(tempToken);
                        return new Token() { Type = TokenType.SPACE, Value = charac.ToString() };                        
                    }
                }
                else
                {
                    return new Token() { Type = TokenType.SPACE, Value = charac.ToString() };
                }
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
