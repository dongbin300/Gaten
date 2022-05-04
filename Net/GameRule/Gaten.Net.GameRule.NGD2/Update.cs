namespace Gaten.Net.GameRule.NGD2
{
    public class Update
    {
        public static List<string> Version = new List<string>();
        public static List<string> UpdateString = new List<string>();

        public static int Max => Version.Count;

        public static int Index = Max - 1;

        public Update()
        {
            
        }

        public static void Init()
        {
            Add("2.0.2", "키로 인한 크뎀 증가 버그를 수정하였습니다.\n스킬(Lv105~300) 11개 추가하였습니다.\n스킬 정보 텍스트를 수정하였습니다.");
            Add("2.1.0", "게임 최적화");
        }

        public static void Show(int index)
        {
            int max = Version.Count;

            EasyConsole.SetCursorAndColorAndWrite(0, 0, 12, "나가기 :: ESC");
            EasyConsole.SetCursorAndColorAndWrite(0, 1, 14, $"{Version[index]} Update data ({index + 1}/{max})", true);
            Console.WriteLine(UpdateString[index]);
            EasyConsole.SetColor(15);
        }

        public static void Add(string version, string updateString)
        {
            Version.Add(version);
            UpdateString.Add(updateString);
        }
    }
}
