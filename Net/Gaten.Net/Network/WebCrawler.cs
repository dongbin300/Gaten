using HtmlAgilityPack;

using System.Net;
using System.Text;

namespace Gaten.Net.Network
{
    public class WebCrawler
    {
        public static string Source = string.Empty;

        static readonly Encoding DefaultEncoding = Encoding.UTF8;
        static WebClient client = default!;
        static HtmlDocument htmlDocument = default!;

        public static void Open(string url = "")
        {
#pragma warning disable SYSLIB0014 // 형식 또는 멤버는 사용되지 않습니다.
            client = new WebClient
            {
                Encoding = DefaultEncoding,
                UseDefaultCredentials = true,
                Proxy = new WebProxy { Credentials = CredentialCache.DefaultCredentials, UseDefaultCredentials = true }
            };
#pragma warning restore SYSLIB0014 // 형식 또는 멤버는 사용되지 않습니다.
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
            Source = client.DownloadString(url);
            htmlDocument.LoadHtml(Source);
        }

        public static void SetHtml(string html)
        {
            if(htmlDocument == null)
            {
                htmlDocument = new HtmlDocument();
            }
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
            client.DownloadFile(url, localPath);
        }
    }
}