namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class NamedElementResult
    {
        public string Name { get; set; }
        public decimal? Value { get; set; }

        public NamedElementResult(string name, decimal? value)
        {
            Name = name;
            Value = value;
        }
    }
}
