namespace svaerke.github.io.Models {
    public partial class CurrencyModel
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public double Size { get; set; }

        public double Denomination { get; set; }

        public CurrencyType Type { get; set; }

        public double AspectRatio { get; set; } = 1;
    }
}
