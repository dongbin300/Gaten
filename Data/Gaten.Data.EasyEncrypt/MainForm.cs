using Gaten.Net.IO;

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
            OpenFileDialog? dialog = new()
            {
                Title = "Select File"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = dialog.FileName;
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if (fileTextBox.Text.Length < 1)
            {
                _ = MessageBox.Show("No File");
                return;
            }

            byte[]? bytes = GFile.ReadBinary(fileTextBox.Text);
            byte[]? ModifiedBytes = Encrypt(bytes);
            string outPath = Path.GetDirectoryName(fileTextBox.Text)?.Down(Path.GetFileNameWithoutExtension(fileTextBox.Text) + "_e" + Path.GetExtension(fileTextBox.Text)) ?? string.Empty;
            GFile.WriteBinary(outPath, ModifiedBytes);

            _ = MessageBox.Show("Encrypt Complete");
        }

        private byte[] Encrypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i]++;
            }
            return bytes;
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (fileTextBox.Text.Length < 1)
            {
                _ = MessageBox.Show("No File");
                return;
            }

            byte[]? bytes = GFile.ReadBinary(fileTextBox.Text);
            byte[]? ModifiedBytes = Decrypt(bytes);
            string outPath = Path.GetDirectoryName(fileTextBox.Text)?.Down(Path.GetFileNameWithoutExtension(fileTextBox.Text) + "_d" + Path.GetExtension(fileTextBox.Text)) ?? string.Empty;
            GFile.WriteBinary(outPath, ModifiedBytes);

            _ = MessageBox.Show("Decrypt Complete");
        }

        private byte[] Decrypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i]--;
            }
            return bytes;
        }
    }
}