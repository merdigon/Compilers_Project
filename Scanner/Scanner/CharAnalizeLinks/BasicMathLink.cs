using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class BasicMathLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '+' || charac == '-' || charac == '*')
            {
                if (tempToken != null)
                {
                    if(charac == '*' && tempToken.Type == TokenType.SLASH)
                    {
                        tempToken.Type = TokenType.MULTIPLE_LINE_COMMENT;
                        tempToken.Value += charac.ToString();
                        return tempToken;
                    }
                    else
                        AddToken(tempToken);
                }
                return new Token() { Type = TokenType.OP_ARYT, Value = charac.ToString() };
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
