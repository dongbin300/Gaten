namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    public class NnlBoard
    {
        public bool[,] Data;

        public NnlBoard(int width, int height)
        {
            Data = new bool[width, height];
        }
    }
}
