using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Controls;
using Gaten.Net.Wpf.Models;

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Gaten.Study.TestDll;

namespace Gaten.Study.TestWpf
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

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            var info = SiteInfoManager.GetSiteInfo();
        }
    }
}
