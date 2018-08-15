namespace GHospital_Care.Settings
{
    partial class BackupDatabase
    {
        /// <summary>
        /// Required designer variable. </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupDatabase));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.optBAK = new DotNetSkin.SkinControls.SkinRadioButton();
            this.optGS = new DotNetSkin.SkinControls.SkinRadioButton();
            this.optXLS = new DotNetSkin.SkinControls.SkinRadioButton();
            this.optPDF = new DotNetSkin.SkinControls.SkinRadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.optSelect = new DotNetSkin.SkinControls.SkinRadioButton();
            this.optDefault = new DotNetSkin.SkinControls.SkinRadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 26);
            this.panel1.TabIndex = 195;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "GHospital Care  | Backup Database";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 185);
            this.panel2.TabIndex = 194;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 189);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(238, 4);
            this.panel4.TabIndex = 192;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(238, 4);
            this.panel5.TabIndex = 193;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(238, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 193);
            this.panel3.TabIndex = 191;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 196;
            this.label2.Text = "Select File Format to Backup";
            // 
            // optBAK
            // 
            this.optBAK.AutoSize = true;
            this.optBAK.BackColor = System.Drawing.Color.Transparent;
            this.optBAK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optBAK.Location = new System.Drawing.Point(15, 67);
            this.optBAK.Name = "optBAK";
            this.optBAK.Size = new System.Drawing.Size(48, 17);
            this.optBAK.TabIndex = 197;
            this.optBAK.Text = ".BAK";
            this.optBAK.UseVisualStyleBackColor = true;
            this.optBAK.CheckedChanged += new System.EventHandler(this.optBAK_CheckedChanged);
            // 
            // optGS
            // 
            this.optGS.AutoSize = true;
            this.optGS.BackColor = System.Drawing.Color.Transparent;
            this.optGS.Checked = true;
            this.optGS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optGS.Location = new System.Drawing.Point(71, 67);
            this.optGS.Name = "optGS";
            this.optGS.Size = new System.Drawing.Size(42, 17);
            this.optGS.TabIndex = 198;
            this.optGS.TabStop = true;
            this.optGS.Text = ".GS";
            this.optGS.UseVisualStyleBackColor = true;
            this.optGS.CheckedChanged += new System.EventHandler(this.optGS_CheckedChanged);
            // 
            // optXLS
            // 
            this.optXLS.AutoSize = true;
            this.optXLS.BackColor = System.Drawing.Color.Transparent;
            this.optXLS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optXLS.Location = new System.Drawing.Point(119, 67);
            this.optXLS.Name = "optXLS";
            this.optXLS.Size = new System.Drawing.Size(46, 17);
            this.optXLS.TabIndex = 199;
            this.optXLS.Text = ".XLS";
            this.optXLS.UseVisualStyleBackColor = true;
            this.optXLS.CheckedChanged += new System.EventHandler(this.optXLS_CheckedChanged);
            // 
            // optPDF
            // 
            this.optPDF.AutoSize = true;
            this.optPDF.BackColor = System.Drawing.Color.Transparent;
            this.optPDF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPDF.Location = new System.Drawing.Point(171, 67);
            this.optPDF.Name = "optPDF";
            this.optPDF.Size = new System.Drawing.Size(48, 17);
            this.optPDF.TabIndex = 200;
            this.optPDF.Text = ".PDF";
            this.optPDF.UseVisualStyleBackColor = true;
            this.optPDF.CheckedChanged += new System.EventHandler(this.optPDF_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.optSelect);
            this.panel6.Controls.Add(this.optDefault);
            this.panel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(12, 118);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(216, 22);
            this.panel6.TabIndex = 201;
            // 
            // optSelect
            // 
            this.optSelect.AutoSize = true;
            this.optSelect.BackColor = System.Drawing.Color.Transparent;
            this.optSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSelect.Location = new System.Drawing.Point(126, 3);
            this.optSelect.Name = "optSelect";
            this.optSelect.Size = new System.Drawing.Size(80, 17);
            this.optSelect.TabIndex = 200;
            this.optSelect.TabStop = true;
            this.optSelect.Text = "Select Root";
            this.optSelect.UseVisualStyleBackColor = true;
            // 
            // optDefault
            // 
            this.optDefault.AutoSize = true;
            this.optDefault.BackColor = System.Drawing.Color.Transparent;
            this.optDefault.Checked = true;
            this.optDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDefault.Location = new System.Drawing.Point(3, 3);
            this.optDefault.Name = "optDefault";
            this.optDefault.Size = new System.Drawing.Size(107, 17);
            this.optDefault.TabIndex = 199;
            this.optDefault.TabStop = true;
            this.optDefault.Text = "Use Default Root";
            this.optDefault.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(171, 160);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 23);
            this.btnClose.TabIndex = 202;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.Location = new System.Drawing.Point(81, 160);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(86, 23);
            this.btnCreateBackup.TabIndex = 203;
            this.btnCreateBackup.Text = "Create Backup";
            this.btnCreateBackup.UseVisualStyleBackColor = true;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // BackupDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 193);
            this.Controls.Add(this.btnCreateBackup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.optPDF);
            this.Controls.Add(this.optXLS);
            this.Controls.Add(this.optGS);
            this.Controls.Add(this.optBAK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BackupDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup Database";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private DotNetSkin.SkinControls.SkinRadioButton optBAK;
        private DotNetSkin.SkinControls.SkinRadioButton optGS;
        private DotNetSkin.SkinControls.SkinRadioButton optXLS;
        private DotNetSkin.SkinControls.SkinRadioButton optPDF;
        private System.Windows.Forms.Panel panel6;
        private DotNetSkin.SkinControls.SkinRadioButton optSelect;
        private DotNetSkin.SkinControls.SkinRadioButton optDefault;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateBackup;
    }
}