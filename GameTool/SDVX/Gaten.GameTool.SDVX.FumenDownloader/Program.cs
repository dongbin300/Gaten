using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.Net;

namespace Gaten.GameTool.SDVX.FumenDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Download();
        }

        static void DownloadFile(IWebDriver driver, string url, string localPath)
        {
            using (WebClient client = new())
            {
                client.Headers[HttpRequestHeader.Cookie] = string.Join("; ", driver.Manage().Cookies.AllCookies.Select(c => string.Format("{0}={1}", c.Name, c.Value)));
                client.DownloadFile(url, localPath);
            }
        }

        static void Download()
        {
            Console.Write("다운받을 레벨을 입력하세요. ");
            int level = int.Parse(Console.ReadLine());

            using (IWebDriver subDriver = new ChromeDriver())
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    driver.Url = level < 10 ? $"https://sdvx.in/sort/sort_0{level}.htm" : $"https://sdvx.in/sort/sort_{level}.htm";

                    // 해당 레벨 채보 리스트 저장
                    // 클래스명 tbg인 td를 찾아서 ->table ->tbody 내려간다음 td를 2개 이상 가지고있는 tr을 선택
                    List<IWebElement> elements = driver.FindElements(By.XPath("//td[@class='tbg']/table/tbody/tr[count(td)>1]")).ToList();

                    int i = 0;
                    foreach (IWebElement element in elements)
                    {
                        if (i < 168) { i++; continue; }
                        string title = element.Text.Split('\n')[1].Replace('\\', '-').Replace('/', '-').Replace(':', '-').Replace('*', '-').
                            Replace('?', '-').Replace('\"', '-').Replace('<', '-').Replace('>', '-').Replace('|', '-');
                        string url = string.Empty;
                        try
                        {
                            url = element.FindElement(By.XPath(".//a[contains(@href,'htm')]")).GetAttribute("href");
                        }
                        catch
                        {
                            continue;
                        }

                        // 채보 페이지
                        subDriver.Url = url;

                        try
                        {
                            // 노트 이미지 엘리먼트
                            IWebElement imgElement = subDriver.FindElement(By.XPath("//img[contains(@src,'obj')]"));

                            // 이미지 주소
                            string src = imgElement.GetAttribute("src");

                            // 이미지 다운로드
                            DownloadFile(subDriver, src, title + ".png");
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
