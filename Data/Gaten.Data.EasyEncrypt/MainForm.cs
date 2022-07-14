using Gaten.Net.Extension;

namespace Gaten.Data.EasyEncrypt
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = ofd.FileName;
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            byte[] bytes;

            if (fileTextBox.Text.Length < 1)
            {
                MessageBox.Show("No File");
                return;
            }

            using (FileStream fs = new FileStream(fileTextBox.Text, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    var len = br.BaseStream.Length;
                    bytes = new byte[len];
                    bytes = br.ReadBytes((int)len);
                }
            }

            var ModifiedBytes = Encrypt(bytes);

            string outPath = Path.GetDirectoryName(fileTextBox.Text).Down(Path.GetFileNameWithoutExtension(fileTextBox.Text) + "_e" + Path.GetExtension(fileTextBox.Text));
            using (FileStream fs = new FileStream(outPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(ModifiedBytes);
                }
            }

            MessageBox.Show("Encrypt Complete");
        }

        byte[] Encrypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i]++;
            }
            return bytes;
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            byte[] bytes;

            if (fileTextBox.Text.Length < 1)
            {
                MessageBox.Show("No File");
                return;
            }

            using (FileStream fs = new FileStream(fileTextBox.Text, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    var len = br.BaseStream.Length;
                    bytes = new byte[len];
                    bytes = br.ReadBytes((int)len);
                }
            }

            var ModifiedBytes = Decrypt(bytes);

            string outPath = Path.GetDirectoryName(fileTextBox.Text).Down(Path.GetFileNameWithoutExtension(fileTextBox.Text) + "_d" + Path.GetExtension(fileTextBox.Text));
            using (FileStream fs = new FileStream(outPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(ModifiedBytes);
                }
            }

            MessageBox.Show("Decrypt Complete");
        }

        byte[] Decrypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i]--;
            }
            return bytes;
        }
    }
}