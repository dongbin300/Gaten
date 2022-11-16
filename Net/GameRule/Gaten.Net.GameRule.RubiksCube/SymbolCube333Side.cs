namespace Gaten.Net.GameRule.RubiksCube
{
    public class SymbolCube333Side
    {
        private const int Width = 3;
        private const int Height = 3;
        private const int PieceCount = Width * Height;
        public string[] Symbols;

        public SymbolCube333Side(string symbol)
        {
            Symbols = new string[PieceCount];
            Array.Fill(Symbols, symbol);
        }

        public void Draw(int x, int y)
        {
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(Symbols[i * Width + j]);
                }
            }
        }
    }
}
