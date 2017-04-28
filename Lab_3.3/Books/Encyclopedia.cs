namespace Lab_3._3.Books
{
    class Encyclopedia : Book
    {
        public string Subject { get; set; }

        public Encyclopedia() { }

        public Encyclopedia(Book b) : base(b) { }

        public Encyclopedia(Encyclopedia e) : base(e)
        {
            this.Subject = e.Subject;
        }
    }
}
