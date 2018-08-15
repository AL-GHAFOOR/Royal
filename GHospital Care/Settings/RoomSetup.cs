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
    public partial class RoomSetup : Form
    {
        public RoomSetup()
        {
            InitializeComponent();
            SetNew();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }
        private void SaveRooms()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblRooms", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@RoomName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@WardNo", SqlDbType.Int);

                cmd.Parameters[0].Value = txtID.Text;
                cmd.Parameters[1].Value = txtName.Text;
                cmd.Parameters[2].Value = txtDescription.Text;
                cmd.Parameters[3].Value = cmbWard.SelectedValue;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Room save successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save room! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetNew()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";

            GenerateID();
            LoadData();
            LoadWards();

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
            ds.CommandText = "select* from tblRooms";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }
        private void LoadWards()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblWards";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbWard.DataSource = dt;
            cmbWard.DisplayMember = "WardName";
            cmbWard.ValueMember = "ID";
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(ID),0)+1 as ID from tblRooms";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtID.Text = dt.Rows[0]["ID"].ToString();
            }
        }
        private void btnColse_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRooms();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbWard.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch
            {
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveRooms();
        }
    }
}
