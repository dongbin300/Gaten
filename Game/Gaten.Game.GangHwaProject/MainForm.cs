namespace Gaten.Game.GangHwaProject
{
    public partial class MainForm : Form
    {
        public int degree = 0;
        public int check = 0;
        public int prob = 0;
        public int temp = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime Clock = DateTime.Now;
            Random rnd = new();
            int num = rnd.Next(1, 100);

            temp = degree;
            prob = 98 - (degree * 4);
            if (check == 0) // 처음 시작
            {
                degree++;
                check = 1;
            }
            else if (check == 1 && num <= (17 * prob / 20))  //전번 강화 성공시, 확률 15% 감소
            {
                degree++;
                check = 1;  // 강화 성공시, 체크값 1
            }
            else if (check == -1 && num <= (6 * prob / 5))   //전번 강화 실패시, 확률 20% 증가
            {
                degree++;
                check = 1;
            }
            else if (degree == 0)   // 0강 실패시
            {
                check = -1;
            }
            else
            {
                degree--;
                check = -1; // 강화 실패시, 체크값 -1
            }
            WeaponStatus.Text = degree.ToString();

            prob = 98 - (degree * 4);

            if (check == -1)
            {
                textBox1.Text = (6 * prob / 5).ToString() + "% (" + prob.ToString() + "%+" + (prob / 5).ToString() + "%)";
                textBox2.AppendText(Clock.ToString("hh:mm:ss") + "  +" + temp + " " + textBox3.Text + " 강화를 실패하셨습니다.\r\n");
            }
            else
            {
                textBox1.Text = (17 * prob / 20).ToString() + "% (" + prob.ToString() + "%-" + (3 * prob / 20).ToString() + "%)";
                textBox2.AppendText(Clock.ToString("hh:mm:ss") + "  +" + temp + " " + textBox3.Text + " 강화를 성공하셨습니다.\r\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "100%";
            WeaponStatus.Text = "0";
        }

        private void 새게임NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            degree = 0;
            check = 0;
            textBox1.Text = "100%";
            WeaponStatus.Text = "0";
            textBox2.Clear();
            textBox3.Clear();
        }

        private void 도움말보기VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new();
            _ = helpForm.ShowDialog();
        }

        private void 개발자CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show("게임개발자: Gaten\r\n제작일: 2013년 3월 1일", "개발자", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
    }
}