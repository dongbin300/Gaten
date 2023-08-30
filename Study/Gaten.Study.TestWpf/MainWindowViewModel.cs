using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Gaten.Study.TestWpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Notify Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Notify Property Changed

        private ObservableCollection<PairControl> pairs = new();
        public ObservableCollection<PairControl> Pairs
        {
            get => pairs;
            set
            {
                pairs = value;
                OnPropertyChanged(nameof(Pairs));
            }
        }

        public MainWindowViewModel()
        {
            for(int i = 0; i < 5; i++)
            {
                var pairControl = new PairControl();
                var price = new Random().Next(1000);
                pairControl.Init("Test", price.ToString());
                pairs.Add(pairControl);
            }
        }
    }
}
