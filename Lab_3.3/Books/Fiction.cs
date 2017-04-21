using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books
{
    [DataContract]
    class Fiction : Book
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Age { get; set; }
    }
}
