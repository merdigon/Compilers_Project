using MapFileReader.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.KMLObjects
{

    public class PointKML
    {
        [KMLAttribute("coordinate")]
        public string Coordinate { get; set; }
    }
}
