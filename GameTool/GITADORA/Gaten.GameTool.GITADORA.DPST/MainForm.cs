using System.Media;

namespace Gaten.GameTool.GITADORA.DPST
{
    public partial class MainForm : Form
    {
		private int half = 0;
		private bool handled = false;
		public MainForm()
		{
			InitializeComponent();
			this.KeyPreview = true;
			this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
			board.KeyPress += new KeyPressEventHandler(board_KeyPress);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void cancelSound()
		{
			SoundPlayer sound = new SoundPlayer("PP.wav");
			sound.Play();
		}

		private void clickSound()
		{
			SoundPlayer sound = new SoundPlayer("CLICK.wav");
			sound.Play();
		}

		private void saveinsert_Click(object sender, EventArgs e)
		{
			clickSound();
			FileStream fs = new FileStream("세이브 디렉토리" + savefilename.Text + ".txt", FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			sw.WriteLine("v3");
			sw.Write(board.Text);
			sw.WriteLine(" =");
			sw.Write("*");

			sw.Flush();
			fs.Close();
		}

		private void DQ_Click(object sender, EventArgs e)
		{
			board.AppendText("DQ");
			clickSound();
		}

		private void DT_Click(object sender, EventArgs e)
		{
			board.AppendText("DT");
			clickSound();
		}

		private void OFF1_Click(object sender, EventArgs e)
		{
			board.AppendText(" 1-1-0");
			clickSound();
		}

		private void OFF2_Click(object sender, EventArgs e)
		{
			board.AppendText(" 1-2-0");
			clickSound();
		}

		private void OFF3_Click(object sender, EventArgs e)
		{
			board.AppendText(" 1-3-0");
			clickSound();
		}

		private void OFF4_Click(object sender, EventArgs e)
		{
			board.AppendText(" 1-4-0");
			clickSound();
		}

		void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case (char)32:
					clickSound();
					board.AppendText(" X");
					handled = true;
					board.SelectionStart = board.Text.Length;
					board.ScrollToCaret();
					break; // space bar
				case (char)96:
					clickSound();
					if (half == 0)
					{
						board.AppendText(" [");
						half = 1;
					}
					else
					{
						board.AppendText(" ]");
						half = 0;
					}
					board.SelectionStart = board.Text.Length;
					board.ScrollToCaret();
					break; // `
				case (char)8:
					cancelSound();
					string str = board.Text;
					str = str.Substring(0, str.LastIndexOf(' '));
					board.Text = str;
					board.SelectionStart = board.Text.Length;
					board.ScrollToCaret();
					break; // backspace
			}
		}

		void board_KeyPress(object sender, KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case (char)113: board.AppendText(" C"); break; // q
				case (char)119: board.AppendText(" H"); break;
				case (char)101: board.AppendText(" L"); break;
				case (char)114: board.AppendText(" S"); break;
				case (char)116: board.AppendText(" T"); break;
				case (char)121: board.AppendText(" K"); break;
				case (char)117: board.AppendText(" M"); break;
				case (char)105: board.AppendText(" F"); break;
				case (char)111: board.AppendText(" R"); break;
				case (char)112: board.AppendText(""); break;
				case (char)91: board.AppendText(""); break;
				case (char)93: board.AppendText(""); break;

				case (char)97: board.AppendText(" CK"); break; // a
				case (char)115: board.AppendText(" HK"); break;
				case (char)100: board.AppendText(" LK"); break;
				case (char)102: board.AppendText(" SK"); break;
				case (char)103: board.AppendText(" TK"); break;
				case (char)104: board.AppendText(" SF"); break;
				case (char)106: board.AppendText(" KM"); break;
				case (char)107: board.AppendText(" KF"); break;
				case (char)108: board.AppendText(" KR"); break;
				case (char)59: board.AppendText(""); break;
				case (char)39: board.AppendText(""); break;

				case (char)122: board.AppendText(" CS"); break; // z
				case (char)120: board.AppendText(" HS"); break;
				case (char)99: board.AppendText(" LSR"); break;
				case (char)118: board.AppendText(" LS"); break;
				case (char)98: board.AppendText(" LT"); break;
				case (char)110: board.AppendText(" SR"); break;
				case (char)109: board.AppendText(" LM"); break;
				case (char)44: board.AppendText(" LF"); break;
				case (char)46: board.AppendText(" LR"); break;
				case (char)47: board.AppendText(""); break;

				case (char)72: board.AppendText(" SKF"); break;
				case (char)90: board.AppendText(" CSK"); break;
				case (char)88: board.AppendText(" HSK"); break;
				case (char)86: board.AppendText(" LSK"); break;
				case (char)78: board.AppendText(" SKR"); break;
				case (char)62: board.AppendText(" LKR"); break;
			}
		}

