using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.Settings
{
    public partial class SubServiceSetup : Form
    {
        public SubServiceSetup()
        {
            InitializeComponent();
            LoadServices();
            SetNew();
        }
        private void SaveService()
        {
            try
            {
                if (txtRate.Text == "" || Convert.ToInt32(txtRate.Text) == 0)
                {
                    MessageBox.Show("Please enter the valid rate of this service!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblSubServices", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SSID", SqlDbType.Int);
                cmd.Parameters.Add("@SSName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@SSRate", SqlDbType.Float);
                cmd.Parameters.Add("@SSParent", SqlDbType.Int);

                cmd.Parameters[0].Value = txtID.Text;
                cmd.Parameters[1].Value = txtSSName.Text;
                cmd.Parameters[2].Value = txtRate.Text;
                cmd.Parameters[3].Value = cmbServices.SelectedValue;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Service save successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save service! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetNew()
        {
            txtID.Text = "";
            txtSSName.Text = "";
            txtRate.Text = "";

            GenerateID();
            LoadData();

            txtSSName.Focus();
        }
        private void LoadServices()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblServices";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbServices.DataSource = dt;
            cmbServices.DisplayMember = "ServiceName";
            cmbServices.ValueMember = "ID";
        }
        private void LoadData()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand ds = da.SelectCommand;
                ds.CommandText = "select* from tblSubServices where SSParent=@SSParent";
                ds.CommandType = CommandType.Text;

                ds.Parameters.Add("SSParent", SqlDbType.Int).Value = cmbServices.SelectedValue.ToString();

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
            }
            catch
            {
            }
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(SSID),0)+1 as SSID from tblSubServices";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtID.Text = dt.Rows[0]["SSID"].ToString();
            }
        }
        private void btnColse_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveService();
        }
        private void cmbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
