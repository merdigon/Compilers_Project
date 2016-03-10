using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class IgnoreMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '\r' || charac == '\t')
                return tempToken;

            return base.GetRequest(tempToken, charac);
        }
    }
}
