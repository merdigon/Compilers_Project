using MapFileReader.KMLObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Parser
{
    public class KMLObjectStackVersion
    {
        public KMLBase KmlObject { get; set; }
        public string TokenName { get; set; }
    }
}
