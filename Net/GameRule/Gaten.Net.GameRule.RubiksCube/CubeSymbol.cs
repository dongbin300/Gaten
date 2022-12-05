namespace Gaten.Net.GameRule.RubiksCube
{
    public class CubeSymbol
    {
        public int Index { get; set; }
        public string Symbol { get; set; }

        public CubeSymbol(int index, string symbol)
        {
            Index = index;
            Symbol = symbol;
        }
    }
}
