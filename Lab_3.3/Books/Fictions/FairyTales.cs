namespace Lab_3._3.Books.Fictions
{
    class FairyTales : FantasticTales
    {
        public bool IsIllustrated { get; set; }

        public FairyTales() { }

        public FairyTales(FantasticTales f) : base(f) { }

        public FairyTales(FairyTales f) : base(f)
        {
            this.IsIllustrated = f.IsIllustrated;
        }
    }
}
