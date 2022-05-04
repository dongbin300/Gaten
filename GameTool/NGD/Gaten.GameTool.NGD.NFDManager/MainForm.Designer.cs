namespace Gaten.GameTool.NGD.NFDManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBox = new System.Windows.Forms.ListBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MonsterPage = new System.Windows.Forms.TabPage();
            this.MaterialPage = new System.Windows.Forms.TabPage();
            this.PotionPage = new System.Windows.Forms.TabPage();
            this.EquipmentPage = new System.Windows.Forms.TabPage();
            this.SkillPage = new System.Windows.Forms.TabPage();
            this.DungeonPage = new System.Windows.Forms.TabPage();
            this.dungeonNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monsterButton = new System.Windows.Forms.Button();
            this.materialButton = new System.Windows.Forms.Button();
            this.potionButton = new System.Windows.Forms.Button();
            this.equipmentButton = new System.Windows.Forms.Button();
            this.skillButton = new System.Windows.Forms.Button();
            this.dungeonButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.waveCountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dungeonMonsterTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.monsterCountMinTextBox = new System.Windows.Forms.TextBox();
            this.monsterCountMaxTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.monsterDropItemTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.monsterNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.registButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.monsterExpTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.monsterGoldTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.monsterPowerTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.monsterStaminaTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.monsterIntelliTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.monsterWillpowerTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.monsterConcentrationTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.monsterAgilityTextBox = new System.Windows.Forms.TextBox();
            this.materialNameTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.materialRankTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.materialValueTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.materialLevelTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.materialDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.equipmentFormattedEffectTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.equipmentLevelTextBox = new System.Windows.Forms.TextBox();
            this.equipmentRankTextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.equipmentNameTextBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.equipmentTypeTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.MonsterPage.SuspendLayout();
            this.MaterialPage.SuspendLayout();
            this.EquipmentPage.SuspendLayout();
            this.DungeonPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("맑은 고딕 Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 21;
            this.listBox.Location = new System.Drawing.Point(13, 13);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(192, 424);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.MonsterPage);
            this.TabControl.Controls.Add(this.MaterialPage);
            this.TabControl.Controls.Add(this.PotionPage);
            this.TabControl.Controls.Add(this.EquipmentPage);
            this.TabControl.Controls.Add(this.SkillPage);
            this.TabControl.Controls.Add(this.DungeonPage);
            this.TabControl.Location = new System.Drawing.Point(211, 42);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(577, 396);
            this.TabControl.TabIndex = 1;
            // 
            // MonsterPage
            // 
            this.MonsterPage.Controls.Add(this.monsterDropItemTextBox);
            this.MonsterPage.Controls.Add(this.label9);
            this.MonsterPage.Controls.Add(this.monsterAgilityTextBox);
            this.MonsterPage.Controls.Add(this.monsterWillpowerTextBox);
            this.MonsterPage.Controls.Add(this.label15);
            this.MonsterPage.Controls.Add(this.label13);
            this.MonsterPage.Controls.Add(this.monsterConcentrationTextBox);
            this.MonsterPage.Controls.Add(this.label14);
            this.MonsterPage.Controls.Add(this.monsterIntelliTextBox);
            this.MonsterPage.Controls.Add(this.label12);
            this.MonsterPage.Controls.Add(this.monsterStaminaTextBox);
            this.MonsterPage.Controls.Add(this.label11);
            this.MonsterPage.Controls.Add(this.monsterPowerTextBox);
            this.MonsterPage.Controls.Add(this.label8);
            this.MonsterPage.Controls.Add(this.monsterGoldTextBox);
            this.MonsterPage.Controls.Add(this.label7);
            this.MonsterPage.Controls.Add(this.monsterExpTextBox);
            this.MonsterPage.Controls.Add(this.label6);
            this.MonsterPage.Controls.Add(this.monsterNameTextBox);
            this.MonsterPage.Controls.Add(this.label10);
            this.MonsterPage.Location = new System.Drawing.Point(4, 22);
            this.MonsterPage.Name = "MonsterPage";
            this.MonsterPage.Padding = new System.Windows.Forms.Padding(3);
            this.MonsterPage.Size = new System.Drawing.Size(569, 370);
            this.MonsterPage.TabIndex = 1;
            this.MonsterPage.Text = "MonsterPage";
            this.MonsterPage.UseVisualStyleBackColor = true;
            // 
            // MaterialPage
            // 
            this.MaterialPage.Controls.Add(this.materialDescriptionTextBox);
            this.MaterialPage.Controls.Add(this.label19);
            this.MaterialPage.Controls.Add(this.materialValueTextBox);
            this.MaterialPage.Controls.Add(this.label20);
            this.MaterialPage.Controls.Add(this.materialLevelTextBox);
            this.MaterialPage.Controls.Add(this.materialRankTextBox);
            this.MaterialPage.Controls.Add(this.label21);
            this.MaterialPage.Controls.Add(this.materialNameTextBox);
            this.MaterialPage.Controls.Add(this.label18);
            this.MaterialPage.Controls.Add(this.label17);
            this.MaterialPage.Controls.Add(this.label16);
            this.MaterialPage.Location = new System.Drawing.Point(4, 22);
            this.MaterialPage.Name = "MaterialPage";
            this.MaterialPage.Padding = new System.Windows.Forms.Padding(3);
            this.MaterialPage.Size = new System.Drawing.Size(569, 370);
            this.MaterialPage.TabIndex = 2;
            this.MaterialPage.Text = "MaterialPage";
            this.MaterialPage.UseVisualStyleBackColor = true;
            // 
            // PotionPage
            // 
            this.PotionPage.Location = new System.Drawing.Point(4, 22);
            this.PotionPage.Name = "PotionPage";
            this.PotionPage.Padding = new System.Windows.Forms.Padding(3);
            this.PotionPage.Size = new System.Drawing.Size(569, 370);
            this.PotionPage.TabIndex = 3;
            this.PotionPage.Text = "PotionPage";
            this.PotionPage.UseVisualStyleBackColor = true;
            // 
            // EquipmentPage
            // 
            this.EquipmentPage.Controls.Add(this.equipmentFormattedEffectTextBox);
            this.EquipmentPage.Controls.Add(this.label22);
            this.EquipmentPage.Controls.Add(this.equipmentLevelTextBox);
            this.EquipmentPage.Controls.Add(this.equipmentTypeTextBox);
            this.EquipmentPage.Controls.Add(this.equipmentRankTextBox);
            this.EquipmentPage.Controls.Add(this.label24);
            this.EquipmentPage.Controls.Add(this.label28);
            this.EquipmentPage.Controls.Add(this.equipmentNameTextBox);
            this.EquipmentPage.Controls.Add(this.label25);
            this.EquipmentPage.Controls.Add(this.label29);
            this.EquipmentPage.Controls.Add(this.label23);
            this.EquipmentPage.Controls.Add(this.label26);
            this.EquipmentPage.Controls.Add(this.label27);
            this.EquipmentPage.Location = new System.Drawing.Point(4, 22);
            this.EquipmentPage.Name = "EquipmentPage";
            this.EquipmentPage.Padding = new System.Windows.Forms.Padding(3);
            this.EquipmentPage.Size = new System.Drawing.Size(569, 370);
            this.EquipmentPage.TabIndex = 4;
            this.EquipmentPage.Text = "EquipmentPage";
            this.EquipmentPage.UseVisualStyleBackColor = true;
            // 
            // SkillPage
            // 
            this.SkillPage.Location = new System.Drawing.Point(4, 22);
            this.SkillPage.Name = "SkillPage";
            this.SkillPage.Padding = new System.Windows.Forms.Padding(3);
            this.SkillPage.Size = new System.Drawing.Size(569, 370);
            this.SkillPage.TabIndex = 5;
            this.SkillPage.Text = "SkillPage";
            this.SkillPage.UseVisualStyleBackColor = true;
            // 
            // DungeonPage
            // 
            this.DungeonPage.Controls.Add(this.monsterCountMaxTextBox);
            this.DungeonPage.Controls.Add(this.monsterCountMinTextBox);
            this.DungeonPage.Controls.Add(this.label5);
            this.DungeonPage.Controls.Add(this.label4);
            this.DungeonPage.Controls.Add(this.waveCountTextBox);
            this.DungeonPage.Controls.Add(this.label2);
            this.DungeonPage.Controls.Add(this.dungeonMonsterTextBox);
            this.DungeonPage.Controls.Add(this.label3);
            this.DungeonPage.Controls.Add(this.dungeonNameTextBox);
            this.DungeonPage.Controls.Add(this.label1);
            this.DungeonPage.Location = new System.Drawing.Point(4, 22);
            this.DungeonPage.Name = "DungeonPage";
            this.DungeonPage.Padding = new System.Windows.Forms.Padding(3);
            this.DungeonPage.Size = new System.Drawing.Size(569, 370);
            this.DungeonPage.TabIndex = 6;
            this.DungeonPage.Text = "DungeonPage";
            this.DungeonPage.UseVisualStyleBackColor = true;
            // 
            // dungeonNameTextBox
            // 
            this.dungeonNameTextBox.Location = new System.Drawing.Point(85, 17);
            this.dungeonNameTextBox.Name = "dungeonNameTextBox";
            this.dungeonNameTextBox.Size = new System.Drawing.Size(100, 21);
            this.dungeonNameTextBox.TabIndex = 1;
            this.dungeonNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "던전 이름";
            // 
            // monsterButton
            // 
            this.monsterButton.Location = new System.Drawing.Point(296, 13);
            this.monsterButton.Name = "monsterButton";
            this.monsterButton.Size = new System.Drawing.Size(75, 23);
            this.monsterButton.TabIndex = 2;
            this.monsterButton.Text = "몬스터";
            this.monsterButton.UseVisualStyleBackColor = true;
            this.monsterButton.Click += new System.EventHandler(this.monsterButton_Click);
            // 
            // materialButton
            // 
            this.materialButton.Location = new System.Drawing.Point(377, 13);
            this.materialButton.Name = "materialButton";
            this.materialButton.Size = new System.Drawing.Size(75, 23);
            this.materialButton.TabIndex = 2;
            this.materialButton.Text = "재료";
            this.materialButton.UseVisualStyleBackColor = true;
            this.materialButton.Click += new System.EventHandler(this.materialButton_Click);
            // 
            // potionButton
            // 
            this.potionButton.Location = new System.Drawing.Point(458, 13);
            this.potionButton.Name = "potionButton";
            this.potionButton.Size = new System.Drawing.Size(75, 23);
            this.potionButton.TabIndex = 2;
            this.potionButton.Text = "포션";
            this.potionButton.UseVisualStyleBackColor = true;
            this.potionButton.Click += new System.EventHandler(this.potionButton_Click);
            // 
            // equipmentButton
            // 
            this.equipmentButton.Location = new System.Drawing.Point(539, 13);
            this.equipmentButton.Name = "equipmentButton";
            this.equipmentButton.Size = new System.Drawing.Size(75, 23);
            this.equipmentButton.TabIndex = 2;
            this.equipmentButton.Text = "장비";
            this.equipmentButton.UseVisualStyleBackColor = true;
            this.equipmentButton.Click += new System.EventHandler(this.equipmentButton_Click);
            // 
            // skillButton
            // 
            this.skillButton.Location = new System.Drawing.Point(620, 13);
            this.skillButton.Name = "skillButton";
            this.skillButton.Size = new System.Drawing.Size(75, 23);
            this.skillButton.TabIndex = 2;
            this.skillButton.Text = "스킬";
            this.skillButton.UseVisualStyleBackColor = true;
            // 
            // dungeonButton
            // 
            this.dungeonButton.Location = new System.Drawing.Point(215, 13);
            this.dungeonButton.Name = "dungeonButton";
            this.dungeonButton.Size = new System.Drawing.Size(75, 23);
            this.dungeonButton.TabIndex = 2;
            this.dungeonButton.Text = "던전";
            this.dungeonButton.UseVisualStyleBackColor = true;
            this.dungeonButton.Click += new System.EventHandler(this.dungeonButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "WAVE 수";
            // 
            // waveCountTextBox
            // 
            this.waveCountTextBox.Location = new System.Drawing.Point(295, 17);
            this.waveCountTextBox.Name = "waveCountTextBox";
            this.waveCountTextBox.Size = new System.Drawing.Size(35, 21);
            this.waveCountTextBox.TabIndex = 1;
            this.waveCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "출현 몬스터";
            // 
            // dungeonMonsterTextBox
            // 
            this.dungeonMonsterTextBox.Location = new System.Drawing.Point(85, 44);
            this.dungeonMonsterTextBox.Name = "dungeonMonsterTextBox";
            this.dungeonMonsterTextBox.Size = new System.Drawing.Size(478, 21);
            this.dungeonMonsterTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "출현 범위";
            // 
            // monsterCountMinTextBox
            // 
            this.monsterCountMinTextBox.Location = new System.Drawing.Point(462, 17);
            this.monsterCountMinTextBox.Name = "monsterCountMinTextBox";
            this.monsterCountMinTextBox.Size = new System.Drawing.Size(35, 21);
            this.monsterCountMinTextBox.TabIndex = 1;
            this.monsterCountMinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // monsterCountMaxTextBox
            // 
            this.monsterCountMaxTextBox.Location = new System.Drawing.Point(527, 17);
            this.monsterCountMaxTextBox.Name = "monsterCountMaxTextBox";
            this.monsterCountMaxTextBox.Size = new System.Drawing.Size(35, 21);
            this.monsterCountMaxTextBox.TabIndex = 1;
            this.monsterCountMaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(505, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "~";
            // 
            // monsterDropItemTextBox
            // 
            this.monsterDropItemTextBox.Location = new System.Drawing.Point(8, 143);
            this.monsterDropItemTextBox.Multiline = true;
            this.monsterDropItemTextBox.Name = "monsterDropItemTextBox";
            this.monsterDropItemTextBox.Size = new System.Drawing.Size(555, 84);
            this.monsterDropItemTextBox.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "드랍 아이템";
            // 
            // monsterNameTextBox
            // 
            this.monsterNameTextBox.Location = new System.Drawing.Point(84, 12);
            this.monsterNameTextBox.Name = "monsterNameTextBox";
            this.monsterNameTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterNameTextBox.TabIndex = 11;
            this.monsterNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "몬스터 이름";
            // 
            // registButton
            // 
            this.registButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.registButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.registButton.Location = new System.Drawing.Point(701, 14);
            this.registButton.Name = "registButton";
            this.registButton.Size = new System.Drawing.Size(87, 23);
            this.registButton.TabIndex = 2;
            this.registButton.Text = "등록";
            this.registButton.UseVisualStyleBackColor = false;
            this.registButton.Click += new System.EventHandler(this.registButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "경험치";
            // 
            // monsterExpTextBox
            // 
            this.monsterExpTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.monsterExpTextBox.Location = new System.Drawing.Point(283, 12);
            this.monsterExpTextBox.Name = "monsterExpTextBox";
            this.monsterExpTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterExpTextBox.TabIndex = 11;
            this.monsterExpTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "골드";
            // 
            // monsterGoldTextBox
            // 
            this.monsterGoldTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.monsterGoldTextBox.Location = new System.Drawing.Point(463, 12);
            this.monsterGoldTextBox.Name = "monsterGoldTextBox";
            this.monsterGoldTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterGoldTextBox.TabIndex = 11;
            this.monsterGoldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "힘";
            // 
            // monsterPowerTextBox
            // 
            this.monsterPowerTextBox.Location = new System.Drawing.Point(84, 39);
            this.monsterPowerTextBox.Name = "monsterPowerTextBox";
            this.monsterPowerTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterPowerTextBox.TabIndex = 11;
            this.monsterPowerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "체력";
            // 
            // monsterStaminaTextBox
            // 
            this.monsterStaminaTextBox.Location = new System.Drawing.Point(84, 66);
            this.monsterStaminaTextBox.Name = "monsterStaminaTextBox";
            this.monsterStaminaTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterStaminaTextBox.TabIndex = 11;
            this.monsterStaminaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(240, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "지능";
            // 
            // monsterIntelliTextBox
            // 
            this.monsterIntelliTextBox.Location = new System.Drawing.Point(283, 39);
            this.monsterIntelliTextBox.Name = "monsterIntelliTextBox";
            this.monsterIntelliTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterIntelliTextBox.TabIndex = 11;
            this.monsterIntelliTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(227, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "정신력";
            // 
            // monsterWillpowerTextBox
            // 
            this.monsterWillpowerTextBox.Location = new System.Drawing.Point(283, 66);
            this.monsterWillpowerTextBox.Name = "monsterWillpowerTextBox";
            this.monsterWillpowerTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterWillpowerTextBox.TabIndex = 11;
            this.monsterWillpowerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(409, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "집중력";
            // 
            // monsterConcentrationTextBox
            // 
            this.monsterConcentrationTextBox.Location = new System.Drawing.Point(463, 39);
            this.monsterConcentrationTextBox.Name = "monsterConcentrationTextBox";
            this.monsterConcentrationTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterConcentrationTextBox.TabIndex = 11;
            this.monsterConcentrationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(420, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 6;
            this.label15.Text = "민첩";
            // 
            // monsterAgilityTextBox
            // 
            this.monsterAgilityTextBox.Location = new System.Drawing.Point(463, 66);
            this.monsterAgilityTextBox.Name = "monsterAgilityTextBox";
            this.monsterAgilityTextBox.Size = new System.Drawing.Size(100, 21);
            this.monsterAgilityTextBox.TabIndex = 11;
            this.monsterAgilityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // materialNameTextBox
            // 
            this.materialNameTextBox.Location = new System.Drawing.Point(81, 19);
            this.materialNameTextBox.Name = "materialNameTextBox";
            this.materialNameTextBox.Size = new System.Drawing.Size(141, 21);
            this.materialNameTextBox.TabIndex = 13;
            this.materialNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 12);
            this.label16.TabIndex = 12;
            this.label16.Text = "재료 이름";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(484, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 84);
            this.label17.TabIndex = 12;
            this.label17.Text = "아이템 등급\n1 : 노멀\r\n2 : 익시드\r\n3 : 레어\r\n4 : 아티팩트\r\n5 : 유니크\r\n6 : 에픽";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(329, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 12;
            this.label18.Text = "등급";
            // 
            // materialRankTextBox
            // 
            this.materialRankTextBox.Location = new System.Drawing.Point(369, 17);
            this.materialRankTextBox.Name = "materialRankTextBox";
            this.materialRankTextBox.Size = new System.Drawing.Size(30, 21);
            this.materialRankTextBox.TabIndex = 13;
            this.materialRankTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(41, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 12;
            this.label20.Text = "가치";
            // 
            // materialValueTextBox
            // 
            this.materialValueTextBox.Location = new System.Drawing.Point(81, 45);
            this.materialValueTextBox.Name = "materialValueTextBox";
            this.materialValueTextBox.Size = new System.Drawing.Size(75, 21);
            this.materialValueTextBox.TabIndex = 13;
            this.materialValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(329, 50);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 12;
            this.label21.Text = "레벨";
            // 
            // materialLevelTextBox
            // 
            this.materialLevelTextBox.Location = new System.Drawing.Point(369, 45);
            this.materialLevelTextBox.Name = "materialLevelTextBox";
            this.materialLevelTextBox.Size = new System.Drawing.Size(30, 21);
            this.materialLevelTextBox.TabIndex = 13;
            this.materialLevelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 95);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 12;
            this.label19.Text = "설명";
            // 
            // materialDescriptionTextBox
            // 
            this.materialDescriptionTextBox.Location = new System.Drawing.Point(15, 113);
            this.materialDescriptionTextBox.Multiline = true;
            this.materialDescriptionTextBox.Name = "materialDescriptionTextBox";
            this.materialDescriptionTextBox.Size = new System.Drawing.Size(540, 160);
            this.materialDescriptionTextBox.TabIndex = 13;
            this.materialDescriptionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // equipmentFormattedEffectTextBox
            // 
            this.equipmentFormattedEffectTextBox.Location = new System.Drawing.Point(319, 34);
            this.equipmentFormattedEffectTextBox.Multiline = true;
            this.equipmentFormattedEffectTextBox.Name = "equipmentFormattedEffectTextBox";
            this.equipmentFormattedEffectTextBox.Size = new System.Drawing.Size(243, 146);
            this.equipmentFormattedEffectTextBox.TabIndex = 20;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(317, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 12);
            this.label22.TabIndex = 14;
            this.label22.Text = "효과 옵션";
            // 
            // equipmentLevelTextBox
            // 
            this.equipmentLevelTextBox.Location = new System.Drawing.Point(273, 44);
            this.equipmentLevelTextBox.Name = "equipmentLevelTextBox";
            this.equipmentLevelTextBox.Size = new System.Drawing.Size(30, 21);
            this.equipmentLevelTextBox.TabIndex = 22;
            this.equipmentLevelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // equipmentRankTextBox
            // 
            this.equipmentRankTextBox.Location = new System.Drawing.Point(273, 16);
            this.equipmentRankTextBox.Name = "equipmentRankTextBox";
            this.equipmentRankTextBox.Size = new System.Drawing.Size(30, 21);
            this.equipmentRankTextBox.TabIndex = 23;
            this.equipmentRankTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(233, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 12);
            this.label24.TabIndex = 16;
            this.label24.Text = "레벨";
            // 
            // equipmentNameTextBox
            // 
            this.equipmentNameTextBox.Location = new System.Drawing.Point(81, 18);
            this.equipmentNameTextBox.Name = "equipmentNameTextBox";
            this.equipmentNameTextBox.Size = new System.Drawing.Size(143, 21);
            this.equipmentNameTextBox.TabIndex = 24;
            this.equipmentNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(233, 21);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 17;
            this.label25.Text = "등급";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(226, 283);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 84);
            this.label26.TabIndex = 18;
            this.label26.Text = "아이템 등급\n1 : 노멀\r\n2 : 익시드\r\n3 : 레어\r\n4 : 아티팩트\r\n5 : 유니크\r\n6 : 에픽";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(13, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 12);
            this.label27.TabIndex = 19;
            this.label27.Text = "장비 이름";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(14, 50);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 12);
            this.label28.TabIndex = 17;
            this.label28.Text = "장비 유형";
            // 
            // equipmentTypeTextBox
            // 
            this.equipmentTypeTextBox.Location = new System.Drawing.Point(81, 45);
            this.equipmentTypeTextBox.Name = "equipmentTypeTextBox";
            this.equipmentTypeTextBox.Size = new System.Drawing.Size(30, 21);
            this.equipmentTypeTextBox.TabIndex = 23;
            this.equipmentTypeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 151);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(174, 216);
            this.label23.TabIndex = 18;
            this.label23.Text = resources.GetString("label23.Text");
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(484, 199);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(78, 168);
            this.label29.TabIndex = 18;
            this.label29.Text = "옵션\r\np : 힘\r\ns : 체력\r\ni : 지능\r\nw : 정신력\r\nc : 집중력\r\na : 민첩\r\nh : HP MAX\r\nm : MP MAX\r\nx : " +
    "HP회복\r\ny : MP회복\r\nt : 공격력\r\nd : 방어력\r\ne : 공격속도";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.registButton);
            this.Controls.Add(this.skillButton);
            this.Controls.Add(this.equipmentButton);
            this.Controls.Add(this.potionButton);
            this.Controls.Add(this.materialButton);
            this.Controls.Add(this.dungeonButton);
            this.Controls.Add(this.monsterButton);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.listBox);
            this.Name = "MainForm";
            this.Text = "NFD Manager";
            this.TabControl.ResumeLayout(false);
            this.MonsterPage.ResumeLayout(false);
            this.MonsterPage.PerformLayout();
            this.MaterialPage.ResumeLayout(false);
            this.MaterialPage.PerformLayout();
            this.EquipmentPage.ResumeLayout(false);
            this.EquipmentPage.PerformLayout();
            this.DungeonPage.ResumeLayout(false);
            this.DungeonPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MonsterPage;
        private System.Windows.Forms.TabPage MaterialPage;
        private System.Windows.Forms.TabPage PotionPage;
        private System.Windows.Forms.TabPage EquipmentPage;
        private System.Windows.Forms.TabPage SkillPage;
        private System.Windows.Forms.Button monsterButton;
        private System.Windows.Forms.Button materialButton;
        private System.Windows.Forms.Button potionButton;
        private System.Windows.Forms.Button equipmentButton;
        private System.Windows.Forms.Button skillButton;
        private System.Windows.Forms.Button dungeonButton;
        private System.Windows.Forms.TabPage DungeonPage;
        private System.Windows.Forms.TextBox dungeonNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox waveCountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dungeonMonsterTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox monsterCountMinTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox monsterCountMaxTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox monsterDropItemTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox monsterNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button registButton;
        private System.Windows.Forms.TextBox monsterAgilityTextBox;
        private System.Windows.Forms.TextBox monsterWillpowerTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox monsterConcentrationTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox monsterIntelliTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox monsterStaminaTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox monsterPowerTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox monsterGoldTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox monsterExpTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox materialNameTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox materialValueTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox materialRankTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox materialLevelTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox materialDescriptionTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox equipmentFormattedEffectTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox equipmentLevelTextBox;
        private System.Windows.Forms.TextBox equipmentRankTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox equipmentNameTextBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox equipmentTypeTextBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label29;
    }
}