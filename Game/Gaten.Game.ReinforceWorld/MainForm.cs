namespace Gaten.Game.ReinforceWorld
{
    public partial class MainForm : Form
    {
        public static int DelayTick = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            delayTimer.Start();

            Character.Load();

            Refresh();
        }

        private void reinforceButton_Click(object sender, EventArgs e)
        {
            string result = Reinforcement.Try().Result;
            if (result != string.Empty)
            {
                _ = MessageBox.Show(result);
            }
        }

        private void ReinforceEnd()
        {
            Reinforcement.Delay = false;

            Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Space:
                    reinforceButton_Click(null, null);
                    break;
            }
        }

        private new void Refresh()
        {
            weaponNameLabel.Text = Character.WeaponName;
            reinforcementValueLabel.Text = "+" + Character.CurrentValue;
            moneyLabel.Text = Character.Money + " °ñµå";
            gradeTierLabel.Text = Character.GradeDisplayName[(int)Character._Grade] + " " + Character.TierDisplayName[(int)Character._Tier];
        }

        public static void StartDelay(int tick)
        {
            DelayTick = tick;
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            if (Reinforcement.Delay && DelayTick > 0)
            {
                DelayTick--;
                delayLabel.Text = string.Format("{0:0.00F}", (double)DelayTick / 100);
            }
            else if (Reinforcement.Delay)
            {
                ReinforceEnd();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            delayTimer.Stop();
        }
    }
}