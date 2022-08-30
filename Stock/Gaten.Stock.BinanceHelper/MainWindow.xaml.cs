using System;
using System.Collections.Generic;
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

namespace Gaten.Stock.BinanceHelper
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

        private void ParseButton_Click(object sender, RoutedEventArgs e)
        {
            //var tradeHistoryParser = TradeHistoryParser.Instance;
            //tradeHistoryParser.ParseContent();

            //List<string> targetSymbols = tradeHistoryParser.GetSymbolList();
            //for (int i = 0; i < targetSymbols.Count; i++)
            //{
            //    string symbol = targetSymbols[i];
            //    double totalFee = tradeHistoryParser.GetTotalFee(symbol);
            //    string feeCoin = "USDT";
            //    double totalRealizedProfit = tradeHistoryParser.GetTotalRealizedProfit(symbol);
            //}
        }
    }
}
