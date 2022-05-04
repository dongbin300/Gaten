namespace Gaten.Game.InstanceGH
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
            this.ghbt = new System.Windows.Forms.Button();
            this.sellbt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.moneylb = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bglb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ghnumlb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.bonus = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ghbt
            // 
            this.ghbt.Location = new System.Drawing.Point(13, 13);
            this.ghbt.Name = "ghbt";
            this.ghbt.Size = new System.Drawing.Size(259, 58);
            this.ghbt.TabIndex = 0;
            this.ghbt.Text = "강화하기\r\n";
            this.ghbt.UseVisualStyleBackColor = true;
            this.ghbt.Click += new System.EventHandler(this.ghbt_Click);
            // 
            // sellbt
            // 
            this.sellbt.Location = new System.Drawing.Point(13, 77);
            this.sellbt.Name = "sellbt";
            this.sellbt.Size = new System.Drawing.Size(259, 27);
            this.sellbt.TabIndex = 1;
            this.sellbt.Text = "판매하기\r\n";
            this.sellbt.UseVisualStyleBackColor = true;
            this.sellbt.Click += new System.EventHandler(this.sellbt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "돈";
            // 
            // moneylb
            // 
            this.moneylb.AutoSize = true;
            this.moneylb.Location = new System.Drawing.Point(29, 17);
            this.moneylb.Name = "moneylb";
            this.moneylb.Size = new System.Drawing.Size(11, 12);
            this.moneylb.TabIndex = 3;
            this.moneylb.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bglb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.moneylb);
            this.groupBox1.Location = new System.Drawing.Point(13, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 62);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "자금";
            // 
            // bglb
            // 
            this.bglb.AutoSize = true;
            this.bglb.Location = new System.Drawing.Point(44, 36);
            this.bglb.Name = "bglb";
            this.bglb.Size = new System.Drawing.Size(11, 12);
            this.bglb.TabIndex = 5;
            this.bglb.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "뱃지";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ghnumlb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(136, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 62);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "무기";
            // 
            // ghnumlb
            // 
            this.ghnumlb.AutoSize = true;
            this.ghnumlb.Font = new System.Drawing.Font("돋움", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ghnumlb.Location = new System.Drawing.Point(65, 16);
            this.ghnumlb.Name = "ghnumlb";
            this.ghnumlb.Size = new System.Drawing.Size(34, 32);
            this.ghnumlb.TabIndex = 1;
            this.ghnumlb.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(25, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "+";
            // 
            // tick
            // 
            this.tick.Enabled = true;
            this.tick.Interval = 50;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // bonus
            // 
            this.bonus.Enabled = true;
            this.bonus.Interval = 500;
            this.bonus.Tick += new System.EventHandler(this.bonus_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 180);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sellbt);
            this.Controls.Add(this.ghbt);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "즉석강화v1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ghbt;
        private System.Windows.Forms.Button sellbt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label moneylb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ghnumlb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tick;
        private System.Windows.Forms.Timer bonus;
        private System.Windows.Forms.Label bglb;
        private System.Windows.Forms.Label label3;
    }
}