using Gaten.Stock.MarinerX.Markets;

using System.Collections.Generic;
using System.Windows;

namespace Gaten.Stock.MarinerX.Views
{
    /// <summary>
    /// SymbolBenchmarkingView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SymbolBenchmarkingView : Window
    {
        public SymbolBenchmarkingView()
        {
            InitializeComponent();
        }

        public void Init(List<SymbolBenchmark> benchmarks)
        {
            HistoryDataGrid.ItemsSource = null;
            HistoryDataGrid.ItemsSource = benchmarks;
        }
    }
}
