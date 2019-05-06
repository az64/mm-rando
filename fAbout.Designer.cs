namespace MMRando
{
    partial class fAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAbout));
            this.discordLabelText = new System.Windows.Forms.Label();
            this.discordLabel = new System.Windows.Forms.Label();
            this.discordLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // discordLabelText
            // 
            this.discordLabelText.Location = new System.Drawing.Point(27, 33);
            this.discordLabelText.Name = "discordLabelText";
            this.discordLabelText.Size = new System.Drawing.Size(308, 145);
            this.discordLabelText.TabIndex = 0;
            this.discordLabelText.Text = resources.GetString("discordLabelText.Text");
            this.discordLabelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.discordLabelText.Click += new System.EventHandler(this.discordLabelText_Click);
            // 
            // discordLabel
            // 
            this.discordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discordLabel.Location = new System.Drawing.Point(0, 1);
            this.discordLabel.Name = "discordLabel";
            this.discordLabel.Size = new System.Drawing.Size(359, 27);
            this.discordLabel.TabIndex = 1;
            this.discordLabel.Text = "Majora\'s Mask Randomizer";
            this.discordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.discordLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // discordLinkLabel
            // 
            this.discordLinkLabel.AutoSize = true;
            this.discordLinkLabel.Location = new System.Drawing.Point(108, 119);
            this.discordLinkLabel.Name = "discordLinkLabel";
            this.discordLinkLabel.Size = new System.Drawing.Size(141, 13);
            this.discordLinkLabel.TabIndex = 2;
            this.discordLinkLabel.TabStop = true;
            this.discordLinkLabel.Text = "https://discord.gg/8qbreUM";
            this.discordLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.discordLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // fAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 183);
            this.Controls.Add(this.discordLinkLabel);
            this.Controls.Add(this.discordLabel);
            this.Controls.Add(this.discordLabelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fAbout";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label discordLabelText;
        private System.Windows.Forms.Label discordLabel;
        private System.Windows.Forms.LinkLabel discordLinkLabel;
    }
}