using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Windows.MintChoco3.Model
{
    internal class Back
    {
        public static List<Module> Modules { get; set; } = new List<Module>();
        public static ObservableCollection<Module> ModuleCollection => GetModuleCollection();

        public static string ComboString { get; set; } = string.Empty;

        static ObservableCollection<Module> GetModuleCollection()
        {
            ObservableCollection<Module> modules = new ObservableCollection<Module>();
            foreach (var module in Modules)
            {
                modules.Add(module);
            }
            return modules;
        }
    }
}
