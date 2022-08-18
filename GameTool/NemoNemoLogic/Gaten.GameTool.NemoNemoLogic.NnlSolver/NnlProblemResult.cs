using System.Collections.Generic;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    internal class NnlProblemResult
    {
        public List<NnlBoard> Answer { get; set; } = new List<NnlBoard>();
        public bool IsMultipleCase => Answer.Count > 1;

        public NnlProblemResult()
        {

        }
    }
}
