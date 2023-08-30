namespace Gaten.Study.TestWpf
{
    public class Pair
    {
        public string Symbol { get; set; }
        public string Price { get; set; }

        public Pair(string symbol, string price)
        {
            Symbol = symbol;
            Price = price;
        }
    }
}
