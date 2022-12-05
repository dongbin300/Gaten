namespace Gaten.Net.GameRule.RubiksCube
{
    public class Problem
    {
        public List<CubeSymbol> InitialSymbols = new();
        public List<CubeSymbol> GoalSymbols = new();

        private SymbolCube333 cube;

        public Problem(List<CubeSymbol> initialSymbols, List<CubeSymbol> goalSymbols)
        {
            InitialSymbols = initialSymbols;
            GoalSymbols = goalSymbols;

            cube = new SymbolCube333(InitialSymbols);
        }
    }
}
