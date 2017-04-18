using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Books.Fictions
{
    class FantasticTales : Fiction
    {
        public string[] CoAuthors { get; set; }

        public FantasticTales(string author, string name, string office, string age, string[] coAuthors) : base(author, name, office, "Fiction", age)
        {
            CoAuthors = coAuthors;
        }
    }
}
