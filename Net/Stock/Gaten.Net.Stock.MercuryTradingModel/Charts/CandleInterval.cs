using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Charts
{
    public class CandleInterval
    {
        public int Number { get; set; }
        public CandleIntervalUnit CandleIntervalUnit { get; set; }

        public CandleInterval(int number, CandleIntervalUnit candleIntervalUnit)
        {
            Number = number;
            CandleIntervalUnit = candleIntervalUnit;
        }

        public CandleInterval(string intervalFormatString)
        {
            switch (intervalFormatString)
            {
                case "1m":
                    Number = 1;
                    CandleIntervalUnit = CandleIntervalUnit.Minute;
                    break;

                case "3m":
                    Number = 3;
                    CandleIntervalUnit = CandleIntervalUnit.Minute;
                    break;

                case "5m":
                    Number = 5;
                    CandleIntervalUnit = CandleIntervalUnit.Minute;
                    break;

                case "15m":
                    Number = 15;
                    CandleIntervalUnit = CandleIntervalUnit.Minute;
                    break;

                case "30m":
                    Number = 30;
                    CandleIntervalUnit = CandleIntervalUnit.Minute;
                    break;

                case "1h":
                    Number = 1;
                    CandleIntervalUnit = CandleIntervalUnit.Hour;
                    break;

                case "2h":
                    Number = 2;
                    CandleIntervalUnit = CandleIntervalUnit.Hour;
                    break;

                case "4h":
                    Number = 4;
                    CandleIntervalUnit = CandleIntervalUnit.Hour;
                    break;

                case "6h":
                    Number = 6;
                    CandleIntervalUnit = CandleIntervalUnit.Hour;
                    break;

                case "8h":
                    Number = 8;
                    CandleIntervalUnit = CandleIntervalUnit.Hour;
                    break;

                case "12h":
                    Number = 12;
                    CandleIntervalUnit = CandleIntervalUnit.Hour;
                    break;

                case "1d":
                    Number = 1;
                    CandleIntervalUnit = CandleIntervalUnit.Day;
                    break;

                case "3d":
                    Number = 3;
                    CandleIntervalUnit = CandleIntervalUnit.Day;
                    break;

                case "1w":
                    Number = 1;
                    CandleIntervalUnit = CandleIntervalUnit.Week;
                    break;

                case "1M":
                    Number = 1;
                    CandleIntervalUnit = CandleIntervalUnit.Month;
                    break;

                default:
                    Number = 1;
                    CandleIntervalUnit = CandleIntervalUnit.Minute;
                    break;
            }
        }
    }
}
