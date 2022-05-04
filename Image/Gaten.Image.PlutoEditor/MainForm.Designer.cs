namespace Gaten.Image.PlutoEditor
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새우주ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.격자ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.콘솔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.테스트ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeMapPanel = new System.Windows.Forms.Panel();
            this.penColorDialog = new System.Windows.Forms.ColorDialog();
            this.toolBoxPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addPanelButton = new System.Windows.Forms.Button();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.currentFrameLabel = new System.Windows.Forms.Label();
            this.currentLabel = new System.Windows.Forms.Label();
            this.testLabel = new System.Windows.Forms.Label();
            this.panelBoxPanel = new Panel.PPanel();
            this.scenePanel = new Panel.PPanel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.편집ToolStripMenuItem,
            this.보기ToolStripMenuItem,
            this.도구ToolStripMenuItem,
            this.테스트ToolStripMenuItem,
            this.도움말ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새우주ToolStripMenuItem,
            this.열기ToolStripMenuItem,
            this.toolStripSeparator1,
            this.저장ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 새우주ToolStripMenuItem
            // 
            this.새우주ToolStripMenuItem.Name = "새우주ToolStripMenuItem";
            this.새우주ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.새우주ToolStripMenuItem.Text = "새 우주";
            this.새우주ToolStripMenuItem.Click += new System.EventHandler(this.새우주ToolStripMenuItem_Click);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 편집ToolStripMenuItem
            // 
            this.편집ToolStripMenuItem.Name = "편집ToolStripMenuItem";
            this.편집ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.편집ToolStripMenuItem.Text = "편집";
            // 
            // 보기ToolStripMenuItem
            // 
            this.보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.격자ToolStripMenuItem});
            this.보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            this.보기ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.보기ToolStripMenuItem.Text = "보기";
            // 
            // 격자ToolStripMenuItem
            // 
            this.격자ToolStripMenuItem.CheckOnClick = true;
            this.격자ToolStripMenuItem.Name = "격자ToolStripMenuItem";
            this.격자ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.격자ToolStripMenuItem.Text = "격자";
            this.격자ToolStripMenuItem.Click += new System.EventHandler(this.격자ToolStripMenuItem_Click);
            // 
            // 도구ToolStripMenuItem
            // 
            this.도구ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.콘솔ToolStripMenuItem});
            this.도구ToolStripMenuItem.Name = "도구ToolStripMenuItem";
            this.도구ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.도구ToolStripMenuItem.Text = "테스트";
            // 
            // 콘솔ToolStripMenuItem
            // 
            this.콘솔ToolStripMenuItem.Name = "콘솔ToolStripMenuItem";
            this.콘솔ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.콘솔ToolStripMenuItem.Text = "콘솔";
            this.콘솔ToolStripMenuItem.Click += new System.EventHandler(this.콘솔ToolStripMenuItem_Click);
            // 
            // 테스트ToolStripMenuItem
            // 
            this.테스트ToolStripMenuItem.Name = "테스트ToolStripMenuItem";
            this.테스트ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.테스트ToolStripMenuItem.Text = "도구";
            // 
            // 도움말ToolStripMenuItem
            // 
            this.도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
            this.도움말ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.도움말ToolStripMenuItem.Text = "도움말";
            // 
            // timeMapPanel
            // 
            this.timeMapPanel.AutoScroll = true;
            this.timeMapPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeMapPanel.Location = new System.Drawing.Point(0, 644);
            this.timeMapPanel.MaximumSize = new System.Drawing.Size(1280, 100);
            this.timeMapPanel.Name = "timeMapPanel";
            this.timeMapPanel.Size = new System.Drawing.Size(1280, 100);
            this.timeMapPanel.TabIndex = 1;
            this.timeMapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TimeMapPanel_Paint);
            this.timeMapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeMapPanel_MouseDown);
            // 
            // toolBoxPanel
            // 
            this.toolBoxPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBoxPanel.Location = new System.Drawing.Point(966, 27);
            this.toolBoxPanel.Name = "toolBoxPanel";
            this.toolBoxPanel.Size = new System.Drawing.Size(141, 406);
            this.toolBoxPanel.TabIndex = 6;
            // 
            // addPanelButton
            // 
            this.addPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPanelButton.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addPanelButton.Location = new System.Drawing.Point(966, 578);
            this.addPanelButton.Name = "addPanelButton";
            this.addPanelButton.Size = new System.Drawing.Size(65, 65);
            this.addPanelButton.TabIndex = 0;
            this.addPanelButton.Text = "+";
            this.addPanelButton.UseVisualStyleBackColor = true;
            this.addPanelButton.Click += new System.EventHandler(this.AddPanelButton_Click);
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(1251, 629);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(17, 12);
            this.scaleLabel.TabIndex = 9;
            this.scaleLabel.Text = "[]";
            // 
            // currentFrameLabel
            // 
            this.currentFrameLabel.AutoSize = true;
            this.currentFrameLabel.Location = new System.Drawing.Point(1147, 629);
            this.currentFrameLabel.Name = "currentFrameLabel";
            this.currentFrameLabel.Size = new System.Drawing.Size(17, 12);
            this.currentFrameLabel.TabIndex = 9;
            this.currentFrameLabel.Text = "[]";
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Location = new System.Drawing.Point(964, 436);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(17, 12);
            this.currentLabel.TabIndex = 9;
            this.currentLabel.Text = "[]";
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(964, 494);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(17, 12);
            this.testLabel.TabIndex = 9;
            this.testLabel.Text = "[]";
            // 
            // panelBoxPanel
            // 
            this.panelBoxPanel.AutoScroll = true;
            this.panelBoxPanel.Location = new System.Drawing.Point(0, 568);
            this.panelBoxPanel.MaximumSize = new System.Drawing.Size(960, 540);
            this.panelBoxPanel.Name = "panelBoxPanel";
            this.panelBoxPanel.Size = new System.Drawing.Size(960, 75);
            this.panelBoxPanel.TabIndex = 1;
            this.panelBoxPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBoxPanel_Paint);
            // 
            // scenePanel
            // 
            this.scenePanel.AutoScroll = true;
            this.scenePanel.Location = new System.Drawing.Point(0, 27);
            this.scenePanel.MaximumSize = new System.Drawing.Size(960, 540);
            this.scenePanel.Name = "scenePanel";
            this.scenePanel.Size = new System.Drawing.Size(960, 540);
            this.scenePanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 744);
            this.Controls.Add(this.addPanelButton);
            this.Controls.Add(this.panelBoxPanel);
            this.Controls.Add(this.scenePanel);
            this.Controls.Add(this.currentFrameLabel);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.currentLabel);
            this.Controls.Add(this.scaleLabel);
            this.Controls.Add(this.toolBoxPanel);
            this.Controls.Add(this.timeMapPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "PlutoEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 콘솔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 테스트ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말ToolStripMenuItem;
        private System.Windows.Forms.Panel timeMapPanel;
        private System.Windows.Forms.ToolStripMenuItem 새우주ToolStripMenuItem;
        private System.Windows.Forms.ColorDialog penColorDialog;
        private System.Windows.Forms.FlowLayoutPanel toolBoxPanel;
        private System.Windows.Forms.Button addPanelButton;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.ToolStripMenuItem 격자ToolStripMenuItem;
        private Panel.PPanel scenePanel;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.Label currentFrameLabel;
        private System.Windows.Forms.Label currentLabel;
        private Panel.PPanel panelBoxPanel;
        private System.Windows.Forms.Label testLabel;
    }
}