using Gaten.Stock.MercuryEditor.Enums;

namespace Gaten.Stock.MercuryEditor.Inspection.SystemCode
{
    internal class MercurySystemCodeFormat
    {
        public int CodeVersion { get; set; } = 0;
        public MarketPlatform MarketPlatform { get; set; } = MarketPlatform.None;
        public ModelType ModelType { get; set; } = ModelType.None;
    }
}
