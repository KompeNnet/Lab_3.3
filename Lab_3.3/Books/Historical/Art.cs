using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Books.History
{
    class Art : Historical
    {
        public string ArtForm { get; set; }

        public Art(string author, string name, string office, string period, string artForm) : base(author, name, office, period)
        {
            ArtForm = artForm;
        }
    }
}
