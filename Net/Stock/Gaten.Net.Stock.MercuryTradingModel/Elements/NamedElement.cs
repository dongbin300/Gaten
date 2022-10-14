using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

using Newtonsoft.Json;

using Skender.Stock.Indicators;

namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class NamedElement : IElement
    {
        public string Name { get; set; } = string.Empty;
        public ChartElementType ElementType { get; set; } = ChartElementType.None;
        public decimal[] Parameters { get; set; } = new decimal[4];

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
                switch (segments[0])
                {
                    case "ma":
                    case "ema":
                    case "ri":
                    case "rsi":
                        ElementType = (ChartElementType)Enum.Parse(typeof(ChartElementType), segments[0]);
                        Parameters[0] = decimal.Parse(segments[1]);
                        break;

                    case "bb_sma":
                    case "bb_upper":
                    case "bb_lower":
                        ElementType = (ChartElementType)Enum.Parse(typeof(ChartElementType), segments[0]);
                        Parameters[0] = decimal.Parse(segments[1]);
                        Parameters[1] = decimal.Parse(segments[2]);
                        break;

                    case "macd_macd":
                    case "macd_signal":
                    case "macd_hist":
                        ElementType = (ChartElementType)Enum.Parse(typeof(ChartElementType), segments[0]);
                        Parameters[0] = decimal.Parse(segments[1]);
                        Parameters[1] = decimal.Parse(segments[2]);
                        Parameters[2] = decimal.Parse(segments[3]);
                        break;

                    default:
                        ElementType = ChartElementType.None;
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
