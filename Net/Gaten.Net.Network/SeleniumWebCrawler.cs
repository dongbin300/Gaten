using System.Net;
using System.Text;

using HtmlAgilityPack;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Gaten.Net.Network
{
    public class SeleniumWebCrawler
    {
        static readonly Encoding DefaultEncoding = Encoding.UTF8;
        static IWebDriver driver;

        public static void Open(string url = "")
        {
            driver = new ChromeDriver();

            if (!string.IsNullOrEmpty(url))
            {
                SetUrl(url);
            }
        }

        public static void Close()
        {
            driver.Dispose();
        }

        public static void SetUrl(string url)
        {
            driver.Url = url;
        }

        public static IWebElement SelectNode(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        public static IWebElement SelectNode(IWebElement node, string xpath)
        {
            return node.FindElement(By.XPath(xpath));
        }

        /// <summary>
        /// //tag[@attribute='argument']
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="attribute"></param>
        /// <param name="argument"></param>
        /// <param name="isContain"></param>
        /// <returns></returns>
        public static IWebElement SelectNode(string tag, string attribute, string argument, bool isContain = false)
        {
            return SelectNode(ToXPath(tag, attribute, argument, isContain));
        }

        /// <summary>
        /// //tag[@attribute='argument']
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="attribute"></param>
        /// <param name="argument"></param>
        /// <param name="isContain"></param>
        /// <returns></returns>
        public static IWebElement SelectNode(IWebElement node, string tag, string attribute, string argument, bool isContain = false)
        {
            return SelectNode(node, ToXPath(tag, attribute, argument, isContain));
        }

        public static IEnumerable<IWebElement> SelectNodes(string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }

        public static IEnumerable<IWebElement> SelectNodes(IWebElement node, string xpath)
        {
            return node.FindElements(By.XPath(xpath));
        }

        /// <summary>
        /// //tag[@attribute='argument']
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="attribute"></param>
        /// <param name="argument"></param>
        /// <param name="isContain"></param>
        /// <returns></returns>
        public static IEnumerable<IWebElement> SelectNodes(string tag, string attribute, string argument, bool isContain = false)
        {
            return SelectNodes(ToXPath(tag, attribute, argument, isContain));
        }

        /// <summary>
        /// //tag[@attribute='argument']
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="attribute"></param>
        /// <param name="argument"></param>
        /// <param name="isContain"></param>
        /// <returns></returns>
        public static IEnumerable<IWebElement> SelectNodes(IWebElement node, string tag, string attribute, string argument, bool isContain = false)
        {
            return SelectNodes(node, ToXPath(tag, attribute, argument, isContain));
        }

        public static string ToXPath(string tag, string attribute, string argument, bool isContain = false)
        {
            //".//div[@class='cmt_contents']"
            //"//table[contains(@id,'table-dark')]"
            return isContain ?
                $".//{tag}[contains(@{attribute}, '{argument}')]" :
                $".//{tag}[@{attribute}='{argument}']";
        }
    }
}