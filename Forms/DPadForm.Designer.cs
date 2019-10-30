namespace MMRando.Forms
{
    partial class DPadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DPadForm));
            this.DPadItemsGroupBox = new System.Windows.Forms.GroupBox();
            this.DPadItemTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DPadItemDownComboBox = new System.Windows.Forms.ComboBox();
            this.DPadItemRightComboBox = new System.Windows.Forms.ComboBox();
            this.DPadItemLeftComboBox = new System.Windows.Forms.ComboBox();
            this.DPadItemLeftLabel = new System.Windows.Forms.Label();
            this.DPadItemUpLabel = new System.Windows.Forms.Label();
            this.DPadItemRightLabel = new System.Windows.Forms.Label();
            this.DPadItemDownLabel = new System.Windows.Forms.Label();
            this.DPadItemUpComboBox = new System.Windows.Forms.ComboBox();
            this.DPadTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PresetComboBox = new System.Windows.Forms.ComboBox();
            this.EnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DPadItemsGroupBox.SuspendLayout();
            this.DPadItemTableLayoutPanel.SuspendLayout();
            this.DPadTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DPadItemsGroupBox
            // 
            this.DPadItemsGroupBox.Controls.Add(this.DPadItemTableLayoutPanel);
            this.DPadItemsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DPadItemsGroupBox.Location = new System.Drawing.Point(6, 34);
            this.DPadItemsGroupBox.Name = "DPadItemsGroupBox";
            this.DPadItemsGroupBox.Size = new System.Drawing.Size(246, 143);
            this.DPadItemsGroupBox.TabIndex = 0;
            this.DPadItemsGroupBox.TabStop = false;
            this.DPadItemsGroupBox.Text = "D-Pad Items";
            // 
            // DPadItemTableLayoutPanel
            // 
            this.DPadItemTableLayoutPanel.ColumnCount = 2;
            this.DPadItemTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.DPadItemTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DPadItemTableLayoutPanel.Controls.Add(this.DPadItemDownComboBox, 1, 3);
            this.DPadItemTableLayoutPanel.Controls.Add(this.DPadItemRightComboBox, 1, 2);
            this.DPadItemTableLayoutPanel.Controls.Add(this.DPadItemLeftComboBox, 1, 1);
            this.DPadItemTableLayoutPanel.Controls.Add(this.DPadItemLeftLabel, 0, 1);
            this.DPadItemTableLayoutPanel.Controls.Add(this.DPadItemUpLabel, 0, 0);
            this.DPadItemTableLayoutPanel.Controls.Add(this.DPadItemRightLabel, 0, 2);
            this.DPadItemTableLayoutPanel.Controls.Add(this.DPadItemDownLabel, 0, 3);
            this.DPadItemTableLayoutPanel.Controls.Add(this.DPadItemUpComboBox, 1, 0);
            this.DPadItemTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPadItemTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.DPadItemTableLayoutPanel.Name = "DPadItemTableLayoutPanel";
            this.DPadItemTableLayoutPanel.RowCount = 4;
            this.DPadItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.DPadItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.DPadItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.DPadItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.DPadItemTableLayoutPanel.Size = new System.Drawing.Size(240, 124);
            this.DPadItemTableLayoutPanel.TabIndex = 0;
            // 
            // DPadItemDownComboBox
            // 
            this.DPadItemDownComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPadItemDownComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DPadItemDownComboBox.FormattingEnabled = true;
            this.DPadItemDownComboBox.Location = new System.Drawing.Point(48, 95);
            this.DPadItemDownComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.DPadItemDownComboBox.Name = "DPadItemDownComboBox";
            this.DPadItemDownComboBox.Size = new System.Drawing.Size(187, 21);
            this.DPadItemDownComboBox.TabIndex = 7;
            this.DPadItemDownComboBox.SelectedIndexChanged += new System.EventHandler(this.DPadItemDownComboBox_SelectedIndexChanged);
            // 
            // DPadItemRightComboBox
            // 
            this.DPadItemRightComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPadItemRightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DPadItemRightComboBox.FormattingEnabled = true;
            this.DPadItemRightComboBox.Location = new System.Drawing.Point(48, 65);
            this.DPadItemRightComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.DPadItemRightComboBox.Name = "DPadItemRightComboBox";
            this.DPadItemRightComboBox.Size = new System.Drawing.Size(187, 21);
            this.DPadItemRightComboBox.TabIndex = 6;
            this.DPadItemRightComboBox.SelectedIndexChanged += new System.EventHandler(this.DPadItemRightComboBox_SelectedIndexChanged);
            // 
            // DPadItemLeftComboBox
            // 
            this.DPadItemLeftComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPadItemLeftComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DPadItemLeftComboBox.FormattingEnabled = true;
            this.DPadItemLeftComboBox.Location = new System.Drawing.Point(48, 35);
            this.DPadItemLeftComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.DPadItemLeftComboBox.Name = "DPadItemLeftComboBox";
            this.DPadItemLeftComboBox.Size = new System.Drawing.Size(187, 21);
            this.DPadItemLeftComboBox.TabIndex = 5;
            this.DPadItemLeftComboBox.SelectedIndexChanged += new System.EventHandler(this.DPadItemLeftComboBox_SelectedIndexChanged);
            // 
            // DPadItemLeftLabel
            // 
            this.DPadItemLeftLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DPadItemLeftLabel.Location = new System.Drawing.Point(4, 34);
            this.DPadItemLeftLabel.Margin = new System.Windows.Forms.Padding(4);
            this.DPadItemLeftLabel.Name = "DPadItemLeftLabel";
            this.DPadItemLeftLabel.Size = new System.Drawing.Size(35, 22);
            this.DPadItemLeftLabel.TabIndex = 2;
            this.DPadItemLeftLabel.Text = "Left";
            this.DPadItemLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DPadItemUpLabel
            // 
            this.DPadItemUpLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DPadItemUpLabel.Location = new System.Drawing.Point(4, 4);
            this.DPadItemUpLabel.Margin = new System.Windows.Forms.Padding(4);
            this.DPadItemUpLabel.Name = "DPadItemUpLabel";
            this.DPadItemUpLabel.Size = new System.Drawing.Size(35, 22);
            this.DPadItemUpLabel.TabIndex = 0;
            this.DPadItemUpLabel.Text = "Up";
            this.DPadItemUpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DPadItemRightLabel
            // 
            this.DPadItemRightLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DPadItemRightLabel.Location = new System.Drawing.Point(4, 64);
            this.DPadItemRightLabel.Margin = new System.Windows.Forms.Padding(4);
            this.DPadItemRightLabel.Name = "DPadItemRightLabel";
            this.DPadItemRightLabel.Size = new System.Drawing.Size(35, 22);
            this.DPadItemRightLabel.TabIndex = 1;
            this.DPadItemRightLabel.Text = "Right";
            this.DPadItemRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DPadItemDownLabel
            // 
            this.DPadItemDownLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DPadItemDownLabel.Location = new System.Drawing.Point(4, 94);
            this.DPadItemDownLabel.Margin = new System.Windows.Forms.Padding(4);
            this.DPadItemDownLabel.Name = "DPadItemDownLabel";
            this.DPadItemDownLabel.Size = new System.Drawing.Size(35, 26);
            this.DPadItemDownLabel.TabIndex = 3;
            this.DPadItemDownLabel.Text = "Down";
            this.DPadItemDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DPadItemUpComboBox
            // 
            this.DPadItemUpComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPadItemUpComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DPadItemUpComboBox.FormattingEnabled = true;
            this.DPadItemUpComboBox.Location = new System.Drawing.Point(48, 5);
            this.DPadItemUpComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.DPadItemUpComboBox.Name = "DPadItemUpComboBox";
            this.DPadItemUpComboBox.Size = new System.Drawing.Size(187, 21);
            this.DPadItemUpComboBox.TabIndex = 4;
            this.DPadItemUpComboBox.SelectedIndexChanged += new System.EventHandler(this.DPadItemUpComboBox_SelectedIndexChanged);
            // 
            // DPadTableLayoutPanel
            // 
            this.DPadTableLayoutPanel.ColumnCount = 2;
            this.DPadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.DPadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.DPadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.DPadTableLayoutPanel.Controls.Add(this.PresetComboBox, 1, 0);
            this.DPadTableLayoutPanel.Controls.Add(this.EnabledCheckBox, 0, 0);
            this.DPadTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DPadTableLayoutPanel.Location = new System.Drawing.Point(6, 6);
            this.DPadTableLayoutPanel.Name = "DPadTableLayoutPanel";
            this.DPadTableLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.DPadTableLayoutPanel.RowCount = 1;
            this.DPadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DPadTableLayoutPanel.Size = new System.Drawing.Size(246, 28);
            this.DPadTableLayoutPanel.TabIndex = 1;
            // 
            // PresetComboBox
            // 
            this.PresetComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PresetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PresetComboBox.FormattingEnabled = true;
            this.PresetComboBox.Location = new System.Drawing.Point(93, 3);
            this.PresetComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.PresetComboBox.Name = "PresetComboBox";
            this.PresetComboBox.Size = new System.Drawing.Size(150, 21);
            this.PresetComboBox.TabIndex = 1;
            this.PresetComboBox.SelectedIndexChanged += new System.EventHandler(this.PresetComboBox_SelectedIndexChanged);
            // 
            // EnabledCheckBox
            // 
            this.EnabledCheckBox.AutoSize = true;
            this.EnabledCheckBox.Checked = true;
            this.EnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnabledCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.EnabledCheckBox.Location = new System.Drawing.Point(6, 6);
            this.EnabledCheckBox.Name = "EnabledCheckBox";
            this.EnabledCheckBox.Size = new System.Drawing.Size(65, 16);
            this.EnabledCheckBox.TabIndex = 2;
            this.EnabledCheckBox.Text = "Enabled";
            this.EnabledCheckBox.UseVisualStyleBackColor = true;
            this.EnabledCheckBox.CheckedChanged += new System.EventHandler(this.EnabledCheckBox_CheckedChanged);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.UpdateButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(6, 179);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(3);
            this.BottomPanel.Size = new System.Drawing.Size(246, 30);
            this.BottomPanel.TabIndex = 2;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.UpdateButton.Location = new System.Drawing.Point(168, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 24);
            this.UpdateButton.TabIndex = 0;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DPadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 215);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.DPadItemsGroupBox);
            this.Controls.Add(this.DPadTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DPadForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "D-Pad Configuration";
            this.DPadItemsGroupBox.ResumeLayout(false);
            this.DPadItemTableLayoutPanel.ResumeLayout(false);
            this.DPadTableLayoutPanel.ResumeLayout(false);
            this.DPadTableLayoutPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DPadItemsGroupBox;
        private System.Windows.Forms.TableLayoutPanel DPadItemTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel DPadTableLayoutPanel;
        private System.Windows.Forms.ComboBox PresetComboBox;
        private System.Windows.Forms.CheckBox EnabledCheckBox;
        private System.Windows.Forms.Label DPadItemUpLabel;
        private System.Windows.Forms.Label DPadItemLeftLabel;
        private System.Windows.Forms.Label DPadItemRightLabel;
        private System.Windows.Forms.Label DPadItemDownLabel;
        private System.Windows.Forms.ComboBox DPadItemUpComboBox;
        private System.Windows.Forms.ComboBox DPadItemDownComboBox;
        private System.Windows.Forms.ComboBox DPadItemRightComboBox;
        private System.Windows.Forms.ComboBox DPadItemLeftComboBox;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button UpdateButton;
    }
}