using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Controls;
using Gaten.Net.Wpf.Models;

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Worker worker;

        public MainWindow()
        {
            InitializeComponent();

            worker = new()
            {
                ProgressBar = progressBar,
                Action = TestMethod
            };
            worker.Start().Wait();
        }

        private void TestMethod(Worker worker, object? obj)
        {
            int sum = 0;
            worker.For(0, 10000, 1, (i) =>
            {
                sum += i;
            });
        }
    }
}
