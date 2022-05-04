namespace Gaten.Net.Stock
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

        public string ListLabel => Code + " | " + Name;

        /// <summary>
        /// 현재가
        /// </summary>
        public int SpotPrice { get; set; }
        public string SpotPriceString => string.Format("{0:#,###}", SpotPrice);

        /// <summary>
        /// 전일대비
        /// </summary>
        public int DayOnDay { get; set; }
        public string DayOnDayString => Sign + string.Format("{0:#,###}", DayOnDay);

        /// <summary>
        /// 전일대비 증감율
        /// </summary>
        public double DayOnDayPercent { get; set; }
        public string DayOnDayPercentString => Sign + string.Format("{0}%", DayOnDayPercent);

        /// <summary>
        /// 전일대비 상승했는지 여부
        /// </summary>
        public bool IsPlus { get; set; }
        public string Sign => IsPlus ? "+" : "";
    }
}