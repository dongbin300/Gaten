
using Gaten.Net.Network;

namespace Gaten.GameTool.SDVX.SDVXBingo
{
    public partial class MainForm : Form
    {
        public static string[] title = new string[1000];
        public static int pageCount = 2;
        public static int musicCount = 0;
        public static bool[] exist = new bool[1000];
        public static string[] link = new string[1000];
        public static int[][] averageScore = new int[1000][];
        public static string[] imgUrls = new string[1000];
        public static string[] rank = { "임페리얼IV", "임페리얼III", "임페리얼II", "임페리얼I", "크림슨IV", "크림슨III", "크림슨II", "크림슨I", "엘도라IV", "엘도라III", "엘도라II", "엘도라I", "아르젠토IV", "아르젠토III", "아르젠토II", "아르젠토I" };
        public static int[] volForceCut = { 10075, 10050, 10025, 10000, 9875, 9750, 9625, 9500, 9375, 9250, 9125, 9000, 8750, 8500, 8250, 8000 };
        public static int level = 0;
        public static int volForce = 0;
        public static int yourRank = 0;
        public static int yourTargetRank = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private static int musicCountCal(int musicCount, int pageIndex)
        {
            if (musicCount >= (pageIndex + 1) * 50)
            {
                return 50;
            }
            else
            {
                return musicCount % 50;
            }
        }

        private void subcreatebt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                exist[i] = false;
            }
            toolStripStatusLabel1.Text = "만드는 중...";
            volForce = int.Parse(volforcetb.Text);
            level = int.Parse(fumenlvtb.Text);

            for (int i = 0; i < rank.Length; i++)
            {
                if (volForce >= volForceCut[i])
                {
                    yourRank = i;
                    break;
                }
                if (i == rank.Length - 1)
                {
                    yourRank = i;
                    break;
                }
            }
            yourTargetRank = Math.Max(0, yourRank - 1);


            WebCrawler.Open();
            for (int page = 0; page < pageCount; page++)
            {
                // 채보 정보 메인 후킹
                WebCrawler.SetUrl("https://anzuinfo.me/tracks.html?sort=title_up&filter_level=" + Math.Pow(2, level - 1) + "&filter_diff=255&page=" + (page + 1));

                // (2021-12-30)현재 안즈인포에서 볼포스별 평균을 안보여주는 상태여서 추후 보여주면 개발함.

                //bool getTitle = false;
                //int c = 0;
                //int linkCounter = -100;
                //string str = "";

                //    linkCounter--;
                //    str = sr.ReadLine();

                //    if (getTitle)
                //    {
                //        Main.title[page * 50 + c] = str.Substring(5);
                //        getTitle = false;
                //    }
                //    if (linkCounter == -2)
                //    {
                //        Main.link[page * 50 + c] = DataSubstring(str, "location.href='./", "'>", 0);
                //        c++;
                //    }
                //    if (str.Contains("<td class=title>"))
                //    {
                //        getTitle = true;
                //        linkCounter = 3;
                //    }
                //    if (str.Contains("<div class=track_count>"))
                //    {
                //        Main.musicCount = int.Parse(str.Substring(str.IndexOf("악곡 수 : ") + 6));
                //    }
                //    if (page == 0 && str.Contains("<div id=cur_page>"))
                //    {
                //        Main.pageCount = int.Parse(DataSubstring(str, "1/", " 페이지", 0));
                //    }


                //for (int i = 0; i < musicCountCal(musicCount, page); i++)
                //{
                //    int idx = page * 50 + i;
                //    averageScore[idx] = new int[rank.Length];
                //    link[idx] = "http://anzuinfo.me/" + link[idx]; // 채보 정보 링크

                //    // 채보 정보 후킹
                //    source = hsh.WebPageToSource(req, res, sr, link[idx], Encoding.UTF8);
                //    hsh.WriteSourceTxtFile("music.txt", source);
                //    hsh.HookDataMusic("music.txt", idx);
                //    hsh.DownloadImageFile("image" + idx + ".jpg", imgUrls[idx]);

                //    //Console.WriteLine();
                //    // Console.WriteLine(title[page * 50 + i]);
                //    //for (int j = 0; j < 12; j++)
                //    //{
                //    //    Console.WriteLine(averageScore[page * 50 + i][j]);
                //    //}
                //}
            }
            WebCrawler.Close();

            FileStream fs = new FileStream("target.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            Random rnd = new Random();

            sw.Write("<html><head></head><body>볼포스: " + volForce + ", 랭크: " + rank[yourRank] + "<br>");

            sw.Write("<table border=1 width=500>");
            for (int i = 0; i < 5; i++)
            {
                sw.Write("<tr>");
                for (int j = 0; j < 5; j++)
                {
                    int idx = rnd.Next(musicCount);
                    while (exist[idx])
                    {
                        idx = rnd.Next(musicCount);
                    }
                    exist[idx] = true;
                    sw.Write("<td><img src=image" + idx + ".jpg width=100><br><b>" + title[idx] + " " + (averageScore[idx][yourTargetRank] / 10000) + "</b></td>");
                }
                sw.Write("</tr>");
            }
            sw.Write("</table>");

            sw.WriteLine("</body></html>");

            sw.Flush();
            fs.Close();
            toolStripStatusLabel1.Text = "완료";

            System.Diagnostics.Process.Start("target.html");
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}