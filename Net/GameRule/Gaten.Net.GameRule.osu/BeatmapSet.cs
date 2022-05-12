namespace Gaten.Net.GameRule.osu
{
    public class BeatmapSet
    {
        public DirectoryInfo Directory { get; set; }
        public string FullDirectory => Directory.FullName;
        public string LastDirectory => Directory.Name;
        public string Title => LastDirectory.Substring(LastDirectory.IndexOf(" - ") + 3);

        public FileInfo[] BeatmapFiles { get; set; }
        public List<int> FruitCounts { get; set; } = new();

        public BeatmapSet(DirectoryInfo directory)
        {
            Directory = directory;
            GetBeatmapFileDirectory();
        }

        public void GetBeatmapFileDirectory()
        {
            BeatmapFiles = Directory.GetFiles("*.osu");
        }

        public void ParseBeatmapFiles()
        {
            foreach (FileInfo fi in BeatmapFiles)
            {
                int count = ParseBeatmapFile(fi.FullName);
                if (count != -1)
                    FruitCounts.Add(count);
            }
        }

        public int ParseBeatmapFile(string fileName)
        {
            int fruitCount = 0;
            bool hoStart = false;

            var data = Data.IO.File.ReadToArray(fileName);
            foreach(var str in data)
            {
                if (hoStart) // 과일 정보 문자열
                {
                    if (str.Contains("|")) // 슬라이더
                    {
                        //fruitCount += 2;
                        fruitCount += (str.Split('|').Length - 2) / 2 + 1;
                    }
                    else // 서클
                    {
                        fruitCount++;
                    }
                }
                else if (str.Contains("Mode")) // 비트맵 모드
                {
                    string mode = str.Replace("Mode: ", "");
                    if (mode == "1" || mode == "3") return -1; // 태고와 매니아는 체크하지 않음
                }
                else if (str.Contains("[HitObjects]")) // 과일 정보의 시작
                {
                    hoStart = true;
                }
            }

            return fruitCount;
        }
    }
}
