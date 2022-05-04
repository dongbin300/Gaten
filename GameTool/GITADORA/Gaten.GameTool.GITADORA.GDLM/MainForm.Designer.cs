namespace Gaten.GameTool.GITADORA.GDLM
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.fumenPanel = new System.Windows.Forms.Panel();
            this.ignoreLineCheckBox = new System.Windows.Forms.CheckBox();
            this.phraseTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createPhraseButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.zoomNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.removePhraseButton = new System.Windows.Forms.Button();
            this.flipCheckBox = new System.Windows.Forms.CheckBox();
            this.phraseNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.phrasePositionTextBox = new System.Windows.Forms.TextBox();
            this.phraseDivisionTextBox = new System.Windows.Forms.TextBox();
            this.addPhraseButton = new System.Windows.Forms.Button();
            this.replacePhraseButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.saveClipboardButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // fumenPanel
            // 
            this.fumenPanel.AutoScroll = true;
            this.fumenPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.fumenPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fumenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fumenPanel.Location = new System.Drawing.Point(12, 15);
            this.fumenPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fumenPanel.MaximumSize = new System.Drawing.Size(620, 837);
            this.fumenPanel.Name = "fumenPanel";
            this.fumenPanel.Size = new System.Drawing.Size(620, 837);
            this.fumenPanel.TabIndex = 0;
            // 
            // ignoreLineCheckBox
            // 
            this.ignoreLineCheckBox.AutoSize = true;
            this.ignoreLineCheckBox.Checked = true;
            this.ignoreLineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreLineCheckBox.Location = new System.Drawing.Point(6, 25);
            this.ignoreLineCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ignoreLineCheckBox.Name = "ignoreLineCheckBox";
            this.ignoreLineCheckBox.Size = new System.Drawing.Size(78, 19);
            this.ignoreLineCheckBox.TabIndex = 1;
            this.ignoreLineCheckBox.Text = "라인 무시";
            this.ignoreLineCheckBox.UseVisualStyleBackColor = true;
            // 
            // phraseTextBox
            // 
            this.phraseTextBox.Location = new System.Drawing.Point(6, 25);
            this.phraseTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.phraseTextBox.Name = "phraseTextBox";
            this.phraseTextBox.Size = new System.Drawing.Size(35, 23);
            this.phraseTextBox.TabIndex = 2;
            this.phraseTextBox.Text = "4";
            this.phraseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "마디";
            // 
            // createPhraseButton
            // 
            this.createPhraseButton.Location = new System.Drawing.Point(6, 59);
            this.createPhraseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createPhraseButton.Name = "createPhraseButton";
            this.createPhraseButton.Size = new System.Drawing.Size(68, 29);
            this.createPhraseButton.TabIndex = 4;
            this.createPhraseButton.Text = "생성";
            this.createPhraseButton.UseVisualStyleBackColor = true;
            this.createPhraseButton.Click += new System.EventHandler(this.createPhraseButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(6, 76);
            this.saveFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(139, 44);
            this.saveFileButton.TabIndex = 4;
            this.saveFileButton.Text = "파일로 저장";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // zoomNumeric
            // 
            this.zoomNumeric.DecimalPlaces = 1;
            this.zoomNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zoomNumeric.Location = new System.Drawing.Point(6, 52);
            this.zoomNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zoomNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomNumeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.zoomNumeric.Name = "zoomNumeric";
            this.zoomNumeric.Size = new System.Drawing.Size(58, 23);
            this.zoomNumeric.TabIndex = 5;
            this.zoomNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zoomNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.zoomNumeric.ValueChanged += new System.EventHandler(this.zoomNumeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "배 확대";
            // 
            // removePhraseButton
            // 
            this.removePhraseButton.Location = new System.Drawing.Point(77, 59);
            this.removePhraseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.removePhraseButton.Name = "removePhraseButton";
            this.removePhraseButton.Size = new System.Drawing.Size(68, 29);
            this.removePhraseButton.TabIndex = 4;
            this.removePhraseButton.Text = "제거";
            this.removePhraseButton.UseVisualStyleBackColor = true;
            this.removePhraseButton.Click += new System.EventHandler(this.removePhraseButton_Click);
            // 
            // flipCheckBox
            // 
            this.flipCheckBox.AutoSize = true;
            this.flipCheckBox.Location = new System.Drawing.Point(6, 25);
            this.flipCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flipCheckBox.Name = "flipCheckBox";
            this.flipCheckBox.Size = new System.Drawing.Size(78, 19);
            this.flipCheckBox.TabIndex = 6;
            this.flipCheckBox.Text = "상하 반전";
            this.flipCheckBox.UseVisualStyleBackColor = true;
            this.flipCheckBox.CheckedChanged += new System.EventHandler(this.flipCheckBox_CheckedChanged);
            // 
            // phraseNumberTextBox
            // 
            this.phraseNumberTextBox.Location = new System.Drawing.Point(49, 25);
            this.phraseNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.phraseNumberTextBox.Name = "phraseNumberTextBox";
            this.phraseNumberTextBox.Size = new System.Drawing.Size(35, 23);
            this.phraseNumberTextBox.TabIndex = 2;
            this.phraseNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "마디 #";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ignoreLineCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(638, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(151, 59);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Path파일";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flipCheckBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.zoomNumeric);
            this.groupBox2.Location = new System.Drawing.Point(638, 112);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(151, 92);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "보기";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.phraseTextBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.createPhraseButton);
            this.groupBox3.Controls.Add(this.removePhraseButton);
            this.groupBox3.Location = new System.Drawing.Point(638, 212);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(151, 98);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "기본 마디";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.phrasePositionTextBox);
            this.groupBox4.Controls.Add(this.phraseDivisionTextBox);
            this.groupBox4.Controls.Add(this.addPhraseButton);
            this.groupBox4.Controls.Add(this.replacePhraseButton);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.phraseNumberTextBox);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(638, 318);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(151, 158);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "마디 편집";
            // 
            // phrasePositionTextBox
            // 
            this.phrasePositionTextBox.Location = new System.Drawing.Point(6, 121);
            this.phrasePositionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.phrasePositionTextBox.Name = "phrasePositionTextBox";
            this.phrasePositionTextBox.Size = new System.Drawing.Size(35, 23);
            this.phrasePositionTextBox.TabIndex = 2;
            this.phrasePositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // phraseDivisionTextBox
            // 
            this.phraseDivisionTextBox.Location = new System.Drawing.Point(6, 88);
            this.phraseDivisionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.phraseDivisionTextBox.Name = "phraseDivisionTextBox";
            this.phraseDivisionTextBox.Size = new System.Drawing.Size(35, 23);
            this.phraseDivisionTextBox.TabIndex = 2;
            this.phraseDivisionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addPhraseButton
            // 
            this.addPhraseButton.Location = new System.Drawing.Point(77, 121);
            this.addPhraseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addPhraseButton.Name = "addPhraseButton";
            this.addPhraseButton.Size = new System.Drawing.Size(68, 29);
            this.addPhraseButton.TabIndex = 4;
            this.addPhraseButton.Text = "추가";
            this.addPhraseButton.UseVisualStyleBackColor = true;
            this.addPhraseButton.Click += new System.EventHandler(this.addPhraseButton_Click);
            // 
            // replacePhraseButton
            // 
            this.replacePhraseButton.Location = new System.Drawing.Point(77, 88);
            this.replacePhraseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.replacePhraseButton.Name = "replacePhraseButton";
            this.replacePhraseButton.Size = new System.Drawing.Size(68, 29);
            this.replacePhraseButton.TabIndex = 4;
            this.replacePhraseButton.Text = "변경";
            this.replacePhraseButton.UseVisualStyleBackColor = true;
            this.replacePhraseButton.Click += new System.EventHandler(this.replacePhraseButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "위치";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "마디";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.saveClipboardButton);
            this.groupBox5.Controls.Add(this.saveFileButton);
            this.groupBox5.Location = new System.Drawing.Point(638, 721);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(151, 131);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "마디 데이터 출력";
            // 
            // saveClipboardButton
            // 
            this.saveClipboardButton.Location = new System.Drawing.Point(6, 25);
            this.saveClipboardButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveClipboardButton.Name = "saveClipboardButton";
            this.saveClipboardButton.Size = new System.Drawing.Size(139, 44);
            this.saveClipboardButton.TabIndex = 4;
            this.saveClipboardButton.Text = "클립보드에 저장";
            this.saveClipboardButton.UseVisualStyleBackColor = true;
            this.saveClipboardButton.Click += new System.EventHandler(this.saveClipboardButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.White;
            this.helpButton.FlatAppearance.BorderSize = 0;
            this.helpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Location = new System.Drawing.Point(766, 15);
            this.helpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(23, 29);
            this.helpButton.TabIndex = 8;
            this.helpButton.Text = "?";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 869);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fumenPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "GDLM";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fumenPanel;
        private System.Windows.Forms.CheckBox ignoreLineCheckBox;
        private System.Windows.Forms.TextBox phraseTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createPhraseButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.NumericUpDown zoomNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removePhraseButton;
        private System.Windows.Forms.CheckBox flipCheckBox;
        private System.Windows.Forms.TextBox phraseNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox phraseDivisionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button saveClipboardButton;
        private System.Windows.Forms.TextBox phrasePositionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button addPhraseButton;
        private System.Windows.Forms.Button replacePhraseButton;
    }
}