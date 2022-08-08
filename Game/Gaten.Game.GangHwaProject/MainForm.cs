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
            if (check == 0) // ó�� ����
            {
                degree++;
                check = 1;
            }
            else if (check == 1 && num <= (17 * prob / 20))  //���� ��ȭ ������, Ȯ�� 15% ����
            {
                degree++;
                check = 1;  // ��ȭ ������, üũ�� 1
            }
            else if (check == -1 && num <= (6 * prob / 5))   //���� ��ȭ ���н�, Ȯ�� 20% ����
            {
                degree++;
                check = 1;
            }
            else if (degree == 0)   // 0�� ���н�
            {
                check = -1;
            }
            else
            {
                degree--;
                check = -1; // ��ȭ ���н�, üũ�� -1
            }
            WeaponStatus.Text = degree.ToString();

            prob = 98 - (degree * 4);

            if (check == -1)
            {
                textBox1.Text = (6 * prob / 5).ToString() + "% (" + prob.ToString() + "%+" + (prob / 5).ToString() + "%)";
                textBox2.AppendText(Clock.ToString("hh:mm:ss") + "  +" + temp + " " + textBox3.Text + " ��ȭ�� �����ϼ̽��ϴ�.\r\n");
            }
            else
            {
                textBox1.Text = (17 * prob / 20).ToString() + "% (" + prob.ToString() + "%-" + (3 * prob / 20).ToString() + "%)";
                textBox2.AppendText(Clock.ToString("hh:mm:ss") + "  +" + temp + " " + textBox3.Text + " ��ȭ�� �����ϼ̽��ϴ�.\r\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "100%";
            WeaponStatus.Text = "0";
        }

        private void ������NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            degree = 0;
            check = 0;
            textBox1.Text = "100%";
            WeaponStatus.Text = "0";
            textBox2.Clear();
            textBox3.Clear();
        }

        private void ���򸻺���VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new();
            _ = helpForm.ShowDialog();
        }

        private void ������CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show("���Ӱ�����: Gaten\r\n������: 2013�� 3�� 1��", "������", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
    }
}