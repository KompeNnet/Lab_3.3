using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books.History
{
    [DataContract]
    class Art : Historical
    {
        [DataMember]
        public string ArtForm { get; set; }
    }
}
