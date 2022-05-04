namespace Gaten.Stock.MockTrader
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
            this.SimulateButton = new System.Windows.Forms.Button();
            this.StatusText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DivisionRateTextBox = new System.Windows.Forms.TextBox();
            this.SimulateProgressBar = new System.Windows.Forms.ProgressBar();
            this.TradeLogCheckBox = new System.Windows.Forms.CheckBox();
            this.DayLogCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BinanceDataUpdateText = new System.Windows.Forms.Label();
            this.GetCandleDataButton = new System.Windows.Forms.Button();
            this.GetSymbolDataButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BackTestPeriodTextBox = new System.Windows.Forms.TextBox();
            this.StartDayComboBox = new System.Windows.Forms.ComboBox();
            this.CandleIntervalComboBox = new System.Windows.Forms.ComboBox();
            this.StartMonthComboBox = new System.Windows.Forms.ComboBox();
            this.StartYearComboBox = new System.Windows.Forms.ComboBox();
            this.AllSymbolCheckBox = new System.Windows.Forms.CheckBox();
            this.SymbolComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimulateButton
            // 
            this.SimulateButton.Location = new System.Drawing.Point(382, 200);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(167, 44);
            this.SimulateButton.TabIndex = 0;
            this.SimulateButton.Text = "백테스트";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Location = new System.Drawing.Point(12, 276);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(62, 15);
            this.StatusText.TabIndex = 1;
            this.StatusText.Text = "StatusText";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Amount ($)";
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(6, 37);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(119, 23);
            this.AmountTextBox.TabIndex = 3;
            this.AmountTextBox.Text = "10000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Division Rate (1/n)";
            // 
            // DivisionRateTextBox
            // 
            this.DivisionRateTextBox.Location = new System.Drawing.Point(156, 37);
            this.DivisionRateTextBox.Name = "DivisionRateTextBox";
            this.DivisionRateTextBox.Size = new System.Drawing.Size(119, 23);
            this.DivisionRateTextBox.TabIndex = 3;
            this.DivisionRateTextBox.Text = "20";
            // 
            // SimulateProgressBar
            // 
            this.SimulateProgressBar.Location = new System.Drawing.Point(12, 250);
            this.SimulateProgressBar.Maximum = 10000;
            this.SimulateProgressBar.Name = "SimulateProgressBar";
            this.SimulateProgressBar.Size = new System.Drawing.Size(537, 23);
            this.SimulateProgressBar.Step = 1;
            this.SimulateProgressBar.TabIndex = 4;
            // 
            // TradeLogCheckBox
            // 
            this.TradeLogCheckBox.AutoSize = true;
            this.TradeLogCheckBox.Location = new System.Drawing.Point(6, 47);
            this.TradeLogCheckBox.Name = "TradeLogCheckBox";
            this.TradeLogCheckBox.Size = new System.Drawing.Size(106, 19);
            this.TradeLogCheckBox.TabIndex = 5;
            this.TradeLogCheckBox.Text = "매매 로그 출력";
            this.TradeLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // DayLogCheckBox
            // 
            this.DayLogCheckBox.AutoSize = true;
            this.DayLogCheckBox.Location = new System.Drawing.Point(6, 22);
            this.DayLogCheckBox.Name = "DayLogCheckBox";
            this.DayLogCheckBox.Size = new System.Drawing.Size(106, 19);
            this.DayLogCheckBox.TabIndex = 5;
            this.DayLogCheckBox.Text = "일별 로그 출력";
            this.DayLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BinanceDataUpdateText);
            this.groupBox1.Controls.Add(this.GetCandleDataButton);
            this.groupBox1.Controls.Add(this.GetSymbolDataButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 70);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "바이낸스 데이터";
            // 
            // BinanceDataUpdateText
            // 
            this.BinanceDataUpdateText.AutoSize = true;
            this.BinanceDataUpdateText.Location = new System.Drawing.Point(6, 48);
            this.BinanceDataUpdateText.Name = "BinanceDataUpdateText";
            this.BinanceDataUpdateText.Size = new System.Drawing.Size(62, 15);
            this.BinanceDataUpdateText.TabIndex = 1;
            this.BinanceDataUpdateText.Text = "업데이트: ";
            // 
            // GetCandleDataButton
            // 
            this.GetCandleDataButton.Location = new System.Drawing.Point(119, 22);
            this.GetCandleDataButton.Name = "GetCandleDataButton";
            this.GetCandleDataButton.Size = new System.Drawing.Size(107, 23);
            this.GetCandleDataButton.TabIndex = 0;
            this.GetCandleDataButton.Text = "1분봉 데이터";
            this.GetCandleDataButton.UseVisualStyleBackColor = true;
            this.GetCandleDataButton.Click += new System.EventHandler(this.GetCandleDataButton_Click);
            // 
            // GetSymbolDataButton
            // 
            this.GetSymbolDataButton.Location = new System.Drawing.Point(6, 22);
            this.GetSymbolDataButton.Name = "GetSymbolDataButton";
            this.GetSymbolDataButton.Size = new System.Drawing.Size(107, 23);
            this.GetSymbolDataButton.TabIndex = 0;
            this.GetSymbolDataButton.Text = "심볼 데이터";
            this.GetSymbolDataButton.UseVisualStyleBackColor = true;
            this.GetSymbolDataButton.Click += new System.EventHandler(this.GetSymbolDataButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.BackTestPeriodTextBox);
            this.groupBox2.Controls.Add(this.StartDayComboBox);
            this.groupBox2.Controls.Add(this.CandleIntervalComboBox);
            this.groupBox2.Controls.Add(this.StartMonthComboBox);
            this.groupBox2.Controls.Add(this.StartYearComboBox);
            this.groupBox2.Controls.Add(this.AllSymbolCheckBox);
            this.groupBox2.Controls.Add(this.SymbolComboBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 147);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "백테스트 범위";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "분봉";
            // 
            // BackTestPeriodTextBox
            // 
            this.BackTestPeriodTextBox.Location = new System.Drawing.Point(6, 115);
            this.BackTestPeriodTextBox.Name = "BackTestPeriodTextBox";
            this.BackTestPeriodTextBox.Size = new System.Drawing.Size(62, 23);
            this.BackTestPeriodTextBox.TabIndex = 5;
            this.BackTestPeriodTextBox.Text = "7";
            this.BackTestPeriodTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StartDayComboBox
            // 
            this.StartDayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartDayComboBox.DropDownWidth = 37;
            this.StartDayComboBox.FormattingEnabled = true;
            this.StartDayComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.StartDayComboBox.Location = new System.Drawing.Point(149, 86);
            this.StartDayComboBox.Name = "StartDayComboBox";
            this.StartDayComboBox.Size = new System.Drawing.Size(37, 23);
            this.StartDayComboBox.TabIndex = 4;
            // 
            // CandleIntervalComboBox
            // 
            this.CandleIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CandleIntervalComboBox.FormattingEnabled = true;
            this.CandleIntervalComboBox.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "15",
            "30",
            "60",
            "120",
            "240",
            "360",
            "480",
            "720",
            "1440"});
            this.CandleIntervalComboBox.Location = new System.Drawing.Point(119, 115);
            this.CandleIntervalComboBox.Name = "CandleIntervalComboBox";
            this.CandleIntervalComboBox.Size = new System.Drawing.Size(67, 23);
            this.CandleIntervalComboBox.TabIndex = 4;
            // 
            // StartMonthComboBox
            // 
            this.StartMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartMonthComboBox.FormattingEnabled = true;
            this.StartMonthComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.StartMonthComboBox.Location = new System.Drawing.Point(90, 86);
            this.StartMonthComboBox.Name = "StartMonthComboBox";
            this.StartMonthComboBox.Size = new System.Drawing.Size(37, 23);
            this.StartMonthComboBox.TabIndex = 4;
            // 
            // StartYearComboBox
            // 
            this.StartYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartYearComboBox.FormattingEnabled = true;
            this.StartYearComboBox.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022"});
            this.StartYearComboBox.Location = new System.Drawing.Point(6, 86);
            this.StartYearComboBox.Name = "StartYearComboBox";
            this.StartYearComboBox.Size = new System.Drawing.Size(62, 23);
            this.StartYearComboBox.TabIndex = 4;
            // 
            // AllSymbolCheckBox
            // 
            this.AllSymbolCheckBox.AutoSize = true;
            this.AllSymbolCheckBox.Location = new System.Drawing.Point(114, 18);
            this.AllSymbolCheckBox.Name = "AllSymbolCheckBox";
            this.AllSymbolCheckBox.Size = new System.Drawing.Size(78, 19);
            this.AllSymbolCheckBox.TabIndex = 3;
            this.AllSymbolCheckBox.Text = "모든 코인";
            this.AllSymbolCheckBox.UseVisualStyleBackColor = true;
            this.AllSymbolCheckBox.CheckedChanged += new System.EventHandler(this.AllSymbolCheckBox_CheckedChanged);
            // 
            // SymbolComboBox
            // 
            this.SymbolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SymbolComboBox.FormattingEnabled = true;
            this.SymbolComboBox.Location = new System.Drawing.Point(6, 37);
            this.SymbolComboBox.Name = "SymbolComboBox";
            this.SymbolComboBox.Size = new System.Drawing.Size(180, 23);
            this.SymbolComboBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "일간";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "월";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "년";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "기간";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "코인";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.AmountTextBox);
            this.groupBox3.Controls.Add(this.DivisionRateTextBox);
            this.groupBox3.Location = new System.Drawing.Point(251, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 70);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "자산 운용";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TradeLogCheckBox);
            this.groupBox4.Controls.Add(this.DayLogCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(251, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(125, 147);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "로그";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 303);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SimulateProgressBar);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.SimulateButton);
            this.Name = "MainForm";
            this.Text = "Mock Trader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SimulateButton;
        private Label StatusText;
        private Label label1;
        private TextBox AmountTextBox;
        private Label label2;
        private TextBox DivisionRateTextBox;
        private ProgressBar SimulateProgressBar;
        private CheckBox TradeLogCheckBox;
        private CheckBox DayLogCheckBox;
        private GroupBox groupBox1;
        private Button GetSymbolDataButton;
        private Button GetCandleDataButton;
        private Label BinanceDataUpdateText;
        private GroupBox groupBox2;
        private Label label3;
        private ComboBox StartYearComboBox;
        private CheckBox AllSymbolCheckBox;
        private ComboBox SymbolComboBox;
        private Label label4;
        private TextBox BackTestPeriodTextBox;
        private ComboBox StartDayComboBox;
        private ComboBox StartMonthComboBox;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label9;
        private ComboBox CandleIntervalComboBox;
    }
}