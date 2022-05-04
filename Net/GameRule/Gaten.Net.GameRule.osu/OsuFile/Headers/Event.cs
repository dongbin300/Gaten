using Gaten.Net.GameRule.osu.OsuFile.Headers.Events;

namespace Gaten.Net.GameRule.osu.OsuFile.Headers
{
    public class Event
    {
        public Background Background;
        public Video Video;
        public List<string> F;
        public string BreakPeriod;
        public string StoryboardBackground;
        public string StoryboardFail;
        public string StoryboardPass;
        public string StoryboardForeground;
        public List<StoryboardSoundSample> StoryboardSoundSamples;
        public List<BackgroundColourTransformation> BackgroundColourTransformations;

        public Event(string str)
        {
            F = new List<string>();
            StoryboardSoundSamples = new List<StoryboardSoundSample>();
            BackgroundColourTransformations = new List<BackgroundColourTransformation>();

            Parse(str);
        }

        void Parse(string str)
        {
            string[] data = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int p = 0;

            foreach (string s0 in data)
            {
                string s = s0.Trim();

                if (s == string.Empty)
                {
                    continue;
                }

                switch (s)
                {
                    case "//Background and Video events":
                        p = 1;
                        break;
                    case "//Break Periods":
                        p = 2;
                        break;
                    case "//Storyboard Layer 0 (Background)":
                        p = 3;
                        break;
                    case "//Storyboard Layer 1 (Fail)":
                        p = 4;
                        break;
                    case "//Storyboard Layer 2 (Pass)":
                        p = 5;
                        break;
                    case "//Storyboard Layer 3 (Foreground)":
                        p = 6;
                        break;
                    case "//Storyboard Sound Samples":
                        p = 7;
                        break;
                    case "//Background Colour Transformations":
                        p = 8;
                        break;
                    default:
                        switch (p)
                        {
                            case 1:
                                string[] data2 = s.Split(',');

                                if (data2[0].Trim().Equals("Video"))
                                {
                                    Video = new Video()
                                    {
                                        Tag = data2[0],
                                        TimingPosition = int.Parse(data2[1]),
                                        FileName = data2[2].Replace("\"", "")
                                    };
                                }
                                else if (data2[0].Trim().Equals("F"))
                                {
                                    F.Add(s);
                                }
                                else
                                {
                                    Background = new Background()
                                    {
                                        A = int.Parse(data2[0]),
                                        B = int.Parse(data2[1]),
                                        FileName = data2[2].Replace("\"", ""),
                                        C = int.Parse(data2[3]),
                                        D = int.Parse(data2[4])
                                    };
                                }
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                string[] data3 = s.Split(',');

                                if (data3[0].Equals("Sample"))
                                {
                                    StoryboardSoundSamples.Add(new StoryboardSoundSample()
                                    {
                                        Tag = data3[0],
                                        TimingPosition = int.Parse(data3[1]),
                                        A = int.Parse(data3[2]),
                                        FileName = data3[3].Replace("\"", ""),
                                        Volume = int.Parse(data3[4])
                                    });
                                }
                                break;
                            case 8:
                                string[] data4 = s.Split(',');

                                BackgroundColourTransformations.Add(new BackgroundColourTransformation()
                                {
                                    A = int.Parse(data4[0]),
                                    B = int.Parse(data4[1]),
                                    C = int.Parse(data4[2]),
                                    D = int.Parse(data4[3]),
                                    E = int.Parse(data4[4])
                                });
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }
    }
}
