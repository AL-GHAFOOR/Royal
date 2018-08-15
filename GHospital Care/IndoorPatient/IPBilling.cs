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
    public partial class IPBilling : Form
    {
        public IPBilling()
        {
            InitializeComponent();
            SetNew();
            LoadServices();
        }
        private void GetPatientInfo()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblIP where IPID=@IPID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@IPID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = txtPatientID.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["PatientName"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();

                    GetAdvancePayment();
                }
                else
                {
                    txtName.Text = "";
                    txtPhone.Text = "";
                    txtAddress.Text = "";
                }
            }
            catch
            {
            }
        }
        int n;
        private void LoadBillDetails()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "SELECT* FROM tblIPBill WHERE BillNo=@BillNo";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = txtBillNo.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtDiscount.Text = dt.Rows[0]["Discount"].ToString();
                    txtPrevPaid.Text = dt.Rows[0]["PreviousPaid"].ToString();
                    txtSubTotal.Text = dt.Rows[0]["SubTotal"].ToString();
                    cmbType.Text = dt.Rows[0]["BillType"].ToString();
                    dateBill.Text = dt.Rows[0]["BillingDate"].ToString();
                    lblGrandTotal.Text = dt.Rows[0]["GrandTotal"].ToString();
                    txtPayable.Text = dt.Rows[0]["PayableTotal"].ToString();

                    isExists = true;
                }
                else
                {
                    isExists = false;
                }
            }
            catch
            {
            }
        }
        private void LoadBillItems()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM tblIPBillDetail WHERE BillID=@BillID";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BillID", SqlDbType.VarChar, 50);
            cmd.Parameters[0].Value = txtBillNo.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dgvServices.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    n = dgvServices.Rows.Add();

                    dgvServices.Rows[n].Cells[0].Value = dt.Rows[i]["ServiceDate"].ToString();
                    dgvServices.Rows[n].Cells[1].Value = dt.Rows[i]["Service"].ToString();
                    dgvServices.Rows[n].Cells[2].Value = dt.Rows[i]["Rate"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Services not included in this bill!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                dgvServices.Rows.Clear();
            }
        }
        private void CreateBill()
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please select a patient to create bill!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblIPBill", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BillingDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BillType", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Patient", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@SubTotal", SqlDbType.Float);
                cmd.Parameters.Add("@Discount", SqlDbType.Float);
                cmd.Parameters.Add("@PreviousPaid", SqlDbType.Float);
                cmd.Parameters.Add("@PayableTotal", SqlDbType.Float);
                cmd.Parameters.Add("@GrandTotal", SqlDbType.Float);

                cmd.Parameters[0].Value = txtBillNo.Text;
                cmd.Parameters[1].Value = dateBill.Text;
                cmd.Parameters[2].Value = cmbType.Text;
                cmd.Parameters[3].Value = txtPatientID.Text;
                cmd.Parameters[4].Value = txtSubTotal.Text;
                cmd.Parameters[5].Value = txtDiscount.Text;
                cmd.Parameters[6].Value = txtPrevPaid.Text;
                cmd.Parameters[7].Value = lblGrandTotal.Text;
                cmd.Parameters[8].Value = txtPayable.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Bill created successfully! Now you can add services!","Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch
            {
            }
        }
        private void CloseBill()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("UPDATE tblIPBill SET BillType='Paid' WHERE BillNo=@BillNo", ob);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtBillNo.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Bill closed successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch
            {
            }
        }
        private void UpdateBill()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblIPBill", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BillingDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BillType", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Patient", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@SubTotal", SqlDbType.Float);
                cmd.Parameters.Add("@Discount", SqlDbType.Float);
                cmd.Parameters.Add("@PreviousPaid", SqlDbType.Float);
                cmd.Parameters.Add("@PayableTotal", SqlDbType.Float);
                cmd.Parameters.Add("@GrandTotal", SqlDbType.Float);

                cmd.Parameters[0].Value = txtBillNo.Text;
                cmd.Parameters[1].Value = dateBill.Text;
                cmd.Parameters[2].Value = cmbType.Text;
                cmd.Parameters[3].Value = txtPatientID.Text;
                cmd.Parameters[4].Value = txtSubTotal.Text;
                cmd.Parameters[5].Value = txtDiscount.Text;
                cmd.Parameters[6].Value = txtPrevPaid.Text;
                cmd.Parameters[7].Value = lblGrandTotal.Text;
                cmd.Parameters[8].Value = txtPayable.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Bill updated successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
            }
        }
        private void GetAdvancePayment()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT ISNULL(SUM(Amount),0) AS Amount FROM tblIPVoucher WHERE PatientID=@PatientID";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@PatientID", SqlDbType.VarChar, 50).Value = txtPatientID.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtPrevPaid.Text = dt.Rows[0]["Amount"].ToString();
            }
        }
        private void SetNew()
        {
            txtAddress.Text = "";
            txtBill.Text = "0";
            txtBillNo.Text = "";
            txtDiscount.Text = "0";
            txtPrevPaid.Text = "0";
            txtName.Text = "";
            txtPatientID.Text = "";
            txtPhone.Text = "";
            txtSubTotal.Text = "0";
            txtPayable.Text = "0";

            cmbType.SelectedIndex = 0;

            lblGrandTotal.Text = "0.00";

            dgvServices.Rows.Clear();

            isExists = false;

            GenerateID();
            LoadData();
            LoadServices();
            txtBill.Text = cmbService.SelectedValue.ToString();
        }
        private void AddServices()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblIPBillDetail", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BillID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Service", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Rate", SqlDbType.Float);
                cmd.Parameters.Add("@ServiceDate", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtBillNo.Text;
                cmd.Parameters[1].Value = cmbService.Text;
                cmd.Parameters[2].Value = txtBill.Text;
                cmd.Parameters[3].Value = dateService.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                try
                {
                    n = dgvServices.Rows.Add();

                    dgvServices.Rows[n].Cells[1].Value = cmbService.Text;
                    dgvServices.Rows[n].Cells[2].Value = txtBill.Text;
                    dgvServices.Rows[n].Cells[0].Value = dateService.Text;

                    UpdateBill();
                    CalculationInGrid();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void RemoveService()
        {
            DialogResult result;

            result = MessageBox.Show("Are you really want to remove this service from bill?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlCommand cmd = new SqlCommand("Delete from tblIPBillDetail where BillID = @BillID AND Service = @Service AND ServiceDate = @ServiceDate AND Rate = @Rate", ob);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BillID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Service", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ServiceDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Rate", SqlDbType.Float);

                foreach (DataGridViewRow row in dgvServices.SelectedRows)
                {
                    cmd.Parameters["@BillID"].Value = txtBillNo.Text;
                    cmd.Parameters["@Service"].Value = row.Cells[1].Value;
                    cmd.Parameters["@ServiceDate"].Value = row.Cells[0].Value;
                    cmd.Parameters["@Rate"].Value = row.Cells[2].Value;

                    ob.Open();
                    cmd.ExecuteNonQuery();
                    ob.Close();
                    dgvServices.Rows.Remove(row);

                    CalculationInGrid();
                }
            }
        }
        private void CalculationInGrid()
        {
            try
            {
                double Total = 0;
                for (int i = 0; i < dgvServices.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvServices.Rows[i];
                    Total += Convert.ToDouble(row.Cells[2].Value);
                }
                txtSubTotal.Text = Total.ToString();
            }
            catch
            {
            }
        }
        private void TotalCalculation()
        {
            try
            {
                lblGrandTotal.Text = (Convert.ToDouble(txtSubTotal.Text) - Convert.ToDouble(txtDiscount.Text)).ToString();
                txtPayable.Text = (Convert.ToDouble(lblGrandTotal.Text) - Convert.ToDouble(txtPrevPaid.Text)).ToString();
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
            ds.CommandText = "SELECT* FROM tblIPBill WHERE BillType='Due'";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = dt;
        }
        private void LoadServices()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "SELECT* FROM tblServices";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbService.DataSource = dt;
            cmbService.DisplayMember = "ServiceName";
            cmbService.ValueMember = "Rate";
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlCommand cmd = new SqlCommand("SP_GENERATE_IPBILLID", ob);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader;
            ob.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
            txtBillNo.Text = reader[0].ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            GetPatientInfo();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (isExists == true)
            {
                MessageBox.Show("This bill already created!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            CreateBill();
        }
        private void txtBillNo_TextChanged(object sender, EventArgs e)
        {
            LoadBillItems();
        }
        bool isExists = false;
        private void dgvDetails_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtBillNo.Text = dgvDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPatientID.Text = dgvDetails.Rows[e.RowIndex].Cells[1].Value.ToString();

                LoadBillDetails();
            }
            catch
            {
            }
        }
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            TotalCalculation();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddServices();
        }
        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBill.Text = cmbService.SelectedValue.ToString();
        }
        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            TotalCalculation();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveService();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            IndoorPatient.PrintIPBill frm = new PrintIPBill(txtBillNo.Text);
            frm.Show();
        }
        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            UpdateBill();
        }
        private void btnCloseBill_Click(object sender, EventArgs e)
        {
            CloseBill();
        }
    }
}
