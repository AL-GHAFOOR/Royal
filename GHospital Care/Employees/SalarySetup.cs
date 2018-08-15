using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.Employees
{
    public partial class SalarySetup : Form
    {
        public SalarySetup()
        {
            InitializeComponent();
            SetNew();
        }
        private void SetNew()
        {
            txtBasic.Text = "0";
            txtDesignation.Text = "";
            txtEmpID.Text = "";
            txtEmpName.Text = "";
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
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblSalary", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Employee", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Basic", SqlDbType.Float);
                cmd.Parameters.Add("@House", SqlDbType.Float);
                cmd.Parameters.Add("@Medical", SqlDbType.Float);
                cmd.Parameters.Add("@TADA", SqlDbType.Float);
                cmd.Parameters.Add("@Others", SqlDbType.Float);
                cmd.Parameters.Add("@Total", SqlDbType.Float);

                cmd.Parameters[0].Value = txtEmpID.Text;
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
            catch(Exception error)
            {
                MessageBox.Show("Failed to save salary! "+error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void LoadSalary(string EmployeeID)
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblSalary where Employee=@Employee";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@Employee", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = EmployeeID;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtBasic.Text = dt.Rows[0]["Basic"].ToString();
                    txtHouse.Text = dt.Rows[0]["House"].ToString();
                    txtMedical.Text = dt.Rows[0]["Medical"].ToString();
                    txtTADA.Text = dt.Rows[0]["TADA"].ToString();
                    txtOthers.Text = dt.Rows[0]["Others"].ToString();
                    txtTotal.Text = dt.Rows[0]["Total"].ToString();
                }
                else
                {
                    MessageBox.Show("Salary not saved yet for "+txtEmpName.Text+"!","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
            ds.CommandText = "select* from tblEmployees";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtEmpName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDesignation.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtJoinDate.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch
            {
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpID.Text != "")
            {
                LoadSalary(txtEmpID.Text);
            }
        }
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            SaveSalary();
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
    }
}
