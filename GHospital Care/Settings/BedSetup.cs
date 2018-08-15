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
    public partial class BedSetup : Form
    {
        public BedSetup()
        {
            InitializeComponent(); 
            SetNew();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }
        private void SaveBed()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblBed", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@Ward", SqlDbType.Int);
                cmd.Parameters.Add("@Room", SqlDbType.Int);
                cmd.Parameters.Add("@BedName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 255);
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtBedID.Text;
                cmd.Parameters[1].Value = cmbWard.SelectedValue;
                cmd.Parameters[2].Value = cmbRoom.SelectedValue;
                cmd.Parameters[3].Value = txtBedName.Text;
                cmd.Parameters[4].Value = txtDescription.Text;
                cmd.Parameters[5].Value = "Free";

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Bed save successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save Bed! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetNew()
        {
            txtBedID.Text = "";
            txtBedName.Text = "";
            txtDescription.Text = "";

            GenerateID();
            LoadData();
            LoadWards();
            LoadRooms();

            txtBedName.Focus();

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
            ds.CommandText = "select* from tblBed";
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

                ds.Parameters.Add("@WardNo", SqlDbType.Int).Value = cmbWard.SelectedValue;

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbRoom.DataSource = dt;
                cmbRoom.DisplayMember = "RoomName";
                cmbRoom.ValueMember = "ID";
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
            cmd.CommandText = "Select isnull(max(ID),0)+1 as ID from tblBed";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtBedID.Text = dt.Rows[0]["ID"].ToString();
            }
        }
        private void btnColse_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void cmbWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRooms();
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
                cmd.CommandText = "Select* From tblBed where ID=@ID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters[0].Value = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtBedID.Text = dt.Rows[0]["ID"].ToString();
                    txtBedName.Text = dt.Rows[0]["BedName"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    cmbRoom.SelectedValue = dt.Rows[0]["Room"].ToString();
                    cmbWard.SelectedValue = dt.Rows[0]["Ward"].ToString();

                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch
            {
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveBed();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveBed();
        }
    }
}
