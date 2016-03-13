using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class ApostropheMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if(charac == '\'')
            {
                if(tempToken!=null)
                {
                    AddToken(tempToken);
                }
                return new Token() { Type = TokenType.CHAR, Value = charac.ToString() };
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
