using Newtonsoft.Json;

using System.Collections.Generic;
using System.Text;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    internal class TealHint
    {
        public IList<IList<int>> ver { get; set; } = new List<IList<int>>();
        public IList<IList<int>> hor { get; set; } = new List<IList<int>>();

        public new string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("ver: ");
            foreach (var v1 in ver)
            {
                foreach (var v2 in v1)
                {
                    builder.Append(v2 + " ");
                }
                builder.Append(" / ");
            }
            builder.Append("  hor: ");
            foreach (var h1 in hor)
            {
                foreach (var h2 in h1)
                {
                    builder.Append(h2 + " ");
                }
                builder.Append(" / ");
            }

            return builder.ToString();
        }
    }

    internal class TealNnlProblem
    {
        public TealHint Hint { get; set; } = new TealHint();
        public string Json => ToJson();

        public new string ToString()
        {
            return Hint.ToString();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(Hint);
        }
    }
}
