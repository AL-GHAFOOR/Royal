using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.Data.Filtering.Helpers;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Model;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.IndoorPatient
{
    public partial class ComssionStauts : Form
    {
        private DoctorWisePatientManager aDoctorWisePatientManager;

        public ComssionStauts()
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
            data = aDoctorWisePatientManager.LoadRefferedInfo();
            searchLookReffered.Properties.DataSource = data;
            searchLookUpEdit1.Properties.DataSource = data;

            searchLookReffered.Properties.DisplayMember = "Name";
            searchLookReffered.Properties.ValueMember = "Id";
            searchLookUpEdit1.Properties.DisplayMember = "Name";
            searchLookUpEdit1.Properties.ValueMember = "Id";
        }


        private void DueStatus()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.DueBillStatus(Chk,FromDate.Value, ToDate.Value);
            gridControlPatient.DataSource = data;
        }

        //Events Start here //Events Start here //Events Start here //Events Start here 
        //Events Start here //Events Start here //Events Start here //Events Start here 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Are you really want to print this?", "Print", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    try
            //    {
            //        //string total = dataGridView1.Rows.Count.ToString();
            //        DGVPrinter printer = new DGVPrinter();
            //        printer.Title = "Bhashani Hospital & Diagonstic Center";
            //        printer.SubTitle = "Mohiuddin Plaza, Kagmari Road, Babistand, Tangail" + "\n" +
            //                           "Doctor Wise Patient List" + "\n" + "Total Patient: " + total;
            //        printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
            //                                      StringFormatFlags.NoClip;
            //        printer.PageNumbers = true;
            //        printer.PageNumberInHeader = false;
            //        printer.PorportionalColumns = true;
            //        printer.HeaderCellAlignment = StringAlignment.Near;
            //        printer.Footer = "Developed By - " + "GSoft Technologies";
            //        printer.FooterSpacing = 30;

            //        //printer.PrintPreviewDataGridView(dataGridView1);
            //    }catch (Exception error)
            //    {
            //        MessageBox.Show("Failed to print data! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK,
            //            MessageBoxIcon.Exclamation);
            //    }
            //}
        }

        private string Chk = "";
            
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoctorWisePatient_IP_Load(object sender, EventArgs e)
        {
            GetCommssionReff();
            LoadRefferedInfo();
            rdIndoor.Checked = true;
            DueStatus();
        }

        private void searchLookUpDoctor_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        public void GetCommssionReff()
        {
            DataTable data = new DataTable();
            data = new DoctorWisePatientManager().GetCommissionReff();
            txtCommissionID.Text = data.Rows[0]["RegNo"].ToString();
        }



        private void DueStatusByReff()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.DueBillStatusByReff(Chk, FromDate.Value, ToDate.Value, searchLookReffered.Text);
            gridControlPatient.DataSource = data;
        }

        private string RefferedId = "";
        private void searchLookReffered_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DueStatusByReff();
                RefferedId = searchLookReffered.Properties.View.GetFocusedRowCellValue("Id").ToString();
                txtTotalAmount.Focus();
            }
            catch (Exception)
            {
                
                //throw;
            }
           
        }

        private string status = "";
        private void rdIndoor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
                
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
        }

        private void rdNICU_CheckedChanged(object sender, EventArgs e)
        {
            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {

            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
        }

        private void gridControlPatient_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Comission saveService = new Comission();
            saveService.CommissionId = txtCommissionID.Text;
            saveService.ReffId = RefferedId;
            saveService.Date = dateCommission.Value;
            saveService.Remarks = txtRemarks.Text;
            saveService.Inword = lblInward.Text;
            saveService.Amount = Convert.ToDecimal(txtTotalAmount.Text);
            saveService.UserId = MainWindow.userName;
            saveService.Status = Chk;
            MessageModel message = new DoctorWisePatientManager().SaveCommission(saveService);
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
            txtRemarks.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            lblInward.Text = string.Empty;
            dateCommission.Text = System.DateTime.Today.Date.ToString("d");
            searchLookReffered.Properties.NullText = "Select";
            GetCommssionReff();
            CommissionView();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtTotalAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalAmount.Focus();
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

        private void CommissionView()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.VewCommission(startDate.Value, EndDate.Value,RefferedId);
            gridControl1.DataSource = data;
        }
        

        private void btnCommissionView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            CommissionView();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            CommissionView();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            CommissionView();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            CommissionView();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            CommissionView();
        }

        private void panel9_Paint_1(object sender, PaintEventArgs e)
        {

        }

        public void Print()
        {
                ReportModel model = new ReportModel();
                model.Parameters = new List<ReportParameter>{
                new ReportParameter("dtFrom", startDate.Value.ToString("d")),
                new ReportParameter("dtTo",  EndDate.Value.ToString("d")),
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
                new ReportParameter("Ledger",  searchLookUpEdit1.Text),
            };
                model.ReportDataSource.Name = "Commission";

            if (string.IsNullOrEmpty(RefferedId))
            {
                RefferedId = "All";
            }
            CommissionView();
            model.ReportDataSource.Value = data;

            model.ReportPath = "GHospital_Care.Report.rptComissionStatus.rdlc";
            model.Show(model, this);
        }

        private void btnComissionPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private string Reff = "";
        private void gridViewPatient_DoubleClick(object sender, EventArgs e)
        {
            
            
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            txtCommissionID.Text = gridView3.GetFocusedRowCellValue("CommissionID").ToString();
            dateCommission.Text = gridView3.GetFocusedRowCellValue("Date").ToString();
            searchLookReffered.Properties.NullText = gridView3.GetFocusedRowCellValue("Name").ToString();
            txtTotalAmount.Text = gridView3.GetFocusedRowCellValue("Amount").ToString();
            txtRemarks.Text = gridView3.GetFocusedRowCellValue("Remarks").ToString();
            Reff = gridView3.GetFocusedRowCellValue("ReffId").ToString();
            if (rdIndoor.Checked)
            {
                Chk = "Indoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            xtraTabPage1.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Comission saveService = new Comission();
            saveService.CommissionId = txtCommissionID.Text;
            saveService.ReffId = Reff;
            saveService.Date = dateCommission.Value;
            saveService.Remarks = txtRemarks.Text;
            saveService.Inword = lblInward.Text;
            saveService.Amount = Convert.ToDecimal(txtTotalAmount.Text);
            saveService.UserId = MainWindow.userName;
            saveService.Status = Chk;
            MessageModel message = new DoctorWisePatientManager().UpdateCommission(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Comission saveService = new Comission();
            saveService.CommissionId = txtCommissionID.Text;
            MessageModel message = new DoctorWisePatientManager().DeleteCommission(saveService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }
    }
}
