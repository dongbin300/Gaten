namespace Gaten.Net.Stock.MercuryTradingModel.Indicators
{
    public class IndicatorBaseValue
    {
        public static readonly decimal MaPeriod = 60;
        public static readonly decimal RsiPeriod = 14;
        public static readonly decimal BollingerBandsPeriod = 20;
        public static readonly decimal BollingerBandsStandardDeviation = 2.0m;
        public static readonly decimal MacdFastPeriod = 12;
        public static readonly decimal MacdSlowPeriod = 26;
        public static readonly decimal MacdSignalPeriod = 9;
    }
}
