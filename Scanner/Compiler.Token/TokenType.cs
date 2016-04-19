using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Tokens
{
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
        MODIF,
        FLOW_CONTROL,
        PRZYPISANIE,
        //operator porównania
        OP_POR,
        OP_LOG,
        END_OF_CODE_LINE,
        SLASH,
        ONE_LINE_COMMENT,
        MULTIPLE_LINE_COMMENT,
        CHAR,
        PRZECINEK,
        SPACE,
        REGION,
        PUNCTUATIONMARK
    }
}
