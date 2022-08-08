using Gaten.Game.NGDG2.Screen.Member;
using Gaten.Game.NGDG2.Util.Screen;

namespace Gaten.Game.NGDG2.Screen
{
    /// <summary>
    /// 스크린 매니저
    /// 화면 객체 관리, 콘솔창에서의 키보드 입력, 화면 전환, 새로고침 등
    /// 화면에 관한 것들을 전반적으로 관리한다.
    /// </summary>
    public class ScreenManager
    {
        /// <summary>
        /// 화면 종류
        /// </summary>
        public enum Screen
        {
            Intro,
            Main,
            DungeonSelection,
            DungeonBattle,
            DungeonResult,
            CharacterInfo,
            Inventory
        }

        private static Screen currentScreen;

        /// <summary>
        /// 현재 콘솔창 화면
        /// </summary>
        public static Screen CurrentScreen
        {
            get => currentScreen;
            set
            {
                currentScreen = value;

                Console.Clear();
            }
        }

        /// <summary>
        /// 글자 표시 Y축 포인터
        /// </summary>
        public static int WritePointer;

        /// <summary>
        /// 화면 객체들
        /// </summary>
        public static Intro Intro = new();
        public static GameMain Main = new();
        public static DungeonSelection DungeonSelection = new();
        public static DungeonBattle DungeonBattle = new();
        public static DungeonResult DungeonResult = new();
        public static CharacterInfo CharacterInfo = new();
        public static Inventory Inventory = new();

        public ScreenManager()
        {
            Initialize();
        }

        /// <summary>
        /// 화면 객체를 생성한다.
        /// </summary>
        private void Initialize()
        {
            Intro = new Intro();
            Main = new GameMain();
            DungeonSelection = new DungeonSelection();
            DungeonBattle = new DungeonBattle();
            DungeonResult = new DungeonResult();
            CharacterInfo = new CharacterInfo();
            Inventory = new Inventory();
        }

        /// <summary>
        /// 다시 그린다.
        /// </summary>
        public static void Redraw()
        {
            WritePointer = 3;

            ScreenUtil.DrawBorder();

            switch (CurrentScreen)
            {
                case Screen.Intro:
                    Intro.Show();
                    break;
                case Screen.Main:
                    Main.Show();
                    break;
                case Screen.DungeonSelection:
                    DungeonSelection.Show();
                    break;
                case Screen.DungeonBattle:
                    DungeonBattle.Show();
                    break;
                case Screen.DungeonResult:
                    DungeonResult.Show();
                    break;
                case Screen.CharacterInfo:
                    CharacterInfo.Show();
                    break;
                case Screen.Inventory:
                    Inventory.Show();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 키보드 입력에 반응한다.
        /// </summary>
        /// <returns></returns>
        public static string React()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            return CurrentScreen switch
            {
                Screen.Intro => Intro.React(key),
                Screen.Main => Main.React(key),
                Screen.DungeonSelection => DungeonSelection.React(key),
                Screen.DungeonBattle => DungeonBattle.React(key),
                Screen.DungeonResult => DungeonResult.React(key),
                Screen.CharacterInfo => CharacterInfo.React(key),
                Screen.Inventory => Inventory.React(key),
                _ => string.Empty,
            };
        }
    }
}
