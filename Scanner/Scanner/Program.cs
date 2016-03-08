using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Scanner scan = new Scanner();
            scan.AnalizeInput();
            scan.ShowTokens();
            Console.ReadLine();
        }
    }
}
