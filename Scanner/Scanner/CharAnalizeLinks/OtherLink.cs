using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class OtherLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
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
                    AddToken(tempToken);
                    return new Token() { Type = TokenType.NIEZNANE, Value = charac.ToString() };
                }
            }
            else
            {
                return new Token() { Type = TokenType.NIEZNANE, Value = charac.ToString() };
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
