using Gaten.Net.IO;

namespace Gaten.Data.FileClassifier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "분류할 상위 디렉토리 설정";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string root = textBox1.Text;
            FileInfo[] files = new DirectoryInfo(root).GetFiles("*.*", SearchOption.AllDirectories);

            foreach (FileInfo f in files)
            {
                if (File.Exists(root.Down(f.Name)))
                {
                    File.Move(f.FullName, root.Down(Path.GetFileNameWithoutExtension(f.FullName) + "_" + Path.GetRandomFileName() + f.Extension));
                }
                else
                {
                    File.Move(f.FullName, root.Down(f.Name));
                }
            }

            DirectoryInfo[]? directories = new DirectoryInfo(root).GetDirectories("*", SearchOption.AllDirectories);

            foreach (DirectoryInfo d in directories)
            {
                d.Delete(true);
            }

            files = new DirectoryInfo(root).GetFiles("*.*", SearchOption.AllDirectories);

            foreach (FileInfo f in files)
            {
                if (!Directory.Exists(root.Down(f.Extension)))
                {
                    _ = Directory.CreateDirectory(root.Down(f.Extension));
                }

                File.Move(f.FullName, root.Down(f.Extension, f.Name));
            }
        }
    }
}