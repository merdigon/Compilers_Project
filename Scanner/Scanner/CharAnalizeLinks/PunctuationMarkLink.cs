using Compiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class PunctuationMarkLink : LinkBase
    {
        public override Tokens.Token GetRequest(Tokens.Token tempToken, char charac)
        {
            if (charac == ':')
            {
                if (tempToken != null)
                {
                    AddToken(tempToken);
                }
                AddToken(new Token() { Type = TokenType.PUNCTUATIONMARK, Value = charac.ToString() });
                return null;
            }
            return base.GetRequest(tempToken, charac);
        }
    }
}
