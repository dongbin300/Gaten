namespace Gaten.GameTool.osu.CatchTheBeatKeyDisplayer
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
            this.shiftKeyPanel = new System.Windows.Forms.Panel();
            this.leftKeyPanel = new System.Windows.Forms.Panel();
            this.rightKeyPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // shiftKeyPanel
            // 
            this.shiftKeyPanel.Location = new System.Drawing.Point(12, 12);
            this.shiftKeyPanel.Name = "shiftKeyPanel";
            this.shiftKeyPanel.Size = new System.Drawing.Size(120, 40);
            this.shiftKeyPanel.TabIndex = 1;
            this.shiftKeyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ShiftKeyPanel_Paint);
            // 
            // leftKeyPanel
            // 
            this.leftKeyPanel.Location = new System.Drawing.Point(138, 12);
            this.leftKeyPanel.Name = "leftKeyPanel";
            this.leftKeyPanel.Size = new System.Drawing.Size(40, 40);
            this.leftKeyPanel.TabIndex = 1;
            this.leftKeyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LeftKeyPanel_Paint);
            // 
            // rightKeyPanel
            // 
            this.rightKeyPanel.Location = new System.Drawing.Point(184, 12);
            this.rightKeyPanel.Name = "rightKeyPanel";
            this.rightKeyPanel.Size = new System.Drawing.Size(40, 40);
            this.rightKeyPanel.TabIndex = 1;
            this.rightKeyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RightKeyPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(244, 65);
            this.Controls.Add(this.rightKeyPanel);
            this.Controls.Add(this.leftKeyPanel);
            this.Controls.Add(this.shiftKeyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel shiftKeyPanel;
        private System.Windows.Forms.Panel leftKeyPanel;
        private System.Windows.Forms.Panel rightKeyPanel;
    }
}