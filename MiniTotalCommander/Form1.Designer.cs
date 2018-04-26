namespace MiniTotalCommander
{
    partial class Form1
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
            this.miniTCPanel1 = new MiniTotalCommander.MiniTCPanel();
            this.miniTCPanel2 = new MiniTotalCommander.MiniTCPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // miniTCPanel1
            // 
            this.miniTCPanel1.Location = new System.Drawing.Point(12, 12);
            this.miniTCPanel1.MinimumSize = new System.Drawing.Size(320, 400);
            this.miniTCPanel1.Name = "miniTCPanel1";
            this.miniTCPanel1.Size = new System.Drawing.Size(320, 400);
            this.miniTCPanel1.TabIndex = 0;
            this.miniTCPanel1.Enter += new System.EventHandler(this.miniTCPanel1_Enter);
            // 
            // miniTCPanel2
            // 
            this.miniTCPanel2.Location = new System.Drawing.Point(354, 12);
            this.miniTCPanel2.MinimumSize = new System.Drawing.Size(300, 400);
            this.miniTCPanel2.Name = "miniTCPanel2";
            this.miniTCPanel2.Size = new System.Drawing.Size(318, 400);
            this.miniTCPanel2.TabIndex = 1;
            this.miniTCPanel2.Enter += new System.EventHandler(this.miniTCPanel2_Enter);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteButton.Location = new System.Drawing.Point(27, 418);
            this.deleteButton.MinimumSize = new System.Drawing.Size(100, 40);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 40);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // copyButton
            // 
            this.copyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.copyButton.Location = new System.Drawing.Point(133, 418);
            this.copyButton.MinimumSize = new System.Drawing.Size(100, 40);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(100, 40);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "Kopiuj";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.moveButton.Location = new System.Drawing.Point(239, 418);
            this.moveButton.MinimumSize = new System.Drawing.Size(100, 40);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(100, 40);
            this.moveButton.TabIndex = 4;
            this.moveButton.Text = "Przenieś";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.miniTCPanel2);
            this.Controls.Add(this.miniTCPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MiniTCPanel miniTCPanel1;
        private MiniTCPanel miniTCPanel2;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button moveButton;
    }
}

