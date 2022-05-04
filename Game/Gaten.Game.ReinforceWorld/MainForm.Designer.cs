namespace Gaten.Game.ReinforceWorld
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
            this.reinforceButton = new System.Windows.Forms.Button();
            this.reinforcementValueLabel = new System.Windows.Forms.Label();
            this.weaponNameLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.gradeTierLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.delayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reinforceButton
            // 
            this.reinforceButton.BackColor = System.Drawing.Color.OrangeRed;
            this.reinforceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reinforceButton.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.reinforceButton.Location = new System.Drawing.Point(231, 88);
            this.reinforceButton.Name = "reinforceButton";
            this.reinforceButton.Size = new System.Drawing.Size(154, 39);
            this.reinforceButton.TabIndex = 0;
            this.reinforceButton.Text = "강화(Space)";
            this.reinforceButton.UseVisualStyleBackColor = false;
            this.reinforceButton.Click += new System.EventHandler(this.reinforceButton_Click);
            // 
            // reinforcementValueLabel
            // 
            this.reinforcementValueLabel.AutoSize = true;
            this.reinforcementValueLabel.Font = new System.Drawing.Font("나눔바른고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.reinforcementValueLabel.Location = new System.Drawing.Point(12, 96);
            this.reinforcementValueLabel.Name = "reinforcementValueLabel";
            this.reinforcementValueLabel.Size = new System.Drawing.Size(58, 24);
            this.reinforcementValueLabel.TabIndex = 1;
            this.reinforcementValueLabel.Text = "+000";
            // 
            // weaponNameLabel
            // 
            this.weaponNameLabel.AutoSize = true;
            this.weaponNameLabel.Font = new System.Drawing.Font("나눔바른고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.weaponNameLabel.Location = new System.Drawing.Point(65, 96);
            this.weaponNameLabel.Name = "weaponNameLabel";
            this.weaponNameLabel.Size = new System.Drawing.Size(124, 24);
            this.weaponNameLabel.TabIndex = 1;
            this.weaponNameLabel.Text = "무기이름이다";
            // 
            // moneyLabel
            // 
            this.moneyLabel.Font = new System.Drawing.Font("나눔바른고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.moneyLabel.Location = new System.Drawing.Point(231, 61);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(154, 24);
            this.moneyLabel.TabIndex = 1;
            this.moneyLabel.Text = "골드";
            this.moneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gradeTierLabel
            // 
            this.gradeTierLabel.AutoSize = true;
            this.gradeTierLabel.Font = new System.Drawing.Font("나눔바른고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradeTierLabel.Location = new System.Drawing.Point(12, 61);
            this.gradeTierLabel.Name = "gradeTierLabel";
            this.gradeTierLabel.Size = new System.Drawing.Size(129, 24);
            this.gradeTierLabel.TabIndex = 1;
            this.gradeTierLabel.Text = "그레이드 티어";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 10;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // delayLabel
            // 
            this.delayLabel.Font = new System.Drawing.Font("나눔바른고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.delayLabel.Location = new System.Drawing.Point(313, 0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(72, 20);
            this.delayLabel.TabIndex = 1;
            this.delayLabel.Text = "00.00초";
            this.delayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 129);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.gradeTierLabel);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.weaponNameLabel);
            this.Controls.Add(this.reinforcementValueLabel);
            this.Controls.Add(this.reinforceButton);
            this.Name = "MainForm";
            this.Text = "강화 월드";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reinforceButton;
        private System.Windows.Forms.Label reinforcementValueLabel;
        private System.Windows.Forms.Label weaponNameLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Label gradeTierLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer delayTimer;
        private System.Windows.Forms.Label delayLabel;
    }
}