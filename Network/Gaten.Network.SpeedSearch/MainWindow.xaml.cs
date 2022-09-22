using Gaten.Net.Network;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Gaten.Network.SpeedSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string url = $"https://www.google.com/search?q=c%23+how+to+convert+string+to+int";
            SeleniumWebCrawler.CreateNoWindow = true;
            SeleniumWebCrawler.Open(url);
            var nodes = SeleniumWebCrawler.SelectNodes("h3", "class", "LC20lb", true);

            var titles = new List<string>();
            foreach(var node in nodes)
            {
                titles.Add(node.Text);
            }


        }
    }
}
