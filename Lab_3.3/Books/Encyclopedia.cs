using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Books
{
    class Encyclopedia : Book
    {
        public string Subject { get; set; }

        public Encyclopedia(string author, string name, string office, string subject) : base(author, name, office, "Encyclopedia")
        {
            Subject = subject;
        }
    }
}
