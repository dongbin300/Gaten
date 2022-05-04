namespace Gaten.Net.GameRule.NGD2
{
    public class EasyConsole
    {
        /// <summary>
        /// 콘솔 지우기
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// 콘솔 커서 위치 설정
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// 콘솔 배경색/글자색 설정
        /// </summary>
        /// <param name="color"></param>
        public static void SetColor(int color)
        {
            Console.BackgroundColor = (ConsoleColor)(color / 16);
            Console.ForegroundColor = (ConsoleColor)(color % 16);
        }

        /// <summary>
        /// 문자열 출력
        /// </summary>
        /// <param name="str">문자열</param>
        /// <param name="newLine">줄바꿈, 기본값=줄안바꿈</param>
        public static void Write(string str, bool newLine = false)
        {
            if (newLine)
                Console.WriteLine(str);
            else
                Console.Write(str);
        }

        /// <summary>
        /// 커서 위치/콘솔 컬러 설정
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public static void SetCursorAndColor(int x, int y, int color)
        {
            SetCursor(x, y);
            SetColor(color);
        }

        /// <summary>
        /// 커서 위치/문자열 설정
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="str"></param>
        public static void SetCursorAndWrite(int x, int y, string str, bool newLine = false)
        {
            SetCursor(x, y);
            Write(str, newLine);
        }

        /// <summary>
        /// 콘솔 컬러/문자열 설정
        /// </summary>
        /// <param name="color"></param>
        /// <param name="str"></param>
        public static void SetColorAndWrite(int color, string str, bool newLine = false)
        {
            SetColor(color);
            Write(str, newLine);
        }

        /// <summary>
        /// 커서 위치/콘솔 컬러/문자열 설정
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <param name="str"></param>
        public static void SetCursorAndColorAndWrite(int x, int y, int color, string str, bool newLine = false)
        {
            SetCursorAndColor(x, y, color);
            Write(str, newLine);
        }

        /// <summary>
        /// 선 그리기
        /// </summary>
        /// <param name="i"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        public static void DrawLine(int i, int x1, int x2, int y)
        {
            SetCursorAndColor(x1, y, 16 * i);
            for (; x1 < x2; x1++)
                SetCursorAndWrite(x1, y, " ");
        }

        /// <summary>
        /// 사각형 그리기
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="lengthX"></param>
        /// <param name="lengthY"></param>
        /// <param name="color"></param>
        public static void DrawBox(int startX, int startY, int lengthX, int lengthY, int color)
        {
            SetCursorAndColor(startX + 2, startY, color);
            //printf("┌");
            for (int i = 0; i < lengthX; i++)
                Console.Write("─");
            //printf("┐");
            for (int i = 0; i < lengthY; i++)
            {
                SetCursorAndWrite(startX, startY + i + 1, "│");
                SetCursorAndWrite(startX + lengthX * 2 + 2, startY + i + 1, "│");
            }
            SetCursor(startX + 2, startY + lengthY + 1);
            //printf("└");
            for (int i = 0; i < lengthX; i++)
                Console.Write("─");
            //printf("┘");
        }

        public static string RegularNumber(int n)
        {
            return string.Format("{0:N0}", n);
        }

        public static string RegularNumber(long n)
        {
            return string.Format("{0:N0}", n);
        }

        public static string DecimalNumber(double d, int dc = 2)
        {
            return string.Format("{0:R}", Math.Round(d, dc));
        }
    }
}
