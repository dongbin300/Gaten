namespace Gaten.GameTool.SDVX.FumenQuiz
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.hardcoreButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.exerciseButton = new System.Windows.Forms.Button();
            this.studyButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.backButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.levelPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.exampleCountPanel = new System.Windows.Forms.Panel();
            this.exampleCountNumericTextBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.seriesPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.difficultyPanel = new System.Windows.Forms.Panel();
            this.difficultyComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nextButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.exampleListBox = new System.Windows.Forms.ListBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.questionPanel = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.mainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.levelPanel.SuspendLayout();
            this.exampleCountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exampleCountNumericTextBox)).BeginInit();
            this.seriesPanel.SuspendLayout();
            this.difficultyPanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Controls.Add(this.tabPage3);
            this.mainTabControl.Controls.Add(this.tabPage4);
            this.mainTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(808, 889);
            this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mainTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hardcoreButton);
            this.tabPage1.Controls.Add(this.testButton);
            this.tabPage1.Controls.Add(this.exerciseButton);
            this.tabPage1.Controls.Add(this.studyButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(800, 880);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // hardcoreButton
            // 
            this.hardcoreButton.Location = new System.Drawing.Point(8, 285);
            this.hardcoreButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hardcoreButton.Name = "hardcoreButton";
            this.hardcoreButton.Size = new System.Drawing.Size(183, 85);
            this.hardcoreButton.TabIndex = 0;
            this.hardcoreButton.Text = "하드코어모드";
            this.hardcoreButton.UseVisualStyleBackColor = true;
            this.hardcoreButton.Click += new System.EventHandler(this.HardcoreButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(8, 192);
            this.testButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(183, 85);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "테스트모드";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // exerciseButton
            // 
            this.exerciseButton.Location = new System.Drawing.Point(8, 100);
            this.exerciseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exerciseButton.Name = "exerciseButton";
            this.exerciseButton.Size = new System.Drawing.Size(183, 85);
            this.exerciseButton.TabIndex = 0;
            this.exerciseButton.Text = "연습모드";
            this.exerciseButton.UseVisualStyleBackColor = true;
            this.exerciseButton.Click += new System.EventHandler(this.ExerciseButton_Click);
            // 
            // studyButton
            // 
            this.studyButton.Location = new System.Drawing.Point(8, 8);
            this.studyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.studyButton.Name = "studyButton";
            this.studyButton.Size = new System.Drawing.Size(183, 85);
            this.studyButton.TabIndex = 0;
            this.studyButton.Text = "학습모드";
            this.studyButton.UseVisualStyleBackColor = true;
            this.studyButton.Click += new System.EventHandler(this.StudyButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.backButton);
            this.tabPage2.Controls.Add(this.startButton);
            this.tabPage2.Controls.Add(this.levelPanel);
            this.tabPage2.Controls.Add(this.exampleCountPanel);
            this.tabPage2.Controls.Add(this.seriesPanel);
            this.tabPage2.Controls.Add(this.difficultyPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(800, 880);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(8, 356);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(45, 32);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "뒤로";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(58, 356);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(195, 32);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "시작";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // levelPanel
            // 
            this.levelPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.levelPanel.Controls.Add(this.label1);
            this.levelPanel.Location = new System.Drawing.Point(8, 9);
            this.levelPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(245, 184);
            this.levelPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "레벨";
            // 
            // exampleCountPanel
            // 
            this.exampleCountPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.exampleCountPanel.Controls.Add(this.exampleCountNumericTextBox);
            this.exampleCountPanel.Controls.Add(this.label4);
            this.exampleCountPanel.Location = new System.Drawing.Point(136, 309);
            this.exampleCountPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exampleCountPanel.Name = "exampleCountPanel";
            this.exampleCountPanel.Size = new System.Drawing.Size(117, 39);
            this.exampleCountPanel.TabIndex = 2;
            // 
            // exampleCountNumericTextBox
            // 
            this.exampleCountNumericTextBox.Location = new System.Drawing.Point(52, 6);
            this.exampleCountNumericTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exampleCountNumericTextBox.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.exampleCountNumericTextBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.exampleCountNumericTextBox.Name = "exampleCountNumericTextBox";
            this.exampleCountNumericTextBox.Size = new System.Drawing.Size(62, 23);
            this.exampleCountNumericTextBox.TabIndex = 1;
            this.exampleCountNumericTextBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "보기 수";
            // 
            // seriesPanel
            // 
            this.seriesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.seriesPanel.Controls.Add(this.label2);
            this.seriesPanel.Location = new System.Drawing.Point(8, 200);
            this.seriesPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.seriesPanel.Name = "seriesPanel";
            this.seriesPanel.Size = new System.Drawing.Size(245, 101);
            this.seriesPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "시리즈";
            // 
            // difficultyPanel
            // 
            this.difficultyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.difficultyPanel.Controls.Add(this.difficultyComboBox);
            this.difficultyPanel.Controls.Add(this.label3);
            this.difficultyPanel.Location = new System.Drawing.Point(8, 309);
            this.difficultyPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.difficultyPanel.Name = "difficultyPanel";
            this.difficultyPanel.Size = new System.Drawing.Size(117, 39);
            this.difficultyPanel.TabIndex = 4;
            // 
            // difficultyComboBox
            // 
            this.difficultyComboBox.FormattingEnabled = true;
            this.difficultyComboBox.Items.AddRange(new object[] {
            "쉬움",
            "보통",
            "어려움",
            "아주어려움"});
            this.difficultyComboBox.Location = new System.Drawing.Point(50, 6);
            this.difficultyComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.difficultyComboBox.Name = "difficultyComboBox";
            this.difficultyComboBox.Size = new System.Drawing.Size(63, 23);
            this.difficultyComboBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "난이도";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.nextButton);
            this.tabPage3.Controls.Add(this.exitButton);
            this.tabPage3.Controls.Add(this.exampleListBox);
            this.tabPage3.Controls.Add(this.resultLabel);
            this.tabPage3.Controls.Add(this.questionPanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 5);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(800, 880);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(509, 701);
            this.nextButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(279, 78);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "다음";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(509, 786);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(279, 78);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "나가기";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // exampleListBox
            // 
            this.exampleListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exampleListBox.FormattingEnabled = true;
            this.exampleListBox.ItemHeight = 15;
            this.exampleListBox.Location = new System.Drawing.Point(509, 130);
            this.exampleListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exampleListBox.Name = "exampleListBox";
            this.exampleListBox.Size = new System.Drawing.Size(279, 300);
            this.exampleListBox.TabIndex = 2;
            this.exampleListBox.SelectedValueChanged += new System.EventHandler(this.ExampleListBox_SelectedValueChanged);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(507, 10);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(11, 15);
            this.resultLabel.TabIndex = 1;
            this.resultLabel.Text = " ";
            // 
            // questionPanel
            // 
            this.questionPanel.Location = new System.Drawing.Point(0, 0);
            this.questionPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.questionPanel.Name = "questionPanel";
            this.questionPanel.Size = new System.Drawing.Size(500, 875);
            this.questionPanel.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 5);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Size = new System.Drawing.Size(800, 880);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 885);
            this.Controls.Add(this.mainTabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "사볼 채보 퀴즈 v1.0";
            this.mainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.levelPanel.ResumeLayout(false);
            this.levelPanel.PerformLayout();
            this.exampleCountPanel.ResumeLayout(false);
            this.exampleCountPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exampleCountNumericTextBox)).EndInit();
            this.seriesPanel.ResumeLayout(false);
            this.seriesPanel.PerformLayout();
            this.difficultyPanel.ResumeLayout(false);
            this.difficultyPanel.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button hardcoreButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button exerciseButton;
        private System.Windows.Forms.Button studyButton;
        private System.Windows.Forms.Panel levelPanel;
        private System.Windows.Forms.Panel exampleCountPanel;
        private System.Windows.Forms.Panel seriesPanel;
        private System.Windows.Forms.Panel difficultyPanel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel questionPanel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.ListBox exampleListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox difficultyComboBox;
        private System.Windows.Forms.NumericUpDown exampleCountNumericTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button nextButton;
    }
}