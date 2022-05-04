using Gaten.Net.Image;

using HtmlAgilityPack;

using System.Drawing;
using System.Net;
using System.Text;

using Path = Gaten.Net.GameRule.GITADORA.Path;

namespace Gaten.GameTool.GITADORA.FumenMaker
{
    class Program
    {
        // svg일수도 있고 png일수도 있음
        public static string svgFileName = string.Empty;

        public static List<Path> paths = new();
        public static Config config = new();

        public static int start = 15483;
        public static int end = start;


        static string[] diffModes = { "bsc", "adv", "ext", "mst" };
        static string[] modes = { "drum", "guitar", "bass" };
        /*
         * GetChartFile()
         * 채보 링크 넣고
         * 채보다운 + 파일이름은 DB상에서 번호와 매칭
         * 
         * GetNotes()
         * 다운 받은 파일을 웹으로 열어서 파싱
         * 
         */
        static void Main(string[] args)
        {
            svgFileName = "test";
            paths = GetNotesFromPng(Game.Mode.Drum);

            GetConfig(Game.Mode.Drum);

            paths = PathAPI.ConvertPath(paths, config, PathAPI.FumenViewMode.OneLine);

            WriteTextFile(paths);

            Console.WriteLine("변환 완료.");

            /*
            for (int i = start; i <= end; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int k = 0; k < 1; k++)
                    {
                        svgFileName = string.Empty;
                        paths.Clear();
                        config.Clear();

                        string result = GetChartFile(i.ToString(), diffModes[k], modes[j]);
                        // ip endpoint change test code 
                        //string result = test();

                        // 클래식은 하지 않음
                        if (result == "classic") continue;

                        // 해당 포맷(url)으로 채보 파일이 없음
                        if (result == "urlerror") continue;

                        switch(result)
                        {
                            case "good svg":

                                // 드럼
                                if (j == 0)
                                {
                                    paths = GetNotes(Game.Mode.Drum);

                                    GetConfig(Game.Mode.Drum);

                                    paths = PathAPI.ConvertPath(paths, config, PathAPI.FumenViewMode.OneLine);
                                }

                                // 기타/베이스
                                else
                                {
                                    paths = GetNotes(Game.Mode.Guitar);

                                    GetConfig(Game.Mode.Guitar);

                                    paths = PathAPI.ConvertPath(paths, config, PathAPI.FumenViewMode.OneLine);
                                    paths = PathAPI.ReversePath(paths, config);
                                }
                                break;

                            case "good png":

                                // 드럼
                                if (j == 0)
                                {
                                    paths = GetNotesFromPng(Game.Mode.Drum);

                                    GetConfig(Game.Mode.Drum);

                                    paths = PathAPI.ConvertPath(paths, config, PathAPI.FumenViewMode.OneLine);
                                }

                                // 기타/베이스
                                else
                                {
                                    paths = GetNotesFromPng(Game.Mode.Guitar);

                                    GetConfig(Game.Mode.Guitar);

                                    paths = PathAPI.ConvertPath(paths, config, PathAPI.FumenViewMode.OneLine);
                                    paths = PathAPI.ReversePath(paths, config);
                                }
                                break;
                        }

                        WriteTextFile(paths);

                        Console.WriteLine("변환 완료.");
                    }
                }
                Console.WriteLine($"{i} 완료!==========");
            }
            */
        }

        public static IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            //Console.WriteLine("BindIPEndpoint called");
            return new IPEndPoint(IPAddress.Parse("23.227.142.218"), 5000);
        }

        static string test()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://기타섬머/viewer.php?t=0&id=1&d=ext&p=drum");

