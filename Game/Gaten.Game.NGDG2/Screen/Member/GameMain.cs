using Gaten.Game.NGDG2.GameRule.Character;
using Gaten.Game.NGDG2.Screen.Interface;
using Gaten.Game.NGDG2.Util.Environment;
using Gaten.Game.NGDG2.Util.Screen;

namespace Gaten.Game.NGDG2.Screen.Member
{
    public class GameMain : IScreen
    {
        public GameMain()
        {
            // 캐릭터 initialize
            _ = new NgdgCharacter();

            NgdgCharacter.LoadFromFile(PathUtil.AccountPath + "c1.txt");
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("NGDG2 V" + GameInfo.Version, ConsoleColor.Green);

            // 바로가기
            ScreenUtil.DrawHotKeyNavigator(new HotKeyNavigator().AddHotKey("A", "저장").AddHotKey("S", "던전").AddHotKey("M", "내 캐릭터").AddHotKey("I", "인벤토리"));

            // 캐릭터 스탯
            ScreenUtil.Stack(NgdgCharacter.Name);
            ScreenUtil.Stack(NgdgCharacter.Class.Value, ConsoleColor.Gray);
            ScreenUtil.Stack($"Lv {NgdgCharacter.Level}", ConsoleColor.Cyan);
            ScreenUtil.Stack($"EXP {NgdgCharacter.Exp}/{NgdgCharacter.RExp}", ConsoleColor.Green);
            ScreenUtil.Stack($"Gold {NgdgCharacter.Gold}", ConsoleColor.Yellow);
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    NgdgCharacter.SaveToFile(PathUtil.AccountPath + "c1.txt");
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
