using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Books.History
{
    class Biography : Historical
    {
        public bool IsAuthoBiography { get; set; }
        public string Years { get; set; }

        public Biography(string author, string name, string office, string period, bool isAuthoBiography, string years) : base(author, name, office, period)
        {
            IsAuthoBiography = isAuthoBiography;
            Years = years;
        }
    }
}
