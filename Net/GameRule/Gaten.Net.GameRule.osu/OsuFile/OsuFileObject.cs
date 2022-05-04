using Gaten.Net.GameRule.osu.OsuFile.Headers;
using Gaten.Net.GameRule.osu.OsuFile.Headers.Events;

using System.Text;

using File = Gaten.Net.Data.IO.File;

namespace Gaten.Net.GameRule.osu.OsuFile
{
    public class OsuFileObject
    {
        public string FileName;
        public string? Version;
        public Dictionary<string, string> General = new();
        public Dictionary<string, string> Editor = new();
        public Dictionary<string, string> Metadata = new();
        public Dictionary<string, string> Difficulty = new();
        public Dictionary<string, string> Colour = new();
        public Event? Event;
        public List<TimingPoint> TimingPoints = new();
        public List<HitObject> HitObjects = new();

        public List<double> Bookmarks = new();
        public List<string> Tags = new();

        public OsuFileObject()
        {
            FileName = string.Empty;
        }

        public OsuFileObject(string fileName)
        {
            FileName = fileName;
        }

        public void Read()
        {
            //string[] data = Regex.Split(File.Read(FileName), @"(\[\w+\]\r\n)");
            string[] data = File.ReadToArray(FileName);

            Version = data[0].Split('v')[1].Trim();

            for (int i = 1; i < data.Length; i += 2)
            {
                string s = data[i].Trim();

                switch (s)
                {
                    case "[General]":
                        string[] data2 = data[i + 1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string m in data2)
                        {
                            string[] contents = m.Split(':');
                            General.Add(contents[0].Trim(), contents[1].Trim());
                        }
                        break;
                    case "[Editor]":
                        string[] data3 = data[i + 1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string m in data3)
                        {
                            string[] contents = m.Split(':');
                            Editor.Add(contents[0].Trim(), contents[1].Trim());

                            if (contents[0].Trim().Equals("Bookmarks"))
                            {
                                string[] bookmarkData = contents[1].Trim().Split(',');
                                foreach (string bm in bookmarkData)
                                {
                                    Bookmarks.Add(int.Parse(bm));
                                }
                            }
                        }
                        break;
                    case "[Metadata]":
                        string[] data4 = data[i + 1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string m in data4)
                        {
                            string[] contents = m.Split(':');
                            Metadata.Add(contents[0].Trim(), contents[1].Trim());

                            if (contents[0].Trim().Equals("Tags"))
                            {
                                string[] tagData = contents[1].Trim().Split(' ');
                                foreach (string t in tagData)
                                {
                                    Tags.Add(t);
                                }
                            }
                        }
                        break;
                    case "[Difficulty]":
                        string[] data5 = data[i + 1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string m in data5)
                        {
                            string[] contents = m.Split(':');
                            Difficulty.Add(contents[0].Trim(), contents[1].Trim());
                        }
                        break;
                    case "[Events]":
                        Event = new Event(data[i + 1]);
                        break;
                    case "[TimingPoints]":
                        string[] data6 = data[i + 1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string m in data6)
                        {
                            string[] contents = m.Split(',');
                            TimingPoints.Add(new TimingPoint()
                            {
                                TimingPosition = double.Parse(contents[0]),
                                OneBeatMillisecond = double.Parse(contents[1]),
                                A = int.Parse(contents[2]),
                                B = int.Parse(contents[3]),
                                C = int.Parse(contents[4]),
                                D = int.Parse(contents[5]),
                                E = int.Parse(contents[6]),
                                F = int.Parse(contents[7])
                            });
                        }
                        break;
                    case "[Colours]":
                        string[] data7 = data[i + 1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string m in data7)
                        {
                            string[] contents = m.Split(':');
                            Colour.Add(contents[0].Trim(), contents[1].Trim());
                        }
                        break;
                    case "[HitObjects]":
                        string[] data8 = data[i + 1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string m in data8)
                        {
                            string[] contents = m.Split(',');
                            HitObjects.Add(new HitObject()
                            {
                                X = int.Parse(contents[0]),
                                Y = int.Parse(contents[1]),
                                TimingPosition = int.Parse(contents[2]),
                                A = int.Parse(contents[3]),
                                B = int.Parse(contents[4]),
                                C = contents[5]
                            });
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void Write(string newFileName = "")
        {
            StringBuilder builder = new();

            builder.AppendLine("osu file format v" + Version);
            builder.AppendLine();

            if (General != null && General.Count > 0)
            {
                builder.AppendLine("[General]");
                foreach (KeyValuePair<string, string> pair in General)
                {
                    builder.AppendLine($"{pair.Key}: {pair.Value}");
                }

                builder.AppendLine();
            }

            if (Editor != null && Editor.Count > 0)
            {
                builder.AppendLine("[Editor]");
                foreach (KeyValuePair<string, string> pair in Editor)
                {
                    builder.AppendLine($"{pair.Key}: {pair.Value}");
                }

                builder.AppendLine();
            }

            if (Metadata != null && Metadata.Count > 0)
            {
                builder.AppendLine("[Metadata]");
                foreach (KeyValuePair<string, string> pair in Metadata)
                {
                    builder.AppendLine($"{pair.Key}:{pair.Value}");
                }

                builder.AppendLine();
            }

            if (Difficulty != null && Difficulty.Count > 0)
            {
                builder.AppendLine("[Difficulty]");
                foreach (KeyValuePair<string, string> pair in Difficulty)
                {
                    builder.AppendLine($"{pair.Key}:{pair.Value}");
                }

                builder.AppendLine();
            }

            if (Event != null)
            {
                builder.AppendLine("[Events]");
                builder.AppendLine("//Background and Video events");
                if (Event.Background != null)
                {
                    builder.AppendLine($"{Event.Background.A},{Event.Background.B},\"{Event.Background.FileName}\",{Event.Background.C},{Event.Background.D}");
                }

                if (Event.Video != null)
                {
                    builder.AppendLine($"{Event.Video.Tag},{Event.Video.TimingPosition},\"{Event.Video.FileName}\"");
                }

                if (Event.F != null && Event.F.Count > 0)
                {
                    foreach (string f in Event.F)
                    {
                        builder.AppendLine(f);
                    }
                }

                builder.AppendLine("//Break Periods");
                builder.AppendLine("//Storyboard Layer 0 (Background)");
                builder.AppendLine("//Storyboard Layer 1 (Fail)");
                builder.AppendLine("//Storyboard Layer 2 (Pass)");
                builder.AppendLine("//Storyboard Layer 3 (Foreground)");
                builder.AppendLine("//Storyboard Sound Samples");
                if (Event.StoryboardSoundSamples != null && Event.StoryboardSoundSamples.Count > 0)
                {
                    foreach (StoryboardSoundSample sss in Event.StoryboardSoundSamples)
                    {
                        builder.AppendLine($"{sss.Tag},{sss.TimingPosition},{sss.A},\"{sss.FileName}\",{sss.Volume}");
                    }
                }

                if (Event.BackgroundColourTransformations != null && Event.BackgroundColourTransformations.Count > 0)
                {
                    builder.AppendLine("//Background Colour Transformations");
                    foreach (BackgroundColourTransformation bct in Event.BackgroundColourTransformations)
                    {
                        builder.AppendLine($"{bct.A},{bct.B},{bct.C},{bct.D},{bct.E}");
                    }
                }

                builder.AppendLine();
            }

            if (TimingPoints != null && TimingPoints.Count > 0)
            {
                builder.AppendLine("[TimingPoints]");

                foreach (TimingPoint tp in TimingPoints)
                {
                    builder.AppendLine($"{tp.TimingPosition},{tp.OneBeatMillisecond},{tp.A},{tp.B},{tp.C},{tp.D},{tp.E},{tp.F}");
                }

                builder.AppendLine();
                builder.AppendLine();
            }

            if (Colour != null && Colour.Count > 0)
            {
                builder.AppendLine("[Colours]");

                foreach (KeyValuePair<string, string> c in Colour)
                {
                    builder.AppendLine($"{c.Key} : {c.Value}");
                }

                builder.AppendLine();
            }

            if (HitObjects != null && HitObjects.Count > 0)
            {
                builder.AppendLine("[HitObjects]");

                foreach (HitObject o in HitObjects)
                {
                    builder.AppendLine($"{o.X},{o.Y},{o.TimingPosition},{o.A},{o.B},{o.C}");
                }

                builder.AppendLine();
            }

            File.Write(newFileName == "" ? FileName : newFileName, builder.ToString());
        }

        public void WriteByAnotherObject(OsuFileObject obj)
        {
            StringBuilder builder = new();

            builder.AppendLine("osu file format v" + obj.Version);
            builder.AppendLine();

            if (obj.General != null && obj.General.Count > 0)
            {
                builder.AppendLine("[General]");
                foreach (KeyValuePair<string, string> pair in obj.General)
                {
                    builder.AppendLine($"{pair.Key}: {pair.Value}");
                }

                builder.AppendLine();
            }

            if (obj.Editor != null && obj.Editor.Count > 0)
            {
                builder.AppendLine("[Editor]");
                foreach (KeyValuePair<string, string> pair in obj.Editor)
                {
                    builder.AppendLine($"{pair.Key}: {pair.Value}");
                }

                builder.AppendLine();
            }

            if (obj.Metadata != null && obj.Metadata.Count > 0)
            {
                builder.AppendLine("[Metadata]");
                foreach (KeyValuePair<string, string> pair in obj.Metadata)
                {
                    builder.AppendLine($"{pair.Key}:{pair.Value}");
                }

                builder.AppendLine();
            }

            if (obj.Difficulty != null && obj.Difficulty.Count > 0)
            {
                builder.AppendLine("[Difficulty]");
                foreach (KeyValuePair<string, string> pair in obj.Difficulty)
                {
                    builder.AppendLine($"{pair.Key}:{pair.Value}");
                }

                builder.AppendLine();
            }

            if (obj.Event != null)
            {
                builder.AppendLine("[Events]");
                builder.AppendLine("//Background and Video events");
                if (obj.Event.Background != null)
                {
                    builder.AppendLine($"{obj.Event.Background.A},{obj.Event.Background.B},\"{obj.Event.Background.FileName}\",{obj.Event.Background.C},{obj.Event.Background.D}");
                }

                if (obj.Event.Video != null)
                {
                    builder.AppendLine($"{obj.Event.Video.Tag},{obj.Event.Video.TimingPosition},\"{obj.Event.Video.FileName}\"");
                }

                if (obj.Event.F != null && obj.Event.F.Count > 0)
                {
                    foreach (string f in obj.Event.F)
                    {
                        builder.AppendLine(f);
                    }
                }

                builder.AppendLine("//Break Periods");
                builder.AppendLine("//Storyboard Layer 0 (Background)");
                builder.AppendLine("//Storyboard Layer 1 (Fail)");
                builder.AppendLine("//Storyboard Layer 2 (Pass)");
                builder.AppendLine("//Storyboard Layer 3 (Foreground)");
                builder.AppendLine("//Storyboard Sound Samples");
                if (obj.Event.StoryboardSoundSamples != null && obj.Event.StoryboardSoundSamples.Count > 0)
                {
                    foreach (StoryboardSoundSample sss in obj.Event.StoryboardSoundSamples)
                    {
                        builder.AppendLine($"{sss.Tag},{sss.TimingPosition},{sss.A},\"{sss.FileName}\",{sss.Volume}");
                    }
                }

                if (obj.Event.BackgroundColourTransformations != null && obj.Event.BackgroundColourTransformations.Count > 0)
                {
                    builder.AppendLine("//Background Colour Transformations");
                    foreach (BackgroundColourTransformation bct in obj.Event.BackgroundColourTransformations)
                    {
                        builder.AppendLine($"{bct.A},{bct.B},{bct.C},{bct.D},{bct.E}");
                    }
                }

                builder.AppendLine();
            }

            if (obj.TimingPoints != null && obj.TimingPoints.Count > 0)
            {
                builder.AppendLine("[TimingPoints]");

                foreach (TimingPoint tp in obj.TimingPoints)
                {
                    builder.AppendLine($"{tp.TimingPosition},{tp.OneBeatMillisecond},{tp.A},{tp.B},{tp.C},{tp.D},{tp.E},{tp.F}");
                }

                builder.AppendLine();
                builder.AppendLine();
            }

            if (obj.Colour != null && obj.Colour.Count > 0)
            {
                builder.AppendLine("[Colours]");

                foreach (KeyValuePair<string, string> c in obj.Colour)
                {
                    builder.AppendLine($"{c.Key} : {c.Value}");
                }

                builder.AppendLine();
            }

            if (obj.HitObjects != null && obj.HitObjects.Count > 0)
            {
                builder.AppendLine("[HitObjects]");

                foreach (HitObject o in obj.HitObjects)
                {
                    builder.AppendLine($"{o.X},{o.Y},{o.TimingPosition},{o.A},{o.B},{o.C}");
                }

                builder.AppendLine();
            }

            File.Write(FileName, builder.ToString());
        }


        //public void ParseObject(string fileName)
        //{
        //    using (FileStream fs = new FileStream(fileName, FileMode.Open))
        //    {
        //        using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
        //        {
        //            while (sr.Peek() >= 0)
        //            {
        //                string[] contents = sr.ReadLine().Split(':');
        //                if (contents.Length > 1)
        //                {
        //                    switch (contents[0])
        //                    {
        //                        case "Bookmarks":
        //                            string[] bookmarkData = contents[1].Split(',');
        //                            foreach (string str in bookmarkData)
        //                            {
        //                                Bookmarks.Add(double.Parse(str));
        //                            }
        //                            Properties.Add(contents[0].Trim(), Bookmarks);
        //                            break;
        //                        case "Tags":
        //                            string[] tagData = contents[1].Split(' ');
        //                            foreach (string str in tagData)
        //                            {
        //                                Tags.Add(str);
        //                            }
        //                            Properties.Add(contents[0].Trim(), Tags);
        //                            break;
        //                        default:
        //                            if (contents[0].Contains("Combo"))
        //                            {
        //                                string[] comboColorData = contents[1].Split(',');
        //                                ComboColors.Add(Color.FromArgb(int.Parse(comboColorData[0]), int.Parse(comboColorData[1]), int.Parse(comboColorData[2])));
        //                                if (Properties.Where(key => key.Key == "ComboColors").Count() == 0)
        //                                    Properties.Add("ComboColors", ComboColors);
        //                            }
        //                            else
        //                                Properties.Add(contents[0].Trim(), contents[1].Trim());
        //                            break;
        //                    }
        //                }
        //                else
        //                {
        //                    // TODO: Events, TimingPoints
        //                    if (contents[0].Contains("osu file format"))
        //                    {
        //                        Properties.Add("FileFormatVersion", contents[0].Split('v')[1]);
        //                    }
        //                    if (contents[0] == "[HitObjects]")
        //                    {
        //                        break;
        //                    }
        //                    if (contents[0] == "[TimingPoints]")
        //                    {
        //                        while (true)
        //                        {
        //                            string timingString = sr.ReadLine();

        //                            if (timingString.Length <= 2) break;

        //                            string[] timingData = timingString.Split(',');
        //                            TimingPoints.Add(new TimingPoint(int.Parse(timingData[0]), double.Parse(timingData[1]), int.Parse(timingData[2]), int.Parse(timingData[3]), int.Parse(timingData[4]), int.Parse(timingData[5]), int.Parse(timingData[6]), int.Parse(timingData[7])));
        //                        }
        //                    }
        //                }
        //            }

        //            while (sr.Peek() >= 0)
        //            {
        //                string str = sr.ReadLine();
        //                HitObjectStrings.Add(str);

        //                string[] hitObjectData = str.Split(',');
        //                HitObjects.Add(new HitObject(int.Parse(hitObjectData[0]), int.Parse(hitObjectData[1]), int.Parse(hitObjectData[2]), int.Parse(hitObjectData[3]), int.Parse(hitObjectData[4]), hitObjectData[5]));
        //            }

        //            Properties.Add("HitObjectStrings", HitObjectStrings);
        //            Properties.Add("HitObjects", HitObjects);
        //        }
        //    }
        //}
    }
}
