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
    public partial class NurseSalary : Form
    {
        public NurseSalary()
        {
            InitializeComponent();
            SetNew();
        }

        private void SetNew()
        {
            txtBasic.Text = "0";
            txtPosition.Text = "";
            txtNurseID.Text = "";
            txtNurseName.Text = "";
            txtHouse.Text = "0";
            txtJoinDate.Text = "";
            txtMedical.Text = "0";
            txtOthers.Text = "0";
            txtTADA.Text = "0";
            txtTotal.Text = "0";

            LoadData();
        }

        private void CalculateTotal()
        {
            try
            {
                double basic = 0, house = 0, medical = 0, tada = 0, others = 0;

                basic = Convert.ToDouble(txtBasic.Text);
                house = Convert.ToDouble(txtHouse.Text);
                medical = Convert.ToDouble(txtMedical.Text);
                tada = Convert.ToDouble(txtTADA.Text);
                others = Convert.ToDouble(txtOthers.Text);

                txtTotal.Text = (basic + house + medical + tada + others).ToString();
            }
            catch
            {
            }
        }
        private void SaveSalary()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_SalaryNurse", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Nurse", SqlDbType.Int);
                cmd.Parameters.Add("@Basic_", SqlDbType.Float);
                cmd.Parameters.Add("@HouseRent", SqlDbType.Float);
                cmd.Parameters.Add("@Hedical", SqlDbType.Float);
                cmd.Parameters.Add("@TADA", SqlDbType.Float);
                cmd.Parameters.Add("@Others", SqlDbType.Float);
                cmd.Parameters.Add("@TotalSalary", SqlDbType.Float);

                cmd.Parameters[0].Value = txtNurseID.Text;
                cmd.Parameters[1].Value = txtBasic.Text;
                cmd.Parameters[2].Value = txtHouse.Text;
                cmd.Parameters[3].Value = txtMedical.Text;
                cmd.Parameters[4].Value = txtTADA.Text;
                cmd.Parameters[5].Value = txtOthers.Text;
                cmd.Parameters[6].Value = txtTotal.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Salary saved successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save salary! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void LoadSalary()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblNurseSalary where Nurse=@Nurse";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@Nurse", SqlDbType.Int);
                cmd.Parameters[0].Value = txtNurseID.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtBasic.Text = dt.Rows[0]["Basic_"].ToString();
                    txtHouse.Text = dt.Rows[0]["HouseRent"].ToString();
                    txtMedical.Text = dt.Rows[0]["Hedical"].ToString();
                    txtTADA.Text = dt.Rows[0]["TADA"].ToString();
                    txtOthers.Text = dt.Rows[0]["Others"].ToString();
                    txtTotal.Text = dt.Rows[0]["TotalSalary"].ToString();
                }
                else
                {
                    MessageBox.Show("Salary not saved yet for " + txtNurseName.Text + "!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtBasic.Text = "0";
                    txtHouse.Text = "0";
                    txtMedical.Text = "0";
                    txtTADA.Text = "0";
                    txtOthers.Text = "0";
                    txtTotal.Text = "0";
                }
            }
            catch
            {
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
            ds.CommandText = "select* from NurseInformation";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
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

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            SaveSalary();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void txtBasic_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtHouse_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtMedical_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtTADA_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtOthers_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
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
        private void txtNurseID_TextChanged(object sender, EventArgs e)
        {
            LoadSalary();
        }
    }
}
