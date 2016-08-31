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
    public class MarketPK
    {
        [DataMember]
        public string date { get; private set; }
        [DataMember]
        public string ticker { get; private set; }

    }
}
