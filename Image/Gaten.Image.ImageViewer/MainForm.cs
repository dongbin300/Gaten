using static Gaten.Net.Windows.WinApi;

namespace Gaten.Image.ImageViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ContextMenuStrip = menu;
            ShowInTaskbar = false;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var image = System.Drawing.Image.FromFile(files[0]);

            Size = new Size(image.Width, image.Height);
            BackgroundImage = image;

            TransparencyKey = Color.White;
        }

        private void 항상위에표시ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = 항상위에표시ToolStripMenuItem.Checked ? true : false;
        }

        private void transparency_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;

            Opacity = double.Parse(item.Text);
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}