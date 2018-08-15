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

namespace GHospital_Care.Settings
{
    public partial class Labs : Form
    {
        public Labs()
        {
            InitializeComponent();
            SetNew();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }
        private void SaveLabs()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblLabs", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@LabName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtID.Text;
                cmd.Parameters[1].Value = txtName.Text;
                cmd.Parameters[2].Value = txtDescription.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Lab save successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save lab! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetNew()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";

            GenerateID();
            LoadData();

            txtName.Focus();

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void LoadData()
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

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(ID),0)+1 as ID from tblLabs";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtID.Text = dt.Rows[0]["ID"].ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLabs();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveLabs();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
    }
}
