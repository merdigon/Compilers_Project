using MapFileReader.DTO;
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
            KMLScanner scanner = new KMLScanner();
            scanner.SetFileReader(@"C:\Users\Szymon\Desktop\kmlExample.xml");
            List<Token> tokens = scanner.GetTokens();
            tokens.ForEach(p => Console.WriteLine(p.TokenType.ToString() + " : " + p.Value + " : " + p.AdditionalInfo));
            KMLParser parser = new KMLParser(tokens);
            ParserResponse outputFile = parser.ParseTokens();
            XmlSerializer ser = new XmlSerializer(outputFile.ResponseObject.GetType());
            ser.Serialize(Console.Out, outputFile.ResponseObject);
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Errory:");
            outputFile.ResponseErrorList.ForEach(p => Console.WriteLine(string.Format("{0} => {1} : {2}", p.ErrorType.ToString(), p.Value, p.AdditionalInfo)));
            Console.ReadLine();
        }
    }
}
