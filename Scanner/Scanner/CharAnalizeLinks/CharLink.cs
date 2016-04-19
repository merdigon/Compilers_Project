using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class CharLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if(tempToken!=null && tempToken.Type == TokenType.CHAR)
            {
                tempToken.Value += charac.ToString();
                if(charac == '\'' && tempToken.Value.Last() != '\\')
                {
                    AddToken(tempToken);
                    return null;
                }
                return tempToken;
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
