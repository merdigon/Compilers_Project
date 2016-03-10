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

        public static TokenType CheckUnknownElem(Token tok, bool brackets)
        {
            SpecialElement[] modif = new SpecialElement[]{
                new SpecialElement(){Name="static", AllowBrackets=false},
                new SpecialElement(){Name="public", AllowBrackets=false},
                new SpecialElement(){Name="private", AllowBrackets=false},
                new SpecialElement(){Name="protected", AllowBrackets=false},
                new SpecialElement(){Name="sealed", AllowBrackets=false},
                new SpecialElement(){Name="final", AllowBrackets=false},
                new SpecialElement(){Name="new", AllowBrackets=false},
                new SpecialElement(){Name="get", AllowBrackets=false},
                new SpecialElement(){Name="set", AllowBrackets=false},
                new SpecialElement(){Name="typeof", AllowBrackets=true}};

            SpecialElement[] basic_type = new SpecialElement[]{
                new SpecialElement(){Name="int", AllowBrackets=true},
                new SpecialElement(){Name="class", AllowBrackets=false},
                new SpecialElement(){Name="interface", AllowBrackets=false},
                new SpecialElement(){Name="char", AllowBrackets=true},
                new SpecialElement(){Name="string", AllowBrackets=true},
                new SpecialElement(){Name="double", AllowBrackets=true},
                new SpecialElement(){Name="long", AllowBrackets=true},
                new SpecialElement(){Name="object", AllowBrackets=true}
            };

            SpecialElement[] flow_control = new SpecialElement[]{
                new SpecialElement(){Name="if", AllowBrackets=true},
                new SpecialElement(){Name="else", AllowBrackets=true},
                new SpecialElement(){Name="for", AllowBrackets=true},
                new SpecialElement(){Name="while", AllowBrackets=true},
                new SpecialElement(){Name="do", AllowBrackets=true},
                new SpecialElement(){Name="try", AllowBrackets=true},
                new SpecialElement(){Name="catch", AllowBrackets=true},
                new SpecialElement(){Name="finally", AllowBrackets=true},
                new SpecialElement(){Name="break", AllowBrackets=false},
                new SpecialElement(){Name="switch", AllowBrackets=true},
                new SpecialElement(){Name="case", AllowBrackets=false},
                new SpecialElement(){Name="default", AllowBrackets=false},
                new SpecialElement(){Name="throw", AllowBrackets=false}
            };

            if((from SpecialElement specEle in modif where specEle.Name.Equals(tok.Value) && (specEle.AllowBrackets || !brackets) select specEle).Count()>0)
                return TokenType.MODIF;
            if ((from SpecialElement specEle in basic_type where specEle.Name.Equals(tok.Value) && (specEle.AllowBrackets || !brackets) select specEle).Count() > 0)
                return TokenType.BASIC_TYPE;
            if ((from SpecialElement specEle in flow_control where specEle.Name.Equals(tok.Value) && (specEle.AllowBrackets || !brackets) select specEle).Count() > 0)
                return TokenType.FLOW_CONTROL;
            return TokenType.NIEZNANE;
        }

        struct SpecialElement
        {
            public string Name { get; set; }
            public bool AllowBrackets { get; set; }
        }
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
        MODIF,
        FLOW_CONTROL,
        PRZYPISANIE,
        //operator porównania
        OP_POR,
        OP_LOG,
        END_OF_CODE_LINE,
        SLASH,
        ONE_LINE_COMMENT,
        MULTIPLE_LINE_COMMENT
    }
 
}
