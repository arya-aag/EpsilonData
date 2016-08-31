using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace EpsilonOne
{
    [DataContract]
    public class Point
    {
        [DataMember]
        public double closeValue { get; private set; }
        [DataMember]
        public string relativeDateDifference { get; private set; }

    }
}
