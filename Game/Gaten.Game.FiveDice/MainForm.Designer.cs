namespace Gaten.Game.FiveDice
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
            this.Dice1Button = new System.Windows.Forms.Button();
            this.Dice2Button = new System.Windows.Forms.Button();
            this.Dice3Button = new System.Windows.Forms.Button();
            this.Dice4Button = new System.Windows.Forms.Button();
            this.Dice5Button = new System.Windows.Forms.Button();
            this.RollButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Dice1Button
            // 
            this.Dice1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dice1Button.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Dice1Button.Location = new System.Drawing.Point(12, 12);
            this.Dice1Button.Name = "Dice1Button";
            this.Dice1Button.Size = new System.Drawing.Size(60, 60);
            this.Dice1Button.TabIndex = 0;
            this.Dice1Button.Text = "1";
            this.Dice1Button.UseVisualStyleBackColor = true;
            this.Dice1Button.Click += new System.EventHandler(this.Dice1Button_Click);
            // 
            // Dice2Button
            // 
            this.Dice2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dice2Button.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Dice2Button.Location = new System.Drawing.Point(78, 12);
            this.Dice2Button.Name = "Dice2Button";
            this.Dice2Button.Size = new System.Drawing.Size(60, 60);
            this.Dice2Button.TabIndex = 0;
            this.Dice2Button.Text = "2";
            this.Dice2Button.UseVisualStyleBackColor = true;
            this.Dice2Button.Click += new System.EventHandler(this.Dice2Button_Click);
            // 
            // Dice3Button
            // 
            this.Dice3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dice3Button.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Dice3Button.Location = new System.Drawing.Point(144, 12);
            this.Dice3Button.Name = "Dice3Button";
            this.Dice3Button.Size = new System.Drawing.Size(60, 60);
            this.Dice3Button.TabIndex = 0;
            this.Dice3Button.Text = "3";
            this.Dice3Button.UseVisualStyleBackColor = true;
            this.Dice3Button.Click += new System.EventHandler(this.Dice3Button_Click);
            // 
            // Dice4Button
            // 
            this.Dice4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dice4Button.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Dice4Button.Location = new System.Drawing.Point(210, 12);
            this.Dice4Button.Name = "Dice4Button";
            this.Dice4Button.Size = new System.Drawing.Size(60, 60);
            this.Dice4Button.TabIndex = 0;
            this.Dice4Button.Text = "4";
            this.Dice4Button.UseVisualStyleBackColor = true;
            this.Dice4Button.Click += new System.EventHandler(this.Dice4Button_Click);
            // 
            // Dice5Button
            // 
            this.Dice5Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dice5Button.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Dice5Button.Location = new System.Drawing.Point(276, 12);
            this.Dice5Button.Name = "Dice5Button";
            this.Dice5Button.Size = new System.Drawing.Size(60, 60);
            this.Dice5Button.TabIndex = 0;
            this.Dice5Button.Text = "5";
            this.Dice5Button.UseVisualStyleBackColor = true;
            this.Dice5Button.Click += new System.EventHandler(this.Dice5Button_Click);
            // 
            // RollButton
            // 
            this.RollButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RollButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RollButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RollButton.Location = new System.Drawing.Point(0, 421);
            this.RollButton.Name = "RollButton";
            this.RollButton.Size = new System.Drawing.Size(345, 66);
            this.RollButton.TabIndex = 0;
            this.RollButton.Text = "ROLL";
            this.RollButton.UseVisualStyleBackColor = false;
            this.RollButton.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 487);
            this.Controls.Add(this.Dice5Button);
            this.Controls.Add(this.Dice4Button);
            this.Controls.Add(this.Dice3Button);
            this.Controls.Add(this.Dice2Button);
            this.Controls.Add(this.RollButton);
            this.Controls.Add(this.Dice1Button);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "MainForm";
            this.Text = "Five Dice Deluxe!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Dice1Button;
        private System.Windows.Forms.Button Dice2Button;
        private System.Windows.Forms.Button Dice3Button;
        private System.Windows.Forms.Button Dice4Button;
        private System.Windows.Forms.Button Dice5Button;
        private System.Windows.Forms.Button RollButton;
    }
}

