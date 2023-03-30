using Gaten.Net.Extensions;
using Gaten.Net.IO;

namespace Gaten.Study.TestConsole
{
    public partial class Program
    {
        public static DateTime GetStartDate(string symbol)
        {
            var fileNames = new DirectoryInfo(GResource.BinanceFuturesDataPath.Down("1m", symbol)).GetFiles("*.csv").OrderBy(x => x.Name);
            return GetDate(fileNames.First().Name);
        }

        public static DateTime GetEndDate(string symbol)
        {
            var fileNames = new DirectoryInfo(GResource.BinanceFuturesDataPath.Down("1m", symbol)).GetFiles("*.csv").OrderByDescending(x => x.Name);
            return GetDate(fileNames.First().Name);
        }

        public static DateTime GetEndDateOf1D(string symbol)
        {
            var data = File.ReadAllLines(GResource.BinanceFuturesDataPath.Down("1D", $"{symbol}.csv"));
            return DateTime.Parse(data[^1].Split(',')[0].Split(' ')[0]);
        }

        public static DateTime GetDate(string fileName)
        {
            return DateTime.Parse(fileName.Split('_', '.')[1]);
        }

        public static void Main()
        {
            var symbolDirectories = Directory.GetDirectories(GResource.BinanceFuturesDataPath.Down("1m"));

            foreach(var symbolDirectory in symbolDirectories)
            {
                var symbol = Path.GetFileName(symbolDirectory);

                var startDate = GetStartDate(symbol);
                var endDate = GetEndDate(symbol);

                var days = (endDate - startDate).Days;
                var fileCount = Directory.GetFiles(GResource.BinanceFuturesDataPath.Down("1m", symbol)).Length;

                Console.WriteLine($"{symbol}, {days}, {fileCount}");
            }
        }
    }
}
