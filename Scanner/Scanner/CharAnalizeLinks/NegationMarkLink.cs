using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scanner.Tokens;

namespace Scanner.CharAnalizeLinks
{
    public class NegationMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '!')
            {
                if (tempToken != null)
                {
                    AddToken(tempToken);
                }
                return new Token() { Type = TokenType.OP_LOG, Value = charac.ToString() };
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
