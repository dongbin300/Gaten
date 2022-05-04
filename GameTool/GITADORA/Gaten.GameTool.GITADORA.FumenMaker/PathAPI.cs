
using Path = Gaten.Net.GameRule.GITADORA.Path;

namespace Gaten.GameTool.GITADORA.FumenMaker
{
    internal class PathAPI
    {
        public enum FumenViewMode
        {
            OneLine,
            MultiLine
        }

        // txt파일 형식
        // CFG, (drum/guitar/bass), 채보 width, height
        // paths ...

        public static List<Path> ConvertPath(List<Path> paths, Config config, FumenViewMode mode)
        {
            List<Path> newPaths = new List<Path>();

            switch (mode)
            {
                case FumenViewMode.OneLine:
                    foreach (Path path in paths)
                    {
                        newPaths.Add(path);
                    }
                    break;
                case FumenViewMode.MultiLine:
                    int bpCount = 4;
                    List<Path> bpPaths = paths.Where(p => p.type.Equals(Path.Type.BigPhrase)).ToList();
                    List<Path> spPaths = paths.Where(p => p.type.Equals(Path.Type.SmallPhrase)).ToList();
                    List<Path> noPaths = paths.Where(p => p.type.Equals(Path.Type.Note)).ToList();
                    List<double> thresholds = GetThresholdTimings(bpPaths, bpCount);

                    int cur = 1;
                    foreach (Path path in bpPaths)
                    {
                        if (path.timing >= thresholds[cur])
                        {
                            cur = Math.Min(thresholds.Count - 1, cur + 1);
                        }

                        newPaths.Add(new Path()
                        {
                            type = path.type,
                            noteNum = path.noteNum,
                            lineNum = cur - 1,
                            timing = path.timing - thresholds[cur - 1],
                            holdLength = path.holdLength
                        });
                    }

                    cur = 1;
                    foreach (Path path in spPaths)
                    {
                        if (path.timing >= thresholds[cur])
                        {
                            cur = Math.Min(thresholds.Count - 1, cur + 1);
                        }

                        newPaths.Add(new Path()
                        {
                            type = path.type,
                            noteNum = path.noteNum,
                            lineNum = cur - 1,
                            timing = path.timing - thresholds[cur - 1],
                            holdLength = path.holdLength
                        });
                    }

                    cur = 1;
                    foreach (Path path in noPaths)
                    {
                        if (path.timing + 1 >= thresholds[cur])
                        {
                            cur = Math.Min(thresholds.Count - 1, cur + 1);
                        }

                        newPaths.Add(new Path()
                        {
                            type = path.type,
                            noteNum = path.noteNum,
                            lineNum = cur - 1,
                            timing = path.timing - thresholds[cur - 1],
                            holdLength = path.holdLength
                        });
                    }

                    CalculateConfig(config, newPaths);

                    break;
            }

            return newPaths;
        }


        // 대절선 bpCount개마다 한 개의 라인
        static List<double> GetThresholdTimings(List<Path> bpPaths, int bpCount)
        {
            List<double> thresholds = new List<double>();
            thresholds.Add(0.0);

            int index = bpCount;

            while (index < bpPaths.Count - 1)
            {
                thresholds.Add(bpPaths[index].timing);
                index += bpCount;
            }
            thresholds.Add(bpPaths[bpPaths.Count - 1].timing);

            return thresholds;
        }

        static void CalculateConfig(Config config, List<Path> paths)
        {
            config.width = 100 + (paths.Max(p => p.lineNum) + 1) * 700;
            config.height = 300 + (int)paths.Max(p => p.timing);
        }

        public static List<Path> ReversePath(List<Path> paths, Config config)
        {
            List<Path> newPaths = new List<Path>();

            foreach (Path path in paths)
            {
                newPaths.Add(new Path()
                {
                    type = path.type,
                    noteNum = path.noteNum,
                    lineNum = path.lineNum,
                    timing = config.height - 100 - path.timing,
                    holdLength = path.holdLength
                });
            }

            return newPaths;
        }

        public static List<Path> ScalePath(List<Path> paths, Config config, double scale)
        {
            List<Path> newPaths = new List<Path>();

            config.height = (int)(config.height * scale);

            foreach (Path path in paths)
            {
                newPaths.Add(new Path()
                {
                    type = path.type,
                    noteNum = path.noteNum,
                    lineNum = path.lineNum,
                    timing = scale * path.timing,
                    holdLength = path.holdLength
                });
            }

            return newPaths;
        }
    }
}
