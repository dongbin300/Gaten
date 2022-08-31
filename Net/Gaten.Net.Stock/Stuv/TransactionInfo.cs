namespace Gaten.Net.Stock.STUV
{
    public class TransactionInfo
    {
        /// <summary>
        /// 체결시간
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 단가
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 거래량
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// 체결타입
        /// (0-매도, 1-매수)
        /// </summary>
        public TransactionType TransactionType { get; set; }

        public string PriceString => Price.ToString("#,###");
        public string VolumeString => Volume.ToString("#,###");
    }

    public enum TransactionType
    {
        Sell,
        Buy
    }
}
