using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class EndOfCodeLineMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if(charac == ';')
            {
                if (tempToken != null)
                {
                    AddToken(tempToken);
                }
                return new Token() { Type = TokenType.END_OF_CODE_LINE, Value = charac.ToString() };
            }            

            return base.GetRequest(tempToken, charac);
        }
    }
}
