using MapFileReader.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.KMLObjects
{
    [DataContract]
    [KMLMarkClass]
    public class FileKML : KMLBase
    {
        [DataMember]
        [KMLMarkName("Placemark")]
        public PlacemarkKML Placemark { get; set; }
    }
}
