namespace Gaten.Game.NGDG2.Screen
{
    /// <summary>
    /// 던전 선택 화면
    /// </summary>
    public class DungeonSelection : IScreen
    {
        public int ScreenID;
        string[] dungeonNames = { "고블린 방", "고블린 소굴", "고블린 기지", "고블린 아지트", "고블린 성", "고블린 왕국" };

        public DungeonSelection()
        {
            ScreenID = 1;
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("던전", ConsoleColor.Green);

            // 바로가기
            ScreenUtil.DrawHotKeyNavigator(new HotKeyNavigator().AddHotKey("ESC", "뒤로가기"));

            // 던전
            switch (ScreenID)
            {
                case 1:
                    for (int i = 0; i < dungeonNames.Length; i++)
                    {
                        ScreenUtil.Stack($"[{i + 1}] {dungeonNames[i]}");
                    }
                    break;
            }
        }

        public string React(ConsoleKey key)
        {
            switch (ScreenID)
            {
                case 1:
                    switch (key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.D2:
                        case ConsoleKey.D3:
                        case ConsoleKey.D4:
                        case ConsoleKey.D5:
                        case ConsoleKey.D6:
                            ScreenManager.DungeonBattle.Make(dungeonNames[(int)key - 49]);
                            ScreenManager.CurrentScreen = ScreenManager.Screen.DungeonBattle;
                            break;
                        case ConsoleKey.Escape:
                            ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
                            break;
                    }
                    break;
            }

            return string.Empty;
        }
    }
}
