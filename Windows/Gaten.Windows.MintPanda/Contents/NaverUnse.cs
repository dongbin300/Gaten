using Gaten.Net.Diagnostics;
using Gaten.Net.Network;

using System;
using System.Reflection;

namespace Gaten.Windows.MintPanda.Contents
{
    public class NaverUnse
    {
        public static string Get()
        {
            try
            {
                WebCrawler.SetUrl("https://search.naver.com/search.naver?where=nexearch&sm=top_hty&fbm=0&ie=utf8&query=%EC%98%A4%EB%8A%98%EC%9D%98+%EC%9A%B4%EC%84%B8");
                var re = WebCrawler.Source;
                return string.Empty;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(NaverUnse), MethodBase.GetCurrentMethod()?.Name, ex);
                return "Error";
            }
        }
    }
}
