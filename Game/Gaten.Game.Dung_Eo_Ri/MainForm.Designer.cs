namespace Gaten.Game.Dung_Eo_Ri
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
            this.PlayerImage = new System.Windows.Forms.PictureBox();
            this.MobImage = new System.Windows.Forms.PictureBox();
            this.PlayerStats = new System.Windows.Forms.ListBox();
            this.MobStats = new System.Windows.Forms.ListBox();
            this.SceneControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RunAwayButton = new System.Windows.Forms.Button();
            this.AttackButton = new System.Windows.Forms.Button();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ExitButton = new System.Windows.Forms.Button();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DungeonListBox = new System.Windows.Forms.ListBox();
            this.PlayerLevelText = new System.Windows.Forms.Label();
            this.PlayerNameText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DungeonInfo = new System.Windows.Forms.ListBox();
            this.PlayerInfo = new System.Windows.Forms.ListBox();
            this.GiveUpButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.PlayerHitPointsText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MobImage)).BeginInit();
            this.SceneControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerImage
            // 
            this.PlayerImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerImage.Location = new System.Drawing.Point(6, 6);
            this.PlayerImage.Name = "PlayerImage";
            this.PlayerImage.Size = new System.Drawing.Size(128, 128);
            this.PlayerImage.TabIndex = 0;
            this.PlayerImage.TabStop = false;
            // 
            // MobImage
            // 
            this.MobImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MobImage.Location = new System.Drawing.Point(480, 7);
            this.MobImage.Name = "MobImage";
            this.MobImage.Size = new System.Drawing.Size(128, 128);
            this.MobImage.TabIndex = 0;
            this.MobImage.TabStop = false;
            // 
            // PlayerStats
            // 
            this.PlayerStats.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerStats.FormattingEnabled = true;
            this.PlayerStats.ItemHeight = 21;
            this.PlayerStats.Location = new System.Drawing.Point(6, 140);
            this.PlayerStats.Name = "PlayerStats";
            this.PlayerStats.Size = new System.Drawing.Size(128, 256);
            this.PlayerStats.TabIndex = 1;
            // 
            // MobStats
            // 
            this.MobStats.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MobStats.FormattingEnabled = true;
            this.MobStats.ItemHeight = 21;
            this.MobStats.Location = new System.Drawing.Point(480, 140);
            this.MobStats.Name = "MobStats";
            this.MobStats.Size = new System.Drawing.Size(128, 256);
            this.MobStats.TabIndex = 1;
            // 
            // SceneControl
            // 
            this.SceneControl.Controls.Add(this.tabPage1);
            this.SceneControl.Controls.Add(this.tabPage2);
            this.SceneControl.Controls.Add(this.tabPage3);
            this.SceneControl.Controls.Add(this.tabPage4);
            this.SceneControl.ItemSize = new System.Drawing.Size(0, 1);
            this.SceneControl.Location = new System.Drawing.Point(0, -4);
            this.SceneControl.Name = "SceneControl";
            this.SceneControl.SelectedIndex = 0;
            this.SceneControl.Size = new System.Drawing.Size(640, 450);
            this.SceneControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.SceneControl.TabIndex = 2;
            this.SceneControl.SelectedIndexChanged += new System.EventHandler(this.SceneControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RunAwayButton);
            this.tabPage1.Controls.Add(this.AttackButton);
            this.tabPage1.Controls.Add(this.PlayerImage);
            this.tabPage1.Controls.Add(this.MobStats);
            this.tabPage1.Controls.Add(this.LogListBox);
            this.tabPage1.Controls.Add(this.PlayerStats);
            this.tabPage1.Controls.Add(this.MobImage);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RunAwayButton
            // 
            this.RunAwayButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RunAwayButton.Location = new System.Drawing.Point(235, 338);
            this.RunAwayButton.Name = "RunAwayButton";
            this.RunAwayButton.Size = new System.Drawing.Size(125, 42);
            this.RunAwayButton.TabIndex = 2;
            this.RunAwayButton.Text = "도망허기";
            this.RunAwayButton.UseVisualStyleBackColor = true;
            this.RunAwayButton.Click += new System.EventHandler(this.RunAwayButton_Click);
            // 
            // AttackButton
            // 
            this.AttackButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AttackButton.Location = new System.Drawing.Point(235, 290);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(125, 42);
            this.AttackButton.TabIndex = 2;
            this.AttackButton.Text = "공격허기";
            this.AttackButton.UseVisualStyleBackColor = true;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // LogListBox
            // 
            this.LogListBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.ItemHeight = 15;
            this.LogListBox.Location = new System.Drawing.Point(154, 7);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(301, 214);
            this.LogListBox.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ExitButton);
            this.tabPage2.Controls.Add(this.StartGameButton);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Red;
            this.ExitButton.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.ForeColor = System.Drawing.Color.Black;
            this.ExitButton.Location = new System.Drawing.Point(184, 269);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(247, 73);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartGameButton.Location = new System.Drawing.Point(184, 180);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(247, 73);
            this.StartGameButton.TabIndex = 1;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(123, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 86);
            this.label1.TabIndex = 0;
            this.label1.Text = "덩어리 게임";
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.PlayerHitPointsText);
            this.tabPage3.Controls.Add(this.DungeonListBox);
            this.tabPage3.Controls.Add(this.PlayerLevelText);
            this.tabPage3.Controls.Add(this.PlayerNameText);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(632, 441);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DungeonListBox
            // 
            this.DungeonListBox.FormattingEnabled = true;
            this.DungeonListBox.ItemHeight = 15;
            this.DungeonListBox.Location = new System.Drawing.Point(8, 11);
            this.DungeonListBox.Name = "DungeonListBox";
            this.DungeonListBox.Size = new System.Drawing.Size(204, 394);
            this.DungeonListBox.TabIndex = 1;
            this.DungeonListBox.DoubleClick += new System.EventHandler(this.DungeonListBox_DoubleClick);
            // 
            // PlayerLevelText
            // 
            this.PlayerLevelText.AutoSize = true;
            this.PlayerLevelText.BackColor = System.Drawing.Color.Transparent;
            this.PlayerLevelText.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerLevelText.Location = new System.Drawing.Point(523, 52);
            this.PlayerLevelText.Name = "PlayerLevelText";
            this.PlayerLevelText.Size = new System.Drawing.Size(42, 17);
            this.PlayerLevelText.TabIndex = 0;
            this.PlayerLevelText.Text = "레벨: ";
            // 
            // PlayerNameText
            // 
            this.PlayerNameText.AutoSize = true;
            this.PlayerNameText.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerNameText.Location = new System.Drawing.Point(523, 33);
            this.PlayerNameText.Name = "PlayerNameText";
            this.PlayerNameText.Size = new System.Drawing.Size(42, 17);
            this.PlayerNameText.TabIndex = 0;
            this.PlayerNameText.Text = "이름: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(512, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "덩어리 월드";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DungeonInfo);
            this.tabPage4.Controls.Add(this.PlayerInfo);
            this.tabPage4.Controls.Add(this.GiveUpButton);
            this.tabPage4.Controls.Add(this.RightButton);
            this.tabPage4.Controls.Add(this.LeftButton);
            this.tabPage4.Controls.Add(this.DownButton);
            this.tabPage4.Controls.Add(this.UpButton);
            this.tabPage4.Location = new System.Drawing.Point(4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(632, 441);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DungeonInfo
            // 
            this.DungeonInfo.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DungeonInfo.FormattingEnabled = true;
            this.DungeonInfo.ItemHeight = 17;
            this.DungeonInfo.Location = new System.Drawing.Point(380, 220);
            this.DungeonInfo.Name = "DungeonInfo";
            this.DungeonInfo.Size = new System.Drawing.Size(134, 191);
            this.DungeonInfo.TabIndex = 1;
            // 
            // PlayerInfo
            // 
            this.PlayerInfo.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerInfo.FormattingEnabled = true;
            this.PlayerInfo.ItemHeight = 17;
            this.PlayerInfo.Location = new System.Drawing.Point(97, 220);
            this.PlayerInfo.Name = "PlayerInfo";
            this.PlayerInfo.Size = new System.Drawing.Size(134, 191);
            this.PlayerInfo.TabIndex = 1;
            // 
            // GiveUpButton
            // 
            this.GiveUpButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GiveUpButton.Location = new System.Drawing.Point(237, 376);
            this.GiveUpButton.Name = "GiveUpButton";
            this.GiveUpButton.Size = new System.Drawing.Size(137, 33);
            this.GiveUpButton.TabIndex = 0;
            this.GiveUpButton.Text = "던전 포기";
            this.GiveUpButton.UseVisualStyleBackColor = true;
            this.GiveUpButton.Click += new System.EventHandler(this.GiveUpButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RightButton.Location = new System.Drawing.Point(237, 337);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(137, 33);
            this.RightButton.TabIndex = 0;
            this.RightButton.Text = "오른쪽으로 이동";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LeftButton.Location = new System.Drawing.Point(237, 298);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(137, 33);
            this.LeftButton.TabIndex = 0;
            this.LeftButton.Text = "왼쪽으로 이동";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DownButton.Location = new System.Drawing.Point(237, 259);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(137, 33);
            this.DownButton.TabIndex = 0;
            this.DownButton.Text = "아래로 이동";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UpButton.Location = new System.Drawing.Point(237, 220);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(137, 33);
            this.UpButton.TabIndex = 0;
            this.UpButton.Text = "위로 이동";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // PlayerHitPointsText
            // 
            this.PlayerHitPointsText.AutoSize = true;
            this.PlayerHitPointsText.BackColor = System.Drawing.Color.Transparent;
            this.PlayerHitPointsText.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerHitPointsText.Location = new System.Drawing.Point(523, 71);
            this.PlayerHitPointsText.Name = "PlayerHitPointsText";
            this.PlayerHitPointsText.Size = new System.Drawing.Size(32, 17);
            this.PlayerHitPointsText.TabIndex = 2;
            this.PlayerHitPointsText.Text = "HP: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 411);
            this.Controls.Add(this.SceneControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DungEoRi";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlayerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MobImage)).EndInit();
            this.SceneControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PlayerImage;
        private PictureBox MobImage;
        private ListBox PlayerStats;
        private ListBox MobStats;
        private TabControl SceneControl;
        private TabPage tabPage1;
        private Button RunAwayButton;
        private Button AttackButton;
        private ListBox LogListBox;
        private TabPage tabPage2;
        private Button ExitButton;
        private Button StartGameButton;
        private Label label1;
        private TabPage tabPage3;
        private Label PlayerLevelText;
        private Label PlayerNameText;
        private Label label2;
        private ListBox DungeonListBox;
        private TabPage tabPage4;
        private Button UpButton;
        private Button GiveUpButton;
        private Button RightButton;
        private Button LeftButton;
        private Button DownButton;
        private ListBox DungeonInfo;
        private ListBox PlayerInfo;
        private Label PlayerHitPointsText;
    }
}