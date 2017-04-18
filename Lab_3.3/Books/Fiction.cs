using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Books
{
    class Fiction : Book
    {
        public string Type { get; set; }
        public string Age { get; set; }

        public Fiction(string author, string name, string office, string type, string age) : base(author, name, office, "Fiction")
        {
            Type = type;
            Age = age;
        }
    }
}
