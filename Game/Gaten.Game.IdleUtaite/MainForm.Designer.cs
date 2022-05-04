namespace Gaten.Game.IdleUtaite
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.awarenessLabel = new System.Windows.Forms.Label();
            this.followerLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainTab = new System.Windows.Forms.TabControl();
            this.studioPage = new System.Windows.Forms.TabPage();
            this.studioTab = new System.Windows.Forms.TabControl();
            this.recordPage = new System.Windows.Forms.TabPage();
            this.recordButton = new System.Windows.Forms.Button();
            this.musicInfoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.musicListBox = new System.Windows.Forms.ListBox();
            this.mixPage = new System.Windows.Forms.TabPage();
            this.illustPage = new System.Windows.Forms.TabPage();
            this.videoPage = new System.Windows.Forms.TabPage();
            this.composePage = new System.Windows.Forms.TabPage();
            this.shopPage = new System.Windows.Forms.TabPage();
            this.subcontractPage = new System.Windows.Forms.TabPage();
            this.nicoPage = new System.Windows.Forms.TabPage();
            this.gakuenPage = new System.Windows.Forms.TabPage();
            this.statPage = new System.Windows.Forms.TabPage();
            this.mixMusicTitleLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.effectorCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panel4.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.studioPage.SuspendLayout();
            this.studioTab.SuspendLayout();
            this.recordPage.SuspendLayout();
            this.mixPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 32);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 32);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(0, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 32);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Ivory;
            this.panel4.Controls.Add(this.awarenessLabel);
            this.panel4.Controls.Add(this.followerLabel);
            this.panel4.Controls.Add(this.moneyLabel);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 96);
            this.panel4.TabIndex = 2;
            // 
            // awarenessLabel
            // 
            this.awarenessLabel.AutoSize = true;
            this.awarenessLabel.Location = new System.Drawing.Point(48, 82);
            this.awarenessLabel.Name = "awarenessLabel";
            this.awarenessLabel.Size = new System.Drawing.Size(11, 12);
            this.awarenessLabel.TabIndex = 4;
            this.awarenessLabel.Text = "0";
            // 
            // followerLabel
            // 
            this.followerLabel.AutoSize = true;
            this.followerLabel.Location = new System.Drawing.Point(48, 50);
            this.followerLabel.Name = "followerLabel";
            this.followerLabel.Size = new System.Drawing.Size(11, 12);
            this.followerLabel.TabIndex = 3;
            this.followerLabel.Text = "0";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(48, 18);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(11, 12);
            this.moneyLabel.TabIndex = 2;
            this.moneyLabel.Text = "0";
            // 
            // timer
            // 
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.studioPage);
            this.mainTab.Controls.Add(this.shopPage);
            this.mainTab.Controls.Add(this.subcontractPage);
            this.mainTab.Controls.Add(this.nicoPage);
            this.mainTab.Controls.Add(this.gakuenPage);
            this.mainTab.Controls.Add(this.statPage);
            this.mainTab.Location = new System.Drawing.Point(0, 97);
            this.mainTab.Margin = new System.Windows.Forms.Padding(0);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(605, 364);
            this.mainTab.TabIndex = 3;
            // 
            // studioPage
            // 
            this.studioPage.Controls.Add(this.studioTab);
            this.studioPage.Location = new System.Drawing.Point(4, 22);
            this.studioPage.Name = "studioPage";
            this.studioPage.Padding = new System.Windows.Forms.Padding(3);
            this.studioPage.Size = new System.Drawing.Size(597, 338);
            this.studioPage.TabIndex = 0;
            this.studioPage.Text = "스튜디오";
            this.studioPage.UseVisualStyleBackColor = true;
            // 
            // studioTab
            // 
            this.studioTab.Controls.Add(this.recordPage);
            this.studioTab.Controls.Add(this.mixPage);
            this.studioTab.Controls.Add(this.illustPage);
            this.studioTab.Controls.Add(this.videoPage);
            this.studioTab.Controls.Add(this.composePage);
            this.studioTab.Location = new System.Drawing.Point(0, 0);
            this.studioTab.Name = "studioTab";
            this.studioTab.SelectedIndex = 0;
            this.studioTab.Size = new System.Drawing.Size(597, 338);
            this.studioTab.TabIndex = 0;
            this.studioTab.SelectedIndexChanged += new System.EventHandler(this.StudioTab_SelectedIndexChanged);
            // 
            // recordPage
            // 
            this.recordPage.Controls.Add(this.recordButton);
            this.recordPage.Controls.Add(this.musicInfoLabel);
            this.recordPage.Controls.Add(this.label1);
            this.recordPage.Controls.Add(this.musicListBox);
            this.recordPage.Location = new System.Drawing.Point(4, 22);
            this.recordPage.Margin = new System.Windows.Forms.Padding(0);
            this.recordPage.Name = "recordPage";
            this.recordPage.Size = new System.Drawing.Size(589, 312);
            this.recordPage.TabIndex = 0;
            this.recordPage.Text = "녹음";
            this.recordPage.UseVisualStyleBackColor = true;
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(158, 219);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(176, 80);
            this.recordButton.TabIndex = 3;
            this.recordButton.Text = "녹음";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // musicInfoLabel
            // 
            this.musicInfoLabel.AutoSize = true;
            this.musicInfoLabel.Location = new System.Drawing.Point(158, 19);
            this.musicInfoLabel.Name = "musicInfoLabel";
            this.musicInfoLabel.Size = new System.Drawing.Size(21, 12);
            this.musicInfoLabel.TabIndex = 2;
            this.musicInfoLabel.Text = "    ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "노래";
            // 
            // musicListBox
            // 
            this.musicListBox.FormattingEnabled = true;
            this.musicListBox.ItemHeight = 12;
            this.musicListBox.Location = new System.Drawing.Point(4, 19);
            this.musicListBox.Name = "musicListBox";
            this.musicListBox.Size = new System.Drawing.Size(148, 280);
            this.musicListBox.TabIndex = 0;
            this.musicListBox.SelectedIndexChanged += new System.EventHandler(this.MusicListBox_SelectedIndexChanged);
            // 
            // mixPage
            // 
            this.mixPage.Controls.Add(this.effectorCheckedListBox);
            this.mixPage.Controls.Add(this.label3);
            this.mixPage.Controls.Add(this.mixMusicTitleLabel);
            this.mixPage.Location = new System.Drawing.Point(4, 22);
            this.mixPage.Name = "mixPage";
            this.mixPage.Padding = new System.Windows.Forms.Padding(3);
            this.mixPage.Size = new System.Drawing.Size(589, 312);
            this.mixPage.TabIndex = 1;
            this.mixPage.Text = "믹싱";
            this.mixPage.UseVisualStyleBackColor = true;
            // 
            // illustPage
            // 
            this.illustPage.Location = new System.Drawing.Point(4, 22);
            this.illustPage.Name = "illustPage";
            this.illustPage.Padding = new System.Windows.Forms.Padding(3);
            this.illustPage.Size = new System.Drawing.Size(589, 312);
            this.illustPage.TabIndex = 2;
            this.illustPage.Text = "일러";
            this.illustPage.UseVisualStyleBackColor = true;
            // 
            // videoPage
            // 
            this.videoPage.Location = new System.Drawing.Point(4, 22);
            this.videoPage.Name = "videoPage";
            this.videoPage.Padding = new System.Windows.Forms.Padding(3);
            this.videoPage.Size = new System.Drawing.Size(589, 312);
            this.videoPage.TabIndex = 3;
            this.videoPage.Text = "영상";
            this.videoPage.UseVisualStyleBackColor = true;
            // 
            // composePage
            // 
            this.composePage.Location = new System.Drawing.Point(4, 22);
            this.composePage.Name = "composePage";
            this.composePage.Padding = new System.Windows.Forms.Padding(3);
            this.composePage.Size = new System.Drawing.Size(589, 312);
            this.composePage.TabIndex = 4;
            this.composePage.Text = "작곡";
            this.composePage.UseVisualStyleBackColor = true;
            // 
            // shopPage
            // 
            this.shopPage.Location = new System.Drawing.Point(4, 22);
            this.shopPage.Name = "shopPage";
            this.shopPage.Padding = new System.Windows.Forms.Padding(3);
            this.shopPage.Size = new System.Drawing.Size(597, 338);
            this.shopPage.TabIndex = 1;
            this.shopPage.Text = "상점";
            this.shopPage.UseVisualStyleBackColor = true;
            // 
            // subcontractPage
            // 
            this.subcontractPage.Location = new System.Drawing.Point(4, 22);
            this.subcontractPage.Name = "subcontractPage";
            this.subcontractPage.Size = new System.Drawing.Size(597, 338);
            this.subcontractPage.TabIndex = 2;
            this.subcontractPage.Text = "외주";
            this.subcontractPage.UseVisualStyleBackColor = true;
            // 
            // nicoPage
            // 
            this.nicoPage.Location = new System.Drawing.Point(4, 22);
            this.nicoPage.Name = "nicoPage";
            this.nicoPage.Size = new System.Drawing.Size(597, 338);
            this.nicoPage.TabIndex = 3;
            this.nicoPage.Text = "니코동";
            this.nicoPage.UseVisualStyleBackColor = true;
            // 
            // gakuenPage
            // 
            this.gakuenPage.Location = new System.Drawing.Point(4, 22);
            this.gakuenPage.Name = "gakuenPage";
            this.gakuenPage.Size = new System.Drawing.Size(597, 338);
            this.gakuenPage.TabIndex = 4;
            this.gakuenPage.Text = "학원";
            this.gakuenPage.UseVisualStyleBackColor = true;
            // 
            // statPage
            // 
            this.statPage.Location = new System.Drawing.Point(4, 22);
            this.statPage.Name = "statPage";
            this.statPage.Size = new System.Drawing.Size(597, 338);
            this.statPage.TabIndex = 5;
            this.statPage.Text = "스탯";
            this.statPage.UseVisualStyleBackColor = true;
            // 
            // mixMusicTitleLabel
            // 
            this.mixMusicTitleLabel.AutoSize = true;
            this.mixMusicTitleLabel.Location = new System.Drawing.Point(171, 19);
            this.mixMusicTitleLabel.Name = "mixMusicTitleLabel";
            this.mixMusicTitleLabel.Size = new System.Drawing.Size(21, 12);
            this.mixMusicTitleLabel.TabIndex = 3;
            this.mixMusicTitleLabel.Text = "    ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "이펙터";
            // 
            // effectorCheckedListBox
            // 
            this.effectorCheckedListBox.FormattingEnabled = true;
            this.effectorCheckedListBox.Location = new System.Drawing.Point(4, 19);
            this.effectorCheckedListBox.Name = "effectorCheckedListBox";
            this.effectorCheckedListBox.Size = new System.Drawing.Size(148, 276);
            this.effectorCheckedListBox.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 460);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Idle Utaite";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.mainTab.ResumeLayout(false);
            this.studioPage.ResumeLayout(false);
            this.studioTab.ResumeLayout(false);
            this.recordPage.ResumeLayout(false);
            this.recordPage.PerformLayout();
            this.mixPage.ResumeLayout(false);
            this.mixPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label awarenessLabel;
        private System.Windows.Forms.Label followerLabel;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage studioPage;
        private System.Windows.Forms.TabPage shopPage;
        private System.Windows.Forms.TabPage subcontractPage;
        private System.Windows.Forms.TabPage nicoPage;
        private System.Windows.Forms.TabPage gakuenPage;
        private System.Windows.Forms.TabPage statPage;
        private System.Windows.Forms.TabControl studioTab;
        private System.Windows.Forms.TabPage recordPage;
        private System.Windows.Forms.TabPage mixPage;
        private System.Windows.Forms.TabPage illustPage;
        private System.Windows.Forms.TabPage videoPage;
        private System.Windows.Forms.TabPage composePage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox musicListBox;
        private System.Windows.Forms.Label musicInfoLabel;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label mixMusicTitleLabel;
        private System.Windows.Forms.CheckedListBox effectorCheckedListBox;
    }
}