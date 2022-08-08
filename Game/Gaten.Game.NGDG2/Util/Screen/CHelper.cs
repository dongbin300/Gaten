namespace Gaten.Game.NGDG2.Util.Screen
{
    /// <summary>
    /// Console Helper
    /// 
    /// 1. Write
    /// </summary>
    public class CHelper
    {
        /// <summary>
        /// 콘솔 문자열 출력
        /// </summary>
        /// <param name="text">문자열</param>
        /// <param name="x">X좌표</param>
        /// <param name="y">Y좌표</param>
        /// <param name="color">색상</param>
        public static void Write(string text, int x = 0, int y = 0, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            string[] data = text.Split('\n');

            for (int i = 0; i < data.Length; i++)
            {
                Console.SetCursorPosition(x, y++);
                Console.Write(data[i]);
            }
        }

        /// <summary>
        /// 콘솔 문자열 출력(하이라이트)
        /// </summary>
        /// <param name="text">문자열</param>
        /// <param name="x">좌표</param>
        /// <param name="y">좌표</param>
        /// <param name="highlightEffect">하이라이트</param>
        public static void WriteHighlight(string text, int x = 0, int y = 0, HighlightEffect highlightEffect = default!)
        {
            Console.ForegroundColor = highlightEffect.Tick();

            string[] data = text.Split('\n');

            for (int i = 0; i < data.Length; i++)
            {
                Console.SetCursorPosition(x, y++);
                Console.Write(data[i]);
            }
        }

        /// <summary>
        /// 콘솔 막대 출력
        /// </summary>
        /// <param name="x">좌표</param>
        /// <param name="y">좌표</param>
        /// <param name="length">막대 길이</param>
        /// <param name="color">색상</param>
        public static void DrawBar(int x = 0, int y = 0, int length = 1, ConsoleColor color = ConsoleColor.White)
        {
            Console.BackgroundColor = color;

            Console.SetCursorPosition(x, y);

            for (int i = 0; i < length; i++)
            {
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// 콘솔 상태바 출력
        /// </summary>
        /// <param name="current">현재 진행도</param>
        /// <param name="max">최대 진행도</param>
        /// <param name="x">좌표</param>
        /// <param name="y">좌표</param>
        /// <param name="length">막대 길이</param>
        /// <param name="color">색상</param>
        /// <param name="backColor">배경 색상</param>
        public static void DrawStatusBar(long current, long max, int x = 0, int y = 0, int length = 10, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Gray)
        {
            double ratio = current / (double)max;
            int fill = (int)System.Math.Round(length * ratio);
            int blank = length - fill;

            DrawBar(x, y, fill, color);
            DrawBar(x + fill, y, blank, backColor);
        }
    }
}
