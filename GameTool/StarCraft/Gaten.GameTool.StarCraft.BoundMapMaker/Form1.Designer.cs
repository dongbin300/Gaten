namespace Gaten.GameTool.StarCraft.BoundMapMaker
{
    partial class Form1
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
            this.boundPanel = new Gaten.GameTool.StarCraft.BoundMapMaker.DoubleBufferPanel();
            this.TileEditSizeButton1 = new System.Windows.Forms.Button();
            this.TileEditSizeButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boundPanel
            // 
            this.boundPanel.Location = new System.Drawing.Point(0, 0);
            this.boundPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boundPanel.Name = "boundPanel";
            this.boundPanel.Size = new System.Drawing.Size(800, 600);
            this.boundPanel.TabIndex = 0;
            this.boundPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.boundPanel_Paint);
            this.boundPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boundPanel_MouseDown);
            this.boundPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.boundPanel_MouseMove);
            // 
            // TileEditSizeButton1
            // 
            this.TileEditSizeButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TileEditSizeButton1.Location = new System.Drawing.Point(806, 4);
            this.TileEditSizeButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TileEditSizeButton1.Name = "TileEditSizeButton1";
            this.TileEditSizeButton1.Size = new System.Drawing.Size(60, 60);
            this.TileEditSizeButton1.TabIndex = 1;
            this.TileEditSizeButton1.Text = "□";
            this.TileEditSizeButton1.UseVisualStyleBackColor = true;
            this.TileEditSizeButton1.Click += new System.EventHandler(this.TileEditSizeButton1_Click);
            // 
            // TileEditSizeButton2
            // 
            this.TileEditSizeButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TileEditSizeButton2.Location = new System.Drawing.Point(872, 4);
            this.TileEditSizeButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TileEditSizeButton2.Name = "TileEditSizeButton2";
            this.TileEditSizeButton2.Size = new System.Drawing.Size(60, 60);
            this.TileEditSizeButton2.TabIndex = 1;
            this.TileEditSizeButton2.Text = "□□\r\n□□";
            this.TileEditSizeButton2.UseVisualStyleBackColor = true;
            this.TileEditSizeButton2.Click += new System.EventHandler(this.TileEditSizeButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 606);
            this.Controls.Add(this.TileEditSizeButton2);
            this.Controls.Add(this.TileEditSizeButton1);
            this.Controls.Add(this.boundPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Bound Map Maker V0.1.1 by Gaten";
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferPanel boundPanel;
        private System.Windows.Forms.Button TileEditSizeButton1;
        private System.Windows.Forms.Button TileEditSizeButton2;
    }
}