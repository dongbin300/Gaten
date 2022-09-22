using Gaten.Net.Extensions;

using System.Numerics;

namespace Gaten.Net.Windows.KakaoTalk.Game.StockGame
{
    public class StockItem
    {
        /// <summary>
        /// 종목코드
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 종목명
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 현재가
        /// </summary>
        public string Price { get; set; }
        public decimal _Price => Price.Convert<decimal>();
        public string PriceString => _Price.ToString("#,###");

        public StockItem(string code, string name, string price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
    }
}
