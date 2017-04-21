using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books.Fictions
{
    [DataContract]
    class ScienceFiction : FantasticTales
    {
        [DataMember]
        public bool IsEarth { get; set; }
    }
}
