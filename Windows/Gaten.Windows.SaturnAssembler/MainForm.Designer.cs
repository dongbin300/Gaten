namespace Gaten.Windows.SaturnAssembler
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.assembleButton = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Panel();
            this.filename = new System.Windows.Forms.Label();
            this.alertLabel = new System.Windows.Forms.Label();
            this.lineLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // assembleButton
            // 
            this.assembleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.assembleButton.Location = new System.Drawing.Point(466, 12);
            this.assembleButton.Name = "assembleButton";
            this.assembleButton.Size = new System.Drawing.Size(80, 35);
            this.assembleButton.TabIndex = 0;
            this.assembleButton.Click += new System.EventHandler(this.assembleButton_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(190, 30);
            this.title.TabIndex = 1;
            this.title.Text = "Saturn Assembler";
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.openButton.Location = new System.Drawing.Point(294, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(80, 35);
            this.openButton.TabIndex = 0;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.saveButton.Location = new System.Drawing.Point(380, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 35);
            this.saveButton.TabIndex = 0;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.BackColor = System.Drawing.Color.Gainsboro;
            this.filename.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.filename.Location = new System.Drawing.Point(215, 16);
            this.filename.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.filename.Name = "filename";
            this.filename.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filename.Size = new System.Drawing.Size(57, 24);
            this.filename.TabIndex = 2;
            this.filename.Text = "label1";
            // 
            // alertLabel
            // 
            this.alertLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alertLabel.Location = new System.Drawing.Point(12, 480);
            this.alertLabel.Name = "alertLabel";
            this.alertLabel.Size = new System.Drawing.Size(534, 55);
            this.alertLabel.TabIndex = 3;
            this.alertLabel.Text = "[TEXT]";
            // 
            // lineLabel
            // 
            this.lineLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lineLabel.Location = new System.Drawing.Point(466, 548);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(80, 17);
            this.lineLabel.TabIndex = 3;
            this.lineLabel.Text = "line: ";
            this.lineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 574);
            this.Controls.Add(this.lineLabel);
            this.Controls.Add(this.alertLabel);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.assembleButton);
            this.Name = "MainForm";
            this.Text = "Saturn Assembler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel assembleButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel openButton;
        private System.Windows.Forms.Panel saveButton;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.Label alertLabel;
        private System.Windows.Forms.Label lineLabel;
    }
}