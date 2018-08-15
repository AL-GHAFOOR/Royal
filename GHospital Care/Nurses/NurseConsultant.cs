using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.Session;

namespace GHospital_Care.Nurses
{
    public partial class NurseConsultant : Form
    {
        SessionData _session = new SessionData();
        private string IpBillingStatus = "";
        public NurseConsultant(string menuName)
        {
            InitializeComponent();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
                this.Activate();
            }
           // Control buttonControl = new ButtonPermissionAccess().TabControl(this.tabControl1, this.Name);
        }
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
     
       
        private DataTable ConsultService;
        public void LoadConsoultService(string patientId, string status)
        {
            try{
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
        private void CosulultDoctor()
        {
            DataTable AllDoctor = new MedicalManager().GetAllCosultDoctor(null);
            repositoryItemLookUpEdit1.DataSource = AllDoctor;
            repositoryItemLookUpEdit1.DisplayMember = "DoctorID";
            repositoryItemLookUpEdit1.ValueMember = "DoctorID";


        }
      
        DataTable patientDataTable = new DataTable();
        private void NurseConsultant_Load(object sender, EventArgs e)
        {
            try
            {
            CosulultDoctor();
               if (toggleSwitch1.IsOn)
                {
                    GetAllPatientSlNo(toggleSwitch1.Properties.OnText);
                   
                    LoadConsoultService(cmbPid.Text, "OPD");
               
                    // MedineList();
                }
                else
                {
                    GetAllPatientSlNo(toggleSwitch1.Properties.OffText);
                    
                    LoadConsoultService(cmbPid.Text, "IPD");
                 
                }
                //GetAllPatientSlNo(toggleSwitch1.Properties.OffText);


               
                //chkPermission();
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.GetBaseException().ToString());
                this.Activate();
            }
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
        public void LoadOtSetupByPId(string pid)
        {
            OtSetup otSetup = new OT_Manager().GetOtSetupByPatientId(pid);

           }

        private void cmbPid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectId = cmbPid.Text;
                LoadDataForIPD(selectId);
                //LoadOtSetupByPId(selectId);
                if (IpBillingStatus == "OPD")
                {
                    //LoadOtSetupByPId(cmbPid.Text);
                    LoadConsoultService(cmbPid.Text, toggleSwitch1.Properties.OnText);
                   // LoadPatientService(cmbPid.Text, toggleSwitch1.Properties.OnText);
                    //LoadPatientPathologyService(cmbPid.Text, toggleSwitch1.Properties.OnText);

                }
                else if (IpBillingStatus == "IPD")
                {
                    //Consult---
                    LoadDataForIPD(cmbPid.Text);
                    LoadConsoultService(selectId, toggleSwitch1.Properties.OffText);
                    //LoadPatientService(selectId, toggleSwitch1.Properties.OffText);
                    //LoadPatientPathologyService(cmbPid.Text, toggleSwitch1.Properties.OffText);


                }
            }
            catch (Exception)
            {

                // throw;
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

        private void btnConsultEdit_Click(object sender, EventArgs e)
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

        }private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
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
    }
}
