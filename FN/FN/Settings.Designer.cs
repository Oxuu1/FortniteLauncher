namespace FN.FN
{
    partial class Settings
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
            this.materialSingleLineTextFieldInstallLocation = new ns1.SiticoneMaterialTextBox();
            this.siticoneButton2 = new ns1.SiticoneButton();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // materialSingleLineTextFieldInstallLocation
            // 
            this.materialSingleLineTextFieldInstallLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.materialSingleLineTextFieldInstallLocation.DefaultText = "";
            this.materialSingleLineTextFieldInstallLocation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.materialSingleLineTextFieldInstallLocation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.materialSingleLineTextFieldInstallLocation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.materialSingleLineTextFieldInstallLocation.DisabledState.Parent = this.materialSingleLineTextFieldInstallLocation;
            this.materialSingleLineTextFieldInstallLocation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.materialSingleLineTextFieldInstallLocation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.materialSingleLineTextFieldInstallLocation.FocusedState.Parent = this.materialSingleLineTextFieldInstallLocation;
            this.materialSingleLineTextFieldInstallLocation.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.materialSingleLineTextFieldInstallLocation.HoveredState.Parent = this.materialSingleLineTextFieldInstallLocation;
            this.materialSingleLineTextFieldInstallLocation.Location = new System.Drawing.Point(12, 25);
            this.materialSingleLineTextFieldInstallLocation.Name = "materialSingleLineTextFieldInstallLocation";
            this.materialSingleLineTextFieldInstallLocation.PasswordChar = '\0';
            this.materialSingleLineTextFieldInstallLocation.PlaceholderText = "";
            this.materialSingleLineTextFieldInstallLocation.SelectedText = "";
            this.materialSingleLineTextFieldInstallLocation.ShadowDecoration.Parent = this.materialSingleLineTextFieldInstallLocation;
            this.materialSingleLineTextFieldInstallLocation.Size = new System.Drawing.Size(345, 36);
            this.materialSingleLineTextFieldInstallLocation.TabIndex = 0;
            // 
            // siticoneButton2
            // 
            this.siticoneButton2.BackColor = System.Drawing.Color.Blue;
            this.siticoneButton2.CheckedState.Parent = this.siticoneButton2;
            this.siticoneButton2.CustomImages.Parent = this.siticoneButton2;
            this.siticoneButton2.FillColor = System.Drawing.Color.Blue;
            this.siticoneButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton2.ForeColor = System.Drawing.Color.White;
            this.siticoneButton2.HoveredState.Parent = this.siticoneButton2;
            this.siticoneButton2.Location = new System.Drawing.Point(12, 67);
            this.siticoneButton2.Name = "siticoneButton2";
            this.siticoneButton2.ShadowDecoration.Parent = this.siticoneButton2;
            this.siticoneButton2.Size = new System.Drawing.Size(396, 62);
            this.siticoneButton2.TabIndex = 7;
            this.siticoneButton2.Text = "Save";
            this.siticoneButton2.Click += new System.EventHandler(this.siticoneButton2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(363, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 144);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.siticoneButton2);
            this.Controls.Add(this.materialSingleLineTextFieldInstallLocation);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ns1.SiticoneMaterialTextBox materialSingleLineTextFieldInstallLocation;
        private ns1.SiticoneButton siticoneButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}