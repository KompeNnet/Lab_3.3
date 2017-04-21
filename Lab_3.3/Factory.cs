using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3._3.Books;

namespace Lab_3._3
{
    class Factory
    {
        public Book Create(string[] needed)
        {
            switch (needed[0])
            {
                case "Encyclopedia": break;
            }
            return new Book();
        }
    }
}
