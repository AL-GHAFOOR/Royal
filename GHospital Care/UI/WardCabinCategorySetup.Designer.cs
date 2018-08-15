namespace GHospital_Care.UI
{
    partial class WardCabinCategorySetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WardCabinCategorySetup));
            this.categorygroupBox = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.btnNew = new Office2007Button.SpecialButton();
            this.btnDelete = new Office2007Button.SpecialButton();
            this.btnSave = new Office2007Button.SpecialButton();
            this.btnEdit = new Office2007Button.SpecialButton();
            this.btnColse = new Office2007Button.SpecialButton();
            this.categoryDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.categorygroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // categorygroupBox
            // 
            this.categorygroupBox.Controls.Add(this.txtId);
            this.categorygroupBox.Controls.Add(this.txtCategory);
            this.categorygroupBox.Controls.Add(this.btnNew);
            this.categorygroupBox.Controls.Add(this.btnDelete);
            this.categorygroupBox.Controls.Add(this.btnSave);
            this.categorygroupBox.Controls.Add(this.btnEdit);
            this.categorygroupBox.Controls.Add(this.btnColse);
            this.categorygroupBox.Controls.Add(this.categoryDataGridView);
            this.categorygroupBox.Controls.Add(this.label2);
            this.categorygroupBox.Controls.Add(this.label3);
            this.categorygroupBox.Location = new System.Drawing.Point(20, 32);
            this.categorygroupBox.Name = "categorygroupBox";
            this.categorygroupBox.Size = new System.Drawing.Size(348, 284);
            this.categorygroupBox.TabIndex = 100111;
            this.categorygroupBox.TabStop = false;
            this.categorygroupBox.Text = "Manage Category";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(153, 9);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(119, 20);
            this.txtId.TabIndex = 100119;
            this.txtId.Visible = false;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(83, 35);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(217, 20);
            this.txtCategory.TabIndex = 100118;
            // 
            // btnNew
            // 
            this.btnNew.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(6, 231);
            this.btnNew.Name = "btnNew";
            this.btnNew.PressedButton = false;
            this.btnNew.Size = new System.Drawing.Size(62, 20);
            this.btnNew.TabIndex = 100117;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(211, 231);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PressedButton = false;
            this.btnDelete.Size = new System.Drawing.Size(62, 20);
            this.btnDelete.TabIndex = 100116;
            this.btnDelete.Tag = "3";
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(77, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedButton = false;
            this.btnSave.Size = new System.Drawing.Size(62, 20);
            this.btnSave.TabIndex = 100114;
            this.btnSave.Tag = "1";
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnEdit
            // 
            this.btnEdit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(144, 231);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressedButton = false;
            this.btnEdit.Size = new System.Drawing.Size(62, 20);
            this.btnEdit.TabIndex = 100115;
            this.btnEdit.Tag = "2";
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnColse
            // 
            this.btnColse.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnColse.BackColor = System.Drawing.Color.Transparent;
            this.btnColse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnColse.Location = new System.Drawing.Point(278, 231);
            this.btnColse.Name = "btnColse";
            this.btnColse.PressedButton = false;
            this.btnColse.Size = new System.Drawing.Size(62, 20);
            this.btnColse.TabIndex = 100113;
            this.btnColse.Text = "Close";
            this.btnColse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click_1);
            // 
            // categoryDataGridView
            // 
            this.categoryDataGridView.AllowUserToAddRows = false;
            this.categoryDataGridView.AllowUserToDeleteRows = false;
            this.categoryDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.categoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Category});
            this.categoryDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.categoryDataGridView.Location = new System.Drawing.Point(99, 61);
            this.categoryDataGridView.Name = "categoryDataGridView";
            this.categoryDataGridView.ReadOnly = true;
            this.categoryDataGridView.RowHeadersVisible = false;
            this.categoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoryDataGridView.Size = new System.Drawing.Size(201, 154);
            this.categoryDataGridView.TabIndex = 100112;
            this.categoryDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.categoryDataGridView_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category Name";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 100111;
            this.label2.Text = "CatagoryID";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 100111;
            this.label3.Text = "Catagory";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.categorygroupBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 325);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 26);
            this.panel2.TabIndex = 214;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "GHospital Care  | Ward/Cabin Catagory Setup ";
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
            // WardCabinCategorySetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(411, 331);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WardCabinCategorySetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WardCabinCategorySetup";
            this.Load += new System.EventHandler(this.WardCabinCategorySetup_Load);
            this.categorygroupBox.ResumeLayout(false);
            this.categorygroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox categorygroupBox;
        private System.Windows.Forms.TextBox txtCategory;
        private Office2007Button.SpecialButton btnNew;
        private Office2007Button.SpecialButton btnDelete;
        private Office2007Button.SpecialButton btnSave;
        private Office2007Button.SpecialButton btnEdit;
        private Office2007Button.SpecialButton btnColse;
        private System.Windows.Forms.DataGridView categoryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;

    }
}