namespace Gaten.GameTool.GITADORA.GDMSM
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
            this.components = new System.ComponentModel.Container();
            this.makeButton = new System.Windows.Forms.Button();
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.정보iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사이트SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeProgressBar = new System.Windows.Forms.ProgressBar();
            this.proceedLabel = new System.Windows.Forms.Label();
            this.mergeLabel = new System.Windows.Forms.Label();
            this.mergeFileCountLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.selectFumenCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.checkPictureBox = new System.Windows.Forms.PictureBox();
            this.speedButton45 = new System.Windows.Forms.Button();
            this.CheckGroupBox = new System.Windows.Forms.GroupBox();
            this.speedButton75 = new System.Windows.Forms.Button();
            this.speedButton70 = new System.Windows.Forms.Button();
            this.speedButton65 = new System.Windows.Forms.Button();
            this.speedButton60 = new System.Windows.Forms.Button();
            this.speedButton30 = new System.Windows.Forms.Button();
            this.speedButton35 = new System.Windows.Forms.Button();
            this.speedPictureBox = new System.Windows.Forms.PictureBox();
            this.gearWidthButtonNarrow = new System.Windows.Forms.Button();
            this.gearWidthButtonWiden = new System.Windows.Forms.Button();
            this.changeScreenShotButton = new System.Windows.Forms.Button();
            this.gearStartButtonRight = new System.Windows.Forms.Button();
            this.gearStartButtonLeft = new System.Windows.Forms.Button();
            this.speedButton40 = new System.Windows.Forms.Button();
            this.speedButton55 = new System.Windows.Forms.Button();
            this.speedButton50 = new System.Windows.Forms.Button();
            this.playerListBox = new System.Windows.Forms.ListBox();
            this.workFolderButton = new System.Windows.Forms.Button();
            this.DeleteScreenShotButton = new System.Windows.Forms.Button();
            this.exitCheckBox = new System.Windows.Forms.CheckBox();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.lineORadioButton = new System.Windows.Forms.RadioButton();
            this.lineNRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textRadioButton = new System.Windows.Forms.RadioButton();
            this.imageRadioButton = new System.Windows.Forms.RadioButton();
            this.mainContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPictureBox)).BeginInit();
            this.CheckGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedPictureBox)).BeginInit();
            this.OutputGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // makeButton
            // 
            this.makeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.makeButton.FlatAppearance.BorderSize = 2;
            this.makeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeButton.ForeColor = System.Drawing.Color.White;
            this.makeButton.Location = new System.Drawing.Point(615, 448);
            this.makeButton.Name = "makeButton";
            this.makeButton.Size = new System.Drawing.Size(70, 35);
            this.makeButton.TabIndex = 6;
            this.makeButton.Text = "보면 생성";
            this.makeButton.UseVisualStyleBackColor = false;
            this.makeButton.Click += new System.EventHandler(this.MakeButton_Click);
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.정보iToolStripMenuItem,
            this.사이트SToolStripMenuItem});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.Size = new System.Drawing.Size(126, 48);
            // 
            // 정보iToolStripMenuItem
            // 
            this.정보iToolStripMenuItem.Name = "정보iToolStripMenuItem";
            this.정보iToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.정보iToolStripMenuItem.Text = "정보(&I)";
            this.정보iToolStripMenuItem.Click += new System.EventHandler(this.정보iToolStripMenuItem_Click);
            // 
            // 사이트SToolStripMenuItem
            // 
            this.사이트SToolStripMenuItem.Name = "사이트SToolStripMenuItem";
            this.사이트SToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.사이트SToolStripMenuItem.Text = "사이트(&S)";
            this.사이트SToolStripMenuItem.Click += new System.EventHandler(this.사이트SToolStripMenuItem_Click);
            // 
            // makeProgressBar
            // 
            this.makeProgressBar.Location = new System.Drawing.Point(5, 460);
            this.makeProgressBar.Name = "makeProgressBar";
            this.makeProgressBar.Size = new System.Drawing.Size(604, 23);
            this.makeProgressBar.TabIndex = 4;
            // 
            // proceedLabel
            // 
            this.proceedLabel.AutoSize = true;
            this.proceedLabel.Location = new System.Drawing.Point(3, 442);
            this.proceedLabel.Name = "proceedLabel";
            this.proceedLabel.Size = new System.Drawing.Size(9, 12);
            this.proceedLabel.TabIndex = 5;
            this.proceedLabel.Text = " ";
            // 
            // mergeLabel
            // 
            this.mergeLabel.AutoSize = true;
            this.mergeLabel.Location = new System.Drawing.Point(242, 442);
            this.mergeLabel.Name = "mergeLabel";
            this.mergeLabel.Size = new System.Drawing.Size(61, 12);
            this.mergeLabel.TabIndex = 6;
            this.mergeLabel.Text = "0 / 0 (0%)";
            // 
            // mergeFileCountLabel
            // 
            this.mergeFileCountLabel.AutoSize = true;
            this.mergeFileCountLabel.Location = new System.Drawing.Point(175, 442);
            this.mergeFileCountLabel.Name = "mergeFileCountLabel";
            this.mergeFileCountLabel.Size = new System.Drawing.Size(31, 12);
            this.mergeFileCountLabel.TabIndex = 7;
            this.mergeFileCountLabel.Text = "0 / 0";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(403, 442);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(34, 12);
            this.fileNameLabel.TabIndex = 8;
            this.fileNameLabel.Text = ".bmp";
            // 
            // selectFumenCheckedListBox
            // 
            this.selectFumenCheckedListBox.CheckOnClick = true;
            this.selectFumenCheckedListBox.FormattingEnabled = true;
            this.selectFumenCheckedListBox.HorizontalScrollbar = true;
            this.selectFumenCheckedListBox.Location = new System.Drawing.Point(5, 12);
            this.selectFumenCheckedListBox.Name = "selectFumenCheckedListBox";
            this.selectFumenCheckedListBox.Size = new System.Drawing.Size(412, 324);
            this.selectFumenCheckedListBox.TabIndex = 9;
            this.selectFumenCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SelectFumenCheckedListBox_ItemCheck);
            // 
            // checkPictureBox
            // 
            this.checkPictureBox.Location = new System.Drawing.Point(6, 18);
            this.checkPictureBox.Name = "checkPictureBox";
            this.checkPictureBox.Size = new System.Drawing.Size(250, 250);
            this.checkPictureBox.TabIndex = 10;
            this.checkPictureBox.TabStop = false;
            // 
            // speedButton45
            // 
            this.speedButton45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton45.FlatAppearance.BorderSize = 2;
            this.speedButton45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton45.ForeColor = System.Drawing.Color.White;
            this.speedButton45.Location = new System.Drawing.Point(213, 303);
            this.speedButton45.Name = "speedButton45";
            this.speedButton45.Size = new System.Drawing.Size(42, 26);
            this.speedButton45.TabIndex = 11;
            this.speedButton45.Text = "x4.5";
            this.speedButton45.UseVisualStyleBackColor = false;
            this.speedButton45.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // CheckGroupBox
            // 
            this.CheckGroupBox.Controls.Add(this.speedButton75);
            this.CheckGroupBox.Controls.Add(this.speedButton70);
            this.CheckGroupBox.Controls.Add(this.speedButton65);
            this.CheckGroupBox.Controls.Add(this.speedButton60);
            this.CheckGroupBox.Controls.Add(this.speedButton30);
            this.CheckGroupBox.Controls.Add(this.speedButton35);
            this.CheckGroupBox.Controls.Add(this.speedPictureBox);
            this.CheckGroupBox.Controls.Add(this.gearWidthButtonNarrow);
            this.CheckGroupBox.Controls.Add(this.gearWidthButtonWiden);
            this.CheckGroupBox.Controls.Add(this.changeScreenShotButton);
            this.CheckGroupBox.Controls.Add(this.gearStartButtonRight);
            this.CheckGroupBox.Controls.Add(this.gearStartButtonLeft);
            this.CheckGroupBox.Controls.Add(this.speedButton40);
            this.CheckGroupBox.Controls.Add(this.speedButton55);
            this.CheckGroupBox.Controls.Add(this.speedButton50);
            this.CheckGroupBox.Controls.Add(this.checkPictureBox);
            this.CheckGroupBox.Controls.Add(this.speedButton45);
            this.CheckGroupBox.Location = new System.Drawing.Point(423, 12);
            this.CheckGroupBox.Name = "CheckGroupBox";
            this.CheckGroupBox.Size = new System.Drawing.Size(262, 427);
            this.CheckGroupBox.TabIndex = 12;
            this.CheckGroupBox.TabStop = false;
            this.CheckGroupBox.Text = "확인";
            // 
            // speedButton75
            // 
            this.speedButton75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton75.FlatAppearance.BorderSize = 2;
            this.speedButton75.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton75.ForeColor = System.Drawing.Color.White;
            this.speedButton75.Location = new System.Drawing.Point(213, 393);
            this.speedButton75.Name = "speedButton75";
            this.speedButton75.Size = new System.Drawing.Size(42, 26);
            this.speedButton75.TabIndex = 27;
            this.speedButton75.Text = "x7.5";
            this.speedButton75.UseVisualStyleBackColor = false;
            this.speedButton75.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // speedButton70
            // 
            this.speedButton70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton70.FlatAppearance.BorderSize = 2;
            this.speedButton70.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton70.ForeColor = System.Drawing.Color.White;
            this.speedButton70.Location = new System.Drawing.Point(165, 393);
            this.speedButton70.Name = "speedButton70";
            this.speedButton70.Size = new System.Drawing.Size(42, 26);
            this.speedButton70.TabIndex = 26;
            this.speedButton70.Text = "x7.0";
            this.speedButton70.UseVisualStyleBackColor = false;
            this.speedButton70.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // speedButton65
            // 
            this.speedButton65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton65.FlatAppearance.BorderSize = 2;
            this.speedButton65.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton65.ForeColor = System.Drawing.Color.White;
            this.speedButton65.Location = new System.Drawing.Point(213, 363);
            this.speedButton65.Name = "speedButton65";
            this.speedButton65.Size = new System.Drawing.Size(42, 26);
            this.speedButton65.TabIndex = 25;
            this.speedButton65.Text = "x6.5";
            this.speedButton65.UseVisualStyleBackColor = false;
            this.speedButton65.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // speedButton60
            // 
            this.speedButton60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton60.FlatAppearance.BorderSize = 2;
            this.speedButton60.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton60.ForeColor = System.Drawing.Color.White;
            this.speedButton60.Location = new System.Drawing.Point(165, 363);
            this.speedButton60.Name = "speedButton60";
            this.speedButton60.Size = new System.Drawing.Size(42, 26);
            this.speedButton60.TabIndex = 24;
            this.speedButton60.Text = "x6.0";
            this.speedButton60.UseVisualStyleBackColor = false;
            this.speedButton60.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // speedButton30
            // 
            this.speedButton30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton30.FlatAppearance.BorderSize = 2;
            this.speedButton30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton30.ForeColor = System.Drawing.Color.White;
            this.speedButton30.Location = new System.Drawing.Point(165, 273);
            this.speedButton30.Name = "speedButton30";
            this.speedButton30.Size = new System.Drawing.Size(42, 26);
            this.speedButton30.TabIndex = 23;
            this.speedButton30.Text = "x3.0";
            this.speedButton30.UseVisualStyleBackColor = false;
            this.speedButton30.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // speedButton35
            // 
            this.speedButton35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton35.FlatAppearance.BorderSize = 2;
            this.speedButton35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton35.ForeColor = System.Drawing.Color.White;
            this.speedButton35.Location = new System.Drawing.Point(213, 273);
            this.speedButton35.Name = "speedButton35";
            this.speedButton35.Size = new System.Drawing.Size(42, 26);
            this.speedButton35.TabIndex = 22;
            this.speedButton35.Text = "x3.5";
            this.speedButton35.UseVisualStyleBackColor = false;
            this.speedButton35.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // speedPictureBox
            // 
            this.speedPictureBox.Location = new System.Drawing.Point(128, 18);
            this.speedPictureBox.Name = "speedPictureBox";
            this.speedPictureBox.Size = new System.Drawing.Size(128, 64);
            this.speedPictureBox.TabIndex = 21;
            this.speedPictureBox.TabStop = false;
            // 
            // gearWidthButtonNarrow
            // 
            this.gearWidthButtonNarrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gearWidthButtonNarrow.FlatAppearance.BorderSize = 2;
            this.gearWidthButtonNarrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gearWidthButtonNarrow.ForeColor = System.Drawing.Color.White;
            this.gearWidthButtonNarrow.Location = new System.Drawing.Point(82, 313);
            this.gearWidthButtonNarrow.Name = "gearWidthButtonNarrow";
            this.gearWidthButtonNarrow.Size = new System.Drawing.Size(70, 34);
            this.gearWidthButtonNarrow.TabIndex = 20;
            this.gearWidthButtonNarrow.Text = ">> 2 <<";
            this.gearWidthButtonNarrow.UseVisualStyleBackColor = false;
            this.gearWidthButtonNarrow.Click += new System.EventHandler(this.GearWidthButtonNarrow_Click);
            // 
            // gearWidthButtonWiden
            // 
            this.gearWidthButtonWiden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gearWidthButtonWiden.FlatAppearance.BorderSize = 2;
            this.gearWidthButtonWiden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gearWidthButtonWiden.ForeColor = System.Drawing.Color.White;
            this.gearWidthButtonWiden.Location = new System.Drawing.Point(6, 313);
            this.gearWidthButtonWiden.Name = "gearWidthButtonWiden";
            this.gearWidthButtonWiden.Size = new System.Drawing.Size(70, 34);
            this.gearWidthButtonWiden.TabIndex = 19;
            this.gearWidthButtonWiden.Text = "<< 2 >>";
            this.gearWidthButtonWiden.UseVisualStyleBackColor = false;
            this.gearWidthButtonWiden.Click += new System.EventHandler(this.GearWidthButtonWiden_Click);
            // 
            // changeScreenShotButton
            // 
            this.changeScreenShotButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.changeScreenShotButton.FlatAppearance.BorderSize = 2;
            this.changeScreenShotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeScreenShotButton.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.changeScreenShotButton.ForeColor = System.Drawing.Color.White;
            this.changeScreenShotButton.Location = new System.Drawing.Point(161, 223);
            this.changeScreenShotButton.Name = "changeScreenShotButton";
            this.changeScreenShotButton.Size = new System.Drawing.Size(94, 44);
            this.changeScreenShotButton.TabIndex = 18;
            this.changeScreenShotButton.Text = "이미지";
            this.changeScreenShotButton.UseVisualStyleBackColor = false;
            this.changeScreenShotButton.Click += new System.EventHandler(this.ChangeScreenShotButton_Click);
            // 
            // gearStartButtonRight
            // 
            this.gearStartButtonRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gearStartButtonRight.FlatAppearance.BorderSize = 2;
            this.gearStartButtonRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gearStartButtonRight.ForeColor = System.Drawing.Color.White;
            this.gearStartButtonRight.Location = new System.Drawing.Point(82, 273);
            this.gearStartButtonRight.Name = "gearStartButtonRight";
            this.gearStartButtonRight.Size = new System.Drawing.Size(70, 34);
            this.gearStartButtonRight.TabIndex = 16;
            this.gearStartButtonRight.Text = "2 >>";
            this.gearStartButtonRight.UseVisualStyleBackColor = false;
            this.gearStartButtonRight.Click += new System.EventHandler(this.GearStartButtonRight_Click);
            // 
            // gearStartButtonLeft
            // 
            this.gearStartButtonLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gearStartButtonLeft.FlatAppearance.BorderSize = 2;
            this.gearStartButtonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gearStartButtonLeft.ForeColor = System.Drawing.Color.White;
            this.gearStartButtonLeft.Location = new System.Drawing.Point(6, 273);
            this.gearStartButtonLeft.Name = "gearStartButtonLeft";
            this.gearStartButtonLeft.Size = new System.Drawing.Size(70, 34);
            this.gearStartButtonLeft.TabIndex = 15;
            this.gearStartButtonLeft.Text = "<< 2";
            this.gearStartButtonLeft.UseVisualStyleBackColor = false;
            this.gearStartButtonLeft.Click += new System.EventHandler(this.GearStartButtonLeft_Click);
            // 
            // speedButton40
            // 
            this.speedButton40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton40.FlatAppearance.BorderSize = 2;
            this.speedButton40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton40.ForeColor = System.Drawing.Color.White;
            this.speedButton40.Location = new System.Drawing.Point(165, 303);
            this.speedButton40.Name = "speedButton40";
            this.speedButton40.Size = new System.Drawing.Size(42, 26);
            this.speedButton40.TabIndex = 14;
            this.speedButton40.Text = "x4.0";
            this.speedButton40.UseVisualStyleBackColor = false;
            this.speedButton40.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // speedButton55
            // 
            this.speedButton55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton55.FlatAppearance.BorderSize = 2;
            this.speedButton55.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton55.ForeColor = System.Drawing.Color.White;
            this.speedButton55.Location = new System.Drawing.Point(213, 333);
            this.speedButton55.Name = "speedButton55";
            this.speedButton55.Size = new System.Drawing.Size(42, 26);
            this.speedButton55.TabIndex = 13;
            this.speedButton55.Text = "x5.5";
            this.speedButton55.UseVisualStyleBackColor = false;
            this.speedButton55.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // speedButton50
            // 
            this.speedButton50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.speedButton50.FlatAppearance.BorderSize = 2;
            this.speedButton50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton50.ForeColor = System.Drawing.Color.White;
            this.speedButton50.Location = new System.Drawing.Point(165, 333);
            this.speedButton50.Name = "speedButton50";
            this.speedButton50.Size = new System.Drawing.Size(42, 26);
            this.speedButton50.TabIndex = 12;
            this.speedButton50.Text = "x5.0";
            this.speedButton50.UseVisualStyleBackColor = false;
            this.speedButton50.Click += new System.EventHandler(this.SpeedButtonClick);
            // 
            // playerListBox
            // 
            this.playerListBox.FormattingEnabled = true;
            this.playerListBox.ItemHeight = 12;
            this.playerListBox.Location = new System.Drawing.Point(5, 338);
            this.playerListBox.Name = "playerListBox";
            this.playerListBox.Size = new System.Drawing.Size(178, 76);
            this.playerListBox.TabIndex = 28;
            this.playerListBox.SelectedIndexChanged += new System.EventHandler(this.PlayerListBox_SelectedIndexChanged);
            // 
            // workFolderButton
            // 
            this.workFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.workFolderButton.FlatAppearance.BorderSize = 2;
            this.workFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workFolderButton.ForeColor = System.Drawing.Color.White;
            this.workFolderButton.Location = new System.Drawing.Point(189, 338);
            this.workFolderButton.Name = "workFolderButton";
            this.workFolderButton.Size = new System.Drawing.Size(114, 47);
            this.workFolderButton.TabIndex = 22;
            this.workFolderButton.Text = "작업 폴더 열기";
            this.workFolderButton.UseVisualStyleBackColor = false;
            this.workFolderButton.Click += new System.EventHandler(this.WorkFolderButton_Click);
            // 
            // DeleteScreenShotButton
            // 
            this.DeleteScreenShotButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DeleteScreenShotButton.FlatAppearance.BorderSize = 2;
            this.DeleteScreenShotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteScreenShotButton.ForeColor = System.Drawing.Color.White;
            this.DeleteScreenShotButton.Location = new System.Drawing.Point(189, 391);
            this.DeleteScreenShotButton.Name = "DeleteScreenShotButton";
            this.DeleteScreenShotButton.Size = new System.Drawing.Size(114, 47);
            this.DeleteScreenShotButton.TabIndex = 22;
            this.DeleteScreenShotButton.Text = "스크린샷 삭제";
            this.DeleteScreenShotButton.UseVisualStyleBackColor = false;
            this.DeleteScreenShotButton.Click += new System.EventHandler(this.DeleteScreenShotButton_Click);
            // 
            // exitCheckBox
            // 
            this.exitCheckBox.AutoSize = true;
            this.exitCheckBox.Checked = true;
            this.exitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exitCheckBox.Location = new System.Drawing.Point(5, 421);
            this.exitCheckBox.Name = "exitCheckBox";
            this.exitCheckBox.Size = new System.Drawing.Size(124, 16);
            this.exitCheckBox.TabIndex = 29;
            this.exitCheckBox.Text = "완료하고 종료하기";
            this.exitCheckBox.UseVisualStyleBackColor = true;
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.lineNRadioButton);
            this.OutputGroupBox.Controls.Add(this.lineORadioButton);
            this.OutputGroupBox.Location = new System.Drawing.Point(309, 338);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(108, 49);
            this.OutputGroupBox.TabIndex = 30;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "출력 라인 수";
            // 
            // lineORadioButton
            // 
            this.lineORadioButton.AutoSize = true;
            this.lineORadioButton.Checked = true;
            this.lineORadioButton.Location = new System.Drawing.Point(6, 15);
            this.lineORadioButton.Name = "lineORadioButton";
            this.lineORadioButton.Size = new System.Drawing.Size(57, 16);
            this.lineORadioButton.TabIndex = 0;
            this.lineORadioButton.TabStop = true;
            this.lineORadioButton.Text = "라인 1";
            this.lineORadioButton.UseVisualStyleBackColor = true;
            // 
            // lineNRadioButton
            // 
            this.lineNRadioButton.AutoSize = true;
            this.lineNRadioButton.Location = new System.Drawing.Point(6, 31);
            this.lineNRadioButton.Name = "lineNRadioButton";
            this.lineNRadioButton.Size = new System.Drawing.Size(60, 16);
            this.lineNRadioButton.TabIndex = 0;
            this.lineNRadioButton.Text = "라인 N";
            this.lineNRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textRadioButton);
            this.groupBox1.Controls.Add(this.imageRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(309, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 49);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "출력 포맷";
            // 
            // textRadioButton
            // 
            this.textRadioButton.AutoSize = true;
            this.textRadioButton.Checked = true;
            this.textRadioButton.Location = new System.Drawing.Point(6, 31);
            this.textRadioButton.Name = "textRadioButton";
            this.textRadioButton.Size = new System.Drawing.Size(59, 16);
            this.textRadioButton.TabIndex = 0;
            this.textRadioButton.TabStop = true;
            this.textRadioButton.Text = "텍스트";
            this.textRadioButton.UseVisualStyleBackColor = true;
            this.textRadioButton.CheckedChanged += new System.EventHandler(this.textRadioButton_CheckedChanged);
            // 
            // imageRadioButton
            // 
            this.imageRadioButton.AutoSize = true;
            this.imageRadioButton.Location = new System.Drawing.Point(6, 15);
            this.imageRadioButton.Name = "imageRadioButton";
            this.imageRadioButton.Size = new System.Drawing.Size(59, 16);
            this.imageRadioButton.TabIndex = 0;
            this.imageRadioButton.Text = "이미지";
            this.imageRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 488);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.exitCheckBox);
            this.Controls.Add(this.playerListBox);
            this.Controls.Add(this.DeleteScreenShotButton);
            this.Controls.Add(this.workFolderButton);
            this.Controls.Add(this.CheckGroupBox);
            this.Controls.Add(this.selectFumenCheckedListBox);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.mergeFileCountLabel);
            this.Controls.Add(this.mergeLabel);
            this.Controls.Add(this.proceedLabel);
            this.Controls.Add(this.makeProgressBar);
            this.Controls.Add(this.makeButton);
            this.Name = "MainForm";
            this.Text = "GDMSM v1.0.8";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.mainContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkPictureBox)).EndInit();
            this.CheckGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedPictureBox)).EndInit();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button makeButton;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 정보iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사이트SToolStripMenuItem;
        private System.Windows.Forms.ProgressBar makeProgressBar;
        private System.Windows.Forms.Label proceedLabel;
        private System.Windows.Forms.Label mergeLabel;
        private System.Windows.Forms.Label mergeFileCountLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.CheckedListBox selectFumenCheckedListBox;
        private System.Windows.Forms.PictureBox checkPictureBox;
        private System.Windows.Forms.Button speedButton45;
        private System.Windows.Forms.GroupBox CheckGroupBox;
        private System.Windows.Forms.Button speedButton55;
        private System.Windows.Forms.Button speedButton50;
        private System.Windows.Forms.Button speedButton40;
        private System.Windows.Forms.Button gearStartButtonRight;
        private System.Windows.Forms.Button gearStartButtonLeft;
        private System.Windows.Forms.Button changeScreenShotButton;
        private System.Windows.Forms.Button gearWidthButtonNarrow;
        private System.Windows.Forms.Button gearWidthButtonWiden;
        private System.Windows.Forms.PictureBox speedPictureBox;
        private System.Windows.Forms.Button workFolderButton;
        private System.Windows.Forms.Button speedButton35;
        private System.Windows.Forms.Button speedButton30;
        private System.Windows.Forms.Button speedButton65;
        private System.Windows.Forms.Button speedButton60;
        private System.Windows.Forms.Button speedButton75;
        private System.Windows.Forms.Button speedButton70;
        private System.Windows.Forms.ListBox playerListBox;
        private System.Windows.Forms.Button DeleteScreenShotButton;
        private System.Windows.Forms.CheckBox exitCheckBox;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.RadioButton lineNRadioButton;
        private System.Windows.Forms.RadioButton lineORadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton textRadioButton;
        private System.Windows.Forms.RadioButton imageRadioButton;
    }
}