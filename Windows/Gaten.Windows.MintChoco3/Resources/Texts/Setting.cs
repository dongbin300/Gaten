using Gaten.Net.IO;
using Gaten.Windows.MintChoco3.Model;

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gaten.Windows.MintChoco3.Resources.Texts
{
    internal class Setting
    {
        public Setting()
        {

        }

        public static void Save(List<ModuleCollection> moduleCollections, List<Module> modules)
        {
            try
            {
                StringBuilder builder = new StringBuilder();

                foreach (var item in moduleCollections)
                {
                    builder.AppendLine(item.SaveCode);
                }
                foreach (var item in modules)
                {
                    builder.AppendLine(item.SaveCode);
                }

                File.WriteAllText(PathCollection.MintChocoSettingPath, builder.ToString());
            }
            catch
            {

            }
        }

        public static (List<ModuleCollection>, List<Module>) Load()
        {
            try
            {
                List<ModuleCollection> moduleCollections = new List<ModuleCollection>();
                List<Module> modules = new List<Module>();

                var items = GFile.ReadToArray(PathCollection.MintChocoSettingPath);

                foreach (string item in items)
                {
                    var contents = item.Split(',');
                }

                return (moduleCollections, modules);
            }
            catch
            {
                return (null, null);
            }
        }
    }
}
