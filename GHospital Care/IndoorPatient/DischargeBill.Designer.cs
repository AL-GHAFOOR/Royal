using System.Security.Cryptography.X509Certificates;

namespace GHospital_Care.IndoorPatient
{
    internal partial class DischargeBill
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
        {if (disposing && (components != null))
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DischargeBill));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.ChkOTMC = new System.Windows.Forms.CheckBox();
            this.ChkOTSC = new System.Windows.Forms.CheckBox();
            this.chkPC = new System.Windows.Forms.CheckBox();
            this.chkMC = new System.Windows.Forms.CheckBox();
            this.chkBC = new System.Windows.Forms.CheckBox();
            this.chkCC = new System.Windows.Forms.CheckBox();
            this.chkHC = new System.Windows.Forms.CheckBox();
            this.txtOTMedicine = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInward = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.txtadvancePaid = new System.Windows.Forms.TextBox();
            this.txtNetPayble = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbBillType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txttaxpercent = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtservicecharge = new System.Windows.Forms.TextBox();
            this.txtPrcentService = new System.Windows.Forms.TextBox();
            this.txttotalBill = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.specialButton3 = new Office2007Button.SpecialButton();
            this.btnNew = new Office2007Button.SpecialButton();
            this.specialButton1 = new Office2007Button.SpecialButton();
            this.btnClose = new Office2007Button.SpecialButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtpathology = new System.Windows.Forms.TextBox();
            this.txtmedicaineCharge = new System.Windows.Forms.TextBox();
            this.txtBedCharge = new System.Windows.Forms.TextBox();
            this.txtdoctorcharge = new System.Windows.Forms.TextBox();
            this.txtOTSerivce = new System.Windows.Forms.TextBox();
            this.txthospitalcharge = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtnoofdays = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtdischargeTime = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtdischargedate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbill = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblReg = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.billDate = new System.Windows.Forms.DateTimePicker();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 566);
            this.panel2.TabIndex = 246;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(891, 4);
            this.panel5.TabIndex = 245;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(891, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 570);
            this.panel3.TabIndex = 243;
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
            this.panel1.Size = new System.Drawing.Size(887, 24);
            this.panel1.TabIndex = 248;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "GHospital Care  | Discharge Patients";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(2, 474);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(869, 38);
            this.panel6.TabIndex = 253;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(4, 28);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(8, 542);
            this.panel7.TabIndex = 254;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 472);
            this.groupBox1.TabIndex = 255;
            this.groupBox1.TabStop = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 17);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(293, 452);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "PatientID";
            this.gridColumn9.FieldName = "OPID";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 67;
            // 
            // gridColumn10
            // 
            this.gridColumn10.FieldName = "PatientName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 120;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Bed/Cabin";
            this.gridColumn11.FieldName = "BedName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 88;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPrint);
            this.groupBox2.Controls.Add(this.ChkOTMC);
            this.groupBox2.Controls.Add(this.ChkOTSC);
            this.groupBox2.Controls.Add(this.chkPC);
            this.groupBox2.Controls.Add(this.chkMC);
            this.groupBox2.Controls.Add(this.chkBC);
            this.groupBox2.Controls.Add(this.chkCC);
            this.groupBox2.Controls.Add(this.chkHC);
            this.groupBox2.Controls.Add(this.txtOTMedicine);
            this.groupBox2.Controls.Add(this.txtTax);
            this.groupBox2.Controls.Add(this.txtdiscount);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblInward);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.panel10);
            this.groupBox2.Controls.Add(this.txttaxpercent);
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.specialButton3);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.specialButton1);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.txtremarks);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.txtpathology);
            this.groupBox2.Controls.Add(this.txtmedicaineCharge);
            this.groupBox2.Controls.Add(this.txtBedCharge);
            this.groupBox2.Controls.Add(this.txtdoctorcharge);
            this.groupBox2.Controls.Add(this.txtOTSerivce);
            this.groupBox2.Controls.Add(this.txthospitalcharge);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtnoofdays);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtdischargeTime);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtdischargedate);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(303, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 391);
            this.groupBox2.TabIndex = 256;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Discharge/Make Bill";
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrint.ForeColor = System.Drawing.Color.Red;
            this.chkPrint.Location = new System.Drawing.Point(18, 362);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(116, 17);
            this.chkPrint.TabIndex = 201;
            this.chkPrint.Text = "Print After Save";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // ChkOTMC
            // 
            this.ChkOTMC.AutoSize = true;
            this.ChkOTMC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkOTMC.Location = new System.Drawing.Point(12, 233);
            this.ChkOTMC.Name = "ChkOTMC";
            this.ChkOTMC.Size = new System.Drawing.Size(15, 14);
            this.ChkOTMC.TabIndex = 200;
            this.ChkOTMC.UseVisualStyleBackColor = true;
            // 
            // ChkOTSC
            // 
            this.ChkOTSC.AutoSize = true;
            this.ChkOTSC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkOTSC.Location = new System.Drawing.Point(12, 207);
            this.ChkOTSC.Name = "ChkOTSC";
            this.ChkOTSC.Size = new System.Drawing.Size(15, 14);
            this.ChkOTSC.TabIndex = 199;
            this.ChkOTSC.UseVisualStyleBackColor = true;
            // 
            // chkPC
            // 
            this.chkPC.AutoSize = true;
            this.chkPC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPC.Location = new System.Drawing.Point(12, 180);
            this.chkPC.Name = "chkPC";
            this.chkPC.Size = new System.Drawing.Size(15, 14);
            this.chkPC.TabIndex = 198;
            this.chkPC.UseVisualStyleBackColor = true;
            // 
            // chkMC
            // 
            this.chkMC.AutoSize = true;
            this.chkMC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMC.Location = new System.Drawing.Point(12, 154);
            this.chkMC.Name = "chkMC";
            this.chkMC.Size = new System.Drawing.Size(15, 14);
            this.chkMC.TabIndex = 197;
            this.chkMC.UseVisualStyleBackColor = true;
            // 
            // chkBC
            // 
            this.chkBC.AutoSize = true;
            this.chkBC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBC.Location = new System.Drawing.Point(12, 126);
            this.chkBC.Name = "chkBC";
            this.chkBC.Size = new System.Drawing.Size(15, 14);
            this.chkBC.TabIndex = 196;
            this.chkBC.UseVisualStyleBackColor = true;
            // 
            // chkCC
            // 
            this.chkCC.AutoSize = true;
            this.chkCC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCC.Location = new System.Drawing.Point(12, 100);
            this.chkCC.Name = "chkCC";
            this.chkCC.Size = new System.Drawing.Size(15, 14);
            this.chkCC.TabIndex = 195;
            this.chkCC.UseVisualStyleBackColor = true;
            // 
            // chkHC
            // 
            this.chkHC.AutoSize = true;
            this.chkHC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHC.Location = new System.Drawing.Point(12, 74);
            this.chkHC.Name = "chkHC";
            this.chkHC.Size = new System.Drawing.Size(15, 14);
            this.chkHC.TabIndex = 194;
            this.chkHC.UseVisualStyleBackColor = true;
            // 
            // txtOTMedicine
            // 
            this.txtOTMedicine.BackColor = System.Drawing.Color.White;
            this.txtOTMedicine.Enabled = false;
            this.txtOTMedicine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTMedicine.Location = new System.Drawing.Point(159, 230);
            this.txtOTMedicine.Name = "txtOTMedicine";
            this.txtOTMedicine.ReadOnly = true;
            this.txtOTMedicine.Size = new System.Drawing.Size(121, 21);
            this.txtOTMedicine.TabIndex = 193;
            this.txtOTMedicine.Text = ".0";
            this.txtOTMedicine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTax
            // 
            this.txtTax.BackColor = System.Drawing.Color.White;
            this.txtTax.Enabled = false;
            this.txtTax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTax.Location = new System.Drawing.Point(438, 265);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(103, 21);
            this.txtTax.TabIndex = 1;
            this.txtTax.Text = "0.00";
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTax.Visible = false;
            this.txtTax.TextChanged += new System.EventHandler(this.txtTax_TextChanged);
            // 
            // txtdiscount
            // 
            this.txtdiscount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiscount.Location = new System.Drawing.Point(141, 400);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(103, 21);
            this.txtdiscount.TabIndex = 1;
            this.txtdiscount.Text = ".0";
            this.txtdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtdiscount.Visible = false;
            this.txtdiscount.TextChanged += new System.EventHandler(this.txtdiscount_TextChanged);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Green;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(9, 403);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(124, 20);
            this.label26.TabIndex = 51;
            this.label26.Text = "Discount";
            this.label26.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(31, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 192;
            this.label6.Text = "OT Medicine Charge";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInward
            // 
            this.lblInward.AutoSize = true;
            this.lblInward.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInward.Location = new System.Drawing.Point(78, 265);
            this.lblInward.Name = "lblInward";
            this.lblInward.Size = new System.Drawing.Size(157, 13);
            this.lblInward.TabIndex = 191;
            this.lblInward.Text = "SEVENTEEN FIVE THOUSAND";
            this.lblInward.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(292, 265);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(93, 20);
            this.label25.TabIndex = 42;
            this.label25.Text = "TAX";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label25.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 191;
            this.label5.Text = "IN WARD : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.Menu;
            this.panel10.Controls.Add(this.label28);
            this.panel10.Controls.Add(this.txtadvancePaid);
            this.panel10.Controls.Add(this.txtNetPayble);
            this.panel10.Controls.Add(this.label27);
            this.panel10.Controls.Add(this.cmbBillType);
            this.panel10.Controls.Add(this.label12);
            this.panel10.Location = new System.Drawing.Point(288, 139);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(260, 119);
            this.panel10.TabIndex = 190;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Green;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(5, 8);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(136, 20);
            this.label28.TabIndex = 53;
            this.label28.Text = "Advance Paid";
            // 
            // txtadvancePaid
            // 
            this.txtadvancePaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtadvancePaid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadvancePaid.Location = new System.Drawing.Point(151, 7);
            this.txtadvancePaid.Name = "txtadvancePaid";
            this.txtadvancePaid.Size = new System.Drawing.Size(103, 21);
            this.txtadvancePaid.TabIndex = 2;
            this.txtadvancePaid.Text = ".0";
            this.txtadvancePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtadvancePaid.TextChanged += new System.EventHandler(this.txtadvancePaid_TextChanged);
            // 
            // txtNetPayble
            // 
            this.txtNetPayble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtNetPayble.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetPayble.Location = new System.Drawing.Point(152, 39);
            this.txtNetPayble.Name = "txtNetPayble";
            this.txtNetPayble.ReadOnly = true;
            this.txtNetPayble.Size = new System.Drawing.Size(103, 21);
            this.txtNetPayble.TabIndex = 3;
            this.txtNetPayble.Text = ".0";
            this.txtNetPayble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNetPayble.TextChanged += new System.EventHandler(this.txtNetPayble_TextChanged);
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Green;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(6, 40);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(136, 20);
            this.label27.TabIndex = 52;
            this.label27.Text = "Net Payble";
            // 
            // cmbBillType
            // 
            this.cmbBillType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBillType.FormattingEnabled = true;
            this.cmbBillType.Items.AddRange(new object[] {
            "CASH",
            "CREDIT CARD",
            "OTHERS"});
            this.cmbBillType.Location = new System.Drawing.Point(152, 73);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Size = new System.Drawing.Size(103, 21);
            this.cmbBillType.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Green;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(6, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Bill Type";
            // 
            // txttaxpercent
            // 
            this.txttaxpercent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttaxpercent.Location = new System.Drawing.Point(409, 266);
            this.txttaxpercent.Name = "txttaxpercent";
            this.txttaxpercent.Size = new System.Drawing.Size(19, 21);
            this.txttaxpercent.TabIndex = 63;
            this.txttaxpercent.Text = "0";
            this.txttaxpercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttaxpercent.Visible = false;
            this.txttaxpercent.TextChanged += new System.EventHandler(this.txttaxpercent_TextChanged);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Info;
            this.panel8.Controls.Add(this.txtSubTotal);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label21);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.txtservicecharge);
            this.panel8.Controls.Add(this.txtPrcentService);
            this.panel8.Controls.Add(this.txttotalBill);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(286, 45);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(263, 89);
            this.panel8.TabIndex = 189;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BackColor = System.Drawing.Color.White;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(152, 63);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(103, 21);
            this.txtSubTotal.TabIndex = 0;
            this.txtSubTotal.Text = ".0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.TextChanged += new System.EventHandler(this.txtSubTotal_TextChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Green;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Sub Total";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(6, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 20);
            this.label21.TabIndex = 39;
            this.label21.Text = "Service Charge";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 187;
            this.label2.Text = "Total BILL";
            // 
            // txtservicecharge
            // 
            this.txtservicecharge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtservicecharge.Location = new System.Drawing.Point(152, 35);
            this.txtservicecharge.Name = "txtservicecharge";
            this.txtservicecharge.Size = new System.Drawing.Size(103, 21);
            this.txtservicecharge.TabIndex = 194;
            this.txtservicecharge.Text = ".0";
            this.txtservicecharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtservicecharge.TextChanged += new System.EventHandler(this.txtservicecharge_TextChanged_1);
            // 
            // txtPrcentService
            // 
            this.txtPrcentService.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrcentService.Location = new System.Drawing.Point(124, 37);
            this.txtPrcentService.Name = "txtPrcentService";
            this.txtPrcentService.Size = new System.Drawing.Size(19, 21);
            this.txtPrcentService.TabIndex = 189;
            this.txtPrcentService.Text = "20";
            this.txtPrcentService.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrcentService.TextChanged += new System.EventHandler(this.txtPrcentService_TextChanged);
            // 
            // txttotalBill
            // 
            this.txttotalBill.Enabled = false;
            this.txttotalBill.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalBill.Location = new System.Drawing.Point(152, 9);
            this.txttotalBill.Name = "txttotalBill";
            this.txttotalBill.Size = new System.Drawing.Size(103, 21);
            this.txttotalBill.TabIndex = 0;
            this.txttotalBill.Text = ".0";
            this.txttotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotalBill.TextChanged += new System.EventHandler(this.txttotalBill_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(102, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 188;
            this.label7.Text = "%";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(387, 269);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(20, 13);
            this.label32.TabIndex = 22;
            this.label32.Text = "%";
            this.label32.Visible = false;
            this.label32.Click += new System.EventHandler(this.label32_Click);
            // 
            // specialButton3
            // 
            this.specialButton3.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton3.BackColor = System.Drawing.Color.Transparent;
            this.specialButton3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton3.ForeColor = System.Drawing.Color.Black;
            this.specialButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.specialButton3.Location = new System.Drawing.Point(414, 342);
            this.specialButton3.Name = "specialButton3";
            this.specialButton3.PressedButton = false;
            this.specialButton3.Size = new System.Drawing.Size(64, 25);
            this.specialButton3.TabIndex = 186;
            this.specialButton3.Text = "Print";
            this.specialButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton3.Click += new System.EventHandler(this.specialButton3_Click);
            // 
            // btnNew
            // 
            this.btnNew.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(344, 341);
            this.btnNew.Name = "btnNew";
            this.btnNew.PressedButton = false;
            this.btnNew.Size = new System.Drawing.Size(64, 25);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // specialButton1
            // 
            this.specialButton1.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton1.BackColor = System.Drawing.Color.Transparent;
            this.specialButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton1.ForeColor = System.Drawing.Color.Black;
            this.specialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.specialButton1.Location = new System.Drawing.Point(267, 342);
            this.specialButton1.Name = "specialButton1";
            this.specialButton1.PressedButton = false;
            this.specialButton1.Size = new System.Drawing.Size(71, 25);
            this.specialButton1.TabIndex = 182;
            this.specialButton1.Text = "Discharge";
            this.specialButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton1.Click += new System.EventHandler(this.specialButton1_Click);
            // 
            // btnClose
            // 
            this.btnClose.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(484, 342);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedButton = false;
            this.btnClose.Size = new System.Drawing.Size(64, 25);
            this.btnClose.TabIndex = 181;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(18, 342);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 68;
            this.checkBox1.Text = "All Checked";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtremarks
            // 
            this.txtremarks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremarks.Location = new System.Drawing.Point(14, 306);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(536, 27);
            this.txtremarks.TabIndex = 60;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(12, 289);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(61, 13);
            this.label30.TabIndex = 59;
            this.label30.Text = "Remarks:";
            // 
            // txtpathology
            // 
            this.txtpathology.BackColor = System.Drawing.Color.White;
            this.txtpathology.Enabled = false;
            this.txtpathology.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpathology.Location = new System.Drawing.Point(159, 176);
            this.txtpathology.Name = "txtpathology";
            this.txtpathology.ReadOnly = true;
            this.txtpathology.Size = new System.Drawing.Size(121, 21);
            this.txtpathology.TabIndex = 49;
            this.txtpathology.Text = ".0";
            this.txtpathology.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmedicaineCharge
            // 
            this.txtmedicaineCharge.BackColor = System.Drawing.Color.White;
            this.txtmedicaineCharge.Enabled = false;
            this.txtmedicaineCharge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmedicaineCharge.Location = new System.Drawing.Point(159, 150);
            this.txtmedicaineCharge.Name = "txtmedicaineCharge";
            this.txtmedicaineCharge.ReadOnly = true;
            this.txtmedicaineCharge.Size = new System.Drawing.Size(121, 21);
            this.txtmedicaineCharge.TabIndex = 48;
            this.txtmedicaineCharge.Text = ".0";
            this.txtmedicaineCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBedCharge
            // 
            this.txtBedCharge.BackColor = System.Drawing.Color.White;
            this.txtBedCharge.Enabled = false;
            this.txtBedCharge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBedCharge.Location = new System.Drawing.Point(159, 123);
            this.txtBedCharge.Name = "txtBedCharge";
            this.txtBedCharge.ReadOnly = true;
            this.txtBedCharge.Size = new System.Drawing.Size(121, 21);
            this.txtBedCharge.TabIndex = 46;
            this.txtBedCharge.Text = ".0";
            this.txtBedCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBedCharge.TextChanged += new System.EventHandler(this.txtBedCharge_TextChanged);
            // 
            // txtdoctorcharge
            // 
            this.txtdoctorcharge.BackColor = System.Drawing.Color.White;
            this.txtdoctorcharge.Enabled = false;
            this.txtdoctorcharge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdoctorcharge.Location = new System.Drawing.Point(159, 97);
            this.txtdoctorcharge.Name = "txtdoctorcharge";
            this.txtdoctorcharge.ReadOnly = true;
            this.txtdoctorcharge.Size = new System.Drawing.Size(121, 21);
            this.txtdoctorcharge.TabIndex = 45;
            this.txtdoctorcharge.Text = ".0";
            this.txtdoctorcharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOTSerivce
            // 
            this.txtOTSerivce.BackColor = System.Drawing.Color.White;
            this.txtOTSerivce.Enabled = false;
            this.txtOTSerivce.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTSerivce.Location = new System.Drawing.Point(159, 203);
            this.txtOTSerivce.Name = "txtOTSerivce";
            this.txtOTSerivce.ReadOnly = true;
            this.txtOTSerivce.Size = new System.Drawing.Size(121, 21);
            this.txtOTSerivce.TabIndex = 44;
            this.txtOTSerivce.Text = ".0";
            this.txtOTSerivce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOTSerivce.TextChanged += new System.EventHandler(this.txtnursecharge_TextChanged);
            // 
            // txthospitalcharge
            // 
            this.txthospitalcharge.BackColor = System.Drawing.Color.White;
            this.txthospitalcharge.Enabled = false;
            this.txthospitalcharge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthospitalcharge.Location = new System.Drawing.Point(159, 71);
            this.txthospitalcharge.Name = "txthospitalcharge";
            this.txthospitalcharge.ReadOnly = true;
            this.txthospitalcharge.Size = new System.Drawing.Size(121, 21);
            this.txthospitalcharge.TabIndex = 43;
            this.txthospitalcharge.Text = ".0";
            this.txthospitalcharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(31, 176);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(118, 20);
            this.label24.TabIndex = 41;
            this.label24.Text = "Pathology Bill";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(31, 150);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 20);
            this.label22.TabIndex = 40;
            this.label22.Text = "Medicine Charge";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(31, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(118, 20);
            this.label20.TabIndex = 38;
            this.label20.Text = "Room/Bed Charge";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(31, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 20);
            this.label19.TabIndex = 37;
            this.label19.Text = "Consultent  Charge";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(31, 203);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 20);
            this.label18.TabIndex = 36;
            this.label18.Text = "OT Service Charge";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(31, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 20);
            this.label17.TabIndex = 35;
            this.label17.Text = "Hospital Charge";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtnoofdays
            // 
            this.txtnoofdays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnoofdays.Location = new System.Drawing.Point(438, 18);
            this.txtnoofdays.Name = "txtnoofdays";
            this.txtnoofdays.Size = new System.Drawing.Size(103, 21);
            this.txtnoofdays.TabIndex = 34;
            this.txtnoofdays.Text = "0";
            this.txtnoofdays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(292, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "No. of Days";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtdischargeTime
            // 
            this.txtdischargeTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdischargeTime.Location = new System.Drawing.Point(159, 43);
            this.txtdischargeTime.Name = "txtdischargeTime";
            this.txtdischargeTime.Size = new System.Drawing.Size(121, 21);
            this.txtdischargeTime.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(159, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Disch. Time";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtdischargedate
            // 
            this.txtdischargedate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdischargedate.Location = new System.Drawing.Point(10, 43);
            this.txtdischargedate.Name = "txtdischargedate";
            this.txtdischargedate.Size = new System.Drawing.Size(139, 21);
            this.txtdischargedate.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(10, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "Disch. Date";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Green;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(294, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Bill Date";
            // 
            // txtbill
            // 
            this.txtbill.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbill.Location = new System.Drawing.Point(428, 5);
            this.txtbill.Name = "txtbill";
            this.txtbill.Size = new System.Drawing.Size(111, 21);
            this.txtbill.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Green;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(294, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Bill No";
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lblReg);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.billDate);
            this.panel9.Controls.Add(this.lblPatientName);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Controls.Add(this.label11);
            this.panel9.Controls.Add(this.txtbill);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Location = new System.Drawing.Point(307, 19);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(547, 57);
            this.panel9.TabIndex = 257;
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Location = new System.Drawing.Point(97, 13);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(43, 13);
            this.lblReg.TabIndex = 31;
            this.lblReg.Text = "RegNo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Patient Reg :";
            // 
            // billDate
            // 
            this.billDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.billDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.billDate.Location = new System.Drawing.Point(428, 31);
            this.billDate.Name = "billDate";
            this.billDate.Size = new System.Drawing.Size(111, 21);
            this.billDate.TabIndex = 29;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(95, 33);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(39, 13);
            this.lblPatientName.TabIndex = 4;
            this.lblPatientName.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Patient Name :";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblPatientID);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Controls.Add(this.panel6);
            this.panelControl1.Controls.Add(this.panel9);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(873, 514);
            this.panelControl1.TabIndex = 258;
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Location = new System.Drawing.Point(309, 3);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(0, 13);
            this.lblPatientID.TabIndex = 258;
            this.lblPatientID.Visible = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 28);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(879, 542);
            this.xtraTabControl1.TabIndex = 259;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(873, 514);
            this.xtraTabPage1.Text = "Discharge Bill";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.groupBox3);
            this.xtraTabPage2.Controls.Add(this.panel4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(873, 514);
            this.xtraTabPage2.Text = "View Dicharge Bill";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridControl2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(873, 474);
            this.groupBox3.TabIndex = 256;
            this.groupBox3.TabStop = false;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(3, 17);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(867, 454);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.Click += new System.EventHandler(this.gridControl2_Click);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView2_MouseDown);
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PatientID";
            this.gridColumn1.FieldName = "OPID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 82;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "PatientName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 105;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bed / Cabin";
            this.gridColumn3.FieldName = "BedName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 105;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "BillNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 105;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Bill Date";
            this.gridColumn5.FieldName = "Date";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 105;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Bill Amount";
            this.gridColumn6.FieldName = "SubTotal";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 105;
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "AdvancePaid";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 105;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Net Payable";
            this.gridColumn8.FieldName = "NetPayble";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 117;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.simpleButton1);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.ToDate);
            this.panel4.Controls.Add(this.FromDate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(873, 40);
            this.panel4.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(287, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(77, 22);
            this.simpleButton1.TabIndex = 100114;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 100101;
            this.label9.Text = "From";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 100102;
            this.label10.Text = "To";
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "dd/MM/yyyy";
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(189, 9);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(90, 21);
            this.ToDate.TabIndex = 100103;
            // 
            // FromDate
            // 
            this.FromDate.CustomFormat = "dd/MM/yyyy";
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDate.Location = new System.Drawing.Point(66, 8);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(90, 21);
            this.FromDate.TabIndex = 100104;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // DischargeBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 570);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DischargeBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discharge IP";
            this.Load += new System.EventHandler(this.DischargeIP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txttaxpercent;
        private System.Windows.Forms.ComboBox cmbBillType;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtadvancePaid;
        private System.Windows.Forms.TextBox txtNetPayble;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtpathology;
        private System.Windows.Forms.TextBox txtmedicaineCharge;
        private System.Windows.Forms.TextBox txtBedCharge;
        private System.Windows.Forms.TextBox txtdoctorcharge;
        private System.Windows.Forms.TextBox txtOTSerivce;
        private System.Windows.Forms.TextBox txthospitalcharge;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtnoofdays;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtdischargeTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtdischargedate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtbill;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label3;
        private Office2007Button.SpecialButton specialButton1;
        private Office2007Button.SpecialButton btnClose;
        private Office2007Button.SpecialButton specialButton3;
        private Office2007Button.SpecialButton btnNew;
        private System.Windows.Forms.Label lblPatientName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.DateTimePicker billDate;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttotalBill;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblInward;
        private System.Windows.Forms.TextBox txtOTMedicine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtservicecharge;
        private System.Windows.Forms.TextBox txtPrcentService;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker FromDate;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.CheckBox ChkOTMC;
        private System.Windows.Forms.CheckBox ChkOTSC;
        private System.Windows.Forms.CheckBox chkPC;
        private System.Windows.Forms.CheckBox chkMC;
        private System.Windows.Forms.CheckBox chkBC;
        private System.Windows.Forms.CheckBox chkCC;
        private System.Windows.Forms.CheckBox chkHC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Label lblPatientID;

    }
}