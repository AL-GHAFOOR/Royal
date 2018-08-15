using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.Operation;
using GHospital_Care.Session;

namespace GHospital_Care.IndoorPatient
{
    public partial class IPBillingSetup : Form
    {
        SessionData _session = new SessionData();
        private string IpBillingStatus = "";
        public IPBillingSetup(string menuName)
        {
            InitializeComponent();
          //Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
            try
            {
                UserMaster master = GlobalPermission.UserPermission.FirstOrDefault(a => a.FormName == this.Name && a.Permission && a.MenuName == menuName);
                if (master != null)
                {
                    if (master.FormCaption == "IPD")
                    {
                        toggleSwitch1.IsOn = false;
                        IpBillingStatus = "IPD";
                        GetAllPatientSlNo("IPD");
                        lblHeadingName.Text = "RB Hospital Care  | Indoor Patient Billing";

                    }
                    else if (master.FormCaption == "OPD")
                    {
                        GetAllPatientSlNo("OPD");
                        IpBillingStatus = "OPD";
                        toggleSwitch1.IsOn = true;
                        lblHeadingName.Text = "RB Hospital Care  | Outdoor Patient Billing";

                    }
                    toggleSwitch1.Enabled = false;
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.GetBaseException().ToString());
                this.Activate();
            }
        // Control buttonControl = new ButtonPermissionAccess().TabControl(this.tabControl1, this.Name);
          //  tabControl1 = (TabControl)buttonControl;
            


        }
        
        private void specialButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        List<IPCosultDoctor> DIPCosultDoctor = new List<IPCosultDoctor>();
        private DataTable TempdataTable;

        private void GetAllPatientSlNo(string status)
        {
            if (status == "IPD")
            {
                DataTable slNo = new DataTable();
                slNo = new IpdManager().GetAllIpdPatientSl();
                cmbPid.DataSource = slNo;
                cmbPid.DisplayMember = "OPID";
                cmbPid.ValueMember = "OPID";
            }
           else
            {
                var slNo = new OPD_Manager().GetAllOpdPatienSlNo();
                cmbPid.DataSource = slNo;
                cmbPid.DisplayMember = "OPID";
                cmbPid.ValueMember = "OPID";
            }

        }

        private DataTable IssueDatatble;
        public void LoadDataTable()
        {
            try
            {
                ////LoadConsoultService(cmbPid.Text, toggleSwitch1.Properties.OnText);
                ////LoadPatientService(cmbPid.Text, toggleSwitch1.Properties.OnText);
                ////LoadPatientPathologyService(cmbPid.Text, toggleSwitch1.Properties.OnText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }
          

        }
        public DataTable LoadOperationService()
        {
            return new ServiceManager().GetPatientServiceBillOnly_OT();
        }
        DataTable dt = new DataTable();
        public void MedineList()
        {
            try
            {
                Service service = new Service();
                DataTable MedineList = new OPD_Manager().GetIssueMedineStock(); ;
                repositoryOtMedicine.DataSource = MedineList;
                repositoryOtMedicine.DisplayMember = "ProductId";
                repositoryOtMedicine.ValueMember = "ProductId";
                service.IssueDate = dtpOPmedicine.Value;
                service.OPID = cmbPid.Text;
                service.GodownId = "3";

                var list = new ServiceManager().GetOPMedicineListByPatientId(service);
                dt = new CustomLibry.CustomLibrary().ToDataTable(list);
                gridControlIssueMedine.DataSource = dt;
                Int64 MaxID = new ServiceGateway().GetOPMedMaxValue();
                griViewIssueMedine.SetRowCellValue(griViewIssueMedine.RowCount - 1, "VoucherNo", MaxID);
            }
            catch (Exception)
            {


            }
        }
        public void PatientService()
        {
            DataTable AllDoctor = new ServiceManager().GetPatientService("Hospital");
            repositoryItemLookUpEdit2.DataSource = AllDoctor;
            repositoryItemLookUpEdit2.DisplayMember = "ServiceName";
            repositoryItemLookUpEdit2.ValueMember = "ServiceName";

        }
        public void PathologyService()
        {
            DataTable AllDoctor = new ServiceManager().GetPatientService("Pathology");
            repositoryItemLookUpEdit4.DataSource = AllDoctor;
            repositoryItemLookUpEdit4.DisplayMember = "ServiceName";
            repositoryItemLookUpEdit4.ValueMember = "ServiceName";

        }
        public void PathologyMaster()
        {
            DataTable PMaster = new ServiceManager().GetPathologyMaster();
            repositoryItemLookUpEdit6.DataSource = PMaster;
            repositoryItemLookUpEdit6.DisplayMember = "Alias";
            repositoryItemLookUpEdit6.ValueMember = "Alias";

        }

        public void LoadOtMedicineList()
        {
            IssueDatatble = new DataTable();
            IssueDatatble.Columns.Add("ProductId");
            IssueDatatble.Columns.Add("ProductName");
            IssueDatatble.Columns.Add("Rate");
            IssueDatatble.Columns.Add("Qty", typeof(int));
            IssueDatatble.Columns.Add("ServiceTotal", typeof(double));
            IssueDatatble.Columns.Add("ID", typeof(int));

            gridControlIssueMedine.DataSource = IssueDatatble;
            DataRow IssueDatatbleRow = IssueDatatble.NewRow();
            IssueDatatble.Rows.Add(IssueDatatbleRow);

            //........................................................................................................
        }

        DataTable patientDataTable = new DataTable();

        public void ClearAllEvent()
        {
            tabControl1.TabPages.Remove(IssueMedicine);
        }
        private void IPBillingSetup_Load(object sender, EventArgs e)
        {
            try
            {
                ClearAllEvent();
                CosulultDoctor();
                PathologyMaster();
                PatientService();
                PathologyService();
               
                //LoadDataTable();
                 MedineList();
                if (toggleSwitch1.IsOn)
                {
                    GetAllPatientSlNo(toggleSwitch1.Properties.OnText);
                    tabControl1.TabPages.Add(IssueMedicine);
                    LoadConsoultService(cmbPid.Text, "OPD");
                    LoadPatientService(cmbPid.Text, "OPD");
                    LoadPatientPathologyService(cmbPid.Text, "OPD");
                   // MedineList();
                }
                else
                {
                    GetAllPatientSlNo(toggleSwitch1.Properties.OffText);
                    tabControl1.TabPages.Remove(IssueMedicine);
                    LoadConsoultService(cmbPid.Text, "IPD");
                    LoadPatientService(cmbPid.Text, "IPD");
                    LoadPatientPathologyService(cmbPid.Text, "IPD");
                }
               //GetAllPatientSlNo(toggleSwitch1.Properties.OffText);
                
               
                Patient_buttonEnable(true);
                //-----for patientService---
                _session.ChkPermission(MainWindow.userName);
                if (_session.SavePermission == false)
                {
                    Patient_buttonEnable(true);
                    Consult_buttonEnable(true);
                    IssueMedcine_buttonEnable(true);
                    Pathology_buttonEnable(true);
                    btnSavePSBill.Enabled = false;
                    btnConsultBill.Enabled = false;
                    btnSaveIssueMedicine.Enabled = false;
                    btnSavePathology.Enabled = false;
                }
                else
                {
                    Patient_buttonEnable(true);
                    Consult_buttonEnable(true);
                    IssueMedcine_buttonEnable(true);
                    Pathology_buttonEnable(true);
                }
                //chkPermission();
            }
            catch (Exception ex)
            {
                
               
                MessageBox.Show(ex.GetBaseException().ToString());
                this.Activate();
            }
          
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "ConQty")
                {
                    var qty = gridView.GetRowCellValue(e.RowHandle, "ConQty");
                    double confee = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, "ConFee"));

