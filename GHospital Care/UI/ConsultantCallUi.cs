using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.BAL;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.UI
{
    public partial class ConsultantCallUi : Form
    {
        public ConsultantCallUi()
        {
            InitializeComponent();

            
        }



        public void GetAllIpPatient()
        {
            searchLookUpGetPatient.Properties.DataSource = new ConsultantCallManager().GetAllIpAdmissionInfo();
            searchLookUpGetPatient.Properties.DisplayMember = "PatientName";
            searchLookUpGetPatient.Properties.DisplayMember = "OPID";
        }

        public void GenerateVoucherNo()
        {
            DataTable data = new ConsultantCallManager().GenerateVoucherNo();

            if (data.Rows.Count > 0)
            {
                txtVoucherNo.Text = data.Rows[0]["VchNo"].ToString();
            }
        }


        private void ConsultantCallUi_Shown(object sender, EventArgs e)
        {

        }

        private void ConsultantCallUi_Load(object sender, EventArgs e)
        {
            GetAllIpPatient();
            GetIpdAllDoctor();
            GenerateVoucherNo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }


        public void Refresh()
        {
            GetAllIpPatient();
            GetIpdAllDoctor();
            GenerateVoucherNo();

            searchLookUpGetPatient.Properties.NullText = "---Select---";
            searchLookUpEditConsultant.Properties.NullText = "---Select---";
            txtPatientID.Text = "";
            txtPatientName.Text = "";
            txtFee.Text = "";
            txtAddress.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            ConsultBillService aConsultBillService=new ConsultBillService();
            ConsultantCall aConsultantCall = new ConsultantCall();

            aConsultantCall.OpId = txtPatientID.Text;
            aConsultantCall.ConsultantId = searchLookUpEditConsultant.EditValue.ToString();


            aConsultBillService.OPID = txtPatientID.Text;
            aConsultBillService.ConsultId = searchLookUpEditConsultant.EditValue.ToString();
            aConsultBillService.ConsultBillDate = dateServiceDate.Text;
            aConsultBillService.ConFee = Convert.ToDouble(txtFee.Text);
            aConsultBillService.ConQty = 1;
            aConsultBillService.VchNo = Convert.ToInt64(txtVoucherNo.Text);



            MessageModel message = new ConsultantCallManager().SaveConsultantCall(aConsultantCall, aConsultBillService);
            if (message.MessageTitle == "Successful")
            {
                MetroFramework.MetroMessageBox.Show(this, message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refresh();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void GetIpdAllDoctor()
        {
            searchLookUpEditConsultant.Properties.DataSource = new IpdManager().GetIpdAllDoctor();
            searchLookUpEditConsultant.Properties.DisplayMember = "DoctorName";
            searchLookUpEditConsultant.Properties.ValueMember = "DoctorID";
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchLookUpGetPatient_EditValueChanged(object sender, EventArgs e)
        {
            txtPatientID.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtPatientName.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
            txtAddress.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
            
        }
        private void searchLookUpEditConsultant_EditValueChanged(object sender, EventArgs e)
        {
            txtFee.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString();
        }

        private void searchLookUpGetPatient_EditValueChanged_1(object sender, EventArgs e)
        {
            txtPatientID.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtPatientName.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
            txtAddress.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("Address").ToString();
            searchLookUpEditConsultant.Focus();
        }

        private void searchLookUpEditConsultant_EditValueChanged_1(object sender, EventArgs e)
        {
            txtFee.Focus();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCommissionView_Click(object sender, EventArgs e)
        {

        }
    }
}
