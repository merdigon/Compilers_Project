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
    public class PointKML : KMLBase
    {
        [DataMember]
        [KMLMarkNameAttribute("coordinates")]
        public string Coordinate { get; set; }
    }
}
