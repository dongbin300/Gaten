namespace Gaten.Audio.VirtualKeyboard
{
    public partial class MainForm : Form
    {
        private readonly Keyboard keyboard = new();
        private const int BlackHeight = 120;

        public MainForm()
        {
            InitializeComponent();
            ChordLabel.Text = "";
            keyLabel.Text = "Key: " + keyboard.Tone[keyboard.Key];
        }

        private void KeyboardBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new(Brushes.Black, 1);
            Brush brush = Brushes.Black;
            Brush pressKeyBrush = new SolidBrush(Color.FromArgb(181, 178, 255));

            // 흰 건반 그리기
            g.DrawRectangle(pen, new Rectangle(0, 0, keyboardBox.Width - 1, keyboardBox.Height - 1));
            g.DrawLine(pen, new Point(keyboardBox.Width / 7 * 1, 0), new Point(keyboardBox.Width / 7 * 1, keyboardBox.Height));
            g.DrawLine(pen, new Point(keyboardBox.Width / 7 * 2, 0), new Point(keyboardBox.Width / 7 * 2, keyboardBox.Height));
            g.DrawLine(pen, new Point(keyboardBox.Width / 7 * 3, 0), new Point(keyboardBox.Width / 7 * 3, keyboardBox.Height));
            g.DrawLine(pen, new Point(keyboardBox.Width / 7 * 4, 0), new Point(keyboardBox.Width / 7 * 4, keyboardBox.Height));
            g.DrawLine(pen, new Point(keyboardBox.Width / 7 * 5, 0), new Point(keyboardBox.Width / 7 * 5, keyboardBox.Height));
            g.DrawLine(pen, new Point(keyboardBox.Width / 7 * 6, 0), new Point(keyboardBox.Width / 7 * 6, keyboardBox.Height));
            if (keyboard.Press[0])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(0, 0, (keyboardBox.Width / 7) - 1, keyboardBox.Height - 1));
            }

            if (keyboard.Press[2])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 7, 0, (keyboardBox.Width / 7) - 1, keyboardBox.Height - 1));
            }

            if (keyboard.Press[4])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 7 * 2, 0, (keyboardBox.Width / 7) - 1, keyboardBox.Height - 1));
            }

            if (keyboard.Press[5])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 7 * 3, 0, (keyboardBox.Width / 7) - 1, keyboardBox.Height - 1));
            }

            if (keyboard.Press[7])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 7 * 4, 0, (keyboardBox.Width / 7) - 1, keyboardBox.Height - 1));
            }

            if (keyboard.Press[9])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 7 * 5, 0, (keyboardBox.Width / 7) - 1, keyboardBox.Height - 1));
            }

            if (keyboard.Press[11])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 7 * 6, 0, keyboardBox.Width - 1, keyboardBox.Height - 1));
            }

            // 검은 건반 그리기
            g.FillRectangle(brush, new Rectangle(keyboardBox.Width / 12 * 1, 0, keyboardBox.Width / 12, BlackHeight));
            g.FillRectangle(brush, new Rectangle(keyboardBox.Width / 12 * 3, 0, keyboardBox.Width / 12, BlackHeight));
            g.FillRectangle(brush, new Rectangle(keyboardBox.Width / 12 * 6, 0, keyboardBox.Width / 12, BlackHeight));
            g.FillRectangle(brush, new Rectangle(keyboardBox.Width / 12 * 8, 0, keyboardBox.Width / 12, BlackHeight));
            g.FillRectangle(brush, new Rectangle(keyboardBox.Width / 12 * 10, 0, keyboardBox.Width / 12, BlackHeight));
            if (keyboard.Press[1])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 12, 0, (keyboardBox.Width / 12) - 1, BlackHeight - 1));
            }

            if (keyboard.Press[3])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 12 * 3, 0, (keyboardBox.Width / 12) - 1, BlackHeight - 1));
            }

            if (keyboard.Press[6])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 12 * 6, 0, (keyboardBox.Width / 12) - 1, BlackHeight - 1));
            }

            if (keyboard.Press[8])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 12 * 8, 0, (keyboardBox.Width / 12) - 1, BlackHeight - 1));
            }

            if (keyboard.Press[10])
            {
                g.FillRectangle(pressKeyBrush, new Rectangle(keyboardBox.Width / 12 * 10, 0, (keyboardBox.Width / 12) - 1, BlackHeight - 1));
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z: PressKey(0); break;
                case Keys.S: PressKey(1); break;
                case Keys.X: PressKey(2); break;
                case Keys.D: PressKey(3); break;
                case Keys.C: PressKey(4); break;
                case Keys.V: PressKey(5); break;
                case Keys.G: PressKey(6); break;
                case Keys.B: PressKey(7); break;
                case Keys.H: PressKey(8); break;
                case Keys.N: PressKey(9); break;
                case Keys.J: PressKey(10); break;
                case Keys.M: PressKey(11); break;
                case Keys.Up: 증가ToolStripMenuItem_Click(sender, e); break;
                case Keys.Down: 감소ToolStripMenuItem_Click(sender, e); break;
            }
        }

        private void PressKey(int index)
        {
            ChordLabel.Text = keyboard.PressKey(index);

            keyboardBox.Refresh();
        }

        private void KeyboardBox_MouseDown(object sender, MouseEventArgs e)
        {
            double blackWidth = keyboardBox.Width / 12.0; // 검은 건반의 폭
            double whiteWidth = keyboardBox.Width / 7.0; // 흰 건반의 폭
            int[] blackPosition = { 1, 3, 6, 8, 10 }; // 키보드에서 검은 건반의 인덱스
            int[] whitePosition = { 0, 2, 4, 5, 7, 9, 11 }; // 키보드에서 흰 건반의 인덱스

            int blackIndex = (int)(e.X / blackWidth); // 검은 건반 입장에서 클릭한 좌표의 인덱스
            int whiteIndex = (int)(e.X / whiteWidth); // 흰 건반 입장에서 클릭한 좌표의 인덱스

            // 검은 건반 클릭
            ChordLabel.Text = e.Y < BlackHeight && blackPosition.Contains(blackIndex)
                ? keyboard.PressKey(blackIndex)
                : keyboard.PressKey(whitePosition[whiteIndex]);

            keyboardBox.Refresh();
        }

        private void Into_Click(object sender, EventArgs e)
        {
            int[] sTonics = { 7, 2, 9, 4, 11, 6 };
            int[] pTonics = { 5, 10, 3, 8, 1, 6 };

            if (sender is not ToolStripMenuItem clickedItem)
            {
                return;
            }

            Reset();
            if (clickedItem.Name == "into0")
            {
                keyboard.SetWithTonic(0);
            }
            else
            {
                switch (clickedItem.Name[4])
                {
                    case 'S':
                        keyboard.SetWithTonic(sTonics[int.Parse(clickedItem.Name[5].ToString()) - 1]);
                        break;
                    case 'P':
                        keyboard.SetWithTonic(pTonics[int.Parse(clickedItem.Name[5].ToString()) - 1]);
                        break;
                }
            }

            keyboardBox.Refresh();
        }

        private void Harm_Click(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem clickedItem)
            {
                return;
            }

            Reset();
            ChordLabel.Text = keyboard.SetWithHarmony(int.Parse(clickedItem.Name.Replace("harm", "")) - 1);

            keyboardBox.Refresh();
        }

        private void Key_Click(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem clickedItem)
            {
                return;
            }

            keyLabel.Text = "Key: " + keyboard.SetKey(clickedItem.Name.Replace("key", "").Replace("S", "#"));

            keyboardBox.Refresh();
        }

        private void Reset()
        {
            keyboard.Clear();
            ChordLabel.Text = "";
            keyboardBox.Refresh();
        }

        private void 리셋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void 증가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keyLabel.Text = "Key: " + keyboard.AscendKey();
            ChordLabel.Text = keyboard.ConfirmChord();

            keyboardBox.Refresh();
        }

        private void 감소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keyLabel.Text = "Key: " + keyboard.DescendKey();
            ChordLabel.Text = keyboard.ConfirmChord();

            keyboardBox.Refresh();
        }
    }
}