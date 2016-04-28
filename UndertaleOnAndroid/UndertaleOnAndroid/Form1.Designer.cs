namespace UndertaleOnAndroid
{
    partial class frmHT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHT));
            this.lblLoc = new System.Windows.Forms.Label();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.btnBrowseUT = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnCreateApk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(12, 9);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(100, 13);
            this.lblLoc.TabIndex = 0;
            this.lblLoc.Text = "Undertale Location:";
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(12, 25);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.ReadOnly = true;
            this.txtLoc.Size = new System.Drawing.Size(301, 20);
            this.txtLoc.TabIndex = 1;
            // 
            // btnBrowseUT
            // 
            this.btnBrowseUT.Location = new System.Drawing.Point(319, 23);
            this.btnBrowseUT.Name = "btnBrowseUT";
            this.btnBrowseUT.Size = new System.Drawing.Size(79, 23);
            this.btnBrowseUT.TabIndex = 2;
            this.btnBrowseUT.Text = "Browse";
            this.btnBrowseUT.UseVisualStyleBackColor = true;
            this.btnBrowseUT.Click += new System.EventHandler(this.btnBrowseUT_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(12, 51);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(386, 335);
            this.rtbLog.TabIndex = 3;
            this.rtbLog.Text = "";
            // 
            // btnCreateApk
            // 
            this.btnCreateApk.Location = new System.Drawing.Point(323, 392);
            this.btnCreateApk.Name = "btnCreateApk";
            this.btnCreateApk.Size = new System.Drawing.Size(75, 23);
            this.btnCreateApk.TabIndex = 4;
            this.btnCreateApk.Text = "Create";
            this.btnCreateApk.UseVisualStyleBackColor = true;
            this.btnCreateApk.Click += new System.EventHandler(this.btnCreateApk_Click);
            // 
            // frmHT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 426);
            this.Controls.Add(this.btnCreateApk);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnBrowseUT);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.lblLoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHT";
            this.Text = "UPHT - Undertale Port Helper Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Button btnBrowseUT;
        private System.Windows.Forms.Button btnCreateApk;
        public System.Windows.Forms.RichTextBox rtbLog;
    }
}

