using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3._3.Books;
using Lab_3._3.Books.History;
using Lab_3._3.Books.Fictions;

namespace Lab_3._3.Serialize
{
    class Factory
    {
        public Book Create(string[] needed)
        {
            if (needed[0] == "Historical")
                switch (needed[1])
                {
                    case "Art": return new Art();
                    case "Biography": return new Biography();
                }
            if (needed[0] == "Historical")
                switch (needed[2])
                {
                    case "Fantastic tales":
                        if (needed[3] == "FairyTales") return new FairyTales();
                        return new ScienceFiction();
                    case "Travelling": return new Travelling();
                }
            return new Encyclopedia();
        }
    }
}
