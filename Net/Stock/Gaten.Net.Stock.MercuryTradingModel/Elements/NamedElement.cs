using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

using Newtonsoft.Json;

using static Gaten.Net.Stock.MercuryTradingModel.Indicators.IndicatorBaseValue;

namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class NamedElement : IElement
    {
        public string Name { get; set; } = string.Empty;
        public ChartElementType ElementType { get; set; } = ChartElementType.None;
        public decimal[] Parameters { get; set; } = new decimal[4];
        [JsonIgnore]
        public bool IsBaseElement { get; set; }

        public NamedElement()
        {

        }

        public NamedElement(string name, ChartElementType element, decimal[] parameters)
        {
            Name = name;
            ElementType = element;
            Parameters = parameters;
        }

        public NamedElement(string name, string parameterString)
        {
            try
            {
                Name = name;
                var segments = parameterString.Split(',').Select(x => x.Trim()).ToArray();
                segments[0] = segments[0].Replace('.', '_');
                ElementType = (ChartElementType)Enum.Parse(typeof(ChartElementType), segments[0]);

                // base element
                if (segments.Length == 1)
                {
                    IsBaseElement = true;
                    switch (ElementType)
                    {
                        case ChartElementType.ma:
                        case ChartElementType.ema:
                            Parameters[0] = MaPeriod;
                            return;

                        case ChartElementType.ri:
                        case ChartElementType.rsi:
                            Parameters[0] = RsiPeriod;
                            return;

                        case ChartElementType.bb_sma:
                        case ChartElementType.bb_upper:
                        case ChartElementType.bb_lower:
                            Parameters[0] = BollingerBandsPeriod;
                            Parameters[1] = BollingerBandsStandardDeviation;
                            return;

                        case ChartElementType.macd_macd:
                        case ChartElementType.macd_signal:
                        case ChartElementType.macd_hist:
                            Parameters[0] = MacdFastPeriod;
                            Parameters[1] = MacdSlowPeriod;
                            Parameters[2] = MacdSignalPeriod;
                            return;

                        default:
                            IsBaseElement = false;
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
                        break;

                    case ChartElementType.bb_sma:
                    case ChartElementType.bb_upper:
                    case ChartElementType.bb_lower:
                        Parameters[0] = decimal.Parse(segments[1]);
                        Parameters[1] = decimal.Parse(segments[2]);
                        break;

                    case ChartElementType.macd_macd:
                    case ChartElementType.macd_signal:
                    case ChartElementType.macd_hist:
                        Parameters[0] = decimal.Parse(segments[1]);
                        Parameters[1] = decimal.Parse(segments[2]);
                        Parameters[2] = decimal.Parse(segments[3]);
                        break;

                    default:
                        break;
                }
            }
            catch
            {
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
