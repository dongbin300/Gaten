using System.Collections.Generic;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    internal class NnlLine
    {
        public List<int> Hint { get; set; } = new List<int>();
        public List<List<int>> EmptyCases { get; set; } = new List<List<int>>();
        public int SelectedIndex { get; set; } = 0;
        public List<int> SelectedEmpty => EmptyCases[SelectedIndex];
    }
}
