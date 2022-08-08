using Gaten.Net.IO;
using Gaten.Net.Windows;
using Gaten.Net.Windows.Forms;

using Microsoft.Win32;

using System.Diagnostics;

namespace Gaten.GameTool.osu.osuBeatmapDownloader
{
    /*
     * v2.3.0 Update Lists
     * 드래그해서 창을 이동시킬 수 있는 기능 추가
     * 최소화 기능 제거
     * 트레이 아이콘 제거
     * 화면 레이블 삭제(비트맵 다운로드 중일 때만 화면에 진행 상황이 뜸)
     * 
     * 마우스 오른쪽클릭으로 메뉴 진입 기능 추가
     * 단축키 추가
     * 다운로드 활성화/비활성화 기능 추가
     * 항상 위에 표시 설정 추가
     * 투명도 기능 추가
     * 배경 이미지 설정 추가
     * 창 크기 설정 추가(최소 200*200)
     * 옵션 초기화 기능 추가
     * 옵션 설정 버그 수정
     * 
     * 사이트URL 수정
     * 비트맵 다운로드 버그 수정
     * 다운로드 실패 오류 수정
     * 프로그램 안정성 개선
     */
    public partial class DownloadForm : Form
    {
        OptionForm of = new OptionForm();

        enum Proceedings { Wait, AnalyzeChromeUrl, AnalyzeHTMLSource, DownloadBeatmap, ExecuteBeatmap }
        Proceedings proceed;

        Thread downloader;
        Thread viewWorker;

        List<string> downloadedLists = new List<string>();

        bool isRunning = false;

        public DownloadForm()
        {
            try
            {
                InitializeComponent();

                // 메뉴
                ContextMenuStrip = menu;

                // 작업표시줄 아이콘 숨김
                ShowInTaskbar = false;

                // 항상 위에 표시
                TopMost = true;

                // 폼 투명화
                //BackColor = Color.LimeGreen;
                //TransparencyKey = Color.LimeGreen;

                // 버전 표시
                versionToolStripMenuItem.Text = $"v{General.Version}";

                // 창 크기
                Size = Settings.Default.WindowSize;

                // 배경 이미지
                BackgroundImage = Image.FromFile(Settings.Default.BackgroundImageFile);

                // 메뉴 체크 상태
                다운로드활성화ToolStripMenuItem.Checked = Settings.Default.ActivateDownloader;
                항상위에표시ToolStripMenuItem.Checked = Settings.Default.TopMostAlways;

                // 다운로드 목록 불러오기
                string result = LoadDownloadedLists();
                if (result != string.Empty)
                {
                    MessageBox.Show("LoadDownloadedLists Error: " + result);
                }

                // 쓰레드 시작
                downloader = new Thread(new ThreadStart(Work));
                downloader.Start();

                viewWorker = new Thread(new ThreadStart(Proceed));
                viewWorker.Start();

                // 대기
                proceed = Proceedings.Wait;

                // 업데이트 확인
                if (Settings.Default.ConfirmUpdate)
                {
                    string result2 = ConfirmUpdate();

                    if (result2 != string.Empty)
                    {
                        MessageBox.Show("ConfirmUpdate Error: " + result2);
                    }
                }

                // 옵션 변경 이벤트
                Settings.Default.PropertyChanged += Default_PropertyChanged;

                // 처리 상황 라벨 기본 설정
                proceedLabel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DownloadForm Error: " + ex.Message);
            }
        }

