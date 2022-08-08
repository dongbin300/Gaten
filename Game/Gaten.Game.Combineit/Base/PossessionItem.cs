using System.ComponentModel;

namespace Gaten.Game.Combineit.Base
{
    public class PossessionItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Item Item { get; set; }

        private int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public PossessionItem(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
