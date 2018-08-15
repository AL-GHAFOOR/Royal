using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GHospital_Care.Nurses
{
    public partial class NurseDutySchedule : Form
    {
        public NurseDutySchedule()
        {
            InitializeComponent();
            Clear();
        }
        private void Clear()
        {
            txtNurseName.Text = "";
            txtPosition.Text = "";
            txtJoinDate.Text = "";
            txtStartTime.Text = "";
            txtEndTime.Text = "";

            cmbAMPM1.SelectedIndex = 0;
            cmbAMPM2.SelectedIndex = 0;
            cmbDuty.SelectedIndex = 0;

            LoadData();
         }
        private void LoadData()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from NurseInformation";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void SaveTiming()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblNurseDuty", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Nurse", SqlDbType.Int);
                cmd.Parameters.Add("@DutyDate", SqlDbType.VarChar);
                cmd.Parameters.Add("@StartTime", SqlDbType.VarChar);
                cmd.Parameters.Add("@EndTime", SqlDbType.VarChar);
                cmd.Parameters.Add("@DayOff", SqlDbType.VarChar);
                cmd.Parameters.Add("@StartAMPM", SqlDbType.VarChar);
                cmd.Parameters.Add("@EndAMPM", SqlDbType.VarChar);
                
                cmd.Parameters[0].Value = txtNurseID.Text;
                cmd.Parameters[1].Value = datetimepicker.Text;
                cmd.Parameters[4].Value = cmbDuty.Text;

                if (cmbDuty.Text == "On Duty")
                {
                    cmd.Parameters[2].Value = txtStartTime.Text;
                    cmd.Parameters[3].Value = txtEndTime.Text;
                    cmd.Parameters[5].Value = cmbAMPM1.Text;
                    cmd.Parameters[6].Value = cmbAMPM2.Text;
                }
                else if (cmbDuty.Text == "Duty Off")
                {
                    cmd.Parameters[2].Value = "--";
                    cmd.Parameters[3].Value = "--";
                    cmd.Parameters[5].Value = "";
                    cmd.Parameters[6].Value = "";
                }
                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Duty saved successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save Duty! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            SaveTiming();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtNurseID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNurseName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtJoinDate.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch
            {
            }
        }

        private void LoadTimming()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblNurseDuty where Nurse=@Nurse and DutyDate=@DutyDate";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@Nurse", SqlDbType.Int);
                cmd.Parameters.Add("@DutyDate", SqlDbType.VarChar, 50).Value = datetimepicker.Text;
                cmd.Parameters[0].Value = txtNurseID.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    datetimepicker.Text = dt.Rows[0]["DutyDate"].ToString();
                    cmbDuty.Text = dt.Rows[0]["DayOff"].ToString();
                    cmbAMPM1.Text = dt.Rows[0]["StartAMPM"].ToString();
                    cmbAMPM2.Text = dt.Rows[0]["EndAMPM"].ToString();
                    txtStartTime.Text = dt.Rows[0]["StartTime"].ToString();
                    txtEndTime.Text = dt.Rows[0]["EndTime"].ToString();
                }
                else
                {
                    MessageBox.Show("Duty Schedule not saved yet for " + txtNurseName.Text + "!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtStartTime.Text = "";
                    txtEndTime.Text = "";

                }
            }
            catch
            {
            }
        }
        private void txtNurseID_TextChanged(object sender, EventArgs e)
        {
            LoadTimming();
        }
        private void cmbDuty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDuty.SelectedIndex == 0)
            {
                pnlTimming.Enabled = true;
            }
            else if (cmbDuty.SelectedIndex == 1)
            {
                pnlTimming.Enabled = false;
            }
        }
    }
}
