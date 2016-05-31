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
    public class FolderKML : KMLBase
    {
        [DataMember]
        [KMLMarkName("Placemark")]
        [KMLMarkGroupField]
        public List<PlacemarkKML> Placemark { get; set; }
    }
}
