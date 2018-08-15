using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;
using GHospital_Care.IndoorPatient;
using GHospital_Care.Session;
using Microsoft.Reporting.WebForms;


namespace GHospital_Care.OutdoorPatient
{

    public partial class OutdoorPatientUi : Form
    {
        private OutdoorPatientManager aOutdoorPatientManager;
        //private AllReportViewer aReportView;
        private ReportDataSource aDataSource;
        // private ReportConnection aReportConnection;
        private List<ReportParameter> parameters = new List<ReportParameter>();


        readonly SessionData _session = new SessionData();

        public OutdoorPatientUi()
        {
            InitializeComponent();

            UserMaster aUserMaster;
            _session.ChkPermission(MainWindow.userName);


            if (_session.SavePermission == false)
            {
                buttonEnable(true);
                btnSave2.Enabled = false;
            }
            else
            {
                buttonEnable(true);

            }

            aOutdoorPatientManager = new OutdoorPatientManager();
            ActiveControl = cmbTreatmentType;
            
            //Control buttonControl = new ButtonPermissionAccess().UserButton(this.panel4, this.Name);
        }
        private void buttonEnable(bool stat)
        {
            //btnSave.Enabled = stat;
            //btnEdit.Enabled = !stat;
            //btnDelete.Enabled = !stat;
        }

        #region

        DataTable data = new DataTable();
        public void GetAllDoctors()
        {
            data = aOutdoorPatientManager.GetAllDoctors();
            searchLookUpDoctor.Properties.DataSource = data;
            searchLookUpDoctor.Properties.DisplayMember = "DoctorName";
            searchLookUpDoctor.Properties.ValueMember = "DoctorID";
        }


        //public void GetAllDoctorsById()
        //{
        //    string DoctorId = gridViewOutdorPatient.GetFocusedRowCellValue("Doctor").ToString();
        //    DataTable data = new DataTable();
        //    data = aOutdoorPatientManager.GetAllDoctorsById(DoctorId);
        //    searchLookUpDoctor.Properties.DataSource = data;
        //    searchLookUpDoctor.Properties.DisplayMember = "DoctorName";
        //    searchLookUpDoctor.Properties.ValueMember = "DoctorID";
        //}
        public void PopulateGridView()
        {
            try
            {
                aOutdoorPatientManager = new OutdoorPatientManager();
                DataTable dataTable = new DataTable();
                dataTable = aOutdoorPatientManager.PopulateGridView(fromDate.Value, ToDate.Value);
                gridControlOutdorPatient.DataSource = dataTable;
            }
            catch (Exception)
            {

                //throw;
            }
        }
        private void GeneratePatientId()
        {
            DataTable data = new DataTable();
            data = aOutdoorPatientManager.GeneratePatientId();
            if (data.Rows.Count > 0)
            {
                txtOpid.Text = data.Rows[0]["OPID"].ToString();
            }
        }
        public void Refresh()
        {
            try
            {
                DateTimeServiceDate.Value = DateTime.Today.Date;
                ToDate.Value = DateTime.Today.Date;
                fromDate.Value = DateTime.Now;
                GeneratePatientId();
                GetRefferedInfo();
                PopulateGridView();
                GetAllDoctors();
               
                cmbTreatmentType.Text = "----Select----";
                txtPatientName.Text = "";
                txtGurdianName.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
                txtAge.Text = "";
                cmbBloodGroup.Text = "----Select----";
                cmbGender.Text = "----Select----"; cmbNationality.Text = "----Select----";
                txtContactPerson.Text = "";
                txtMobileContactPerson.Text = "";
                txtDoctorFees.Text = "";

                btnDelete2.Enabled = false;
                btnSave2.Text = "Save";
                ActiveControl = cmbTreatmentType;
                searchLookUpDoctor.Properties.NullText = "Select Doctor";
                txtDoctorSpecialization.Text = "";
                checkBox1.Checked = false;

               
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        #endregion

       

        private void searchLookUpDoctor_EditValueChanged(object sender, EventArgs e)
        {
            txtDoctorSpecialization.Text = searchLookUpDoctor.Properties.View.GetFocusedRowCellValue("Specialization").ToString();
            txtDoctorFees.Text = "350";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Refresh();
            }
            catch (Exception ex)
            {
                //throw NotImplementedException;
            }
        }

        private void gridControlOutdorPatient_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtOpid.Text = gridViewOutdorPatient.GetFocusedRowCellValue("OPID").ToString();
                fromDate.Text = gridViewOutdorPatient.GetFocusedRowCellValue("ServiceDate").ToString();
                cmbTreatmentType.Text = gridViewOutdorPatient.GetFocusedRowCellValue("TreatmentType").ToString();
                txtPatientName.Text = gridViewOutdorPatient.GetFocusedRowCellValue("PatientName").ToString();
                txtGurdianName.Text = gridViewOutdorPatient.GetFocusedRowCellValue("GurdianName").ToString();
                txtAddress.Text = gridViewOutdorPatient.GetFocusedRowCellValue("Address").ToString();
                txtPhone.Text = gridViewOutdorPatient.GetFocusedRowCellValue("Phone").ToString();
                txtAge.Text = gridViewOutdorPatient.GetFocusedRowCellValue("Age").ToString();
                cmbBloodGroup.Text = gridViewOutdorPatient.GetFocusedRowCellValue("BloodGroup").ToString();
                cmbGender.Text = gridViewOutdorPatient.GetFocusedRowCellValue("Gender").ToString();
                cmbNationality.Text = gridViewOutdorPatient.GetFocusedRowCellValue("Nationality").ToString();
                txtContactPerson.Text = gridViewOutdorPatient.GetFocusedRowCellValue("ContactPerson").ToString();
                txtMobileContactPerson.Text = gridViewOutdorPatient.GetFocusedRowCellValue("Mobile").ToString();
                txtDoctorFees.Text = gridViewOutdorPatient.GetFocusedRowCellValue("Fees").ToString();

                txtDoctorFees.Text = gridViewOutdorPatient.GetFocusedRowCellValue("RefferedBy").ToString();



                string DoctorId = gridViewOutdorPatient.GetFocusedRowCellValue("Doctor").ToString();


                DataTable dt = new DataTable();
                dt = aOutdoorPatientManager.GetAllDoctorsById(DoctorId);
                searchLookUpDoctor.Properties.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    searchLookUpDoctor.Properties.DisplayMember = "DoctorName";searchLookUpDoctor.Properties.ValueMember = "DoctorID";

                    txtDoctorSpecialization.Text = dt.Rows[0]["Specialization"].ToString();
                    searchLookUpDoctor.Properties.NullValuePrompt = dt.Rows[0]["DoctorName"].ToString();
                    searchLookUpDoctor.Properties.DataSource = data;
                }
                
