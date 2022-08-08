using System.Net;
using System.Text;

namespace Gaten.GameTool.GITADORA.Macro
{
    internal class MusicInfoDb
    {
        private readonly int id = 1061;
        private int curp;
        private readonly string otitle = string.Empty;
        private readonly string title = string.Empty;
        private readonly string artist = string.Empty;
        private readonly string composition = string.Empty;
        private readonly string lyric = string.Empty;
        private readonly string bpm = string.Empty;
        private readonly string length = string.Empty;
        private readonly string version = "exc";

        public MusicInfoDb()
        {
            while (true)
            {
                id++;
                curp = 0;
                otitle = string.Empty;
                title = string.Empty;
                artist = string.Empty;
                composition = string.Empty;
                lyric = string.Empty;
                bpm = string.Empty;
                length = string.Empty;
                version = "exc";

                Console.Write("remywiki url: ");
                string dir = Console.ReadLine();
                string source = string.Empty;

                using (WebClient wc = new())
                {
                    wc.Encoding = Encoding.UTF8;
                    source = wc.DownloadString(dir);
                    wc.DownloadFile("https://remywiki.com" + DataSubstring(source, "<img alt=\"\" src=\"", "\"", 0), $@"image\{id}.png");
                }

                title = DataSubstring(source, "class=\"firstHeading\" lang=\"en\">", "</h1>", 0);
                otitle = DataSubstring(source, "\">", "</span>", source.IndexOf("class=\"mw-headline\""));

                string musicInfoSource = DataSubstring(source, "<p>", "</p>", source.IndexOf("<div class=\"thumb tright\">"));
                string[] misContents = musicInfoSource.Split(new string[] { "<br />" }, StringSplitOptions.None);
                foreach (string str in misContents)
                {
                    if (str.Contains("Artist"))
                    {
                        artist = str.Split(':')[1].Trim();
                        if (artist.Contains("href"))
                        {
                            artist = DataSubstring(artist, "\">", "</a>", 0);
                        }
                    }
                    if (str.Contains("Composition"))
                    {
                        composition = str.Split(':')[1].Trim();
                        if (composition.Contains("href"))
                        {
                            composition = DataSubstring(composition, "\">", "</a>", 0);
                        }
                    }
                    if (str.Contains("Lyric"))
                    {
                        lyric = str.Split(':')[1].Trim();
                        if (lyric.Contains("href"))
                        {
                            lyric = DataSubstring(lyric, "\">", "</a>", 0);
                        }
                    }
                    if (str.Contains("BPM"))
                    {
                        bpm = str.Split(':')[1].Trim();
                    }

                    if (str.Contains("Length"))
                    {
                        length = str.Split(':')[1].Trim() + ":" + str.Split(':')[2].Trim();
                    }
                }

                int s0 = source.IndexOf("Difficulty &amp; Notecounts");
                int s = source.IndexOf("<td> GITADORA EXCHAIN&#8594;Present </td>", s0);
                string db = DataSubstring(source, "#73C2FB;\">", " </td>", s).Replace("&#8593;", "").Replace("&#8595;", "");
                string da = DataSubstring(source, "#eeee77;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string de = DataSubstring(source, "#FB607F;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string dm = DataSubstring(source, "#9966CC;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string gb = DataSubstring(source, "#73C2FB;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string ga = DataSubstring(source, "#eeee77;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string ge = DataSubstring(source, "#FB607F;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string gm = DataSubstring(source, "#9966CC;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string bb = DataSubstring(source, "#73C2FB;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string ba = DataSubstring(source, "#eeee77;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string be = DataSubstring(source, "#FB607F;\">", " </td>", curp).Replace("&#8593;", "").Replace("&#8595;", "");
                string bm = DataSubstring(source, "#9966CC;\">", "</td>", curp).Replace("&#8593;", "").Replace("&#8595;", "").Trim();

                // (519, 'MODEL DD10', 'Mutsuhiko Izumi', 'Mutsuhiko Izumi', '', '150', '1:46', '5.20', '6.80', '8.70', '9.55', '4.50', '8.40', '9.25', '9.91', '5.40', '6.20', '8.00', '8.95', 'GITADORA', 0, ''),

                FileStream fs = new("music_info.sql", FileMode.Append);
                StreamWriter sw = new(fs, Encoding.UTF8);
                //sw.WriteLine(",");
                //sw.Write("{" + $"\"id\":\"{id}\",\"Title\":\"{title}\",\"Artist\":\"{artist}\",\"Composition\":\"{composition}\",\"Lyric\":\"{lyric}\",\"BPM\":\"{bpm}\",\"Length\":\"{length}\",\"Basic-D\":\"{db}\",\"Advanced-D\":\"{da}\",\"Extreme-D\":\"{de}\",\"Master-D\":\"{dm}\",\"Basic-G\":\"{gb}\",\"Advanced-G\":\"{ga}\",\"Extreme-G\":\"{ge}\",\"Master-G\":\"{gm}\",\"Basic-B\":\"{bb}\",\"Advanced-B\":\"{ba}\",\"Extreme-B\":\"{be}\",\"Master-B\":\"{bm}\",\"Version\":\"{version}\",\"Hit\":\"0\",\"New\":\"\"" + "}");

                sw.WriteLine($"({id}, '{otitle}', '{title}', '{artist}', '{composition}', '{lyric}', '{bpm}', '{length}', '{db}', '{da}', '{de}', '{dm}', '{gb}', '{ga}', '{ge}', '{gm}', '{bb}', '{ba}', '{be}', '{bm}', '{version}', 0, ''),");

                sw.Flush();
                fs.Close();
            }

            string DataSubstring(string o, string s, string e, int cur)
            {
                int p = o.IndexOf(s, cur);
                p += s.Length;
                int ep = o.IndexOf(e, p);
                curp = ep;
                return o[p..ep];
            }
        }
    }
}
