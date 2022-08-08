using System.Net;
using System.Text;

namespace Gaten.GameTool.GITADORA.Macro
{
    internal class OtitleDb
    {
        private int curp;
        private readonly string source = string.Empty;

        public OtitleDb()
        {
            string[] url = new string[1000];
            string[] otitle = new string[1000];
            while (true)
            {

                Console.Write("remywiki url: ");
                string dir = Console.ReadLine();
                using (WebClient wc = new())
                {
                    wc.Encoding = Encoding.UTF8;
                    source = wc.DownloadString(dir);
                }

                int p = 0;
                url[p++] = "https://remywiki.com" + DataSubstring(source, "<a href=\"", "\" title", source.IndexOf("<td>"));
                while (true)
                {
                    try
                    {
                        url[p++] = "https://remywiki.com" + DataSubstring(source, "<a href=\"", "\" title", curp);
                    }
                    catch
                    {
                        break;
                    }
                }

                int q = 0;
                for (int i = 0; i < p; i++)
                {
                    try
                    {
                        using (WebClient wc = new())
                        {
                            wc.Encoding = Encoding.UTF8;
                            source = wc.DownloadString(url[i]);
                        }
                        otitle[q++] = DataSubstring(source, "\">", "</span>", source.IndexOf("class=\"mw-headline\""));

                    }
                    catch
                    {

                    }
                }

                FileStream fs = new("otitle.txt", FileMode.Append);
                StreamWriter sw = new(fs, Encoding.UTF8);
                for (int i = 0; i < q; i++)
                {
                    sw.WriteLine(otitle[i]);
                }
                sw.Flush();
                fs.Close();
            }
        }

        private string DataSubstring(string o, string s, string e, int cur)
        {
            int p = o.IndexOf(s, cur);
            p += s.Length;
            int ep = o.IndexOf(e, p);
            curp = ep;
            return o[p..ep];
        }
    }
}
