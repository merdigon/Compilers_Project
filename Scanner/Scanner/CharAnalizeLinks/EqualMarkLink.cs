using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.Tokens;

namespace Compiler.Scanner.CharAnalizeLinks
{
    class EqualMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == '=')
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.OP_ARYT)
                    {
                        tempToken.Type = TokenType.PRZYPISANIE;
                        tempToken.Value += charac.ToString();
                        AddToken(tempToken);
                        return null;
                    }
                    if (tempToken.Type == TokenType.PRZYPISANIE && tempToken.Value.Equals("="))
                    {
                        tempToken.Type = TokenType.OP_POR;
                        tempToken.Value += charac.ToString();
                        AddToken(tempToken);
                        return null;
                    }
                    if (tempToken.Type == TokenType.OP_POR)
                    {
                        tempToken.Value += charac.ToString();
                        AddToken(tempToken);
                        return null;
                    }
                    if (tempToken.Type == TokenType.OP_LOG && tempToken.Value.Equals("!"))
                    {
                        tempToken.Type = TokenType.OP_POR;
                        tempToken.Value += charac.ToString();
                        AddToken(tempToken);
                        return null;
                    }
                    AddToken(tempToken);
                }
                return new Token() { Type = TokenType.PRZYPISANIE, Value = charac.ToString() };
            }


            return base.GetRequest(tempToken, charac);
        }

    }
}
