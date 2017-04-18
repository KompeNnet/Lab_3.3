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
        public string Author { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PublishingOffice { get; set; }

        [DataMember]
        public string Genre { get; set; }

        public Book(string author, string name, string office, string genre)
        {
            Author = author;
            Name = name;
            PublishingOffice = office;
            Genre = genre;
        }
    }
}
