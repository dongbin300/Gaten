namespace Gaten.GameTool.osu.Mania726
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.osuTextBox = new System.Windows.Forms.TextBox();
            this.osuFindButton = new System.Windows.Forms.Button();
            this.exceptkeyButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moveButton = new System.Windows.Forms.RadioButton();
            this.removeButton = new System.Windows.Forms.RadioButton();
            this.exceptkeyButton2 = new System.Windows.Forms.RadioButton();
            this.exceptkeyButton3 = new System.Windows.Forms.RadioButton();
            this.exceptkeyButton4 = new System.Windows.Forms.RadioButton();
            this.exceptkeyButton5 = new System.Windows.Forms.RadioButton();
            this.exceptkeyButton6 = new System.Windows.Forms.RadioButton();
            this.exceptkeyButton7 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.convertButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "OSU 파일";
            // 
            // osuTextBox
            // 
            this.osuTextBox.Location = new System.Drawing.Point(104, 18);
            this.osuTextBox.Name = "osuTextBox";
            this.osuTextBox.ReadOnly = true;
            this.osuTextBox.Size = new System.Drawing.Size(372, 27);
            this.osuTextBox.TabIndex = 1;
            // 
            // osuFindButton
            // 
            this.osuFindButton.Location = new System.Drawing.Point(482, 18);
            this.osuFindButton.Name = "osuFindButton";
            this.osuFindButton.Size = new System.Drawing.Size(78, 27);
            this.osuFindButton.TabIndex = 2;
            this.osuFindButton.Text = "찾아보기";
            this.osuFindButton.UseVisualStyleBackColor = true;
            this.osuFindButton.Click += new System.EventHandler(this.osuFindButton_Click);
            // 
            // exceptkeyButton1
            // 
            this.exceptkeyButton1.AutoSize = true;
            this.exceptkeyButton1.Location = new System.Drawing.Point(6, 26);
            this.exceptkeyButton1.Name = "exceptkeyButton1";
            this.exceptkeyButton1.Size = new System.Drawing.Size(35, 24);
            this.exceptkeyButton1.TabIndex = 3;
            this.exceptkeyButton1.Text = "1";
            this.exceptkeyButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exceptkeyButton7);
            this.groupBox1.Controls.Add(this.exceptkeyButton6);
            this.groupBox1.Controls.Add(this.exceptkeyButton5);
            this.groupBox1.Controls.Add(this.exceptkeyButton4);
            this.groupBox1.Controls.Add(this.exceptkeyButton3);
            this.groupBox1.Controls.Add(this.exceptkeyButton2);
            this.groupBox1.Controls.Add(this.exceptkeyButton1);
            this.groupBox1.Location = new System.Drawing.Point(17, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 239);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "제외버튼";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.moveButton);
            this.groupBox2.Controls.Add(this.removeButton);
            this.groupBox2.Location = new System.Drawing.Point(134, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "제외방식";
            // 
            // moveButton
            // 
            this.moveButton.AutoSize = true;
            this.moveButton.Enabled = false;
            this.moveButton.Location = new System.Drawing.Point(6, 56);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(152, 24);
            this.moveButton.TabIndex = 3;
            this.moveButton.Text = "다른버튼으로 이동";
            this.moveButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.AutoSize = true;
            this.removeButton.Checked = true;
            this.removeButton.Location = new System.Drawing.Point(6, 26);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(57, 24);
            this.removeButton.TabIndex = 3;
            this.removeButton.TabStop = true;
            this.removeButton.Text = "제거";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // exceptkeyButton2
            // 
            this.exceptkeyButton2.AutoSize = true;
            this.exceptkeyButton2.Location = new System.Drawing.Point(6, 56);
            this.exceptkeyButton2.Name = "exceptkeyButton2";
            this.exceptkeyButton2.Size = new System.Drawing.Size(35, 24);
            this.exceptkeyButton2.TabIndex = 3;
            this.exceptkeyButton2.Text = "2";
            this.exceptkeyButton2.UseVisualStyleBackColor = true;
            // 
            // exceptkeyButton3
            // 
            this.exceptkeyButton3.AutoSize = true;
            this.exceptkeyButton3.Location = new System.Drawing.Point(6, 86);
            this.exceptkeyButton3.Name = "exceptkeyButton3";
            this.exceptkeyButton3.Size = new System.Drawing.Size(35, 24);
            this.exceptkeyButton3.TabIndex = 3;
            this.exceptkeyButton3.Text = "3";
            this.exceptkeyButton3.UseVisualStyleBackColor = true;
            // 
            // exceptkeyButton4
            // 
            this.exceptkeyButton4.AutoSize = true;
            this.exceptkeyButton4.Checked = true;
            this.exceptkeyButton4.Location = new System.Drawing.Point(6, 116);
            this.exceptkeyButton4.Name = "exceptkeyButton4";
            this.exceptkeyButton4.Size = new System.Drawing.Size(35, 24);
            this.exceptkeyButton4.TabIndex = 3;
            this.exceptkeyButton4.TabStop = true;
            this.exceptkeyButton4.Text = "4";
            this.exceptkeyButton4.UseVisualStyleBackColor = true;
            // 
            // exceptkeyButton5
            // 
            this.exceptkeyButton5.AutoSize = true;
            this.exceptkeyButton5.Location = new System.Drawing.Point(6, 146);
            this.exceptkeyButton5.Name = "exceptkeyButton5";
            this.exceptkeyButton5.Size = new System.Drawing.Size(35, 24);
            this.exceptkeyButton5.TabIndex = 3;
            this.exceptkeyButton5.Text = "5";
            this.exceptkeyButton5.UseVisualStyleBackColor = true;
            // 
            // exceptkeyButton6
            // 
            this.exceptkeyButton6.AutoSize = true;
            this.exceptkeyButton6.Location = new System.Drawing.Point(6, 176);
            this.exceptkeyButton6.Name = "exceptkeyButton6";
            this.exceptkeyButton6.Size = new System.Drawing.Size(35, 24);
            this.exceptkeyButton6.TabIndex = 3;
            this.exceptkeyButton6.Text = "6";
            this.exceptkeyButton6.UseVisualStyleBackColor = true;
            // 
            // exceptkeyButton7
            // 
            this.exceptkeyButton7.AutoSize = true;
            this.exceptkeyButton7.Location = new System.Drawing.Point(6, 206);
            this.exceptkeyButton7.Name = "exceptkeyButton7";
            this.exceptkeyButton7.Size = new System.Drawing.Size(35, 24);
            this.exceptkeyButton7.TabIndex = 3;
            this.exceptkeyButton7.Text = "7";
            this.exceptkeyButton7.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(330, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 230);
            this.panel1.TabIndex = 5;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(134, 181);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(173, 126);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "변환";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.osuFindButton);
            this.Controls.Add(this.osuTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "osu!mania 7K to 6K Converter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox osuTextBox;
        private System.Windows.Forms.Button osuFindButton;
        private System.Windows.Forms.RadioButton exceptkeyButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton exceptkeyButton7;
        private System.Windows.Forms.RadioButton exceptkeyButton6;
        private System.Windows.Forms.RadioButton exceptkeyButton5;
        private System.Windows.Forms.RadioButton exceptkeyButton4;
        private System.Windows.Forms.RadioButton exceptkeyButton3;
        private System.Windows.Forms.RadioButton exceptkeyButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton moveButton;
        private System.Windows.Forms.RadioButton removeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button convertButton;
    }
}