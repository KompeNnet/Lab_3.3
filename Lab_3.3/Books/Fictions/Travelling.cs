using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books.Fictions
{
    [DataContract]
    class Travelling : Fiction
    {
        [DataMember]
        public string[] Countries { get; set; }
        
        public Travelling(string author, string name, string office, string[] countries) : base(author, name, office, "Original", "16+")
        {
            Countries = countries;
        }
    }
}
