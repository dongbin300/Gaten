namespace Gaten.GameTool.osu.osuBeatmapSpeedChanger
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
            this.beatmapTextBox = new System.Windows.Forms.TextBox();
            this.beatmapListBox = new System.Windows.Forms.ListBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.tempoValueTextBox = new System.Windows.Forms.NumericUpDown();
            this.osuPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tempoValueTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // beatmapTextBox
            // 
            this.beatmapTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.beatmapTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beatmapTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.beatmapTextBox.Location = new System.Drawing.Point(16, 15);
            this.beatmapTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.beatmapTextBox.Name = "beatmapTextBox";
            this.beatmapTextBox.Size = new System.Drawing.Size(897, 23);
            this.beatmapTextBox.TabIndex = 0;
            this.beatmapTextBox.TextChanged += new System.EventHandler(this.beatmapTextBox_TextChanged);
            // 
            // beatmapListBox
            // 
            this.beatmapListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.beatmapListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.beatmapListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.beatmapListBox.FormattingEnabled = true;
            this.beatmapListBox.ItemHeight = 35;
            this.beatmapListBox.Location = new System.Drawing.Point(16, 46);
            this.beatmapListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.beatmapListBox.Name = "beatmapListBox";
            this.beatmapListBox.Size = new System.Drawing.Size(897, 669);
            this.beatmapListBox.TabIndex = 1;
            this.beatmapListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.beatmapListBox_DrawItem);
            this.beatmapListBox.SelectedIndexChanged += new System.EventHandler(this.beatmapListBox_SelectedIndexChanged);
            // 
            // convertButton
            // 
            this.convertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.convertButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.convertButton.Location = new System.Drawing.Point(922, 649);
            this.convertButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(277, 66);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "변환";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // tempoValueTextBox
            // 
            this.tempoValueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.tempoValueTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.tempoValueTextBox.Location = new System.Drawing.Point(1128, 610);
            this.tempoValueTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tempoValueTextBox.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.tempoValueTextBox.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.tempoValueTextBox.Name = "tempoValueTextBox";
            this.tempoValueTextBox.Size = new System.Drawing.Size(71, 26);
            this.tempoValueTextBox.TabIndex = 3;
            this.tempoValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tempoValueTextBox.ValueChanged += new System.EventHandler(this.tempoValueTextBox_ValueChanged);
            // 
            // osuPanel
            // 
            this.osuPanel.AllowDrop = true;
            this.osuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.osuPanel.Location = new System.Drawing.Point(919, 15);
            this.osuPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.osuPanel.Name = "osuPanel";
            this.osuPanel.Size = new System.Drawing.Size(280, 280);
            this.osuPanel.TabIndex = 4;
            this.osuPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.osuPanel_DragDrop);
            this.osuPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.osuPanel_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label1.Location = new System.Drawing.Point(933, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "스피드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label2.Location = new System.Drawing.Point(933, 578);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "배속";
            // 
            // rateLabel
            // 
            this.rateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.rateLabel.Location = new System.Drawing.Point(1128, 578);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(71, 18);
            this.rateLabel.TabIndex = 5;
            this.rateLabel.Text = "x1.00";
            this.rateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label3.Location = new System.Drawing.Point(919, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "osu 설치 경로 연동하기!\r\nosu.exe 파일을 위에다가 끌어 놓아주세요!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(1212, 729);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.osuPanel);
            this.Controls.Add(this.tempoValueTextBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.beatmapListBox);
            this.Controls.Add(this.beatmapTextBox);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "osuSpeed!";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tempoValueTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox beatmapTextBox;
        private System.Windows.Forms.ListBox beatmapListBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.NumericUpDown tempoValueTextBox;
        private System.Windows.Forms.Panel osuPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.Label label3;
    }
}