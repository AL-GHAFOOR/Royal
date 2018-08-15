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
    public partial class BloodGroupTest : Form
    {
        public BloodGroupTest()
        {
            InitializeComponent();
            SetNew();
        }
        private void SetNew()
        {
            txtAge.Text = "";
            txtdate.Text = "";
            txtPatientName.Text = "";
            txtRptNo.Text = "";

            cmbABOType.SelectedIndex = 0;
            cmbRh.SelectedIndex = 0;

            cmbGender.SelectedIndex = 0;

            btnCreateReport.Enabled = true;

            LoadLabs();
            LoadDoctors();
            LoadPathologist();
            GenerateID();
        }
        private void CreateReport()
        {
            try
            {
                if (cmbABOType.SelectedIndex == 0)
                {
                    MessageBox.Show("You must select ABO type!","Required",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (cmbRh.SelectedIndex == 0)
                {
                    MessageBox.Show("You must select Rh type!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblBloodGrouping", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ReportNo", SqlDbType.Int);
                cmd.Parameters.Add("@ReportDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Lab", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Age", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ReferredDoctor", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@TestedBy", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ABOType", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@RhType", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtRptNo.Text;
                cmd.Parameters[1].Value = txtdate.Text;
                cmd.Parameters[2].Value = cmbLab.Text;
                cmd.Parameters[3].Value = txtPatientName.Text;
                cmd.Parameters[4].Value = txtAge.Text;
                cmd.Parameters[5].Value = cmbGender.Text;
                cmd.Parameters[6].Value = cmbDoctor.Text;
                cmd.Parameters[7].Value = cmbPathologist.Text;
                cmd.Parameters[8].Value = cmbABOType.Text;
                cmd.Parameters[9].Value = cmbRh.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                ReportViewer.BloodGroup frm = new GHospital_Care.ReportViewer.BloodGroup(txtRptNo.Text);
                frm.Show();
                btnCreateReport.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to create report! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            cmd.CommandText = "Select isnull(max(ReportNo),0)+1 as ReportNo from tblBloodGrouping";
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
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            CreateReport();
        }
    }
}
