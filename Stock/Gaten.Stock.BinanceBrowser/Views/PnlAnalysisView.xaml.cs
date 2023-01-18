using Gaten.Stock.BinanceBrowser.Excels;

using System.Windows;
using System.Windows.Controls;

namespace Gaten.Stock.BinanceBrowser.Views
{
    /// <summary>
    /// PnlAnalysisView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PnlAnalysisView : UserControl
    {
        public PnlAnalysisView()
        {
            InitializeComponent();
        }

        private void ExcelImportButton_Click(object sender, RoutedEventArgs e)
        {
            var result = TradeHistoryParser.ParseContent();
            ResultDataGrid.ItemsSource = null;
            ResultDataGrid.ItemsSource = result;
        }
    }
}
