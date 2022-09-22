namespace Gaten.Net.Windows.KakaoTalk.Game.StockGame
{
    public class AssetRankingClass
    {
        public string Name { get; set; }
        public decimal SumAsset { get; set; }

        public AssetRankingClass(string name, decimal sumAsset)
        {
            Name = name;
            SumAsset = sumAsset;
        }
    }
}
