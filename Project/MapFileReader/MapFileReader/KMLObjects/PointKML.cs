﻿using MapFileReader.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.KMLObjects
{
    [KMLMarkClass]
    public class PointKML : KMLBase
    {
        [KMLMarkNameAttribute("coordinates")]
        public string Coordinate { get; set; }
    }
}
