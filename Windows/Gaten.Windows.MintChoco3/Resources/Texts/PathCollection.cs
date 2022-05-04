using System;
using System.Diagnostics;
using System.IO;

namespace Gaten.Windows.MintChoco3.Resources.Texts
{
    public class PathCollection
    {
        //public static string MintChocoExePath => Application
        public static string MintChocoMainPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MintChoco3");
        public static string MintChocoSettingPath => Path.Combine(MintChocoMainPath, "setting.csv");
        public static string MintChocoLogPath => Path.Combine(MintChocoMainPath, "log.txt");
        public static string MintChocoWebUrl => "https://treeton.xyz/mc/";
    }
}
