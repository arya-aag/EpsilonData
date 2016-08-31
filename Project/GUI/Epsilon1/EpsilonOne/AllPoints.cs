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
    public class AllPoints
    {
        [DataMember]
        public List<Point> stockCloseValueList { get; private set; }
        [DataMember]
        public string startDate { get; private set; }
        [DataMember]
        public string endDate { get; private set; }
        [DataMember]
        public string ticker { get; private set; }
    }
}
