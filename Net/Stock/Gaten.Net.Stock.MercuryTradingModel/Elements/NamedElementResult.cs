namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class NamedElementResult
    {
        public string Name { get; set; }
        public double? Value { get; set; }

        public NamedElementResult(string name, double? value)
        {
            Name = name;
            Value = value;
        }
    }
}
