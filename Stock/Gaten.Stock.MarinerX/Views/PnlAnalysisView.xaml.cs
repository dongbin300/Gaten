using Gaten.Stock.MarinerX.Excels;

using System.Windows;

namespace Gaten.Stock.MarinerX.Views
{
    /// <summary>
    /// PnlAnalysisView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PnlAnalysisView : Window
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
