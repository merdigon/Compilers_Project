using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    public class SlashMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '/')
            {
                if (tempToken != null)
                {
                    if(tempToken.Type == TokenType.SLASH)
                    {
                        tempToken.Type = TokenType.ONE_LINE_COMMENT;
                        tempToken.Value += charac.ToString();
                        return tempToken;
                    }
                    AddToken(tempToken);
                }
                return new Token() { Type = TokenType.SLASH, Value = charac.ToString() };
            }
            
            return base.GetRequest(tempToken, charac);
        }
    }
}
