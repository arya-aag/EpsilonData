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
    public class MarketStockDetails
    {
        [DataMember]
        public MarketStock marketIndicators{ get; private set; }
        //[DataMember]
        //public string getStockType { get; private set; }
        [DataMember]
        public Decimal get52WeekHigh { get; private set; }
        [DataMember]
        public Decimal get52WeekLow { get; private set; }
        [DataMember]
        public double risk { get; private set; }
    }
}
