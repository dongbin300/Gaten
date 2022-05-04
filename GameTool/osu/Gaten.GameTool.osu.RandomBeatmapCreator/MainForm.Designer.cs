namespace Gaten.GameTool.osu.RandomBeatmapCreator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.musicnametextbox = new System.Windows.Forms.TextBox();
			this.searchingbutton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.distancetextbox = new System.Windows.Forms.TextBox();
			this.beatcombobox = new System.Windows.Forms.ComboBox();
			this.titletextbox = new System.Windows.Forms.TextBox();
			this.artisttextbox = new System.Windows.Forms.TextBox();
			this.creatortextbox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.versiontextbox = new System.Windows.Forms.TextBox();
			this.sourcetextbox = new System.Windows.Forms.TextBox();
			this.tagstextbox = new System.Windows.Forms.TextBox();
			this.createbutton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.hpcombobox = new System.Windows.Forms.ComboBox();
			this.cscombobox = new System.Windows.Forms.ComboBox();
			this.arcombobox = new System.Windows.Forms.ComboBox();
			this.odcombobox = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.smtextbox = new System.Windows.Forms.TextBox();
			this.strcombobox = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.offsettextbox = new System.Windows.Forms.TextBox();
			this.bpmtextbox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// musicnametextbox
			// 
			this.musicnametextbox.Location = new System.Drawing.Point(13, 13);
			this.musicnametextbox.Name = "musicnametextbox";
			this.musicnametextbox.Size = new System.Drawing.Size(197, 21);
			this.musicnametextbox.TabIndex = 0;
			// 
			// searchingbutton
			// 
			this.searchingbutton.Location = new System.Drawing.Point(216, 13);
			this.searchingbutton.Name = "searchingbutton";
			this.searchingbutton.Size = new System.Drawing.Size(75, 23);
			this.searchingbutton.TabIndex = 1;
			this.searchingbutton.Text = "찾아보기...";
			this.searchingbutton.UseVisualStyleBackColor = true;
			this.searchingbutton.Click += new System.EventHandler(this.searchingbutton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "Distance";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "Beat";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "Title";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 121);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "Artist";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 149);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 12);
			this.label5.TabIndex = 6;
			this.label5.Text = "Creator";
			// 
			// distancetextbox
			// 
			this.distancetextbox.Location = new System.Drawing.Point(73, 40);
			this.distancetextbox.Name = "distancetextbox";
			this.distancetextbox.Size = new System.Drawing.Size(37, 21);
			this.distancetextbox.TabIndex = 7;
			// 
			// beatcombobox
			// 
			this.beatcombobox.FormattingEnabled = true;
			this.beatcombobox.Items.AddRange(new object[] {
			"2",
			"3",
			"4",
			"6",
			"8",
			"12",
			"16"});
			this.beatcombobox.Location = new System.Drawing.Point(73, 67);
			this.beatcombobox.Name = "beatcombobox";
			this.beatcombobox.Size = new System.Drawing.Size(37, 20);
			this.beatcombobox.TabIndex = 8;
			// 
			// titletextbox
			// 
			this.titletextbox.Location = new System.Drawing.Point(73, 93);
			this.titletextbox.Name = "titletextbox";
			this.titletextbox.Size = new System.Drawing.Size(100, 21);
			this.titletextbox.TabIndex = 9;
			// 
			// artisttextbox
			// 
			this.artisttextbox.Location = new System.Drawing.Point(73, 121);
			this.artisttextbox.Name = "artisttextbox";
			this.artisttextbox.Size = new System.Drawing.Size(100, 21);
			this.artisttextbox.TabIndex = 10;
			// 
			// creatortextbox
			// 
			this.creatortextbox.Location = new System.Drawing.Point(73, 149);
			this.creatortextbox.Name = "creatortextbox";
			this.creatortextbox.Size = new System.Drawing.Size(100, 21);
			this.creatortextbox.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 177);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 12);
			this.label6.TabIndex = 12;
			this.label6.Text = "Version";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 204);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 12);
			this.label7.TabIndex = 13;
			this.label7.Text = "Source";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 233);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 12);
			this.label8.TabIndex = 14;
			this.label8.Text = "Tags";
			// 
			// versiontextbox
			// 
			this.versiontextbox.Location = new System.Drawing.Point(73, 177);
			this.versiontextbox.Name = "versiontextbox";
			this.versiontextbox.Size = new System.Drawing.Size(100, 21);
			this.versiontextbox.TabIndex = 15;
			// 
			// sourcetextbox
			// 
			this.sourcetextbox.Location = new System.Drawing.Point(73, 204);
			this.sourcetextbox.Name = "sourcetextbox";
			this.sourcetextbox.Size = new System.Drawing.Size(100, 21);
			this.sourcetextbox.TabIndex = 16;
			// 
			// tagstextbox
			// 
			this.tagstextbox.Location = new System.Drawing.Point(73, 233);
			this.tagstextbox.Name = "tagstextbox";
			this.tagstextbox.Size = new System.Drawing.Size(100, 21);
			this.tagstextbox.TabIndex = 17;
			// 
			// createbutton
			// 
			this.createbutton.Location = new System.Drawing.Point(249, 97);
			this.createbutton.Name = "createbutton";
			this.createbutton.Size = new System.Drawing.Size(112, 157);
			this.createbutton.TabIndex = 18;
			this.createbutton.Text = "생성";
			this.createbutton.UseVisualStyleBackColor = true;
			this.createbutton.Click += new System.EventHandler(this.createbutton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "*.mp3";
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "*.osu";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(180, 45);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(21, 12);
			this.label9.TabIndex = 19;
			this.label9.Text = "HP";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(179, 71);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(22, 12);
			this.label10.TabIndex = 20;
			this.label10.Text = "CS";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(180, 97);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(21, 12);
			this.label11.TabIndex = 21;
			this.label11.Text = "AR";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(180, 124);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(22, 12);
			this.label12.TabIndex = 22;
			this.label12.Text = "OD";
			// 
			// hpcombobox
			// 
			this.hpcombobox.FormattingEnabled = true;
			this.hpcombobox.Items.AddRange(new object[] {
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"10"});
			this.hpcombobox.Location = new System.Drawing.Point(206, 42);
			this.hpcombobox.Name = "hpcombobox";
			this.hpcombobox.Size = new System.Drawing.Size(37, 20);
			this.hpcombobox.TabIndex = 23;
			// 
			// cscombobox
			// 
			this.cscombobox.FormattingEnabled = true;
			this.cscombobox.Items.AddRange(new object[] {
			"2",
			"3",
			"4",
			"5",
			"6",
			"7"});
			this.cscombobox.Location = new System.Drawing.Point(206, 68);
			this.cscombobox.Name = "cscombobox";
			this.cscombobox.Size = new System.Drawing.Size(37, 20);
			this.cscombobox.TabIndex = 24;
			// 
			// arcombobox
			// 
			this.arcombobox.FormattingEnabled = true;
			this.arcombobox.Items.AddRange(new object[] {
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"10"});
			this.arcombobox.Location = new System.Drawing.Point(206, 94);
			this.arcombobox.Name = "arcombobox";
			this.arcombobox.Size = new System.Drawing.Size(37, 20);
			this.arcombobox.TabIndex = 25;
			// 
			// odcombobox
			// 
			this.odcombobox.FormattingEnabled = true;
			this.odcombobox.Items.AddRange(new object[] {
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"10"});
			this.odcombobox.Location = new System.Drawing.Point(206, 120);
			this.odcombobox.Name = "odcombobox";
			this.odcombobox.Size = new System.Drawing.Size(37, 20);
			this.odcombobox.TabIndex = 26;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(180, 151);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(24, 12);
			this.label13.TabIndex = 27;
			this.label13.Text = "SM";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(175, 179);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(29, 12);
			this.label14.TabIndex = 28;
			this.label14.Text = "STR";
			// 
			// smtextbox
			// 
			this.smtextbox.Location = new System.Drawing.Point(206, 147);
			this.smtextbox.Name = "smtextbox";
			this.smtextbox.Size = new System.Drawing.Size(37, 21);
			this.smtextbox.TabIndex = 29;
			// 
			// strcombobox
			// 
			this.strcombobox.FormattingEnabled = true;
			this.strcombobox.Items.AddRange(new object[] {
			"1",
			"2",
			"3",
			"4"});
			this.strcombobox.Location = new System.Drawing.Point(206, 175);
			this.strcombobox.Name = "strcombobox";
			this.strcombobox.Size = new System.Drawing.Size(37, 20);
			this.strcombobox.TabIndex = 30;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(251, 46);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(37, 12);
			this.label15.TabIndex = 31;
			this.label15.Text = "Offset";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(253, 73);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 12);
			this.label16.TabIndex = 32;
			this.label16.Text = "BPM";
			// 
			// offsettextbox
			// 
			this.offsettextbox.Location = new System.Drawing.Point(293, 42);
			this.offsettextbox.Name = "offsettextbox";
			this.offsettextbox.Size = new System.Drawing.Size(61, 21);
			this.offsettextbox.TabIndex = 33;
			// 
			// bpmtextbox
			// 
			this.bpmtextbox.Location = new System.Drawing.Point(293, 69);
			this.bpmtextbox.Name = "bpmtextbox";
			this.bpmtextbox.Size = new System.Drawing.Size(61, 21);
			this.bpmtextbox.TabIndex = 34;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 259);
			this.Controls.Add(this.bpmtextbox);
			this.Controls.Add(this.offsettextbox);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.strcombobox);
			this.Controls.Add(this.smtextbox);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.odcombobox);
			this.Controls.Add(this.arcombobox);
			this.Controls.Add(this.cscombobox);
			this.Controls.Add(this.hpcombobox);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.createbutton);
			this.Controls.Add(this.tagstextbox);
			this.Controls.Add(this.sourcetextbox);
			this.Controls.Add(this.versiontextbox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.creatortextbox);
			this.Controls.Add(this.artisttextbox);
			this.Controls.Add(this.titletextbox);
			this.Controls.Add(this.beatcombobox);
			this.Controls.Add(this.distancetextbox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.searchingbutton);
			this.Controls.Add(this.musicnametextbox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox musicnametextbox;
		private System.Windows.Forms.Button searchingbutton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox distancetextbox;
		private System.Windows.Forms.ComboBox beatcombobox;
		private System.Windows.Forms.TextBox titletextbox;
		private System.Windows.Forms.TextBox artisttextbox;
		private System.Windows.Forms.TextBox creatortextbox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox versiontextbox;
		private System.Windows.Forms.TextBox sourcetextbox;
		private System.Windows.Forms.TextBox tagstextbox;
		private System.Windows.Forms.Button createbutton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox hpcombobox;
		private System.Windows.Forms.ComboBox cscombobox;
		private System.Windows.Forms.ComboBox arcombobox;
		private System.Windows.Forms.ComboBox odcombobox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox smtextbox;
		private System.Windows.Forms.ComboBox strcombobox;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox offsettextbox;
		private System.Windows.Forms.TextBox bpmtextbox;
	}
}