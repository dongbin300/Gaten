namespace Gaten.Game.BrandNewType
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
            this.exitButton = new System.Windows.Forms.Button();
            this.mainFrame = new System.Windows.Forms.PictureBox();
            this.frameTimer = new System.Windows.Forms.Timer(this.components);
            this.railPositionLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.judgmentLabel = new System.Windows.Forms.Label();
            this.comboLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitButton.Location = new System.Drawing.Point(1177, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "종료";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // mainFrame
            // 
            this.mainFrame.Location = new System.Drawing.Point(12, 41);
            this.mainFrame.Name = "mainFrame";
            this.mainFrame.Size = new System.Drawing.Size(1240, 200);
            this.mainFrame.TabIndex = 1;
            this.mainFrame.TabStop = false;
            this.mainFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFrame_Paint);
            // 
            // frameTimer
            // 
            this.frameTimer.Interval = 15;
            this.frameTimer.Tick += new System.EventHandler(this.FrameTimer_Tick);
            // 
            // railPositionLabel
            // 
            this.railPositionLabel.AutoSize = true;
            this.railPositionLabel.Location = new System.Drawing.Point(1065, 20);
            this.railPositionLabel.Name = "railPositionLabel";
            this.railPositionLabel.Size = new System.Drawing.Size(106, 12);
            this.railPositionLabel.TabIndex = 2;
            this.railPositionLabel.Text = "[RAIL_POSITION]";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scoreLabel.Location = new System.Drawing.Point(565, 8);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(93, 24);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "[SCORE]";
            // 
            // judgmentLabel
            // 
            this.judgmentLabel.AutoSize = true;
            this.judgmentLabel.Font = new System.Drawing.Font("나눔고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.judgmentLabel.Location = new System.Drawing.Point(12, 244);
            this.judgmentLabel.Name = "judgmentLabel";
            this.judgmentLabel.Size = new System.Drawing.Size(222, 36);
            this.judgmentLabel.TabIndex = 4;
            this.judgmentLabel.Text = "[JUDGMENT]";
            // 
            // comboLabel
            // 
            this.comboLabel.AutoSize = true;
            this.comboLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboLabel.Location = new System.Drawing.Point(62, 280);
            this.comboLabel.Name = "comboLabel";
            this.comboLabel.Size = new System.Drawing.Size(114, 24);
            this.comboLabel.TabIndex = 5;
            this.comboLabel.Text = "[COMBO]";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.comboLabel);
            this.Controls.Add(this.judgmentLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.railPositionLabel);
            this.Controls.Add(this.mainFrame);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand New Type v0.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.mainFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox mainFrame;
        private System.Windows.Forms.Timer frameTimer;
        private System.Windows.Forms.Label railPositionLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label judgmentLabel;
        private System.Windows.Forms.Label comboLabel;
    }
}