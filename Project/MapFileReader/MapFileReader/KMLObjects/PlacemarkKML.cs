using MapFileReader.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.KMLObjects
{
    public class PlacemarkKML
    {
        [KMLAttribute("name")]
        public string Name { get; set; }
        
        [KMLAttribute("description")]
        public string Description { get; set; }

        [KMLAttribute("Point")]
        public PointKML Point { get; set; }
    }
}
