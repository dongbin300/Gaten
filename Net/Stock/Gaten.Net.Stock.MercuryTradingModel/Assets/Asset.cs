namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class Asset
    {
        /// <summary>
        /// 시드 금액
        /// </summary>
        public decimal Seed { get; set; } = 0m;

        /// <summary>
        /// 현금 잔고
        /// </summary>
        public decimal Balance { get; set; } = 0m;

        /// <summary>
        /// 포지션
        /// </summary>
        public Position Position { get; set; } = new();

        public Asset(decimal seed, Position position)
        {
            Seed = seed;
            Balance = seed;
            Position = position;
        }
    }
}
