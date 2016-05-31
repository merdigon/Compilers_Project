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
        [KMLMarkNameAttribute("name")]
        public string Name { get; set; }

        [DataMember]
        [KMLMarkOptional]
        [KMLMarkNameAttribute("description")]
        public string Description { get; set; }

        [DataMember]
        [KMLMarkOptional]
        [KMLMarkNameAttribute("Point")]
        public PointKML Point { get; set; }
        
        [DataMember]
        [KMLMarkOptional]
        [KMLMarkNameAttribute("LineString")]
        public LineStringKML LineString { get; set; }
    }
}
