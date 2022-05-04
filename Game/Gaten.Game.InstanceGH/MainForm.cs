namespace Gaten.Game.InstanceGH
{
    public partial class MainForm : Form
    {
        int money, ghnum, bg;
        int click_count = 0;
        Random ran = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            money = 5000;
            ghnum = 0;
            bg = 0;
        }

        private void sellbt_Click(object sender, EventArgs e)
        {
            if (ghnum > 0)
            {
                money += ghnum * ghnum * 150;
                ghnum = 0;
            }
        }

        private void tick_Tick(object sender, EventArgs e)
        {
            moneylb.Text = "" + money;
            bglb.Text = "" + bg;
            ghnumlb.Text = "" + ghnum;
            ghbt.Text = "[A]강화하기(" + (ghnum + 1) * 120 + ")";
            sellbt.Text = "[S]판매하기(" + ghnum * ghnum * 150 + ")";
        }

        private void ghbt_Click(object sender, EventArgs e)
        {
            click_count++;
            if (money >= (ghnum + 1) * 120)
            {
                money -= (ghnum + 1) * 120;
                if (RanNum(100) >= ghnum * 3 - (bg / 100))
                {
                    ghnum++;

                    if (ghnum >= 10)
                    {
                        bg += (ghnum / 5 - 1);
                    }
                }
                else
                {
                    ghnum = 0;
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    ghbt_Click(null, null);
                    break;
                case Keys.S:
                    sellbt_Click(null, null);
                    break;
            }
        }

        private void bonus_Tick(object sender, EventArgs e)
        {
            money += 2;
            money += ghnum;
            money += bg / 10;
        }

        public int RanNum(int num)
        {
            int rand_num = 1;
            while (true)
            {
                //랜덤을 다양하게 하기 위해 현재시간과 클릭횟수등을 더하여서 랜덤을 만들었습니다.
                rand_num = DateTime.Now.Second + click_count + ran.Next(num);
                if (rand_num % num != 0) break;
            }
            return rand_num % num;
        }
    }
}