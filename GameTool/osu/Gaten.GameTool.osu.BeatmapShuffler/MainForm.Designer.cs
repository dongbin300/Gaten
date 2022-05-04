namespace Gaten.GameTool.osu.BeatmapShuffler
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
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.xrange = new System.Windows.Forms.TextBox();
			this.yrange = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(447, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(83, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "찾아보기...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "*.osu";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "osu 파일|*.osu";
			this.openFileDialog1.RestoreDirectory = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(429, 21);
			this.textBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "x축 범위 (0<x<256)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 83);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "y축 범위 (0<y<192)";
			// 
			// xrange
			// 
			this.xrange.Location = new System.Drawing.Point(129, 49);
			this.xrange.MaxLength = 3;
			this.xrange.Name = "xrange";
			this.xrange.Size = new System.Drawing.Size(30, 21);
			this.xrange.TabIndex = 4;
			// 
			// yrange
			// 
			this.yrange.Location = new System.Drawing.Point(129, 83);
			this.yrange.MaxLength = 3;
			this.yrange.Name = "yrange";
			this.yrange.Size = new System.Drawing.Size(30, 21);
			this.yrange.TabIndex = 5;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(176, 49);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(170, 55);
			this.button2.TabIndex = 6;
			this.button2.Text = "변환";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "*.osu";
			this.saveFileDialog1.Filter = "osu 파일|*.osu";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(360, 49);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(170, 55);
			this.button3.TabIndex = 7;
			this.button3.Text = "리셋";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 113);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.yrange);
			this.Controls.Add(this.xrange);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "osu! Beatmap Shuffler v1.0 by Gaten";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox xrange;
		private System.Windows.Forms.TextBox yrange;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button button3;
	}
}