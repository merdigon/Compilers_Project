﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class CommaMarkLink : LinkBase
    {
        public override Token GetRequest(Token tempToken, char charac)
        {
            if (charac == ',')
            {
                if (tempToken != null)
                {
                    if (tempToken.Type == TokenType.NIEZNANE)
                    {
                        tempToken.Type = Token.CheckUnknownElem(tempToken, true);
                    }
                    AddToken(tempToken);
                    AddToken(new Token() { Type = TokenType.PRZECINEK, Value = charac.ToString() });
                }
                return null;
            }

            return base.GetRequest(tempToken, charac);
        }
    }
}
