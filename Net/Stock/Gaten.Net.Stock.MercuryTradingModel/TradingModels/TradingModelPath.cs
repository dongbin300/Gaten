using Gaten.Net.IO;

namespace Gaten.Net.Stock.MercuryTradingModel.TradingModels
{
    public class TradingModelPath
    {
        public static string InspectedDirectory => Environment.CurrentDirectory.Down("Temp");
        public static string InspectedBackTestDirectory => InspectedDirectory.Down("BackTest");
        public static string InspectedMockTradeDirectory => InspectedDirectory.Down("MockTrade");
        public static string InspectedRealTradeDirectory => InspectedDirectory.Down("RealTrade");

        public static void Init()
        {
            GPath.TryCreateDirectory(InspectedDirectory);
            GPath.TryCreateDirectory(InspectedBackTestDirectory);
            GPath.TryCreateDirectory(InspectedMockTradeDirectory);
            GPath.TryCreateDirectory(InspectedRealTradeDirectory);
        }
    }
}
