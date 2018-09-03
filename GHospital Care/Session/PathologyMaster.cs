using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.Services.Internal;
using GHospital_Care.Admin;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.Session
{
    public partial class PathologyMaster : Form
    {
        public PathologyMaster()
        {
            InitializeComponent();
            SetNew();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }
        private void SavePathology()
        {
            try
            {
                DAL.Model.PathologyMaster Pathology = new DAL.Model.PathologyMaster();
                Pathology.PathId = txtID.Text; ;
                Pathology.PathologyName = Convert.ToString(txtName.Text);
                Pathology.Address = Convert.ToString(txtAddress.Text);
                Pathology.Alias = Convert.ToString(txtAlias.Text);
                Pathology.UserId = MainWindow.userName;

                MessageModel messageModel = new BAL.Manager.ServiceManager().SavePathology(Pathology);
                MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save Pathology! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdatePathology()
        {
            try
            {
                DAL.Model.PathologyMaster Pathology = new DAL.Model.PathologyMaster();
                Pathology.PathId = txtID.Text; ;
                Pathology.PathologyName = Convert.ToString(txtName.Text);
                Pathology.Address = Convert.ToString(txtAddress.Text);
                Pathology.Alias = Convert.ToString(txtAlias.Text);
                Pathology.UserId = MainWindow.userName;

                MessageModel messageModel = new BAL.Manager.ServiceManager().UpdatePathology(Pathology);
                MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save Pathology! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void SetNew()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtAlias.Text = "";
            LoadData();
            txtName.Focus();
            PatholgyID();
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void LoadData()
        {
            DataTable data = new BAL.Manager.ServiceManager().GetPathology();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = data;
        }
      

        public void PatholgyID()
        {
            DataTable dt = new BAL.Manager.ServiceManager().GeneratePatholgyId();
            if (dt != null && dt.Rows.Count > 0)
            {
                txtID.Text = "Path-00"+dt.Rows[0][0].ToString();
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
            SavePathology();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdatePathology();
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtAlias.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch
            {
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void PathologyMaster_Load(object sender, EventArgs e)
        {
            PatholgyID();
        }
    }
}
