using Gaten.GameTool.GITADORA.Macro.Data;

using HtmlAgilityPack;

using System.Net;
using System.Text;

namespace Gaten.GameTool.GITADORA.Macro
{
    internal class DifficultyChanger
    {
        private readonly List<Song> songs = new();

        public DifficultyChanger()
        {
            ParseDiffTable();

            MakeQueryFile();
        }

        private void ParseDiffTable()
        {
            using FileStream stream = new("list.txt", FileMode.Open);
            using StreamReader reader = new(stream, Encoding.UTF8);
            _ = reader.ReadLine();
            _ = reader.ReadLine();
            while (reader.Peek() >= 0)
            {
                string str = reader.ReadLine();

                string[] data = str.Split('	');
                songs.Add(new Song()
                {
                    Title = data[0],
                    Guitar = new Mode()
                    {
                        Basic = new Diff()
                        {
                            Old = data[1],
                            New = data[2],
                            Gap = data[3]
                        },
                        Advanced = new Diff()
                        {
                            Old = data[4],
                            New = data[5],
                            Gap = data[6]
                        },
                        Extreme = new Diff()
                        {
                            Old = data[7],
                            New = data[8],
                            Gap = data[9]
                        },
                        Master = new Diff()
                        {
                            Old = data[10],
                            New = data[11],
                            Gap = data[12]
                        }
                    },
                    Bass = new Mode()
                    {
                        Basic = new Diff()
                        {
                            Old = data[13],
                            New = data[14],
                            Gap = data[15]
                        },
                        Advanced = new Diff()
                        {
                            Old = data[16],
                            New = data[17],
                            Gap = data[18]
                        },
                        Extreme = new Diff()
                        {
                            Old = data[19],
                            New = data[20],
                            Gap = data[21]
                        },
                        Master = new Diff()
                        {
                            Old = data[22],
                            New = data[23],
                            Gap = data[24]
                        }
                    },
                    Drum = new Mode()
                    {
                        Basic = new Diff()
                        {
                            Old = data[25],
                            New = data[26],
                            Gap = data[27]
                        },
                        Advanced = new Diff()
                        {
                            Old = data[28],
                            New = data[29],
                            Gap = data[30]
                        },
                        Extreme = new Diff()
                        {
                            Old = data[31],
                            New = data[32],
                            Gap = data[33]
                        },
                        Master = new Diff()
                        {
                            Old = data[34],
                            New = data[35],
                            Gap = data[36]
                        }
                    }
                });
            }
        }

        private void MakeQueryFile()
        {
            HtmlDocument doc = new();
            using FileStream stream = new("query.sql", FileMode.Create);
            using StreamWriter writer = new(stream, Encoding.UTF8);
            foreach (Song song in songs)
            {
                // develop.기타도라넷 접속
                using (WebClient client = new())
                {
                    client.Encoding = Encoding.UTF8;
                    string source = client.DownloadString("http://develop.기타도라넷/id.php");
                    doc.LoadHtml(source);
                }

                string id;
                // id, otitle 매칭
                try
                {
                    id = doc.DocumentNode.SelectSingleNode($"//td[text()='{song.Title}']").Attributes["id"].Value;
                }
                catch (Exception)
                {
                    id = song.Title;
                }

                // UPDATE `music_info` SET `Basic_D` = '2.45' WHERE `music_info`.`id` = 1;
                string query = "UPDATE `music_info` SET ";
                if (song.Drum.Basic.New != "0.00")
                {
                    query += $"`Basic_D` = '{song.Drum.Basic.New}', ";
                }

                if (song.Drum.Advanced.New != "0.00")
                {
                    query += $"`Advanced_D` = '{song.Drum.Advanced.New}', ";
                }

                if (song.Drum.Extreme.New != "0.00")
                {
                    query += $"`Extreme_D` = '{song.Drum.Extreme.New}', ";
                }

                if (song.Drum.Master.New != "0.00")
                {
                    query += $"`Master_D` = '{song.Drum.Master.New}', ";
                }

                if (song.Guitar.Basic.New != "0.00")
                {
                    query += $"`Basic_G` = '{song.Guitar.Basic.New}', ";
                }

                if (song.Guitar.Advanced.New != "0.00")
                {
                    query += $"`Advanced_G` = '{song.Guitar.Advanced.New}', ";
                }

                if (song.Guitar.Extreme.New != "0.00")
                {
                    query += $"`Extreme_G` = '{song.Guitar.Extreme.New}', ";
                }

                if (song.Guitar.Master.New != "0.00")
                {
                    query += $"`Master_G` = '{song.Guitar.Master.New}', ";
                }

                if (song.Bass.Basic.New != "0.00")
                {
                    query += $"`Basic_B` = '{song.Bass.Basic.New}', ";
                }

                if (song.Bass.Advanced.New != "0.00")
                {
                    query += $"`Advanced_B` = '{song.Bass.Advanced.New}', ";
                }

                if (song.Bass.Extreme.New != "0.00")
                {
                    query += $"`Extreme_B` = '{song.Bass.Extreme.New}', ";
                }

                if (song.Bass.Master.New != "0.00")
                {
                    query += $"`Master_B` = '{song.Bass.Master.New}', ";
                }

                query = query[..^2];
                query += $" WHERE `music_info`.`id` = {id};";

                Console.WriteLine(song.Title);

                writer.WriteLine(query);
            }

            writer.Flush();
        }
    }
}
