using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Model;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.NICU
{
    public partial class PathologyStatus : Form
    {
        private DoctorWisePatientManager aDoctorWisePatientManager;

        public PathologyStatus()
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

        private void LoadRefferedInfo()
        {
            data = aDoctorWisePatientManager.LoadPathology();
            searchLookPathology.Properties.DataSource = data;
            searchLookUpEdit1.Properties.DataSource = data;

            searchLookPathology.Properties.DisplayMember = "PathologyName";
            searchLookPathology.Properties.ValueMember = "PathId";
            searchLookUpEdit1.Properties.DisplayMember = "PathologyName";
            searchLookUpEdit1.Properties.ValueMember = "PathId";
        }

        private void PathologyPayment()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.GetPathologyPayment(FromDate.Value, ToDate.Value);
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
            PathologyPayment();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoctorWisePatient_IP_Load(object sender, EventArgs e)
        {
            GetVoucherNo();
            LoadRefferedInfo();
            PathologyPayment();
        }

        private void searchLookUpDoctor_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        public void GetVoucherNo()
        {
            DataTable data = new DataTable();
            data = new DoctorWisePatientManager().GetPathologyVch();
            txtVoucherNo.Text = data.Rows[0]["VchNo"].ToString();
        }



        private void DueStatusByReff()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.DueBillStatusByReff(Chk, FromDate.Value, ToDate.Value, searchLookPathology.Text);
            gridControlPatient.DataSource = data;
        }

        private string RefferedId = "";
        private void searchLookReffered_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                RefferedId = searchLookPathology.Properties.View.GetFocusedRowCellValue("PathId").ToString();
                txtAddress.Text = searchLookPathology.Properties.View.GetFocusedRowCellValue("Address").ToString();
                txtTotalAmount.Focus();
            }
            catch (Exception)
            {
                
               
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
            MessageModel message = new DoctorWisePatientManager().SavePathologyPayment(saveService);
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
            searchLookPathology.Text ="";
            txtAddress.Text = string.Empty;
            searchLookPathology.Properties.NullText = "Select";
            GetVoucherNo();
            PathologyPayment();
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

        private void PathologyLedger()
        {
            try
            {
                data = aDoctorWisePatientManager.PathologyLedger(startDate.Value, endDate.Value, pathID);
                gridControl1.DataSource = data;
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Pathology", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchLookUpEdit1.Focus();
            }
            
        }
        

        private void btnCommissionView_Click(object sender, EventArgs e)
        {
           
            PathologyLedger();
        }

        private string pathID = "";
        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            pathID = searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("PathId").ToString();
            PathologyLedger();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            PathologyLedger();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            PathologyLedger();
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
                new ReportParameter("Ledger",  searchLookUpEdit1.Text),
            };
            model.ReportDataSource.Name = "PathologyStatus";

            PathologyLedger();
            model.ReportDataSource.Value = data;

            model.ReportPath = "GHospital_Care.Report.rptPathologyStatus.rdlc";
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
            model.ReportDataSource.Name = "PathologyPayment";

            
            DataTable Payment = aDoctorWisePatientManager.GetPathologyPayment(FromDate.Value, ToDate.Value);
            model.ReportDataSource.Value = Payment;

            model.ReportPath = "GHospital_Care.Report.rptPathologyPayment.rdlc";
            model.Show(model, this);
        }
        private void btnComissionPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private string pathology = "";
        private void gridViewPatient_DoubleClick(object sender, EventArgs e)
        {
            txtVoucherNo.Text = gridViewPatient.GetFocusedRowCellValue("VoucherNo").ToString();
            datePathology.Text = gridViewPatient.GetFocusedRowCellValue("Date").ToString();
            searchLookPathology.Properties.NullText = gridViewPatient.GetFocusedRowCellValue("Alias").ToString();
            txtTotalAmount.Text = gridViewPatient.GetFocusedRowCellValue("Amount").ToString();
            txtDescription.Text = gridViewPatient.GetFocusedRowCellValue("Description").ToString();
            pathology = gridViewPatient.GetFocusedRowCellValue("Particulars").ToString();
            txtAddress.Text = gridViewPatient.GetFocusedRowCellValue("Address").ToString();
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DAL.Model.Pathology saveService = new DAL.Model.Pathology();
            saveService.VoucherNo = txtVoucherNo.Text;
            saveService.Particulars = pathology;
            saveService.Date = datePathology.Value;
            saveService.Description = txtDescription.Text;
            saveService.Inword = lblInward.Text;
            saveService.Amount = Convert.ToDecimal(txtTotalAmount.Text);
            saveService.UserId = MainWindow.userName;
            MessageModel message = new DoctorWisePatientManager().UpdatePathologyPayment(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DAL.Model.Pathology saveService = new DAL.Model.Pathology();
            saveService.VoucherNo = txtVoucherNo.Text;
            MessageModel message = new DoctorWisePatientManager().DeletePathologyPayment(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }
    }
}