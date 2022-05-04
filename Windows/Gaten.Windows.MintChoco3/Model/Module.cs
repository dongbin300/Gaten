using System.ComponentModel;

namespace Gaten.Windows.MintChoco3.Model
{
    internal class Module : INotifyPropertyChanged, IMenuItem
    {
        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged(nameof(Index));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string hotkey;
        public string HotKey
        {
            get { return hotkey; }
            set
            {
                hotkey = value;
                OnPropertyChanged(nameof(HotKey));
            }
        }

        private string path;
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        private bool isChild;
        public bool Ischild
        {
            get { return isChild; }
            set
            {
                isChild = value;
                OnPropertyChanged(nameof(Ischild));
            }
        }

        public string Representation => $"{Name} ({HotKey})";
        public string TextInMenu =>
            Ischild ? $"  └{Name} ({HotKey})" :
            $"{Name} ({HotKey})";
        public string SaveCode => $"M,{Index},{Name},{HotKey},{Path}";

        public Module()
        {
            name = string.Empty;
            hotkey = string.Empty;
            path = string.Empty;
            isChild = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
