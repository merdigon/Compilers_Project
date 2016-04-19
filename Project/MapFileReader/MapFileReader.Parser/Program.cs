using MapFileReader.KMLObjects;
using MapFileReader.Scanner;
using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MapFileReader.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            KMLScanner scanner = new KMLScanner(@"C:\Users\Szymon\Desktop\kmlExample.xml");
            List<Token> tokens = scanner.GetTokensFromFile();
            tokens.ForEach(p => Console.WriteLine(p.TokenType.ToString() + " : " + p.Value + " : " + p.AdditionalInfo));
            KMLParser parser = new KMLParser(tokens);
            XmlSerializer ser = new XmlSerializer(typeof(FileKML));
            FileKML outputFile = parser.ParseTokens();
            ser.Serialize(Console.Out, outputFile);
            Console.ReadLine();
        }
    }
}
