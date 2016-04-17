using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Tokens
{
    public class TokenDictionary : ICloneable
    {
        public string Value { get; set; }

        public TokenDictionary(string value)
        {
            this.Value = value;
        }

        public TokenDictionary Clone()
        {
            return new TokenDictionary(Value);
        }
    }
}
