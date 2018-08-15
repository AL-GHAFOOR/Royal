using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.Operation;
using GHospital_Care.Session;

namespace GHospital_Care.Nurses
{
    public partial class NursePatientService : Form
    {
        SessionData _session = new SessionData();
        private string IpBillingStatus = "";
        public NursePatientService(string menuName)
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
               
                service.OPID = cmbPid.Text;
                service.GodownId = "3";
                var list = new ServiceManager().GetOPMedicineListByPatientId(service);
                dt = new CustomLibry.CustomLibrary().ToDataTable(list);
                Int64 MaxID = new ServiceGateway().GetOPMedMaxValue();
                
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
      
       

        DataTable patientDataTable = new DataTable();

        
        private void IPBillingSetup_Load(object sender, EventArgs e)
        {
            try
            {
                PatientService();
                //LoadDataTable();
                 MedineList();
                if (toggleSwitch1.IsOn)
                {
                    GetAllPatientSlNo(toggleSwitch1.Properties.OnText);
                    LoadPatientService(cmbPid.Text, "OPD");
                   
                   // MedineList();
                }
                else
                {
                    GetAllPatientSlNo(toggleSwitch1.Properties.OffText);
                    LoadPatientService(cmbPid.Text, "IPD");
                   
                }
               //GetAllPatientSlNo(toggleSwitch1.Properties.OffText);
                
               
                Patient_buttonEnable(true);
                //-----for patientService---
                _session.ChkPermission(MainWindow.userName);
                if (_session.SavePermission == false)
                {
                    Patient_buttonEnable(true);
                    
                    btnSavePSBill.Enabled = false;
                    
                }
                else
                {
                    Patient_buttonEnable(true);
                    
                }
                //chkPermission();
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.GetBaseException().ToString());
                this.Activate();
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
                if (IpBillingStatus== "OPD")
                {
                    //LoadOtSetupByPId(cmbPid.Text);
                   LoadPatientService(cmbPid.Text, toggleSwitch1.Properties.OnText);
                   

                }
                else if (IpBillingStatus == "IPD")
                {
                    //Consult---
                    LoadDataForIPD(cmbPid.Text);
                    LoadPatientService(selectId, toggleSwitch1.Properties.OffText);
                   


                }
            }
            catch (Exception)
            {

                // throw;
            }

        }

        //Consult-------
     

        //Consult---------
        private DataTable ConsultService;
        private DataTable Patientservice;
       

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


        
        private void btnSavePSBill_Click(object sender, EventArgs e)
        {
            Service saveService = new Service();
            saveService.GetPatientServices = new ServiceManager().GetPatientServiceByPatientId(cmbPid.Text, IpBillingStatus, "", dtpPatientService.Value);
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
       
        private void gridControlIssueMedine_Click(object sender, EventArgs e)
        {

        }

        
        


      


     
     

        private void windowsUIButtonPanel2_Click(object sender, EventArgs e)
        {

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

       

       


        private DataTable Pathology;
      
       

      
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

        


        


       

       

        private void chkPermission()
        {
            _session.ChkPermission(MainWindow.userName);
            if (_session.SavePermission == true && _session.EditPermission == true && _session.DeletePermission == true)
            {
                Patient_buttonEnable(false);
                btnSavePSBill.Enabled = true;
               
            }
            else
            {
                if (_session.SavePermission == true && _session.EditPermission == false &&
                    _session.DeletePermission == false)
                {
                    Patient_buttonEnable(true);
                   
                }
                if (_session.SavePermission == true && _session.EditPermission == true &&
                    _session.DeletePermission == false)
                {
                    Patient_buttonEnable(true);
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
       

    }
}
