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
    public partial class WardSetup : Form
    {
        public WardSetup()
        {
            InitializeComponent();
            SetNew();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }
        private void DeleteWard()
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you really want to delete this ward?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Conn obcon = new Conn();
                    SqlConnection ob = new SqlConnection(obcon.strCon);
                    SqlCommand cmd = new SqlCommand("Delete from tblWards where ID=@ID", ob);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters[0].Value = txtBedID.Text;

                    ob.Open();
                    cmd.ExecuteNonQuery();
                    ob.Close();

                    MessageBox.Show("Your ward has been deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNew();
                }
            }
            catch
            {
            }
        }
        private void SetNew()
        {
            txtBedID.Text = "";
            txtBedName.Text = "";
            txtDescription.Text = "";

            GenerateID();
            LoadData();

            txtBedName.Focus();

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void SaveWards()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblWards", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@WardName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtBedID.Text;
                cmd.Parameters[1].Value = txtBedName.Text;
                cmd.Parameters[2].Value = txtDescription.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Ward save successfully!","Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
                SetNew();
            }
            catch(Exception error)
            {
                MessageBox.Show("Failed to save ward! "+error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadData()
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
            cmd.CommandText = "Select isnull(max(ID),0)+1 as ID from tblWards";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtBedID.Text = dt.Rows[0]["ID"].ToString();
            }
        }
        private void txtBedID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtBedName.Focus();
            }
        }
        private void txtBedName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtDescription.Focus();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveWards();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtBedID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtBedName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch
            {
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteWard();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveWards();
        }

        private void WardSetup_Load(object sender, EventArgs e)
        {

        }
    }
}
