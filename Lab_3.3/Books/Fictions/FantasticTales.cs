using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab_3._3.Books.Fictions
{
    [DataContract]
    class FantasticTales : Fiction
    {
        [DataMember]
        public string[] CoAuthors { get; set; }

        public FantasticTales(string author, string name, string office, string age, string[] coAuthors) : base(author, name, office, "Fiction", age)
        {
            CoAuthors = coAuthors;
        }
    }
}
