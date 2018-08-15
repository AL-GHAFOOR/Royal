using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.IndoorPatient
{
    public partial class IPBedShiftment : Form
    {
        public IPBedShiftment()
        {
            InitializeComponent();
            ResetUI();
        }
        private void ResetUI()
        {
            txtAge.Text = "";
            txtGender.Text = "";
            txtPatientName.Text = "";
            txtPatientNo.Text = "";
            txtRefferdBy.Text = "";
            txtRoom.Text = "";
            txtBed.Text = "";
            txtWard.Text = "";

            LoadWards();
            LoadRooms();
            LoadBeds();
        }
        private void ShiftBed()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("UPDATE tblIP SET Ward=@Ward, Room=@Room, Bed=@Bed WHERE IPID=@IPID", ob);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@IPID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Ward", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Room", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Bed", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtPatientNo.Text;
                cmd.Parameters[1].Value = cmbWard.Text;
                cmd.Parameters[2].Value = cmbRoom.Text;
                cmd.Parameters[3].Value = cmbBed.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                SetBedBusy();
                SetBedFree();

                MessageBox.Show("Bed shifted successfully!","Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ResetUI();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to shift bed to ! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetBedBusy()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("UPDATE tblBed SET Status=@Status WHERE ID=@ID", ob);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = cmbBed.SelectedValue;
                cmd.Parameters[1].Value = "Busy";
                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to set bed to busy ! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetBedFree()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("UPDATE tblBed SET Status=@Status WHERE BedName=@BedName", ob);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BedName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtBed.Text;
                cmd.Parameters[1].Value = "Free";
                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to set bed to free ! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SearchIP()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "SELECT* FROM tblIP where IPID=@IPID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@IPID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = txtPatientNo.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtGender.Text = dt.Rows[0]["Gender"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    txtRefferdBy.Text = dt.Rows[0]["Doctor"].ToString();
                    txtPatientName.Text = dt.Rows[0]["PatientName"].ToString();
                    txtWard.Text = dt.Rows[0]["Ward"].ToString();
                    txtRoom.Text = dt.Rows[0]["Room"].ToString();
                    txtBed.Text = dt.Rows[0]["Bed"].ToString();
                }
            }
            catch
            {
            }
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
        private void LoadBeds()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand ds = da.SelectCommand;
                ds.CommandText = "select* from tblBed where Ward=@Ward and Room=@Room and Status='Free'";
                ds.CommandType = CommandType.Text;

                ds.Parameters.Add("@Ward", SqlDbType.Int).Value = cmbWard.SelectedValue;
                ds.Parameters.Add("@Room", SqlDbType.Int).Value = cmbRoom.SelectedValue;

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbBed.DataSource = dt;
                cmbBed.DisplayMember = "BedName";
                cmbBed.ValueMember = "ID";
            }
            catch
            {
            }
        }
        private void txtPatientNo_TextChanged(object sender, EventArgs e)
        {
            SearchIP();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void cmbWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRooms();
        }
        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBeds();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ShiftBed();
        }
    }
}
