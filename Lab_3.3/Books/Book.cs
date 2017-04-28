namespace Lab_3._3.Books
{
    public class Book
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string PublishingOffice { get; set; }
        public string Genre { get; set; }

        public Book() { }

        public Book(Book b)
        {
            this.Author = b.Author;
            this.Name = b.Name;
            this.PublishingOffice = b.PublishingOffice;
            this.Genre = b.Genre;
        }
    }
}
