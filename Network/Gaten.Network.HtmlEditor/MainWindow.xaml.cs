using Gaten.Net.Data.IO;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gaten.Network.HtmlEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Editor.Text = GResource.GetText("he-test.html");
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshWebBrowser();
        }

        /// <summary>
        /// 웹 브라우저를 새로고침 합니다.
        /// </summary>
        void RefreshWebBrowser()
        {
            //try
            //{
            //    titleLabel.Text = editor.Text.Split(new string[] { "<title>", "</title>" }, StringSplitOptions.None)[1];
            //}
            //catch
            //{

            //}

            try
            {
                GResource.SetText("he-test.html", Editor.Text);
                PreviewWebBrowser.Navigate(GResource.GetPath("he-test.html"));
            }
            catch
            {
            }
        }
    }
}
