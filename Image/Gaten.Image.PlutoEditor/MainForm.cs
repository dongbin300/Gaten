using Gaten.Image.PlutoEditor.Panel;
using Gaten.Net.Windows.Forms;
using Gaten.Net.Image;

namespace Gaten.Image.PlutoEditor
{
    public partial class MainForm : Form
    {
        /*
         * 궁극적인 목표:
         * 오브젝트를 움직이는 영상 제작
         * 
         * 필요:
         * 1. 오브젝트 그리기
         * 2. 프레임(장면, 시간에따라 재생)
         * 3. 오브젝트 애니메이션
         * 4. 테스트 콘솔
         * 5. 동영상 파일로 추출(.avi)
         * 
         * hierarchy
         * 비디오(video)-애니메이션(animation)-장면(scene)-패널(panel)-오브젝트(object)-픽셀(pixel)
         * 
         * 0. 우주 (960*540)
         * 
         * 1. 오브젝트 그리기
         * 1-1. 오브젝트(Object)
         * 하나의 오브젝트 = 하나의 Panel
         * 1-2. 그리기(Draw)
         * 점, 선
         * 
         * 2. 프레임
         * 2-1. 
         * 
         * 
         * TODO:
         * 다중 패널 사용(패널 선택 후 이동 가능)(6시간)
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

        // scenePanel 고정 변수
        Point pencilPosition;

        public MainForm()
        {
            InitializeComponent();
            InitToolBox();
            InitPaint();
            InitThread();
            InitEvent();

            새우주ToolStripMenuItem_Click(null, null);
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
                // 마우스 휠
                hook.MouseWheel += (sender, e) =>
                {
                    // 폼 내부 실제 좌표 구하기
                    Point currentPosition = this.GetCurrentPositionOnForm(e.Location);

                    // 현재 커서가 위치중인 컨트롤 찾기
                    List<Control> currentControls = this.GetControlsFromCurrentPosition(currentPosition);

                    if (e.Delta != 0)
                    {
                        if (currentControls.Contains(scenePanel) && !currentControls.Contains(menuStrip))
                        {
                            // 휠을 위로 올리면 확대, 아래로 내리면 축소
                            float scale = e.Delta < 0 ? U.SetScale(Math.Max(2, U.Scale - 1)) : U.SetScale(Math.Min(20, U.Scale + 1));

                            // 스케일 표시
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

                // 마우스 다운
                hook.MouseDown += (sender, e) =>
                {
                    // 폼 내부 실제 좌표 구하기
                    Point currentPosition = this.GetCurrentPositionOnForm(e.Location);

                    // 현재 커서가 위치중인 컨트롤 찾기
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

                // 마우스 업
                hook.MouseUp += (sender, e) =>
                {
                    // 폼 내부 실제 좌표 구하기
                    Point currentPosition = this.GetCurrentPositionOnForm(e.Location);

                    // 현재 커서가 위치중인 컨트롤 찾기
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

                // 마우스 무브
                hook.MouseMove += (sender, e) =>
                {
                    // 폼 내부 실제 좌표 구하기
                    Point currentPosition = this.GetCurrentPositionOnForm(e.Location);

                    // 현재 커서가 위치중인 컨트롤 찾기
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

                //키보드 후킹
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
                            새우주ToolStripMenuItem.PerformClick();
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
            //새우주ToolStripMenuItem_Click(sender, e);
            //AddPanelButton_Click(sender, e);
            //panelListBox.SelectedIndex = 0;
            SelectedTool = Tools.Pixel;
            //격자ToolStripMenuItem.PerformClick();
            //PanelTest();
        }

        void PanelTest()
        {
            PPanel panel = new PPanel($"패널 1", 2, 2, 3, 3, 1);
            panel.SetCoordinate(0, 0, Color.Red);
            panel.SetCoordinate(1, 1, Color.Red);
            panels.Add(panel);

            panel = new PPanel($"패널 2", 7, 5, 5, 5, 2);
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

        private void 새우주ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 메인 패널 추가
                mainPanel = new PPanel("메인 패널", 0, 0, 100, 60, 0);
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

        private void 콘솔ToolStripMenuItem_Click(object sender, EventArgs e)
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
            PPanel panel = new PPanel($"패널 {panels.Count + 1}", 1, 1, 10, 10, panels.Count);
            panels.Add(panel);

            ScenePanelView(1.0f);
        }

        /// <summary>
        /// Scene패널 다시 그리기
        /// </summary>
        void ScenePanelView(float scale)
        {
            Dictionary<int, int> iDict = new Dictionary<int, int>();
            List<int> zIndexes = new List<int>();
            int i = 0;

            scenePanel.Controls.Clear();

            // 메인 패널 업데이트
            mainPanel.ReCalculate();
            scenePanel.Controls.Add(mainPanel);
            mainPanel.RePaint(격자ToolStripMenuItem.Checked ? true : false);

            // 일반 패널 업데이트
            // 패널 추가는 Z-index가 높은 것부터 추가해야함
            // Z-index가 클수록 먼저 추가되므로 가장 위에 표시된다
            foreach (PPanel panel in panels)
            {
                // 패널 픽셀 재계산
                panel.ReCalculate();

                // 패널 비트맵 그리기
                panel.RePaint(UserSetting.Grid);

                // 리스트에 Z-index 추가
                iDict.Add(panel.Z, i++);
                zIndexes.Add(panel.Z);
            }

            // Z-index로 내림차순 정렬
            zIndexes.Sort((a, b) => -1 * a.CompareTo(b));

            // 패널을 메인패널에 추가
            foreach (int z in zIndexes)
            {
                mainPanel.Controls.Add(panels[iDict[z]]);
            }

            // 선택중인 패널 표시
            UserSetting.SelectedPanel.RePaint(UserSetting.Grid, true);

            // 패널박스 업데이트
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
                g.DrawString("메인 패널", new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, new Point(55 * i++, 55));
                foreach (PPanel panel in panels)
                {
                    g.DrawString(panel.Name, new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, new Point(55 * i++, 55));
                }
            }
        }

        private void 격자ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSetting.Grid = 격자ToolStripMenuItem.Checked;
            mainPanel.RePaint(UserSetting.Grid);
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Pluto";
            sfd.Filter = "장면|*.ps|32비트 비트맵|*.bmp|PNG|*.png";
            sfd.Title = "저장";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName != "")
                {
                    mainPanel.SaveFile(panels, Path.GetFullPath(sfd.FileName));
                }
            }
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "장면|*.ps|32비트 비트맵|*.bmp|PNG|*.png";
            ofd.Title = "열기";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName != "")
                {
                    새우주ToolStripMenuItem_Click(sender, e);
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