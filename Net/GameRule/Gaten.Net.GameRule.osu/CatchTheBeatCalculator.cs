using Gaten.Net.GameRule.osu.OsuFile;

namespace Gaten.Net.GameRule.osu
{
    public class CatchTheBeatCalculator
    {
        public OsuFileObject osuFileObject;
        public enum CalculateRule { SumTime, SumNote, AverageSpeed }

        public CatchTheBeatCalculator(OsuFileObject osuFileObject)
        {
            this.osuFileObject = osuFileObject;
        }

        public double Calculate(CalculateRule rule)
        {
            // 스피드 = 두 과일의 거리 / 두 과일의 시간차
            List<double> speeds = new List<double>();

            switch (rule)
            {
                // 모든 스피드를 더한 다음에 시간으로 나눔
                case CalculateRule.SumTime:
                    double sumTimeCoef = 1.0;
                    for (int i = 0; i < osuFileObject.HitObjects.Count - 1; i++)
                    {
                        speeds.Add((double)System.Math.Abs(osuFileObject.HitObjects[i].X - osuFileObject.HitObjects[i + 1].X) / System.Math.Abs(osuFileObject.HitObjects[i].TimingPosition - osuFileObject.HitObjects[i + 1].TimingPosition));
                    }
                    return speeds.Sum() / (System.Math.Abs(osuFileObject.HitObjects[0].TimingPosition - osuFileObject.HitObjects[osuFileObject.HitObjects.Count - 1].TimingPosition) / 1000) * sumTimeCoef;
                // 모든 스피드를 더한 다음에 노트수로 나눔
                case CalculateRule.SumNote:
                    double sumNoteCoef = 5.0;
                    for (int i = 0; i < osuFileObject.HitObjects.Count - 1; i++)
                    {
                        speeds.Add((double)System.Math.Abs(osuFileObject.HitObjects[i].X - osuFileObject.HitObjects[i + 1].X) / System.Math.Abs(osuFileObject.HitObjects[i].TimingPosition - osuFileObject.HitObjects[i + 1].TimingPosition));
                    }
                    return speeds.Sum() / osuFileObject.HitObjects.Count * sumNoteCoef;
            }
            return 0;
        }
    }
}
