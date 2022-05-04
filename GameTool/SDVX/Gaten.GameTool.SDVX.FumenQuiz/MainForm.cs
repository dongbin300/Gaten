namespace Gaten.GameTool.SDVX.FumenQuiz
{
    public partial class MainForm : Form
    {
        public enum Modes { Study, Exercise, Test, Hardcore };
        public Modes mode;
        public List<int> selectedLevels = new List<int>();
        public List<int> selectedSeries = new List<int>();

        public string answer;
        public string selectExample;

        public MainForm()
        {
            InitializeComponent();

            Init();
        }

        void Init()
        {
            CheckBox[] levels = new CheckBox[20];
            CheckBox allLevel = new CheckBox();
            CheckBox[] seriess = new CheckBox[5];
            CheckBox allSeries = new CheckBox();

            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = new CheckBox();
                levels[i].Name = $"LEVEL{i + 1}";
                levels[i].Location = new Point(10 + 60 * (i % 4), 10 + 20 * (i / 4));
                levels[i].Size = new Size(50, 15);
                levels[i].Text = $"{i + 1}";
                levels[i].Checked = false;
                levelPanel.Controls.Add(levels[i]);
            }
            allLevel = new CheckBox();
            allLevel.Location = new Point(180, 120);
            allLevel.Size = new Size(50, 15);
            allLevel.Text = "모두";
            allLevel.Checked = false;
            allLevel.CheckedChanged += AllLevel_CheckedChanged;
            levelPanel.Controls.Add(allLevel);

            for (int i = 0; i < seriess.Length; i++)
            {
                seriess[i] = new CheckBox();
                seriess[i].Name = $"SERIES{i + 1}";
                seriess[i].Location = new Point(10 + 60 * (i % 4), 10 + 20 * (i / 4));
                seriess[i].Size = new Size(50, 15);
                seriess[i].Text = $"{i + 1}";
                seriess[i].Checked = false;
                seriesPanel.Controls.Add(seriess[i]);
            }
            allSeries = new CheckBox();
            allSeries.Location = new Point(180, 60);
            allSeries.Size = new Size(50, 15);
            allSeries.Text = "모두";
            allSeries.Checked = false;
            allSeries.CheckedChanged += AllSeries_CheckedChanged;
            seriesPanel.Controls.Add(allSeries);

            // 1~16레벨 아직 미지원, 시리즈 미지원
            for (int i = 0; i < 16; i++)
            {
                (levelPanel.Controls[$"LEVEL{i + 1}"] as CheckBox).Visible = false;
            }
            for (int i = 0; i < 5; i++)
            {
                (seriesPanel.Controls[$"SERIES{i + 1}"] as CheckBox).Visible = false;
            }
            // 테스트모드, 하드코어모드 미지원
            testButton.Enabled = false;
            hardcoreButton.Enabled = false;

            difficultyComboBox.SelectedIndex = 1;
        }

        private void AllSeries_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
                for (int i = 0; i < 5; i++)
                    (seriesPanel.Controls[$"SERIES{i + 1}"] as CheckBox).Checked = true;
            else
                for (int i = 0; i < 5; i++)
                    (seriesPanel.Controls[$"SERIES{i + 1}"] as CheckBox).Checked = false;
        }

        private void AllLevel_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
                for (int i = 16; i < 20; i++)
                    (levelPanel.Controls[$"LEVEL{i + 1}"] as CheckBox).Checked = true;
            else
                for (int i = 16; i < 20; i++)
                    (levelPanel.Controls[$"LEVEL{i + 1}"] as CheckBox).Checked = false;
        }

        private void StudyButton_Click(object sender, EventArgs e)
        {
            mode = Modes.Study;
            mainTabControl.SelectedIndex = 1;
        }

        private void ExerciseButton_Click(object sender, EventArgs e)
        {
            mode = Modes.Exercise;
            mainTabControl.SelectedIndex = 1;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // 선택된 레벨 넣기
            for (int i = 0; i < 20; i++)
            {
                if ((levelPanel.Controls[$"LEVEL{i + 1}"] as CheckBox).Checked)
                    selectedLevels.Add(i + 1);
            }
            // 선택된 시리즈 넣기
            for (int i = 0; i < 5; i++)
            {
                if ((seriesPanel.Controls[$"SERIES{i + 1}"] as CheckBox).Checked)
                    selectedSeries.Add(i + 1);
            }

            mainTabControl.SelectedIndex = 2;

            switch (mode)
            {
                case Modes.Study:
                    nextButton.Visible = true;
                    Next(mode);
                    break;
                case Modes.Exercise:
                    nextButton.Visible = false;
                    Next(mode);
                    break;
            }
        }

        int GetRandomLevel()
        {
            List<int> counts = new List<int>();
            foreach (int i in selectedLevels)
            {
                counts.Add(new DirectoryInfo($"fumen\\{i}").GetFiles().Length);
            }

            int num = new Random().Next(counts.Sum());

            for (int i = 0; ; i++)
            {
                if (num - counts[i] <= 0)
                    return selectedLevels[i];
                else
                    num -= counts[i];
            }
        }

        void Next(Modes mode)
        {
            Random random = new Random();
            int level;
            List<FileInfo> files;
            FileInfo file;

            switch (mode)
            {
                case Modes.Study:
                    level = GetRandomLevel();

                    files = new DirectoryInfo($"fumen\\{level}").GetFiles().ToList();
                    file = files[random.Next(files.Count)];

                    exampleListBox.Items.Clear();
                    exampleListBox.Items.Add(file.Name.Replace(".png", ""));

                    ShowImage(file.FullName);
                    break;
                case Modes.Exercise:
                    level = GetRandomLevel();

                    files = new DirectoryInfo($"fumen\\{level}").GetFiles().ToList();
                    file = files[random.Next(files.Count)];

                    SetExample(files, file.Name.Replace(".png", ""));

                    ShowImage(file.FullName);
                    break;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectedIndex = 0;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectedIndex = 1;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            mode = Modes.Test;
            mainTabControl.SelectedIndex = 2;
        }

        private void HardcoreButton_Click(object sender, EventArgs e)
        {
            mode = Modes.Hardcore;
            mainTabControl.SelectedIndex = 2;
        }

        Bitmap CropImage(Image source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics.FromImage(bmp).DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            return bmp;
        }

        void ShowImage(string fileName)
        {
            Random random = new Random();

            Image image = Image.FromFile(fileName);
            int qWidth = 0;
            int qHeight = 0;

            switch (difficultyComboBox.SelectedIndex)
            {
                case 0:
                    qWidth = 500;
                    qHeight = 700;
                    break;
                case 1:
                    qWidth = 400;
                    qHeight = 600;
                    break;
                case 2:
                    qWidth = 300;
                    qHeight = 500;
                    break;
                case 3:
                    qWidth = 200;
                    qHeight = 400;
                    break;
            }

            try
            {
                int x = random.Next(image.Width - qWidth);
                int y = random.Next(image.Height - qHeight);

                image = CropImage(image, new Rectangle(x, y, qWidth, qHeight));

                questionPanel.BackColor = Color.FromArgb(22, 22, 22);
                questionPanel.BackgroundImage = image;
                questionPanel.BackgroundImageLayout = ImageLayout.Center;
            }
            catch
            {

            }
        }

        void SetExample(List<FileInfo> files, string answer)
        {
            Random random = new Random();
            List<string> examples = new List<string>();
            examples.Add(answer);

            // 정답 문자열
            this.answer = answer;

            for (int i = 0; i < exampleCountNumericTextBox.Value - 1; i++)
            {
                string fileName = files[random.Next(files.Count)].Name.Replace(".png", "");
                if (examples.Contains(fileName))
                    i--;
                else
                    examples.Add(fileName);
            }

            // 리스트 정렬
            examples.Sort();

            exampleListBox.Items.Clear();
            foreach (string str in examples)
            {
                exampleListBox.Items.Add(str);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Next(mode);
        }

        private void ExampleListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;

            if (answer == listBox.SelectedItem.ToString())
            {
                resultLabel.ForeColor = Color.Lime;
                resultLabel.Text = $"[O] 정답:{answer}\r\n선택한 답:{listBox.SelectedItem.ToString()}";
                Next(mode);
            }
            else
            {
                resultLabel.ForeColor = Color.Red;
                resultLabel.Text = $"[X] 정답:{answer}\r\n선택한 답:{listBox.SelectedItem.ToString()}";
                Next(mode);
            }
        }
    }
}