namespace Gaten.GameTool.KaguyaTable.KaguyaTableManager
{
    public partial class MainForm : Form
    {
        // 추출할 곳
        public string iePath1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Macromedia\Flash Player\#SharedObjects"); // InternetExplorer
        public string path1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"\Google\Chrome\User Data\Default\Pepper Data\Shockwave Flash\WritableRoot\#SharedObjects"); // Chrome

        // 복사될 곳
        public string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
        public const string fileName = "walfas_kaguya_table.sol";

        public MainForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _ = Path.Combine(iePath1, saveDirectoryTextBox.Text, "www.walfas.org");
            string kaguyaPath = Path.Combine(path1 + saveDirectoryTextBox.Text + "www.walfas.org");
            try
            {
                File.Copy(kaguyaPath + fileName, path2 + fileName, true);
                toolStripStatusLabel1.Text = $"세이브 완료 ({DateTime.Now})";
            }
            catch
            {

            }
        }

        private void minXPCalculate()
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                int rebirth = int.Parse(textBox1.Text);
                int level = int.Parse(textBox2.Text);

                int require = (int)(200_000.0 / (rebirth + 3));

                ulong sum = 0;
                for (int i = level; i <= level + require; i++)
                {
                    sum += (ulong)((i + 1) * 250);
                }

                HXPlb.Text = string.Format("{0:0}", sum) + "(" + string.Format("{0:0}", sum / 100_000_000) + "억)";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            minXPCalculate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            minXPCalculate();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                int count = int.Parse(textBox3.Text);

                double percent = 100.0;
                int eplus = 0;

                for (int i = 0; i < count; i++)
                {
                    percent *= 0.9;
                    if (percent < 1)
                    {
                        percent *= 10;
                        eplus++;
                    }
                }
                SRlb.Text = string.Format("{0:0.000000}", percent) + "E-" + string.Format("{0:0}", eplus);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string kaguyaPath = path1 + saveDirectoryTextBox.Text + @"\www.walfas.org\";
            try
            {
                File.Copy(path2 + fileName, kaguyaPath + fileName, true);
                toolStripStatusLabel1.Text = $"로드 완료 ({DateTime.Now})";
            }
            catch
            {

            }
        }

        private void autoSaveTimer_Tick(object sender, EventArgs e)
        {
            if (autoSaveCheckBox.Checked)
            {
                saveButton_Click(sender, e);
            }
        }

        private void statusLabelTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            statusLabelTimer.Stop();
        }

        private void autoSaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSaveCheckBox.Checked)
            {
                autoSaveTimer.Start();
            }
            else
            {
                autoSaveTimer.Stop();
            }
        }

        private void toolStripStatusLabel1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Text.Length > 1)
            {
                statusLabelTimer.Start();
            }
        }
    }
}