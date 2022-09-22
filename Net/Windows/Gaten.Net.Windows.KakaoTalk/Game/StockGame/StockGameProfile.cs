using System.Numerics;

namespace Gaten.Net.Windows.KakaoTalk.Game.StockGame
{
    public class StockGameProfile
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public string MoneyString => Money.ToString("#,###");
        public List<Asset> Assets { get; set; } = new();

        public StockGameProfile(string name, decimal money, List<Asset> assets)
        {
            Name = name;
            Money = money;
            Assets = assets;
        }
    }
}
