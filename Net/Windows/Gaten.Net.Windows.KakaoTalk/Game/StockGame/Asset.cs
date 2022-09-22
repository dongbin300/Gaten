using Gaten.Net.Extensions;

using System.Numerics;

namespace Gaten.Net.Windows.KakaoTalk.Game.StockGame
{
    public class Asset
    {
        /// <summary>
        /// 종목코드
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 주식 보유 수
        /// </summary>
        public string Quantity { get; set; }
        public decimal _Quantity => Quantity.Convert<decimal>();

        /// <summary>
        /// 주식 매입금액
        /// </summary>
        public string Amount { get; set; }
        public decimal _Amount => Amount.Convert<decimal>();

        public Asset(string code, string quantity, string amount)
        {
            Code = code;
            Quantity = quantity;
            Amount = amount;
        }
    }
}
