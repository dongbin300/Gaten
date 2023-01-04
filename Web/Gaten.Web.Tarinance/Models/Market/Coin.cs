using Gaten.Net.Extensions;

using Newtonsoft.Json;

namespace Gaten.Web.Tarinance.Models.Market
{
    public class Coin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Price { get; set; }
        [JsonIgnore]
        public decimal _Price => Price.Convert<decimal>();
        [JsonIgnore]
        public string PriceString => _Price.ToString("#,###");
        public string PrevPrice { get; set; }
        [JsonIgnore]
        public decimal _PrevPrice => PrevPrice.Convert<decimal>();
        [JsonIgnore]
        public string PrevPriceString => _PrevPrice.ToString("#,###");
        public string Count { get; set; }
        [JsonIgnore]
        public decimal _Count => Count.Convert<decimal>();
        [JsonIgnore]
        public string CountString => _Count.ToString("#,###");

        public Coin()
        {

        }

        public Coin(string id, string name, string symbol, string price, string prevPrice, string count)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
            Price = price;
            PrevPrice = prevPrice;
            Count = count;
        }
    }
}
