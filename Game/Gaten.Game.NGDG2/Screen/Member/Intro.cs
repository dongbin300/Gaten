namespace Gaten.Game.NGDG2.Screen
{
    public class Intro : IScreen
    {
        public int Pointer = 1;

        public void Show()
        {
            CHelper.Write(
                " /$$   /$$  /$$$$$$    \n" +
                "| $$$ | $$ /$$__  $$   \n" +
                "| $$$$| $$| $$  \\__ /  \n" +
                "| $$ $$ $$| $$ /$$$$   \n" +
                "| $$  $$$$| $$| _  $$  \n" +
                "| $$\\  $$$| $$  \\ $$   \n" +
                "| $$ \\  $$|  $$$$$$/   \n" +
                "| __ /  \\__ / \\______ /\n" +
                "                       \n" +
                " /$$$$$$$   /$$$$$$    \n" +
                "| $$__  $$ /$$__  $$   \n" +
                "| $$  \\ $$| $$  \\__ /  \n" +
                "| $$  | $$| $$ /$$$$   \n" +
                "| $$  | $$| $$| _  $$  \n" +
                "| $$  | $$| $$  \\ $$   \n" +
                "| $$$$$$$/|  $$$$$$/   \n" +
                "| _______ /  \\______ / \n"
                , 39, 4);

            CHelper.Write(GameInfo.Version, 55, 21);

            CHelper.Write(Pointer == 1 ? "▶ 1. 게임시작 ◀" : "   1. 게임시작   ", 41, 24);
            CHelper.Write(Pointer == 2 ? "▶ 2. 도움말 ◀" : "   2. 도움말   ", 41, 25);
            CHelper.Write(Pointer == 3 ? "▶ 3. 종료 ◀" : "   3. 종료   ", 41, 26);
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    return "GameExit";
                case ConsoleKey.UpArrow:
                    Pointer = Math.Max(1, --Pointer);
                    break;
                case ConsoleKey.DownArrow:
                    Pointer = Math.Min(++Pointer, 3);
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    switch (Pointer)
                    {
                        case 1:
                            ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
                            break;
                        case 2:
                            break;
                        case 3:
                            return "GameExit";
                    }
                    break;
            }

            return string.Empty;
        }
    }
}
