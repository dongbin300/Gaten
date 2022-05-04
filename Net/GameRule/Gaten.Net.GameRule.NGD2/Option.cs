using System.Text;

namespace Gaten.Net.GameRule.NGD2
{
    public class Option
    {
        static string fileName = "option.ini";

        /// <summary>
        /// 0-수동저장, 1-자동저장
        /// </summary>
        public static int AutoSave;

        /// <summary>
        /// 0-숫자표시, 1-바표시
        /// </summary>
        public static int BarDisplay;

        /// <summary>
        /// 소수점 n자리 표시<br/>
        /// 0-77%, 1-77.2%, 2-77.24%, ...
        /// </summary>
        public static int PerDisplay;

        public Option()
        {

        }

        public static void Init()
        {
            Load();
        }

        public static void Save()
        {
            using StreamWriter sw = new StreamWriter(File.Create(fileName), Encoding.UTF8);

            sw.WriteLine($"AutoSave = {AutoSave}");
            sw.WriteLine($"BarDisplay = {BarDisplay}");
            sw.WriteLine($"PerDisplay = {PerDisplay}");
            sw.WriteLine("// AutoSave: (0-수동, 1-자동)");
            sw.WriteLine("// BarDisplay: (0-숫자, 1-막대기)");
            sw.WriteLine("// PerDisplay: 소수 n자리 표시");
        }

        public static void Load()
        {
            using StreamReader sr = new StreamReader(File.OpenRead(fileName), Encoding.UTF8);

            AutoSave = int.Parse(sr.ReadLine().Split('=')[1]);
            BarDisplay = int.Parse(sr.ReadLine().Split('=')[1]);
            PerDisplay = int.Parse(sr.ReadLine().Split('=')[1]);
        }
    }
}
