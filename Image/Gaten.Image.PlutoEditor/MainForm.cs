using Gaten.Image.PlutoEditor.Panel;
using Gaten.Net.Windows.Forms;
using Gaten.Net.Image;

namespace Gaten.Image.PlutoEditor
{
    public partial class MainForm : Form
    {
        /*
         * �ñ����� ��ǥ:
         * ������Ʈ�� �����̴� ���� ����
         * 
         * �ʿ�:
         * 1. ������Ʈ �׸���
         * 2. ������(���, �ð������� ���)
         * 3. ������Ʈ �ִϸ��̼�
         * 4. �׽�Ʈ �ܼ�
         * 5. ������ ���Ϸ� ����(.avi)
         * 
         * hierarchy
         * ����(video)-�ִϸ��̼�(animation)-���(scene)-�г�(panel)-������Ʈ(object)-�ȼ�(pixel)
         * 
         * 0. ���� (960*540)
         * 
         * 1. ������Ʈ �׸���
         * 1-1. ������Ʈ(Object)
         * �ϳ��� ������Ʈ = �ϳ��� Panel
         * 1-2. �׸���(Draw)
         * ��, ��
         * 
         * 2. ������
         * 2-1. 
         * 
         * 
         * TODO:
         * ���� �г� ���(�г� ���� �� �̵� ����)(6�ð�)
         */

        public enum Tools { None, Pixel, Line, Move }
        public Tools SelectedTool = Tools.None;
        public Color SelectedColor = Color.LimeGreen;
        public PPanel mainPanel;
        public List<PPanel> panels = new List<PPanel>();
        public TransparentPanel gridPanel = new TransparentPanel();
        public TimeMap timeMap = new TimeMap(10);
        int currentFrameNumber = 1;
        int maxFrameCount = 3600;

        UserActivityHook hook;
        Thread inputWorker;
        public bool paintMode;

        PPanel moveButton = new PPanel();
        PPanel pixelButton = new PPanel();
        PPanel lineButton = new PPanel();
        PPanel colorButton = new PPanel();

        // scenePanel ���� ����
        Point pencilPosition;

        public MainForm()
        {
            InitializeComponent();
            InitToolBox();
            InitPaint();
            InitThread();
            InitEvent();

            ������ToolStripMenuItem_Click(null, null);
        }

        void InitToolBox()
        {
            pixelButton.Location = new Point(0, 0);
            pixelButton.BackgroundImage = "resource/image/dot.png".Resize(30);
            pixelButton.Size = new Size(30, 30);
            pixelButton.Text = "";
            pixelButton.Click += PixelButton_Click;
            toolBoxPanel.Controls.Add(pixelButton);

            //lineButton.Location = new Point(30, 0);
            //lineButton.BackgroundImage = ImageHandle.Resize("resource/image/line.png", 30);
            //lineButton.Size = new Size(30, 30);
            //lineButton.Text = "";
            //lineButton.Click += LineButton_Click;
            //toolBoxPanel.Controls.Add(lineButton);

            colorButton.Location = new Point(60, 0);
            colorButton.BackColor = SelectedColor;
            colorButton.Size = new Size(30, 30);
            colorButton.Text = "";
            colorButton.Click += ColorButton_Click;
            toolBoxPanel.Controls.Add(colorButton);

            //moveButton.Location = new Point(0, 30);
            //moveButton.BackgroundImage = ImageHandle.Resize("resource/image/move.png", 30);
            //moveButton.Size = new Size(30, 30);
            //moveButton.Text = "";
            //moveButton.Click += MoveButton_Click;
            //toolBoxPanel.Controls.Add(moveButton);
        }

        void InitPaint()
        {
            timeMapPanel.Refresh();
            toolBoxPanel.Refresh();
        }

        void InitThread()
        {
            hook = new UserActivityHook();
            inputWorker = new Thread(new ThreadStart(Input));
            inputWorker.Start();
        }

        void InitEvent()
        {
        }

