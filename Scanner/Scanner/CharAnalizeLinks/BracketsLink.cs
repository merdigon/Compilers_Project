using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class BracketsLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '(' || charac == ')' || charac == '{' || charac == '}' || charac == ']' || charac == '[')
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.NIEZNANE)
                    {
                        tempToken.Type = TokenManager.CheckUnknownElem(tempToken, true);
                    }
                    AddToken(tempToken);
                }
                AddToken(new Token() { Type = TokenType.NAWIAS, Value = charac.ToString() });
                return null;
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
