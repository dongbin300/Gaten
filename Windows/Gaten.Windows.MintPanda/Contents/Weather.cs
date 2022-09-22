using Gaten.Net.Diagnostics;
using Gaten.Net.Network;

using System;
using System.Reflection;

namespace Gaten.Windows.MintPanda.Contents
{
    internal class Weather
    {
        public static string Get()
        {
            try
            {
                WebCrawler.SetUrl("https://weather.naver.com/today/02410105");
                var currentTemperature = WebCrawler.SelectNode("strong", "class", "current ").InnerText.Replace("현재 온도", "").Trim();
                var currentWeather = WebCrawler.SelectNode("span", "class", "weather").InnerText;
                //var currentWeatherStatus = WebCrawler.SelectNode("table", "class", "weather_table").InnerText;

                WebCrawler.SetUrl("https://weather.naver.com/air/02410105");
                var nodes = WebCrawler.SelectNodes("em", "class", "grade_value", true);
                var mise = nodes[0].InnerText.Replace("\n", "").Replace("\t", "");
                var chomise = nodes[1].InnerText.Replace("\n", "").Replace("\t", "");

                return $"{currentTemperature} {currentWeather}\r\n미세: {mise}\r\n초미세: {chomise}";
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Weather), MethodBase.GetCurrentMethod()?.Name, ex);
            }

            return string.Empty;
        }
    }
}