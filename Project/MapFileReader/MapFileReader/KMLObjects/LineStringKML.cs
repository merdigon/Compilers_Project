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
    public class LineStringKML : KMLBase
    {
        [DataMember]
        [KMLMarkOptional]
        [KMLMarkNameAttribute("tessellate")]
        public string Tessellate { get; set; }
        
        [DataMember]
        [KMLMarkNameAttribute("coordinates")]
        public string Coordinates { get; set; }
    }
}
