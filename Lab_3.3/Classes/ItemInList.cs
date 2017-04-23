using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3._3.Books;

namespace Lab_3._3.Classes
{
    class ItemInList
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Book Data { get; set; }
    }
}
