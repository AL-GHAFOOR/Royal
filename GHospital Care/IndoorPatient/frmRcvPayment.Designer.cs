namespace GHospital_Care.IndoorPatient
{
    partial class frmRcvPayment
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
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrint = new VistaButton.VistaButton();
            this.btnRefresh = new VistaButton.VistaButton();
            this.vistaButton1 = new VistaButton.VistaButton();
            this.SuspendLayout();
            // 
            // ToDate
            // 
            this.ToDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ToDate.CustomFormat = "dd-MM-yyyy";
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(195, 124);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(100, 21);
            this.ToDate.TabIndex = 100110;
            // 
            // FromDate
            // 
            this.FromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FromDate.CustomFormat = "dd-MM-yyyy";
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDate.Location = new System.Drawing.Point(195, 97);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(100, 21);
            this.FromDate.TabIndex = 100111;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 100109;
            this.label5.Text = "To Date";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 100108;
            this.label4.Text = "From Date";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BaseColor = System.Drawing.Color.Red;
            this.btnPrint.ButtonColor = System.Drawing.Color.SaddleBrown;
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.CornerRadius = 3;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.HighlightColor = System.Drawing.Color.Transparent;
            this.btnPrint.Location = new System.Drawing.Point(-421, 91);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 27);
            this.btnPrint.TabIndex = 100107;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BaseColor = System.Drawing.Color.Red;
            this.btnRefresh.ButtonColor = System.Drawing.Color.SaddleBrown;
            this.btnRefresh.ButtonText = "Refresh";
            this.btnRefresh.CornerRadius = 3;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefresh.HighlightColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Location = new System.Drawing.Point(-497, 91);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 27);
            this.btnRefresh.TabIndex = 100106;
            // 
            // vistaButton1
            // 
            this.vistaButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.Red;
            this.vistaButton1.ButtonColor = System.Drawing.Color.SaddleBrown;
            this.vistaButton1.ButtonText = "Print";
            this.vistaButton1.CornerRadius = 3;
            this.vistaButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vistaButton1.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.vistaButton1.HighlightColor = System.Drawing.Color.Transparent;
            this.vistaButton1.Location = new System.Drawing.Point(225, 164);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(70, 27);
            this.vistaButton1.TabIndex = 100113;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // frmRcvPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 261);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRefresh);
            this.Name = "frmRcvPayment";
            this.Text = "frmRcvPayment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private VistaButton.VistaButton btnPrint;
        private VistaButton.VistaButton btnRefresh;
        private VistaButton.VistaButton vistaButton1;
    }
}