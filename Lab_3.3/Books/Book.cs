using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books
{
    [DataContract]
    class Book
    {
        [DataMember]
        string Author { get; set; }

        [DataMember]
        string Name { get; set; }

        [DataMember]
        string PublishingOffice { get; set; }

        [DataMember]
        string Genre { get; set; }
    }
}
