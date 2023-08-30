using System.ComponentModel;

namespace Gaten.Study.TestWpf
{
    public class PairControlViewModel : INotifyPropertyChanged
    {
        #region Notify Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Notify Property Changed

        private string symbol = string.Empty;
        public string Symbol
        {
            get => symbol;
            set
            {
                symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private string price = string.Empty;
        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}
