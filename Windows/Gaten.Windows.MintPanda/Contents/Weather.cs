using Gaten.Net.Network;

namespace Gaten.Windows.MintPanda.Contents
{
    internal class Weather
    {
        public static string Get()
        {
            WebCrawler.SetUrl("https://weather.naver.com/today/02410105");
            var currentTemperature = WebCrawler.SelectNode("strong", "class", "current ").InnerText.Replace("현재 온도", "").Trim();
            var currentWeather = WebCrawler.SelectNode("span", "class", "weather").InnerText;
            //var currentWeatherStatus = WebCrawler.SelectNode("table", "class", "weather_table").InnerText;

            WebCrawler.SetUrl("https://weather.naver.com/air/02410105");
            var nodes = WebCrawler.SelectNodes("em", "class", "grade_value", true);
            var mise = nodes[0].InnerText.Replace("\n", "").Replace("\t", "");
            var chomise = nodes[1].InnerText.Replace("\n", "").Replace("\t", "");

            return $"{currentTemperature} {currentWeather}   미세: {mise}   초미세: {chomise}";
        }
    }
}
