using MapFileReader.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.KMLObjects
{
    [KMLMarkClass]
    public class FileKML : KMLBase
    {
        [KMLMarkName("Placemark")]
        public PlacemarkKML Placemark { get; set; }
    }
}
