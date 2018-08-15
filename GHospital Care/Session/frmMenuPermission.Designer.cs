namespace GHospital_Care.Session
{
    partial class frmMenuPermission
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.Page1 = new DevExpress.XtraTab.XtraTabPage();
            this.cmbRoleUser = new System.Windows.Forms.ComboBox();
            this.chkReporting = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkDelete = new DevExpress.XtraEditors.CheckEdit();
            this.chkEdit = new DevExpress.XtraEditors.CheckEdit();
            this.chkSave = new DevExpress.XtraEditors.CheckEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.CaptionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Permission = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Insert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Update = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Reporting = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAccountName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnRoleExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnRoleRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnRoleSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtRoleDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtRoleName = new DevExpress.XtraEditors.TextEdit();
            this.CheckRoleReporting = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.CheckRoleDelete = new DevExpress.XtraEditors.CheckEdit();
            this.CheckRoleEdit = new DevExpress.XtraEditors.CheckEdit();
            this.CheckRoleSave = new DevExpress.XtraEditors.CheckEdit();
            this.CheckRoleSelectAll = new DevExpress.XtraEditors.CheckEdit();
            this.dataGridViewRole = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkReporting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountName.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleReporting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleSelectAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRole)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.Page1;
            this.xtraTabControl1.Size = new System.Drawing.Size(988, 554);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.Page1,
            this.xtraTabPage1});
            this.xtraTabControl1.Click += new System.EventHandler(this.xtraTabControl1_Click);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.cmbRoleUser);
            this.Page1.Controls.Add(this.chkReporting);
            this.Page1.Controls.Add(this.labelControl3);
            this.Page1.Controls.Add(this.chkDelete);
            this.Page1.Controls.Add(this.chkEdit);
            this.Page1.Controls.Add(this.chkSave);
            this.Page1.Controls.Add(this.chkAll);
            this.Page1.Controls.Add(this.dgv);
            this.Page1.Controls.Add(this.btnExit);
            this.Page1.Controls.Add(this.btnCancel);
            this.Page1.Controls.Add(this.btnSave);
            this.Page1.Controls.Add(this.labelControl1);
            this.Page1.Controls.Add(this.cmbAccountName);
            this.Page1.Name = "Page1";
            this.Page1.Size = new System.Drawing.Size(982, 526);
            this.Page1.Text = "Menu Permission";
            // 
            // cmbRoleUser
            // 
            this.cmbRoleUser.FormattingEnabled = true;
            this.cmbRoleUser.Location = new System.Drawing.Point(11, 45);
            this.cmbRoleUser.Name = "cmbRoleUser";
            this.cmbRoleUser.Size = new System.Drawing.Size(227, 21);
            this.cmbRoleUser.TabIndex = 22;
            this.cmbRoleUser.SelectedIndexChanged += new System.EventHandler(this.cmbRoleUser_SelectedIndexChanged);
            // 
            // chkReporting
            // 
            this.chkReporting.Location = new System.Drawing.Point(900, 469);
            this.chkReporting.Name = "chkReporting";
            this.chkReporting.Properties.Caption = "Reporting";
            this.chkReporting.Size = new System.Drawing.Size(75, 19);
            this.chkReporting.TabIndex = 21;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(902, 378);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Data Access Role :";
            // 
            // chkDelete
            // 
            this.chkDelete.Location = new System.Drawing.Point(900, 445);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Properties.Caption = "Delete";
            this.chkDelete.Size = new System.Drawing.Size(75, 19);
            this.chkDelete.TabIndex = 19;
            // 
            // chkEdit
            // 
            this.chkEdit.Location = new System.Drawing.Point(900, 421);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Properties.Caption = "Edit";
            this.chkEdit.Size = new System.Drawing.Size(75, 19);
            this.chkEdit.TabIndex = 18;
            // 
            // chkSave
            // 
            this.chkSave.Location = new System.Drawing.Point(900, 397);
            this.chkSave.Name = "chkSave";
            this.chkSave.Properties.Caption = "Save";
            this.chkSave.Size = new System.Drawing.Size(75, 19);
            this.chkSave.TabIndex = 17;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(784, 500);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Select All";
            this.chkAll.Size = new System.Drawing.Size(75, 19);
            this.chkAll.TabIndex = 16;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CaptionName,
            this.FormName,
            this.MenuName,
            this.Permission,
            this.Insert,
            this.Update,
            this.Delete,
            this.Reporting});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgv.Location = new System.Drawing.Point(11, 72);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(964, 293);
            this.dgv.TabIndex = 15;
            // 
            // CaptionName
            // 
            this.CaptionName.DataPropertyName = "CaptionName";
            this.CaptionName.HeaderText = "Caption";
            this.CaptionName.Name = "CaptionName";
            this.CaptionName.Width = 200;
            // 
            // FormName
            // 
            this.FormName.DataPropertyName = "formName";
            this.FormName.HeaderText = "FormName";
            this.FormName.Name = "FormName";
            // 
            // MenuName
            // 
            this.MenuName.DataPropertyName = "MenuName";
            this.MenuName.HeaderText = "Menu Name";
            this.MenuName.Name = "MenuName";
            // 
            // Permission
            // 
            this.Permission.FalseValue = "false";
            this.Permission.HeaderText = "Permission";
            this.Permission.IndeterminateValue = "";
            this.Permission.Name = "Permission";
            this.Permission.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Permission.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Permission.TrueValue = "true";
            this.Permission.Width = 120;
            // 
            // Insert
            // 
            this.Insert.HeaderText = "Insert";
            this.Insert.Name = "Insert";
            // 
            // Update
            // 
            this.Update.HeaderText = "Update";
            this.Update.Name = "Update";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            // 
            // Reporting
            // 
            this.Reporting.HeaderText = "Reporting";
            this.Reporting.Name = "Reporting";
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExit.Location = new System.Drawing.Point(342, 371);
            this.btnExit.LookAndFeel.SkinName = "The Asphalt World";
            this.btnExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(162, 40);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancel.Location = new System.Drawing.Point(177, 371);
            this.btnCancel.LookAndFeel.SkinName = "The Asphalt World";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Refresh";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSave.Location = new System.Drawing.Point(12, 371);
            this.btnSave.LookAndFeel.SkinName = "The Asphalt World";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Role User";
            // 
            // cmbAccountName
            // 
            this.cmbAccountName.Location = new System.Drawing.Point(356, 3);
            this.cmbAccountName.Name = "cmbAccountName";
            this.cmbAccountName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAccountName.Size = new System.Drawing.Size(46, 20);
            this.cmbAccountName.TabIndex = 10;
            this.cmbAccountName.Visible = false;
            this.cmbAccountName.SelectedIndexChanged += new System.EventHandler(this.cmbAccountName_SelectedIndexChanged_1);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnRoleExit);
            this.xtraTabPage1.Controls.Add(this.btnRoleRefresh);
            this.xtraTabPage1.Controls.Add(this.btnRoleSave);
            this.xtraTabPage1.Controls.Add(this.labelControl19);
            this.xtraTabPage1.Controls.Add(this.labelControl20);
            this.xtraTabPage1.Controls.Add(this.txtRoleDescription);
            this.xtraTabPage1.Controls.Add(this.txtRoleName);
            this.xtraTabPage1.Controls.Add(this.CheckRoleReporting);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.CheckRoleDelete);
            this.xtraTabPage1.Controls.Add(this.CheckRoleEdit);
            this.xtraTabPage1.Controls.Add(this.CheckRoleSave);
            this.xtraTabPage1.Controls.Add(this.CheckRoleSelectAll);
            this.xtraTabPage1.Controls.Add(this.dataGridViewRole);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(982, 526);
            this.xtraTabPage1.Text = "Create New Permission Role";
            // 
            // btnRoleExit
            // 
            this.btnRoleExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoleExit.Appearance.Options.UseFont = true;
            this.btnRoleExit.Location = new System.Drawing.Point(451, 402);
            this.btnRoleExit.LookAndFeel.SkinName = "The Asphalt World";
            this.btnRoleExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRoleExit.Name = "btnRoleExit";
            this.btnRoleExit.Size = new System.Drawing.Size(58, 23);
            this.btnRoleExit.TabIndex = 303;
            this.btnRoleExit.Text = "E&xit";
            // 
            // btnRoleRefresh
            // 
            this.btnRoleRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoleRefresh.Appearance.Options.UseFont = true;
            this.btnRoleRefresh.Location = new System.Drawing.Point(386, 402);
            this.btnRoleRefresh.LookAndFeel.SkinName = "The Asphalt World";
            this.btnRoleRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRoleRefresh.Name = "btnRoleRefresh";
            this.btnRoleRefresh.Size = new System.Drawing.Size(58, 23);
            this.btnRoleRefresh.TabIndex = 302;
            this.btnRoleRefresh.Text = "&Refresh";
            this.btnRoleRefresh.Click += new System.EventHandler(this.btnRoleRefresh_Click);
            // 
            // btnRoleSave
            // 
            this.btnRoleSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoleSave.Appearance.Options.UseFont = true;
            this.btnRoleSave.Location = new System.Drawing.Point(322, 402);
            this.btnRoleSave.LookAndFeel.SkinName = "The Asphalt World";
            this.btnRoleSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRoleSave.Name = "btnRoleSave";
            this.btnRoleSave.Size = new System.Drawing.Size(58, 23);
            this.btnRoleSave.TabIndex = 301;
            this.btnRoleSave.Text = "&Save";
            this.btnRoleSave.Click += new System.EventHandler(this.btnRoleSave_Click);
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Location = new System.Drawing.Point(147, 26);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(58, 14);
            this.labelControl19.TabIndex = 300;
            this.labelControl19.Text = "Role Name";
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl20.Location = new System.Drawing.Point(145, 57);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(60, 14);
            this.labelControl20.TabIndex = 299;
            this.labelControl20.Text = "Description";
            // 
            // txtRoleDescription
            // 
            this.txtRoleDescription.Location = new System.Drawing.Point(226, 54);
            this.txtRoleDescription.Name = "txtRoleDescription";
            this.txtRoleDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleDescription.Properties.Appearance.Options.UseFont = true;
            this.txtRoleDescription.Size = new System.Drawing.Size(218, 22);
            this.txtRoleDescription.TabIndex = 298;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(226, 27);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleName.Properties.Appearance.Options.UseFont = true;
            this.txtRoleName.Size = new System.Drawing.Size(218, 22);
            this.txtRoleName.TabIndex = 297;
            // 
            // CheckRoleReporting
            // 
            this.CheckRoleReporting.Location = new System.Drawing.Point(710, 309);
            this.CheckRoleReporting.Name = "CheckRoleReporting";
            this.CheckRoleReporting.Properties.Caption = "Reporting";
            this.CheckRoleReporting.Size = new System.Drawing.Size(75, 19);
            this.CheckRoleReporting.TabIndex = 30;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(712, 218);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 13);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "Data Access Role :";
            // 
            // CheckRoleDelete
            // 
            this.CheckRoleDelete.Location = new System.Drawing.Point(710, 285);
            this.CheckRoleDelete.Name = "CheckRoleDelete";
            this.CheckRoleDelete.Properties.Caption = "Delete";
            this.CheckRoleDelete.Size = new System.Drawing.Size(75, 19);
            this.CheckRoleDelete.TabIndex = 28;
            // 
            // CheckRoleEdit
            // 
            this.CheckRoleEdit.Location = new System.Drawing.Point(710, 261);
            this.CheckRoleEdit.Name = "CheckRoleEdit";
            this.CheckRoleEdit.Properties.Caption = "Edit";
            this.CheckRoleEdit.Size = new System.Drawing.Size(75, 19);
            this.CheckRoleEdit.TabIndex = 27;
            // 
            // CheckRoleSave
            // 
            this.CheckRoleSave.Location = new System.Drawing.Point(710, 237);
            this.CheckRoleSave.Name = "CheckRoleSave";
            this.CheckRoleSave.Properties.Caption = "Save";
            this.CheckRoleSave.Size = new System.Drawing.Size(75, 19);
            this.CheckRoleSave.TabIndex = 26;
            // 
            // CheckRoleSelectAll
            // 
            this.CheckRoleSelectAll.Location = new System.Drawing.Point(710, 109);
            this.CheckRoleSelectAll.Name = "CheckRoleSelectAll";
            this.CheckRoleSelectAll.Properties.Caption = "Select All";
            this.CheckRoleSelectAll.Size = new System.Drawing.Size(75, 19);
            this.CheckRoleSelectAll.TabIndex = 25;
            this.CheckRoleSelectAll.CheckedChanged += new System.EventHandler(this.CheckRoleSelectAll_CheckedChanged);
            // 
            // dataGridViewRole
            // 
            this.dataGridViewRole.AllowUserToAddRows = false;
            this.dataGridViewRole.AllowUserToDeleteRows = false;
            this.dataGridViewRole.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1});
            this.dataGridViewRole.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewRole.Location = new System.Drawing.Point(29, 89);
            this.dataGridViewRole.MultiSelect = false;
            this.dataGridViewRole.Name = "dataGridViewRole";
            this.dataGridViewRole.RowHeadersVisible = false;
            this.dataGridViewRole.Size = new System.Drawing.Size(675, 293);
            this.dataGridViewRole.TabIndex = 24;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Menu Text";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "SubMenu";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Menu Caption";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "false";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Permission";
            this.dataGridViewCheckBoxColumn1.IndeterminateValue = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.TrueValue = "true";
            this.dataGridViewCheckBoxColumn1.Width = 120;
            // 
            // frmMenuPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 554);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmMenuPermission";
            this.Text = "frmMenuPermission";
            this.Load += new System.EventHandler(this.frmMenuPermission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkReporting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountName.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleReporting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRoleSelectAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage Page1;
        private DevExpress.XtraEditors.CheckEdit chkReporting;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkDelete;
        private DevExpress.XtraEditors.CheckEdit chkEdit;
        private DevExpress.XtraEditors.CheckEdit chkSave;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private System.Windows.Forms.DataGridView dgv;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAccountName;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.CheckEdit CheckRoleReporting;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit CheckRoleDelete;
        private DevExpress.XtraEditors.CheckEdit CheckRoleEdit;
        private DevExpress.XtraEditors.CheckEdit CheckRoleSave;
        private DevExpress.XtraEditors.CheckEdit CheckRoleSelectAll;
        private System.Windows.Forms.DataGridView dataGridViewRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.TextEdit txtRoleDescription;
        private DevExpress.XtraEditors.TextEdit txtRoleName;
        private DevExpress.XtraEditors.SimpleButton btnRoleExit;
        private DevExpress.XtraEditors.SimpleButton btnRoleRefresh;
        private DevExpress.XtraEditors.SimpleButton btnRoleSave;
        private System.Windows.Forms.ComboBox cmbRoleUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaptionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Permission;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Insert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Update;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Reporting;
    }
}