using Gaten.Net.IO;
using Gaten.Net.Wpf;
using Gaten.Visual.DataVisualizer;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

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

            List<Model> models = new List<Model>();
            var test = new CollectionView(models);
        }

        public class Model
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
