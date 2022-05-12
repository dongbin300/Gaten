namespace Gaten.GameTool.Inventory
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
            this.inventoryView = new System.Windows.Forms.ListView();
            this.getButton = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.throwButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.distributionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inventoryView
            // 
            this.inventoryView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.inventoryView.GridLines = true;
            this.inventoryView.Location = new System.Drawing.Point(0, 0);
            this.inventoryView.Name = "inventoryView";
            this.inventoryView.Size = new System.Drawing.Size(300, 400);
            this.inventoryView.TabIndex = 0;
            this.inventoryView.TileSize = new System.Drawing.Size(6, 4);
            this.inventoryView.UseCompatibleStateImageBehavior = false;
            this.inventoryView.View = System.Windows.Forms.View.SmallIcon;
            // 
            // getButton
            // 
            this.getButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getButton.Location = new System.Drawing.Point(306, 12);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(75, 23);
            this.getButton.TabIndex = 1;
            this.getButton.Text = "획득";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 75;
            // 
            // throwButton
            // 
            this.throwButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.throwButton.Location = new System.Drawing.Point(306, 41);
            this.throwButton.Name = "throwButton";
            this.throwButton.Size = new System.Drawing.Size(75, 23);
            this.throwButton.TabIndex = 2;
            this.throwButton.Text = "폐기";
            this.throwButton.UseVisualStyleBackColor = true;
            this.throwButton.Click += new System.EventHandler(this.ThrowButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveButton.Location = new System.Drawing.Point(306, 70);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 3;
            this.moveButton.Text = "이동";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // sortButton
            // 
            this.sortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sortButton.Location = new System.Drawing.Point(306, 99);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 23);
            this.sortButton.TabIndex = 4;
            this.sortButton.Text = "정렬";
            this.sortButton.UseVisualStyleBackColor = true;
            // 
            // distributionButton
            // 
            this.distributionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distributionButton.Location = new System.Drawing.Point(306, 128);
            this.distributionButton.Name = "distributionButton";
            this.distributionButton.Size = new System.Drawing.Size(75, 23);
            this.distributionButton.TabIndex = 5;
            this.distributionButton.Text = "분리";
            this.distributionButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 400);
            this.Controls.Add(this.distributionButton);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.throwButton);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.inventoryView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView inventoryView;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button throwButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button distributionButton;
    }
}