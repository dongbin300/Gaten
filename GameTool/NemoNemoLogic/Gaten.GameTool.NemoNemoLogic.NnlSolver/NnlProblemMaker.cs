using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    internal class NnlProblemMaker
    {
        public NnlProblemMaker()
        {

        }

        public static NnlProblem Make(string completionText, int width, int height)
        {
            var result = new NnlProblem(width, height, new List<NnlLine>(), new List<NnlLine>());

            var lines = new List<string>();
            for (int i = 0; i < height; i++)
            {
                lines.Add(completionText.Substring(i * width, width));
            }
            var blocks = lines.Select(x => x.Split('0')).ToList();

            foreach (var block in blocks)
            {
                var hint = new List<int>();
                foreach (var b in block)
                {
                    if (b.Length == 0)
                    {
                        continue;
                    }
                    hint.Add(b.Length);
                }
                if (hint.Count == 0)
                {
                    hint.Add(0);
                }
                result.Horizontal.Add(new NnlLine { Hint = hint });
            }

            lines.Clear();
            for(int i = 0; i < width; i++)
            {
                var builder = new StringBuilder();
                for (int j = 0; j < height; j++)
                {
                    builder.Append(completionText[j * width + i]);
                }
                lines.Add(builder.ToString());
            }
            blocks = lines.Select(x => x.Split('0')).ToList();

            foreach (var block in blocks)
            {
                var hint = new List<int>();
                foreach (var b in block)
                {
                    if (b.Length == 0)
                    {
                        continue;
                    }
                    hint.Add(b.Length);
                }
                if (hint.Count == 0)
                {
                    hint.Add(0);
                }
                result.Vertical.Add(new NnlLine { Hint = hint });
            }

            return result;
        }
    }
}
