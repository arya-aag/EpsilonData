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
    public class MarketStock
    {
        [DataMember]
        public MarketPK id { get; private set; }
        [DataMember]
        public Decimal close { get; private set; }
        [DataMember]
        public Decimal high { get; private set; }
        [DataMember]
        public Decimal low { get; private set; }
        [DataMember]
        public Decimal open { get; private set; }
        [DataMember]
        public int volume { get; private set; }
    }
}
