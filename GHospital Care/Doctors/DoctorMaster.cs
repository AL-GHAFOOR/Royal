using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GHospital_Care.Admin;

namespace GHospital_Care.Doctors
{
    public partial class DoctorMaster : Form
    {
        public DoctorMaster()
        {
            InitializeComponent();
            SetNew();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }
        private void SaveDoctor()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblDoctors", ob);

                cmd.CommandType = CommandType.StoredProcedure;

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
                cmd.Parameters[10].Value = txtNotes.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Doctor save successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save doctor! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            btnSave.Enabled = true;
            btnEdit.Enabled = false;

            GenerateID();
            LoadData();
            LoadSpecializations();
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlCommand cmd = new SqlCommand("SP_GENERATE_DOCTORID", ob);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader;
            ob.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
            txtDoctorID.Text = reader[0].ToString();
        }
        private void LoadSpecializations()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblDoctorSpecialization";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbSpecialization.DataSource = dt;
            cmbSpecialization.DisplayMember = "SpecializationName";
            cmbSpecialization.ValueMember = "ID";
        }
        private void LoadData()
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

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDoctor();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveDoctor();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblDoctors where DoctorID=@DoctorID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@DoctorID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                DataTable dt = new DataTable();
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

                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
            catch
            {
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
    }
}
