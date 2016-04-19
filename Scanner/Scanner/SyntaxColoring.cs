using Compiler.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Compiler.Scanner
{
    public class SyntaxColoring
    {
        List<Token> Tokens { get; set; }

        public SyntaxColoring(List<Token> tokens)
        {
            this.Tokens = tokens;
        }

        private string GetTokenValueWithColor(Token token)
        {
            if (token.Color != null)
                return "<font color=\"" + token.Color + "\">" + token.Value + "</font>";
            else if (token.Type == TokenType.END_OF_LINE)
                return "</br>\n";
            else if (token.Type == TokenType.SPACE)
                return token.Value.Replace(" ", "&nbsp");
            else
                return token.Value;
        }

        public StringBuilder GetHTMLCode()
        {
            StringBuilder strBuild = new StringBuilder();
            foreach (Token tok in Tokens)
            {
                strBuild.Append(GetTokenValueWithColor(tok));
            }
            return strBuild;
        }

        public void SaveColoredTokenToFile(string path)
        {
            using (StreamWriter stw = new StreamWriter(path))
            {
                try
                {
                    stw.WriteLine("<html>");
                    stw.WriteLine("<head>");
                    stw.WriteLine("</head>");
                    stw.WriteLine("<body bgcolor=\"#000000\">");
                    stw.WriteLine(GetHTMLCode().ToString());
                    stw.WriteLine("</body>");
                    stw.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (stw != null)
                        stw.Close();
                }
            }
        }
    }
}
