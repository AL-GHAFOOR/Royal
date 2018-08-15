using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.Pathology
{
    public partial class UrineExamine : Form
    {
        public UrineExamine()
        {
            InitializeComponent();
            SetNew();
        }
        private void SetNew()
        {
            txtAge.Text = "";
            txtBilePigmant.Text = "";
            txtBileSalts.Text = "";
            txtCS.Text = "";
            txtdate.Text = "";
            txtPatientName.Text = "";
            txtPregnancy.Text = "";
            txtRE.Text = "";
            txtRptNo.Text = "";
            txtUrbilinogcn.Text = "";

            cmbGender.SelectedIndex = 0;

            LoadLabs();
            LoadDoctors();
            LoadPathologist();
            GenerateID();
        }
        private void CreateReport()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblUltraSonography", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ReportNo", SqlDbType.Int);
                cmd.Parameters.Add("@ReportDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Lab", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Age", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ReferredDoctor", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@TestedBy", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@RE", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@CS", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Pregnancy", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BileSalts", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BilePigment", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Urobilinogcn", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtRptNo.Text;
                cmd.Parameters[1].Value = txtdate.Text;
                cmd.Parameters[2].Value = cmbLab.Text;
                cmd.Parameters[3].Value = txtPatientName.Text;
                cmd.Parameters[4].Value = txtAge.Text;
                cmd.Parameters[5].Value = cmbGender.Text;
                cmd.Parameters[6].Value = cmbDoctor.Text;
                cmd.Parameters[7].Value = cmbPathologist.Text;
                cmd.Parameters[8].Value = txtRE.Text;
                cmd.Parameters[9].Value = txtCS.Text;
                cmd.Parameters[10].Value = txtPregnancy.Text;
                cmd.Parameters[11].Value = txtBileSalts.Text;
                cmd.Parameters[12].Value = txtBilePigmant.Text;
                cmd.Parameters[13].Value = txtUrbilinogcn.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Failed to create report! "+error.Message.ToString(),"Failed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void LoadPathologist()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblPathologist";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbPathologist.DataSource = dt;
            cmbPathologist.DisplayMember = "PathologistName";
            cmbPathologist.ValueMember = "ID";
        }
        private void LoadLabs()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblLabs";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbLab.DataSource = dt;
            cmbLab.DisplayMember = "LabName";
            cmbLab.ValueMember = "ID";
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

            cmbDoctor.DataSource = dt;
            cmbDoctor.DisplayMember = "DoctorName";
            cmbDoctor.ValueMember = "DoctorID";
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(ReportNo),0)+1 as ReportNo from tblUltraSonography";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtRptNo.Text = dt.Rows[0]["ReportNo"].ToString();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
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
                cmbGender.Focus();
            }
        }
        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                cmbDoctor.Focus();
            }
        }
        private void cmbDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                cmbPathologist.Focus();
            }
        }
        private void cmbPathologist_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtRE.Focus();
            }
        }
        private void txtRE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtCS.Focus();
            }
        }
        private void txtCS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtPregnancy.Focus();
            }
        }
        private void txtPregnancy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtBileSalts.Focus();
            }
        }
        private void txtBileSalts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtBilePigmant.Focus();
            }
        }
        private void txtBilePigmant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtUrbilinogcn.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CreateReport();
        }
    }
}
