using MapFileReader.Errors;
using MapFileReader.KMLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MapFileReader.Server.ServiceObjects
{
    [DataContract]
    public class MapReaderResponse
    {
        [DataMember]
        public FileKML KmlObject { get; set; }

        [DataMember]
        public List<ReaderError> Errors { get; set; }
    }
}