namespace Gaten.GameTool.osu.osuBeatmapDownloader
{
    partial class OptionForm
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
            this.tabListBox = new System.Windows.Forms.ListBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.confirmUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.autoStartonWindowsStartCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.transparentTrackBar = new System.Windows.Forms.TrackBar();
            this.topMostCheckBox = new System.Windows.Forms.CheckBox();
            this.backImageSelectButton = new System.Windows.Forms.Button();
            this.windowSizeYTextBox = new System.Windows.Forms.TextBox();
            this.windowSizeXTextBox = new System.Windows.Forms.TextBox();
            this.backImagePathTextBox = new System.Windows.Forms.TextBox();
            this.transparentValueLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.activateDownloaderCheckBox = new System.Windows.Forms.CheckBox();
            this.closeChromeAfterCompleteDownloadCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.blogButton = new System.Windows.Forms.Button();
            this.twitterButton = new System.Windows.Forms.Button();
            this.donateButton = new System.Windows.Forms.Button();
            this.updateDataButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.makeDateLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backImageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.defaultButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparentTrackBar)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabListBox
            // 
            this.tabListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tabListBox.FormattingEnabled = true;
            this.tabListBox.ItemHeight = 30;
            this.tabListBox.Items.AddRange(new object[] {
            "일반",
            "화면",
            "다운로드",
            "프로그램 정보"});
            this.tabListBox.Location = new System.Drawing.Point(12, 15);
            this.tabListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabListBox.Name = "tabListBox";
            this.tabListBox.Size = new System.Drawing.Size(117, 184);
            this.tabListBox.TabIndex = 0;
            this.tabListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabListBox_DrawItem);
            this.tabListBox.SelectedIndexChanged += new System.EventHandler(this.TabListBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.okButton.Location = new System.Drawing.Point(369, 215);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 29);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "확인";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(450, 215);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 29);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "취소";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.ItemSize = new System.Drawing.Size(32, 16);
            this.tabControl.Location = new System.Drawing.Point(135, 15);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(394, 192);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.confirmUpdateCheckBox);
            this.tabPage1.Controls.Add(this.autoStartonWindowsStartCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 20);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(386, 168);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // confirmUpdateCheckBox
            // 
            this.confirmUpdateCheckBox.AutoSize = true;
            this.confirmUpdateCheckBox.Location = new System.Drawing.Point(0, 28);
            this.confirmUpdateCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmUpdateCheckBox.Name = "confirmUpdateCheckBox";
            this.confirmUpdateCheckBox.Size = new System.Drawing.Size(234, 19);
            this.confirmUpdateCheckBox.TabIndex = 0;
            this.confirmUpdateCheckBox.Text = "실행할 때마다 프로그램 업데이트 확인";
            this.confirmUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoStartonWindowsStartCheckBox
            // 
            this.autoStartonWindowsStartCheckBox.AutoSize = true;
            this.autoStartonWindowsStartCheckBox.Location = new System.Drawing.Point(0, 0);
            this.autoStartonWindowsStartCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.autoStartonWindowsStartCheckBox.Name = "autoStartonWindowsStartCheckBox";
            this.autoStartonWindowsStartCheckBox.Size = new System.Drawing.Size(232, 19);
            this.autoStartonWindowsStartCheckBox.TabIndex = 0;
            this.autoStartonWindowsStartCheckBox.Text = "윈도우 시작시 자동 실행(윈10 실험적)";
            this.autoStartonWindowsStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.transparentTrackBar);
            this.tabPage2.Controls.Add(this.topMostCheckBox);
            this.tabPage2.Controls.Add(this.backImageSelectButton);
            this.tabPage2.Controls.Add(this.windowSizeYTextBox);
            this.tabPage2.Controls.Add(this.windowSizeXTextBox);
            this.tabPage2.Controls.Add(this.backImagePathTextBox);
            this.tabPage2.Controls.Add(this.transparentValueLabel);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 20);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(386, 168);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // transparentTrackBar
            // 
            this.transparentTrackBar.AutoSize = false;
            this.transparentTrackBar.Location = new System.Drawing.Point(75, 68);
            this.transparentTrackBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transparentTrackBar.Maximum = 100;
            this.transparentTrackBar.Minimum = 5;
            this.transparentTrackBar.Name = "transparentTrackBar";
            this.transparentTrackBar.Size = new System.Drawing.Size(266, 31);
            this.transparentTrackBar.SmallChange = 5;
            this.transparentTrackBar.TabIndex = 5;
            this.transparentTrackBar.TickFrequency = 5;
            this.transparentTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.transparentTrackBar.Value = 5;
            this.transparentTrackBar.Scroll += new System.EventHandler(this.transparentTrackBar_Scroll);
            this.transparentTrackBar.ValueChanged += new System.EventHandler(this.transparentTrackBar_ValueChanged);
            // 
            // topMostCheckBox
            // 
            this.topMostCheckBox.AutoSize = true;
            this.topMostCheckBox.Location = new System.Drawing.Point(183, 5);
            this.topMostCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMostCheckBox.Name = "topMostCheckBox";
            this.topMostCheckBox.Size = new System.Drawing.Size(106, 19);
            this.topMostCheckBox.TabIndex = 3;
            this.topMostCheckBox.Text = "항상 위에 표시";
            this.topMostCheckBox.UseVisualStyleBackColor = true;
            // 
            // backImageSelectButton
            // 
            this.backImageSelectButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backImageSelectButton.Location = new System.Drawing.Point(347, 32);
            this.backImageSelectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backImageSelectButton.Name = "backImageSelectButton";
            this.backImageSelectButton.Size = new System.Drawing.Size(36, 29);
            this.backImageSelectButton.TabIndex = 2;
            this.backImageSelectButton.Text = "...";
            this.backImageSelectButton.UseVisualStyleBackColor = true;
            this.backImageSelectButton.Click += new System.EventHandler(this.backImageSelectButton_Click);
            // 
            // windowSizeYTextBox
            // 
            this.windowSizeYTextBox.BackColor = System.Drawing.Color.White;
            this.windowSizeYTextBox.Location = new System.Drawing.Point(126, 0);
            this.windowSizeYTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.windowSizeYTextBox.Name = "windowSizeYTextBox";
            this.windowSizeYTextBox.Size = new System.Drawing.Size(40, 23);
            this.windowSizeYTextBox.TabIndex = 1;
            // 
            // windowSizeXTextBox
            // 
            this.windowSizeXTextBox.BackColor = System.Drawing.Color.White;
            this.windowSizeXTextBox.Location = new System.Drawing.Point(75, 0);
            this.windowSizeXTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.windowSizeXTextBox.Name = "windowSizeXTextBox";
            this.windowSizeXTextBox.Size = new System.Drawing.Size(40, 23);
            this.windowSizeXTextBox.TabIndex = 1;
            // 
            // backImagePathTextBox
            // 
            this.backImagePathTextBox.BackColor = System.Drawing.Color.White;
            this.backImagePathTextBox.Location = new System.Drawing.Point(75, 34);
            this.backImagePathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backImagePathTextBox.Name = "backImagePathTextBox";
            this.backImagePathTextBox.ReadOnly = true;
            this.backImagePathTextBox.Size = new System.Drawing.Size(266, 23);
            this.backImagePathTextBox.TabIndex = 1;
            // 
            // transparentValueLabel
            // 
            this.transparentValueLabel.Location = new System.Drawing.Point(341, 72);
            this.transparentValueLabel.Name = "transparentValueLabel";
            this.transparentValueLabel.Size = new System.Drawing.Size(41, 15);
            this.transparentValueLabel.TabIndex = 0;
            this.transparentValueLabel.Text = "00%";
            this.transparentValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = ",";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "창 크기";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "투명도";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "배경 이미지";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.activateDownloaderCheckBox);
            this.tabPage3.Controls.Add(this.closeChromeAfterCompleteDownloadCheckBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 20);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(386, 168);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // activateDownloaderCheckBox
            // 
            this.activateDownloaderCheckBox.AutoSize = true;
            this.activateDownloaderCheckBox.Location = new System.Drawing.Point(0, 0);
            this.activateDownloaderCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.activateDownloaderCheckBox.Name = "activateDownloaderCheckBox";
            this.activateDownloaderCheckBox.Size = new System.Drawing.Size(114, 19);
            this.activateDownloaderCheckBox.TabIndex = 1;
            this.activateDownloaderCheckBox.Text = "다운로드 활성화";
            this.activateDownloaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // closeChromeAfterCompleteDownloadCheckBox
            // 
            this.closeChromeAfterCompleteDownloadCheckBox.AutoSize = true;
            this.closeChromeAfterCompleteDownloadCheckBox.Location = new System.Drawing.Point(0, 28);
            this.closeChromeAfterCompleteDownloadCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeChromeAfterCompleteDownloadCheckBox.Name = "closeChromeAfterCompleteDownloadCheckBox";
            this.closeChromeAfterCompleteDownloadCheckBox.Size = new System.Drawing.Size(314, 19);
            this.closeChromeAfterCompleteDownloadCheckBox.TabIndex = 1;
            this.closeChromeAfterCompleteDownloadCheckBox.Text = "다운로드 완료 후 크롬 창 닫기(모든 크롬이 닫힙니다)";
            this.closeChromeAfterCompleteDownloadCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.blogButton);
            this.tabPage4.Controls.Add(this.twitterButton);
            this.tabPage4.Controls.Add(this.donateButton);
            this.tabPage4.Controls.Add(this.updateDataButton);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.copyrightLabel);
            this.tabPage4.Controls.Add(this.makeDateLabel);
            this.tabPage4.Controls.Add(this.versionLabel);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Location = new System.Drawing.Point(4, 20);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Size = new System.Drawing.Size(386, 168);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // blogButton
            // 
            this.blogButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blogButton.FlatAppearance.BorderSize = 0;
            this.blogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blogButton.Location = new System.Drawing.Point(168, 108);
            this.blogButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.blogButton.Name = "blogButton";
            this.blogButton.Size = new System.Drawing.Size(40, 50);
            this.blogButton.TabIndex = 4;
            this.blogButton.UseVisualStyleBackColor = true;
            this.blogButton.Click += new System.EventHandler(this.blogButton_Click);
            // 
            // twitterButton
            // 
            this.twitterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.twitterButton.FlatAppearance.BorderSize = 0;
            this.twitterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twitterButton.Location = new System.Drawing.Point(113, 108);
            this.twitterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.twitterButton.Name = "twitterButton";
            this.twitterButton.Size = new System.Drawing.Size(49, 50);
            this.twitterButton.TabIndex = 4;
            this.twitterButton.UseVisualStyleBackColor = true;
            this.twitterButton.Click += new System.EventHandler(this.twitterButton_Click);
            // 
            // donateButton
            // 
            this.donateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.donateButton.FlatAppearance.BorderSize = 0;
            this.donateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donateButton.Location = new System.Drawing.Point(215, 108);
            this.donateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(165, 50);
            this.donateButton.TabIndex = 3;
            this.donateButton.UseVisualStyleBackColor = true;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // updateDataButton
            // 
            this.updateDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateDataButton.Location = new System.Drawing.Point(251, 30);
            this.updateDataButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateDataButton.Name = "updateDataButton";
            this.updateDataButton.Size = new System.Drawing.Size(75, 29);
            this.updateDataButton.TabIndex = 1;
            this.updateDataButton.Text = "패치 내용";
            this.updateDataButton.UseVisualStyleBackColor = true;
            this.updateDataButton.Click += new System.EventHandler(this.UpdateDataButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(21, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "문의 / 후원";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(22, 65);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(188, 30);
            this.copyrightLabel.TabIndex = 0;
            this.copyrightLabel.Text = "Copyright ⓒ 2020  Kim Dongbin\r\nAll rights reserved";
            // 
            // makeDateLabel
            // 
            this.makeDateLabel.AutoSize = true;
            this.makeDateLabel.Location = new System.Drawing.Point(72, 36);
            this.makeDateLabel.Name = "makeDateLabel";
            this.makeDateLabel.Size = new System.Drawing.Size(73, 15);
            this.makeDateLabel.TabIndex = 0;
            this.makeDateLabel.Text = "2020-01-01";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(166, 36);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(40, 15);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "v2.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "osu! Beatmap Downloader";
            // 
            // defaultButton
            // 
            this.defaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultButton.ForeColor = System.Drawing.Color.Crimson;
            this.defaultButton.Location = new System.Drawing.Point(12, 215);
            this.defaultButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(75, 29);
            this.defaultButton.TabIndex = 3;
            this.defaultButton.Text = "초기화";
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 252);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.defaultButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OptionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "옵션";
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparentTrackBar)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox tabListBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox autoStartonWindowsStartCheckBox;
        private System.Windows.Forms.CheckBox confirmUpdateCheckBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox closeChromeAfterCompleteDownloadCheckBox;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button updateDataButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backImageSelectButton;
        private System.Windows.Forms.TextBox backImagePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog backImageOpenFileDialog;
        private System.Windows.Forms.CheckBox activateDownloaderCheckBox;
        private System.Windows.Forms.CheckBox topMostCheckBox;
        private System.Windows.Forms.TrackBar transparentTrackBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label transparentValueLabel;
        private System.Windows.Forms.TextBox windowSizeYTextBox;
        private System.Windows.Forms.TextBox windowSizeXTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button defaultButton;
        private System.Windows.Forms.Label makeDateLabel;
        private System.Windows.Forms.Button donateButton;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Button blogButton;
        private System.Windows.Forms.Button twitterButton;
    }
}