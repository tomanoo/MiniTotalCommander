namespace MiniTotalCommander
{
    partial class MiniTCPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentPathBox = new System.Windows.Forms.TextBox();
            this.drivesList = new System.Windows.Forms.ComboBox();
            this.containerBox = new System.Windows.Forms.ListBox();
            this.goBackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentPathBox
            // 
            this.currentPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPathBox.Location = new System.Drawing.Point(3, 3);
            this.currentPathBox.MinimumSize = new System.Drawing.Size(300, 20);
            this.currentPathBox.Name = "currentPathBox";
            this.currentPathBox.Size = new System.Drawing.Size(312, 20);
            this.currentPathBox.TabIndex = 0;
            this.currentPathBox.TextChanged += new System.EventHandler(this.currentPathBox_TextChanged);
            // 
            // drivesList
            // 
            this.drivesList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.drivesList.DropDownWidth = 45;
            this.drivesList.FormattingEnabled = true;
            this.drivesList.Location = new System.Drawing.Point(270, 29);
            this.drivesList.MinimumSize = new System.Drawing.Size(45, 0);
            this.drivesList.Name = "drivesList";
            this.drivesList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.drivesList.Size = new System.Drawing.Size(45, 21);
            this.drivesList.TabIndex = 1;
            this.drivesList.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.drivesList.SelectedIndexChanged += new System.EventHandler(this.drivesList_SelectedIndexChanged);
            // 
            // containerBox
            // 
            this.containerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerBox.FormattingEnabled = true;
            this.containerBox.Location = new System.Drawing.Point(3, 57);
            this.containerBox.MinimumSize = new System.Drawing.Size(300, 147);
            this.containerBox.Name = "containerBox";
            this.containerBox.Size = new System.Drawing.Size(312, 251);
            this.containerBox.TabIndex = 2;
            this.containerBox.SelectedIndexChanged += new System.EventHandler(this.containerBox_SelectedIndexChanged);
            this.containerBox.DoubleClick += new System.EventHandler(this.containerBox_DoubleClick);
            // 
            // goBackButton
            // 
            this.goBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.goBackButton.Location = new System.Drawing.Point(3, 29);
            this.goBackButton.MinimumSize = new System.Drawing.Size(150, 22);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(150, 22);
            this.goBackButton.TabIndex = 3;
            this.goBackButton.Text = ". . .";
            this.goBackButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // MiniTCPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.containerBox);
            this.Controls.Add(this.drivesList);
            this.Controls.Add(this.currentPathBox);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "MiniTCPanel";
            this.Size = new System.Drawing.Size(318, 400);
            this.Load += new System.EventHandler(this.MiniTCPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox currentPathBox;
        private System.Windows.Forms.ComboBox drivesList;
        private System.Windows.Forms.ListBox containerBox;
        private System.Windows.Forms.Button goBackButton;
    }
}
