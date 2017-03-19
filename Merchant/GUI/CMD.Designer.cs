namespace Merchant.GUI
{
    partial class CMD
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
            this.LoadProfileButton = new System.Windows.Forms.Button();
            this.LoadProfileOFD = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LoadProfileButton
            // 
            this.LoadProfileButton.Location = new System.Drawing.Point(197, 226);
            this.LoadProfileButton.Name = "LoadProfileButton";
            this.LoadProfileButton.Size = new System.Drawing.Size(75, 23);
            this.LoadProfileButton.TabIndex = 2;
            this.LoadProfileButton.Text = "Load Profile";
            this.LoadProfileButton.UseVisualStyleBackColor = true;
            this.LoadProfileButton.Click += new System.EventHandler(this.LoadProfileButton_Click);
            // 
            // LoadProfileOFD
            // 
            this.LoadProfileOFD.FileName = "LoadProfileOFD";
            this.LoadProfileOFD.Filter = "Profiles (*.xml; *.json)|*.xml; *.json";
            this.LoadProfileOFD.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadProfileOFD_FileOk);
            // 
            // CMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.LoadProfileButton);
            this.Name = "CMD";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button LoadProfileButton;
        private System.Windows.Forms.OpenFileDialog LoadProfileOFD;
    }
}