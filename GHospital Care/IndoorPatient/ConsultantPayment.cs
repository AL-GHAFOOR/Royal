using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Model;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.IndoorPatient
{
    public partial class ConsultantPayment : Form
    {
        private DoctorWisePatientManager aDoctorWisePatientManager;

        public ConsultantPayment()
        {
            string user = MainWindow.userName;
            InitializeComponent();
            aDoctorWisePatientManager = new DoctorWisePatientManager();
        }

        //Method Start here //Method Start here //Method Start here //Method Start here 
        //Method Start here //Method Start here //Method Start here //Method Start here 

        private DataTable data = new DataTable();

        private void LoadDoctors()
        {
            data = aDoctorWisePatientManager.LoadDoctors();
        }

     

        private void CosulultDoctor()
        {
            DataTable AllDoctor = new MedicalManager().GetAllCosultDoctor(null);
            searchLookConsltant.Properties.DataSource = AllDoctor;
            searchLookUp_Cousultant.Properties.DataSource = AllDoctor;
            searchLookConsltant.Properties.DisplayMember = "DoctorName";
            searchLookConsltant.Properties.ValueMember = "DoctorID";

            searchLookUp_Cousultant.Properties.DisplayMember = "DoctorName";
            searchLookUp_Cousultant.Properties.ValueMember = "DoctorID";


        }
        DataTable Consultant = new DataTable();
        private void PathologyPayment()
        {
            Consultant = aDoctorWisePatientManager.GetPathologyPayment(FromDate.Value, ToDate.Value);
            gridControlPatient.DataSource = data;
        }

        private void GetConsultantPayment()
        {
           // DataTable data = new DataTable();
            data = aDoctorWisePatientManager.GetConsultantPayment(FromDate.Value, ToDate.Value);
            gridControlPatient.DataSource = data;
        }

        //Events Start here //Events Start here //Events Start here //Events Start here 
        //Events Start here //Events Start here //Events Start here //Events Start here 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPayment();
         }

        private string Chk = "";
            
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetConsultantPayment();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoctorWisePatient_IP_Load(object sender, EventArgs e)
        {
            GetVoucherNo();
            CosulultDoctor();
            GetConsultantPayment();
        }

        private void searchLookUpDoctor_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        public void GetVoucherNo()
        {
            DataTable data = new DataTable();
            data = new DoctorWisePatientManager().GetConslutantVch();
            txtVoucherNo.Text = data.Rows[0]["VchNo"].ToString();
        }



        private void DueStatusByReff()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.DueBillStatusByReff(Chk, FromDate.Value, ToDate.Value, searchLookConsltant.Text);
            gridControlPatient.DataSource = data;
        }

        private string RefferedId = "";
        private void searchLookReffered_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                RefferedId = searchLookConsltant.Properties.View.GetFocusedRowCellValue("DoctorID").ToString();
                txtAddress.Text = searchLookConsltant.Properties.View.GetFocusedRowCellValue("Specialization").ToString();
                txtTotalAmount.Focus();
            }
            catch (Exception)
            {
                
               // throw;
            }
          
        }

        private string status = "";
        private void rdIndoor_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdNICU_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {

            PathologyPayment();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

            PathologyPayment();
        }

        private void gridControlPatient_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAL.Model.Pathology saveService = new DAL.Model.Pathology();
            saveService.VoucherNo = txtVoucherNo.Text;
            saveService.Particulars = RefferedId;
            saveService.Date = datePathology.Value;
            saveService.Description = txtDescription.Text;
            saveService.Inword = lblInward.Text;
            saveService.Amount = Convert.ToDecimal(txtTotalAmount.Text);
            saveService.UserId = MainWindow.userName;
            MessageModel message = new DoctorWisePatientManager().SaveConsultantPayment(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
           
            
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var ammount = Spell.SpellAmount.InWrods(Convert.ToDecimal(txtTotalAmount.Text));
                lblInward.Text = ammount;
            }
            catch (Exception)
            {
                
             }
           
        }

        public void Clear()
        {
            txtDescription.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            lblInward.Text = string.Empty;
            searchLookConsltant.Text ="";
            txtAddress.Text = string.Empty;
            datePathology.Text = System.DateTime.Today.Date.ToString("d");
            searchLookConsltant.Properties.NullText = "Select";
            GetVoucherNo();
            GetConsultantPayment();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtTotalAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Focus();
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConsultantLedger(){
            try
            {
                data = aDoctorWisePatientManager.ConsutantLedger(startDate.Value, endDate.Value, ConsultID);
                gridControl1.DataSource = data;
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Pathology", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchLookUp_Cousultant.Focus();
            }
            
        }
        

        private void btnCommissionView_Click(object sender, EventArgs e)
        {
            ConsultantLedger();
        }

        private string ConsultID = "";
        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ConsultID = searchLookUp_Cousultant.Properties.View.GetFocusedRowCellValue("DoctorID").ToString();
            ConsultantLedger();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            ConsultantLedger();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            ConsultantLedger();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        public void Print()
        {
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>{
               new ReportParameter("dtFrom", startDate.Value.ToString("d")),
                new ReportParameter("dtTo",  endDate.Value.ToString("d")),
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
                new ReportParameter("Ledger",  searchLookUp_Cousultant.Text),
            };
            model.ReportDataSource.Name = "PathologyStatus";

            ConsultantLedger();
            model.ReportDataSource.Value = data;

            model.ReportPath = "GHospital_Care.Report.rptConsultantStatus.rdlc";
            model.Show(model, this);
        }


        public void PrintPayment()
        {
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>{
               new ReportParameter("dtFrom", FromDate.Value.ToString("d")),
                new ReportParameter("dtTo",  ToDate.Value.ToString("d")),
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
               
            };
            model.ReportDataSource.Name = "ConsultantPayment";

            
           GetConsultantPayment();
           model.ReportDataSource.Value = data;

            model.ReportPath = "GHospital_Care.Report.rptConsultantPayment.rdlc";
            model.Show(model, this);
        }
        private void btnComissionPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private string Consultent = "";
        private void gridViewPatient_DoubleClick(object sender, EventArgs e)
        {
            txtVoucherNo.Text = gridViewPatient.GetFocusedRowCellValue("VoucherNo").ToString();
            datePathology.Text = gridViewPatient.GetFocusedRowCellValue("Date").ToString();
            searchLookConsltant.Properties.NullText = gridViewPatient.GetFocusedRowCellValue("DoctorName").ToString();
            txtTotalAmount.Text = gridViewPatient.GetFocusedRowCellValue("Amount").ToString();
            txtDescription.Text = gridViewPatient.GetFocusedRowCellValue("Description").ToString();
            Consultent = gridViewPatient.GetFocusedRowCellValue("Particulars").ToString();
            txtAddress.Text = gridViewPatient.GetFocusedRowCellValue("Specialization").ToString();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DAL.Model.Pathology saveService = new DAL.Model.Pathology();
            saveService.VoucherNo = txtVoucherNo.Text;
            saveService.Particulars = Consultent;
            saveService.Date = datePathology.Value;
            saveService.Description = txtDescription.Text;
            saveService.Inword = lblInward.Text;
            saveService.Amount = Convert.ToDecimal(txtTotalAmount.Text);
            saveService.UserId = MainWindow.userName;
            MessageModel message = new DoctorWisePatientManager().UpdateConsultantPayment(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DAL.Model.Pathology saveService = new DAL.Model.Pathology();
            saveService.VoucherNo = txtVoucherNo.Text;
            MessageModel message = new DoctorWisePatientManager().DeleteConsultantPayment(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }
    }
}
