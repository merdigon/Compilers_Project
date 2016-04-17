using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Tokens
{
    public class Token
    {
        public string Value { get; set; }

        public TokenType TokenType { get; set; }

        public string AdditionalInfo { get; set; }
    }

}
