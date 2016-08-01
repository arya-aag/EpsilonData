﻿using System;
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
        public double yCoordinate { get; private set; }
        [DataMember]
        public int date { get; private set; }

    }
}