        #region Main Work
        /// <summary>
        /// 업데이트가 있는지 확인
        /// </summary>
        string ConfirmUpdate()
        {
        //    try
        //    {
        //        using (WebClient client = new WebClient())
        //        {
        //            client.Encoding = Encoding.UTF8;
        //            string source = client.DownloadString(General.OfficialURL);

        //            if (source == null)
        //            {
        //                return "update-source: null";
        //            }

        //            var doc = new HtmlAgilityPack.HtmlDocument();
        //            doc.LoadHtml(source);

        //            if (doc.DocumentNode == null)
        //            {
        //                return "update-doc.DocumentNode: null";
        //            }

        //            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//li[@class='new-version']"))
        //            {
        //                string latestVersionString = node.InnerText.Split(new string[] { ".zip" }, StringSplitOptions.None)[0];

        //                if (latestVersionString == null)
        //                {
        //                    return "update-latestVersionString: null";
        //                }

        //                if (!General.Version.Equals(latestVersionString))
        //                {
        //                    if (MessageBox.Show("새 버전이 나왔습니다. 패치하시겠습니까?", "패치", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
        //                    {
        //                        Process.Start(General.OfficialDownloadURL);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }

            return string.Empty;
        }

        /// <summary>
        /// 다운받았던 비트맵 파일 목록을 저장
        /// </summary>
        string SaveDownloadedLists(string beatmapNumber)
        {
            try
            {
                GFile.AppendLine(General.DownloadedListPath, beatmapNumber);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }

        /// <summary>
        /// 다운받았던 비트맵 파일 목록을 로드
        /// </summary>
        string LoadDownloadedLists()
        {
            try
            {
                if (!File.Exists(General.DownloadedListPath))
                {
                    File.Create(General.DownloadedListPath).Close();
                }

                downloadedLists.Clear();
                var lists = GFile.ReadToArray(General.DownloadedListPath);
                foreach (string str in lists)
                {
                    downloadedLists.Add(str);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }

        /// <summary>
        /// 현재 상태 스레드
        /// </summary>
        void Proceed()
        {
            while (true)
            {
                switch (proceed)
                {
                    case Proceedings.Wait:
                        Delegater.TextSet(proceedLabel, "대기");
                        break;
                    case Proceedings.AnalyzeChromeUrl:
                        Delegater.TextSet(proceedLabel, "크롬 URL 분석중..");
                        break;
                    case Proceedings.AnalyzeHTMLSource:
                        Delegater.TextSet(proceedLabel, "HTML소스 분석중..");
                        break;
                    case Proceedings.DownloadBeatmap:
                        Delegater.TextSet(proceedLabel, "비트맵 다운로드중..");
                        break;
                    case Proceedings.ExecuteBeatmap:
                        Delegater.TextSet(proceedLabel, "비트맵 실행중..");
                        break;
                }

                // 대기 중이 아니면 진행 상황을 보여줌
                Delegater.VisibleSet(proceedLabel, proceed != Proceedings.Wait);

                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// 비트맵 다운로드 스레드
        /// </summary>
        void Work()
        {
            while (true)
            {
                try
                {
                    if (!isRunning && Settings.Default.ActivateDownloader)
                    {
                        // 현재 크롬 URL
                        string chromeCurrentUrl = GetChromeCurrentUrl();

                        if (chromeCurrentUrl != null)
                        {
                            if (chromeCurrentUrl.StartsWith("osu.ppy.sh/beatmapsets/"))
                            {
                                isRunning = true;

                                string result = ParseUrl(chromeCurrentUrl);

                                isRunning = false;

                                if (result != string.Empty)
                                {
                                    MessageBox.Show("ParseUrl Error: " + result);
                                }
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
                catch
                {
                    isRunning = false;
                }
            }
        }

        /// <summary>
        /// 비트맵 다운로드 전체적인 루틴
        /// 크롬URL을 분석해서 블캣에서 다운로드 후 실행
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string ParseUrl(string url)
        {
            try
            {
                // 크롬 URL 분석
                proceed = Proceedings.AnalyzeChromeUrl;
                string[] urlData = url.Split('/');
                if (urlData == null)
                {
                    return "urlData: null";
                }

                // 비트맵 번호 문자열
                string beatmapNumberString = urlData[urlData.Length - 1];

                // 다운받았던 목록 불러오기
                string result = LoadDownloadedLists();
                if (result != string.Empty)
                {
                    MessageBox.Show("LoadDownloadedLists Error: " + result);
                }

                // 이미 다운받았던 곡인지 확인
                if (downloadedLists.Find(d => d.Equals(beatmapNumberString)) != null)
                {
                    proceed = Proceedings.Wait;
                    return string.Empty;
                }

                // 비트맵 다운로드 후 실행
                string result2 = Download(beatmapNumberString);
                if (result2 != string.Empty && result2 != "노드없음")
                {
                    MessageBox.Show("Download Error: " + result2);
                }

                // 다운로드 목록 저장하기
                string result3 = SaveDownloadedLists(beatmapNumberString);
                if (result3 != string.Empty)
                {
                    MessageBox.Show("SaveDownloadedLists Error: " + result3);
                }

                // 대기
                proceed = Proceedings.Wait;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }

        /// <summary>
        /// 비트맵 다운로드
        /// </summary>
        /// <param name="beatmapNumberString"></param>
        string Download(string beatmapNumberString)
        {
            //try
            //{
            //    if (beatmapNumberString == null)
            //    {
            //        return "beatmapNumberString: null";
            //    }

            //    // HTML 소스 분석
            //    proceed = Proceedings.AnalyzeHTMLSource;
            //    using (WebClient client = new WebClient())
            //    {
            //        client.Encoding = Encoding.UTF8;
            //        string source = client.DownloadString($"https://bloodcat.com/osu/?q={beatmapNumberString}");

            //        if (source == null)
            //        {
            //            return "source: null";
            //        }

            //        var doc = new HtmlAgilityPack.HtmlDocument();

            //        if (doc == null)
            //        {
            //            return "doc: null";
            //        }

            //        doc.LoadHtml(source);

            //        if (doc.DocumentNode == null)
            //        {
            //            return "doc.DocumentNode: null";
            //        }

            //        var nodes = doc.DocumentNode.SelectNodes("//a[@class='title']");

            //        if (nodes == null)
            //        {
            //            return "노드없음";
            //        }

            //        foreach (HtmlNode node in nodes)
            //        {
            //            string bloodcatDownloadUrl = node.GetAttributeValue("href", ""); // s/112233

            //            if (bloodcatDownloadUrl == null)
            //            {
            //                return "bloodcatDownloadUrl: null";
            //            }

            //            string beatmapTitle = node.InnerText.
            //                Replace('\\', '-').Replace('/', '-').Replace(':', '-').Replace('*', '-').
            //                Replace('?', '-').Replace('\"', '-').Replace('<', '-').Replace('>', '-').Replace('|', '-'); // Existence

            //            if (beatmapTitle == null)
            //            {
            //                return "beatmapTitle: null";
            //            }

            //            string bloodcatDownloadNumber = bloodcatDownloadUrl.Substring(2); // 112233

            //            if (bloodcatDownloadNumber == null)
            //            {
            //                return "bloodcatDownloadNumber: null";
            //            }

            //            string fileName = $"{bloodcatDownloadNumber} {beatmapTitle}.osz"; // 112233 Existence.osz

            //            // 비트맵 다운로드
            //            proceed = Proceedings.DownloadBeatmap;
            //            client.DownloadFile($"https://bloodcat.com/osu/{bloodcatDownloadUrl}", fileName); // https://bloodcat.com/osu/s/112233

            //            // 비트맵 실행
            //            proceed = Proceedings.ExecuteBeatmap;
            //            Process.Start(fileName);
            //        }
            //    }

            //    // 크롬 닫기
            //    if (Settings.Default.CloseChromeAfterCompleteDownload)
            //        KillChromeProcess();
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}

            return string.Empty;
        }

        /// <summary>
        /// 크롬 현재 Url 가져오기
        /// </summary>
        /// <returns></returns>
        string GetChromeCurrentUrl()
        {
        //    try
        //    {
        //        Process[] chromeProcess = Process.GetProcessesByName("chrome");

        //        foreach (Process chrome in chromeProcess)
        //        {
        //            if (chrome.MainWindowHandle == IntPtr.Zero)
        //                continue;

        //            AutomationElement element = AutomationElement.FromHandle(chrome.MainWindowHandle);

        //            if (element == null)
        //            {
        //                return null;
        //            }

        //            Condition conditions = new AndCondition(
        //                new PropertyCondition(AutomationElement.ProcessIdProperty, chrome.Id),
        //                new PropertyCondition(AutomationElement.IsControlElementProperty, true),
        //                new PropertyCondition(AutomationElement.IsContentElementProperty, true),
        //                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

        //            AutomationElement elementx = element.FindFirst(TreeScope.Descendants, conditions);

        //            if (elementx == null)
        //            {
        //                return null;
        //            }

        //            return ((ValuePattern)elementx.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }

            return null;
        }

        /// <summary>
        /// 크롬 끄기
        /// </summary>
        void KillChromeProcess()
        {
            try
            {
                SendKeys.SendWait("^W");
            }
            catch (Exception ex)
            {
                MessageBox.Show("KillChromeProcess Error: " + ex.Message);
            }
        }
        #endregion

        #region React
        /// <summary>
        /// 옵션 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                BackgroundImage = Image.FromFile(Settings.Default.BackgroundImageFile);

                다운로드활성화ToolStripMenuItem.Checked = Settings.Default.ActivateDownloader;
                항상위에표시ToolStripMenuItem.Checked = Settings.Default.TopMostAlways;

                TopMost = Settings.Default.TopMostAlways;

                Size = Settings.Default.WindowSize;

                Opacity = (double)Settings.Default.TransparentValue / 100;

                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Default_PropertyChanged Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 프로그램이 종료될 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 윈도우 시작과 함께 프로그램 시작
                RegistryKey? key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if(key == null)
                {
                    throw new KeyNotFoundException(nameof(key));
                }

                if (Settings.Default.AutoStartOnWindowsStart) // 등록
                    key.SetValue("OsuBeatmapDownloader", Application.ExecutablePath.ToString());
                else // 삭제
                    key.DeleteValue("OsuBeatmapDownloader", false);

                if (downloader.IsAlive)
                {
                    downloader.Join();
                }

                if (viewWorker.IsAlive)
                {
                    viewWorker.Join();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MainForm_FormClosed Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 키보드 입력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyData)
                {
                    case Keys.F5:
                        다운로드활성화ToolStripMenuItem_Click(null, null);
                        break;
                    case Keys.F6:
                        Application.Exit();
                        break;
                    case Keys.F12:
                        of.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DownloadForm_KeyDown Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 마우스 입력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadForm_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    WinApi.ReleaseCapture();
                    _ = WinApi.SendMessage(Handle, WinApi.WM_NCLBUTTONDOWN, WinApi.HT_CAPTION, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DownloadForm_MouseDown Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 새로고침
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadForm_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.DrawRectangle(new Pen(Settings.Default.ActivateDownloader ? Color.LimeGreen : Color.Gray, 8), DisplayRectangle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DownloadForm_Paint Error: " + ex.Message);
            }
        }
        #endregion

        #region 메뉴 클릭
        private void 다운로드활성화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.ActivateDownloader = 다운로드활성화ToolStripMenuItem.Checked;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("다운로드활성화ToolStripMenuItem_Click Error: " + ex.Message);
            }
        }

        private void 항상위에표시ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.TopMostAlways = 항상위에표시ToolStripMenuItem.Checked;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("항상위에표시ToolStripMenuItem_Click Error: " + ex.Message);
            }
        }

        private void 옵션ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                of.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("설정ToolStripMenuItem_Click Error: " + ex.Message);
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("종료ToolStripMenuItem_Click Error: " + ex.Message);
            }
        }

        private void makerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process.Start(General.TwitterURL);
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process.Start(General.OfficialDownloadURL);
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(General.DonateURL);
        }
        #endregion
    }
}