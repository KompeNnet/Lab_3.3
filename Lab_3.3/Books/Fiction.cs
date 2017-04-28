namespace Lab_3._3.Books
{
    class Fiction : Book
    {
        public string Type { get; set; }
        public string Age { get; set; }

        public Fiction() { }

        public Fiction(Book b) : base(b) { }

        public Fiction(Fiction f) : base(f)
        {
            this.Type = f.Type;
            this.Age = f.Age;
        }
    }
}
