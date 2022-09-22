namespace Gaten.Net.Windows.KakaoTalk.Game.StockGame
{
    public class IndexItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public IndexItem(string code, string name, decimal price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
    }
}
