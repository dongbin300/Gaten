namespace Gaten.Data.Mem0r12e
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
            this.FileLabel = new System.Windows.Forms.Button();
            this.ProblemLabel = new System.Windows.Forms.TextBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.AnswerLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FileLabel
            // 
            this.FileLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.FileLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FileLabel.Enabled = false;
            this.FileLabel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FileLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileLabel.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 9F);
            this.FileLabel.ForeColor = System.Drawing.Color.White;
            this.FileLabel.Location = new System.Drawing.Point(0, 0);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(381, 23);
            this.FileLabel.TabIndex = 0;
            this.FileLabel.Text = "파일";
            this.FileLabel.UseVisualStyleBackColor = false;
            // 
            // ProblemLabel
            // 
            this.ProblemLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ProblemLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProblemLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProblemLabel.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 10F);
            this.ProblemLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ProblemLabel.Location = new System.Drawing.Point(23, 71);
            this.ProblemLabel.Multiline = true;
            this.ProblemLabel.Name = "ProblemLabel";
            this.ProblemLabel.ReadOnly = true;
            this.ProblemLabel.Size = new System.Drawing.Size(281, 107);
            this.ProblemLabel.TabIndex = 1;
            this.ProblemLabel.Text = "문제";
            // 
            // InputTextBox
            // 
            this.InputTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InputTextBox.Location = new System.Drawing.Point(0, 223);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(381, 14);
            this.InputTextBox.TabIndex = 2;
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.AnswerLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AnswerLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.AnswerLabel.Font = new System.Drawing.Font("나눔바른고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AnswerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.AnswerLabel.Location = new System.Drawing.Point(0, 29);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.ReadOnly = true;
            this.AnswerLabel.Size = new System.Drawing.Size(381, 15);
            this.AnswerLabel.TabIndex = 1;
            this.AnswerLabel.Text = "정답";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(381, 237);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.ProblemLabel);
            this.Controls.Add(this.FileLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEM0R12E";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FileLabel;
        private System.Windows.Forms.TextBox ProblemLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox AnswerLabel;
    }
}