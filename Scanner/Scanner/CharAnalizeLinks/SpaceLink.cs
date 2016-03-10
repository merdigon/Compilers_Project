using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class SpaceLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == ' ')
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.NIEZNANE)
                    {
                        tempToken.Type = Token.CheckUnknownElem(tempToken, false);
                        AddToken(tempToken);
                    }
                    else
                    {
                        AddToken(tempToken);
                    }
                }
                return null;
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
