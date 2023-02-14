using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Net.Network;

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Controls;

namespace Gaten.Windows.Console
{
    public class ExternalTask
    {
        public static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }

        public static string GetInternalIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static string GetExternalIp()
        {
            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim();

            if (string.IsNullOrWhiteSpace(externalip))
            {
                externalip = GetInternalIp();
            }

            return externalip;
        }

        public static string GetWeatherString()
        {
            try
            {
                WebCrawler.SetUrl("https://weather.naver.com/today/02410105");
                var currentTemperature = WebCrawler.SelectNode("strong", "class", "current ").InnerText.Replace("현재 온도", "").Trim();
                var currentWeather = WebCrawler.SelectNode("span", "class", "weather").InnerText;

                WebCrawler.SetUrl("https://weather.naver.com/air/02410105");
                var nodes = WebCrawler.SelectNodes("em", "class", "grade_value", true);
                var mise = nodes[0].InnerText.Replace("\n", "").Replace("\t", "");
                var chomise = nodes[1].InnerText.Replace("\n", "").Replace("\t", "");

                return $"{currentTemperature} {currentWeather}\r\n미세: {mise}\r\n초미세: {chomise}";
            }
            catch
            {
                throw;
            }
        }

        public static string GetDiskDriveString()
        {
            try
            {
                StringBuilder builder = new();
                var driveInfo = DriveInfo.GetDrives();

                foreach (DriveInfo di in driveInfo)
                {
                    string label = di.Name == "C:\\" ? "로컬 디스크" : di.VolumeLabel;
                    string volume = di.Name.Replace(":\\", "");
                    string availableFreeSpace = di.AvailableFreeSpace / 1_000_000_000 + "GB";
                    string usingPercent = (int)(100 - (double)di.AvailableFreeSpace / di.TotalSize * 100) + "%";

                    builder.AppendLine($"{label,-10}{volume,-4}{availableFreeSpace,-10}{usingPercent,-8}");
                }

                return builder.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static string GetDictionaryString(string keyword)
        {
            try
            {
                WebCrawler.SetUrl($"https://dict.naver.com/search.nhn?dicQuery={keyword}&query={keyword}&target=dic&ie=utf8&query_utf=&isOnlyViewEE=");

                var builder = new StringBuilder();
                var nodes = WebCrawler.SelectNodes("//dl[@class='dic_search_result']/dd");
                foreach (var node in nodes)
                {
                    builder.AppendLine(node.InnerText.Trim()
                        .Replace("\t ", "")
                        .Replace("\t", "")
                        .Replace("\r\n", ""));
                }
                return builder.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static string GetStockPriceString()
        {
            try
            {
                int euckrCodePage = 51949;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding euckr = Encoding.GetEncoding(euckrCodePage);

                var builder = new StringBuilder();
                var stocks = GResource.GetTextLines("monitor_stock.txt").ToList();

                foreach (var stock in stocks)
                {
                    WebCrawler.Open($"https://finance.naver.com/item/main.naver?code={stock}");
                    var source = WebCrawler.Source;
                    var stockTitleSegments = WebCrawler.SelectNode("div", "class", "wrap_company").InnerText.Replace("\t", "").Split("\n", System.StringSplitOptions.RemoveEmptyEntries);
                    var segments = WebCrawler.SelectNode("div", "class", "today").InnerText.Replace("\t", "").Split("\n", System.StringSplitOptions.RemoveEmptyEntries);

                    builder.AppendLine($"{stockTitleSegments[0],-12}{segments[0],-10}{segments[7] + segments[8] + segments[10],-10}");
                }

                return builder.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static (string, string) GetRandomHanja()
        {
            try
            {
                int num = new Random(DateTime.Now.Millisecond).Next(74679);
                int convert =
                    num < 6592 ? num + 13312 :
                    num < 27584 ? num + 13376 :
                    num < 70304 ? num + 103488 :
                    num < 74457 ? num + 103520 :
                    num + 103527;
                string hex = convert.ToString("X");
                WebCrawler.SetUrl($"https://unicode-explorer.com/c/{hex}");
                string hanja = WebCrawler.SelectNode("div", "class", "char-big").InnerText;

                WebCrawler.SetUrl($"http://yoksa.aks.ac.kr/jsp/hh/HHBottom1.jsp?hh10_no=0-{hex}");
                var nodes = WebCrawler.SelectNodes("td", "align", "center");
                string dok = nodes != null && nodes.Count > 6 ? nodes[6].InnerText.Replace("&nbsp;", "") : string.Empty;

                return (hanja, "U+" + hex + "   " + dok);
            }
            catch
            {
                throw;
            }
        }

        public static string GetRandomWord()
        {
            try
            {
                WebCrawler.SetUrl("https://randomword.com/");
                string word = WebCrawler.SelectNode("div", "id", "random_word").InnerText;
                string meaning = WebCrawler.SelectNode("div", "id", "random_word_definition").InnerText;

                return word + "\n" + meaning;
            }
            catch
            {
                throw;
            }
        }

        record RNG_generateIntegers(string jsonrpc, string method, RNG_generateIntegers_params @params, int id);
        record RNG_generateIntegers_params(string apiKey, int n, int min, int max);

        record RNG_response_generateIntegers(RNG_response_generateIntegers_result result);
        record RNG_response_generateIntegers_result(RNG_response_generateIntegers_result_random random);
        record RNG_response_generateIntegers_result_random(int[] data);

        public static string GetRandomNumber(int min, int max)
        {
            try
            {
                var data = new RNG_generateIntegers(
                    "2.0",
                    "generateIntegers",
                    new RNG_generateIntegers_params(Common.RandomOrgKey, 1, min, max),
                    DateTime.Now.Millisecond);

                var jsonString = JsonSerializer.Serialize(data);
                var response = Http.RequestPost("https://api.random.org/json-rpc/4/invoke", jsonString);
                var responseObject = JsonSerializer.Deserialize<RNG_response_generateIntegers>(response) ?? default!;

                return responseObject.result.random.data[0].ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}
