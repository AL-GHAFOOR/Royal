using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.Accounts
{
    public partial class AccountSetup : Form
    {
        public AccountSetup()
        {
            InitializeComponent();
            SetNew();
        }
        private void SaveAccount()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblAccounts", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AccNo", SqlDbType.Int);
                cmd.Parameters.Add("@AccName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@AccType", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@OpeningBalance", SqlDbType.Float);
                cmd.Parameters.Add("@Notes", SqlDbType.VarChar, 255);

                cmd.Parameters[0].Value = txtID.Text;
                cmd.Parameters[1].Value = txtAccName.Text;
                cmd.Parameters[2].Value = cmbType.Text;
                cmd.Parameters[3].Value = txtBalance.Text;
                cmd.Parameters[4].Value = txtNotes.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Account Saved Successfully!","Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
                SetNew();
            }
            catch(Exception error)
            {
                MessageBox.Show("Failed to Save Account! "+error.Message.ToString(),"Failed",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        private void SetNew()
        {
            txtAccName.Text = "";
            txtID.Text = "";
            txtNotes.Text = "";
            txtBalance.Text = "0";

            cmbType.SelectedIndex = 0;

            btnSave.Enabled = true;
            btnEdit.Enabled = false;

            GenerateID();
            GridLoad();
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(AccNo),0)+1 as AccNo from tblAccounts";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtID.Text = dt.Rows[0]["AccNo"].ToString();
            }
        }
        private void GridLoad()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "SELECT* FROM tblAccounts";
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAccount();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveAccount();
        }
    }
}
