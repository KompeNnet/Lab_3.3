namespace Lab_3._3.Books.Fictions
{
    class Travelling : Fiction
    {
        public string Countries { get; set; }

        public Travelling() { }

        public Travelling(Fiction f) : base(f) { }

        public Travelling(Travelling t) : base(t)
        {
            this.Countries = t.Countries;
        }
    }
}
