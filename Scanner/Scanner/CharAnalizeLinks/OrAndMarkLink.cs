using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class OrAndMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '|' || charac == '&')
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.OP_LOG && tempToken.Value.Equals(charac.ToString()))
                    {
                        tempToken.Value += charac.ToString();
                        AddToken(tempToken);
                        return null;
                    }
                    AddToken(tempToken);
                }
                return new Token() { Type = TokenType.OP_LOG, Value = charac.ToString() };
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
