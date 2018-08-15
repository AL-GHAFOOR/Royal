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
    public partial class BankSummary : Form
    {
        public BankSummary()
        {
            InitializeComponent();
            LoadBanks();
        }
        private void LoadBanks()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM tblAccounts WHERE AccType='Bank Account'";
            cmd.CommandType = CommandType.Text;
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            lstBankList.DataSource = dtt;
            lstBankList.DisplayMember = "AccName";
            lstBankList.ValueMember = "AccNo";

            GetBalance();
        }
        private void GetBalance()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblAccounts where AccNo=@AccNo";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@AccNo", SqlDbType.Int);
                cmd.Parameters[0].Value = lstBankList.SelectedValue;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblCurrentBalance.Text = dt.Rows[0]["OpeningBalance"].ToString();
                }
            }
            catch
            {
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void lstBankList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBalance();
        }
        private void lstBankList_DoubleClick(object sender, EventArgs e)
        {
            //GetBalance();
        }
    }
}