                if (DoctorId=="0" || DoctorId=="")
                {
                    //GetAllDoctors();
                    searchLookUpDoctor.Properties.DataSource = data;
                    searchLookUpDoctor.Properties.DisplayMember = "DoctorName";
                    searchLookUpDoctor.Properties.ValueMember = "DoctorID";
                }

                btnSave2.Text = "Update";
                btnDelete2.Enabled = true;


            }
            catch (Exception)
            {

                // throw;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "Are you sure to delete row?", "Confirmation Message",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dr == DialogResult.Yes)
                {
                    DAL.Model.OutdoorPatient aOutdoorPatient = new DAL.Model.OutdoorPatient();
                    aOutdoorPatient.Opid = txtOpid.Text;
                    MessageModel aMessageModel = new MessageModel();
                    aMessageModel = aOutdoorPatientManager.DeleteOutdoorPatient(aOutdoorPatient);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonValidation.IsNumberCheck(sender, e);
            if (e.KeyChar == '\r')
            {
                cmbBloodGroup.Focus();
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonValidation.IsNumberCheck(sender, e);
            
        }

        private void txtMobileContactPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonValidation.IsNumberCheck(sender, e);
            if (e.KeyChar == '\r')
            {
                cmbDoctorView.Focus();
            }
        }

        private void txtDoctorFees_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTreatmentType_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtGurdianName.Focus();
            }
        }

        private void txtGurdianName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtAddress.Focus();
            }

            if (checkBox1.Checked)
            {
                txtContactPerson.Text = txtGurdianName.Text;
            }
            txtContactPerson.Text = "";
        }

        private void cmbBloodGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '\r')
            //{
            //    cmbGender.Focus();
            //}
        }

        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '\r')
            //{
            //    cmbNationality.Focus();
            //}
        }

        private void cmbNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '\r')
            //{
            //    txtContactPerson.Focus();
            //}
        }

        private void txtContactPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtMobileContactPerson.Focus();
            }
        }

        private void searchLookUpDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtDoctorSpecialization.Focus();
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtContactPerson.Text = txtGurdianName.Text;
                txtMobileContactPerson.Text = txtPhone.Text;
            }
            else
            {
                txtContactPerson.Text = "";
                txtMobileContactPerson.Text = "";
            }
        }

        private void txtGurdianName_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtContactPerson.Text = txtGurdianName.Text;
            }
            txtContactPerson.Text = "";
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtMobileContactPerson.Text = txtPhone.Text;
            }
            txtMobileContactPerson.Text = "";
        }

        private void cmbTreatmentType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPatientName.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAge.Focus();
            }
        }

        private void cmbBloodGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
            }
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbNationality.Focus();
            }
        }

        private void cmbNationality_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRefferedBy.Focus();
            }
        }

        private void txtMobileContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchLookUpDoctor.Focus();
            }
        }

        private void searchLookUpDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDoctorSpecialization.Focus();
            }
        }

        private void txtDoctorSpecialization_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDoctorFees.Focus();
            }
        }

        private void txtDoctorFees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave2.Focus();
            }
        }

        private void OutdoorPatientUi_Load(object sender, EventArgs e)
        {
            PopulateGridView();
            GetAllDoctors();
            GeneratePatientId();
            GetRefferedInfo();
            btnDelete2.Enabled = false;
            btnSave2.Text = "Save";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtContactPerson.Text = txtGurdianName.Text;
                txtMobileContactPerson.Text = txtPhone.Text;
            }
            else
            {
                txtContactPerson.Text = "";
                txtMobileContactPerson.Text = "";
            }

        }

        public void GetRefferedIdByName()
        {
            DataTable data = new DataTable();

            data = new RefferedInfoManager().GetRefferedIdByName(cmbRefferedBy.DisplayMember);
            cmbRefferedBy.DataSource = data;
            cmbRefferedBy.DisplayMember = "Name";
            cmbRefferedBy.ValueMember = "Id";
        }

        public void GetRefferedInfo()
        {
            DataTable data = new DataTable();

            data = new RefferedInfoManager().PopulateGridView();

            cmbRefferedBy.DisplayMember = "Name";
            cmbRefferedBy.ValueMember = "Id";
            cmbRefferedBy.DataSource = data;
        }

        private void cmbRefferedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContactPerson.Focus();
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.Model.OutdoorPatient aOutdoorPatient = new DAL.Model.OutdoorPatient();
                aOutdoorPatient.Opid = txtOpid.Text;
                aOutdoorPatient.ServiceDate = fromDate.Value;
                if (cmbTreatmentType.Text == "All" || cmbTreatmentType.Text == "IPD" || cmbTreatmentType.Text == "Emergency" || cmbTreatmentType.Text == "Daycare" || cmbTreatmentType.Text == "Consultation")
                {
                    aOutdoorPatient.TreatementType = cmbTreatmentType.Text;
                }
                aOutdoorPatient.PatientName = txtPatientName.Text;
                aOutdoorPatient.GurdianName = txtGurdianName.Text;
                aOutdoorPatient.Address = txtAddress.Text;
                aOutdoorPatient.Phone = txtPhone.Text;


                if (!string.IsNullOrEmpty(txtAge.Text) && txtAge.Text != "")
                {
                    aOutdoorPatient.Age = Convert.ToInt32(txtAge.Text);
                }
                if (cmbBloodGroup.Text == "A+" || cmbBloodGroup.Text == "A-" || cmbBloodGroup.Text == "AB+" || cmbBloodGroup.Text == "AB-" || cmbBloodGroup.Text == "B+" || cmbBloodGroup.Text == "B-" || cmbBloodGroup.Text == "O+" || cmbBloodGroup.Text == "O-" || cmbBloodGroup.Text == "N/A")
                {
                    aOutdoorPatient.BloodGroup = cmbBloodGroup.Text;
                }
                if (cmbGender.Text == "Female" || cmbGender.Text == "Male" || cmbGender.Text == "Neuture")
                {
                    aOutdoorPatient.Gender = cmbGender.Text;
                }
           
                aOutdoorPatient.Nationality = cmbNationality.Text;
                aOutdoorPatient.ContactPerson = txtContactPerson.Text;
                aOutdoorPatient.Mobile = txtMobileContactPerson.Text;

                aOutdoorPatient.RefferedBy = string.IsNullOrEmpty(cmbRefferedBy.SelectedValue.ToString()) ? null : cmbRefferedBy.SelectedValue.ToString();

                aOutdoorPatient.AService = new Service();
                aOutdoorPatient.AService.OPID = txtOpid.Text;
                aOutdoorPatient.AService.ServiceId = "Serv-02";
                if (!string.IsNullOrEmpty(txtDoctorFees.Text))
                {
                    aOutdoorPatient.AService.Rate = Convert.ToDouble(txtDoctorFees.Text);
                }
                aOutdoorPatient.AService.Qty = 1;
                aOutdoorPatient.AService.IssueDate = DateTimeServiceDate.Value;
                aOutdoorPatient.ServiceDate = DateTimeServiceDate.Value;

                if (searchLookUpDoctor.Properties.View.GetFocusedRowCellValue("DoctorID") != null)
                {
                    aOutdoorPatient.Doctor = searchLookUpDoctor.Properties.View.GetFocusedRowCellValue("DoctorID").ToString();
                }
                aOutdoorPatient.Fees = txtDoctorFees.Text;

                if (btnSave2.Text == "Save")
                {
                    MessageModel aMessageModel = new MessageModel();
                    
                    aMessageModel = aOutdoorPatientManager.SaveOutdoorPatient(aOutdoorPatient);
                    if (aMessageModel.MessageTitle == "Successful")
                    {
                        MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageModel aMessageModel = new MessageModel();
                    aMessageModel = aOutdoorPatientManager.UpdateOutdoorPatient(aOutdoorPatient);
                    if (aMessageModel.MessageTitle == "Successful")
                    {
                        MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Refresh();
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageTitle, aMessageModel.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void picBoxAddRefferedBy_Click(object sender, EventArgs e)
        {
            RefferedUi refferedUi = new RefferedUi();
            refferedUi.ShowDialog(this);
            GetRefferedInfo();
        }

        private void picBoxSearch_Click_1(object sender, EventArgs e)
        {
            PopulateGridView();
        }


        private void picBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbRefferedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
