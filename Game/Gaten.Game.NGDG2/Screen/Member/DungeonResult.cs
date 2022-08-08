using Gaten.Game.NGDG2.GameRule.Dungeon;
using Gaten.Game.NGDG2.GameRule.Item;
using Gaten.Game.NGDG2.Screen.Interface;
using Gaten.Game.NGDG2.Util.Screen;

namespace Gaten.Game.NGDG2.Screen.Member
{
    public class DungeonResult : IScreen
    {
        public static NgdgDungeon d = new();

        public DungeonResult()
        {

        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("던전 클리어!", ConsoleColor.Green);

            // 바로가기
            ScreenUtil.DrawHotKeyNavigator(new HotKeyNavigator().AddHotKey("SPACE", "확인"));

            // 던전 클리어 보상
            ScreenUtil.Stack($"{d.Name} 클리어!", ConsoleColor.Cyan);
            ScreenUtil.Stack("");
            ScreenUtil.Stack("보상");
            ScreenUtil.Stack($"EXP + {d.AccumulatedExp + (long)(d.AccumulatedExp * 0.2)} ({d.AccumulatedExp} + {(long)(d.AccumulatedExp * 0.2)})", ConsoleColor.Green);
            ScreenUtil.Stack($"Gold + {d.AccumulatedGold + (long)(d.AccumulatedGold * 0.2)} ({d.AccumulatedGold} + {(long)(d.AccumulatedGold * 0.2)})", ConsoleColor.Yellow);
            foreach (NgdgSlot slot in d.AccumulatedItems.Slots)
            {
                if (slot.Item == null)
                {
                    continue;
                }

                ScreenUtil.Stack(string.Format("{0,-20}{1,-4}", slot.Item.Name, slot.ItemCount), slot.Item.Color);
            }
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Spacebar:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
                    break;
            }

            return string.Empty;
        }
    }
}
