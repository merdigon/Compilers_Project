using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class MoreLessMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '>' || charac == '<')
            {
                if (tempToken != null)
                {
                    AddToken(tempToken);
                }
                return new Token() { Type = TokenType.OP_POR, Value = charac.ToString() };
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
