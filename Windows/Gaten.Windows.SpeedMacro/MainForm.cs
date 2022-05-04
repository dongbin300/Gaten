using Gaten.Net.Windows.Forms;

using System.Runtime.InteropServices;

namespace Gaten.Windows.SpeedMacro
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVNETF_MOVE = 0x0001;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_WHEEL = 0x0800;
        private const int MOUSEEVENTF_XDOWN = 0x0080;
        private const int MOUSEEVENTF_XUP = 0x0100;
        private const int MOUSEEVENTF_HWHEEL = 0x1000;
        private bool isStart = false;
        private bool fastInputMode = false;
        private bool loopMode = false;

        UserActivityHook hook = new UserActivityHook();

        MouseSettingForm msForm;
        KeyboardSettingForm kbsForm;
        TimeSettingForm tsForm;

        public string DataSubstring(string o, string s, string e, int cur)
        {
            int p = o.IndexOf(s, cur);
            p += s.Length;
            int ep = o.IndexOf(e, p);
            return o.Substring(p, ep - p);
        }

        public MainForm()
        {
            InitializeComponent();

            msForm = new MouseSettingForm(this);
            kbsForm = new KeyboardSettingForm(this);
            tsForm = new TimeSettingForm(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xPosTextBox.Text = "1000";
            yPosTextBox.Text = "800";
            WaitTextBox.Text = "200";
            tick.Start();

            Thread keyInputThread = new Thread(() => keyInputWorker(sender, e));
            keyInputThread.Start();
        }

        private void tick_Tick(object sender, EventArgs e)
        {
            CursorPositionLabel.Text = $"현재 커서: {Cursor.Position.X}, {Cursor.Position.Y}";
            if (isStart)
            {
                ProcedureListBox.BackColor = Color.Gray;
                ProcedureListBox.ForeColor = Color.White;
            }
            else
            {
                ProcedureListBox.BackColor = Color.White;
                ProcedureListBox.ForeColor = Color.Black;
            }
        }

        private new void MouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private new void MouseClick(int x, int y)
        {
            Cursor.Position = new Point(x, y);
            MouseClick();
        }

        private new void MouseDoubleClick()
        {
            MouseClick();
            Thread.Sleep(50);
            MouseClick();
        }

        private new void MouseDoubleClick(int x, int y)
        {
            MouseClick(x, y);
            Thread.Sleep(50);
            MouseClick(x, y);
        }

        private void MouseRightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        private void MouseRightClick(int x, int y)
        {
            Cursor.Position = new Point(x, y);
            MouseRightClick();
        }

        private void ClickButton_Click(object sender, EventArgs e)
        {
            ProcedureListBox.Items.Add($"Click({xPosTextBox.Text}, {yPosTextBox.Text})");
            if (eachCheckBox.Checked)
            {
                ProcedureListBox.Items.Add($"Wait({WaitTextBox.Text}ms)");
            }
            ProcedureListBox.SelectedIndex = ProcedureListBox.Items.Count - 1;
        }

        private void DoubleClickButton_Click(object sender, EventArgs e)
        {
            ProcedureListBox.Items.Add($"DClick({xPosTextBox.Text}, {yPosTextBox.Text})");
            if (eachCheckBox.Checked)
            {
                ProcedureListBox.Items.Add($"Wait({WaitTextBox.Text}ms)");
            }
            ProcedureListBox.SelectedIndex = ProcedureListBox.Items.Count - 1;
        }

        private void RightClickButton_Click(object sender, EventArgs e)
        {
            ProcedureListBox.Items.Add($"RClick({xPosTextBox.Text}, {yPosTextBox.Text})");
            if (eachCheckBox.Checked)
            {
                ProcedureListBox.Items.Add($"Wait({WaitTextBox.Text}ms)");
            }
            ProcedureListBox.SelectedIndex = ProcedureListBox.Items.Count - 1;
        }

        private void PressButton_Click(object sender, EventArgs e)
        {
            ProcedureListBox.Items.Add($"Press({KeyTextBox.Text})");
            if (eachCheckBox.Checked)
            {
                ProcedureListBox.Items.Add($"Wait({WaitTextBox.Text}ms)");
            }
            ProcedureListBox.SelectedIndex = ProcedureListBox.Items.Count - 1;
        }

        private void WaitButton_Click(object sender, EventArgs e)
        {
            ProcedureListBox.Items.Add($"Wait({WaitTextBox.Text}ms)");
            ProcedureListBox.SelectedIndex = ProcedureListBox.Items.Count - 1;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            isStart = true;
            Thread routineThread = new Thread(new ThreadStart(routine));
            routineThread.Start();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ProcedureListBox.SelectedIndex >= 0)
            {
                int idx = ProcedureListBox.SelectedIndex;
                ProcedureListBox.Items.RemoveAt(idx);
                if (ProcedureListBox.Items.Count > idx)
                {
                    ProcedureListBox.SelectedIndex = idx;
                }
                else if (idx != 0)
                {
                    ProcedureListBox.SelectedIndex = idx - 1;
                }
            }
        }

        private void NewRoutineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcedureListBox.Items.Clear();
        }

        private void EndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void speedMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void KeyTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string keyText = string.Empty;

            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl";
                else
                    keyText = "Ctrl+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.Menu)
                    keyText = "Alt";
                else
                    keyText = "Alt+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == Keys.Shift)
            {
                if (e.KeyCode == Keys.ShiftKey)
                    keyText = "Shift";
                else
                    keyText = "Shift+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Alt))
            {
                if (e.KeyCode == Keys.Menu || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Alt";
                else
                    keyText = "Ctrl+Alt+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Shift";
                else
                    keyText = "Ctrl+Shift+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Alt | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu)
                    keyText = "Alt+Shift";
                else
                    keyText = "Alt+Shift+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Alt | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Alt+Shift";
                else
                    keyText = "Ctrl+Alt+Shift+" + KeysString("" + e.KeyCode);
            }
            else
            {
                keyText = KeysString("" + e.KeyCode);
            }
            KeyTextBox.Text = keyText;
        }

        private void KeyTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string keyText = string.Empty;

            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl";
                else
                    keyText = "Ctrl+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.Menu)
                    keyText = "Alt";
                else
                    keyText = "Alt+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == Keys.Shift)
            {
                if (e.KeyCode == Keys.ShiftKey)
                    keyText = "Shift";
                else
                    keyText = "Shift+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Alt))
            {
                if (e.KeyCode == Keys.Menu || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Alt";
                else
                    keyText = "Ctrl+Alt+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Shift";
                else
                    keyText = "Ctrl+Shift+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Alt | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu)
                    keyText = "Alt+Shift";
                else
                    keyText = "Alt+Shift+" + KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Alt | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Alt+Shift";
                else
                    keyText = "Ctrl+Alt+Shift+" + KeysString("" + e.KeyCode);
            }
            else
            {
                keyText = KeysString("" + e.KeyCode);
            }
            KeyTextBox.Text = keyText;
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
                case "Up": toString = "↑"; break;
                case "Down": toString = "↓"; break;
                case "Left": toString = "←"; break;
                case "Right": toString = "→"; break;
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

        public string SendKeysString(string keyString)
        {
            string[] key = keyString.Split('+');
            string toString = string.Empty;
            for (int i = 0; i < key.Length; i++)
            {
                switch (key[i])
                {
                    case "Ctrl": toString += "^"; break;
                    case "Alt": toString += "%"; break;
                    case "Shift": toString += "+"; break;
                    case "Back": toString += "{BACKSPACE}"; break;
                    case "CapsLock": toString += "{CAPSLOCK}"; break;
                    case "Delete": toString += "{DELETE}"; break;
                    case "↓": toString += "{DOWN}"; break;
                    case "End": toString += "{END}"; break;
                    case "Enter": toString += "{ENTER}"; break;
                    case "ESC": toString += "{ESC}"; break;
                    case "Home": toString += "{HOME}"; break;
                    case "Insert": toString += "{INSERT}"; break;
                    case "←": toString += "{LEFT}"; break;
                    case "NumLock": toString += "{NUMLOCK}"; break;
                    case "PageDown": toString += "{PGDN}"; break;
                    case "PageUp": toString += "{PGUP}"; break;
                    case "PrintScreen": toString += "{PRTSC}"; break;
                    case "→": toString += "{RIGHT}"; break;
                    case "ScrollLock": toString += "{SCROLLLOCK}"; break;
                    case "Tab": toString += "{TAB}"; break;
                    case "↑": toString += "{UP}"; break;
                    case "F1": toString += "{F1}"; break;
                    case "F2": toString += "{F2}"; break;
                    case "F3": toString += "{F3}"; break;
                    case "F4": toString += "{F4}"; break;
                    case "F5": toString += "{F5}"; break;
                    case "F6": toString += "{F6}"; break;
                    case "F7": toString += "{F7}"; break;
                    case "F8": toString += "{F8}"; break;
                    case "F9": toString += "{F9}"; break;
                    case "F10": toString += "{F10}"; break;
                    case "F11": toString += "{F11}"; break;
                    case "F12": toString += "{F12}"; break;
                    case "+": toString += "{ADD}"; break;
                    case "-": toString += "{SUBTRACT}"; break;
                    case "*": toString += "{MULTIPLY}"; break;
                    case "/": toString += "{DIVIDE}"; break;
                    default:
                        if (key[i].Length == 1 && key[i][0] >= 'A' && key[i][0] <= 'Z')
                            toString += key[i].ToLower();
                        else
                            toString += key[i]; break;
                }
            }
            return toString;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs;
            StreamWriter sw;
            RoutineSaveFileDialog.Filter = "routine files (*.rt)|*.rt";
            RoutineSaveFileDialog.RestoreDirectory = true;

            if (RoutineOpenFileDialog.FileName != "")
            {
                fs = new FileStream(RoutineOpenFileDialog.FileName, FileMode.Create);
                sw = new StreamWriter(fs);
                for (int i = 0; i < ProcedureListBox.Items.Count; i++)
                {
                    sw.WriteLine(ProcedureListBox.Items[i].ToString());
                }
                sw.Flush();
                fs.Close();
            }
            else if (RoutineSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(RoutineSaveFileDialog.FileName, FileMode.Create);
                sw = new StreamWriter(fs);
                for (int i = 0; i < ProcedureListBox.Items.Count; i++)
                {
                    sw.WriteLine(ProcedureListBox.Items[i].ToString());
                }
                sw.Flush();
                fs.Close();

                // 새 루틴 저장 한번 하고 난 뒤, 다시 재저장할 때 바로 되게끔 하기 위해
                RoutineOpenFileDialog.FileName = RoutineSaveFileDialog.FileName;
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs;
            StreamReader sr;
            RoutineOpenFileDialog.InitialDirectory = "c:\\";
            RoutineOpenFileDialog.Filter = "routine files (*.rt)|*.rt";
            RoutineOpenFileDialog.RestoreDirectory = true;

            if (RoutineOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(RoutineOpenFileDialog.FileName, FileMode.Open);
                sr = new StreamReader(fs);
                for (int i = 0; sr.Peek() >= 0; i++)
                {
                    ProcedureListBox.Items.Add(sr.ReadLine());
                }
                sr.Close();
                fs.Close();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs;
            StreamWriter sw;
            RoutineSaveFileDialog.Filter = "routine files (*.rt)|*.rt";
            RoutineSaveFileDialog.RestoreDirectory = true;

            if (RoutineSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(RoutineSaveFileDialog.FileName, FileMode.Create);
                sw = new StreamWriter(fs);
                for (int i = 0; i < ProcedureListBox.Items.Count; i++)
                {
                    sw.WriteLine(ProcedureListBox.Items[i].ToString());
                }
                sw.Flush();
                fs.Close();
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            FileStream fs = new FileStream(files[0], FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            for (int i = 0; sr.Peek() >= 0; i++)
            {
                ProcedureListBox.Items.Add(sr.ReadLine());
            }
            sr.Close();
            fs.Close();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Stop();
            //isStart = false;
        }

        delegate void DelegateListBoxSelect(ListBox lb, int index);
        delegate void DelegateStop();

        private void ListBoxSelect(ListBox lb, int index)
        {
            if (lb.InvokeRequired)
            {
                DelegateListBoxSelect del = new DelegateListBoxSelect(ListBoxSelect);
                lb.Invoke(del, new object[] { lb, index });
            }
            else
            {
                lb.SelectedIndex = index;
            }
        }

        private void Stop()
        {
            if (InvokeRequired)
            {
                DelegateStop del = new DelegateStop(Stop);
                Invoke(del);
            }
            else
            {
                isStart = false;
            }
        }

        void routine()
        {
            int x, y;

            while (isStart)
            {
                for (int i = 0; i < ProcedureListBox.Items.Count; i++)
                {
                    if (isStart)
                    {
                        ListBoxSelect(ProcedureListBox, i);
                        string str = ProcedureListBox.Items[i].ToString();
                        string command = str.Split('(')[0];
                        switch (command)
                        {
                            case "Click":
                                x = int.Parse(DataSubstring(str, "(", ",", 0));
                                y = int.Parse(DataSubstring(str, ", ", ")", 0));
                                MouseClick(x, y);
                                break;
                            case "DClick":
                                x = int.Parse(DataSubstring(str, "(", ",", 0));
                                y = int.Parse(DataSubstring(str, ", ", ")", 0));
                                MouseDoubleClick(x, y);
                                break;
                            case "RClick":
                                x = int.Parse(DataSubstring(str, "(", ",", 0));
                                y = int.Parse(DataSubstring(str, ", ", ")", 0));
                                MouseRightClick(x, y);
                                break;
                            case "Press":
                                SendKeys.SendWait(SendKeysString(DataSubstring(str, "(", ")", 0)));
                                break;
                            case "Wait":
                                Thread.Sleep(int.Parse(DataSubstring(str, "(", "ms", 0)));
                                break;
                        }
                    }
                }
                if (!loopMode)
                    isStart = false;
            }
        }

        void keyInputWorker(object sender, EventArgs e)
        {
            // background key input
            hook.KeyUp += (start, end) =>
            {
                // 매크로를 실행 중이지 않을 때만 키보드 입력 받음
                if (!isStart)
                {
                    // 빠른 입력 모드
                    if (fastInputMode)
                    {
                        KeyTextBox_PreviewKeyDown(sender, end);
                        PressButton_Click(sender, e);
                    }
                    // 일반 입력 모드(단축키)
                    else
                    {
                        switch (end.KeyCode)
                        {
                            case Keys.F1:
                                helpToolStripMenuItem_Click(sender, e);
                                break;
                            case Keys.F2:
                                xPosTextBox.Text = "" + Cursor.Position.X;
                                yPosTextBox.Text = "" + Cursor.Position.Y;
                                ClickButton_Click(sender, e);
                                break;
                            case Keys.F3:
                                xPosTextBox.Text = "" + Cursor.Position.X;
                                yPosTextBox.Text = "" + Cursor.Position.Y;
                                DoubleClickButton_Click(sender, e);
                                break;
                            case Keys.F4:
                                xPosTextBox.Text = "" + Cursor.Position.X;
                                yPosTextBox.Text = "" + Cursor.Position.Y;
                                RightClickButton_Click(sender, e);
                                break;
                            case Keys.F5:
                                WaitButton_Click(sender, e);
                                break;
                            case Keys.F7:
                                StartButton_Click(sender, e);
                                break;
                            case Keys.F8:
                                StopButton_Click(sender, e);
                                break;
                            case Keys.Delete:
                                DeleteButton_Click(sender, e);
                                break;
                        }
                    }
                }
            };
        }

        private void ProcedureListBox_DoubleClick(object sender, EventArgs e)
        {
            switch (ProcedureListBox.Items[ProcedureListBox.SelectedIndex].ToString().Split('(')[0])
            {
                case "Click":
                case "DClick":
                case "RClick":
                    msForm.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
                    msForm.ShowDialog();
                    break;
                case "Press":
                    kbsForm.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
                    kbsForm.ShowDialog();
                    break;
                case "Wait":
                    tsForm.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
                    tsForm.ShowDialog();
                    break;
            }

        }

        private void FastInputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fastInputMode = fastInputCheckBox.Checked;
        }

        private void LoopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            loopMode = loopCheckBox.Checked;
        }
    }
}
