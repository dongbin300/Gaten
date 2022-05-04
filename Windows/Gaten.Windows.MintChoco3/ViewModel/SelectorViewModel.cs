
using Gaten.Windows.MintChoco3.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace Gaten.Windows.MintChoco3.ViewModel
{
    /// <summary>
    /// 현재 사용하지 않음
    /// </summary>
    internal class SelectorViewModel : INotifyPropertyChanged
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        string foreString = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string keytext;
        public string KeyText
        {
            get { return keytext; }
            set
            {
                keytext = value;
                OnPropertyChanged(nameof(KeyText));
            }
        }


        private ObservableCollection<Module> filteredModules;
        public ObservableCollection<Module> FilteredModules
        {
            get { return filteredModules; }
            set
            {
                filteredModules = value;
                OnPropertyChanged(nameof(FilteredModules));
            }
        }

        public SelectorViewModel()
        {
            keytext = string.Empty;
            filteredModules = new ObservableCollection<Module>();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            //{
            KeyText = Back.ComboString;

            // 입력이 바뀌었을 때
            if (foreString != Back.ComboString)
            {
                MessageBox.Show("1");
                foreString = Back.ComboString;
                var fModules = Back.Modules.Where(m => m.HotKey.StartsWith(Back.ComboString));
                FilteredModules.Clear();
                foreach (var module in fModules)
                {
                    FilteredModules.Add(module);
                }
                MessageBox.Show(FilteredModules.Count.ToString());
            }

            // 아무것도 입력이 되지 않았을 때
            else if (Back.ComboString == string.Empty)
            {
                FilteredModules = Back.ModuleCollection;
            }
            //}));
        }
    }
}