		private void patterninsert_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" " + patternbox.Text.ToUpper());
			clickSound();
		}

		private void Interval5_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n5");
			clickSound();
		}

		private void Interval2_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n2");
			clickSound();
		}

		private void Interval1_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n1");
			clickSound();
		}

		private void Interval11_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n11");
			clickSound();
		}

		private void Interval7_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n7");
			clickSound();
		}

		private void Interval33_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n33");
			clickSound();
		}

		private void Interval16_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n16");
			clickSound();
		}

		private void Interval12_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n12");
			clickSound();
		}

		private void Interval66_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n66");
			clickSound();
		}

		private void Interval25_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n25");
			clickSound();
		}

		private void Interval17_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n17");
			clickSound();
		}

		private void Interval10_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n10");
			clickSound();
		}

		private void Interval20_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n20");
			clickSound();
		}

		private void Interval30_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n30");
			clickSound();
		}

		private void Interval40_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n40");
			clickSound();
		}

		private void intervalinsert_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" =\r\n10" + intervalbox.Text);
			clickSound();
		}

		private void C_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" C");
			clickSound();
		}

		private void H_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" H");
			clickSound();
		}

		private void L_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" L");
			clickSound();
		}

		private void S_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" S");
			clickSound();
		}

		private void T_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" T");
			clickSound();
		}

		private void K_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" K");
			clickSound();
		}

		private void M_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" M");
			clickSound();
		}

		private void F_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" F");
			clickSound();
		}

		private void R_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" R");
			clickSound();
		}

		private void CK_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" CK");
			clickSound();
		}

		private void HK_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" HK");
			clickSound();
		}

		private void LK_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LK");
			clickSound();
		}

		private void SK_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" SK");
			clickSound();
		}

		private void TK_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" TK");
			clickSound();
		}

		private void SF_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" SF");
			clickSound();
		}

		private void KM_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" KM");
			clickSound();
		}

		private void KF_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" KF");
			clickSound();
		}

		private void KR_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" KR");
			clickSound();
		}

		private void CS_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" CS");
			clickSound();
		}

		private void HS_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" HS");
			clickSound();
		}

		private void LSR_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LSR");
			clickSound();
		}

		private void LS_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LS");
			clickSound();
		}

		private void LT_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LT");
			clickSound();
		}

		private void SR_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" SR");
			clickSound();
		}

		private void LM_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LM");
			clickSound();
		}

		private void LF_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LF");
			clickSound();
		}

		private void LR_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LR");
			clickSound();
		}

		private void CSK_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" CSK");
			clickSound();
		}

		private void HSK_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" HSK");
			clickSound();
		}

		private void LSK_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LSK");
			clickSound();
		}

		private void SKF_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" SKF");
			clickSound();
		}

		private void SKR_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" SKR");
			clickSound();
		}

		private void LKR_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			board.AppendText(" LKR");
			clickSound();
		}

		private void IntervalHalf_Click(object sender, EventArgs e)
		{
			if (handled)
			{
				handled = false;
				return;
			}
			if (half == 0)
			{
				board.AppendText(" [");
				half = 1;
			}
			else
			{
				board.AppendText(" ]");
				half = 0;
			}
			clickSound();
		}
	}
}