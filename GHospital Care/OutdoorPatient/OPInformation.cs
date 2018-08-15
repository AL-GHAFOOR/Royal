using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Data.WcfLinq.Helpers;
using DevExpress.XtraRichEdit.API.Word;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.OutdoorPatient
{
    public partial class OPInformation : Form
    {
        Tools tools = new Tools();
        private Patient _patient;
        private OPD_Manager _opdManager;
        public OPInformation()
        {
            InitializeComponent();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this.panel9, this.Name);
            SetNew();
            time();
        }
        private void time()
        {
            timer1.Start();
            Time.Text = DateTime.Now.ToLongTimeString();

        }
        OPD_Manager opdManager = new OPD_Manager();
        private void InitialAllField()
        {
            _patient = new Patient();
            _patient.OPID = txtID.Text;
            _patient.ServiceDate = dateTimePicker1.Text;
            _patient.TreatmentType = TreatmentType.Text;
            _patient.Phone = txtPhone.Text;
            _patient.PatientName = txtName.Text;
            _patient.Gurdian = txtGurdianName.Text;
            _patient.Address = txtAddress.Text;
            _patient.Age = txtAge.Text;
            _patient.Gender = cmbGender.Text;
            _patient.BloodGroup = cmbBloodGroup.Text;
            _patient.Nationality = cmbNationality.Text;
            _patient.ContactPerson = txtContactPerson.Text;
            _patient.ContactPersonMobile = txtMobileContactPerson.Text;
            if ((string) cmbDoctor.EditValue != "Select Doctor")
            {
                _patient.Doctor = cmbDoctor.Properties.View.GetFocusedRowCellValue("DoctorID").ToString();
                _patient.Fees = txtDoctorFees.Text;
                
            }
        }
        private void SearchPatient(string PatientID)
        {
            try
            {
                DataTable dt = opdManager.SearchPatient(PatientID);
                if (dt.Rows.Count > 0)
                {
                    txtID.Text = dt.Rows[0]["OPID"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["ServiceDate"]);
                    TreatmentType.Text = dt.Rows[0]["TreatmentType"].ToString();

                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txtName.Text = dt.Rows[0]["PatientName"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    cmbDoctor.Properties.NullValuePrompt = dt.Rows[0]["Doctor"].ToString();
                    txtMobileContactPerson.Text = dt.Rows[0]["Mobile"].ToString();
                    cmbNationality.Text = dt.Rows[0]["Nationality"].ToString();
                    cmbBloodGroup.Text = dt.Rows[0]["BloodGroup"].ToString();
                    cmbGender.Text = dt.Rows[0]["Gender"].ToString();
                    txtContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();

                    //cmbBloodGroup.Properties.NullValuePrompt = dt.Rows[0]["Doctor"].ToString();



                    DataTable view = (DataTable)cmbDoctor.Properties.DataSource;
                    var data = view.AsEnumerable().FirstOrDefault(a => a["DoctorID"].ToString() == dt.Rows[0]["Doctor"].ToString());
                    cmbDoctor.Properties.NullValuePrompt = data["DoctorName"].ToString();
                    txtDoctorSpecialization.Text = data["Specialization"].ToString();
                    //.GetKeyValueByDisplayText("TheSelectedIndexYouWant");
                    //dt.Rows[0]["Doctor"].ToString();

                    txtDoctorFees.Text = dt.Rows[0]["Fees"].ToString();

                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
                    btnCreateBill.Enabled = true;
                    btnDelete.Enabled = true;
                    btnPrescription.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to load patient informations!" + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void SetNew()
        {
            txtAddress.Text = "";
            txtAge.Text = "";
            txtDoctorFees.Text = "";
            txtDoctorSpecialization.Text = "";
            txtID.Text = "";
            txtPhone.Text = "";
            txtName.Text = "";
            cmbNationality.Text = "";
            TreatmentType.Text = "";
            cmbBloodGroup.Text = "";
            cmbGender.Text = "";
            txtGurdianName.Clear();
            txtGurdianName.Clear();
            txtContactPerson.Clear();
            txtMobileContactPerson.Clear();
            txtDoctorSpecialization.Clear();
            cmbGender.SelectedIndex = -1;

            dateTimePicker1.Value = DateTime.Now;
            //cmbGender.SelectedIndex = 0;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnCreateBill.Enabled = false;
            btnDelete.Enabled = false;
            btnPrescription.Enabled = false;

            GenerateID();
            LoadData();
            LoadDoctors();
            // txtDoctorSpecialization.Text = cmbDoctor.SelectedValue.ToString();
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlCommand cmd = new SqlCommand("SP_GENERATE_OPID", ob);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader;
            ob.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
            txtID.Text = reader[0].ToString();
        }
        private void LoadDoctors()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select DoctorID, DoctorName, Specialization from tblDoctors";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);


            cmbDoctor.Properties.DataSource = dt;

            cmbDoctor.Properties.DisplayMember = "DoctorName";
            cmbDoctor.Properties.ValueMember = "DoctorID";
        }
        private void LoadData()
        {
            //Conn obcon = new Conn();
            //SqlConnection connection = new SqlConnection(obcon.strCon);
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //adapter.SelectCommand = new SqlCommand();
            //adapter.SelectCommand.Connection = connection;
            //SqlCommand command = adapter.SelectCommand;
            //command.CommandText = "select *  from tblOP where ServiceDate=Convert(date,@ServiceDate)";
            //command.CommandType = CommandType.Text;
            //command.Parameters.AddWithValue("@ServiceDate", dateTimePicker1.Value);
            //DataTable dt = new DataTable();.
            //adapter.Fill(dt);

            dataGridView1.DataSource = opdManager.GetAllValueAsToday();
            dataGridView1.AutoGenerateColumns = false;}

        //previous method 
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                SearchPatient(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                btnSave.Enabled = false;
                btnEdit.Enabled = true;//write here 
                btnDelete.Enabled = true;

            }
            catch
            {
            }
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Patient aPatient = new Patient();
                aPatient.OPID = txtID.Text;
                aPatient.ServiceDate = dateTimePicker1.Text;
                aPatient.TreatmentType = TreatmentType.Text;
                aPatient.Phone = txtPhone.Text;
                aPatient.PatientName = txtName.Text;
                aPatient.Address = txtAddress.Text;
                aPatient.Age = txtAge.Text;
                aPatient.Gender = cmbGender.Text; 
                aPatient.BloodGroup = cmbBloodGroup.Text;
                aPatient.Nationality = cmbNationality.Text;
                aPatient.Mobile = txtMobileContactPerson.Text;
                aPatient.Gurdian = txtGurdianName.Text;
                aPatient.ContactPerson = txtContactPerson.Text;
                aPatient.Fees = txtDoctorFees.Text;
                
                var doctor =cmbDoctor.Properties.View.GetFocusedRowCellValue("DoctorID");
                if (doctor != null)
                {
                    aPatient.Doctor = doctor.ToString();
                }
                else
                {
                    aPatient.Doctor = string.Empty;
                }
                //aPatient.Fees = txtDoctorFees.Text;
                MessageModel message = opdManager.UpdatePatient(aPatient);
                if (message.MessageTitle == "Warning")
                {
                    MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;}
                else
                {
                    MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save patient! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SetNew();
        }
        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            OutdoorPatient.OutpatientBilling frm = new OutpatientBilling(txtID.Text);
            frm.Show();
        }

        private void txtMobileContactPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtAddress.Focus();
            }
           // Patient aPatient=new Patient();
            //CommonValidation.IsPhoneNumber(aPatient.Mobile);//CommonValidation.IsNumberCheck(sender, e);
        }private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _patient = new Patient();
                _patient.OPID = txtID.Text;
                _opdManager = new OPD_Manager();
                _opdManager.DeletePatient(_patient); SetNew();
            }
            else
            {
                //nothing to do 
            }


            //LoadData();

            //DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message", MessageBoxButtons.YesNo);
            //if (dr == DialogResult.Yes)
            //{
            //    _patient.OPID = txtID.Text;

            //    MessageModel messageModel = new OPD_Manager().PatientCreate(_patient);
            //    _opdManager=new OPD_Manager();

            //    string message = -opdManager.DeletePatient();
            //    MessageBox.Show(message);

            //    ResetAllData();
            //    PopulateCategoriesListView();
            //}
            //else
            //{
            //    //Nothing to do
            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Patient aPatient=new Patient();

            //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //txtID.Text = row.Cells["Phone"].ToString();
            //txtName.Text = row.Cells["Phone"].ToString();
            //txtPhone.Text = row.Cells["Phone"].ToString();
            //cmbDoctor.Properties.NullValuePrompt = row.Cells["Phone"].ToString();
            ////dateTimePicker1.Text = row.Cells["Phone"].ToString();
            //TreatmentType.Text = row.Cells["Phone"].ToString();
            //txtMobileContactPerson.Text = row.Cells["Phone"].ToString();
            //txtAddress.Text = row.Cells["Phone"].ToString();
            //cmbGender.Text = row.Cells["Phone"].ToString();
            //txtAge.Text = row.Cells["Phone"].ToString();
            //cmbNationality.Text = row.Cells["Phone"].ToString();


            //string patientId = _patient.OPID;
            //DataTable dt = opdManager.SearchPatient(patientId);
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //DataRow row=dataGridView1 as 
            //string testVaue = row.Cells["Phone"].ToString();
            //txtID.Text = row.Cells["OPID"].Value.ToString();
            //TreatmentType.Text = row.Cells["PatientName"].Value.ToString();
            //txtPhone.Text = row.Cells["Mobile"].Value.ToString();
            //cmbDoctor.Properties.NullValuePrompt = row.Cells["Doctor"].Value.ToString();
            //txtGurdianName.Text = row.Cells[""].Value.ToString();
            //txtAddress.Text = row.Cells["Address"].Value.ToString();
            //txtAge.Text = row.Cells["Age"].Value.ToString();
            //cmbGender.Text = row.Cells["Gender"].Value.ToString();
            //cmbBloodGroup.Text = row.Cells["BloodGroup"].Value.ToString();
            //txtNationality.Text = row.Cells["Nationality"].Value.ToString();

            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    txtID.Text = dt.Rows[0]["OPID"].ToString();
            //    dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["ServiceDate"]);
            //    txtPhone.Text = dt.Rows[0]["Phone"].ToString();

            //    DataTable view = (DataTable)cmbDoctor.Properties.DataSource;
            //    var data = view.AsEnumerable().FirstOrDefault(a => a["DoctorID"].ToString() == dt.Rows[0]["Doctor"].ToString());
            //    cmbDoctor.Properties.NullValuePrompt = data["DoctorName"].ToString();
            //    txtDoctorSpecialization.Text = data["Specialization"].ToString();
            //.GetKeyValueByDisplayText("TheSelectedIndexYouWant");

            //= dt.Rows[0]["Doctor"].ToString();
            //        txtDoctorFees.Text = dt.Rows[0]["Fees"].ToString();

            //        btnSave.Enabled = false;
            //        btnEdit.Enabled = true;
            //        btnCreateBill.Enabled = true;
            //        btnDelete.Enabled = true;
            //        btnPrescription.Enabled = true;
            //    }
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show("Failed to load patient informations!" + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            //}
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                InitialAllField();
                MessageModel messageModel = new OPD_Manager().PatientCreate(_patient);



                MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save patient! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDoctorSpecialization.Text = cmbDoctor.Properties.View.GetFocusedRowCellValue("Specialization").ToString();
            txtDoctorFees.Text = "350.00";
        }
        // comment 
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                cmbGender.Focus();
            }
        }
        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtAge.Focus();
            }
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtPhone.Focus();}
           // Patient aPatient=new Patient();
            //CommonValidation.IsNumberCheck(sender, e);
            //CommonValidation.IsPhoneNumber(aPatient.Phone);
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtPhone.Focus();
            }

        }
        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtNationality.Focus();
            } CommonValidation.IsNumberCheck(sender, e);
        }
        private void txtDoctorFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            CommonValidation.IsNumberCheck(sender, e);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        //previouse method 
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //    //if (Cell != null)
            //    //{

            //    //}
            //    txtID.Text = row.Cells["OPID"].Value.ToString();
            //    TreatmentType.Text = row.Cells["TreatmentTyp"].Value.ToString();
            //    txtPhone.Text = row.Cells["Phone"].Value.ToString();
            //    txtName.Text = row.Cells["PatientName"].Value.ToString();
            //    cmbDoctor.Properties.NullValuePrompt = row.Cells["Doctor"].ToString();
            //    txtMobileContactPerson.Text = row.Cells["Mobile"].ToString();
            //    txtAddress.Text = row.Cells["Address"].ToString();

            //}
        }


    }
}