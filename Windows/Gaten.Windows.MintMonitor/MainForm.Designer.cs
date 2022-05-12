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
            this.WeatherText = new System.Windows.Forms.Label();
            this.StockText = new System.Windows.Forms.Label();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.ColorPickButton = new System.Windows.Forms.Button();
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
            this.DictListBox = new System.Windows.Forms.ListBox();
            this.DictTextBox = new System.Windows.Forms.TextBox();
            this.HardwarePriceDataGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danawaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceChangeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashChangeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HardwareTextFileButton = new System.Windows.Forms.Button();
            this.checkGroupBox2 = new Gaten.Windows.MintMonitor.CheckGroupBox();
            this.checkGroupBox3 = new Gaten.Windows.MintMonitor.CheckGroupBox();
            this.checkGroupBox4 = new Gaten.Windows.MintMonitor.CheckGroupBox();
            this.checkGroupBox5 = new Gaten.Windows.MintMonitor.CheckGroupBox();
            this.checkGroupBox6 = new Gaten.Windows.MintMonitor.CheckGroupBox();
            this.DiskDriveText = new System.Windows.Forms.Label();
            this.checkGroupBox7 = new Gaten.Windows.MintMonitor.CheckGroupBox();
            this.UnseText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HardwarePriceDataGridView)).BeginInit();
            this.checkGroupBox2.SuspendLayout();
            this.checkGroupBox3.SuspendLayout();
            this.checkGroupBox4.SuspendLayout();
            this.checkGroupBox5.SuspendLayout();
            this.checkGroupBox6.SuspendLayout();
            this.checkGroupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // WeatherText
            // 
            this.WeatherText.AutoSize = true;
            this.WeatherText.Location = new System.Drawing.Point(326, 724);
            this.WeatherText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WeatherText.Name = "WeatherText";
            this.WeatherText.Size = new System.Drawing.Size(69, 21);
            this.WeatherText.TabIndex = 0;
            this.WeatherText.Text = "weather";
            // 
            // StockText
            // 
            this.StockText.AutoSize = true;
            this.StockText.Location = new System.Drawing.Point(7, 25);
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
            this.ClockText.Location = new System.Drawing.Point(15, 724);
            this.ClockText.Name = "ClockText";
            this.ClockText.Size = new System.Drawing.Size(48, 21);
            this.ClockText.TabIndex = 4;
            this.ClockText.Text = "clock";
            // 
            // DictListBox
            // 
            this.DictListBox.FormattingEnabled = true;
            this.DictListBox.ItemHeight = 21;
            this.DictListBox.Location = new System.Drawing.Point(6, 64);
            this.DictListBox.Name = "DictListBox";
            this.DictListBox.Size = new System.Drawing.Size(455, 130);
            this.DictListBox.TabIndex = 1;
            // 
            // DictTextBox
            // 
            this.DictTextBox.Location = new System.Drawing.Point(6, 29);
            this.DictTextBox.Name = "DictTextBox";
            this.DictTextBox.Size = new System.Drawing.Size(455, 29);
            this.DictTextBox.TabIndex = 0;
            this.DictTextBox.TextChanged += new System.EventHandler(this.DictTextBox_TextChanged);
            this.DictTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DictTextBox_KeyDown);
            // 
            // HardwarePriceDataGridView
            // 
            this.HardwarePriceDataGridView.AllowUserToAddRows = false;
            this.HardwarePriceDataGridView.AllowUserToDeleteRows = false;
            this.HardwarePriceDataGridView.AllowUserToOrderColumns = true;
            this.HardwarePriceDataGridView.AllowUserToResizeRows = false;
            this.HardwarePriceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HardwarePriceDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.danawaColumn,
            this.cashColumn,
            this.priceChangeColumn,
            this.cashChangeColumn});
            this.HardwarePriceDataGridView.Location = new System.Drawing.Point(6, 28);
            this.HardwarePriceDataGridView.Name = "HardwarePriceDataGridView";
            this.HardwarePriceDataGridView.ReadOnly = true;
            this.HardwarePriceDataGridView.RowHeadersVisible = false;
            this.HardwarePriceDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.HardwarePriceDataGridView.RowTemplate.Height = 25;
            this.HardwarePriceDataGridView.Size = new System.Drawing.Size(453, 345);
            this.HardwarePriceDataGridView.TabIndex = 6;
            this.HardwarePriceDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HardwarePriceDataGridView_CellDoubleClick);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "이름";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 150;
            // 
            // danawaColumn
            // 
            this.danawaColumn.HeaderText = "가격";
            this.danawaColumn.Name = "danawaColumn";
            this.danawaColumn.ReadOnly = true;
            this.danawaColumn.Width = 70;
            // 
            // cashColumn
            // 
            this.cashColumn.HeaderText = "현금";
            this.cashColumn.Name = "cashColumn";
            this.cashColumn.ReadOnly = true;
            this.cashColumn.Width = 70;
            // 
            // priceChangeColumn
            // 
            this.priceChangeColumn.HeaderText = "가변";
            this.priceChangeColumn.Name = "priceChangeColumn";
            this.priceChangeColumn.ReadOnly = true;
            this.priceChangeColumn.Width = 80;
            // 
            // cashChangeColumn
            // 
            this.cashChangeColumn.HeaderText = "현변";
            this.cashChangeColumn.Name = "cashChangeColumn";
            this.cashChangeColumn.ReadOnly = true;
            this.cashChangeColumn.Width = 80;
            // 
            // HardwareTextFileButton
            // 
            this.HardwareTextFileButton.Location = new System.Drawing.Point(6, 378);
            this.HardwareTextFileButton.Name = "HardwareTextFileButton";
            this.HardwareTextFileButton.Size = new System.Drawing.Size(453, 34);
            this.HardwareTextFileButton.TabIndex = 7;
            this.HardwareTextFileButton.Text = "텍스트 파일로 저장";
            this.HardwareTextFileButton.UseVisualStyleBackColor = true;
            this.HardwareTextFileButton.Click += new System.EventHandler(this.HardwareTextFileButton_Click);
            // 
            // checkGroupBox2
            // 
            this.checkGroupBox2.Controls.Add(this.StockText);
            this.checkGroupBox2.Location = new System.Drawing.Point(15, 118);
            this.checkGroupBox2.Name = "checkGroupBox2";
            this.checkGroupBox2.Size = new System.Drawing.Size(280, 100);
            this.checkGroupBox2.TabIndex = 9;
            this.checkGroupBox2.TabStop = false;
            this.checkGroupBox2.Text = "주식";
            // 
            // checkGroupBox3
            // 
            this.checkGroupBox3.Controls.Add(this.BadukButtonChange);
            this.checkGroupBox3.Controls.Add(this.BadukButton12);
            this.checkGroupBox3.Controls.Add(this.BadukButton1);
            this.checkGroupBox3.Controls.Add(this.BadukButton11);
            this.checkGroupBox3.Controls.Add(this.BadukButton2);
            this.checkGroupBox3.Controls.Add(this.BadukButton10);
            this.checkGroupBox3.Controls.Add(this.BadukButton3);
            this.checkGroupBox3.Controls.Add(this.BadukButton9);
            this.checkGroupBox3.Controls.Add(this.BadukButton4);
            this.checkGroupBox3.Controls.Add(this.BadukButton8);
            this.checkGroupBox3.Controls.Add(this.BadukButton5);
            this.checkGroupBox3.Controls.Add(this.BadukButton7);
            this.checkGroupBox3.Controls.Add(this.BadukButton6);
            this.checkGroupBox3.Location = new System.Drawing.Point(15, 224);
            this.checkGroupBox3.Name = "checkGroupBox3";
            this.checkGroupBox3.Size = new System.Drawing.Size(280, 418);
            this.checkGroupBox3.TabIndex = 9;
            this.checkGroupBox3.TabStop = false;
            this.checkGroupBox3.Text = "바둑";
            // 
            // checkGroupBox4
            // 
            this.checkGroupBox4.Controls.Add(this.DictListBox);
            this.checkGroupBox4.Controls.Add(this.DictTextBox);
            this.checkGroupBox4.Location = new System.Drawing.Point(301, 12);
            this.checkGroupBox4.Name = "checkGroupBox4";
            this.checkGroupBox4.Size = new System.Drawing.Size(467, 206);
            this.checkGroupBox4.TabIndex = 9;
            this.checkGroupBox4.TabStop = false;
            this.checkGroupBox4.Text = "사전";
            // 
            // checkGroupBox5
            // 
            this.checkGroupBox5.Controls.Add(this.HardwarePriceDataGridView);
            this.checkGroupBox5.Controls.Add(this.HardwareTextFileButton);
            this.checkGroupBox5.Location = new System.Drawing.Point(301, 224);
            this.checkGroupBox5.Name = "checkGroupBox5";
            this.checkGroupBox5.Size = new System.Drawing.Size(467, 418);
            this.checkGroupBox5.TabIndex = 9;
            this.checkGroupBox5.TabStop = false;
            this.checkGroupBox5.Text = "하드웨어";
            // 
            // checkGroupBox6
            // 
            this.checkGroupBox6.Controls.Add(this.DiskDriveText);
            this.checkGroupBox6.Location = new System.Drawing.Point(15, 12);
            this.checkGroupBox6.Name = "checkGroupBox6";
            this.checkGroupBox6.Size = new System.Drawing.Size(233, 100);
            this.checkGroupBox6.TabIndex = 10;
            this.checkGroupBox6.TabStop = false;
            this.checkGroupBox6.Text = "용량";
            // 
            // DiskDriveText
            // 
            this.DiskDriveText.AutoSize = true;
            this.DiskDriveText.Location = new System.Drawing.Point(7, 25);
            this.DiskDriveText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DiskDriveText.Name = "DiskDriveText";
            this.DiskDriveText.Size = new System.Drawing.Size(77, 21);
            this.DiskDriveText.TabIndex = 0;
            this.DiskDriveText.Text = "diskDrive";
            // 
            // checkGroupBox7
            // 
            this.checkGroupBox7.Controls.Add(this.UnseText);
            this.checkGroupBox7.Location = new System.Drawing.Point(15, 648);
            this.checkGroupBox7.Name = "checkGroupBox7";
            this.checkGroupBox7.Size = new System.Drawing.Size(753, 73);
            this.checkGroupBox7.TabIndex = 10;
            this.checkGroupBox7.TabStop = false;
            this.checkGroupBox7.Text = "운세";
            // 
            // UnseText
            // 
            this.UnseText.AutoSize = true;
            this.UnseText.Location = new System.Drawing.Point(7, 25);
            this.UnseText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UnseText.Name = "UnseText";
            this.UnseText.Size = new System.Drawing.Size(44, 21);
            this.UnseText.TabIndex = 0;
            this.UnseText.Text = "unse";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 754);
            this.Controls.Add(this.checkGroupBox7);
            this.Controls.Add(this.WeatherText);
            this.Controls.Add(this.checkGroupBox6);
            this.Controls.Add(this.checkGroupBox4);
            this.Controls.Add(this.checkGroupBox5);
            this.Controls.Add(this.checkGroupBox2);
            this.Controls.Add(this.checkGroupBox3);
            this.Controls.Add(this.ClockText);
            this.Controls.Add(this.ColorPickButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.HardwarePriceDataGridView)).EndInit();
            this.checkGroupBox2.ResumeLayout(false);
            this.checkGroupBox2.PerformLayout();
            this.checkGroupBox3.ResumeLayout(false);
            this.checkGroupBox3.PerformLayout();
            this.checkGroupBox4.ResumeLayout(false);
            this.checkGroupBox4.PerformLayout();
            this.checkGroupBox5.ResumeLayout(false);
            this.checkGroupBox5.PerformLayout();
            this.checkGroupBox6.ResumeLayout(false);
            this.checkGroupBox6.PerformLayout();
            this.checkGroupBox7.ResumeLayout(false);
            this.checkGroupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label WeatherText;
        private Label StockText;
        private ColorDialog ColorDialog;
        private Button ColorPickButton;
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
        private ListBox DictListBox;
        private TextBox DictTextBox;
        private DataGridView HardwarePriceDataGridView;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn danawaColumn;
        private DataGridViewTextBoxColumn cashColumn;
        private DataGridViewTextBoxColumn priceChangeColumn;
        private DataGridViewTextBoxColumn cashChangeColumn;
        private Button HardwareTextFileButton;
        private CheckGroupBox checkGroupBox2;
        private CheckGroupBox checkGroupBox3;
        private CheckGroupBox checkGroupBox4;
        private CheckGroupBox checkGroupBox5;
        private CheckGroupBox checkGroupBox6;
        private Label DiskDriveText;
        private CheckGroupBox checkGroupBox7;
        private Label UnseText;
    }
}