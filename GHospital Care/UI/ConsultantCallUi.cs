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
            DataTable dt = new DataTable();
            dt = new ConsultantCallManager().GetAllIpAdmissionInfo();

            if (dt.Rows.Count > 0)
            {
                searchLookUpGetPatient.Properties.DataSource = dt;
                searchLookUpGetPatient.Properties.DisplayMember = "PatientName";
                searchLookUpGetPatient.Properties.ValueMember = "OPID";
            }
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
            radioBtnIndoor.Checked = true;
<<<<<<< HEAD
            // GetAllIpPatient();
=======
           // GetAllIpPatient();
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
            GetIpdAllDoctor();
            GenerateVoucherNo();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }


        public void Refresh()
        {
            searchLookUpGetPatient.Properties.DataSource = null;
            searchLookUpGetPatient.Properties.NullText = "---Select---";
            searchLookUpEditConsultant.Properties.NullText = "---Select---";
            txtPatientID.Text = "";
            txtPatientName.Text = "";
            txtFee.Text = "";
            txtAddress.Text = "";
            GenerateVoucherNo();
<<<<<<< HEAD
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConsultBillService aConsultBillService = new ConsultBillService();
=======
           }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConsultBillService aConsultBillService=new ConsultBillService();
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
            ConsultantCall aConsultantCall = new ConsultantCall();

            aConsultantCall.OpId = txtPatientID.Text;
            aConsultantCall.ConsultantId = searchLookUpEditConsultant.EditValue.ToString();
            aConsultantCall.Id = Convert.ToInt32(txtVoucherNo.Text);

            aConsultBillService.OPID = txtPatientID.Text;
            aConsultBillService.ConsultId = searchLookUpEditConsultant.EditValue.ToString();
            aConsultBillService.ConsultBillDate = dateServiceDate.Text;
            aConsultBillService.ConFee = Convert.ToDouble(txtFee.Text);
            aConsultBillService.ConQty = 1;
            aConsultBillService.VchNo = Convert.ToInt64(txtVoucherNo.Text);
<<<<<<< HEAD

=======
            
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
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
            DataTable AllDoctor = new MedicalManager().GetAllCosultDoctor(null);
            searchLookUpEditConsultant.Properties.DataSource = AllDoctor;
            searchLookUpEditConsultant.Properties.DisplayMember = "DoctorName";
            searchLookUpEditConsultant.Properties.ValueMember = "DoctorID";
        }


<<<<<<< HEAD

=======
        
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
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
            try
            {
<<<<<<< HEAD
                // searchLookUpGetPatient.Properties.View.SetFocusedRowCellValue("PatientName", txtPatientName.Text);
                txtPatientID.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString();

                string patientName = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
                txtPatientName.Text = patientName;

                txtCabin.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("CabinName").ToString();
=======
                searchLookUpGetPatient.Properties.View.SetFocusedRowCellValue("PatientName", txtPatientName.Text);
                txtPatientID.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString();
                txtPatientName.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
                txtAddress.Text = searchLookUpGetPatient.Properties.View.GetFocusedRowCellValue("Address").ToString();
                searchLookUpEditConsultant.Focus();
            }
            catch (Exception)
            {


            }
<<<<<<< HEAD

=======
           
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
        }

        private void searchLookUpEditConsultant_EditValueChanged_1(object sender, EventArgs e)
        {
            txtFee.Focus();
<<<<<<< HEAD
        }

        public void GetNicuPatient()
        {
            searchLookUpGetPatient.Properties.DataSource = new ConsultantCallManager().GetNICUPatient();
            searchLookUpGetPatient.Properties.DisplayMember = "PatientName";
            searchLookUpGetPatient.Properties.ValueMember = "OPID";

        }

=======
        }

        public void GetNicuPatient()
        {
            searchLookUpGetPatient.Properties.DataSource = new ConsultantCallManager().GetNICUPatient();
            searchLookUpGetPatient.Properties.DisplayMember = "PatientName";
            searchLookUpGetPatient.Properties.ValueMember = "OPID";
        
         }
        
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
        private void radioBtnNicu_CheckedChanged(object sender, EventArgs e)
        {
            searchLookUpGetPatient.Properties.DataSource = null;
            Refresh();
            GetNicuPatient();

        }



        private void radioBtnIndoor_CheckedChanged(object sender, EventArgs e)
        {
            
            searchLookUpGetPatient.Properties.DataSource = null;
            Refresh();
            GetAllIpPatient();
        }

<<<<<<< HEAD
            searchLookUpGetPatient.Properties.DataSource = null;
            Refresh();
            GetAllIpPatient();
        }

=======
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
        public void ViewConsultant()
        {
            DataTable dt = new ConsultantCallManager().ViewConsultantMaster(FromDate.Value, ToDate.Value);
            gridControl1.DataSource = dt;
        }

        private void btnCommissionView_Click(object sender, EventArgs e)
        {
            ViewConsultant();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            ViewConsultant();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            ViewConsultant();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            ViewConsultant();
        }
