using Gaten.Net.Diagnostics;
using Gaten.Net.Network;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// CheckList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CheckList : Window
    {
        public static List<Check> Checks { get; set; } = new();

        public CheckList()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(CheckList), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    DragMove();
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(CheckList), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        public static void Init()
        {
            try
            {
                //CheckLists.Add(NaverMembershipDay());
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(CheckList), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        static Check NaverMembershipDay()
        {
            try
            {
                string url = "https://smartstore.naver.com/enlcorp/products/4741788053?NaPm=ct%3Dl39ld9z4%7Cci%3Da4e90f8214cf93ea267024a529b56d6d1c49ef9a%7Ctr%3Dslbrc%7Csn%3D575259%7Chk%3D22b93dc785c056631e33aaa003ab25d4463faa04";
                WebCrawler.SetUrl(url);
                var accumulatePoint = WebCrawler.SelectNode("span", "class", "_1uWi-x17sn").InnerText;

                return new Check("네이버 멤버십데이", accumulatePoint, url);
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(CheckList), MethodBase.GetCurrentMethod()?.Name, ex);
            }

            return default!;
        }

        public void RefreshCheckList()
        {
            try
            {
                CheckListBox.Items.Clear();
                foreach (var check in Checks)
                {
                    CheckListBox.Items.Add(check);
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(CheckList), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void CheckListListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var check = CheckListBox.SelectedItem as Check;

                if (check == null)
                {
                    return;
                }

                check.Start();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(CheckList), MethodBase.GetCurrentMethod()?.Name, ex);
            }
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
            try
            {
                GProcess.Start(Url);
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Check), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
