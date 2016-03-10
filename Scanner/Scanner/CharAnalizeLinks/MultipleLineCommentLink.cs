using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scanner.Tokens;

namespace Scanner.CharAnalizeLinks
{
    public class MultipleLineCommentLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (tempToken != null && tempToken.Type == TokenType.MULTIPLE_LINE_COMMENT)
            {
                if (charac == '/' && tempToken.Value.Last() == '*')
                {
                    tempToken.Value += charac.ToString();
                    AddToken(tempToken);
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
