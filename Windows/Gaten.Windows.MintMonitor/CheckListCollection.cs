
using Gaten.Net.Network;

namespace Gaten.Windows.MintMonitor
{
    internal class CheckListCollection
    {
        public static List<CheckList> CheckLists { get; set; } = new();

        public static void Init()
        {
            //CheckLists.Add(NaverMembershipDay());
        }

        static CheckList NaverMembershipDay()
        {
            string url = "https://smartstore.naver.com/enlcorp/products/4741788053?NaPm=ct%3Dl39ld9z4%7Cci%3Da4e90f8214cf93ea267024a529b56d6d1c49ef9a%7Ctr%3Dslbrc%7Csn%3D575259%7Chk%3D22b93dc785c056631e33aaa003ab25d4463faa04";
            WebCrawler.SetUrl(url);
            var accumulatePoint = WebCrawler.SelectNode("span", "class", "_1uWi-x17sn").InnerText;

            return new CheckList("네이버 멤버십데이", accumulatePoint, url);
        }
    }
}
