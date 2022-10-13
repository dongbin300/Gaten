using Gaten.Net.Stock.MercuryTradingModel.Enums;

using Newtonsoft.Json;

using Skender.Stock.Indicators;

namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class NamedElement
    {
        public string Name { get; set; } = string.Empty;
        public ChartElement Element { get; set; } = ChartElement.None;
        public decimal[] Parameters { get; set; } = new decimal[4];
        [JsonIgnore]
        public ResultBase Result { get; set; } = default!;

        public NamedElement()
        {

        }

        public NamedElement(string name, ChartElement element, decimal[] parameters)
        {
            Name = name;
            Element = element;
            Parameters = parameters;
        }

        public NamedElement(string name, string parameterString)
        {
            try
            {
                Name = name;
                var segments = parameterString.Split(',').Select(x => x.Trim()).ToArray();
                switch (segments[0])
                {
                    case "ma":
                        Element = ChartElement.ma;
                        Parameters[0] = decimal.Parse(segments[1]);
                        break;

                    case "ema":
                        Element = ChartElement.ema;
                        Parameters[0] = decimal.Parse(segments[1]);
                        break;

                    case "ri":
                        Element = ChartElement.ri;
                        Parameters[0] = decimal.Parse(segments[1]);
                        break;

                    case "rsi":
                        Element = ChartElement.rsi;
                        Parameters[0] = decimal.Parse(segments[1]);
                        break;

                    case "bb":
                        Element = ChartElement.bb;
                        Parameters[0] = decimal.Parse(segments[1]);
                        Parameters[1] = decimal.Parse(segments[2]);
                        break;

                    case "macd":
                        Element = ChartElement.macd;
                        Parameters[0] = decimal.Parse(segments[1]);
                        Parameters[1] = decimal.Parse(segments[2]);
                        Parameters[2] = decimal.Parse(segments[3]);
                        break;

                    default:
                        Element = ChartElement.None;
                        break;
                }
            }
            catch
            {
            }
        }
    }
}
