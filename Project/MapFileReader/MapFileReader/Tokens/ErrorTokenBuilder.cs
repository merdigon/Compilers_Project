using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Tokens
{
    public class ErrorTokenBuilder
    {
        public static Token EndOfFileErrorToken()
        {
            return new Token() { TokenType = TokenType.ERROR, Value = "<", AdditionalInfo = "Niespodziewany koniec pliku" };
        }

        public static Token UnknownMarkup(string markup)
        {
            return new Token() { TokenType = TokenType.ERROR, Value = markup, AdditionalInfo = "Niespodziewany znacznik" };
        }

        public static Token EmptyMarkup()
        {
            return new Token() { TokenType = TokenType.ERROR, Value = "", AdditionalInfo = "Pusty znacznik" };
        }      
    }
}
