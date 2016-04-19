using MapFileReader.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.KMLObjects
{
    [KMLMarkClass]
    public class PlacemarkKML : KMLBase
    {
        [KMLMarkNameAttribute("name")]
        public string Name { get; set; }
        
        [KMLMarkNameAttribute("description")]
        public string Description { get; set; }

        [KMLMarkNameAttribute("Point")]
        public PointKML Point { get; set; }
    }
}
