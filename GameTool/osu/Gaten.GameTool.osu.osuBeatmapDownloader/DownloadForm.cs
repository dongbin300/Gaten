using Gaten.Net.IO;
using Gaten.Net.Windows;
using Gaten.Net.Windows.Forms;

using Microsoft.Win32;

using System.Diagnostics;

namespace Gaten.GameTool.osu.osuBeatmapDownloader
{
    /*
     * v2.3.0 Update Lists
     * �巡���ؼ� â�� �̵���ų �� �ִ� ��� �߰�
     * �ּ�ȭ ��� ����
     * Ʈ���� ������ ����
     * ȭ�� ���̺� ����(��Ʈ�� �ٿ�ε� ���� ���� ȭ�鿡 ���� ��Ȳ�� ��)
     * 
     * ���콺 ������Ŭ������ �޴� ���� ��� �߰�
     * ����Ű �߰�
     * �ٿ�ε� Ȱ��ȭ/��Ȱ��ȭ ��� �߰�
     * �׻� ���� ǥ�� ���� �߰�
     * ���� ��� �߰�
     * ��� �̹��� ���� �߰�
     * â ũ�� ���� �߰�(�ּ� 200*200)
     * �ɼ� �ʱ�ȭ ��� �߰�
     * �ɼ� ���� ���� ����
     * 
     * ����ƮURL ����
     * ��Ʈ�� �ٿ�ε� ���� ����
     * �ٿ�ε� ���� ���� ����
     * ���α׷� ������ ����
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

                // �޴�
                ContextMenuStrip = menu;

                // �۾�ǥ���� ������ ����
                ShowInTaskbar = false;

                // �׻� ���� ǥ��
                TopMost = true;

                // �� ����ȭ
                //BackColor = Color.LimeGreen;
                //TransparencyKey = Color.LimeGreen;

                // ���� ǥ��
                versionToolStripMenuItem.Text = $"v{General.Version}";

                // â ũ��
                Size = Settings.Default.WindowSize;

                // ��� �̹���
                BackgroundImage = Image.FromFile(Settings.Default.BackgroundImageFile);

                // �޴� üũ ����
                �ٿ�ε�Ȱ��ȭToolStripMenuItem.Checked = Settings.Default.ActivateDownloader;
                �׻�����ǥ��ToolStripMenuItem.Checked = Settings.Default.TopMostAlways;

                // �ٿ�ε� ��� �ҷ�����
                string result = LoadDownloadedLists();
                if (result != string.Empty)
                {
                    MessageBox.Show("LoadDownloadedLists Error: " + result);
                }

                // ������ ����
                downloader = new Thread(new ThreadStart(Work));
                downloader.Start();

                viewWorker = new Thread(new ThreadStart(Proceed));
                viewWorker.Start();

                // ���
                proceed = Proceedings.Wait;

                // ������Ʈ Ȯ��
                if (Settings.Default.ConfirmUpdate)
                {
                    string result2 = ConfirmUpdate();

                    if (result2 != string.Empty)
                    {
                        MessageBox.Show("ConfirmUpdate Error: " + result2);
                    }
                }

                // �ɼ� ���� �̺�Ʈ
                Settings.Default.PropertyChanged += Default_PropertyChanged;

                // ó�� ��Ȳ �� �⺻ ����
                proceedLabel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DownloadForm Error: " + ex.Message);
            }
        }

        #region Main Work
        /// <summary>
        /// ������Ʈ�� �ִ��� Ȯ��
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
        //                    if (MessageBox.Show("�� ������ ���Խ��ϴ�. ��ġ�Ͻðڽ��ϱ�?", "��ġ", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
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
        /// �ٿ�޾Ҵ� ��Ʈ�� ���� ����� ����
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
        /// �ٿ�޾Ҵ� ��Ʈ�� ���� ����� �ε�
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
        /// ���� ���� ������
        /// </summary>
        void Proceed()
        {
            while (true)
            {
                switch (proceed)
                {
                    case Proceedings.Wait:
                        Delegater.TextSet(proceedLabel, "���");
                        break;
                    case Proceedings.AnalyzeChromeUrl:
                        Delegater.TextSet(proceedLabel, "ũ�� URL �м���..");
                        break;
                    case Proceedings.AnalyzeHTMLSource:
                        Delegater.TextSet(proceedLabel, "HTML�ҽ� �м���..");
                        break;
                    case Proceedings.DownloadBeatmap:
                        Delegater.TextSet(proceedLabel, "��Ʈ�� �ٿ�ε���..");
                        break;
                    case Proceedings.ExecuteBeatmap:
                        Delegater.TextSet(proceedLabel, "��Ʈ�� ������..");
                        break;
                }

                // ��� ���� �ƴϸ� ���� ��Ȳ�� ������
                Delegater.VisibleSet(proceedLabel, proceed != Proceedings.Wait);

                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// ��Ʈ�� �ٿ�ε� ������
        /// </summary>
        void Work()
        {
            while (true)
            {
                try
                {
                    if (!isRunning && Settings.Default.ActivateDownloader)
                    {
                        // ���� ũ�� URL
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
        /// ��Ʈ�� �ٿ�ε� ��ü���� ��ƾ
        /// ũ��URL�� �м��ؼ� ��Ĺ���� �ٿ�ε� �� ����
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string ParseUrl(string url)
        {
            try
            {
                // ũ�� URL �м�
                proceed = Proceedings.AnalyzeChromeUrl;
                string[] urlData = url.Split('/');
                if (urlData == null)
                {
                    return "urlData: null";
                }

                // ��Ʈ�� ��ȣ ���ڿ�
                string beatmapNumberString = urlData[urlData.Length - 1];

                // �ٿ�޾Ҵ� ��� �ҷ�����
                string result = LoadDownloadedLists();
                if (result != string.Empty)
                {
                    MessageBox.Show("LoadDownloadedLists Error: " + result);
                }

                // �̹� �ٿ�޾Ҵ� ������ Ȯ��
                if (downloadedLists.Find(d => d.Equals(beatmapNumberString)) != null)
                {
                    proceed = Proceedings.Wait;
                    return string.Empty;
                }

                // ��Ʈ�� �ٿ�ε� �� ����
                string result2 = Download(beatmapNumberString);
                if (result2 != string.Empty && result2 != "������")
                {
                    MessageBox.Show("Download Error: " + result2);
                }

                // �ٿ�ε� ��� �����ϱ�
                string result3 = SaveDownloadedLists(beatmapNumberString);
                if (result3 != string.Empty)
                {
                    MessageBox.Show("SaveDownloadedLists Error: " + result3);
                }

                // ���
                proceed = Proceedings.Wait;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }

        /// <summary>
        /// ��Ʈ�� �ٿ�ε�
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

            //    // HTML �ҽ� �м�
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
            //            return "������";
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

            //            // ��Ʈ�� �ٿ�ε�
            //            proceed = Proceedings.DownloadBeatmap;
            //            client.DownloadFile($"https://bloodcat.com/osu/{bloodcatDownloadUrl}", fileName); // https://bloodcat.com/osu/s/112233

            //            // ��Ʈ�� ����
            //            proceed = Proceedings.ExecuteBeatmap;
            //            Process.Start(fileName);
            //        }
            //    }

            //    // ũ�� �ݱ�
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
        /// ũ�� ���� Url ��������
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
        /// ũ�� ����
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
        /// �ɼ� ���� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                BackgroundImage = Image.FromFile(Settings.Default.BackgroundImageFile);

                �ٿ�ε�Ȱ��ȭToolStripMenuItem.Checked = Settings.Default.ActivateDownloader;
                �׻�����ǥ��ToolStripMenuItem.Checked = Settings.Default.TopMostAlways;

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
        /// ���α׷��� ����� ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // ������ ���۰� �Բ� ���α׷� ����
                RegistryKey? key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if(key == null)
                {
                    throw new KeyNotFoundException(nameof(key));
                }

                if (Settings.Default.AutoStartOnWindowsStart) // ���
                    key.SetValue("OsuBeatmapDownloader", Application.ExecutablePath.ToString());
                else // ����
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
        /// Ű���� �Է�
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
                        �ٿ�ε�Ȱ��ȭToolStripMenuItem_Click(null, null);
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
        /// ���콺 �Է�
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
        /// ���ΰ�ħ
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

        #region �޴� Ŭ��
        private void �ٿ�ε�Ȱ��ȭToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.ActivateDownloader = �ٿ�ε�Ȱ��ȭToolStripMenuItem.Checked;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�ٿ�ε�Ȱ��ȭToolStripMenuItem_Click Error: " + ex.Message);
            }
        }

        private void �׻�����ǥ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.TopMostAlways = �׻�����ǥ��ToolStripMenuItem.Checked;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�׻�����ǥ��ToolStripMenuItem_Click Error: " + ex.Message);
            }
        }

        private void �ɼ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                of.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ToolStripMenuItem_Click Error: " + ex.Message);
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ToolStripMenuItem_Click Error: " + ex.Message);
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