<<<<<<< HEAD

        private string Consultent = "";
        private string PatientID = "";
        private string category = "";
        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            category = gridView3.GetFocusedRowCellValue("Status").ToString();
            if (category == "Indoor")
            {
                radioBtnIndoor.Checked = true;
            }
            if (category == "NICU")
            {
                radioBtnNicu.Checked = true;
            }
            searchLookUpGetPatient.Properties.DataSource = null;
            txtVoucherNo.Text = gridView3.GetFocusedRowCellValue("VoucherNo").ToString();
            dateServiceDate.Text = gridView3.GetFocusedRowCellValue("Date").ToString();
            searchLookUpEditConsultant.Properties.NullText = gridView3.GetFocusedRowCellValue("DoctorName").ToString();
            txtPatientID.Text = gridView3.GetFocusedRowCellValue("OPID").ToString();
            txtPatientName.Text = gridView3.GetFocusedRowCellValue("PatientName").ToString();
            Consultent = gridView3.GetFocusedRowCellValue("ConsultantId").ToString();
            PatientID = gridView3.GetFocusedRowCellValue("OPID").ToString();
            txtAddress.Text = gridView3.GetFocusedRowCellValue("Address").ToString();
            txtFee.Text = gridView3.GetFocusedRowCellValue("ConFee").ToString();
            searchLookUpGetPatient.Properties.NullText = txtPatientName.Text;
            xtraTabPage1.Show();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ConsultBillService aConsultBillService = new ConsultBillService();
            ConsultantCall aConsultantCall = new ConsultantCall();

            aConsultantCall.OpId = txtPatientID.Text;
            aConsultantCall.ConsultantId = Consultent;
            aConsultantCall.Id = Convert.ToInt32(txtVoucherNo.Text);

            aConsultBillService.OPID = txtPatientID.Text;
            aConsultBillService.ConsultId = Consultent;
            aConsultBillService.ConsultBillDate = dateServiceDate.Text;
            aConsultBillService.ConFee = Convert.ToDouble(txtFee.Text);
            aConsultBillService.ConQty = 1;
            aConsultBillService.VchNo = Convert.ToInt64(txtVoucherNo.Text);

            MessageModel message = new ConsultantCallManager().UpdateConsultantCall(aConsultantCall, aConsultBillService);
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


=======

        private string Consultent = "";
        private string PatientID = "";
        private string category = ""; 
        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            category = gridView3.GetFocusedRowCellValue("Status").ToString();
            if (category == "Indoor")
            {
                radioBtnIndoor.Checked = true;
            }
            if (category == "NICU")
            {
                radioBtnNicu.Checked = true;
            }
            searchLookUpGetPatient.Properties.DataSource = null;
            txtVoucherNo.Text = gridView3.GetFocusedRowCellValue("VoucherNo").ToString();
            dateServiceDate.Text = gridView3.GetFocusedRowCellValue("Date").ToString();
            searchLookUpEditConsultant.Properties.NullText = gridView3.GetFocusedRowCellValue("DoctorName").ToString();
            txtPatientID.Text = gridView3.GetFocusedRowCellValue("OPID").ToString();
            txtPatientName.Text = gridView3.GetFocusedRowCellValue("PatientName").ToString();
            Consultent = gridView3.GetFocusedRowCellValue("ConsultantId").ToString();
            PatientID = gridView3.GetFocusedRowCellValue("OPID").ToString();
            txtAddress.Text = gridView3.GetFocusedRowCellValue("Address").ToString();
            txtFee.Text = gridView3.GetFocusedRowCellValue("ConFee").ToString();
            searchLookUpGetPatient.Properties.NullText = txtPatientName.Text;
            xtraTabPage1.Show();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ConsultBillService aConsultBillService = new ConsultBillService();
            ConsultantCall aConsultantCall = new ConsultantCall();

            aConsultantCall.OpId = txtPatientID.Text;
            aConsultantCall.ConsultantId = Consultent;
            aConsultantCall.Id = Convert.ToInt32(txtVoucherNo.Text);

            aConsultBillService.OPID = txtPatientID.Text;
            aConsultBillService.ConsultId = Consultent;
            aConsultBillService.ConsultBillDate = dateServiceDate.Text;
            aConsultBillService.ConFee = Convert.ToDouble(txtFee.Text);
            aConsultBillService.ConQty = 1;
            aConsultBillService.VchNo = Convert.ToInt64(txtVoucherNo.Text);

            MessageModel message = new ConsultantCallManager().UpdateConsultantCall(aConsultantCall, aConsultBillService);
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

        
>>>>>>> 077d18b8db0ecb2f9355d455de044d12204a1222
    }
}
