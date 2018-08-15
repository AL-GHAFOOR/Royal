namespace BABInventory.forms
{
    partial class frmUserInfo
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
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.page1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbUserType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtDate = new DevExpress.XtraEditors.DateEdit();
            this.lstvUser = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtVerifyPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserId = new DevExpress.XtraEditors.TextEdit();
            this.page2 = new DevExpress.XtraTab.XtraTabPage();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnUExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnUCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbUType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtUDate = new DevExpress.XtraEditors.DateEdit();
            this.lstvUpdate = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtUUserId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.page1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUserType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerifyPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).BeginInit();
            this.page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUUserId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(12, 17);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.page1;
            this.tabControl.Size = new System.Drawing.Size(565, 329);
            this.tabControl.TabIndex = 269;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.page1,
            this.page2});
            this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // page1
            // 
            this.page1.Controls.Add(this.labelControl2);
            this.page1.Controls.Add(this.cmbUserType);
            this.page1.Controls.Add(this.txtDate);
            this.page1.Controls.Add(this.lstvUser);
            this.page1.Controls.Add(this.labelControl1);
            this.page1.Controls.Add(this.txtVerifyPassword);
            this.page1.Controls.Add(this.btnExit);
            this.page1.Controls.Add(this.btnCancel);
            this.page1.Controls.Add(this.btnSave);
            this.page1.Controls.Add(this.labelControl13);
            this.page1.Controls.Add(this.labelControl27);
            this.page1.Controls.Add(this.labelControl7);
            this.page1.Controls.Add(this.labelControl6);
            this.page1.Controls.Add(this.txtPassword);
            this.page1.Controls.Add(this.txtUserName);
            this.page1.Controls.Add(this.txtUserId);
            this.page1.Name = "page1";
            this.page1.Size = new System.Drawing.Size(559, 301);
            this.page1.Text = "New User";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(251, 193);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 14);
            this.labelControl2.TabIndex = 286;
            this.labelControl2.Text = "User Role:";
            // 
            // cmbUserType
            // 
            this.cmbUserType.Location = new System.Drawing.Point(313, 192);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUserType.Size = new System.Drawing.Size(218, 20);
            this.cmbUserType.TabIndex = 285;
            this.cmbUserType.SelectedIndexChanged += new System.EventHandler(this.cmbUserType_SelectedIndexChanged);
            this.cmbUserType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUserType_KeyPress);
            // 
            // txtDate
            // 
            this.txtDate.EditValue = null;
            this.txtDate.Location = new System.Drawing.Point(313, 166);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDate.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.txtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.txtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDate.Size = new System.Drawing.Size(218, 20);
            this.txtDate.TabIndex = 284;
            this.txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDate_KeyPress);
            // 
            // lstvUser
            // 
            this.lstvUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstvUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvUser.GridLines = true;
            this.lstvUser.Location = new System.Drawing.Point(25, 56);
            this.lstvUser.MultiSelect = false;
            this.lstvUser.Name = "lstvUser";
            this.lstvUser.Size = new System.Drawing.Size(187, 202);
            this.lstvUser.TabIndex = 283;
            this.lstvUser.UseCompatibleStateImageBehavior = false;
            this.lstvUser.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User ID";
            this.columnHeader1.Width = 183;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(217, 140);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 14);
            this.labelControl1.TabIndex = 282;
            this.labelControl1.Text = "Verify Password:";
            // 
            // txtVerifyPassword
            // 
            this.txtVerifyPassword.Location = new System.Drawing.Point(313, 138);
            this.txtVerifyPassword.Name = "txtVerifyPassword";
            this.txtVerifyPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerifyPassword.Properties.Appearance.Options.UseFont = true;
            this.txtVerifyPassword.Properties.PasswordChar = '*';
            this.txtVerifyPassword.Size = new System.Drawing.Size(218, 22);
            this.txtVerifyPassword.TabIndex = 281;
            this.txtVerifyPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVerifyPassword_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(456, 260);
            this.btnExit.LookAndFeel.SkinName = "The Asphalt World";
            this.btnExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 23);
            this.btnExit.TabIndex = 280;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(394, 260);
            this.btnCancel.LookAndFeel.SkinName = "The Asphalt World";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 279;
            this.btnCancel.Text = "&Refresh";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(332, 260);
            this.btnSave.LookAndFeel.SkinName = "The Asphalt World";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 276;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Location = new System.Drawing.Point(252, 113);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(55, 14);
            this.labelControl13.TabIndex = 275;
            this.labelControl13.Text = "Password:";
            // 
            // labelControl27
            // 
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Location = new System.Drawing.Point(227, 167);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(79, 14);
            this.labelControl27.TabIndex = 274;
            this.labelControl27.Text = "Creation Date:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(239, 59);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(68, 14);
            this.labelControl7.TabIndex = 273;
            this.labelControl7.Text = "Login Name:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(249, 86);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(56, 14);
            this.labelControl6.TabIndex = 272;
            this.labelControl6.Text = "Full Name:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(313, 111);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(218, 22);
            this.txtPassword.TabIndex = 271;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(313, 84);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(218, 22);
            this.txtUserName.TabIndex = 270;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(313, 57);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.Properties.Appearance.Options.UseFont = true;
            this.txtUserId.Size = new System.Drawing.Size(218, 22);
            this.txtUserId.TabIndex = 269;
            this.txtUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserId_KeyPress);
            // 
            // page2
            // 
            this.page2.Controls.Add(this.btnDelete);
            this.page2.Controls.Add(this.btnEdit);
            this.page2.Controls.Add(this.btnUExit);
            this.page2.Controls.Add(this.btnUCancel);
            this.page2.Controls.Add(this.labelControl3);
            this.page2.Controls.Add(this.cmbUType);
            this.page2.Controls.Add(this.txtUDate);
            this.page2.Controls.Add(this.lstvUpdate);
            this.page2.Controls.Add(this.labelControl4);
            this.page2.Controls.Add(this.txtNewPassword);
            this.page2.Controls.Add(this.labelControl5);
            this.page2.Controls.Add(this.labelControl8);
            this.page2.Controls.Add(this.labelControl9);
            this.page2.Controls.Add(this.labelControl10);
            this.page2.Controls.Add(this.txtOldPassword);
            this.page2.Controls.Add(this.txtUUserName);
            this.page2.Controls.Add(this.txtUUserId);
            this.page2.Name = "page2";
            this.page2.Size = new System.Drawing.Size(559, 301);
            this.page2.Text = "User Edit";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Location = new System.Drawing.Point(360, 259);
            this.btnDelete.LookAndFeel.SkinName = "The Asphalt World";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 23);
            this.btnDelete.TabIndex = 305;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Location = new System.Drawing.Point(298, 259);
            this.btnEdit.LookAndFeel.SkinName = "The Asphalt World";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(56, 23);
            this.btnEdit.TabIndex = 304;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnUExit
            // 
            this.btnUExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUExit.Appearance.Options.UseFont = true;
            this.btnUExit.Location = new System.Drawing.Point(484, 259);
            this.btnUExit.LookAndFeel.SkinName = "The Asphalt World";
            this.btnUExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUExit.Name = "btnUExit";
            this.btnUExit.Size = new System.Drawing.Size(56, 23);
            this.btnUExit.TabIndex = 303;
            this.btnUExit.Text = "E&xit";
            this.btnUExit.Click += new System.EventHandler(this.btnUExit_Click);
            // 
            // btnUCancel
            // 
            this.btnUCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUCancel.Appearance.Options.UseFont = true;
            this.btnUCancel.Location = new System.Drawing.Point(422, 259);
            this.btnUCancel.LookAndFeel.SkinName = "The Asphalt World";
            this.btnUCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUCancel.Name = "btnUCancel";
            this.btnUCancel.Size = new System.Drawing.Size(56, 23);
            this.btnUCancel.TabIndex = 302;
            this.btnUCancel.Text = "&Cancel";
            this.btnUCancel.Click += new System.EventHandler(this.btnUCancel_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(243, 194);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 14);
            this.labelControl3.TabIndex = 299;
            this.labelControl3.Text = "User Type :";
            // 
            // cmbUType
            // 
            this.cmbUType.Location = new System.Drawing.Point(313, 192);
            this.cmbUType.Name = "cmbUType";
            this.cmbUType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUType.Size = new System.Drawing.Size(218, 20);
            this.cmbUType.TabIndex = 298;
            this.cmbUType.SelectedIndexChanged += new System.EventHandler(this.cmbUType_SelectedIndexChanged);
            this.cmbUType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUType_KeyPress);
            // 
            // txtUDate
            // 
            this.txtUDate.EditValue = null;
            this.txtUDate.Location = new System.Drawing.Point(313, 166);
            this.txtUDate.Name = "txtUDate";
            this.txtUDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtUDate.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.txtUDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtUDate.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.txtUDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtUDate.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtUDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUDate.Size = new System.Drawing.Size(218, 20);
            this.txtUDate.TabIndex = 297;
            this.txtUDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDate_KeyPress);
            // 
            // lstvUpdate
            // 
            this.lstvUpdate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lstvUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvUpdate.GridLines = true;
            this.lstvUpdate.Location = new System.Drawing.Point(25, 56);
            this.lstvUpdate.MultiSelect = false;
            this.lstvUpdate.Name = "lstvUpdate";
            this.lstvUpdate.Size = new System.Drawing.Size(187, 202);
            this.lstvUpdate.TabIndex = 296;
            this.lstvUpdate.UseCompatibleStateImageBehavior = false;
            this.lstvUpdate.View = System.Windows.Forms.View.Details;
            this.lstvUpdate.SelectedIndexChanged += new System.EventHandler(this.lstvUpdate_SelectedIndexChanged);
            this.lstvUpdate.DoubleClick += new System.EventHandler(this.lstvUpdate_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User ID";
            this.columnHeader2.Width = 183;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(223, 141);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 295;
            this.labelControl4.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(313, 138);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Properties.Appearance.Options.UseFont = true;
            this.txtNewPassword.Properties.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(218, 22);
            this.txtNewPassword.TabIndex = 294;
            this.txtNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUVerifyPass_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(226, 114);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(77, 14);
            this.labelControl5.TabIndex = 293;
            this.labelControl5.Text = "Old Password:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(228, 168);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(79, 14);
            this.labelControl8.TabIndex = 292;
            this.labelControl8.Text = "Creation Date:";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(239, 60);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(68, 14);
            this.labelControl9.TabIndex = 291;
            this.labelControl9.Text = "Login Name:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(248, 87);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(56, 14);
            this.labelControl10.TabIndex = 290;
            this.labelControl10.Text = "Full Name:";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(313, 111);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.Properties.Appearance.Options.UseFont = true;
            this.txtOldPassword.Properties.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(218, 22);
            this.txtOldPassword.TabIndex = 289;
            this.txtOldPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUPassword_KeyPress);
            // 
            // txtUUserName
            // 
            this.txtUUserName.Location = new System.Drawing.Point(313, 84);
            this.txtUUserName.Name = "txtUUserName";
            this.txtUUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUUserName.Size = new System.Drawing.Size(218, 22);
            this.txtUUserName.TabIndex = 288;
            this.txtUUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUUserName_KeyPress);
            // 
            // txtUUserId
            // 
            this.txtUUserId.Location = new System.Drawing.Point(313, 57);
            this.txtUUserId.Name = "txtUUserId";
            this.txtUUserId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUUserId.Properties.Appearance.Options.UseFont = true;
            this.txtUUserId.Size = new System.Drawing.Size(218, 22);
            this.txtUUserId.TabIndex = 287;
            this.txtUUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUUserId_KeyPress);
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 359);
            this.Controls.Add(this.tabControl);
            this.LookAndFeel.SkinName = "Money Twins";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            this.Shown += new System.EventHandler(this.frmUserInfo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.page1.ResumeLayout(false);
            this.page1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUserType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerifyPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).EndInit();
            this.page2.ResumeLayout(false);
            this.page2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUUserId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage page1;
        private DevExpress.XtraTab.XtraTabPage page2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUserType;
        private DevExpress.XtraEditors.DateEdit txtDate;
        private System.Windows.Forms.ListView lstvUser;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtVerifyPassword;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtUserId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUType;
        private DevExpress.XtraEditors.DateEdit txtUDate;
        private System.Windows.Forms.ListView lstvUpdate;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtOldPassword;
        private DevExpress.XtraEditors.TextEdit txtUUserName;
        private DevExpress.XtraEditors.TextEdit txtUUserId;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnUExit;
        private DevExpress.XtraEditors.SimpleButton btnUCancel;
    }
}