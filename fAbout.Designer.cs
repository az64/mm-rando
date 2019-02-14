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
            this.lAboutText = new System.Windows.Forms.Label();
            this.lVer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lAboutText
            // 
            this.lAboutText.Location = new System.Drawing.Point(12, 9);
            this.lAboutText.Name = "lAboutText";
            this.lAboutText.Size = new System.Drawing.Size(335, 123);
            this.lAboutText.TabIndex = 0;
            this.lAboutText.Text = resources.GetString("lAboutText.Text");
            // 
            // lVer
            // 
            this.lVer.AutoSize = true;
            this.lVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVer.Location = new System.Drawing.Point(192, 9);
            this.lVer.Name = "lVer";
            this.lVer.Size = new System.Drawing.Size(49, 13);
            this.lVer.TabIndex = 1;
            this.lVer.Text = "Version";
            // 
            // fAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 141);
            this.Controls.Add(this.lVer);
            this.Controls.Add(this.lAboutText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fAbout";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lAboutText;
        private System.Windows.Forms.Label lVer;
    }
}