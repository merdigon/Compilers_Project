using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class OneLineCommentLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if(tempToken!=null && tempToken.Type==TokenType.ONE_LINE_COMMENT)
            {
                if (charac == '\n' || charac == '\r')
                {
                    AddToken(tempToken);
                    AddToken(new Token() { Type = TokenType.END_OF_LINE, Value = charac.ToString() });
                    return null;
                }
                else
                {
                    tempToken.Value += charac.ToString();
                    return tempToken;
                }
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
