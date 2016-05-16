using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + @"\..\..\..\..\Grammatica\map.grammar";
            using (StreamWriter strWriter = new StreamWriter(path))
            {
                StringBuilder strBuilder = new GrammaGenerator().CreateGramma();
                strWriter.WriteLine(strBuilder.ToString());
                strWriter.Flush();
            }
        }
    }
}
