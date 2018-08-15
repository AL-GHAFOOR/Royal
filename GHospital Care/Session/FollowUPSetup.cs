using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Linq;
using DevExpress.Data.PLinq.Helpers;
using GHospital_Care.BAL.Manager;

using GHospital_Care.DAL.Model;
using ServiceManager = GHospital_Care.BAL.Manager.ServiceManager;

namespace GHospital_Care.Session
{
    public partial class FollowUPSetup : Form
    {
        public FollowUPSetup()
        {
            InitializeComponent();
            SetNew();
        }
        private void SaveService()
        {
            try
            {
                txtRate.Text ="0";
               FollowUPMaster FollowUP = new FollowUPMaster();
               FollowUP.Description = Convert.ToString(txtDescription.Text);
                FollowUP.Rate = Convert.ToDouble(txtRate.Text);
                FollowUP.DepartmentId = cmbDeparment.SelectedValue.ToString();
                FollowUP.FollowUpItemName = txtName.Text;
                var subItems = listOfSubItem.Items;
                FollowUP.ID = Convert.ToInt16(txtID.Text);
                FollowUP.SubItems=new List<FollowUpSubItem>();
                for (int i = 0; i < subItems.Count; i++)
                {
                    
                    FollowUpSubItem item=new FollowUpSubItem();
                    item.ItemId = i;
                    item.SubItemName = subItems[i].SubItems[2].Text;
                    FollowUP.SubItems.Add(item);
                }

                MessageModel messageModel = new FollowUpManager().SaveService(FollowUP);
                MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save service! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Update()
        {
            txtRate.Text = "0";
            FollowUPMaster FollowUP = new FollowUPMaster();
            FollowUP.Description = Convert.ToString(txtDescription.Text);
            FollowUP.Rate = Convert.ToDouble(txtRate.Text);
            FollowUP.DepartmentId = cmbDeparment.SelectedValue.ToString();
            FollowUP.FollowUpItemName = txtName.Text;
           var subItems = listOfSubItem.Items;
            FollowUP.ID = Convert.ToInt16(txtID.Text);
            FollowUP.SubItems = new List<FollowUpSubItem>();

            for (int i = 0; i < subItems.Count; i++)
            {

                FollowUpSubItem item = new FollowUpSubItem();
                item.ItemId = i;
                item.SubItemName = subItems[i].SubItems[2].Text;
                FollowUP.SubItems.Add(item);
            }

            MessageModel messageModel = new FollowUpManager().UpdateService(FollowUP);
            MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetNew();
        }
        private void SetNew()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtRate.Text = "";
            txtDescription.Text = "";
            listOfSubItem.Items.Clear();
            GenerateID();
            LoadData();

            txtName.Focus();

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }



        private void GetDeparment()
        {

            cmbDeparment.DataSource = new FollowUpManager().GetDeparmentTreatment();
            cmbDeparment.DisplayMember = "DeparmentName";
            cmbDeparment.ValueMember = "Id";
        }
        private void LoadData()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select * from tblFollowUp";
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
            cmd.CommandText = "Select isnull(max(ID),0)+1 as ID from tblFollowUp";
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
            Update();
        }
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar)
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
              ////  SetNew();
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtRate.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                GetSubItems(Convert.ToInt16(txtID.Text));

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch
            {
            }
        }

        public void GetSubItems(int ItemId)
        {
            var subItem =new FollowUpManager().GetALLFollowUpWithSubItems().FirstOrDefault(a => a.ID == ItemId);
            if (subItem!=null)
            {
                if (subItem.SubItems.Count > 0)
                {
                   

                    foreach (FollowUpSubItem followUpSubItem in subItem.SubItems)
                    {
                        ListViewItem lvi = new ListViewItem();
                  
                        lvi.SubItems.Add(followUpSubItem.Id.ToString());
                        lvi.SubItems.Add(followUpSubItem.SubItemName);
                        lvi.SubItems.Add(followUpSubItem.ItemId.ToString());
                        listOfSubItem.Items.Add(lvi);
                    }
                  }
            
            }
          
          
        }

        private void FollowUPSetup_Load(object sender, EventArgs e)
        {
            GetDeparment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubItem.Text!=String.Empty)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(txtSubItem.Text);
                    lvi.SubItems.Add("");
                    listOfSubItem.Items.Add(lvi);
                    txtSubItem.Text = String.Empty;
               
                    
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
