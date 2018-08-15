namespace GHospital_Care.OutdoorPatient
{
    partial class OPServiceTreatment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OP_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_PatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_AssDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OP_Date,
            this.OP_PatientID,
            this.OP_PatientName,
            this.OP_AssDoctor,
            this.Fees});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 18;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(698, 388);
            this.dataGridView1.TabIndex = 247;
            // 
            // OP_Date
            // 
            this.OP_Date.DataPropertyName = "ServiceDate";
            this.OP_Date.HeaderText = "Date";
            this.OP_Date.Name = "OP_Date";
            this.OP_Date.ReadOnly = true;
            this.OP_Date.Width = 80;
            // 
            // OP_PatientID
            // 
            this.OP_PatientID.DataPropertyName = "OPID";
            this.OP_PatientID.HeaderText = "Patient ID";
            this.OP_PatientID.Name = "OP_PatientID";
            this.OP_PatientID.ReadOnly = true;
            // 
            // OP_PatientName
            // 
            this.OP_PatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OP_PatientName.DataPropertyName = "PatientName";
            this.OP_PatientName.FillWeight = 17.54385F;
            this.OP_PatientName.HeaderText = "Patient Name";
            this.OP_PatientName.Name = "OP_PatientName";
            this.OP_PatientName.ReadOnly = true;
            // 
            // OP_AssDoctor
            // 
            this.OP_AssDoctor.DataPropertyName = "Doctor";
            this.OP_AssDoctor.FillWeight = 182.4561F;
            this.OP_AssDoctor.HeaderText = "Assigned Doctor";
            this.OP_AssDoctor.Name = "OP_AssDoctor";
            this.OP_AssDoctor.ReadOnly = true;
            this.OP_AssDoctor.Width = 200;
            // 
            // Fees
            // 
            this.Fees.DataPropertyName = "Fees";
            this.Fees.HeaderText = "Fees";
            this.Fees.Name = "Fees";
            this.Fees.ReadOnly = true;
            // 
            // OPServiceTreatment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 388);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OPServiceTreatment";
            this.Text = "OPServiceTreatment";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_PatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_AssDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fees;
    }
}