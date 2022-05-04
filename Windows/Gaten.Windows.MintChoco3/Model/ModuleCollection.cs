using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gaten.Windows.MintChoco3.Model
{
    internal class ModuleCollection : INotifyPropertyChanged, IMenuItem
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

        private List<Module> modules;
        public List<Module> Modules
        {
            get { return modules; }
            set
            {
                modules = value;
                OnPropertyChanged(nameof(Modules));
            }
        }

        public string Representation => $"{Name} ({HotKey})";
        public string TextInMenu => $"▦ {Name} ({HotKey})";
        public string SaveCode => GetSaveCode();

        public ModuleCollection()
        {
            name = string.Empty;
            hotkey = string.Empty;
            modules = new List<Module>();
        }

        string GetSaveCode()
        {
            StringBuilder saveCode = new StringBuilder();
            saveCode.AppendLine($"C,{Index},{Name},{HotKey}");

            foreach(var module in modules)
            {
                saveCode.AppendLine(module.SaveCode);
            }

            return saveCode.ToString();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
