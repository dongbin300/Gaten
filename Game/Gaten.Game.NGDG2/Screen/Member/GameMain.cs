namespace Gaten.Game.NGDG2.Screen
{
    public class GameMain : IScreen
    {
        public GameMain()
        {
            // 캐릭터 initialize
            _ = new Character();

            Character.LoadFromFile(PathUtil.AccountPath + "c1.txt");
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("NGDG2 V" + GameInfo.Version, ConsoleColor.Green);

            // 바로가기
            ScreenUtil.DrawHotKeyNavigator(new HotKeyNavigator().AddHotKey("A", "저장").AddHotKey("S", "던전").AddHotKey("M", "내 캐릭터").AddHotKey("I", "인벤토리"));

            // 캐릭터 스탯
            ScreenUtil.Stack(Character.Name);
            ScreenUtil.Stack(Character.Class.Value, ConsoleColor.Gray);
            ScreenUtil.Stack($"Lv {Character.Level}", ConsoleColor.Cyan);
            ScreenUtil.Stack($"EXP {Character.Exp}/{Character.RExp}", ConsoleColor.Green);
            ScreenUtil.Stack($"Gold {Character.Gold}", ConsoleColor.Yellow);
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    Character.SaveToFile(PathUtil.AccountPath + "c1.txt");
                    break;
                case ConsoleKey.S:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.DungeonSelection;
                    break;
                case ConsoleKey.M:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.CharacterInfo;
                    break;
                case ConsoleKey.I:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.Inventory;
                    break;
            }

            return string.Empty;
        }
    }
}
