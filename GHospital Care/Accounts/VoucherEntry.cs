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
    public partial class VoucherEntry : Form
    {
        public VoucherEntry()
        {
            InitializeComponent();
            SetNew();
        }
        private void SetNew()
        {
            txtAccName.Text = "";
            txtAccNo.Text = "";
            txtCredit.Text = "0";
            txtDebit.Text = "0";
            txtDescription.Text = "";
            txtID.Text = "";
            txtTotalCredit.Text = "0";
            txtTotalDebit.Text = "0";

            GenerateVoucherNo();
            LoadAccounts();
        }
        private void GenerateVoucherNo()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(VoucherNo),0)+1 as VoucherNo from tblVoucher";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtID.Text = dt.Rows[0]["VoucherNo"].ToString();
            }
        }
        private void LoadAccounts()
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

            dgvAccList.AutoGenerateColumns = false;
            dgvAccList.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void txtAccName_Click(object sender, EventArgs e)
        {
            dgvAccList.Visible = true;
        }
        private void dgvAccList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtAccNo.Text = dgvAccList.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtAccName.Text = dgvAccList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtBalance.Text = dgvAccList.Rows[e.RowIndex].Cells[2].Value.ToString();

                dgvAccList.Visible = false;
            }
            catch
            {
            }
        }
        private void dgvAccList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtAccNo.Text = dgvAccList.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtAccName.Text = dgvAccList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtBalance.Text = dgvAccList.Rows[e.RowIndex].Cells[2].Value.ToString();

                dgvAccList.Visible = false;
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
