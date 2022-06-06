namespace Gaten.Audio.VirtualKeyboard
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
            this.keyboardBox = new System.Windows.Forms.PictureBox();
            this.ChordLabel = new System.Windows.Forms.Label();
            this.keyLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.성조ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.into0 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoS1 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoS2 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoS3 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoS4 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoS5 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoS6 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoP1 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoP2 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoP3 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoP4 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoP5 = new System.Windows.Forms.ToolStripMenuItem();
            this.intoP6 = new System.Windows.Forms.ToolStripMenuItem();
            this.화음ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.harm1 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm2 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm3 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm4 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm5 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm6 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm7 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm8 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm9 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm10 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm11 = new System.Windows.Forms.ToolStripMenuItem();
            this.harm12 = new System.Windows.Forms.ToolStripMenuItem();
            this.키ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyC = new System.Windows.Forms.ToolStripMenuItem();
            this.keyCS = new System.Windows.Forms.ToolStripMenuItem();
            this.keyD = new System.Windows.Forms.ToolStripMenuItem();
            this.keyDS = new System.Windows.Forms.ToolStripMenuItem();
            this.keyE = new System.Windows.Forms.ToolStripMenuItem();
            this.keyF = new System.Windows.Forms.ToolStripMenuItem();
            this.keyFS = new System.Windows.Forms.ToolStripMenuItem();
            this.keyG = new System.Windows.Forms.ToolStripMenuItem();
            this.keyGS = new System.Windows.Forms.ToolStripMenuItem();
            this.keyA = new System.Windows.Forms.ToolStripMenuItem();
            this.keyAS = new System.Windows.Forms.ToolStripMenuItem();
            this.keyB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.증가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.감소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.리셋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.색상ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.개발자ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyboardBox
            // 
            this.keyboardBox.Location = new System.Drawing.Point(0, 27);
            this.keyboardBox.Name = "keyboardBox";
            this.keyboardBox.Size = new System.Drawing.Size(480, 160);
            this.keyboardBox.TabIndex = 0;
            this.keyboardBox.TabStop = false;
            this.keyboardBox.Paint += new System.Windows.Forms.PaintEventHandler(this.KeyboardBox_Paint);
            this.keyboardBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KeyboardBox_MouseDown);
            // 
            // ChordLabel
            // 
            this.ChordLabel.AutoSize = true;
            this.ChordLabel.Font = new System.Drawing.Font("나눔바른고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ChordLabel.Location = new System.Drawing.Point(486, 27);
            this.ChordLabel.Name = "ChordLabel";
            this.ChordLabel.Size = new System.Drawing.Size(84, 24);
            this.ChordLabel.TabIndex = 1;
            this.ChordLabel.Text = "[Chord]";
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(488, 64);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(39, 12);
            this.keyLabel.TabIndex = 2;
            this.keyLabel.Text = "[Key]";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.설정ToolStripMenuItem,
            this.도움말ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.성조ToolStripMenuItem,
            this.화음ToolStripMenuItem,
            this.키ToolStripMenuItem,
            this.리셋ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem1.Text = "보기";
            // 
            // 성조ToolStripMenuItem
            // 
            this.성조ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.into0,
            this.intoS1,
            this.intoS2,
            this.intoS3,
            this.intoS4,
            this.intoS5,
            this.intoS6,
            this.intoP1,
            this.intoP2,
            this.intoP3,
            this.intoP4,
            this.intoP5,
            this.intoP6});
            this.성조ToolStripMenuItem.Name = "성조ToolStripMenuItem";
            this.성조ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.성조ToolStripMenuItem.Text = "성조";
            // 
            // into0
            // 
            this.into0.Name = "into0";
            this.into0.Size = new System.Drawing.Size(157, 22);
            this.into0.Text = " ";
            this.into0.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoS1
            // 
            this.intoS1.Name = "intoS1";
            this.intoS1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.intoS1.Size = new System.Drawing.Size(157, 22);
            this.intoS1.Text = "#";
            this.intoS1.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoS2
            // 
            this.intoS2.Name = "intoS2";
            this.intoS2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.intoS2.Size = new System.Drawing.Size(157, 22);
            this.intoS2.Text = "##";
            this.intoS2.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoS3
            // 
            this.intoS3.Name = "intoS3";
            this.intoS3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.intoS3.Size = new System.Drawing.Size(157, 22);
            this.intoS3.Text = "###";
            this.intoS3.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoS4
            // 
            this.intoS4.Name = "intoS4";
            this.intoS4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.intoS4.Size = new System.Drawing.Size(157, 22);
            this.intoS4.Text = "####";
            this.intoS4.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoS5
            // 
            this.intoS5.Name = "intoS5";
            this.intoS5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.intoS5.Size = new System.Drawing.Size(157, 22);
            this.intoS5.Text = "#####";
            this.intoS5.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoS6
            // 
            this.intoS6.Name = "intoS6";
            this.intoS6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.intoS6.Size = new System.Drawing.Size(157, 22);
            this.intoS6.Text = "######";
            this.intoS6.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoP1
            // 
            this.intoP1.Name = "intoP1";
            this.intoP1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.intoP1.Size = new System.Drawing.Size(157, 22);
            this.intoP1.Text = "b";
            this.intoP1.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoP2
            // 
            this.intoP2.Name = "intoP2";
            this.intoP2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.intoP2.Size = new System.Drawing.Size(157, 22);
            this.intoP2.Text = "bb";
            this.intoP2.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoP3
            // 
            this.intoP3.Name = "intoP3";
            this.intoP3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.intoP3.Size = new System.Drawing.Size(157, 22);
            this.intoP3.Text = "bbb";
            this.intoP3.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoP4
            // 
            this.intoP4.Name = "intoP4";
            this.intoP4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.intoP4.Size = new System.Drawing.Size(157, 22);
            this.intoP4.Text = "bbbb";
            this.intoP4.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoP5
            // 
            this.intoP5.Name = "intoP5";
            this.intoP5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
            this.intoP5.Size = new System.Drawing.Size(157, 22);
            this.intoP5.Text = "bbbbb";
            this.intoP5.Click += new System.EventHandler(this.Into_Click);
            // 
            // intoP6
            // 
            this.intoP6.Name = "intoP6";
            this.intoP6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D6)));
            this.intoP6.Size = new System.Drawing.Size(157, 22);
            this.intoP6.Text = "bbbbbb";
            this.intoP6.Click += new System.EventHandler(this.Into_Click);
            // 
            // 화음ToolStripMenuItem
            // 
            this.화음ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.harm1,
            this.harm2,
            this.harm3,
            this.harm4,
            this.harm5,
            this.harm6,
            this.harm7,
            this.harm8,
            this.harm9,
            this.harm10,
            this.harm11,
            this.harm12});
            this.화음ToolStripMenuItem.Name = "화음ToolStripMenuItem";
            this.화음ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.화음ToolStripMenuItem.Text = "화음";
            // 
            // harm1
            // 
            this.harm1.Name = "harm1";
            this.harm1.Size = new System.Drawing.Size(114, 22);
            this.harm1.Text = "M";
            this.harm1.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm2
            // 
            this.harm2.Name = "harm2";
            this.harm2.Size = new System.Drawing.Size(114, 22);
            this.harm2.Text = "m";
            this.harm2.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm3
            // 
            this.harm3.Name = "harm3";
            this.harm3.Size = new System.Drawing.Size(114, 22);
            this.harm3.Text = "dim";
            this.harm3.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm4
            // 
            this.harm4.Name = "harm4";
            this.harm4.Size = new System.Drawing.Size(114, 22);
            this.harm4.Text = "aug";
            this.harm4.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm5
            // 
            this.harm5.Name = "harm5";
            this.harm5.Size = new System.Drawing.Size(114, 22);
            this.harm5.Text = "M7";
            this.harm5.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm6
            // 
            this.harm6.Name = "harm6";
            this.harm6.Size = new System.Drawing.Size(114, 22);
            this.harm6.Text = "7";
            this.harm6.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm7
            // 
            this.harm7.Name = "harm7";
            this.harm7.Size = new System.Drawing.Size(114, 22);
            this.harm7.Text = "m7";
            this.harm7.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm8
            // 
            this.harm8.Name = "harm8";
            this.harm8.Size = new System.Drawing.Size(114, 22);
            this.harm8.Text = "m7(b5)";
            this.harm8.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm9
            // 
            this.harm9.Name = "harm9";
            this.harm9.Size = new System.Drawing.Size(114, 22);
            this.harm9.Text = "dim7";
            this.harm9.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm10
            // 
            this.harm10.Name = "harm10";
            this.harm10.Size = new System.Drawing.Size(114, 22);
            this.harm10.Text = "sus4";
            this.harm10.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm11
            // 
            this.harm11.Name = "harm11";
            this.harm11.Size = new System.Drawing.Size(114, 22);
            this.harm11.Text = "6";
            this.harm11.Click += new System.EventHandler(this.Harm_Click);
            // 
            // harm12
            // 
            this.harm12.Name = "harm12";
            this.harm12.Size = new System.Drawing.Size(114, 22);
            this.harm12.Text = "m6";
            this.harm12.Click += new System.EventHandler(this.Harm_Click);
            // 
            // 키ToolStripMenuItem
            // 
            this.키ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyC,
            this.keyCS,
            this.keyD,
            this.keyDS,
            this.keyE,
            this.keyF,
            this.keyFS,
            this.keyG,
            this.keyGS,
            this.keyA,
            this.keyAS,
            this.keyB,
            this.toolStripMenuItem2,
            this.증가ToolStripMenuItem,
            this.감소ToolStripMenuItem});
            this.키ToolStripMenuItem.Name = "키ToolStripMenuItem";
            this.키ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.키ToolStripMenuItem.Text = "키";
            // 
            // keyC
            // 
            this.keyC.Name = "keyC";
            this.keyC.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.keyC.Size = new System.Drawing.Size(180, 22);
            this.keyC.Text = "C";
            this.keyC.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyCS
            // 
            this.keyCS.Name = "keyCS";
            this.keyCS.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.keyCS.Size = new System.Drawing.Size(180, 22);
            this.keyCS.Text = "C#";
            this.keyCS.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyD
            // 
            this.keyD.Name = "keyD";
            this.keyD.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.keyD.Size = new System.Drawing.Size(180, 22);
            this.keyD.Text = "D";
            this.keyD.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyDS
            // 
            this.keyDS.Name = "keyDS";
            this.keyDS.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.keyDS.Size = new System.Drawing.Size(180, 22);
            this.keyDS.Text = "D#";
            this.keyDS.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyE
            // 
            this.keyE.Name = "keyE";
            this.keyE.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.keyE.Size = new System.Drawing.Size(180, 22);
            this.keyE.Text = "E";
            this.keyE.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyF
            // 
            this.keyF.Name = "keyF";
            this.keyF.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.keyF.Size = new System.Drawing.Size(180, 22);
            this.keyF.Text = "F";
            this.keyF.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyFS
            // 
            this.keyFS.Name = "keyFS";
            this.keyFS.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.keyFS.Size = new System.Drawing.Size(180, 22);
            this.keyFS.Text = "F#";
            this.keyFS.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyG
            // 
            this.keyG.Name = "keyG";
            this.keyG.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.keyG.Size = new System.Drawing.Size(180, 22);
            this.keyG.Text = "G";
            this.keyG.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyGS
            // 
            this.keyGS.Name = "keyGS";
            this.keyGS.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.keyGS.Size = new System.Drawing.Size(180, 22);
            this.keyGS.Text = "G#";
            this.keyGS.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyA
            // 
            this.keyA.Name = "keyA";
            this.keyA.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.keyA.Size = new System.Drawing.Size(180, 22);
            this.keyA.Text = "A";
            this.keyA.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyAS
            // 
            this.keyAS.Name = "keyAS";
            this.keyAS.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.keyAS.Size = new System.Drawing.Size(180, 22);
            this.keyAS.Text = "A#";
            this.keyAS.Click += new System.EventHandler(this.Key_Click);
            // 
            // keyB
            // 
            this.keyB.Name = "keyB";
            this.keyB.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.keyB.Size = new System.Drawing.Size(180, 22);
            this.keyB.Text = "B";
            this.keyB.Click += new System.EventHandler(this.Key_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // 증가ToolStripMenuItem
            // 
            this.증가ToolStripMenuItem.Name = "증가ToolStripMenuItem";
            this.증가ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.증가ToolStripMenuItem.Text = "증가";
            this.증가ToolStripMenuItem.Click += new System.EventHandler(this.증가ToolStripMenuItem_Click);
            // 
            // 감소ToolStripMenuItem
            // 
            this.감소ToolStripMenuItem.Name = "감소ToolStripMenuItem";
            this.감소ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.감소ToolStripMenuItem.Text = "감소";
            this.감소ToolStripMenuItem.Click += new System.EventHandler(this.감소ToolStripMenuItem_Click);
            // 
            // 리셋ToolStripMenuItem
            // 
            this.리셋ToolStripMenuItem.Name = "리셋ToolStripMenuItem";
            this.리셋ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.리셋ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.리셋ToolStripMenuItem.Text = "리셋";
            this.리셋ToolStripMenuItem.Click += new System.EventHandler(this.리셋ToolStripMenuItem_Click);
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.색상ToolStripMenuItem});
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.설정ToolStripMenuItem.Text = "설정";
            // 
            // 색상ToolStripMenuItem
            // 
            this.색상ToolStripMenuItem.Name = "색상ToolStripMenuItem";
            this.색상ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.색상ToolStripMenuItem.Text = "색상";
            // 
            // 도움말ToolStripMenuItem
            // 
            this.도움말ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.개발자ToolStripMenuItem});
            this.도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
            this.도움말ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.도움말ToolStripMenuItem.Text = "도움말";
            // 
            // 개발자ToolStripMenuItem
            // 
            this.개발자ToolStripMenuItem.Name = "개발자ToolStripMenuItem";
            this.개발자ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.개발자ToolStripMenuItem.Text = "개발자";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 188);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.ChordLabel);
            this.Controls.Add(this.keyboardBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.keyboardBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox keyboardBox;
        private System.Windows.Forms.Label ChordLabel;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 성조ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화음ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 키ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 리셋ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 색상ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 개발자ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem into0;
        private System.Windows.Forms.ToolStripMenuItem intoS1;
        private System.Windows.Forms.ToolStripMenuItem intoS2;
        private System.Windows.Forms.ToolStripMenuItem intoS3;
        private System.Windows.Forms.ToolStripMenuItem intoS4;
        private System.Windows.Forms.ToolStripMenuItem intoS5;
        private System.Windows.Forms.ToolStripMenuItem intoS6;
        private System.Windows.Forms.ToolStripMenuItem intoP1;
        private System.Windows.Forms.ToolStripMenuItem intoP2;
        private System.Windows.Forms.ToolStripMenuItem intoP3;
        private System.Windows.Forms.ToolStripMenuItem intoP4;
        private System.Windows.Forms.ToolStripMenuItem intoP5;
        private System.Windows.Forms.ToolStripMenuItem intoP6;
        private System.Windows.Forms.ToolStripMenuItem harm1;
        private System.Windows.Forms.ToolStripMenuItem harm2;
        private System.Windows.Forms.ToolStripMenuItem harm3;
        private System.Windows.Forms.ToolStripMenuItem harm4;
        private System.Windows.Forms.ToolStripMenuItem harm5;
        private System.Windows.Forms.ToolStripMenuItem harm6;
        private System.Windows.Forms.ToolStripMenuItem harm7;
        private System.Windows.Forms.ToolStripMenuItem harm8;
        private System.Windows.Forms.ToolStripMenuItem harm9;
        private System.Windows.Forms.ToolStripMenuItem harm10;
        private System.Windows.Forms.ToolStripMenuItem harm11;
        private System.Windows.Forms.ToolStripMenuItem harm12;
        private System.Windows.Forms.ToolStripMenuItem keyC;
        private System.Windows.Forms.ToolStripMenuItem keyCS;
        private System.Windows.Forms.ToolStripMenuItem keyD;
        private System.Windows.Forms.ToolStripMenuItem keyDS;
        private System.Windows.Forms.ToolStripMenuItem keyE;
        private System.Windows.Forms.ToolStripMenuItem keyF;
        private System.Windows.Forms.ToolStripMenuItem keyFS;
        private System.Windows.Forms.ToolStripMenuItem keyG;
        private System.Windows.Forms.ToolStripMenuItem keyGS;
        private System.Windows.Forms.ToolStripMenuItem keyA;
        private System.Windows.Forms.ToolStripMenuItem keyAS;
        private System.Windows.Forms.ToolStripMenuItem keyB;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 증가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 감소ToolStripMenuItem;
    }
}