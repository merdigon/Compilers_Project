using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
    }

    public enum TokenType
    {
        NAWIAS,
        OP_ARYT,
        LICZBA_CALKOWITA,
        LICZBA_WYMIERNA,
        ERROR,
        KROPKA,
        NIEZNANE,
        STRING,
        END_OF_LINE,
        BASIC_TYPE,
        MODIF
    }
}
