using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Net.Stock.MercuryTradingModel.Trades;

using System.Collections.Generic;
using System.Windows;

namespace Gaten.Stock.MarinerX.Views
{
    /// <summary>
    /// BackTestTradingHistoryView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BackTestTradingHistoryView : Window
    {
        public BackTestTradingHistoryView()
        {
            InitializeComponent();
        }

        public void Init(List<BackTestTradeInfo> trades)
        {
            HistoryDataGrid.ItemsSource = null;
            HistoryDataGrid.ItemsSource = trades;
        }

        public void Init(string fileName)
        {
            Title = fileName.GetOnlyFileName();

            var csv = GFile.ReadCsv(fileName);
            HistoryDataGrid.ItemsSource = null;
            HistoryDataGrid.ItemsSource = csv.DefaultView;
        }
    }
}
