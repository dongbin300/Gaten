namespace Gaten.GameTool.osu.osuBeatmapDownloader
{
    partial class DownloadForm
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
            this.proceedLabel = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.다운로드활성화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.항상위에표시ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.옵션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프로그램정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // proceedLabel
            // 
            this.proceedLabel.AutoSize = true;
            this.proceedLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.proceedLabel.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.proceedLabel.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.proceedLabel.Location = new System.Drawing.Point(0, 235);
            this.proceedLabel.Name = "proceedLabel";
            this.proceedLabel.Size = new System.Drawing.Size(39, 15);
            this.proceedLabel.TabIndex = 7;
            this.proceedLabel.Text = "대기";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.다운로드활성화ToolStripMenuItem,
            this.항상위에표시ToolStripMenuItem,
            this.toolStripSeparator1,
            this.옵션ToolStripMenuItem,
            this.프로그램정보ToolStripMenuItem,
            this.toolStripSeparator2,
            this.종료ToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(183, 126);
            // 
            // 다운로드활성화ToolStripMenuItem
            // 
            this.다운로드활성화ToolStripMenuItem.Checked = true;
            this.다운로드활성화ToolStripMenuItem.CheckOnClick = true;
            this.다운로드활성화ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.다운로드활성화ToolStripMenuItem.Name = "다운로드활성화ToolStripMenuItem";
            this.다운로드활성화ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.다운로드활성화ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.다운로드활성화ToolStripMenuItem.Text = "다운로드 활성화";
            this.다운로드활성화ToolStripMenuItem.Click += new System.EventHandler(this.다운로드활성화ToolStripMenuItem_Click);
            // 
            // 항상위에표시ToolStripMenuItem
            // 
            this.항상위에표시ToolStripMenuItem.Checked = true;
            this.항상위에표시ToolStripMenuItem.CheckOnClick = true;
            this.항상위에표시ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.항상위에표시ToolStripMenuItem.Name = "항상위에표시ToolStripMenuItem";
            this.항상위에표시ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.항상위에표시ToolStripMenuItem.Text = "항상 위에 표시";
            this.항상위에표시ToolStripMenuItem.Click += new System.EventHandler(this.항상위에표시ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // 옵션ToolStripMenuItem
            // 
            this.옵션ToolStripMenuItem.Name = "옵션ToolStripMenuItem";
            this.옵션ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.옵션ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.옵션ToolStripMenuItem.Text = "옵션";
            this.옵션ToolStripMenuItem.Click += new System.EventHandler(this.옵션ToolStripMenuItem_Click);
            // 
            // 프로그램정보ToolStripMenuItem
            // 
            this.프로그램정보ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makerToolStripMenuItem,
            this.versionToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.프로그램정보ToolStripMenuItem.Name = "프로그램정보ToolStripMenuItem";
            this.프로그램정보ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.프로그램정보ToolStripMenuItem.Text = "프로그램 정보";
            // 
            // makerToolStripMenuItem
            // 
            this.makerToolStripMenuItem.Name = "makerToolStripMenuItem";
            this.makerToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.makerToolStripMenuItem.Text = "만든 사람: Gaten";
            this.makerToolStripMenuItem.Click += new System.EventHandler(this.makerToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.versionToolStripMenuItem.Text = "v2.0.0";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.donateToolStripMenuItem.Text = "개발자에게 커피 한 잔 후원하기";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(200, 250);
            this.Controls.Add(this.proceedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DownloadForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "osu Beatmap Downloader by Gaten";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DownloadForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DownloadForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DownloadForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownloadForm_MouseDown);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label proceedLabel;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 옵션ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다운로드활성화ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 항상위에표시ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프로그램정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
    }
}