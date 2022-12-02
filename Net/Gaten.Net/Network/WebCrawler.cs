using HtmlAgilityPack;

using System.Net;

namespace Gaten.Net.Network
{
    public class WebCrawler
    {
        public static string Source = string.Empty;

        static HttpClient client = new();
        static HtmlDocument htmlDocument = default!;

        public static void Open(string url = "")
        {
            htmlDocument = new HtmlDocument();

            if (!string.IsNullOrEmpty(url))
            {
                SetUrl(url);
            }
        }

        public static void Close()
        {
            client.Dispose();
        }

        public static void SetUrl(string url)
        {
            Source = Request(url);
            htmlDocument.LoadHtml(Source);
        }

        public static void SetHtml(string html)
        {
            htmlDocument ??= new HtmlDocument();
            htmlDocument.LoadHtml(html);
        }

        public static HtmlNode SelectNode(string xpath)
        {
            return htmlDocument.DocumentNode.SelectSingleNode(xpath);
        }

        /// <summary>
        /// //tag[@attribute='argument']
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="attribute"></param>
        /// <param name="argument"></param>
        /// <param name="isContain"></param>
        /// <returns></returns>
        public static HtmlNode SelectNode(string tag, string attribute, string argument, bool isContain = false)
        {
            return htmlDocument.DocumentNode.SelectSingleNode(ToXPath(tag, attribute, argument, isContain));
        }

        public static HtmlNodeCollection SelectNodes(string xpath)
        {
            return htmlDocument.DocumentNode.SelectNodes(xpath);
        }

        /// <summary>
        /// //tag[@attribute='argument']
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="attribute"></param>
        /// <param name="argument"></param>
        /// <param name="isContain"></param>
        /// <returns></returns>
        public static HtmlNodeCollection SelectNodes(string tag, string attribute, string argument, bool isContain = false)
        {
            return htmlDocument.DocumentNode.SelectNodes(ToXPath(tag, attribute, argument, isContain));
        }

        public static string ToXPath(string tag, string attribute, string argument, bool isContain = false)
        {
            //".//div[@class='cmt_contents']"
            //"//table[contains(@id,'table-dark')]"
            return isContain ?
                $".//{tag}[contains(@{attribute}, '{argument}')]" :
                $".//{tag}[@{attribute}='{argument}']";
        }

        /// <summary>
        /// 파일 다운로드
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        /// <param name="localPath"></param>
        public static void DownloadFile(string url, string localPath)
        {
            try
            {
                var result = client.GetAsync(url);
                result.Wait();

                var response = result.Result;

                using var stream = new FileStream(localPath, FileMode.CreateNew);
                var result2 = response.Content.CopyToAsync(stream);
                result2.Wait();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string Request(string url)
        {
            try
            {
                var result = client.GetAsync(url);
                result.Wait();

                var response = result.Result.EnsureSuccessStatusCode();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result2 = response.Content.ReadAsStringAsync();
                    result2.Wait();

                    return result2.Result;
                }
                else
                {
                    return response.ReasonPhrase ?? "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}