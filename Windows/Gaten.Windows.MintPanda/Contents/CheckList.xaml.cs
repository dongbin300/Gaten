using Gaten.Net.Data.Diagnostics;
using Gaten.Net.Network;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// CheckList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CheckList : Window
    {
        public static List<Check> Checks { get; set; }

        public CheckList()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        public static void Init()
        {
            Checks = new List<Check>();
            //CheckLists.Add(NaverMembershipDay());
        }

        static Check NaverMembershipDay()
        {
            string url = "https://smartstore.naver.com/enlcorp/products/4741788053?NaPm=ct%3Dl39ld9z4%7Cci%3Da4e90f8214cf93ea267024a529b56d6d1c49ef9a%7Ctr%3Dslbrc%7Csn%3D575259%7Chk%3D22b93dc785c056631e33aaa003ab25d4463faa04";
            WebCrawler.SetUrl(url);
            var accumulatePoint = WebCrawler.SelectNode("span", "class", "_1uWi-x17sn").InnerText;

            return new Check("네이버 멤버십데이", accumulatePoint, url);
        }

        public void RefreshCheckList()
        {
            CheckListBox.Items.Clear();
            foreach (var check in Checks)
            {
                CheckListBox.Items.Add(check);
            }
        }

        private void CheckListListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var check = CheckListBox.SelectedItem as Check;

            if (check == null)
            {
                return;
            }

            check.Start();
        }
    }

    public class Check
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Info => Title + ": " + Content;

        public Check(string title, string content, string url)
        {
            Title = title;
            Content = content;
            Url = url;
        }

        public void Start()
        {
            GProcess.Start(Url);
        }
    }
}
