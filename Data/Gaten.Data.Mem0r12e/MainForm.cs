namespace Gaten.Data.Mem0r12e
{
    public partial class MainForm : Form
    {
        List<int> sequences;
        string[] problems = new string[1000];
        string[] answers = new string[1000];
        private int problemCount;
        int stage = 0;

        string tempAnswer = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            FileLabel.Text = "파일:" + files[0];

            problemCount = ParseProblemData(files[0]);

            sequences = Shuffle(problemCount);

            NewProblem();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private List<int> Shuffle(int n)
        {
            Random r = new Random();
            List<int> seq = new List<int>();
            int rn;

            for (int i = 0; i < n; i++)
            {
                rn = r.Next(n);

                if (seq.Contains(rn))
                {
                    i--;
                }
                else
                {
                    seq.Add(rn);
                }
            }

            return seq;
        }

        private int ParseProblemData(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string token = "->";
            string temp = string.Empty;
            int index = 0;

            while (sr.Peek() >= 0)
            {
                temp = sr.ReadLine();
                if (temp.Contains(token))
                {
                    problems[index] += temp.Substring(0, temp.IndexOf(token));
                    answers[index++] = temp.Substring(temp.IndexOf(token) + token.Length);
                }
                else
                    problems[index] += temp + Environment.NewLine;
            }

            sr.Close();
            fs.Close();

            return index;
        }

        private void NewProblem()
        {
            if (stage == 0)
            {
                stage++;
                if (tempAnswer != string.Empty)
                {
                    AnswerLabel.Text = tempAnswer;
                }
            }
            else
            {
                AnswerLabel.Text = answers[sequences[stage++]];
            }
                
            ProblemLabel.Text = problems[sequences[stage]];

            // 1바퀴 돌았으면 다시 섞기
            if (stage == problemCount - 1)
            {
                tempAnswer = answers[sequences[stage]];
                sequences = Shuffle(problemCount);
                stage = 0;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputTextBox.Clear();
                NewProblem();
            }
        }
    }
}