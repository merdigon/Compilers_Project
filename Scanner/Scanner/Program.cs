using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Scanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Scanner scan = new Scanner();
            scan.AnalizeInput();
            SyntaxColoring syntColor = new SyntaxColoring(scan.tokens);
            syntColor.SaveColoredTokenToFile("C:\\Users\\Szymon\\Desktop\\code.html");
            scan.ShowTokens();
            Console.ReadLine();
        }
    }
}
