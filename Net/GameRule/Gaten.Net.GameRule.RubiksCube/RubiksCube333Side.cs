namespace Gaten.Net.GameRule.RubiksCube
{
    /// <summary>
    /// 큐브의 한 면
    /// </summary>
    public class RubiksCube333Side
    {
        private const int PieceCount = 9;
        public List<PieceColor> PieceColors;

        public RubiksCube333Side(PieceColor color)
        {
            PieceColors = new List<PieceColor>(PieceCount);
            for (int i = 0; i < PieceCount; i++)
                PieceColors.Add(color);
        }

        public void Draw(int x, int y)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 3; j++)
                {
                    Console.ForegroundColor = General.GetConsoleColor(PieceColors[i * 3 + j]);
                    Console.Write("■");
                }
            }
        }
    }
}
