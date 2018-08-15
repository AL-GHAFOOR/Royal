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
    public partial class NurseGenerator : Form
    {
        public NurseGenerator()
        {
            InitializeComponent();
            LoadData();
            cmbMonth.SelectedIndex = 0;
        }
        private DataTable dt;
        private void NurseGenerateSalary()
        {
            try
            {
                CheckExists();
                if (isExists == true)
                {
                    MessageBox.Show("Salary sheet for " + cmbMonth.Text + "," + txtYear.Text + " is already exists!", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Conn ob = new Conn();
                    SqlConnection obCon = new SqlConnection(ob.strCon);
                    SqlCommand cmd = new SqlCommand("SP_Nurse_SALARY_SHEET", obCon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];

                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@_Month", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@_Year", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@Nurse", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@Basic", SqlDbType.Float);
                        cmd.Parameters.Add("@House", SqlDbType.Float);
                        cmd.Parameters.Add("@Medical", SqlDbType.Float);
                        cmd.Parameters.Add("@TADA", SqlDbType.Float);
                        cmd.Parameters.Add("@Other", SqlDbType.Float);
                        cmd.Parameters.Add("@Total", SqlDbType.Float);

                        cmd.Parameters[0].Value = cmbMonth.Text;
                        cmd.Parameters[1].Value = txtYear.Text;
                        cmd.Parameters[2].Value = row.Cells[0].Value;
                        cmd.Parameters[3].Value = row.Cells[1].Value;
                        cmd.Parameters[4].Value = row.Cells[2].Value;
                        cmd.Parameters[5].Value = row.Cells[3].Value;
                        cmd.Parameters[6].Value = row.Cells[4].Value;
                        cmd.Parameters[7].Value = row.Cells[5].Value;
                        cmd.Parameters[8].Value = row.Cells[6].Value;

                        obCon.Open();
                        cmd.ExecuteNonQuery();
                        obCon.Close();
                    }
                    MessageBox.Show("Salary sheet for " + cmbMonth.Text + "," + txtYear.Text + " is generated successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to generate salary sheet! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool isExists = false;
        private void CheckExists()
        {
            try
            {
                isExists = false;
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From Nurse_Salary_Sheet where _Month=@_Month And _Year=@_Year";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@_Month", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@_Year", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = cmbMonth.Text;
                cmd.Parameters[1].Value = txtYear.Text;

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    isExists = true;
                }
            }
            catch
            {
                MessageBox.Show("Failed to check exists!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            ds.CommandText = "select* from tblNurseSalary";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
             if (txtYear.Text == "")
            {
                MessageBox.Show("This is an invalid year selection!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(txtYear.Text) < 2015)
            {
                MessageBox.Show("This is an invalid year selection!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                NurseGenerateSalary();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            isExists = false;
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            isExists = false;
        }
    }
}
