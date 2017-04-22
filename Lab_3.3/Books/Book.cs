using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PublishingOffice { get; set; }

        [DataMember]
        public string Genre { get; set; }
    }
}