                request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                return "good";
            }
            catch (Exception)
            {
                return "error";
            }
        }

        static string GetChartFile(string _id, string diffMode, string mode)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                HtmlDocument doc = null;
                string mainUrl = "http://기타섬머";
                string url = string.Empty;
                string svgFileNameInChartViewer = string.Empty;
                string oTitle = string.Empty;
                string id = string.Empty;

                // Chart Viewer 사이트 접속
                try
                {
                    url = $"{mainUrl}viewer.php?id={_id}&t=0&d={diffMode}&p={mode}&m=2";
                    string source = client.DownloadString(url);
                    doc = new HtmlDocument();
                    doc.LoadHtml(source);
                }
                catch (Exception)
                {
                    Console.WriteLine("URL 에러");
                    return "urlerror";
                }

                // svg파일이름, 혹은 png파일이름 얻기
                try
                {
                    svgFileNameInChartViewer = doc.DocumentNode.SelectSingleNode("//div[@class='chart']/img").Attributes["src"].Value;
                }
                catch (Exception)
                {
                    Console.WriteLine("svg파일이름 get 에러");
                }

                // otitle 얻기
                try
                {
                    oTitle = doc.DocumentNode.SelectSingleNode("//span[@class='info__title']").InnerText;
                    if (oTitle.Contains("(CLASSIC)")) return "classic";
                }
                catch (Exception)
                {
                    Console.WriteLine("otitle get 에러");
                }

                // develop.기타도라넷 접속
                using (WebClient client2 = new WebClient())
                {
                    client2.Encoding = Encoding.UTF8;
                    string source2 = client2.DownloadString("http://develop.기타도라넷/id.php");
                    doc.LoadHtml(source2);
                }

                // id, otitle 매칭
                try
                {
                    id = doc.DocumentNode.SelectSingleNode($"//td[text()='{oTitle}']").Attributes["id"].Value;
                    svgFileName = id;
                }
                catch
                {
                    svgFileName = FindId(_id);
                }

                // 추출 svg파일명 설정
                if (url.Contains("p=drum"))
                    svgFileName += "d";
                else if (url.Contains("p=guitar"))
                    svgFileName += "g";
                else if (url.Contains("p=bass"))
                    svgFileName += "b";

                if (url.Contains("d=bsc"))
                    svgFileName += "b";
                else if (url.Contains("d=adv"))
                    svgFileName += "a";
                else if (url.Contains("d=ext"))
                    svgFileName += "e";
                else if (url.Contains("d=mst"))
                    svgFileName += "m";

                // svg파일, 혹은 png파일 다운로드
                string[] data = svgFileNameInChartViewer.Split('.');
                string extension = data[data.Length - 1];
                client.DownloadFile($"{mainUrl}{svgFileNameInChartViewer}", $"result/{svgFileName}.{extension}");

                Console.Write($"{_id},{mode},{diffMode} => {svgFileName}.{extension} 획득 완료.  ");

                return $"good {extension}";
            }
        }

        static List<Path> GetNotes(Game.Mode mode)
        {
            List<Path> paths = new List<Path>();

            using (WebClient client = new WebClient())
            {
                string source = client.DownloadString($@"C:\Users\kdb\source\repos\FumenMaker\bin\Debug\result\{svgFileName}.svg");
                var doc = new HtmlDocument();
                doc.LoadHtml(source);

                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//path"))
                {
                    paths.Add(ParsePath(node, mode));
                }
            }

            return paths;
        }

        static List<Path> GetNotesFromPng(Game.Mode mode)
        {
            List<Path> paths = new List<Path>();

            Bitmap bitmap = (Bitmap)Image.FromFile($@"C:\Users\kdb\source\repos\FumenMaker\bin\Debug\result\{svgFileName}.png");

            LockBitmap lockBitmap = new LockBitmap(bitmap);
            lockBitmap.LockBits();

            List<Color> colors = new List<Color>();
            for (int i = 0; i < lockBitmap.Height; i++)
            {
                for (int j = 0; j < lockBitmap.Width; j++)
                {
                    colors.Add(lockBitmap.GetPixel(j, i));
                }
            }

            paths = FindNotes(colors, lockBitmap.Width, lockBitmap.Height);

            lockBitmap.UnlockBits();
            lockBitmap.Dispose();

            int notecount = paths.Where(p => p.type.Equals(Path.Type.Note)).Count();
            int spcount = paths.Where(p => p.type.Equals(Path.Type.SmallPhrase)).Count();
            int bpcount = paths.Where(p => p.type.Equals(Path.Type.BigPhrase)).Count();

            return paths;
        }

        static List<Path> FindNotes(List<Color> colors, int width, int height)
        {
            List<Path> paths = new List<Path>();
            List<Path> bpPaths = new List<Path>();
            List<Path> spPaths = new List<Path>();
            List<Path> noPaths = new List<Path>();
            bool FoundLine = false;
            bool Normalize = false;
            const int NoteWidth = 50;
            const int NoteHeight = 8; // 7일 경우도 있음
            const int LineHeight = 6;

            // 경계선 안쪽 노트가 위치할 수 있는 영역 정의
            Point Start = new Point(131, 77);
            //Point Start = new Point(131, 44100);
            Point End = new Point(width - 131, height - 95);
            //Point End = new Point(width - 131, height - 95);

            // 스캔 시작
            for (int i = Start.Y; i < End.Y; i++)
            {
                for (int j = Start.X; j < End.X; j++)
                {
                    // 픽셀 RGB값
                    Color pixel = colors[i * width + j];

                    //if (i == 44176 || i == 20478)
                    //{
                    //    Console.WriteLine($"{j}: {pixel}");
                    //}

                    // 선이나 노트 픽셀을 찾으면
                    if (IsObject(colors[i * width + j], 5))
                    {
                        // 선인지 노트인지 판별
                        // -1: 에러, 0: 노트, 1: 소절선, 2: 대절선
                        int result = DeterminateObject(colors, i, j, width, FoundLine);

                        switch (result)
                        {
                            case 0: // 노트

                                // 라인의 첫 노트면 밑으로 1픽셀(평준화)
                                if (!Normalize)
                                {
                                    Normalize = true;
                                    i++;
                                }

                                int noteNum = GetNoteNumByPosition(j);

                                noPaths.Add(new Path()
                                {
                                    type = Path.Type.Note,
                                    timing = i + 3,
                                    noteNum = noteNum
                                });

                                // 라이드 심벌은 마지막 노트이기 때문에 백트랙으로 선을 찾아야함
                                if (noteNum == 9)
                                {
                                    switch (BackTrack(colors, i, j, width))
                                    {
                                        case 1: // 소절선
                                            spPaths.Add(new Path()
                                            {
                                                type = Path.Type.SmallPhrase,
                                                timing = i + 3
                                            });

                                            // 선을 찾음
                                            FoundLine = true;
                                            Console.WriteLine($"[{(i - 77) / 700 + 1}] {i}");

                                            break;
                                        case 2: // 대절선
                                            bpPaths.Add(new Path()
                                            {
                                                type = Path.Type.BigPhrase,
                                                timing = i + 3
                                            });

                                            // 선을 찾음
                                            FoundLine = true;

                                            break;
                                    }
                                }

                                // 노트 넓이+2만큼 x좌표이동
                                j += NoteWidth + 2;

                                //if (i == 44177)
                                //{
                                //    Console.WriteLine(noteNum);
                                //}

                                break;

                            case 1: // 소절선

                                spPaths.Add(new Path()
                                {
                                    type = Path.Type.SmallPhrase,
                                    timing = i + 3
                                });

                                // 선을 찾음
                                FoundLine = true;
                                Console.WriteLine($"[{(i - 77) / 700 + 1}] {i}");

                                break;

                            case 2: // 대절선

                                bpPaths.Add(new Path()
                                {
                                    type = Path.Type.BigPhrase,
                                    timing = i + 3
                                });

                                //Console.WriteLine($"[{(i-77)/700+1}] {i}");
                                // 선을 찾음
                                FoundLine = true;

                                break;
                        }
                    }
                }

                // 그 라인에서 노트를 찾았다면 노트 높이+2만큼 y좌표 스캔 스킵
                if (Normalize)
                {
                    Normalize = false;
                    FoundLine = false;
                    i += NoteHeight + 2;
                }

                // 그 라인에서 선을 찾았다면 선 높이만큼 y좌표 스캔 스킵
                // 오브젝트도 찾았다면 이 단계를 스킵함
                if (FoundLine)
                {
                    FoundLine = false;
                    i += LineHeight;
                }
            }

            // 대절선, 소절선, 노트 순으로 paths에 이어붙힘
            paths.AddRange(bpPaths);
            paths.AddRange(spPaths);
            paths.AddRange(noPaths);

            return paths;
        }

        /// <summary>
        /// 오브젝트(선 혹은 노트)인지 확인
        /// 검은색이 아니면 오브젝트로 인식
        /// </summary>
        /// <param name="color">픽셀 컬러</param>
        /// <param name="margin">오차범위, 10일 경우 (10,10,10)까지는 허용함</param>
        /// <returns></returns>
        static bool IsObject(Color color, int margin = 10)
        {
            return !IsBlack(color, margin);
        }

        /// <summary>
        /// 검은색인지 확인
        /// </summary>
        /// <param name="color">픽셀 컬러</param>
        /// <param name="margin">오차범위, 10일 경우 (10,10,10)까지는 허용함</param>
        /// <returns></returns>
        static bool IsBlack(Color color, int margin = 10)
        {
            return color.R + color.G + color.B <= margin * 3;
        }

        static int GetNoteNum(Color color)
        {
            Color[] noteColorValues = new Color[9];
            noteColorValues[0] = Color.FromArgb(255, 0, 102);
            noteColorValues[1] = Color.FromArgb(62, 160, 255);
            noteColorValues[2] = Color.FromArgb(255, 54, 229);
            noteColorValues[3] = Color.FromArgb(190, 175, 2);
            noteColorValues[4] = Color.FromArgb(0, 156, 26);
            noteColorValues[5] = Color.FromArgb(129, 99, 255);
            noteColorValues[6] = Color.FromArgb(192, 0, 45);
            noteColorValues[7] = Color.FromArgb(255, 132, 0);
            noteColorValues[8] = Color.FromArgb(0, 92, 217);

            Color nearestColor = noteColorValues[0];
            int nearestIndex = 0;
            for (int i = 1; i < noteColorValues.Length; i++)
            {
                nearestColor = GetNearestColor(color, nearestColor, noteColorValues[i]);
                nearestIndex = nearestColor == noteColorValues[i] ? i : nearestIndex;
                /*if (IsSameColor(color, noteColorValues[i], 40))
                {
                    return i + 1;
                }*/
            }
            return nearestIndex + 1;
        }

        static int GetNoteNumByPosition(int j)
        {
            return (j - 80) / 50;
        }

        /// <summary>
        /// 숫자가 범위안에 포함되는지 확인
        /// </summary>
        /// <param name="x">대상</param>
        /// <param name="min">최소값</param>
        /// <param name="max">최대값</param>
        /// <returns></returns>
        static bool IsRange(int x, int min, int max)
        {
            return x >= min && x <= max;
        }

        /// <summary>
        /// 같은 색인지 확인
        /// </summary>
        /// <param name="color1">픽셀 컬러1</param>
        /// <param name="color2">픽셀 컬러2</param>
        /// <param name="margin">오차 범위</param>
        /// <returns></returns>
        static bool IsSameColor(Color color1, Color color2, int margin = 10)
        {
            return IsRange(color1.R, color2.R - margin, color2.R + margin) &&
                IsRange(color1.G, color2.G - margin, color2.G + margin) &&
                IsRange(color1.B, color2.B - margin, color2.B + margin);
        }

        /// <summary>
        /// 그레이색인지 확인
        /// </summary>
        /// <param name="color">픽셀 컬러</param>
        /// <param name="margin">오차범위</param>
        /// <returns></returns>
        static bool IsGrayColor(Color color, int margin = 10)
        {
            return Math.Abs(color.R - color.G) <= margin && Math.Abs(color.R - color.B) <= margin && Math.Abs(color.G - color.B) <= margin;
        }

        /// <summary>
        /// 해당 좌표에서 Y축(밑)으로 inspectHeight만큼의 평균값
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="width"></param>
        /// <param name="inspectHeight"></param>
        /// <returns></returns>
        static Color AverageOfInspectY(List<Color> colors, int i, int j, int width, int inspectHeight)
        {
            int R = 0;
            int G = 0;
            int B = 0;

            for (int t = 0; t < inspectHeight; t++)
            {
                R += colors[(i + t) * width + j].R;
                G += colors[(i + t) * width + j].G;
                B += colors[(i + t) * width + j].B;
            }

            return Color.FromArgb(R / inspectHeight, G / inspectHeight, B / inspectHeight);
        }

        /// <summary>
        /// 대상에 더 가까운 색상을 선택
        /// </summary>
        /// <param name="color">비교 대상 컬러</param>
        /// <param name="color1">후보1 컬러</param>
        /// <param name="color2">후보2 컬러</param>
        /// <returns></returns>
        static Color GetNearestColor(Color color, Color color1, Color color2)
        {
            return Math.Sqrt(Math.Pow(color.R - color1.R, 2) + Math.Pow(color.G - color1.G, 2) + Math.Pow(color.B - color1.B, 2)) < Math.Sqrt(Math.Pow(color.R - color2.R, 2) + Math.Pow(color.G - color2.G, 2) + Math.Pow(color.B - color2.B, 2)) ? color1 : color2;
        }

        /// <summary>
        /// 오브젝트가 선인지 노트인지 판별
        /// </summary>
        /// <param name="colors">RGB테이블</param>
        /// <param name="i">height</param>
        /// <param name="j">width</param>
        /// <param name="width">이미지의 넓이</param>
        /// <param name="isFoundLine">선 탐색 플래그</param>
        /// <returns>
        /// -1 : 선도 아니고 노트도 아님
        /// 0 : 노트임
        /// 1 : 소절선
        /// 2 : 대절선
        /// </returns>
        static int DeterminateObject(List<Color> colors, int i, int j, int width, bool isFoundLine)
        {
            const int NoteInspectX = 16;
            //const int NoteInspectY = 6;
            const int LineInspectY = 6;
            Color smallPhraseColor = Color.FromArgb(74, 74, 74);
            Color bigPhraseColor = Color.FromArgb(151, 151, 151);

            // 선
            // LineInspectY 구간의 평균값이 GrayColor면 선으로 인식
            if (IsGrayColor(AverageOfInspectY(colors, i, j, width, LineInspectY), 3))
            {
                // 이미 찾은 선이면 스킵(에러)
                if (isFoundLine) return -1;

                return GetNearestColor(colors[(i + 3) * width + j], smallPhraseColor, bigPhraseColor) == smallPhraseColor ? 1 : 2;
            }
            // 노트
            // 선이 아니면 노트로 인식
            else
            {
                int blackCount = 0;
                for (int t = 0; t < NoteInspectX; t++)
                {
                    if (IsBlack(colors[i * width + j + t])) blackCount++;

                    // 검은색이 2픽셀 이상이면 노트가 아님(에러)
                    if (blackCount >= 2) return -1;
                }

                // 노트
                return 0;
            }
        }

        /// <summary>
        /// 백트랙
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="width"></param>
        /// <returns>
        /// 0 : 선 없음
        /// 1 : 소절선
        /// 2 : 대절선
        /// </returns>
        static int BackTrack(List<Color> colors, int i, int j, int width)
        {
            Color smallPhraseColor = Color.FromArgb(74, 74, 74);
            Color bigPhraseColor = Color.FromArgb(151, 151, 151);

            if (IsSameColor(colors[(i + 3) * width + j - 50], smallPhraseColor) &&
                IsSameColor(colors[(i + 3) * width + j - 100], smallPhraseColor) &&
                IsSameColor(colors[(i + 3) * width + j - 150], smallPhraseColor) &&
                IsSameColor(colors[(i + 3) * width + j - 200], smallPhraseColor))
            {
                return 1;
            }
            else if (IsSameColor(colors[(i + 3) * width + j - 50], bigPhraseColor) &&
                IsSameColor(colors[(i + 3) * width + j - 100], bigPhraseColor) &&
                IsSameColor(colors[(i + 3) * width + j - 150], bigPhraseColor) &&
                IsSameColor(colors[(i + 3) * width + j - 200], bigPhraseColor))
            {
                return 2;
            }
            else
                return 0;
        }

        static Path ParsePath(HtmlNode node, Game.Mode mode)
        {
            string[] d = node.Attributes["d"].Value.Split(new char[] { ',', ' ' });
            Path path = new Path();

            switch (mode)
            {
                case Game.Mode.Drum:
                    path.timing = double.Parse(d[1].Replace("-", ""));

                    switch (node.Attributes["stroke"].Value)
                    {
                        case "#979797":
                            path.type = d[1] == d[3] ? Path.Type.BigPhrase : Path.Type.Boundary;
                            break;
                        case "#4a4a4a":
                            path.type = Path.Type.SmallPhrase;
                            break;
                        default:
                            path.type = Path.Type.Note;
                            path.noteNum = ((int)double.Parse(d[0].Replace("M", "")) - 80) / 50;
                            break;
                    }
                    break;

                case Game.Mode.Guitar:
                case Game.Mode.Bass:
                    path.timing = double.Parse(d[1].Replace("-", ""));

                    switch (node.Attributes["stroke"].Value)
                    {
                        case "#979797":
                            path.type = d[1] == d[3] ? Path.Type.BigPhrase : Path.Type.Boundary;
                            break;
                        case "#4a4a4a":
                            path.type = Path.Type.SmallPhrase;
                            break;
                        case "#ff0066":
                            path.type = Path.Type.Note;
                            path.noteNum = double.Parse(node.Attributes["stroke-width"].Value) > 10 ? 6 : 1;
                            break;
                        case "#009c1a":
                            path.type = Path.Type.Note;
                            path.noteNum = double.Parse(node.Attributes["stroke-width"].Value) > 10 ? 7 : 2;
                            break;
                        case "#3ea0ff":
                            path.type = Path.Type.Note;
                            path.noteNum = double.Parse(node.Attributes["stroke-width"].Value) > 10 ? 8 : 3;
                            break;
                        case "#beaf02":
                            path.type = Path.Type.Note;
                            path.noteNum = double.Parse(node.Attributes["stroke-width"].Value) > 10 ? 9 : 4;
                            break;
                        case "#ff36e5":
                            path.type = Path.Type.Note;
                            path.noteNum = double.Parse(node.Attributes["stroke-width"].Value) > 10 ? 10 : double.Parse(d[2].Replace("L", "")) - double.Parse(d[0].Replace("M", "")) > 100 ? 11 : 5;
                            break;
                        case "#ffffff":
                            path.type = Path.Type.Note;
                            path.noteNum = double.Parse(d[1]) > double.Parse(d[3]) ? 12 : 13;
                            break;
                    }
                    // 홀드노트 길이 설정
                    if (path.noteNum >= 6 && path.noteNum <= 10)
                    {
                        path.holdLength = double.Parse(node.Attributes["stroke-width"].Value);
                    }

                    break;
            }

            return path;
        }

        static void GetConfig(Game.Mode mode)
        {
            config.width = mode == Game.Mode.Drum ? 480 : 220;
            config.height = (int)paths.Max(p => p.timing);
        }

        static void WriteTextFile(List<Path> paths)
        {
            using (FileStream stream = new FileStream($"result/{svgFileName}.txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.WriteLine($"CFG,{config.width},{config.height}");
                    foreach (Path path in paths)
                    {
                        switch (path.type)
                        {
                            case Path.Type.BigPhrase:
                                writer.WriteLine($"BP,{path.lineNum},{path.timing}");
                                break;
                            case Path.Type.SmallPhrase:
                                writer.WriteLine($"SP,{path.lineNum},{path.timing}");
                                break;
                            case Path.Type.Note:
                                if (path.holdLength != 0) // 홀드노트
                                    writer.WriteLine($"NO,{path.lineNum},{path.timing},{path.noteNum},{path.holdLength}");
                                else
                                    writer.WriteLine($"NO,{path.lineNum},{path.timing},{path.noteNum}");
                                break;
                        }
                    }
                    writer.Flush();
                }
            }
        }

        static string FindId(string id)
        {
            string[] data =
            {
                "6/1096",
                "7/1095",
                "11/1105",
                "46/1084"

            };

            foreach (string str in data)
            {
                if (str.Split('/')[0].Equals(id))
                {
                    return str.Split('/')[1];
                }
            }

            return "temp" + id;
        }
    }
}