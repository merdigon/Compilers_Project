using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Tokens
{
    public class TokenManager
    {
        struct SpecialElement
        {
            public string Name { get; set; }
            public bool AllowBrackets { get; set; }
        }

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
                new SpecialElement(){Name="using", AllowBrackets=false},
                new SpecialElement(){Name="namespace", AllowBrackets=false},
                new SpecialElement(){Name="get", AllowBrackets=false},
                new SpecialElement(){Name="set", AllowBrackets=false},
                new SpecialElement(){Name="null", AllowBrackets=true},
                new SpecialElement(){Name="as", AllowBrackets=false},
                new SpecialElement(){Name="override", AllowBrackets=false},
                new SpecialElement(){Name="base", AllowBrackets=false},
                new SpecialElement(){Name="typeof", AllowBrackets=true}};

            SpecialElement[] basic_type = new SpecialElement[]{
                new SpecialElement(){Name="int", AllowBrackets=true},
                new SpecialElement(){Name="class", AllowBrackets=false},
                new SpecialElement(){Name="interface", AllowBrackets=false},
                new SpecialElement(){Name="char", AllowBrackets=true},
                new SpecialElement(){Name="string", AllowBrackets=true},
                new SpecialElement(){Name="var", AllowBrackets=true},
                new SpecialElement(){Name="double", AllowBrackets=true},
                new SpecialElement(){Name="long", AllowBrackets=true},
                new SpecialElement(){Name="bool", AllowBrackets=true},
                new SpecialElement(){Name="true", AllowBrackets=true},
                new SpecialElement(){Name="false", AllowBrackets=true},
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
                new SpecialElement(){Name="foreach", AllowBrackets=true},
                new SpecialElement(){Name="finally", AllowBrackets=true},
                new SpecialElement(){Name="break", AllowBrackets=false},
                new SpecialElement(){Name="in", AllowBrackets=false},
                new SpecialElement(){Name="switch", AllowBrackets=true},
                new SpecialElement(){Name="case", AllowBrackets=false},
                new SpecialElement(){Name="default", AllowBrackets=false},
                new SpecialElement(){Name="throw", AllowBrackets=false},
                new SpecialElement(){Name="return", AllowBrackets=false}
            };

            if ((from SpecialElement specEle in modif where specEle.Name.Equals(tok.Value) && (specEle.AllowBrackets || !brackets) select specEle).Count() > 0)
                return TokenType.MODIF;
            if ((from SpecialElement specEle in basic_type where specEle.Name.Equals(tok.Value) && (specEle.AllowBrackets || !brackets) select specEle).Count() > 0)
                return TokenType.BASIC_TYPE;
            if ((from SpecialElement specEle in flow_control where specEle.Name.Equals(tok.Value) && (specEle.AllowBrackets || !brackets) select specEle).Count() > 0)
                return TokenType.FLOW_CONTROL;
            if (tok.Value.Equals("#region") || tok.Value.Equals("#endregion"))
                return TokenType.REGION;
            return TokenType.NIEZNANE;
        }

        public static string GetColor(TokenType type)
        {
            switch (type)
            {
                case TokenType.STRING:
                    return "#cc6600";   //ciemnopomarańczowy
                case TokenType.ONE_LINE_COMMENT:
                    return "#00802b";   //wojskowy zielony
                case TokenType.MULTIPLE_LINE_COMMENT:
                    return "#00e64d";   //zielony
                case TokenType.MODIF:
                    return "#0000cc";   //granatowy
                case TokenType.FLOW_CONTROL:
                    return "#1ac6ff";   //jasnoniebieski
                case TokenType.BASIC_TYPE:
                    return "#cc33ff";   //fiolet
                case TokenType.CHAR:
                    return "#ffa64d";   //jasnopomaranczowy
                case TokenType.END_OF_CODE_LINE:
                    return "#ff66cc";   //róż
                case TokenType.KROPKA:
                    return "#ff66cc";   //róż
                case TokenType.PRZECINEK:
                    return "#ff66cc";   //róż
                case TokenType.LICZBA_CALKOWITA:
                    return "#ffff00";   //żółty
                case TokenType.LICZBA_WYMIERNA:
                    return "#999900";   //brudnożółty
                case TokenType.ERROR:
                    return "#ff0000";   //czerwony
                case TokenType.OP_ARYT:
                    return "#ff0000";   //krwisty
                case TokenType.OP_LOG:
                    return "#cc66ff";   //niebiesko-fioletowy
                case TokenType.REGION:
                    return "#999966";   //szary
                case TokenType.OP_POR:
                    return "#ffcc66";   //kremowy
                case TokenType.NAWIAS:
                    return "#00e64d";   //jasnozielony
                case TokenType.SLASH:
                    return "#ff66cc";   //róż
                case TokenType.PRZYPISANIE:
                    return "#66ffcc";   //morski
                case TokenType.NIEZNANE:
                    return "#ffffff";   //biały
                case TokenType.PUNCTUATIONMARK:
                    return "#ff0066";  //wściekły róż
                case TokenType.SPACE:
                    return null;
                case TokenType.END_OF_LINE:
                    return null;
                default:
                    throw new Exception("Nieobslugiwane kolorowanie!");
            }
        }

    }
}
