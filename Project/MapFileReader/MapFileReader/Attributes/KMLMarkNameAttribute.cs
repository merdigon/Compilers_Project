﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Attributes
{
    public class KMLMarkNameAttribute : Attribute
    {
        public KMLMarkNameAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
