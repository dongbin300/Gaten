namespace Gaten.Game.FiveDice
{
    public partial class MainForm : Form
    {
        private readonly List<Dice> Dices = new();

        public MainForm()
        {
            InitializeComponent();

            Dices.Add(new Dice() { Value = "1" });
            Dices.Add(new Dice() { Value = "2" });
            Dices.Add(new Dice() { Value = "3" });
            Dices.Add(new Dice() { Value = "4" });
            Dices.Add(new Dice() { Value = "5" });

            SetDiceStatus(Dice1Button, Dices[0].IntValue);
            SetDiceStatus(Dice2Button, Dices[1].IntValue);
            SetDiceStatus(Dice3Button, Dices[2].IntValue);
            SetDiceStatus(Dice4Button, Dices[3].IntValue);
            SetDiceStatus(Dice5Button, Dices[4].IntValue);
        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            Button button = null;

            for (int i = 0; i < 5; i++)
            {
                if (Dices[i].Fixed)
                {
                    continue;
                }

                Dices[i].Roll();

                switch (i)
                {
                    case 0: button = Dice1Button; break;
                    case 1: button = Dice2Button; break;
                    case 2: button = Dice3Button; break;
                    case 3: button = Dice4Button; break;
                    case 4: button = Dice5Button; break;
                    default:
                        break;
                }

                SetDiceStatus(button, Dices[i].IntValue);
            }
        }

        private void SetDiceStatus(Button button, int value = 0, bool _fixed = false)
        {
            switch (value)
            {
                case 0: break;
                case 1: button.Text = "¡Ü"; break;
                case 2: button.Text = "     ¡Ü       ¡Ü      "; break;
                case 3: button.Text = "     ¡Ü   ¡Ü   ¡Ü      "; break;
                case 4: button.Text = "¡Ü   ¡Ü       ¡Ü   ¡Ü"; break;
                case 5: button.Text = "¡Ü   ¡Ü   ¡Ü    ¡Ü   ¡Ü"; break;
                case 6: button.Text = "¡Ü   ¡Ü¡Ü   ¡Ü¡Ü   ¡Ü"; break;
                default:
                    break;
            }

            button.BackColor = _fixed ? Color.Lime : SystemColors.Control;
        }

        private void Dice1Button_Click(object sender, EventArgs e)
        {
            Dices[0].Fixed ^= true;
            SetDiceStatus(Dice1Button, 0, Dices[0].Fixed);
        }

        private void Dice2Button_Click(object sender, EventArgs e)
        {
            Dices[1].Fixed ^= true;
            SetDiceStatus(Dice2Button, 0, Dices[1].Fixed);
        }

        private void Dice3Button_Click(object sender, EventArgs e)
        {
            Dices[2].Fixed ^= true;
            SetDiceStatus(Dice3Button, 0, Dices[2].Fixed);
        }

        private void Dice4Button_Click(object sender, EventArgs e)
        {
            Dices[3].Fixed ^= true;
            SetDiceStatus(Dice4Button, 0, Dices[3].Fixed);
        }

        private void Dice5Button_Click(object sender, EventArgs e)
        {
            Dices[4].Fixed ^= true;
            SetDiceStatus(Dice5Button, 0, Dices[4].Fixed);
        }
    }
}