using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Gaten.Windows.MintChoco3.Model
{
    internal class Menu : INotifyPropertyChanged
    {
        private List<ModuleCollection> moduleCollections;
        public List<ModuleCollection> ModuleCollections
        {
            get { return moduleCollections; }
            set
            {
                moduleCollections = value;
                OnPropertyChanged(nameof(ModuleCollections));
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

        //private List<IMenuItem> menuItems 
        public List<IMenuItem> MenuItems => GetMenuItems();

        public ModuleCollection LastModuleCollection => ModuleCollections.Find(mc=>mc.Index == ModuleCollections.Count);
        public Module LastModule => Modules.Find(m=>m.Index == Modules.Count);

        public Menu()
        {
            moduleCollections = new List<ModuleCollection>();
            modules = new List<Module>();
        }

        List<IMenuItem> GetMenuItems()
        {
            List<IMenuItem> menuItems = new List<IMenuItem>();

            moduleCollections.Sort((x, y) => x.Index.CompareTo(y.Index));

            foreach(var moduleCollection in moduleCollections)
            {
                menuItems.Add(moduleCollection);

                moduleCollection.Modules.Sort((x,y)=> x.Index.CompareTo(y.Index));

                foreach(var module in moduleCollection.Modules)
                {
                    menuItems.Add(module);
                }
            }

            modules.Sort((x, y) => x.Index.CompareTo(y.Index));

            foreach (var module in modules)
            {
                menuItems.Add(module);
            }

            return menuItems;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
