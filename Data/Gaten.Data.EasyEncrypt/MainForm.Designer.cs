namespace Gaten.Data.EasyEncrypt
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
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.decryptIconPanel = new System.Windows.Forms.Panel();
            this.selectIconPanel = new System.Windows.Forms.Panel();
            this.encryptIconPanel = new System.Windows.Forms.Panel();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(205, 13);
            this.fileTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.fileTextBox.Multiline = true;
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(613, 192);
            this.fileTextBox.TabIndex = 0;
            // 
            // encryptButton
            // 
            this.encryptButton.FlatAppearance.BorderSize = 0;
            this.encryptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.encryptButton.Font = new System.Drawing.Font("나눔바른고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.encryptButton.Location = new System.Drawing.Point(3, 74);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(197, 74);
            this.encryptButton.TabIndex = 2;
            this.encryptButton.Text = "   Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.FlatAppearance.BorderSize = 0;
            this.decryptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decryptButton.Font = new System.Drawing.Font("나눔바른고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.decryptButton.Location = new System.Drawing.Point(3, 148);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(197, 74);
            this.decryptButton.TabIndex = 2;
            this.decryptButton.Text = "   Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.panel1.Controls.Add(this.decryptIconPanel);
            this.panel1.Controls.Add(this.decryptButton);
            this.panel1.Controls.Add(this.selectIconPanel);
            this.panel1.Controls.Add(this.encryptIconPanel);
            this.panel1.Controls.Add(this.selectFileButton);
            this.panel1.Controls.Add(this.encryptButton);
            this.panel1.Location = new System.Drawing.Point(-6, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 534);
            this.panel1.TabIndex = 3;
            // 
            // decryptIconPanel
            // 
            this.decryptIconPanel.BackgroundImage = global::Gaten.Data.EasyEncrypt.Properties.Resources.key;
            this.decryptIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.decryptIconPanel.Location = new System.Drawing.Point(18, 162);
            this.decryptIconPanel.Name = "decryptIconPanel";
            this.decryptIconPanel.Size = new System.Drawing.Size(40, 40);
            this.decryptIconPanel.TabIndex = 4;
            // 
            // selectIconPanel
            // 
            this.selectIconPanel.BackgroundImage = global::Gaten.Data.EasyEncrypt.Properties.Resources.folder;
            this.selectIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectIconPanel.Location = new System.Drawing.Point(18, 13);
            this.selectIconPanel.Name = "selectIconPanel";
            this.selectIconPanel.Size = new System.Drawing.Size(40, 40);
            this.selectIconPanel.TabIndex = 4;
            // 
            // encryptIconPanel
            // 
            this.encryptIconPanel.BackgroundImage = global::Gaten.Data.EasyEncrypt.Properties.Resources._lock;
            this.encryptIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.encryptIconPanel.Location = new System.Drawing.Point(18, 87);
            this.encryptIconPanel.Name = "encryptIconPanel";
            this.encryptIconPanel.Size = new System.Drawing.Size(40, 40);
            this.encryptIconPanel.TabIndex = 4;
            // 
            // selectFileButton
            // 
            this.selectFileButton.FlatAppearance.BorderSize = 0;
            this.selectFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFileButton.Font = new System.Drawing.Font("나눔바른고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectFileButton.Location = new System.Drawing.Point(3, 0);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(197, 74);
            this.selectFileButton.TabIndex = 2;
            this.selectFileButton.Text = "Select";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 218);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fileTextBox);
            this.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Easy Encrypt";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel decryptIconPanel;
        private System.Windows.Forms.Panel selectIconPanel;
        private System.Windows.Forms.Panel encryptIconPanel;
        private System.Windows.Forms.Button selectFileButton;
    }
}