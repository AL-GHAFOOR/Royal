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
    public partial class FebrilAntigen : Form
    {
        public FebrilAntigen()
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

            txtAH.Text = "";
            txtBH.Text = "";
            txtOX19.Text = "";
            txtOX2.Text = "";
            txtOXK.Text = "";
            txtTH.Text = "";
            txtTO.Text = "";

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
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblFebrilAntigen", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ReportNo", SqlDbType.Int);
                cmd.Parameters.Add("@ReportDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Lab", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Age", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@RefferedBy", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@TestBy", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@_TO", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@TH", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@AH", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BH", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PRO_OXK", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PRO_OX2", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PRO_OX19", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtRptNo.Text;
                cmd.Parameters[1].Value = txtdate.Text;
                cmd.Parameters[2].Value = cmbLab.Text;
                cmd.Parameters[3].Value = txtPatientName.Text;
                cmd.Parameters[4].Value = txtAge.Text;
                cmd.Parameters[5].Value = cmbGender.Text;
                cmd.Parameters[6].Value = cmbDoctor.Text;
                cmd.Parameters[7].Value = cmbPathologist.Text;
                cmd.Parameters[8].Value = txtTO.Text;
                cmd.Parameters[9].Value = txtTH.Text;
                cmd.Parameters[10].Value = txtAH.Text;
                cmd.Parameters[11].Value = txtBH.Text;
                cmd.Parameters[12].Value = txtOXK.Text;
                cmd.Parameters[13].Value = txtOX2.Text;
                cmd.Parameters[14].Value = txtOX19.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                ReportViewer.FebrilAntigenViewer frm = new GHospital_Care.ReportViewer.FebrilAntigenViewer(txtRptNo.Text);
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
            cmd.CommandText = "Select isnull(max(ReportNo),0)+1 as ReportNo from tblFebrilAntigen";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtRptNo.Text = dt.Rows[0]["ReportNo"].ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            CreateReport();
        }
        private void txtTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtTH.Focus();
            }
        }
        private void txtTH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtAH.Focus();
            }
        }
        private void txtAH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtBH.Focus();
            }
        }
        private void txtBH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtOXK.Focus();
            }
        }
        private void txtOXK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtOX2.Focus();
            }
        }
        private void txtOX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtOX19.Focus();
            }
        }
    }
}
