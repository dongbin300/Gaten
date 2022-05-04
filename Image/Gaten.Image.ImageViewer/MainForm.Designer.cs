namespace Gaten.Image.ImageViewer
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
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.투명도ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency01 = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency03 = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency05 = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency07 = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency09 = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency10 = new System.Windows.Forms.ToolStripMenuItem();
            this.항상위에표시ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.투명도ToolStripMenuItem,
            this.항상위에표시ToolStripMenuItem,
            this.toolStripSeparator1,
            this.종료ToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(181, 98);
            // 
            // 투명도ToolStripMenuItem
            // 
            this.투명도ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transparency01,
            this.transparency03,
            this.transparency05,
            this.transparency07,
            this.transparency09,
            this.transparency10});
            this.투명도ToolStripMenuItem.Name = "투명도ToolStripMenuItem";
            this.투명도ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.투명도ToolStripMenuItem.Text = "투명도";
            // 
            // transparency01
            // 
            this.transparency01.Name = "transparency01";
            this.transparency01.Size = new System.Drawing.Size(180, 22);
            this.transparency01.Text = "0.1";
            this.transparency01.Click += new System.EventHandler(this.transparency_Click);
            // 
            // transparency03
            // 
            this.transparency03.Name = "transparency03";
            this.transparency03.Size = new System.Drawing.Size(180, 22);
            this.transparency03.Text = "0.3";
            this.transparency03.Click += new System.EventHandler(this.transparency_Click);
            // 
            // transparency05
            // 
            this.transparency05.Name = "transparency05";
            this.transparency05.Size = new System.Drawing.Size(180, 22);
            this.transparency05.Text = "0.5";
            this.transparency05.Click += new System.EventHandler(this.transparency_Click);
            // 
            // transparency07
            // 
            this.transparency07.Name = "transparency07";
            this.transparency07.Size = new System.Drawing.Size(180, 22);
            this.transparency07.Text = "0.7";
            this.transparency07.Click += new System.EventHandler(this.transparency_Click);
            // 
            // transparency09
            // 
            this.transparency09.Name = "transparency09";
            this.transparency09.Size = new System.Drawing.Size(180, 22);
            this.transparency09.Text = "0.9";
            this.transparency09.Click += new System.EventHandler(this.transparency_Click);
            // 
            // transparency10
            // 
            this.transparency10.Name = "transparency10";
            this.transparency10.Size = new System.Drawing.Size(180, 22);
            this.transparency10.Text = "1.0";
            this.transparency10.Click += new System.EventHandler(this.transparency_Click);
            // 
            // 항상위에표시ToolStripMenuItem
            // 
            this.항상위에표시ToolStripMenuItem.Checked = true;
            this.항상위에표시ToolStripMenuItem.CheckOnClick = true;
            this.항상위에표시ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.항상위에표시ToolStripMenuItem.Name = "항상위에표시ToolStripMenuItem";
            this.항상위에표시ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.항상위에표시ToolStripMenuItem.Text = "항상 위에 표시";
            this.항상위에표시ToolStripMenuItem.Click += new System.EventHandler(this.항상위에표시ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 투명도ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency01;
        private System.Windows.Forms.ToolStripMenuItem transparency03;
        private System.Windows.Forms.ToolStripMenuItem transparency05;
        private System.Windows.Forms.ToolStripMenuItem transparency07;
        private System.Windows.Forms.ToolStripMenuItem transparency09;
        private System.Windows.Forms.ToolStripMenuItem transparency10;
        private System.Windows.Forms.ToolStripMenuItem 항상위에표시ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
    }
}