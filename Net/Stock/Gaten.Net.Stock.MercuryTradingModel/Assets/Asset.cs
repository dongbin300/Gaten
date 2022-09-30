namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class Asset
    {
        /// <summary>
        /// 현금 잔고
        /// </summary>
        public decimal Balance { get; set; } = 0m;

        /// <summary>
        /// 포지션
        /// </summary>
        public Position Position { get; set; } = new();
    }
}
