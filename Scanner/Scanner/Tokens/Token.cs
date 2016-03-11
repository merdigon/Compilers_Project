using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.Tokens
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
        public string Color
        {
            get
            {
                return TokenManager.GetColor(Type);
            }
        }   
    } 
}
