using Gaten.GameTool.GITADORA.GDRS.RealSkill.SkillField;
using Gaten.Net.GameRule.GITADORA;

using Path = Gaten.Net.GameRule.GITADORA.Path;

namespace Gaten.GameTool.GITADORA.GDRS.RealSkill
{
    /* 테스트 채보 (10개~)
     * 1116 db/da/de/dm
     * 1112 db/da/de/dm
     * 965 db/da/de/dm
    */
    internal class FumenTeacher
    {
        public Fumen Fumen;
        public Reading Reading;
        public Stamina Stamina;
        public Agility Agility;
        public Concentration Concentration;
        public Accuracy Accuracy;

        public FumenTeacher()
        {
            Fumen = new Fumen();
            Reading = new Reading();
            Stamina = new Stamina();
            Agility = new Agility();
            Concentration = new Concentration();
            Accuracy = new Accuracy();
        }

        public void Parse(FumenFile fumenFile, int bpm = 0)
        {
            Fumen.Bpm = bpm;
            for (double i = RealSkillRule.StartPhraseTiming; i < fumenFile.Height; i += RealSkillRule.PhraseLength)
            {
                Fumen.Phrases.Add(new Phrase()
                {
                    Num = (int)((i - RealSkillRule.StartPhraseTiming) / RealSkillRule.PhraseLength + 1),
                    Duration = 240 / Fumen.Bpm,
                    Note = fumenFile.Paths.Where(p => p.type.Equals(Path.Type.Note) && p.timing >= i - RealSkillRule.NoteDelay && p.timing < i + RealSkillRule.PhraseLength - RealSkillRule.NoteDelay).ToList()
                });
            }

            List<double> densities = new List<double>();
            List<double> pedalDensities = new List<double>();
            List<double> tomDensities = new List<double>();
            List<double> offBeatDensities = new List<double>();
            List<double> noteIntervals = new List<double>();
            double durationSum = 0;
            foreach (Phrase phrase in Fumen.Phrases)
            {
                // 밀도 계산
                densities.Add(phrase.Note.Count / phrase.Duration);
                pedalDensities.Add(phrase.Note.Count(n => n.noteNum.Equals(3) || n.noteNum.Equals(6)) / phrase.Duration);
                tomDensities.Add(phrase.Note.Count(n => n.noteNum.Equals(5) || n.noteNum.Equals(7) || n.noteNum.Equals(8)) / phrase.Duration);
                offBeatDensities.Add(phrase.Note.Count(n => IsOffBeat(n.timing)) / phrase.Duration);

                // 곡 길이 계산
                if (phrase.Note.Count != 0)
                {
                    durationSum += phrase.Duration;
                }

                // 노트 간격 계산
                noteIntervals.Add(phrase.Duration * (GetAverageHandInterval(phrase.Note) + GetAveragePedalInterval(phrase.Note)));
            }

            // 앞의 0 제외
            while (true)
            {
                if (densities[0] == 0)
                {
                    densities.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }

            // 뒤의 0 제외
            for (int i = densities.Count - 1; i >= 0; i--)
            {
                if (densities[i] == 0)
                {
                    densities.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }

            // 노트 개수
            double noteCount = fumenFile.Paths.Count(p => p.type.Equals(Path.Type.Note));

            // 노트 밀도
            double averageA = densities.Where(d => !d.Equals(0)).Average();
            double averageB = densities.Where(d => !d.Equals(0)).Where(d => d >= averageA * RealSkillRule.LackThreshold).Average();

            // 페달 밀도
            double pedalAverageA = pedalDensities.Where(d => !d.Equals(0)).Average();
            double pedalAverageB = pedalDensities.Where(d => !d.Equals(0)).Where(d => d >= pedalAverageA * RealSkillRule.LackThreshold).Average();

            // 탐 밀도
            double tomAverageA = tomDensities.Where(d => !d.Equals(0)).Average();
            double tomAverageB = tomDensities.Where(d => !d.Equals(0)).Where(d => d >= tomAverageA * RealSkillRule.LackThreshold).Average();

            // 엇박 밀도
            double offBeatAverageA = offBeatDensities.Where(d => !d.Equals(0)).Average();
            double offBeatAverageB = offBeatDensities.Where(d => !d.Equals(0)).Where(d => d >= offBeatAverageA * RealSkillRule.LackThreshold).Average();

            // 노트 간격
            double noteIntervalAverageA = noteIntervals.Where(ni => !ni.Equals(0)).Average();
            double noteIntervalAverageB = noteIntervals.Where(ni => !ni.Equals(0)).Where(ni => ni >= noteIntervalAverageA * RealSkillRule.LackThreshold).Average();

            // 분야별 합산
            Reading.TomDensity = tomAverageB;
            Reading.NoteDensity = averageB;
            Reading.AddUp();

            Stamina.PedalDensity = pedalAverageB;
            Stamina.SongLength = durationSum / RealSkillRule.SongLengthCoef;
            Stamina.NoteCount = noteCount / RealSkillRule.NoteCountCoef;
            Stamina.AddUp();

            Agility.NoteInterval = RealSkillRule.NoteIntervalCoef / noteIntervalAverageB;
            Agility.AddUp();

            Concentration.SongLength = durationSum / RealSkillRule.SongLengthCoef;
            Concentration.NoteInterval = RealSkillRule.NoteIntervalCoef / noteIntervalAverageB;
            Concentration.OffBeatDensity = offBeatAverageB / RealSkillRule.OffBeatCoef;
            Concentration.AddUp();

            Accuracy.OffBeatDensity = offBeatAverageB / RealSkillRule.OffBeatCoef;
            Accuracy.AddUp();

        }

        // TODO: 같은 노트의 간격 평균

        // 손으로 치는 노트의 간격 평균
        double GetAverageHandInterval(List<Path> paths)
        {
            List<Path> handPaths = paths.Where(p => !p.noteNum.Equals(3) && !p.noteNum.Equals(6)).ToList();

            if (handPaths.Count < 2) return RealSkillRule.PhraseLength;

            List<double> intervals = new List<double>();

            for (int i = 0; i < handPaths.Count - 1; i++)
            {
                intervals.Add(Math.Abs(handPaths[i + 1].timing - handPaths[i].timing));
            }

            if (intervals.Count(i => i >= RealSkillRule.NoteIntervalMargin) < 1) return RealSkillRule.PhraseLength;

            return intervals.Where(i => i >= RealSkillRule.NoteIntervalMargin).Average();
        }

        // 페달 노트의 간격 평균
        double GetAveragePedalInterval(List<Path> paths)
        {
            List<Path> pedalPaths = paths.Where(p => p.noteNum.Equals(3) || p.noteNum.Equals(6)).ToList();

            if (pedalPaths.Count < 2) return RealSkillRule.PhraseLength;

            List<double> intervals = new List<double>();

            for (int i = 0; i < pedalPaths.Count - 1; i++)
            {
                intervals.Add(Math.Abs(pedalPaths[i + 1].timing - pedalPaths[i].timing));
            }

            if (intervals.Count(i => i >= RealSkillRule.NoteIntervalMargin) < 1) return RealSkillRule.PhraseLength;

            return intervals.Where(i => i >= RealSkillRule.NoteIntervalMargin).Average();
        }

        // 엇박인지 체크
        bool IsOffBeat(double timing)
        {
            double[] beats = { 0, 175, 350, 525, 700, 87.5, 262.5, 437.5, 612.5 };

            timing = (timing - RealSkillRule.StartPhraseTiming) % RealSkillRule.PhraseLength;

            foreach (double beat in beats)
            {
                if (timing >= beat - RealSkillRule.OffBeatMargin && timing <= beat + RealSkillRule.OffBeatMargin)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
