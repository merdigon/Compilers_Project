using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class EndOfLineLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if(charac == '\n')
            {
                if(tempToken!=null)
                {
                    if (tempToken.Type == TokenType.NIEZNANE)
                    {
                        tempToken.Type = Token.CheckUnknownElem(tempToken, true);
                    }
                    AddToken(tempToken);
                }
                return null;
            }
            
            return base.GetRequest(tempToken, charac);
        }
    }
}
