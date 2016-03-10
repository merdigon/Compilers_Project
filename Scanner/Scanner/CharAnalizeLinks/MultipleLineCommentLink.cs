using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class MultipleLineCommentLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (tempToken != null && tempToken.Type == TokenType.MULTIPLE_LINE_COMMENT)
            {
                tempToken.Value += charac.ToString();
                if (charac == '/' && tempToken.Value.Last() == '*')
                {
                    AddToken(tempToken);
                    return null;
                }
                else
                {
                    return tempToken;
                }
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
