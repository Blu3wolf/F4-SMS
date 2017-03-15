namespace F4_SMS
{
    partial class MainMenu
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
            this.comboBoxTape = new System.Windows.Forms.ComboBox();
            this.tapeLoadButton = new System.Windows.Forms.Button();
            this.comboBoxTapeLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxIssues = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxTape
            // 
            this.comboBoxTape.FormattingEnabled = true;
            this.comboBoxTape.Location = new System.Drawing.Point(86, 27);
            this.comboBoxTape.Name = "comboBoxTape";
            this.comboBoxTape.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTape.TabIndex = 0;
            this.comboBoxTape.Text = "M5.1";
            // 
            // tapeLoadButton
            // 
            this.tapeLoadButton.Location = new System.Drawing.Point(213, 25);
            this.tapeLoadButton.Name = "tapeLoadButton";
            this.tapeLoadButton.Size = new System.Drawing.Size(75, 23);
            this.tapeLoadButton.TabIndex = 1;
            this.tapeLoadButton.Text = "Load";
            this.tapeLoadButton.UseVisualStyleBackColor = true;
            this.tapeLoadButton.Click += new System.EventHandler(this.tapeLoadButton_Click);
            // 
            // comboBoxTapeLabel
            // 
            this.comboBoxTapeLabel.AutoSize = true;
            this.comboBoxTapeLabel.Location = new System.Drawing.Point(12, 30);
            this.comboBoxTapeLabel.Name = "comboBoxTapeLabel";
            this.comboBoxTapeLabel.Size = new System.Drawing.Size(68, 13);
            this.comboBoxTapeLabel.TabIndex = 2;
            this.comboBoxTapeLabel.Text = "Aircraft Tape";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutToolStripMenuItem.Text = "About F4-SMS";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // textBoxIssues
            // 
            this.textBoxIssues.Location = new System.Drawing.Point(12, 54);
            this.textBoxIssues.Multiline = true;
            this.textBoxIssues.Name = "textBoxIssues";
            this.textBoxIssues.ReadOnly = true;
            this.textBoxIssues.Size = new System.Drawing.Size(346, 53);
            this.textBoxIssues.TabIndex = 4;
            this.textBoxIssues.Text = "To report a bug, please open an Issue on the GitHub Repository. Thanks for checki" +
    "ng out F4-SMS!";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 121);
            this.Controls.Add(this.textBoxIssues);
            this.Controls.Add(this.comboBoxTapeLabel);
            this.Controls.Add(this.tapeLoadButton);
            this.Controls.Add(this.comboBoxTape);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.Text = "F4-SMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTape;
        private System.Windows.Forms.Button tapeLoadButton;
        private System.Windows.Forms.Label comboBoxTapeLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxIssues;
    }
}

