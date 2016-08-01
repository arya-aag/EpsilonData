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
    public class VolumeShare
    {
        [DataMember]
        public string type_ { get; private set; }
        [DataMember]
        public long volume { get; private set; }
    }
}
