namespace Lab_3._3.Books
{
    class Historical : Book
    {
        public string Period { get; set; }

        public Historical() { }

        public Historical(Book b) : base(b) { }

        public Historical(Historical h) : base(h)
        {
            this.Period = h.Period;
        }
    }
}
