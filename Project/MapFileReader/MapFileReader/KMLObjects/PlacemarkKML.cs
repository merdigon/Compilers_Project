using MapFileReader.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.KMLObjects
{
    [KMLMarkClass]
    [DataContract]
    public class PlacemarkKML : KMLBase
    {
        [DataMember]
        [KMLMarkOptional]
        [KMLMarkNameAttribute("description")]
        public string Description { get; set; }

        [DataMember]
        [KMLMarkNameAttribute("name")]
        public string Name { get; set; }

        [DataMember]
        [KMLMarkNameAttribute("Point")]
        public PointKML Point { get; set; }
    }
}
