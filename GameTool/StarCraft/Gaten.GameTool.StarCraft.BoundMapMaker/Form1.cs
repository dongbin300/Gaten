namespace Gaten.GameTool.StarCraft.BoundMapMaker
{
    public partial class Form1 : Form
    {
        int tempX = 0, tempY = 0;
        public BoundPanel BoundPanel;
        public enum TileEditMode
        {
            Size1,
            Size2
        }
        public TileEditMode _TileEditMode;
        public int Size => _TileEditMode == TileEditMode.Size1 ? 1 : 2;

        public Form1()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            DoubleBuffered = true;

            PanelInit();
        }

        public void PanelInit()
        {
            BoundPanel = new BoundPanel();
            TileEditSizeButton2_Click(null, null);

            boundPanel.BackColor = Color.FromArgb(33, 33, 33);
        }

        private void boundPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    /* Draw Tile */
                    Color color = Color.FromArgb(33, 33, 33);

                    switch (BoundPanel.Tiles[i, j])
                    {
                        case BoundPanel.TileType.Blank:
                            continue;
                        case BoundPanel.TileType.BoundZone:
                            color = Color.White;
                            break;
                        case BoundPanel.TileType.Creep:
                            color = Color.Magenta;
                            break;
                        case BoundPanel.TileType.Pointer:
                            color = Color.FromArgb(60, 255, 255, 255);
                            break;
                    }

                    g.DrawLine(new Pen(color, 20), j * 20, i * 20 + 10, j * 20 + 20, i * 20 + 10);


                }
            }

            /* Draw Grid */
            for (int i = 20; i < 600; i += 20)
            {
                g.DrawLine(new Pen(Color.FromArgb(100, 0, 255, 0), 1), 0, i, 800, i);
            }

            for (int i = 20; i < 800; i += 20)
            {
                g.DrawLine(new Pen(Color.FromArgb(100, 0, 255, 0), 1), i, 0, i, 600);
            }

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    /* Draw BoundZone Number */
                    var boundZone = BoundPanel.BoundZones.Find(z => z.X.Equals(j) && z.Y.Equals(i));
                    if (boundZone != null)
                    {
                        g.DrawString(boundZone.ID.ToString(), new Font("굴림", 9), Brushes.Green, j * 20 + boundZone.Size * 10 - 6, i * 20 + boundZone.Size * 10 - 6);
                    }
                }
            }
        }

        private void boundPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / 20;
            int y = e.Y / 20;

            switch (e.Button)
            {
                /*
                 * 가장자리가 아니어야함
                 * 1/4칸 타일이 모두 0이어야함
                 * 1/4칸 상하좌우에 연결되는 타일이 있어야함
                 */
                case MouseButtons.Left:
                    if (x < 0 || x >= 41 - Size)
                        break;
                    if (y < 0 || y >= 31 - Size)
                        break;
                    if (!BoundPanel.InspectSquare(BoundPanel.TileType.Blank, x, y, Size) && !BoundPanel.InspectSquare(BoundPanel.TileType.Pointer, x, y, Size))
                        break;
                    if (!BoundPanel.InspectAmbient(BoundPanel.TileType.BoundZone, x, y, Size) && !BoundPanel.InspectAmbient(BoundPanel.TileType.Creep, x, y, Size))
                    {
                        MessageBox.Show("주위에 타일이 있어야 합니다.");
                        break;
                    }

                    BoundPanel.AddBoundZone(x, y, Size);
                    break;

                case MouseButtons.Right:
                    break;
            }

            boundPanel.Refresh();
        }

        private void TileEditSizeButton1_Click(object sender, EventArgs e)
        {
            _TileEditMode = TileEditMode.Size1;
            TileEditSizeButton1.BackColor = Color.Lime;
            TileEditSizeButton2.BackColor = Color.White;
        }

        private void TileEditSizeButton2_Click(object sender, EventArgs e)
        {
            _TileEditMode = TileEditMode.Size2;
            TileEditSizeButton1.BackColor = Color.White;
            TileEditSizeButton2.BackColor = Color.Lime;
        }

        private void boundPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / 20;
            int y = e.Y / 20;

            if (x < 0 || x >= 41 - Size)
                return;
            if (y < 0 || y >= 31 - Size)
                return;

            BoundPanel.RefreshPointer(x, y, Size);

            if (tempX != x || tempY != y)
            {
                boundPanel.Refresh();
            }

            tempX = x;
            tempY = y;
        }
    }
}