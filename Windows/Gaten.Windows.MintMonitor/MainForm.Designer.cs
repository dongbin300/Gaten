namespace Gaten.Windows.MintMonitor
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WeatherText = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StockText = new System.Windows.Forms.Label();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.ColorPickButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BadukButtonChange = new System.Windows.Forms.Button();
            this.BadukButton12 = new System.Windows.Forms.Button();
            this.BadukButton11 = new System.Windows.Forms.Button();
            this.BadukButton10 = new System.Windows.Forms.Button();
            this.BadukButton9 = new System.Windows.Forms.Button();
            this.BadukButton8 = new System.Windows.Forms.Button();
            this.BadukButton7 = new System.Windows.Forms.Button();
            this.BadukButton6 = new System.Windows.Forms.Button();
            this.BadukButton5 = new System.Windows.Forms.Button();
            this.BadukButton4 = new System.Windows.Forms.Button();
            this.BadukButton3 = new System.Windows.Forms.Button();
            this.BadukButton2 = new System.Windows.Forms.Button();
            this.BadukButton1 = new System.Windows.Forms.Button();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.ClockText = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WeatherText);
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(169, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "날씨";
            // 
            // WeatherText
            // 
            this.WeatherText.AutoSize = true;
            this.WeatherText.Location = new System.Drawing.Point(8, 27);
            this.WeatherText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WeatherText.Name = "WeatherText";
            this.WeatherText.Size = new System.Drawing.Size(69, 21);
            this.WeatherText.TabIndex = 0;
            this.WeatherText.Text = "weather";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StockText);
            this.groupBox2.Location = new System.Drawing.Point(15, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "주식";
            // 
            // StockText
            // 
            this.StockText.AutoSize = true;
            this.StockText.Location = new System.Drawing.Point(8, 25);
            this.StockText.Name = "StockText";
            this.StockText.Size = new System.Drawing.Size(49, 21);
            this.StockText.TabIndex = 0;
            this.StockText.Text = "stock";
            // 
            // ColorDialog
            // 
            this.ColorDialog.AnyColor = true;
            this.ColorDialog.FullOpen = true;
            // 
            // ColorPickButton
            // 
            this.ColorPickButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ColorPickButton.BackgroundImage")));
            this.ColorPickButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ColorPickButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorPickButton.Location = new System.Drawing.Point(263, 17);
            this.ColorPickButton.Margin = new System.Windows.Forms.Padding(10);
            this.ColorPickButton.Name = "ColorPickButton";
            this.ColorPickButton.Padding = new System.Windows.Forms.Padding(5);
            this.ColorPickButton.Size = new System.Drawing.Size(32, 32);
            this.ColorPickButton.TabIndex = 2;
            this.ColorPickButton.UseVisualStyleBackColor = true;
            this.ColorPickButton.Click += new System.EventHandler(this.ColorPickButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BadukButtonChange);
            this.groupBox3.Controls.Add(this.BadukButton12);
            this.groupBox3.Controls.Add(this.BadukButton11);
            this.groupBox3.Controls.Add(this.BadukButton10);
            this.groupBox3.Controls.Add(this.BadukButton9);
            this.groupBox3.Controls.Add(this.BadukButton8);
            this.groupBox3.Controls.Add(this.BadukButton7);
            this.groupBox3.Controls.Add(this.BadukButton6);
            this.groupBox3.Controls.Add(this.BadukButton5);
            this.groupBox3.Controls.Add(this.BadukButton4);
            this.groupBox3.Controls.Add(this.BadukButton3);
            this.groupBox3.Controls.Add(this.BadukButton2);
            this.groupBox3.Controls.Add(this.BadukButton1);
            this.groupBox3.Location = new System.Drawing.Point(15, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 425);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "바둑";
            // 
            // BadukButtonChange
            // 
            this.BadukButtonChange.Location = new System.Drawing.Point(205, 379);
            this.BadukButtonChange.Name = "BadukButtonChange";
            this.BadukButtonChange.Size = new System.Drawing.Size(69, 33);
            this.BadukButtonChange.TabIndex = 0;
            this.BadukButtonChange.Text = "韩↔中";
            this.BadukButtonChange.UseVisualStyleBackColor = true;
            this.BadukButtonChange.Click += new System.EventHandler(this.BadukButtonChange_Click);
            // 
            // BadukButton12
            // 
            this.BadukButton12.Location = new System.Drawing.Point(144, 379);
            this.BadukButton12.Name = "BadukButton12";
            this.BadukButton12.Size = new System.Drawing.Size(55, 33);
            this.BadukButton12.TabIndex = 0;
            this.BadukButton12.Text = "14级";
            this.BadukButton12.UseVisualStyleBackColor = true;
            this.BadukButton12.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton11
            // 
            this.BadukButton11.Location = new System.Drawing.Point(83, 379);
            this.BadukButton11.Name = "BadukButton11";
            this.BadukButton11.Size = new System.Drawing.Size(55, 33);
            this.BadukButton11.TabIndex = 0;
            this.BadukButton11.Text = "19路";
            this.BadukButton11.UseVisualStyleBackColor = true;
            this.BadukButton11.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton10
            // 
            this.BadukButton10.Location = new System.Drawing.Point(8, 379);
            this.BadukButton10.Name = "BadukButton10";
            this.BadukButton10.Size = new System.Drawing.Size(69, 33);
            this.BadukButton10.TabIndex = 0;
            this.BadukButton10.Text = "3到5段";
            this.BadukButton10.UseVisualStyleBackColor = true;
            this.BadukButton10.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton9
            // 
            this.BadukButton9.Location = new System.Drawing.Point(8, 340);
            this.BadukButton9.Name = "BadukButton9";
            this.BadukButton9.Size = new System.Drawing.Size(266, 33);
            this.BadukButton9.TabIndex = 0;
            this.BadukButton9.Text = "快点吧，我等到花儿也谢了！";
            this.BadukButton9.UseVisualStyleBackColor = true;
            this.BadukButton9.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton8
            // 
            this.BadukButton8.Location = new System.Drawing.Point(8, 301);
            this.BadukButton8.Name = "BadukButton8";
            this.BadukButton8.Size = new System.Drawing.Size(266, 33);
            this.BadukButton8.TabIndex = 0;
            this.BadukButton8.Text = "不要走，决战到天亮！";
            this.BadukButton8.UseVisualStyleBackColor = true;
            this.BadukButton8.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton7
            // 
            this.BadukButton7.Location = new System.Drawing.Point(8, 262);
            this.BadukButton7.Name = "BadukButton7";
            this.BadukButton7.Size = new System.Drawing.Size(266, 33);
            this.BadukButton7.TabIndex = 0;
            this.BadukButton7.Text = "太慢了。";
            this.BadukButton7.UseVisualStyleBackColor = true;
            this.BadukButton7.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton6
            // 
            this.BadukButton6.Location = new System.Drawing.Point(8, 223);
            this.BadukButton6.Name = "BadukButton6";
            this.BadukButton6.Size = new System.Drawing.Size(266, 33);
            this.BadukButton6.TabIndex = 0;
            this.BadukButton6.Text = "你还在吗？请落子。";
            this.BadukButton6.UseVisualStyleBackColor = true;
            this.BadukButton6.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton5
            // 
            this.BadukButton5.Location = new System.Drawing.Point(8, 184);
            this.BadukButton5.Name = "BadukButton5";
            this.BadukButton5.Size = new System.Drawing.Size(266, 33);
            this.BadukButton5.TabIndex = 0;
            this.BadukButton5.Text = "有没有人下棋？";
            this.BadukButton5.UseVisualStyleBackColor = true;
            this.BadukButton5.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton4
            // 
            this.BadukButton4.Location = new System.Drawing.Point(8, 145);
            this.BadukButton4.Name = "BadukButton4";
            this.BadukButton4.Size = new System.Drawing.Size(266, 33);
            this.BadukButton4.TabIndex = 0;
            this.BadukButton4.Text = "有人下棋吗？";
            this.BadukButton4.UseVisualStyleBackColor = true;
            this.BadukButton4.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton3
            // 
            this.BadukButton3.Location = new System.Drawing.Point(8, 106);
            this.BadukButton3.Name = "BadukButton3";
            this.BadukButton3.Size = new System.Drawing.Size(266, 33);
            this.BadukButton3.TabIndex = 0;
            this.BadukButton3.Text = "谁能下棋？";
            this.BadukButton3.UseVisualStyleBackColor = true;
            this.BadukButton3.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton2
            // 
            this.BadukButton2.Location = new System.Drawing.Point(8, 67);
            this.BadukButton2.Name = "BadukButton2";
            this.BadukButton2.Size = new System.Drawing.Size(266, 33);
            this.BadukButton2.TabIndex = 0;
            this.BadukButton2.Text = "有没有人下棋？";
            this.BadukButton2.UseVisualStyleBackColor = true;
            this.BadukButton2.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // BadukButton1
            // 
            this.BadukButton1.Location = new System.Drawing.Point(8, 28);
            this.BadukButton1.Name = "BadukButton1";
            this.BadukButton1.Size = new System.Drawing.Size(266, 33);
            this.BadukButton1.TabIndex = 0;
            this.BadukButton1.Text = "我想下棋，欢迎向我申请对局。";
            this.BadukButton1.UseVisualStyleBackColor = true;
            this.BadukButton1.Click += new System.EventHandler(this.BadukButton_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 60000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // ClockTimer
            // 
            this.ClockTimer.Enabled = true;
            this.ClockTimer.Interval = 1000;
            this.ClockTimer.Tick += new System.EventHandler(this.ClockTimer_Tick);
            // 
            // ClockText
            // 
            this.ClockText.AutoSize = true;
            this.ClockText.Location = new System.Drawing.Point(7, 660);
            this.ClockText.Name = "ClockText";
            this.ClockText.Size = new System.Drawing.Size(48, 21);
            this.ClockText.TabIndex = 4;
            this.ClockText.Text = "clock";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 690);
            this.Controls.Add(this.ClockText);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ColorPickButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "민트 모니터";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label WeatherText;
        private GroupBox groupBox2;
        private Label StockText;
        private ColorDialog ColorDialog;
        private Button ColorPickButton;
        private GroupBox groupBox3;
        private Button BadukButton5;
        private Button BadukButton4;
        private Button BadukButton3;
        private Button BadukButton2;
        private Button BadukButton1;
        private Button BadukButtonChange;
        private Button BadukButton12;
        private Button BadukButton11;
        private Button BadukButton10;
        private Button BadukButton9;
        private Button BadukButton8;
        private Button BadukButton7;
        private Button BadukButton6;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Timer ClockTimer;
        private Label ClockText;
    }
}