        void Input()
        {
            try
            {
                // ���콺 ��
                hook.MouseWheel += (sender, e) =>
                {
                    // �� ���� ���� ��ǥ ���ϱ�
                    Point currentPosition = this.GetCurrentPositionOnForm(e.Location);

                    // ���� Ŀ���� ��ġ���� ��Ʈ�� ã��
                    List<Control> currentControls = this.GetControlsFromCurrentPosition(currentPosition);

                    if (e.Delta != 0)
                    {
                        if (currentControls.Contains(scenePanel) && !currentControls.Contains(menuStrip))
                        {
                            // ���� ���� �ø��� Ȯ��, �Ʒ��� ������ ���
                            float scale = e.Delta < 0 ? U.SetScale(Math.Max(2, U.Scale - 1)) : U.SetScale(Math.Min(20, U.Scale + 1));

                            // ������ ǥ��
                            scaleLabel.Text = U.Scale.ToString();
                            ScenePanelView(scale);
                        }
                        else if (currentControls.Contains(timeMapPanel))
                        {
                            if (e.Delta < 0)
                                timeMap.Scale = Math.Max(2, timeMap.Scale - 2);
                            else
                                timeMap.Scale = Math.Min(100, timeMap.Scale + 2);

                            timeMapPanel.Refresh();
                        }
                        else if (currentControls.Contains(panelBoxPanel))
                        {

                        }
                    }
                };

                // ���콺 �ٿ�
                hook.MouseDown += (sender, e) =>
                {
                    // �� ���� ���� ��ǥ ���ϱ�
                    Point currentPosition = this.GetCurrentPositionOnForm(e.Location);

                    // ���� Ŀ���� ��ġ���� ��Ʈ�� ã��
                    List<Control> currentControls = this.GetControlsFromCurrentPosition(currentPosition);
                    string name = string.Empty;
                    foreach (Control control in currentControls)
                        name += control.Name;

                    currentLabel.Text = $"[{name}] {currentPosition.X}, {currentPosition.Y}";

                    switch (e.Button)
                    {
                        case MouseButtons.None:
                            break;
                        case MouseButtons.Left:
                            if (currentControls.Contains(scenePanel))
                            {
                                switch (SelectedTool)
                                {
                                    case Tools.None:
                                        break;
                                    case Tools.Pixel:
                                        UserSetting.SelectedPanel.SetCoordinate(
                                       U.C(currentPosition.X) - UserSetting.SelectedPanel.CX,
                                       U.C(currentPosition.Y - this.GetMenuHeight()) - UserSetting.SelectedPanel.CY,
                                       SelectedColor);
                                        //testLabel.Text = $"{U.C(currentPosition.X) - UserSetting.SelectedPanel.CX}, {U.C(currentPosition.Y - WindowLocation.MenuHeight) - UserSetting.SelectedPanel.CY}";
                                        paintMode = true;
                                        break;
                                    case Tools.Line:
                                        break;
                                }
                            }
                            break;
                        case MouseButtons.Right:
                            break;
                    }
                };

                // ���콺 ��
                hook.MouseUp += (sender, e) =>
                {
                    // �� ���� ���� ��ǥ ���ϱ�
                    Point currentPosition = this.GetCurrentPositionOnForm(e.Location);

                    // ���� Ŀ���� ��ġ���� ��Ʈ�� ã��
                    List<Control> currentControls = this.GetControlsFromCurrentPosition(currentPosition);
                    string name = string.Empty;
                    foreach (Control control in currentControls)
                        name += control.Name;

                    currentLabel.Text = $"[{name}] {currentPosition.X}, {currentPosition.Y}";

                    switch (e.Button)
                    {
                        case MouseButtons.None:
                            break;
                        case MouseButtons.Left:
                            if (currentControls.Contains(scenePanel) && !currentControls.Contains(menuStrip))
                            {
                                switch (SelectedTool)
                                {
                                    case Tools.None:
                                        break;
                                    case Tools.Pixel:
                                        paintMode = false;
                                        break;
                                    case Tools.Line:
                                        break;
                                }
                            }
                            break;
                        case MouseButtons.Right:
                            break;
                    }
                };

                // ���콺 ����
                hook.MouseMove += (sender, e) =>
                {
                    // �� ���� ���� ��ǥ ���ϱ�
                    Point currentPosition = this.GetCurrentPositionOnForm(e.Location);

                    // ���� Ŀ���� ��ġ���� ��Ʈ�� ã��
                    List<Control> currentControls = this.GetControlsFromCurrentPosition(currentPosition);
                    string name = string.Empty;
                    foreach (Control control in currentControls)
                        name += control.Name;

                    currentLabel.Text = $"[{name}] {currentPosition.X}, {currentPosition.Y}";

                    if (currentControls.Contains(scenePanel) && !currentControls.Contains(menuStrip))
                    {
                        switch (SelectedTool)
                        {
                            case Tools.None:
                                break;
                            case Tools.Pixel:
                                if (paintMode)
                                {
                                    UserSetting.SelectedPanel.SetCoordinate(
                                        U.C(currentPosition.X) - UserSetting.SelectedPanel.CX,
                                        U.C(currentPosition.Y - this.GetMenuHeight()) - UserSetting.SelectedPanel.CY,
                                        SelectedColor);
                                    //testLabel.Text = $"{U.C(currentPosition.X) - UserSetting.SelectedPanel.CX}, {U.C(currentPosition.Y - WindowLocation.MenuHeight) - UserSetting.SelectedPanel.CY}";
                                }
                                break;
                            case Tools.Line:
                                break;
                        }
                    }
                };

                //Ű���� ��ŷ
                hook.KeyUp += (sender, e) =>
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            UserSetting.SelectedPanel.Move(Direction.Up);
                            UserSetting.SelectedPanel.RePaint(UserSetting.Grid, true);
                            break;
                        case Keys.Down:
                            UserSetting.SelectedPanel.Move(Direction.Down);
                            UserSetting.SelectedPanel.RePaint(UserSetting.Grid, true);
                            break;
                        case Keys.Left:
                            UserSetting.SelectedPanel.Move(Direction.Left);
                            UserSetting.SelectedPanel.RePaint(UserSetting.Grid, true);
                            break;
                        case Keys.Right:
                            UserSetting.SelectedPanel.Move(Direction.Right);
                            UserSetting.SelectedPanel.RePaint(UserSetting.Grid, true);
                            break;
                        case Keys.N:
                            ������ToolStripMenuItem.PerformClick();
                            break;
                    }
                };
            }
            catch
            {

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //������ToolStripMenuItem_Click(sender, e);
            //AddPanelButton_Click(sender, e);
            //panelListBox.SelectedIndex = 0;
            SelectedTool = Tools.Pixel;
            //����ToolStripMenuItem.PerformClick();
            //PanelTest();
        }

