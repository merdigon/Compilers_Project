using MapFileReader.Errors;
using MapFileReader.KMLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.DTO
{
    public class ParserResponse
    {
        public KMLBase ResponseObject { get; set; }
        public List<ReaderError> ResponseErrorList { get; set; }
    }
}
