using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class IgnoreMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '\r')
                return tempToken;
            else if (charac == '\t')
            {
                if (tempToken != null && tempToken.Type == TokenType.SPACE)
                {
                    tempToken.Value += "    ";
                    return tempToken;
                }
                else if (tempToken != null)
                {
                    AddToken(tempToken);
                    return new Token() { Type = TokenType.SPACE, Value = "    " };
                }
                else
                    return new Token() { Type = TokenType.SPACE, Value = "    " };
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
