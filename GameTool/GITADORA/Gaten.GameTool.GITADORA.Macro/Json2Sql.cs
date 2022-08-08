using System.Text;

namespace Gaten.GameTool.GITADORA.Macro
{
    internal class Json2Sql
    {
        public Json2Sql()
        {
            string[] id = new string[1000];
            string[] title = new string[1000];
            string[] artist = new string[1000];
            string[] composition = new string[1000];
            string[] lyric = new string[1000];
            string[] bpm = new string[1000];
            string[] length = new string[1000];
            string[] bd = new string[1000];
            string[] ad = new string[1000];
            string[] ed = new string[1000];
            string[] md = new string[1000];
            string[] bg = new string[1000];
            string[] ag = new string[1000];
            string[] eg = new string[1000];
            string[] mg = new string[1000];
            string[] bb = new string[1000];
            string[] ab = new string[1000];
            string[] eb = new string[1000];
            string[] mb = new string[1000];
            string[] version = new string[1000];
            string[] hit = new string[1000];
            string[] newstr = new string[1000];

            FileStream fs = new("music_info.json", FileMode.Open);
            StreamReader sr = new(fs, Encoding.UTF8);
            int p = 0;
            for (int i = 0; sr.Peek() >= 0; i++)
            {
                string str = sr.ReadLine();
                if (i <= 4)
                {
                    continue;
                }

                str = str.Replace("{", "").Replace("}", "");
                string[] contents = str.Split(',');
                id[p] = contents[0].Split(':')[1].Replace("\"", "");
                title[p] = contents[1].Split(':')[1].Replace("\"", "");
                artist[p] = contents[2].Split(':')[1].Replace("\"", "");
                composition[p] = contents[3].Split(':')[1].Replace("\"", "");
                lyric[p] = contents[4].Split(':')[1].Replace("\"", "");
                bpm[p] = contents[5].Split(':')[1].Replace("\"", "");
                length[p] = contents[6].Split(':')[1].Replace("\"", "") + ":" + contents[6].Split(':')[2].Replace("\"", "");
                bd[p] = contents[7].Split(':')[1].Replace("\"", "");
                ad[p] = contents[8].Split(':')[1].Replace("\"", "");
                ed[p] = contents[9].Split(':')[1].Replace("\"", "");
                md[p] = contents[10].Split(':')[1].Replace("\"", "");
                bg[p] = contents[11].Split(':')[1].Replace("\"", "");
                ag[p] = contents[12].Split(':')[1].Replace("\"", "");
                eg[p] = contents[13].Split(':')[1].Replace("\"", "");
                mg[p] = contents[14].Split(':')[1].Replace("\"", "");
                bb[p] = contents[15].Split(':')[1].Replace("\"", "");
                ab[p] = contents[16].Split(':')[1].Replace("\"", "");
                eb[p] = contents[17].Split(':')[1].Replace("\"", "");
                mb[p] = contents[18].Split(':')[1].Replace("\"", "");
                version[p] = contents[19].Split(':')[1].Replace("\"", "");
                hit[p] = contents[20].Split(':')[1].Replace("\"", "");
                newstr[p] = contents[21].Split(':')[1].Replace("\"", "");

                p++;
            }

            sr.Close();
            fs.Close();

            FileStream fs2 = new("music_info.sql", FileMode.Create);
            StreamWriter sw = new(fs2, Encoding.UTF8);

            //(1, 'Cagayake!GIRLS', '桜高軽音部', 'Tom-H@ck', 'Shoko Oomori', '170', '1:31', '1.90', '3.90', '6.30', '7.60', '1.70', '3.60', '5.10', '7.55', '1.95', '3.80', '6.00', '7.40', 'mat', 452, ''),
            for (int i = 0; i < p; i++)
            {
                sw.WriteLine($"({id[i]}, '{title[i]}', '{artist[i]}', '{composition[i]}', '{lyric[i]}', '{bpm[i]}', '{length[i]}', '{bd[i]}', '{ad[i]}', '{ed[i]}', '{md[i]}', '{bg[i]}', '{ag[i]}', '{eg[i]}', '{mg[i]}', '{bb[i]}', '{ab[i]}', '{eb[i]}', '{mb[i]}', '{version[i]}', {hit[i]}, '{newstr[i]}'),");
            }

            sw.Flush();
            fs2.Close();
        }
    }
}
