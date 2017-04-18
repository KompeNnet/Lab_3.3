using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Books.Fictions
{
    class FairyTales : FantasticTales
    {
        public bool IsIllustrated;

        public FairyTales(string author, string name, string office, string age, string[] coAuthors, bool isIllustrated) : base(author, name, office, age, coAuthors)
        {
            IsIllustrated = isIllustrated;
        }
    }
}
