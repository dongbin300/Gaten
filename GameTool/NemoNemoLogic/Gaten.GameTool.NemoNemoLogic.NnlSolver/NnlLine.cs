using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    internal class NnlLine
    {
        public List<int> Hint { get; set; } = new List<int>();
        public List<List<int>> EmptyCases { get; set; } = new List<List<int>>();
        public int SelectedIndex { get; set; } = 0;
        public List<int> SelectedEmpty => EmptyCases[SelectedIndex];

        public new string ToString()
        {
            return string.Join(" ", Hint.Select(x=>x.ToString()));
        }
    }
}
