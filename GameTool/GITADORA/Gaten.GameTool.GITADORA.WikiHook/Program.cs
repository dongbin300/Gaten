using System.Net;
using System.Text;

namespace GitadoraWikiHook
{
    class Program
    {
        static void Main(string[] args)
        {
            string id;
            int ncchk = 0, dfstack = 0, dfchk = 0, dfstack2 = 0;
            FileStream fs;
            StreamWriter sw;
            StreamReader sr;

            // =================== HTML Source Load =================== //
            fs = new FileStream("Source.txt", FileMode.Open);
            sw = new StreamWriter(fs);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://remywiki.com/Raspberry");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string strHtml = reader.ReadToEnd();

            reader.Close();
            response.Close();

            sw.WriteLine(strHtml);
            sw.Flush();
            sw.Close();
            fs.Close();

            Console.WriteLine("HTML 소스 로딩 완료.");
            // =================== HTML Source Load =================== //
            /*

            // =================== id value Load =================== //
            fs = new FileStream("id.txt", FileMode.Open);
            sr = new StreamReader(fs);
            id = sr.ReadLine();
            sr.Close();
            fs.Close();

            string new_id = (int.Parse(id) + 1).ToString();

            fs = new FileStream("id.txt", FileMode.Open);
            sw = new StreamWriter(fs);
            sw.WriteLine(new_id);
            sw.Flush();
            sw.Close();
            fs.Close();

            Console.WriteLine("id 값 로딩 완료.");
            // =================== id value Load =================== //


            // =================== Data Hook =================== //
            fs = new FileStream("Source.txt", FileMode.Open);
            sr = new StreamReader(fs);

            int s, e;
            string title = null, bpm = null, length = null, db = null, da = null, de = null, dm = null, gb = null, ga = null, ge = null, gm = null, bb = null, ba = null, be = null, bm = null;

            for (int i = 0; sr.Peek() >= 0; i++)
            {
                string str = sr.ReadLine();

                if(str.Contains("mw-headline"))
                {
                    s = str.IndexOf("mw-headline\" id=\"Raspberry\">");
                    s += "mw-headline\" id=\"Raspberry\">".Length;
                    e = str.IndexOf("</span>", s);
                    title = str.Substring(s, e - s);
                }

                if(str.Contains("BPM: "))
                {
                    s = str.IndexOf("BPM: ");
                    s += "BPM: ".Length;
                    e = str.IndexOf("\"", s);
                    bpm = str.Substring(s, e - s);
                }

                if (str.Contains("Length: "))
                {
                    s = str.IndexOf("Length: ");
                    s += "Length: ".Length;
                    e = str.IndexOf("\"", s);
                    length = str.Substring(s, e - s);
                }

                if (str.Contains("Notecounts"))
                {
                    ncchk = 1;
                }

                if (dfchk == 1)
                {
                    if(str.Contains("73C2FB") && dfstack2 == 0)
                    {
                        s = str.IndexOf("73C2FB;\">");
                        s += "73C2FB;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        db = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if(str.Contains("eeee77") && dfstack2 == 1)
                    {
                        s = str.IndexOf("eeee77;\">");
                        s += "eeee77;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        da = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("FB607F") && dfstack2 == 2)
                    {
                        s = str.IndexOf("FB607F;\">");
                        s += "FB607F;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        de = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("9966CC") && dfstack2 == 3)
                    {
                        s = str.IndexOf("9966CC;\">");
                        s += "9966CC;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        dm = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("73C2FB") && dfstack2 == 4)
                    {
                        s = str.IndexOf("73C2FB;\">");
                        s += "73C2FB;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        gb = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("eeee77") && dfstack2 == 5)
                    {
                        s = str.IndexOf("eeee77;\">");
                        s += "eeee77;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        ga = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("FB607F") && dfstack2 == 6)
                    {
                        s = str.IndexOf("FB607F;\">");
                        s += "FB607F;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        ge = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("9966CC") && dfstack2 == 7)
                    {
                        s = str.IndexOf("9966CC;\">");
                        s += "9966CC;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        gm = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("73C2FB") && dfstack2 == 8)
                    {
                        s = str.IndexOf("73C2FB;\">");
                        s += "73C2FB;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        bb = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("eeee77") && dfstack2 == 9)
                    {
                        s = str.IndexOf("eeee77;\">");
                        s += "eeee77;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        ba = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("FB607F") && dfstack2 == 10)
                    {
                        s = str.IndexOf("FB607F;\">");
                        s += "FB607F;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        be = str.Substring(s, e - s);
                        dfstack++;
                    }
                    if (str.Contains("9966CC") && dfstack2 == 11)
                    {
                        s = str.IndexOf("9966CC;\">");
                        s += "9966CC;\">".Length;
                        e = str.IndexOf(" </td>", s);
                        bm = str.Substring(s, e - s);
                        dfchk = 0;
                    }
                }

                if (ncchk == 1)
                {
                    if(str.Contains("73C2FB;\">"))
                    {
                        dfstack++;
                    }
                    if(dfstack==3)
                    {
                        ncchk = 0;
                        dfchk = 1;
                    }
                }
            }
            // =================== Data Hook =================== //

            string query_str = "INSERT INTO `gitadora_music` (`id`, `Title`, `Artist`, `Composition`, `Lyric`, `BPM`, `Length`, `Basic - D`, `Advanced - D`, `Extreme - D`, `Master - D`, `Basic - G`, `Advanced - G`, `Extreme - G`, `Master - G`, `Basic - B`, `Advanced - B`, `Extreme - B`, `Master - B`, `Version`, `Hit`, `New`) VALUES('"
                + new_id + "', '" + title + "', '" + "-" + "', '" + "-" + "', '" + "-" + "', '" + bpm + "', '" + length + "', '" + db + "', '" + da + "', '" + de + "', '" + dm + "', '" + gb + "', '" + ga + "', '" + ge + "', '" + gm + "', '" + bb + "', '" + ba + "', '" + be + "', '" + bm + "', '" + "tbr" + "', '" + "0" + "', '" + " " + "');";

            Clipboard.SetText(query_str);

            Console.WriteLine("쿼리문 생성 완료.");

            //'115', 'Raspberry', '肥塚良彦', 'Konami Amusement (Yoshihiko Koezuka)', 'Konami Amusement (Yoshihiko Koezuka)', '256', '1:45', '3.00', '4.45', '6.45', '8.10', '2.25', '3.90', '6.80', '8.10', '2.70', '4.05', '5.25', '7.70', 'tbr', '0', '');

            sr.Close();
            fs.Close();
            */
        }
    }
}
