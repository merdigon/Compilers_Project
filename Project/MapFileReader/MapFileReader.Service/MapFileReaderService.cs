using MapFileReader.KMLObjects;
using MapFileReader.Parser;
using MapFileReader.Scanner;
using MapFileReader.Server.ServiceObjects;
using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MapFileReader.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MapFileReaderService : IMapFileReaderService
    {
        public MapReaderResponse ReadMap(string value)
        {
            KMLScanner scanner = new KMLScanner();
            scanner.SetMapValue(value);
            List<Token> tokens = scanner.GetTokens();
            var response = new KMLParser(tokens).ParseTokens();
            return new MapReaderResponse()
            {
                KmlObject = (response.ResponseObject is FolderKML ? new FileKML() { Folder = (FolderKML)response.ResponseObject } : (FileKML)response.ResponseObject),
                Errors = response.ResponseErrorList
            };
        }
    }
}
