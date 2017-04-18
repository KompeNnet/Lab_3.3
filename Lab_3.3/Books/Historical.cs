using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books
{
    [DataContract]
    class Historical : Book
    {
        [DataMember]
        public string Period { get; set; }

        public Historical(string author, string name, string office, string period) : base(author, name, office, "Historical")
        {
            Period = period;
        }
    }
}
