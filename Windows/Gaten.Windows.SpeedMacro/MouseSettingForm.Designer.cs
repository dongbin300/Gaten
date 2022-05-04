namespace Gaten.Windows.SpeedMacro
{
    partial class MouseSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xPosTextBox = new System.Windows.Forms.TextBox();
            this.yPosTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.clickTypeComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xPosTextBox
            // 
            this.xPosTextBox.Location = new System.Drawing.Point(13, 13);
            this.xPosTextBox.Name = "xPosTextBox";
            this.xPosTextBox.Size = new System.Drawing.Size(45, 21);
            this.xPosTextBox.TabIndex = 0;
            // 
            // yPosTextBox
            // 
            this.yPosTextBox.Location = new System.Drawing.Point(64, 13);
            this.yPosTextBox.Name = "yPosTextBox";
            this.yPosTextBox.Size = new System.Drawing.Size(45, 21);
            this.yPosTextBox.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(23, 39);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "확인";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // clickTypeComboBox
            // 
            this.clickTypeComboBox.FormattingEnabled = true;
            this.clickTypeComboBox.Items.AddRange(new object[] {
            "클릭",
            "더블",
            "오른쪽"});
            this.clickTypeComboBox.Location = new System.Drawing.Point(115, 13);
            this.clickTypeComboBox.Name = "clickTypeComboBox";
            this.clickTypeComboBox.Size = new System.Drawing.Size(64, 20);
            this.clickTypeComboBox.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(104, 39);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "취소";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MouseSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(186, 68);
            this.Controls.Add(this.clickTypeComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.yPosTextBox);
            this.Controls.Add(this.xPosTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MouseSettingForm";
            this.Text = "MouseSettingForm";
            this.Load += new System.EventHandler(this.MouseSettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xPosTextBox;
        private System.Windows.Forms.TextBox yPosTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox clickTypeComboBox;
        private System.Windows.Forms.Button cancelButton;
    }
}