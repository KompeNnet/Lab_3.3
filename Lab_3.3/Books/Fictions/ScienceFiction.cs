using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Books.Fictions
{
    class ScienceFiction : FantasticTales
    {
        public bool IsEarth { get; set; }

        public ScienceFiction(string author, string name, string office, string age, string[] coAuthors, bool isEarth) : base(author, name, office, age, coAuthors)
        {
            IsEarth = isEarth;
        }
    }
}
