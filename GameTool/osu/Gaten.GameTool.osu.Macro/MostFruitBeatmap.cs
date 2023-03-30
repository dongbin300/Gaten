using Gaten.Net.GameRule.osu;

namespace Gaten.GameTool.osu.Macro
{
    internal class MostFruitBeatmap
    {
        static string beatmapDirectory = "C:\\Users\\Gaten\\AppData\\Local\\osu!\\Songs";
        static string filterDirectory = "C:\\Users\\Gaten\\AppData\\Local\\osu!\\Filter";
        static List<BeatmapSet> bs = new List<BeatmapSet>();
        static List<BeatmapSet> filter = new List<BeatmapSet>();
        static int Threshold = 1500;

        public MostFruitBeatmap()
        {
            // 모든 osu 파일 목록 불러오기
            DirectoryInfo[] beatmapSetDirectory = new DirectoryInfo(beatmapDirectory).GetDirectories();
            foreach (DirectoryInfo di in beatmapSetDirectory)
            {
                BeatmapSet beatmapSet = new BeatmapSet(di);
                beatmapSet.GetBeatmapFileDirectory();

                bs.Add(beatmapSet);
            }

            // osu 파일 열어서 과일수 체크 후 리스트에 저장
            foreach (BeatmapSet b in bs)
            {
                b.ParseBeatmapFiles();
            }

            // 과일수 적은 것들은 필터링
            Filter();

            // 필터링 되는 비트맵셋 다른 디렉토리로 제외 
            foreach (BeatmapSet b in filter)
            {
                b.Directory.MoveTo(filterDirectory + "\\" + b.Directory.Name);
                /*Console.Write($"{b.directory} :: ");
                foreach (int i in b.fruitCounts)
                    Console.Write($"{i} ");
                Console.WriteLine();*/
            }
            Console.WriteLine($"{bs.Count}개 중 {filter.Count}개 필터링 됨.");
        }

        static void Filter()
        {
            foreach (BeatmapSet b in bs)
            {
                bool filtered = true;
                foreach (int i in b.FruitCounts)
                {
                    if (i >= Threshold) // 과일수가 임계값에 하나라도 미치면 필터링하지 않음
                    {
                        filtered = false;
                        break;
                    }
                }
                if (filtered) // 과일수가 임계값에 하나도 미치지 못하면 필터링됨
                {
                    filter.Add(b);
                }
            }
        }
    }
}