        void PanelTest()
        {
            PPanel panel = new PPanel($"�г� 1", 2, 2, 3, 3, 1);
            panel.SetCoordinate(0, 0, Color.Red);
            panel.SetCoordinate(1, 1, Color.Red);
            panels.Add(panel);

            panel = new PPanel($"�г� 2", 7, 5, 5, 5, 2);
            panel.SetCoordinate(0, 0, Color.Green);
            panel.SetCoordinate(1, 0, Color.Green);
            panel.SetCoordinate(1, 1, Color.Green);
            panel.SetCoordinate(0, 1, Color.Green);
            panels.Add(panel);

            ScenePanelView(1.0f);
        }

        private void TimeMapPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Pen pen = new Pen(Brushes.Black, 1);

                g.DrawLine(pen, new Point(0, 1), new Point(1280, 1));
                g.DrawLine(pen, new Point(0, 20), new Point(1280, 20));

                for (int i = 1; i <= maxFrameCount; i += 100 / timeMap.Scale)
                {
                    g.DrawString(i.ToString(), new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, new Point((i - 1) * timeMap.Scale, 5));
                }
                g.DrawLine(pen, new Point((currentFrameNumber - 1) * timeMap.Scale, 0), new Point((currentFrameNumber - 1) * timeMap.Scale, timeMapPanel.Height));
            }
        }

        private void TimeMapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    currentFrameNumber = e.X / timeMap.Scale + 1;
                    currentFrameLabel.Text = $"{currentFrameNumber}/{maxFrameCount}";
                    timeMapPanel.Refresh();
                    break;
                case MouseButtons.Right:
                    break;
            }
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // ���� �г� �߰�
                mainPanel = new PPanel("���� �г�", 0, 0, 100, 60, 0);
                mainPanel.MouseMove += MainPanel_MouseMove;
                UserSetting.SelectedPanel = mainPanel;

                ScenePanelView(1.0f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            pencilPosition = e.Location;
        }

        private void �ܼ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Pluto.exe", ConsoleArgument.SaveTempScene(mainPanel.IntegrateImage(panels)));
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            SelectedTool = Tools.Move;
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            penColorDialog.ShowDialog();
            SelectedColor = penColorDialog.Color;
            colorButton.BackColor = SelectedColor;
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            SelectedTool = Tools.Line;
        }

        private void PixelButton_Click(object sender, EventArgs e)
        {
            SelectedTool = Tools.Pixel;
        }

        private void AddPanelButton_Click(object sender, EventArgs e)
        {
            PPanel panel = new PPanel($"�г� {panels.Count + 1}", 1, 1, 10, 10, panels.Count);
            panels.Add(panel);

            ScenePanelView(1.0f);
        }

        /// <summary>
        /// Scene�г� �ٽ� �׸���
        /// </summary>
        void ScenePanelView(float scale)
        {
            Dictionary<int, int> iDict = new Dictionary<int, int>();
            List<int> zIndexes = new List<int>();
            int i = 0;

            scenePanel.Controls.Clear();

            // ���� �г� ������Ʈ
            mainPanel.ReCalculate();
            scenePanel.Controls.Add(mainPanel);
            mainPanel.RePaint(����ToolStripMenuItem.Checked ? true : false);

            // �Ϲ� �г� ������Ʈ
            // �г� �߰��� Z-index�� ���� �ͺ��� �߰��ؾ���
            // Z-index�� Ŭ���� ���� �߰��ǹǷ� ���� ���� ǥ�õȴ�
            foreach (PPanel panel in panels)
            {
                // �г� �ȼ� ����
                panel.ReCalculate();

                // �г� ��Ʈ�� �׸���
                panel.RePaint(UserSetting.Grid);

                // ����Ʈ�� Z-index �߰�
                iDict.Add(panel.Z, i++);
                zIndexes.Add(panel.Z);
            }

            // Z-index�� �������� ����
            zIndexes.Sort((a, b) => -1 * a.CompareTo(b));

            // �г��� �����гο� �߰�
            foreach (int z in zIndexes)
            {
                mainPanel.Controls.Add(panels[iDict[z]]);
            }

            // �������� �г� ǥ��
            UserSetting.SelectedPanel.RePaint(UserSetting.Grid, true);

            // �гιڽ� ������Ʈ
            PanelBoxView();
        }

        void PanelBoxView()
        {
            int i = 0;

            panelBoxPanel.Controls.Clear();

            PPanel miniPanel = new PPanel();
            miniPanel.Name = mainPanel.Name;
            miniPanel.Location = new Point(55 * i++, 0);
            miniPanel.Size = new Size(50, 50);
            miniPanel.MouseClick += MiniPanel_MouseClick;

            Bitmap miniBitmap = new Bitmap(mainPanel.CW, mainPanel.CH);
            LockBitmap lockBitmap = new LockBitmap(miniBitmap);
            lockBitmap.LockBits();
            for (int j = 0; j < mainPanel.CoordinateColors.Length; j++)
            {
                lockBitmap.SetPixel(j / mainPanel.CH, j % mainPanel.CH, mainPanel.CoordinateColors[j]);
            }
            lockBitmap.UnlockBits();
            lockBitmap.Dispose();

            miniPanel.BackgroundImageLayout = ImageLayout.Zoom;
            miniPanel.UpdateImage(miniBitmap);

            panelBoxPanel.Controls.Add(miniPanel);

            foreach (PPanel panel in panels)
            {
                miniPanel = new PPanel();
                miniPanel.Name = panel.Name;
                miniPanel.Location = new Point(55 * i++, 0);
                miniPanel.Size = new Size(50, 50);
                miniPanel.MouseClick += MiniPanel_MouseClick;

                miniBitmap = new Bitmap(panel.CW, panel.CH);
                lockBitmap = new LockBitmap(miniBitmap);
                lockBitmap.LockBits();
                for (int j = 0; j < panel.CoordinateColors.Length; j++)
                {
                    lockBitmap.SetPixel(j / panel.CH, j % panel.CH, panel.CoordinateColors[j]);
                }
                lockBitmap.UnlockBits();
                lockBitmap.Dispose();

                miniPanel.BackgroundImageLayout = ImageLayout.Zoom;
                miniPanel.UpdateImage(miniBitmap);

                panelBoxPanel.Controls.Add(miniPanel);
            }

            panelBoxPanel.Refresh();
        }

        private void MiniPanel_MouseClick(object sender, MouseEventArgs e)
        {
            string selectedName = (sender as PPanel).Name;
            PPanel selectedPanel = panels.Find(p => p.Name.Equals(selectedName));

            if (selectedPanel == null)
                selectedPanel = mainPanel;

            UserSetting.SelectedPanel.RePaint(UserSetting.Grid);
            selectedPanel.RePaint(UserSetting.Grid, true);

            UserSetting.SelectedPanel = selectedPanel;
        }

        private void PanelBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                int i = 0;
                g.DrawString("���� �г�", new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, new Point(55 * i++, 55));
                foreach (PPanel panel in panels)
                {
                    g.DrawString(panel.Name, new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, new Point(55 * i++, 55));
                }
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSetting.Grid = ����ToolStripMenuItem.Checked;
            mainPanel.RePaint(UserSetting.Grid);
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Pluto";
            sfd.Filter = "���|*.ps|32��Ʈ ��Ʈ��|*.bmp|PNG|*.png";
            sfd.Title = "����";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName != "")
                {
                    mainPanel.SaveFile(panels, Path.GetFullPath(sfd.FileName));
                }
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "���|*.ps|32��Ʈ ��Ʈ��|*.bmp|PNG|*.png";
            ofd.Title = "����";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName != "")
                {
                    ������ToolStripMenuItem_Click(sender, e);
                    mainPanel.OpenFile(Path.GetFullPath(ofd.FileName));
                    ScenePanelView(1.0f);
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inputWorker.Join();
        }
    }
}