                    double totalFee = Convert.ToInt16(qty) * confee;
                    gridView.SetRowCellValue(e.RowHandle, "TotalConsFee", totalFee);
                }
                else if (e.Column.FieldName == "ConFee")
                {
                    double confee = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, "ConFee"));
                    Int16 qty = Convert.ToInt16(gridView.GetRowCellValue(e.RowHandle, "ConQty"));
                    double totalFee = Convert.ToInt16(qty) * confee;
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, "TotalConsFee", totalFee);

                }
            }
            catch (Exception)
            {


            }

        }

        public void Cellvaluechnaged(string value)
        {
            try
            {
                var docId = new MedicalManager().GetAllCosultDoctor(value.ToString());
                string doc = docId.Rows[0]["DoctorID"].ToString();
                var Degree = docId.Rows[0]["AcademicDegree"].ToString();
                //  var Total = docId.Rows[0]["TotalConsFee"];
                gridView.SetFocusedRowCellValue("ConsultId", doc);
                gridView.SetFocusedRowCellValue("DoctorName", docId.Rows[0]["DoctorName"].ToString());
                gridView.SetFocusedRowCellValue("Degree", Degree.ToString());
                gridView.SetFocusedRowCellValue("Specialization", docId.Rows[0]["Specialization"].ToString());
                gridView.SetFocusedRowCellValue("ConsultBillDate", dtpConsultBill.Value);
                gridView.SetFocusedRowCellValue("ConFee", Convert.ToDouble("0.00"));
                gridView.SetFocusedRowCellValue("ConQty", "1");
                gridView.SetFocusedRowCellValue("TotalConsFee", Convert.ToDouble("0.00"));

            }
            catch (Exception)
            {
                
               // throw;
            }
        
        }
        public void CellvaluechnagedForPService(string value)
        {
            try
            {
                DataRow service = new ServiceManager().GetPatientServiceBillWithoutOT().AsEnumerable().FirstOrDefault(a => a["ServiceName"].ToString() == value);

                var serviceName = service["ServiceName"].ToString();
                var Description = service["Description"].ToString();
                var Rate = service["Rate"].ToString();var Id = service["ServiceId"].ToString();
                gridViewServiceBill.SetFocusedRowCellValue("ServiceName", serviceName);
                gridViewServiceBill.SetFocusedRowCellValue("Description", Description);
                gridViewServiceBill.SetFocusedRowCellValue("PsRate", Rate);
                gridViewServiceBill.SetFocusedRowCellValue("PsSubTotal", 1 * Convert.ToDouble(Rate));
                gridViewServiceBill.SetFocusedRowCellValue("PSQty", 1);
                gridViewServiceBill.SetFocusedRowCellValue("ServiceId", Id);
                gridViewServiceBill.SetFocusedRowCellValue("serviceDate", dtpPatientService.Value);
            }
            catch (Exception)
            {

            }

        }


        public void CellvaluechnagedForPath_Service(string value)
        {
            try
            {
                DataRow service = new ServiceManager().GetPatientServiceBillWithoutOT().AsEnumerable().FirstOrDefault(a => a["ServiceName"].ToString() == value);

                var serviceName = service["ServiceName"].ToString();
                var Description = service["Description"].ToString();
                var Rate = service["Rate"].ToString();
                var Id = service["ServiceId"].ToString();
                gridView1.SetFocusedRowCellValue("ServiceName", serviceName);
                gridView1.SetFocusedRowCellValue("Description", Description);
                gridView1.SetFocusedRowCellValue("PsRate", Rate);
                gridView1.SetFocusedRowCellValue("PsSubTotal", 1 * Convert.ToDouble(Rate));
                gridView1.SetFocusedRowCellValue("PSQty", 1);
                gridView1.SetFocusedRowCellValue("ServiceId", Id);
                gridView1.SetFocusedRowCellValue("serviceDate", dtpPathologyDate.Value);
            }
            catch (Exception)
            {

            }

        }
        public void CellvaluechnagedForIssueMedicine(string value)
        {
            DataRow service = new OPD_Manager().GetIssueMedineStock().AsEnumerable().FirstOrDefault(a => a["ProductId"].ToString() == value);

            var productId = service["ProductId"].ToString();
            var productName = service["ProductName"].ToString();
            var Rate = service["Rate"].ToString();
            
            griViewIssueMedine.SetFocusedRowCellValue("ProductId", productId);
            griViewIssueMedine.SetFocusedRowCellValue("ProductName", productName);
            griViewIssueMedine.SetFocusedRowCellValue("Rate", Rate);
            griViewIssueMedine.SetFocusedRowCellValue("ServiceTotal", 1 * Convert.ToDouble(Rate));
            griViewIssueMedine.SetFocusedRowCellValue("Qty", 1);
            
        }

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LookUpEdit edit = gridView.ActiveEditor as LookUpEdit;
                if (edit != null)
                {
                    object value = edit.Text;
                    Cellvaluechnaged(value.ToString());
                    DataRow row = ConsultService.NewRow();

                    int rowIndex = gridView.GetFocusedDataSourceRowIndex();

                    if (rowIndex == gridView.RowCount - 1)
                    {
                        var docName = gridView.GetRowCellValue(gridView.RowCount - 1, "DoctorName");
                        gridView.SetFocusedRowCellValue("ConsultBillDate", dtpConsultBill.Value);
                        if (docName.ToString() != string.Empty)
                        {
                            Int64 vch = Convert.ToInt64(gridView.GetRowCellValue(gridView.RowCount - 1, "VchNo"));
                            gridView.SetRowCellValue(gridView.RowCount - 1, "VchNo", vch);
                            ConsultService.Rows.Add(row);
                            gridView.SetRowCellValue(gridView.RowCount - 1, "VchNo", vch + 1);

                           
                        }
                    }

               }
            }
            catch (Exception)
            {
                
             //   throw;
            }
           

        }

        public void LoadOtSetupByPId(string pid)
        {
            OtSetup otSetup = new OT_Manager().GetOtSetupByPatientId(pid);

            txtOtReffNo.Text = otSetup.OtReffNo;
            txtCabinName.Text = otSetup.Cabin_Bed;
            txtOTdate.Text = otSetup.Date.ToString("d");
            txtSurgenName.Text = otSetup.SurgenId;
            txtFistAsst.Text = otSetup.FirstAsst;
            txtSecondAsst.Text = otSetup.SecondAsst;
            txtAnestheisLogist.Text = otSetup.Anstology;
            txtOpName.Text = otSetup.OpName;
            otFrom.Text = otSetup.OT_To.ToString("g");
            txtOtTo.Text = otSetup.OT_From.ToString("g");
        }

        public void LoadDataForIPD(string pslNo)
        {
            Patient patient = new Patient();
            if (toggleSwitch1.IsOn)
            {
                patient = new OPD_Manager().GetPatientInformationBySl(pslNo);
            }
            else
            {
                patient = new IpdManager().GetPatientInformationBySl(pslNo);
            }


            txtName.Text = patient.PatientName;
            txtFatherName.Text = patient.FatherName;
            txtMotherName.Text = patient.MotherName;
            txtAddress.Text = patient.Address;
            txtAge.Text = patient.Age;
            txtPhone.Text = patient.Phone;
            txtMobile.Text = patient.Mobile;
            txtGuirdian.Text = patient.Gurdian;
            txtRelation.Text = patient.Relation;
            txtGender.Text = patient.Gender;
            txtBloodGroup.Text = patient.BloodGroup;
            txtReligion.Text = patient.Religion;
            txtCabinBed.Text = patient.SelectedBed;
        }
        private void cmbPid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectId = cmbPid.Text;
                LoadDataForIPD(selectId);
                LoadOtSetupByPId(selectId);
                if (IpBillingStatus== "OPD")
                {
                    //LoadOtSetupByPId(cmbPid.Text);
                    LoadConsoultService(cmbPid.Text, toggleSwitch1.Properties.OnText);
                    LoadPatientService(cmbPid.Text, toggleSwitch1.Properties.OnText);
                    LoadPatientPathologyService(cmbPid.Text, toggleSwitch1.Properties.OnText);

                }
                else if (IpBillingStatus == "IPD")
                {
                    //Consult---
                    LoadDataForIPD(cmbPid.Text);
                    LoadConsoultService(selectId, toggleSwitch1.Properties.OffText);
                    LoadPatientService(selectId, toggleSwitch1.Properties.OffText);
                    LoadPatientPathologyService(cmbPid.Text, toggleSwitch1.Properties.OffText);


                }
            }
            catch (Exception)
            {

                // throw;
            }

        }

        //Consult-------
        private void CosulultDoctor()
        {
            DataTable AllDoctor = new MedicalManager().GetAllCosultDoctor(null);
            repositoryItemLookUpEdit1.DataSource = AllDoctor;
            repositoryItemLookUpEdit1.DisplayMember = "DoctorID";
            repositoryItemLookUpEdit1.ValueMember = "DoctorID";


        }

        //Consult---------
        private DataTable ConsultService;
        private DataTable Patientservice;
        public void LoadConsoultService(string patientId, string status)
        {
            try
            {
                ConsultService = new DataTable();
                Int64 MaxID = new ServiceGateway().GetOtMaxValueConsultSrvc();
                patientId = cmbPid.Text;
                ConsultService = new ServiceManager().GetConsultServiceBill(patientId, status, "Consult", dtpConsultBill.Value);
                if (ConsultService != null && ConsultService.Rows.Count > 0)
                {
                    gridControl.DataSource = ConsultService;
                  // ConsultService.Rows.Add();
                }
                else
                {
                    DataRow row = ConsultService.NewRow();
                    ConsultService.Rows.Add(row);
                    gridControl.DataSource = ConsultService;
                }
                gridView.SetRowCellValue(gridView.RowCount - 1, "VchNo", MaxID);
                gridView.SetRowCellValue(gridView.RowCount - 1, "TotalConsFee", Convert.ToDouble("0.00"));
                //gridView.SetRowCellValue(gridView.RowCount - 1, "TotalConsFee", "0.00");
            }
            catch (Exception)
            {
                
            }

        }

        public void LoadPatientService(string patientId, string status)
        {
            try
            {
                Patientservice = new DataTable();
                Int64 MaxID = new ServiceGateway().GetPateintServiceMaxValue();
                patientId = cmbPid.Text;
                Patientservice = new ServiceManager().GetPatientServiceBill(patientId, status, "Hospital", dtpPatientService.Value);
                if (Patientservice.Rows.Count > 0)
                {
                  
                    gridControlPSBill.DataSource = Patientservice;
                    
                }
                else
                {
                    DataRow row = Patientservice.NewRow();
                    Patientservice.Rows.Add(row);
                    Patientservice.Rows[0]["OPID"] = "NA";
                    gridControlPSBill.DataSource = Patientservice;
                }
                gridViewServiceBill.SetRowCellValue(gridViewServiceBill.RowCount - 1, "VchNo", MaxID);
            }
            catch (Exception)
            {

            }
        }

        private void btnConsultBill_Click(object sender, EventArgs e)
        {
            List<Patient> ListOfConsultBilling = new List<Patient>();
            Service aService = new Service();
            aService.AConsultBill = new ServiceManager().GetConsultBillServicesByPatientId(cmbPid.Text, IpBillingStatus, "Consult", dtpConsultBill.Value);
           for (int i = 0; i < gridView.RowCount - 1; i++)
            {
                Patient consultBillService = new Patient();
                consultBillService.ConsultBillServices = new ConsultBillService();
                consultBillService.OPID = cmbPid.Text;
                consultBillService.ConsultBillServices.ConsultId = gridView.GetRowCellValue(i, "ConsultId").ToString();
                consultBillService.ConsultBillServices.ConsultBillDate = gridView.GetRowCellValue(i, "ConsultBillDate").ToString();
                consultBillService.ConsultBillServices.ConQty = Convert.ToInt32(gridView.GetRowCellValue(i, "ConQty").ToString());
                consultBillService.ConsultBillServices.ConFee = Convert.ToDouble(gridView.GetRowCellValue(i, "ConFee").ToString());
                consultBillService.ConsultBillServices.VchNo = Convert.ToInt64(gridView.GetRowCellValue(i, "VchNo").ToString());
                ListOfConsultBilling.Add(consultBillService);
            }
            MessageModel message = new IpdManager().SaveCosultBilling(ListOfConsultBilling, aService);
            MessageBox.Show(message.MessageTitle, message.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public List<OT_Consump> ListOfConsumeList = new List<OT_Consump>();
        public List<Service> ListOfPatientService = new List<Service>();
        public List<Service> ListOfPathologyService = new List<Service>();
        private void repositoryItemComboBox2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void repositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = gridViewServiceBill.ActiveEditor as LookUpEdit;
            if (edit != null)
            {
                object value = edit.Text;
                CellvaluechnagedForPService(value.ToString());
                DataRow row = Patientservice.NewRow();
                int rowIndex = gridViewServiceBill.RowCount - 1;
                string docName = gridViewServiceBill.GetRowCellValue(gridViewServiceBill.RowCount - 1, "ServiceName").ToString();

                if (rowIndex == gridViewServiceBill.RowCount - 1)
                {
                    if (docName != string.Empty)
                    {
                        Int64 vch = Convert.ToInt64(gridViewServiceBill.GetRowCellValue(gridViewServiceBill.RowCount - 1, "VchNo"));
                        gridViewServiceBill.SetRowCellValue(gridViewServiceBill.RowCount - 1, "VchNo", vch);
                        Patientservice.Rows.Add(row);
                        gridViewServiceBill.SetRowCellValue(gridViewServiceBill.RowCount - 1, "VchNo", vch + 1);

                    }
                    // Patientservice.Rows.Add(row);
                }

            }
        }

        private void gridViewServiceBill_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "PSQty")
                {
                    decimal total = 0;
                    decimal Rate = Convert.ToDecimal(gridViewServiceBill.GetRowCellValue(e.RowHandle, "PsRate"));
                    decimal qty = Convert.ToDecimal(gridViewServiceBill.GetRowCellValue(e.RowHandle, "PSQty"));
                    total = Rate * qty;
                    gridViewServiceBill.SetRowCellValue(e.RowHandle, "PsSubTotal", total.ToString("0.00"));
                }
                if (e.Column.FieldName == "PsRate")
                {
                    decimal total = 0;
                    decimal Rate = Convert.ToDecimal(gridViewServiceBill.GetRowCellValue(e.RowHandle, "PsRate"));
                    decimal qty = Convert.ToDecimal(gridViewServiceBill.GetRowCellValue(e.RowHandle, "PSQty"));
                    total = Rate * qty;
                    gridViewServiceBill.SetRowCellValue(e.RowHandle, "PsSubTotal", total.ToString("0.00"));
                }
            }
            catch (Exception)
            {

            }
        }

        public List<Service> GetAllService()
        {
            ListOfPatientService.Clear();
            for (int i = 0; i < gridViewServiceBill.RowCount - 1; i++)
            {
                Service newService = new Service();
                newService.ServiceId = Convert.ToString(gridViewServiceBill.GetRowCellValue(i, "ServiceId"));
                newService.Rate = Convert.ToDouble(gridViewServiceBill.GetRowCellValue(i, "PsRate"));
                newService.Qty = Convert.ToInt16(gridViewServiceBill.GetRowCellValue(i, "PSQty"));
                newService.Total = Convert.ToDouble(gridViewServiceBill.GetRowCellValue(i, "PsSubTotal"));
                newService.IssueDate = Convert.ToDateTime(gridViewServiceBill.GetRowCellValue(i, "serviceDate")).Date;
                newService.VoucherNo = Convert.ToInt64(gridViewServiceBill.GetRowCellValue(i, "VchNo"));
                ListOfPatientService.Add(newService);
            }
            return ListOfPatientService;
        }


        public List<Service> GetPathologyService()
        {
            ListOfPathologyService.Clear();
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                Service newService = new Service();
                newService.ServiceId = Convert.ToString(gridView1.GetRowCellValue(i, "ServiceId"));
                newService.Rate = Convert.ToDouble(gridView1.GetRowCellValue(i, "PsRate"));
                newService.Qty = Convert.ToInt16(gridView1.GetRowCellValue(i, "PSQty"));
                newService.Total = Convert.ToDouble(gridView1.GetRowCellValue(i, "PsSubTotal"));
                newService.IssueDate = Convert.ToDateTime(gridView1.GetRowCellValue(i, "serviceDate")).Date;
                newService.VoucherNo = Convert.ToInt64(gridView1.GetRowCellValue(i, "VchNo"));
                newService.PathID = gridView1.GetRowCellValue(i, "PathID").ToString();
                ListOfPathologyService.Add(newService);
            }
            return ListOfPathologyService;
        }
        private void btnSavePSBill_Click(object sender, EventArgs e)
        {
            Service saveService = new Service();
            saveService.GetPatientServices = new ServiceManager().GetPatientServiceByPatientId(cmbPid.Text, IpBillingStatus, "", dtpConsultBill.Value);
            saveService.OPID = cmbPid.Text;
            saveService.PatientService = GetAllService();
            MessageModel message = new ServiceManager().SavePatientService(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
           // LoadDataTable();
            //if (toggleSwitch1.IsOn)
            //{
            //    GetAllPatientSlNo(toggleSwitch1.Properties.OnText);
            //    tabControl1.TabPages.Add(IssueMedicine);
            //    LoadConsoultService(cmbPid.Text, "OPD");
            //    LoadPatientService(cmbPid.Text, "OPD");
            //    LoadPatientPathologyService(cmbPid.Text, "OPD");
            //    MedineList();
            //}
            //else
            //{
            //    GetAllPatientSlNo(toggleSwitch1.Properties.OffText);
            //    tabControl1.TabPages.Remove(IssueMedicine);
            //    LoadConsoultService(cmbPid.Text, "IPD");
            //    LoadPatientService(cmbPid.Text, "IPD");
            //    LoadPatientPathologyService(cmbPid.Text, "IPD");
            //}

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void repositoryItemLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = griViewIssueMedine.ActiveEditor as LookUpEdit;
            if (edit != null)
            {
                object value = edit.GetColumnValue("ProductId");
                CellvaluechnagedForIssueMedicine(value.ToString());

                string issueMedine = griViewIssueMedine.GetRowCellValue(griViewIssueMedine.RowCount - 1, "ProductId").ToString();
                if (issueMedine != string.Empty)
                {
                    DataRow row = IssueDatatble.NewRow();
                    IssueDatatble.Rows.Add(row);

                }

            }
        }
        private void gridControlIssueMedine_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            var uniqkey = griViewIssueMedine.GetFocusedRowCellValue("VoucherNo");
            var opid = cmbPid.Text;
            int deleterow = new IpdGateway().DeleteServiceByCategory("Medicine", opid, uniqkey.ToString());


            griViewIssueMedine.DeleteRow(griViewIssueMedine.GetFocusedDataSourceRowIndex());
        }
        


        public List<IssueMedine> AddProductMedinine()
        {
            List<IssueMedine> List = new List<IssueMedine>();

            for (int rowHandle = 0; rowHandle < griViewIssueMedine.RowCount - 1; rowHandle++)
            {
                var ProductId = griViewIssueMedine.GetRowCellValue(rowHandle, "ProductId");
                var ProductName = griViewIssueMedine.GetRowCellValue(rowHandle, "ProductName");
                var Rate = griViewIssueMedine.GetRowCellValue(rowHandle, "Rate");
                var Qty = griViewIssueMedine.GetRowCellValue(rowHandle, "Qty");
                // var VOUCHERNo = griViewIssueMedine.GetRowCellValue(rowHandle, "Id");
                var batchId = griViewIssueMedine.GetRowCellValue(rowHandle, "batchId");
                var IsueDate = griViewIssueMedine.GetRowCellValue(rowHandle, "date");
                var VouherNo = griViewIssueMedine.GetRowCellValue(rowHandle, "VoucherNo");
                var PatientID = cmbPid.Text;

                //if (VOUCHERNo == DBNull.Value)
                //{
                //    VOUCHERNo = 0;
                //}
                if (VouherNo == DBNull.Value)
                {
                    VouherNo = 0;
                }
                if (ProductId != DBNull.Value && Qty != DBNull.Value && Rate != DBNull.Value)
                {
                    List.Add(new IssueMedine() { ProductId = ProductId.ToString(), ProductName = ProductName.ToString(), Rate = Convert.ToDecimal(Rate), Qty = Convert.ToInt16(Qty), batchId = batchId.ToString(), date = Convert.ToDateTime(IsueDate).Date, VoucherNo = (long)VouherNo, OPID = PatientID });
                }

            }
            return List;
        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SaveIssueMedicine();
        }

        private void SaveIssueMedicine()
        {
            IssueMedine OTmedine = new IssueMedine();
            Service aService = new Service();
            aService.IssueMedines = AddProductMedinine();
            aService.OPID = cmbPid.Text;
            OTmedine.date = dtpOPmedicine.Value;
            OTmedine.MedineList = IssueDatatble;

            MessageModel message = new OPD_Manager().SaveOtIssueMedine(aService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void windowsUIButtonPanel2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOtReffNo.Text != string.Empty)
                {
                    O_TServiceMedicine oTServiceMedicine = new O_TServiceMedicine(this);
                    oTServiceMedicine.ShowDialog();

                }
            }
            catch (Exception)
            {
            }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (txtOtReffNo.Text != String.Empty)
            {
                OperationServiceBill oTServiceMedicine = new OperationServiceBill(this);
                oTServiceMedicine.ShowDialog();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                LoadConsoultService(cmbPid.Text, "OPD");
            }
            else
            {
                LoadConsoultService(cmbPid.Text, "IPD");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                LoadPatientService(cmbPid.Text, "OPD");
            }
            else
            {
                LoadPatientService(cmbPid.Text, "IPD");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            MedineList();
        }

        private void repositoryItemLookUpEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            //LoadPatientService(cmbPid.Text, "IPD");
        }

        private void repositoryOtMedicine_EditValueChanged(object sender, EventArgs e)
        {
            bool flag = false;
            SearchLookUpEdit edit = sender as SearchLookUpEdit;
            var productId = edit.Properties.View.GetFocusedRowCellValue("ProductId");
            var BatchID = edit.Properties.View.GetFocusedRowCellValue("batchId");
            var row = (DataTable)gridControlIssueMedine.DataSource;
            int rowIndex = griViewIssueMedine.GetFocusedDataSourceRowIndex();

            if (rowIndex == griViewIssueMedine.RowCount - 1)
            {
                if (row.AsEnumerable().Count(a => (a["ProductId"].ToString() == productId.ToString() && a["batchId"].ToString() == BatchID.ToString())) > 0)
                {
                    Int64 vch = (long)griViewIssueMedine.GetRowCellValue(griViewIssueMedine.RowCount - 1, "VoucherNo");
                    dt.Rows.RemoveAt(griViewIssueMedine.GetFocusedDataSourceRowIndex());
                    dt.Rows.Add();
                    griViewIssueMedine.SetRowCellValue(griViewIssueMedine.RowCount - 1, "VoucherNo", vch);
                    flag = true;
                    return;
                }
            }
            else
            {
                for (int i = 0; i < griViewIssueMedine.RowCount; i++)
                {
                    var PID = griViewIssueMedine.GetRowCellValue(i, "ProductId").ToString();
                    var Batch = griViewIssueMedine.GetRowCellValue(i, "batchId").ToString();
                    if (productId.ToString() == PID && BatchID.ToString() == Batch)
                    {
                        productId = griViewIssueMedine.GetRowCellValue(griViewIssueMedine.FocusedRowHandle, "ProductId").ToString();
                        griViewIssueMedine.SetFocusedRowCellValue("ProductId", productId);
                        return;
                    }
                }
            }

            Int64 MaxID = new ServiceGateway().GetOPMedMaxValue();
            var qty = edit.Properties.View.GetFocusedRowCellValue("Qty");
            var rate = edit.Properties.View.GetFocusedRowCellValue("Rate");
            var name = edit.Properties.View.GetFocusedRowCellValue("ProductName");
            var batchId = edit.Properties.View.GetFocusedRowCellValue("batchId");
            var batchName = edit.Properties.View.GetFocusedRowCellValue("batchName");
            var ExpDate = edit.Properties.View.GetFocusedRowCellValue("expd");
            decimal total = Convert.ToDecimal(qty) * Convert.ToDecimal(rate);
            griViewIssueMedine.SetFocusedRowCellValue("Qty", Convert.ToInt16(qty ?? 1));
            griViewIssueMedine.SetFocusedRowCellValue("Rate", rate);
            griViewIssueMedine.SetFocusedRowCellValue("ProductName", name);
            griViewIssueMedine.SetFocusedRowCellValue("ProductId", productId);
            griViewIssueMedine.SetFocusedRowCellValue("batchId", batchId);
            griViewIssueMedine.SetFocusedRowCellValue("ServiceTotal", total.ToString("0.00"));
            griViewIssueMedine.SetFocusedRowCellValue("BatchName", batchName);
            griViewIssueMedine.SetFocusedRowCellValue("expd", ExpDate);

            if (flag == false)
            {
                for (int i = 0; i < griViewIssueMedine.RowCount; i++)
                {
                    if (rowIndex == griViewIssueMedine.RowCount - 1)
                    {
                        griViewIssueMedine.SetFocusedRowCellValue("date", dtpOPmedicine.Value);
                        Int64 vch = (long)griViewIssueMedine.GetRowCellValue(griViewIssueMedine.RowCount - 1, "VoucherNo");
                        griViewIssueMedine.SetRowCellValue(griViewIssueMedine.RowCount - 1, "VoucherNo", vch);
                        dt.Rows.Add();
                        griViewIssueMedine.SetRowCellValue(griViewIssueMedine.RowCount - 1, "VoucherNo", vch + 1);
                    }
                    return;
                }
            }

            //string vchNo = MaxID.ToString();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                LoadPatientPathologyService(cmbPid.Text, "OPD");
            }
            else
            {
                LoadPatientPathologyService(cmbPid.Text, "IPD");
            }
        }
        private DataTable Pathology;
        public void LoadPatientPathologyService(string patientId, string status)
        {
            try
            {
                Pathology = new DataTable();
                Int64 MaxID = new ServiceGateway().GetPateintServiceMaxValue();
                patientId = cmbPid.Text;
                Pathology = new ServiceManager().GetPatientServicePathology(patientId, status, "Pathology", dtpPathologyDate.Value);
                if (Pathology.Rows.Count > 0)
                {
                    gridControlPathology.DataSource = Pathology;
                }
                else
                {
                    DataRow row = Pathology.NewRow();
                    Pathology.Rows.Add(row);
                    Pathology.Rows[0]["OPID"] = "NA";
                    gridControlPathology.DataSource = Pathology;
                }
                gridView1.SetRowCellValue(gridView1.RowCount - 1, "VchNo", MaxID);
            }
            catch (Exception)
            {

            }
        }

        private void repositoryItemLookUpEdit4_EditValueChanged(object sender, EventArgs e)
        {
            
            LookUpEdit edit = gridView1.ActiveEditor as LookUpEdit;
            if (edit != null)
            {
                object value = edit.Text;
                CellvaluechnagedForPath_Service(value.ToString());
                DataRow row = Pathology.NewRow();

                int rowIndex = gridView1.GetFocusedDataSourceRowIndex();
                string docName = gridView1.GetRowCellValue(gridView1.RowCount - 1, "ServiceName").ToString();

                if (rowIndex == gridView1.RowCount - 1)
                {
                    if (docName != string.Empty)
                    {
                        try
                        {
                            Int64 vch = Convert.ToInt64(gridView1.GetRowCellValue(gridView1.RowCount - 1, "VchNo"));
                            gridView1.SetRowCellValue(gridView1.RowCount - 1, "VchNo", vch);
                            Pathology.Rows.Add(row);
                            gridView1.SetRowCellValue(gridView1.RowCount - 1, "VchNo", vch + 1);
                        }
                        catch (Exception)
                        {
                            
                           // throw;
                        }
                        

                    }
                    // Patientservice.Rows.Add(row);
                }

            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Service saveService = new Service();
            saveService.GetPathologyServices = new ServiceManager().GetPathologyServiceByPatientId(cmbPid.Text, IpBillingStatus, "", dtpConsultBill.Value);
            saveService.OPID = cmbPid.Text;
            saveService.Path_Service = GetPathologyService();
            MessageModel message = new ServiceManager().SavePathologyService(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void griViewIssueMedine_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Qty" || e.Column.FieldName == "Rate")
                {
                    var qty = griViewIssueMedine.GetRowCellValue(griViewIssueMedine.FocusedRowHandle  ,"Qty");
                    var Rate = griViewIssueMedine.GetRowCellValue(griViewIssueMedine.FocusedRowHandle, "Rate");
                    Decimal Total = Convert.ToDecimal(qty)*Convert.ToDecimal(Rate);
                    griViewIssueMedine.SetRowCellValue(griViewIssueMedine.FocusedRowHandle, "ServiceTotal", Total.ToString("0.00"));
                }
            }catch (Exception)
            {
                
                //throw;
            }
        }

        private void repositoryItemHyperLinkEdit3_Click(object sender, EventArgs e)
        {
            var uniqkey = gridViewServiceBill.GetFocusedRowCellValue("Id");
            var opid = cmbPid.Text;
            int deleterow = new IpdGateway().DeleteServiceByCategory("PService", opid, uniqkey.ToString());

            gridViewServiceBill.DeleteRow(gridViewServiceBill.GetFocusedDataSourceRowIndex());
        }


        private void Patient_buttonEnable(bool stat)
        {
            btnSavePSBill.Enabled = stat;
            btnPatientEdit.Enabled = !stat;
          //  gridViewServiceBill.Columns["Remove"].Visible = !stat;

        }

        private void repositoryItemHyperLinkEdit4_Click(object sender, EventArgs e)
        {
            var uniqkey = gridView.GetFocusedRowCellValue("Id");
            var opid = cmbPid.Text;
            int deleterow = new IpdGateway().DeleteServiceByCategory("Consult", opid, uniqkey.ToString());

            gridView.DeleteRow(gridView.GetFocusedDataSourceRowIndex());
        }


        private void Consult_buttonEnable(bool stat)
        {
            btnConsultBill.Enabled = stat;
            btnConsultEdit.Enabled = !stat;
           // gridView.Columns["Remove"].Visible = !stat;

        }


        private void IssueMedcine_buttonEnable(bool stat)
        {
            btnSaveIssueMedicine.Enabled = stat;
            btnMedicineEdit.Enabled = !stat;
         //   griViewIssueMedine.Columns["Remove"].Visible = !stat;

        }

        private void repositoryItemHyperLinkEdit5_Click(object sender, EventArgs e)
        {
            var uniqkey = gridView1.GetFocusedRowCellValue("VchNo");
            var opid = cmbPid.Text;
            int deleterow = new IpdGateway().DeleteServiceByCategory("Pathology", opid, uniqkey.ToString());
            gridView1.DeleteRow(gridView1.GetFocusedDataSourceRowIndex());

        }
        private void Pathology_buttonEnable(bool stat)
        {
            btnSavePathology.Enabled = stat;
            btnPathologyEdit.Enabled = !stat;
          //  gridView1.Columns["Remove"].Visible = !stat;

        }

        private void chkPermission()
        {
            _session.ChkPermission(MainWindow.userName);
            if (_session.SavePermission == true && _session.EditPermission == true && _session.DeletePermission == true)
            {
                Patient_buttonEnable(false);
                Consult_buttonEnable(false);
                IssueMedcine_buttonEnable(false);
                Pathology_buttonEnable(false);
                btnSavePSBill.Enabled = true;
                btnSavePathology.Enabled = true;
                btnSaveIssueMedicine.Enabled = true;
                btnConsultBill.Enabled = true;
            }
            else
            {
                if (_session.SavePermission == true && _session.EditPermission == false &&
                    _session.DeletePermission == false)
                {
                    Patient_buttonEnable(true);
                    Consult_buttonEnable(true);
                    IssueMedcine_buttonEnable(true);
                    Pathology_buttonEnable(true);
                }
                if (_session.SavePermission == true && _session.EditPermission == true &&
                    _session.DeletePermission == false)
                {
                    Patient_buttonEnable(true);
                    Consult_buttonEnable(true);
                    IssueMedcine_buttonEnable(true);
                    Pathology_buttonEnable(true);
                    btnConsultEdit.Enabled = true;
                    btnPathologyEdit.Enabled = true;
                    btnMedicineEdit.Enabled = true;
                    btnPatientEdit.Enabled = true;
                    //gridView1.Columns["Remove"].Visible = false;
                    //gridView.Columns["Remove"].Visible = false;
                    //griViewIssueMedine.Columns["Remove"].Visible = false;
                    //gridViewServiceBill.Columns["Remove"].Visible = false;
                }
                if (_session.SavePermission == true && _session.EditPermission == false &&
                    _session.DeletePermission == true)
                {
                    Patient_buttonEnable(true);
                    Consult_buttonEnable(true);
                    IssueMedcine_buttonEnable(true);
                    Pathology_buttonEnable(true);
                    btnConsultEdit.Enabled = false;
                    btnPathologyEdit.Enabled = false;
                    btnMedicineEdit.Enabled = false;
                    btnPatientEdit.Enabled = false;
                    //gridView1.Columns["Remove"].Visible = true;
                    //gridView.Columns["Remove"].Visible = true;
                    //griViewIssueMedine.Columns["Remove"].Visible = true;
                    //gridViewServiceBill.Columns["Remove"].Visible = true;
                }
            }
        }

        private void chkNICU_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "PSQty")
                {
                    decimal total = 0;
                    decimal Rate = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "PsRate"));
                    decimal qty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "PSQty"));
                    total = Rate * qty;
                    gridView1.SetRowCellValue(e.RowHandle, "PsSubTotal", total.ToString("0.00"));
                }
                if (e.Column.FieldName == "PsRate")
                {
                    decimal total = 0;
                    decimal Rate = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "PsRate"));
                    decimal qty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "PSQty"));
                    total = Rate * qty;
                    gridView1.SetRowCellValue(e.RowHandle, "PsSubTotal", total.ToString("0.00"));
                }
            }
            catch (Exception)
            {

            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (toggleSwitch1.IsOn)
                {
                    LoadConsoultService(cmbPid.Text, "OPD");
                }
                else
                {
                    LoadConsoultService(cmbPid.Text, "IPD");
                }
            }
        }

        private void IPBillingSetup_LocationChanged(object sender, EventArgs e)
        {

        }

        private void repositoryItemLookUpEdit6_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = gridView1.ActiveEditor as LookUpEdit;
            if (edit != null)
            {
                object value = edit.Text;
                DataRow service = new ServiceManager().GetPathologyMaster().AsEnumerable().FirstOrDefault(a => a["Alias"].ToString() == value.ToString());
                
                var serviceName = service["Alias"].ToString();
                var PathID = service["PathID"].ToString();

                gridView1.SetFocusedRowCellValue("Alias", serviceName);
                gridView1.SetFocusedRowCellValue("PathID", PathID);
                
            }
        }
    }
}