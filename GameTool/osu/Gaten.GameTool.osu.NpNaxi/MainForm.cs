namespace Gaten.GameTool.osu.NpNaxi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

		private void MainForm_Load(object sender, EventArgs e)
		{
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			comboBox3.SelectedIndex = 0;
			comboBox4.SelectedIndex = 2;
			comboBox5.SelectedIndex = 0;
			checkBox1.Checked = true;
		}

		private void Completebt_Click(object sender, EventArgs e)
		{
			string rt = ""; // Result Text
			rt += "/me is ";
			if (comboBox1.SelectedIndex == 0)
			{
				rt += "playing";
			}
			else if (comboBox1.SelectedIndex == 1)
			{
				rt += "listening to";
			}
			else if (comboBox1.SelectedIndex == 2)
			{
				rt += "editing";
			}
			rt += " [http://osu.ppy.sh/b/";
			rt += textBox1.Text;
			rt += " ";
			rt += textBox2.Text;
			rt += " - ";
			rt += textBox3.Text;
			if (comboBox2.SelectedIndex != 0)
			{
				rt += " (";
				if (comboBox2.SelectedItem == "Remix")
				{
					rt += textBox4.Text;
					rt += " ";
				}
				rt += comboBox2.SelectedItem;
				rt += ")";
			}
			rt += " [";
			if (comboBox3.SelectedIndex != 0)
			{
				rt += comboBox3.SelectedItem;
			}
			else
			{
				rt += textBox5.Text;
			}
			rt += "]] ";
			if (comboBox4.SelectedIndex == 0)
			{
				rt += "";
			}
			else if (comboBox4.SelectedIndex == 1)
			{
				rt += "<Taiko>";
			}
			else if (comboBox4.SelectedIndex == 2)
			{
				rt += "<CatchTheBeat>";
			}
			else if (comboBox4.SelectedIndex == 3)
			{
				rt += "<osu!mania>";
			}
			rt += " ";
			switch (comboBox5.SelectedIndex)
			{
				case 0:
					if (checkBox1.Checked == true)
						rt += "+Perfect";
					else
						rt += "";
					break;
				case 1:
					if (checkBox1.Checked == true)
						rt += "+Hidden +Perfect";
					else
						rt += "+Hidden";
					break;
				case 2:
					if (checkBox1.Checked == true)
						rt += "+Perfect +HardRock";
					else
						rt += "+HardRock";
					break;
				case 3:
					if (checkBox1.Checked == true)
						rt += "+Perfect +DoubleTime";
					else
						rt += "+DoubleTime";
					break;
				case 4:
					if (checkBox1.Checked == true)
						rt += "+Perfect +Flashlight";
					else
						rt += "+Flashlight";
					break;
				case 5:
					if (checkBox1.Checked == true)
						rt += "+Hidden +Perfect +HardRock";
					else
						rt += "+Hidden +HardRock";
					break;
				case 6:
					if (checkBox1.Checked == true)
						rt += "+Hidden +Perfect +DoubleTime";
					else
						rt += "+Hidden +DoubleTime";
					break;
				case 7:
					if (checkBox1.Checked == true)
						rt += "+Hidden +Perfect +Flashlight";
					else
						rt += "+Hidden +Flashlight";
					break;
				case 8:
					if (checkBox1.Checked == true)
						rt += "+Perfect +HardRock +DoubleTime";
					else
						rt += "+HardRock +DoubleTime";
					break;
				case 9:
					if (checkBox1.Checked == true)
						rt += "+Perfect +HardRock +Flashlight";
					else
						rt += "+HardRock +Flashlight";
					break;
				case 10:
					if (checkBox1.Checked == true)
						rt += "+Perfect +DoubleTime +Flashlight";
					else
						rt += "+DoubleTime +Flashlight";
					break;
				case 11:
					if (checkBox1.Checked == true)
						rt += "+Hidden +Perfect +HardRock +DoubleTime";
					else
						rt += "+Hidden +HardRock +DoubleTime";
					break;
				case 12:
					if (checkBox1.Checked == true)
						rt += "+Hidden +Perfect +HardRock +Flashlight";
					else
						rt += "+Hidden +HardRock +Flashlight";
					break;
				case 13:
					if (checkBox1.Checked == true)
						rt += "+Hidden +Perfect +DoubleTime +Flashlight";
					else
						rt += "+Hidden +DoubleTime +Flashlight";
					break;
				case 14:
					if (checkBox1.Checked == true)
						rt += "+Perfect +HardRock +DoubleTime +Flashlight";
					else
						rt += "+HardRock +DoubleTime +Flashlight";
					break;
				case 15:
					if (checkBox1.Checked == true)
						rt += "+Hidden +Perfect +HardRock +DoubleTime +Flashlight";
					else
						rt += "+Hidden +HardRock +DoubleTime +Flashlight";
					break;
			}
			Result.Text = rt;
		}
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox4.Enabled = comboBox2.SelectedItem == "Remix";
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox5.Enabled = comboBox3.SelectedItem == "±‚≈∏";
		}

        private void TextCopyButton_Click(object sender, EventArgs e)
        {
			Clipboard.SetText(Result.Text);
        }
        
    }
}