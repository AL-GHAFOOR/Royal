using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Services.Internal;
using GHospital_Care.DAL.Model;
using ServiceManager = GHospital_Care.BAL.Manager.ServiceManager;

namespace GHospital_Care.Settings
{
    public partial class ServiceSetup : Form
    {
        public ServiceSetup()
        {
            InitializeComponent();
            SetNew();
        }
        private void SaveService()
        {
            try
            {
                if (txtRate.Text == "" || Convert.ToInt32(txtRate.Text) < 0)
                {MessageBox.Show("Please enter the valid rate of this service!","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }

                Service service=new Service();
                service.ID = Convert.ToInt16(txtID.Text);
                service.ServiceName = Convert.ToString(txtName.Text);
                service.Description = Convert.ToString(txtDescription.Text);
                service.Rate = Convert.ToDouble(txtRate.Text);
                service.ServiceId = "Serv-0"+txtID.Text;
                service.Catgory = cmbCatgory.Text;

                if (btnEdit.Enabled)
                {
                    MessageModel messageModel = new ServiceManager().UpdateService(service);
                    MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNew();
                }
                else
                {
                    MessageModel messageModel = new ServiceManager().SaveService(service);
                    MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNew();
                }

             
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save service! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void SetNew()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtRate.Text = "";
            txtDescription.Text = "";
            cmbCatgory.Text = "";
            GenerateID();
            LoadData();

            txtName.Focus();

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            ActiveControl = cmbCatgory;
        }
        private void LoadData()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblServices ORDER BY ServiceName";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(ID),0)+1 as ID from tblServices";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtID.Text = dt.Rows[0]["ID"].ToString();
            }
        }
        private void btnColse_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SaveService();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveService();
        }
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
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
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtRate.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetNew();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveService();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveService();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            SaveService();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();}

        private void btnDelete_Click_2(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this row?", "Confirmation Message",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Service service = new Service();

                service.ID = Convert.ToInt32(txtID.Text);
                MessageModel aMessageModel = new MessageModel();
                aMessageModel = new ServiceManager().DeleteService(service);
                if (aMessageModel.MessageTitle == "Successfull")
                {MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNew();
                }
                else
                {
                    MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
