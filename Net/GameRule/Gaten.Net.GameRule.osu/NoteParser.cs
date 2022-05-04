using Gaten.Net.GameRule.osu.OsbFile;
using Gaten.Net.GameRule.osu.OsuFile;
using Gaten.Net.GameRule.osu.OsuFile.Headers;
using Gaten.Net.Extension;
using Gaten.Net.GameRule.osu.OsbFile.Headers;
using System.Drawing;

namespace Gaten.Net.GameRule.osu
{
    public class NoteParser
    {
        public const double timingMultiplier = 1.10;

        public NoteParser()
        {

        }

        public static List<Note> Parse(OsuFileObject obj)
        {
            List<Note> notes = new List<Note>();

            obj.Read();
            double tick = obj.TimingPoints[0].OneBeatMillisecond;
            double bpm = GetBPM(tick);

            foreach (var hitObject in obj.HitObjects)
            {
                int timing = hitObject.TimingPosition;
                int x = NormalizeX(hitObject.X);

                notes.Add(new Note(
                    NoteType.Circle, x, (int)(timing * timingMultiplier)
                    ));

                if (!string.IsNullOrEmpty(hitObject.C)) // Slider
                {
                    // 추후 osu 슬라이더 연구 해야함
                    //foreach (string str2 in hitObject.C) // Search Slider Properties
                    //{
                    //    string[] data3 = str2.Split(',');

                    //    if (data3.Length == 4) // Slider Properties
                    //    {
                    //        double delayPosition = (double.Parse(data3[2]) * tick) / 160.0;
                    //        int repeatCount = int.Parse(data3[1]);
                    //        int x2 = NormalizeX(int.Parse(data3[0].Split(':')[0]));

                    //        for (int i = 0; i < repeatCount; i++)
                    //        {
                    //            // Make Slider
                    //            notes.AddRange(MakeSlider(x, x2, (int)(timing * timingMultiplier), (int)delayPosition));

                    //            timing = (int)(timing + delayPosition);

                    //            notes.Add(new Note(
                    //                NoteType.Circle, i % 2 == 0 ? x2 : x, (int)(timing * timingMultiplier)
                    //                ));
                    //        }
                    //    }
                    //}
                }
            }

            return notes;
        }

        public static OsbFileObject ToOsbFileObject(OsuFileObject osuObj, string fileName)
        {
            OsbFileObject obj = new();
            obj.FileName = fileName.GetDirectory() + fileName.GetExceptDifficulty() + ".osb";

            osuObj.Read();
            foreach (var hitObject in osuObj.HitObjects)
            {
                int x = hitObject.X;
                int timing = hitObject.TimingPosition;

                obj.SBActions.Add(new SBAction()
                {
                    Sprite = new Sprite("n1.png"),
                    StartTiming = timing - 600,
                    EndTiming = timing,
                    StartPoint = new Point(x, 0),
                    EndPoint = new Point(x, 480)
                });
            }

            return obj;
        }

        public static List<Note> MakeSlider(int x1, int x2, int timing, int delayPosition)
        {
            List<Note> notes = new List<Note>();

            if (delayPosition > 50)
            {
                notes.Add(new Note(
                    NoteType.Slider,
                    (x1 + x2 + Note.CircleSize) / 2 - Note.SliderSize / 2,
                    (timing + timing + delayPosition - Note.CircleSize) / 2 + Note.SliderSize / 2
                ));
            }

            return notes;
        }

        public static double GetBPM(double tick)
        {
            return 60000.0 / tick;
        }

        public static int NormalizeX(int x)
        {
            return 205 + (int)(x * 780.0 / 512.0);
        }
    }
}
