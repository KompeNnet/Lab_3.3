using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books
{
    [DataContract]
    class Encyclopedia : Book
    {
        [DataMember]
        public string Subject { get; set; }

        public override string ToString()
        {
            return "Encyclopedia: " + Name;
        }
    }
}
