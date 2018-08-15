using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.Admin;

namespace GHospital_Care.Doctors
{
    public partial class Consultent_UI : Form
    {
        public Consultent_UI()
        {
            InitializeComponent();
            ActiveControl = txtDoctorname;
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }


        private void GenerateId()
        {
            var obcon = new Conn();
            var ob = new SqlConnection(obcon.strCon);
            var cmd = new SqlCommand("SP_GENERATE_DoctorId_tblConsult_Doctors", ob)
            {
                CommandType = CommandType.StoredProcedure
            };
            ob.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
            txtDoctorID.Text = reader[0].ToString();
        }

        private void LoadSpecializations()
        {
            var obcon = new Conn();
            var ob = new SqlConnection(obcon.strCon);
            var da = new SqlDataAdapter { SelectCommand = new SqlCommand { Connection = ob } };
            var ds = da.SelectCommand;
            ds.CommandText = "select * from tblDoctorSpecialization";
            ds.CommandType = CommandType.Text;
            var dt = new DataTable();
            da.Fill(dt);

            //cmbSpecialization.DataSource = dt;
            //cmbSpecialization.DisplayMember = "SpecializationName";
            //cmbSpecialization.ValueMember = "ID";
        }

        private void LoadData()
        {
            var obcon = new Conn();
            var ob = new SqlConnection(obcon.strCon);
            var da = new SqlDataAdapter { SelectCommand = new SqlCommand { Connection = ob } };
            var ds = da.SelectCommand;
            ds.CommandText = "select * from tblConsult_Doctors";
            ds.CommandType = CommandType.Text;
            var dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void SetNew()
        {
            txtAddress.Text = "";
            txtDoctorID.Text = "";
            txtDoctorname.Text = "";
            txtLicense.Text = "";
            txtMobile.Text = "";
            txtNickName.Text = "";
            txtNotes.Text = "";
            txtPhone.Text = "";
            dtDOB.Value = DateTime.Now;

            cmbGender.SelectedIndex = 0;

            btnSave.Text = "Save";//btnEdit.Enabled = false;

            GenerateId();
            LoadData();
            LoadSpecializations();
            CmbAcademicDegree.Text = "MBBS";
        }

        private void SaveDoctor()
        {
            try
            {
                var obCon = new Conn();
                var ob = new SqlConnection(obCon.strCon);
                var cmd = new SqlCommand("SP_SAVE_tblConsult_Doctors", ob) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@DoctorID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@DoctorName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@NickName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@License", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Specialization", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@AcademicDegree", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Notes", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtDoctorID.Text;
                cmd.Parameters[1].Value = txtDoctorname.Text;
                cmd.Parameters[2].Value = txtNickName.Text;
                cmd.Parameters[3].Value = cmbGender.Text;
                cmd.Parameters[4].Value = dtDOB.Text;
                cmd.Parameters[5].Value = txtAddress.Text;
                cmd.Parameters[6].Value = txtPhone.Text;
                cmd.Parameters[7].Value = txtMobile.Text;
                cmd.Parameters[8].Value = txtLicense.Text;
                cmd.Parameters[9].Value = cmbSpecialization.Text;
                cmd.Parameters[10].Value = CmbAcademicDegree.Text;
                cmd.Parameters[11].Value = txtNotes.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();
                MessageBox.Show(@"Doctor save successfully!", @"Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show(@"Failed to save doctor! " + error.Message.ToString(), @"Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Consultent_UI_Load(object sender, EventArgs e)
        {
            SetNew();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var obcon = new Conn();
                var ob = new SqlConnection(obcon.strCon);
                var da = new SqlDataAdapter { SelectCommand = new SqlCommand { Connection = ob } };
                var cmd = da.SelectCommand;
                cmd.CommandText = "Select * From tblConsult_Doctors where DoctorID=@DoctorID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@DoctorID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtDoctorID.Text = dt.Rows[0]["DoctorID"].ToString();
                    txtDoctorname.Text = dt.Rows[0]["DoctorName"].ToString();
                    txtLicense.Text = dt.Rows[0]["License"].ToString();
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                    txtNickName.Text = dt.Rows[0]["NickName"].ToString();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    cmbGender.Text = dt.Rows[0]["Gender"].ToString();
                    cmbSpecialization.Text = dt.Rows[0]["Specialization"].ToString();
                    dtDOB.Text = dt.Rows[0]["DateOfBirth"].ToString();
                    CmbAcademicDegree.Text = dt.Rows[0]["AcademicDegree"].ToString();

                    btnSave.Text = "Update";

                    //btnSave.Enabled = false;
                }
            }
            catch
            {
                // ignored
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveDoctor();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this row?", "Confirmation Message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string ConsultId = txtDoctorID.Text;

                var obCon = new Conn();
                var ob = new SqlConnection(obCon.strCon);
                var cmd = new SqlCommand("DELETE tblConsult_Doctors WHERE DoctorID='" + ConsultId + "'", ob);

                ob.Open();
                int rowAffect = cmd.ExecuteNonQuery();
                ob.Close();
                if (rowAffect > 0)
                {
                    MessageBox.Show(@"Information deleted successfully!", @"Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNew();}

            }
        }


    }
}
