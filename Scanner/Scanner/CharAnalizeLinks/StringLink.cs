using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class StringLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (tempToken != null)
            {
                if (tempToken.Type == TokenType.STRING)
                {
                    if (charac == '"')
                    {
                        tempToken.Value += charac;
                        AddToken(tempToken);
                        return null;
                    }
                    else
                    {
                        tempToken.Value += charac;
                        return tempToken;
                    }
                }
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
