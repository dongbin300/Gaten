using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

using Newtonsoft.Json;

namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class ChartElement : IElement
    {
        private static readonly decimal MaPeriodDefault = 60;
        private static readonly decimal RsiPeriodDefault = 14;
        private static readonly decimal BollingerBandsPeriodDefault = 20;
        private static readonly decimal BollingerBandsStandardDeviationDefault = 2.0m;
        private static readonly decimal MacdFastPeriodDefault = 12;
        private static readonly decimal MacdSlowPeriodDefault = 26;
        private static readonly decimal MacdSignalPeriodDefault = 9;

        public ChartElementType ElementType { get; set; } = ChartElementType.None;
        public decimal[] Parameters { get; set; } = new decimal[4];
        [JsonIgnore]
        public bool IsDefaultElement { get; set; }

        public ChartElement()
        {

        }

        public ChartElement(ChartElementType element, decimal[] parameters)
        {
            ElementType = element;
            Parameters = parameters;
        }

        public ChartElement(string elementString)
        {
            try
            {
                var segments = elementString.Split(',').Select(x => x.Trim()).ToArray();
                segments[0] = segments[0].Replace('.', '_');
                ElementType = (ChartElementType)Enum.Parse(typeof(ChartElementType), segments[0]);

                // default element
                if (segments.Length == 1)
                {
                    IsDefaultElement = true;
                    switch (ElementType)
                    {
                        case ChartElementType.ma:
                        case ChartElementType.ema:
                            Parameters[0] = MaPeriodDefault;
                            return;

                        case ChartElementType.ri:
                        case ChartElementType.rsi:
                            Parameters[0] = RsiPeriodDefault;
                            return;

                        case ChartElementType.bb_sma:
                        case ChartElementType.bb_upper:
                        case ChartElementType.bb_lower:
                            Parameters[0] = BollingerBandsPeriodDefault;
                            Parameters[1] = BollingerBandsStandardDeviationDefault;
                            return;

                        case ChartElementType.macd_macd:
                        case ChartElementType.macd_signal:
                        case ChartElementType.macd_hist:
                            Parameters[0] = MacdFastPeriodDefault;
                            Parameters[1] = MacdSlowPeriodDefault;
                            Parameters[2] = MacdSignalPeriodDefault;
                            return;

                        default:
                            IsDefaultElement = false;
                            return;
                    }
                }

                // parametered element
                switch (ElementType)
                {
                    case ChartElementType.ma:
                    case ChartElementType.ema:
                    case ChartElementType.ri:
                    case ChartElementType.rsi:
                        Parameters[0] = decimal.Parse(segments[1]);
                        return;

                    case ChartElementType.bb_sma:
                    case ChartElementType.bb_upper:
                    case ChartElementType.bb_lower:
                        ElementType = (ChartElementType)Enum.Parse(typeof(ChartElementType), segments[0]);
                        Parameters[0] = decimal.Parse(segments[1]);
                        Parameters[1] = decimal.Parse(segments[2]);
                        return;

                    case ChartElementType.macd_macd:
                    case ChartElementType.macd_signal:
                    case ChartElementType.macd_hist:
                        ElementType = (ChartElementType)Enum.Parse(typeof(ChartElementType), segments[0]);
                        Parameters[0] = decimal.Parse(segments[1]);
                        Parameters[1] = decimal.Parse(segments[2]);
                        Parameters[2] = decimal.Parse(segments[3]);
                        return;

                    default:
                        return;
                }
            }
            catch
            {
            }
        }

        public override string ToString()
        {
            var meaningfulParameters = Parameters.Where(x => x != 0);
            return ElementType.ToString() + (meaningfulParameters.Any() ? $"({string.Join(',', meaningfulParameters)})" : "");
        }
    }
}
