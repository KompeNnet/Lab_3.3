﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books.History
{
    [DataContract]
    class Biography : Historical
    {
        [DataMember]
        public string Person { get; set; }

        [DataMember]
        public string Years { get; set; }
    }
}
