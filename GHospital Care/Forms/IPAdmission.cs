using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.IndoorPatient
{
    public partial class IPAdmission : Form
    {
        Tools tools = new Tools();
        public IPAdmission()
        {
            InitializeComponent();
            GetAllIpdPatient();
            GetIpdAllDutyDoctor();
            LoadBeds();
            GetAllCabin();
            GetAllWard();
            string t = atime.ToString();
            //GenerateReg();
        }

        private TimeSpan atime = System.DateTime.Today.TimeOfDay;
        private void GenerateReg()
        {
            DataTable dt = new IpdManager().GetIpRegID();
            txtReg.Text = dt.Rows[0][0].ToString() ;
        }
        
        private void GetIpdAllDutyDoctor()
        {
           
            cmbDutydoctor.DataSource = new IpdManager().GetIpdAllDutyDoctor();
            cmbDutydoctor.DisplayMember = "DoctorName";
            cmbDutydoctor.ValueMember = "DoctorID";

        }

        private void SearchIP(){
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "SELECT* FROM tblIP where IPID=@IPID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IPID", SqlDbType.VarChar, 50);
                //cmd.Parameters[0].Value = txtID.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    //  txtID.Text = dt.Rows[0]["IPID"].ToString();
                    txtPhone.Text = dt.Rows[0]["Mobile"].ToString();
                    txtName.Text = dt.Rows[0]["PatientName"].ToString();
                    txtGurdian.Text = dt.Rows[0]["Nationality"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();

                    //  cmbBed.Text = dt.Rows[0]["Bed"].ToString();
                   // cmbDoctor.Text = dt.Rows[0]["Doctor"].ToString();
                    cmbGender.Text = dt.Rows[0]["Gender"].ToString();
                   // cmbRoom.Text = dt.Rows[0]["Room"].ToString();
                   // cmbWard.Text = dt.Rows[0]["Ward"].ToString();

                    dateTimePicker1.Text = dt.Rows[0]["AdmissionDate"].ToString();
                }
            }
            catch
            {
            }
        }
        private void SetBedBusy()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("UPDATE tblBed SET Status=@Status WHERE ID=@ID", ob);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50);

                //cmd.Parameters[0].Value = cmbBed.SelectedValue;
                cmd.Parameters[1].Value = "Busy";
                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to set bed to busy ! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void UpdatePatient()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_UPDATE_tblOP", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IPID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Age", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Nationality", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Doctor", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Ward", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Room", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Bed", SqlDbType.VarChar, 50);

                // cmd.Parameters[0].Value = txtID.Text;
                cmd.Parameters[1].Value = tools.Today;
                cmd.Parameters[2].Value = txtName.Text;
                cmd.Parameters[3].Value = txtAddress.Text;
                cmd.Parameters[4].Value = cmbGender.Text;
                cmd.Parameters[5].Value = txtAge.Text;
                cmd.Parameters[6].Value = txtPhone.Text;
                cmd.Parameters[7].Value = txtPhone.Text;
                cmd.Parameters[8].Value = txtGurdian.Text;
               // cmd.Parameters[9].Value = cmbDoctor.Text;
                //cmd.Parameters[10].Value = cmbWard.Text; cmd.Parameters[11].Value = cmbRoom.Text;
                //cmd.Parameters[12].Value = cmbBed.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Indoor patient information updated successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to update patient! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetNew()
        {
            txtAddress.Text = "";
            txtAge.Text = "";
            //txtID.Text = "";
            txtPhone.Text = "";
            txtName.Text = "";
            txtGurdian.Text = "";
            txtPhone.Text = "";

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnCreateBill.Enabled = false;
            btnDelete.Enabled = false;
            btnPrescription.Enabled = false;

            GenerateID();
            LoadData();
            LoadDoctors();
            GetAllWard(); 
            LoadRooms();
          

        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlCommand cmd = new SqlCommand("SP_GENERATE_IPID", ob);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader;
            ob.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
           }
        private void LoadData()
        {
            IndoorPatientRegGridControl.DataSource = new IpdManager().GetAllIpAdmissionInfo();
            GetAllWard();
            //gridView1.SourceView.DataSource = new IpdManager().GetAllIpAdmissionInfo();
        }

        private void LoadDoctors()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblDoctors";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

           // cmbDoctor.DataSource = dt;
            //cmbDoctor.DisplayMember = "DoctorName";
           // cmbDoctor.ValueMember = "Specialization";
        }
        private void GetAllWard()
        {
            IpdManager aIpdManager = new IpdManager();
            cmbwardCabin.DataSource = aIpdManager.GetAllWard();
            cmbwardCabin.DisplayMember = "WardName";
            cmbwardCabin.ValueMember = "ID";
        }

        private void LoadRooms()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand ds = da.SelectCommand;
                ds.CommandText = "select* from tblRooms where WardNo=@WardNo";
                ds.CommandType = CommandType.Text;
                // ds.Parameters.Add("@WardNo", SqlDbType.Int).Value = cmbWard.SelectedValue;
                
                DataTable dt = new DataTable();
                da.Fill(dt);

         }
            catch(Exception)
            {
            }
        }
        public void WardOrCabin()
        {
            if (chkCabin.Checked)
            {
                GetAllWard();
            }
            else
            {
                GetAllCabin();
            }
        }
        private void GetAllCabin()
        {
            IpdManager aIpdManager = new IpdManager();
            cmbwardCabin.DataSource = aIpdManager.GetAllCabin();
            cmbwardCabin.DisplayMember = "CabinName";
            cmbwardCabin.ValueMember = "Id";
        }
        private void LoadBeds()
        {
            
            IpdManager aIpdManager = new IpdManager();
            txtseletedBed.DataSource = aIpdManager.GetAllBeds(cmbwardCabin.Text);
            txtseletedBed.DisplayMember = "BedName";
            txtseletedBed.ValueMember = "BedId";

            //try
            //{
            //    Conn obcon = new Conn();
            //    SqlConnection ob = new SqlConnection(obcon.strCon);
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    da.SelectCommand = new SqlCommand();
            //    da.SelectCommand.Connection = ob;
            //    SqlCommand ds = da.SelectCommand;
            //    //ds.CommandText = "select* from tblBed where Ward=@Ward and Room=@Room and Status='Free'";
            //    ds.CommandText = "select * from ViewAllBeds";
            //    ds.CommandType = CommandType.Text;

            //    DataTable dt = new DataTable();
            //    da.Fill(dt);

            //    txtseletedBed.DataSource = dt;
            //    txtseletedBed.DisplayMember = "BedName";
            //    txtseletedBed.ValueMember = "ID";
            //}
            //catch
            //{
            //}
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try
            //{
            //    txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    SearchIP();
            //}
            //catch
            //{
            //}
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //id=pidSearchLookUpEdit.Properties.View.GetFocusedDisplayText();
            Patient patient = new Patient();
           Service service = new Service();

            patient.OPID = pidSearchLookUpEdit.Properties.View.GetFocusedDisplayText();
            patient.PatientName = txtName.Text;
            patient.FatherName = txtFatherName.Text;
            patient.MotherName = txtMother.Text;
            patient.Address = txtAddress.Text;
            patient.Age = txtAge.Text;
            patient.Mobile = txtAge.Text;
            patient.Gurdian = txtGurdian.Text;
            patient.Phone = txtPhone.Text;
            patient.Relation = txtRelation.Text;
            patient.Gender = cmbGender.Text;
            patient.BloodGroup = txtbloodGroup.Text;
            patient.Religion = cmbReligion.Text;
            patient.AdmissionTime = admissionTime.Value;
            patient.RefferedBy = cmbRefferBy.Text;
            patient.Doctor = txtPrimaryDoctor.Text;
            patient.Department = cmbDepartment.Text;
            patient.PatientCondition = txtPinformation.Text;
            patient.RegNo = txtReg.Text;
            patient.WardOrCabin = "";
            patient.Weight = txtWeight.Text;
            patient.Nationality = txtNationality.Text;
            var bed = txtseletedBed.SelectedValue;
            patient.SelectedBed = "";
            if (bed != null)
            {
                patient.SelectedBed = bed.ToString();
            }
            patient.InputDate = dateTimePicker1.Value;
            patient.DutyDoctorId = cmbDutydoctor.SelectedValue.ToString();
            patient.Doctor = txtPrimaryDoctor.Text;
            patient.RefferedBy = cmbRefferBy.Text;
            patient.RegNo = txtReg.Text;
            
            service.OPID = pidSearchLookUpEdit.Properties.View.GetFocusedDisplayText();
            service.ServiceId = "Serv-01";
            service.Rate = Convert.ToDouble(txtRegFf.Text);
            service.Total = Convert.ToDouble(txtRegFf.Text);
            service.Qty=1;
            service.IssueDate = dateTimePicker1.Value;
            
            MessageModel message = new IpdManager().SaveIpdPatient(patient, service);
            MessageBox.Show(message.MessageBody,message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
            GetAllIpdPatient();
            LoadData();
        }

        private void focus(object sender, KeyPressEventArgs e, TextBox text, ComboBox cmb)
        {
            if (e.KeyChar == 13 && text!= null )
            {
                text.Focus();
            }
            else if (e.KeyChar == 13 && cmb != null)
            {
                cmb.Focus();
            }
        }

        private void chkWard_CheckedChanged(object sender, EventArgs e)
        {
            WardOrCabin();
        }
        private void chkCabin_CheckedChanged(object sender, EventArgs e)
        {
            WardOrCabin();
        }
        private void cmbwardCabin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkCabin.Checked)
            {
                txtseletedBed.Enabled = true;
                txtseletedBed.Text = "";
                LoadBeds();
            }
            else
            {
                txtseletedBed.DataSource = null;
                txtseletedBed.Enabled = false;

            }
        }
        private void btnNew_Click_1(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            
            txtName.Clear();
            txtFatherName.Clear();
            txtMother.Clear();
            txtAddress.Clear();
            txtAge.Clear();
            txtPhone.Clear();
            txtGurdian.Clear();
            txtRelation.Clear();
            cmbGender.Clear();
            txtbloodGroup.Clear();
            txtWeight.Clear();
            cmbRefferBy.Clear();

            txtPrimaryDoctor.Clear();
            txtPinformation.Clear();
            cmbDepartment.Clear();
            txtNationality.Clear();
            txtReg.Clear();

            GetAllIpdPatient();
            //GetAllIpdPatient();

            //pidSearchLookUpEdit.Text = "---Select---";
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            //flag = false;
            pidSearchLookUpEdit.Enabled = true;
           
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            //patient.OPID = pidSearchLookUpEdit.Properties.View.GetFocusedDisplayText();
            //patient.OPID = pidSearchLookUpEdit.EditValue.ToString();
            patient.OPID = pidSearchLookUpEdit.Properties.NullValuePrompt;
            patient.PatientName = txtName.Text;
            patient.FatherName = txtFatherName.Text;
            patient.MotherName = txtMother.Text;
            patient.Address = txtAddress.Text;
            patient.Age = txtAge.Text;
            patient.Mobile = txtPhone.Text;
            patient.Gurdian = txtGurdian.Text;
            patient.Phone = txtPhone.Text;
            patient.Relation = txtRelation.Text;
            patient.Gender = cmbGender.Text;
            patient.BloodGroup = txtbloodGroup.Text;
            patient.Religion = cmbReligion.Text;
            patient.RefferedBy = cmbRefferBy.Text;
            patient.Department = cmbDepartment.Text;

            patient.Weight = txtWeight.Text;
            patient.Nationality = txtNationality.Text;

            patient.InputDate = dateTimePicker1.Value;
            patient.DutyDoctorId = cmbDutydoctor.SelectedValue.ToString();
            patient.Doctor = txtPrimaryDoctor.Text;
            patient.RefferedBy = cmbRefferBy.Text;
            MessageModel message = new IpdManager().UpdateAdmissionPatient(patient);
            MessageBox.Show(message.MessageTitle, message.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                flag = true;
                //hiddinLabel.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                pidSearchLookUpEdit.Properties.NullValuePrompt = gridView1.GetFocusedRowCellValue("OPID").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("PatientName").ToString();
                txtFatherName.Text = gridView1.GetFocusedRowCellValue("FatherName").ToString();
                txtMother.Text = gridView1.GetFocusedRowCellValue("MotherName").ToString();
                txtAddress.Text = gridView1.GetFocusedRowCellValue("Address").ToString();
                txtAge.Text = gridView1.GetFocusedRowCellValue("Age").ToString();
                txtPhone.Text = gridView1.GetFocusedRowCellValue("Phone").ToString();
                txtGurdian.Text = gridView1.GetFocusedRowCellValue("Gurdian").ToString();
                txtRelation.Text = gridView1.GetFocusedRowCellValue("Relation").ToString();
                txtNationality.Text = gridView1.GetFocusedRowCellValue("Nationality").ToString();
                cmbRefferBy.Text = gridView1.GetFocusedRowCellValue("RefferedBy").ToString();
                txtPrimaryDoctor.Text = gridView1.GetFocusedRowCellValue("Doctor").ToString();
                txtPinformation.Text = gridView1.GetFocusedRowCellValue("paitentConditon").ToString();
                cmbDepartment.Text = gridView1.GetFocusedRowCellValue("Department").ToString();
                cmbDutydoctor.Text = gridView1.GetFocusedRowCellValue("DutyDoctorId").ToString();
                cmbGender.Text = gridView1.GetFocusedRowCellValue("Gender").ToString();
                txtbloodGroup.Text = gridView1.GetFocusedRowCellValue("BloodGroup").ToString();
                txtWeight.Text = gridView1.GetFocusedRowCellValue("Weight").ToString();
                cmbReligion.Text = gridView1.GetFocusedRowCellValue("Religion").ToString();
                cmbwardCabin.Text = gridView1.GetFocusedRowCellValue("WardOrCabin").ToString();
                txtseletedBed.Text = gridView1.GetFocusedRowCellValue("SelectedBed").ToString();


                pidSearchLookUpEdit.Enabled = false;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                new MailServer.MailServerConnection().SentMail(ex.GetBaseException().ToString());
                
                }
         
        }
        //private void txtID_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (flag == false)
        //    {
        //        string slNo = txtID.Properties.View.GetFocusedRowCellValue("OPID").ToString();

        //        Patient patientInformation = new OPD_Manager().GetPatientInformationBySl(slNo);

        //        txtName.Text = patientInformation.PatientName;
        //        txtAddress.Text = patientInformation.Address;
        //        txtPhone.Text = patientInformation.Mobile;
        //        txtbloodGroup.Text = patientInformation.BloodGroup;
        //        txtAge.Text = patientInformation.Age;
        //        cmbRefferBy.Text = patientInformation.Doctor;
        //        txtPrimaryDoctor.Text = patientInformation.Doctor;
        //        txtNationality.Text = patientInformation.Nationality;
        //        cmbGender.Text = patientInformation.Gender;
        //    }
        //}
        private void IPAdmission_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void IpdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IpdComboBox.DataSource = new IpdManager().GetAllIpAdmissionInfo2();


            //var comboBoxValue = IpdComboBox.ValueMember.ToString();

            ////Patient patientInformation = new OPD_Manager().GetPatientInformationBySl(comboBoxValue);
            //Patient patientInformation = new IpdManager().GetAllIpAdmissionInfo2(comboBoxValue);

            //txtName.Text = patientInformation.PatientName;
            //txtAddress.Text = patientInformation.Address;
            //txtPhone.Text = patientInformation.Mobile;
            //txtbloodGroup.Text = patientInformation.BloodGroup;
            //txtAge.Text = patientInformation.Age;
            //cmbRefferBy.Text = patientInformation.Doctor;
            //txtPrimaryDoctor.Text = patientInformation.Doctor;
            //txtNationality.Text = patientInformation.Nationality;
            //cmbGender.Text = patientInformation.Gender;


            //if (IpdComboBox.SelectedIndex<0)
            //{
            //    IpdComboBox.Text = "Please, Select any patient.";
            //}
            //else{
            //    IpdComboBox.Text = IpdComboBox.SelectedIndex.ToString();
            //}
        }
        private void GetAllIpdPatient()
        {
            pidSearchLookUpEdit.Properties.DataSource = null;
            pidSearchLookUpEdit.Properties.DataSource = new IpdManager().GetIpdAllIpdPatient();

            pidSearchLookUpEdit.Properties.ValueMember = "OPID";
            pidSearchLookUpEdit.Properties.DisplayMember = "PatientName";
        }

        /// <summary>
        /// 
        /// </summary>
        private bool flag = false; public object id;
        private void pidSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            id = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtName.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
            cmbGender.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Gender").ToString();
            txtAge.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Age").ToString();
            txtAddress.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Address").ToString();
            txtbloodGroup.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("BloodGroup").ToString();
            txtPhone.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Phone").ToString();
            txtNationality.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Nationality").ToString();
            txtPrimaryDoctor.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("DoctorName").ToString();
            GenerateReg();
            txtFatherName.Clear();
            txtMother.Clear();
            txtWeight.Clear();
            txtGurdian.Clear();
            txtRelation.Clear();
            cmbRefferBy.Clear();
            cmbDepartment.Clear();
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pidSearchLookUpEdit.Properties.NullValuePrompt))
            {
                MessageBox.Show("Patient not found!");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Patient aPatient = new Patient();
                aPatient.OPID = pidSearchLookUpEdit.Properties.NullValuePrompt;

                MessageModel message = new IpdManager().DeleteAdmitedPatient(aPatient);
                MessageBox.Show(message.MessageTitle, message.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                LoadData();

            }
            else
            {
                //Nothing to do
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtFatherName, null);
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtMother, null);
        }

        private void txtMother_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtAddress, null);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAge.Focus();
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtPhone, null);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtGurdian, null);
        }

        private void txtGurdian_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtRelation, null);
        }

        private void txtRelation_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtNationality, null);
        }

        private void txtNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtWeight, null);
        }

        private void cmbRefferBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtPinformation, null);
        }


        private void cmbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, null, cmbDutydoctor);
        }

        private void txtPinformation_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, cmbDepartment, null);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, null, cmbReligion);
        }

        private void cmbReligion_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, cmbRefferBy, null);
        }

        private void rdFree_CheckedChanged(object sender, EventArgs e)
        {
            ChkFreeOccupied();
            GetBadorCabin();
        }
        private void GetBadorCabin()
        {
            DataTable dt = new BedHistoryManager().GetFreeOccupiedBed(FreeOccupied, cmbWardorCabin.Text);
            gridControl2.DataSource = dt;
            //txtReg.Text = dt.Rows[0][0].ToString();
            
        }

        public string FreeOccupied = "";
        private void ChkFreeOccupied()
        {
            if (cmbWardorCabin.Text == "All Cabin" && rdFree.Checked == true)
            {
                FreeOccupied = "C_Free";
            }
            else if (cmbWardorCabin.Text == "All Cabin" && rdOccupied.Checked == true)
            {
                FreeOccupied = "C_Occupied";
            }
            else if (cmbWardorCabin.Text == "All Ward" && rdOccupied.Checked == true)
            {
                FreeOccupied = "B_Occupied";
            }
            else if (cmbWardorCabin.Text == "All Ward" && rdFree.Checked == true)
            {
                FreeOccupied = "B_Free";
            }
        }

        private void cmbWardorCabin_SelectedIndexChanged(object sender, EventArgs e)
        {ChkFreeOccupied();
            GetBadorCabin();
        }

        private void rdOccupied_CheckedChanged(object sender, EventArgs e)
        {
            ChkFreeOccupied();
            GetBadorCabin();
        }

        private void txtseletedBed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
