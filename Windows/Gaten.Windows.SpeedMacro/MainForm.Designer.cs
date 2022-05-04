namespace Gaten.Windows.SpeedMacro
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CursorPositionLabel = new System.Windows.Forms.Label();
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.xPosTextBox = new System.Windows.Forms.TextBox();
            this.yPosTextBox = new System.Windows.Forms.TextBox();
            this.ClickButton = new System.Windows.Forms.Button();
            this.DoubleClickButton = new System.Windows.Forms.Button();
            this.ProcedureListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RightClickButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fastInputCheckBox = new System.Windows.Forms.CheckBox();
            this.PressButton = new System.Windows.Forms.Button();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.eachCheckBox = new System.Windows.Forms.CheckBox();
            this.WaitButton = new System.Windows.Forms.Button();
            this.WaitTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewRoutineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoutineSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.RoutineOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StopButton = new System.Windows.Forms.Button();
            this.loopCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CursorPositionLabel
            // 
            this.CursorPositionLabel.AutoSize = true;
            this.CursorPositionLabel.Location = new System.Drawing.Point(420, 9);
            this.CursorPositionLabel.Name = "CursorPositionLabel";
            this.CursorPositionLabel.Size = new System.Drawing.Size(0, 12);
            this.CursorPositionLabel.TabIndex = 0;
            // 
            // tick
            // 
            this.tick.Interval = 10;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // xPosTextBox
            // 
            this.xPosTextBox.Location = new System.Drawing.Point(11, 20);
            this.xPosTextBox.Name = "xPosTextBox";
            this.xPosTextBox.Size = new System.Drawing.Size(48, 21);
            this.xPosTextBox.TabIndex = 1;
            // 
            // yPosTextBox
            // 
            this.yPosTextBox.Location = new System.Drawing.Point(65, 20);
            this.yPosTextBox.Name = "yPosTextBox";
            this.yPosTextBox.Size = new System.Drawing.Size(48, 21);
            this.yPosTextBox.TabIndex = 2;
            // 
            // ClickButton
            // 
            this.ClickButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClickButton.Location = new System.Drawing.Point(119, 20);
            this.ClickButton.Name = "ClickButton";
            this.ClickButton.Size = new System.Drawing.Size(70, 21);
            this.ClickButton.TabIndex = 3;
            this.ClickButton.Text = "클릭";
            this.ClickButton.UseVisualStyleBackColor = true;
            this.ClickButton.Click += new System.EventHandler(this.ClickButton_Click);
            // 
            // DoubleClickButton
            // 
            this.DoubleClickButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoubleClickButton.Location = new System.Drawing.Point(195, 20);
            this.DoubleClickButton.Name = "DoubleClickButton";
            this.DoubleClickButton.Size = new System.Drawing.Size(70, 21);
            this.DoubleClickButton.TabIndex = 4;
            this.DoubleClickButton.Text = "더블";
            this.DoubleClickButton.UseVisualStyleBackColor = true;
            this.DoubleClickButton.Click += new System.EventHandler(this.DoubleClickButton_Click);
            // 
            // ProcedureListBox
            // 
            this.ProcedureListBox.AllowDrop = true;
            this.ProcedureListBox.FormattingEnabled = true;
            this.ProcedureListBox.ItemHeight = 12;
            this.ProcedureListBox.Location = new System.Drawing.Point(12, 27);
            this.ProcedureListBox.Name = "ProcedureListBox";
            this.ProcedureListBox.Size = new System.Drawing.Size(170, 136);
            this.ProcedureListBox.TabIndex = 5;
            this.ProcedureListBox.DoubleClick += new System.EventHandler(this.ProcedureListBox_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RightClickButton);
            this.groupBox1.Controls.Add(this.ClickButton);
            this.groupBox1.Controls.Add(this.xPosTextBox);
            this.groupBox1.Controls.Add(this.DoubleClickButton);
            this.groupBox1.Controls.Add(this.yPosTextBox);
            this.groupBox1.Location = new System.Drawing.Point(188, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "마우스";
            // 
            // RightClickButton
            // 
            this.RightClickButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightClickButton.Location = new System.Drawing.Point(271, 20);
            this.RightClickButton.Name = "RightClickButton";
            this.RightClickButton.Size = new System.Drawing.Size(70, 21);
            this.RightClickButton.TabIndex = 5;
            this.RightClickButton.Text = "오른쪽";
            this.RightClickButton.UseVisualStyleBackColor = true;
            this.RightClickButton.Click += new System.EventHandler(this.RightClickButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fastInputCheckBox);
            this.groupBox2.Controls.Add(this.PressButton);
            this.groupBox2.Controls.Add(this.KeyTextBox);
            this.groupBox2.Location = new System.Drawing.Point(188, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 50);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "키보드";
            // 
            // fastInputCheckBox
            // 
            this.fastInputCheckBox.AutoSize = true;
            this.fastInputCheckBox.Location = new System.Drawing.Point(195, 23);
            this.fastInputCheckBox.Name = "fastInputCheckBox";
            this.fastInputCheckBox.Size = new System.Drawing.Size(76, 16);
            this.fastInputCheckBox.TabIndex = 8;
            this.fastInputCheckBox.Text = "빠른 입력";
            this.fastInputCheckBox.UseVisualStyleBackColor = true;
            this.fastInputCheckBox.CheckedChanged += new System.EventHandler(this.FastInputCheckBox_CheckedChanged);
            // 
            // PressButton
            // 
            this.PressButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PressButton.Location = new System.Drawing.Point(119, 20);
            this.PressButton.Name = "PressButton";
            this.PressButton.Size = new System.Drawing.Size(70, 21);
            this.PressButton.TabIndex = 6;
            this.PressButton.Text = "입력";
            this.PressButton.UseVisualStyleBackColor = true;
            this.PressButton.Click += new System.EventHandler(this.PressButton_Click);
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Location = new System.Drawing.Point(11, 20);
            this.KeyTextBox.MaxLength = 1;
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.ReadOnly = true;
            this.KeyTextBox.Size = new System.Drawing.Size(102, 21);
            this.KeyTextBox.TabIndex = 3;
            this.KeyTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyTextBox_PreviewKeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.eachCheckBox);
            this.groupBox3.Controls.Add(this.WaitButton);
            this.groupBox3.Controls.Add(this.WaitTextBox);
            this.groupBox3.Location = new System.Drawing.Point(341, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 50);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "시간";
            // 
            // eachCheckBox
            // 
            this.eachCheckBox.AutoSize = true;
            this.eachCheckBox.Location = new System.Drawing.Point(141, 22);
            this.eachCheckBox.Name = "eachCheckBox";
            this.eachCheckBox.Size = new System.Drawing.Size(48, 16);
            this.eachCheckBox.TabIndex = 7;
            this.eachCheckBox.Text = "매번";
            this.eachCheckBox.UseVisualStyleBackColor = true;
            // 
            // WaitButton
            // 
            this.WaitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WaitButton.Location = new System.Drawing.Point(65, 19);
            this.WaitButton.Name = "WaitButton";
            this.WaitButton.Size = new System.Drawing.Size(70, 21);
            this.WaitButton.TabIndex = 6;
            this.WaitButton.Text = "대기";
            this.WaitButton.UseVisualStyleBackColor = true;
            this.WaitButton.Click += new System.EventHandler(this.WaitButton_Click);
            // 
            // WaitTextBox
            // 
            this.WaitTextBox.Location = new System.Drawing.Point(11, 20);
            this.WaitTextBox.Name = "WaitTextBox";
            this.WaitTextBox.Size = new System.Drawing.Size(48, 21);
            this.WaitTextBox.TabIndex = 4;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Location = new System.Drawing.Point(188, 141);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(68, 48);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "시작";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Silver;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Location = new System.Drawing.Point(66, 168);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(116, 21);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "삭제";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.SettingToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewRoutineToolStripMenuItem,
            this.toolStripSeparator1,
            this.LoadToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.EndToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.FileToolStripMenuItem.Text = "파일";
            // 
            // NewRoutineToolStripMenuItem
            // 
            this.NewRoutineToolStripMenuItem.Name = "NewRoutineToolStripMenuItem";
            this.NewRoutineToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.NewRoutineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewRoutineToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.NewRoutineToolStripMenuItem.Text = "새 루틴";
            this.NewRoutineToolStripMenuItem.Click += new System.EventHandler(this.NewRoutineToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.LoadToolStripMenuItem.Text = "불러오기";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.SaveToolStripMenuItem.Text = "저장";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.SaveAsToolStripMenuItem.Text = "새로운 이름으로 저장";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // EndToolStripMenuItem
            // 
            this.EndToolStripMenuItem.Name = "EndToolStripMenuItem";
            this.EndToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.EndToolStripMenuItem.Text = "종료";
            this.EndToolStripMenuItem.Click += new System.EventHandler(this.EndToolStripMenuItem_Click);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.SettingToolStripMenuItem.Text = "설정";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.speedMacroToolStripMenuItem});
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.AboutToolStripMenuItem.Text = "정보";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem.Text = "도움말";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // speedMacroToolStripMenuItem
            // 
            this.speedMacroToolStripMenuItem.Name = "speedMacroToolStripMenuItem";
            this.speedMacroToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.speedMacroToolStripMenuItem.Text = "Speed Macro";
            this.speedMacroToolStripMenuItem.Click += new System.EventHandler(this.speedMacroToolStripMenuItem_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Location = new System.Drawing.Point(262, 141);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(68, 48);
            this.StopButton.TabIndex = 11;
            this.StopButton.Text = "중지";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // loopCheckBox
            // 
            this.loopCheckBox.AutoSize = true;
            this.loopCheckBox.Location = new System.Drawing.Point(12, 171);
            this.loopCheckBox.Name = "loopCheckBox";
            this.loopCheckBox.Size = new System.Drawing.Size(48, 16);
            this.loopCheckBox.TabIndex = 8;
            this.loopCheckBox.Text = "반복";
            this.loopCheckBox.UseVisualStyleBackColor = true;
            this.loopCheckBox.CheckedChanged += new System.EventHandler(this.LoopCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 195);
            this.Controls.Add(this.loopCheckBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProcedureListBox);
            this.Controls.Add(this.CursorPositionLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "스피드매크로 Speed Macro v1.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CursorPositionLabel;
        private System.Windows.Forms.Timer tick;
        private System.Windows.Forms.TextBox xPosTextBox;
        private System.Windows.Forms.TextBox yPosTextBox;
        private System.Windows.Forms.Button ClickButton;
        private System.Windows.Forms.Button DoubleClickButton;
        public System.Windows.Forms.ListBox ProcedureListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RightClickButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Button PressButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button WaitButton;
        private System.Windows.Forms.TextBox WaitTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewRoutineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog RoutineSaveFileDialog;
        private System.Windows.Forms.OpenFileDialog RoutineOpenFileDialog;
        private System.Windows.Forms.CheckBox eachCheckBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.CheckBox fastInputCheckBox;
        private System.Windows.Forms.CheckBox loopCheckBox;
    }
}