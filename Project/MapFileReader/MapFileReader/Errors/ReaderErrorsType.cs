using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Errors
{
    [DataContract]
    [Flags]
    public enum ReaderErrorsType
    {
        [EnumMember]
        SCANNER,

        [EnumMember]
        PARSER
    }
}
