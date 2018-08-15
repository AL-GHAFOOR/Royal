using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.OutdoorPatient
{
    public partial class OutpatientBilling : Form
    {
        public OutpatientBilling(string PatientID)
        {
            InitializeComponent();
            SetNew();
            //txtPatientID.Text = PatientID;
            LoadServices();
        }
        private void SetNew()
        {
            txtBill.Text = "0";
            txtBillNo.Text = "";
            txtDiscount.Text = "0";
            txtExchanged.Text = "0";
            txtName.Text = "";
            txtPhone.Text = "";
            txtRecieved.Text = "0";
            txtSubTotal.Text = "0";

            lblGrandTotal.Text = "0.00";

            dgvServices.Rows.Clear();

            btnPrint.Enabled = false;

            GenerateID();
            LoadData();
            LoadServices();
            LoadSubServices();
            //txtBill.Text = cmbSubService.SelectedValue.ToString();
        }
        int n;
        private void AddService()
        {
            try
            {
                n = dgvServices.Rows.Add();

                dgvServices.Rows[n].Cells[0].Value = cmbService.Text;
                dgvServices.Rows[n].Cells[1].Value = cmbSubService.Text;
                dgvServices.Rows[n].Cells[2].Value = txtBill.Text;

                CalculationInGrid();
            }
            catch
            {
            }
        }
        private void SaveBill()
        {
            try
            {
                if (lblGrandTotal.Text == "0.00")
                {
                    MessageBox.Show("Please add atleast one service for patient and retry again!", "Information Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please enter the patient id and retry again!", "Information Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblOPBill", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BillID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BillDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@SubTotal", SqlDbType.Float);
                cmd.Parameters.Add("@Discount", SqlDbType.Float);
                cmd.Parameters.Add("@Recieved", SqlDbType.Float);
                cmd.Parameters.Add("@Exchanged", SqlDbType.Float);
                cmd.Parameters.Add("@GrandTotal", SqlDbType.Float);
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Age", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Sex", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtBillNo.Text;
                cmd.Parameters[1].Value = dateTimePicker1.Text;
                cmd.Parameters[2].Value = txtSubTotal.Text;
                cmd.Parameters[3].Value = txtDiscount.Text;
                cmd.Parameters[4].Value = txtRecieved.Text;
                cmd.Parameters[5].Value = txtExchanged.Text;
                cmd.Parameters[6].Value = lblGrandTotal.Text;
                cmd.Parameters[7].Value = txtName.Text;
                cmd.Parameters[8].Value = txtAge.Text;
                if (optMale.Checked == true)
                {
                    cmd.Parameters[9].Value = "Male";
                }
                else if (optFemale.Checked == true)
                {
                    cmd.Parameters[9].Value = "Female";
                }

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                SaveService();
                SavePatient();

                DialogResult dr = MessageBox.Show("Bill created successfully! Do you want to print it?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ReportViewer.ViewReport frm = new GHospital_Care.ReportViewer.ViewReport("OPBill", txtBillNo.Text);
                    frm.Show();
                }
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save bill! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SavePatient()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblOP", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@OPID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ServiceDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Age", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtBillNo.Text;
                cmd.Parameters[1].Value = txtName.Text;
                cmd.Parameters[2].Value = dateTimePicker1.Text;
                if (optMale.Checked == true)
                {
                    cmd.Parameters[3].Value = "Male";
                }
                else if (optFemale.Checked == true)
                {
                    cmd.Parameters[3].Value = "Female";
                }
                cmd.Parameters[4].Value = txtAge.Text;
                cmd.Parameters[5].Value = txtPhone.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save patient! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SearchBill()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblOPBill where BillID=@BillID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BillID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = txtBillNo.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtSubTotal.Text = dt.Rows[0]["SubTotal"].ToString();
                    txtDiscount.Text = dt.Rows[0]["Discount"].ToString();
                    txtRecieved.Text = dt.Rows[0]["Recieved"].ToString();
                    txtExchanged.Text = dt.Rows[0]["Exchanged"].ToString();
                    lblGrandTotal.Text = dt.Rows[0]["GrandTotal"].ToString();
                    txtName.Text = dt.Rows[0]["PatientName"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    string Gender = dt.Rows[0]["Sex"].ToString();

                    if (Gender == "Male")
                    {
                        optMale.Checked = true;
                    }
                    else if (Gender == "Female")
                    {
                        optFemale.Checked = true;
                    }

                    LoadGrid();

                    btnPrint.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
            catch
            {
            }
        }
        private void LoadGrid()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblOPBillDetails where OPBillID=@OPBillID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@OPBillID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = txtBillNo.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dgvServices.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        n = dgvServices.Rows.Add();

                        dgvServices.Rows[n].Cells[0].Value = dt.Rows[i]["Service"].ToString();
                        dgvServices.Rows[n].Cells[2].Value = dt.Rows[i]["Rate"].ToString();
                        dgvServices.Rows[n].Cells[1].Value = dt.Rows[i]["SubService"].ToString();
                    }
                }
            }
            catch
            {
            }
        }
        private void SaveService()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblOPBillDetails", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@OPBillID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Service", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Rate", SqlDbType.Float);
                cmd.Parameters.Add("@SubService", SqlDbType.VarChar, 50);

                for (int i = 0; i < dgvServices.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvServices.Rows[i];

                    cmd.Parameters[0].Value = txtBillNo.Text;
                    cmd.Parameters[1].Value = row.Cells[0].Value;
                    cmd.Parameters[2].Value = row.Cells[2].Value;
                    cmd.Parameters[3].Value = row.Cells[1].Value;

                    ob.Open();
                    cmd.ExecuteNonQuery();
                    ob.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save service! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TotalCalculation()
        {
            try
            {
                double SubTotal, Discount;

                SubTotal = Convert.ToDouble(txtSubTotal.Text);
                Discount = Convert.ToDouble(txtDiscount.Text);

                lblGrandTotal.Text = (SubTotal - Discount).ToString();
            }
            catch
            {
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
                cmd.CommandText = "Select* From tblOP where OPID=@OPID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@OPID", SqlDbType.VarChar, 50);
                //cmd.Parameters[0].Value = txtPatientID.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["PatientName"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                }
                else
                {
                    txtName.Text = "";
                    txtPhone.Text = "";
                }
            }
            catch
            {
            }
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlCommand cmd = new SqlCommand("SP_GENERATE_OPBILLID", ob);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader;
            ob.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
            txtBillNo.Text = reader[0].ToString();
        }
        private void CountTotalPatient()
        {
            string today_date = dateTimePicker1.Text;
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(count(BillID),0) as BillID from tblOPBill Where BillDate=@BillDate";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BillDate", SqlDbType.VarChar, 50).Value = today_date; ;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblTotalPatient.Text = "Total " + dt.Rows[0]["BillID"].ToString() + " Patient Today";
            }
        }
        private void RemoveService()
        {
            try
            {
                DialogResult result;

                result = MessageBox.Show("Are you really want to remove this service from bill?", "OP Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvServices.SelectedRows)
                    {
                        dgvServices.Rows.Remove(row);
                    }
                    CalculationInGrid();
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
            ds.CommandText = "SELECT* FROM tblOPBill WHERE BillDate='" + dateTimePicker1.Text + "'";
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
            ds.CommandText = "select* from tblServices";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbService.DataSource = dt;
            cmbService.DisplayMember = "ServiceName";
            cmbService.ValueMember = "ID";
        }
        private void LoadSubServices()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand ds = da.SelectCommand;
                ds.CommandText = "select* from tblSubServices where SSParent=@SSParent";
                ds.CommandType = CommandType.Text;

                ds.Parameters.Add("@SSParent", SqlDbType.Int).Value = cmbService.SelectedValue.ToString();

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbSubService.DataSource = dt;
                cmbSubService.DisplayMember = "SSName";
                cmbSubService.ValueMember = "SSRate";
            }
            catch
            {
            }
        }
        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubServices();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            GetPatientInfo();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddService();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveService();
        }
        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            TotalCalculation();
        }
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            TotalCalculation();
        }
        private void txtRecieved_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtExchanged.Text = (Convert.ToDouble(txtRecieved.Text) - Convert.ToDouble(lblGrandTotal.Text)).ToString();
            }
            catch
            {
            }
        }
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtRecieved.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveBill();
        }
        private void dgvDetails_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtBillNo.Text = dgvDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                SearchBill();
            }
            catch
            {
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportViewer.ViewReport frm = new GHospital_Care.ReportViewer.ViewReport("OPBill", txtBillNo.Text);
            frm.Show();
        }
        private void OutpatientBilling_Load(object sender, EventArgs e)
        {
            SetNew();
        }
        private void cmbSubService_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBill.Text = cmbSubService.SelectedValue.ToString();
        }
    }
}
