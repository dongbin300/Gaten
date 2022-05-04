using Gaten.Windows.MintChoco3.Model;

using System.Windows;

namespace Gaten.Windows.MintChoco3
{
    /// <summary>
    /// Selector.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Selector : Window
    {
        public Selector()
        {
            InitializeComponent();

            ModuleList.Items.Clear();
            foreach (var module in Back.Modules)
            {
                ModuleList.Items.Add($"{module.Name} ({module.HotKey})");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
