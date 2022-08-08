using Gaten.Game.Starcraft.Rule.Product;

using System.Drawing;

using static Colorful.Console;

namespace Gaten.Game.Starcraft
{
    internal class Program
    {
        public static int Turn;
        public static bool GameOver;
        private static readonly string keyOrder = "1234567890ABCDEF";
        private static Player p;
        private static ProductDictionary pd;

        private static void Main()
        {
            pd = new ProductDictionary();
            p = new Player();
            Turn = 1;

            while (true)
            {
                Clear();
                DisplayStatus();
                WriteLine("[1] 자원 캐기", Color.FromArgb(255, 215, 175));
                WriteLine("[2] 건물 건설", Color.FromArgb(255, 205, 155));
                WriteLine("[3] 유닛 생산", Color.FromArgb(255, 195, 135));
                WriteLine("[P] 게임 종료", Color.FromArgb(255, 185, 115));

                switch (ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        p.GetResources();
                        break;
                    case ConsoleKey.D2:
                        DisplayBuildingList();
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.P:
                        GameOver = true;
                        break;
                }

                if (!GameOver)
                {
                    ++Turn;
                }
                else
                {
                    break;
                }
            }
        }

        private static void DisplayStatus()
        {
            WriteLine("---------------------------------------------------", Color.FromArgb(255, 255, 255));
            WriteLine("------스타크래프트----------------제작자: Gaten---", Color.FromArgb(255, 245, 235));
            WriteLine("---------------------------------------------------", Color.FromArgb(255, 235, 215));
            WriteLine("     미네랄: {0}  가스: {1}  인구: {2}/{3}  턴: {4}", Color.FromArgb(255, 225, 195), p.CurrentMineral, p.CurrentGas, p.CurrentPopulation, p.MaxPopulation, Turn);
            WriteLine();
        }

        private static List<string> DisplayBuildingSimple()
        {
            List<string> buildingStrings = new();
            IEnumerable<IProduct>? buildings = pd.Products.Where(p => p is IBuilding);

            int c = 0;
            foreach (IBuilding b in buildings)
            {
                string str = string.Format("[{0}] {1} M{2} G{3} ({4})", keyOrder[c++], b.Name, b.MineralCost, b.GasCost, p.GetProductCount(b.Id));
                buildingStrings.Add(str);
                WriteLine(str);
            }

            return buildingStrings;
        }

        private static void DisplayBuildingList()
        {
            Clear();
            DisplayStatus();
            _ = DisplayBuildingSimple();
            WriteLine("[P] 취소");
            _ = ReadKey(true).Key;
        }
    }
}
