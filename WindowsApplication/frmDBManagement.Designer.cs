namespace WindowsApplication
{
    partial class frmDBManagement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlDatabaseNameList = new System.Windows.Forms.ComboBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstBackup = new System.Windows.Forms.ListBox();
            this.btnFullBackup = new System.Windows.Forms.Button();
            this.btnPartialBackup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ddlDatabaseNameList);
            this.panel1.Controls.Add(this.btnRestore);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnFullBackup);
            this.panel1.Controls.Add(this.btnPartialBackup);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 392);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Database ";
            // 
            // ddlDatabaseNameList
            // 
            this.ddlDatabaseNameList.FormattingEnabled = true;
            this.ddlDatabaseNameList.Location = new System.Drawing.Point(73, 36);
            this.ddlDatabaseNameList.Name = "ddlDatabaseNameList";
            this.ddlDatabaseNameList.Size = new System.Drawing.Size(147, 21);
            this.ddlDatabaseNameList.TabIndex = 5;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(11, 134);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(209, 23);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Restore DB Backup";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstBackup);
            this.panel2.Location = new System.Drawing.Point(254, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 364);
            this.panel2.TabIndex = 3;
            // 
            // lstBackup
            // 
            this.lstBackup.FormattingEnabled = true;
            this.lstBackup.Location = new System.Drawing.Point(3, 3);
            this.lstBackup.Name = "lstBackup";
            this.lstBackup.Size = new System.Drawing.Size(304, 355);
            this.lstBackup.TabIndex = 3;
            // 
            // btnFullBackup
            // 
            this.btnFullBackup.Location = new System.Drawing.Point(11, 105);
            this.btnFullBackup.Name = "btnFullBackup";
            this.btnFullBackup.Size = new System.Drawing.Size(209, 23);
            this.btnFullBackup.TabIndex = 1;
            this.btnFullBackup.Text = "Full DB Backup";
            this.btnFullBackup.UseVisualStyleBackColor = true;
            this.btnFullBackup.Click += new System.EventHandler(this.btnFullBackup_Click);
            // 
            // btnPartialBackup
            // 
            this.btnPartialBackup.Location = new System.Drawing.Point(11, 76);
            this.btnPartialBackup.Name = "btnPartialBackup";
            this.btnPartialBackup.Size = new System.Drawing.Size(209, 23);
            this.btnPartialBackup.TabIndex = 0;
            this.btnPartialBackup.Text = "Partial DB Backup";
            this.btnPartialBackup.UseVisualStyleBackColor = true;
            this.btnPartialBackup.Click += new System.EventHandler(this.btnPartialBackup_Click);
            // 
            // frmDBManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 388);
            this.Controls.Add(this.panel1);
            this.Name = "frmDBManagement";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPartialBackup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFullBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ListBox lstBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlDatabaseNameList;
    }
}

