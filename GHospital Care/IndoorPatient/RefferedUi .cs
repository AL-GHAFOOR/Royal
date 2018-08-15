using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.IndoorPatient
{
    public partial class RefferedUi : MetroFramework.Forms.MetroForm
    {
        private RefferedInfoManager aRefferedInfoManager;
        private RefferedInfo aRefferedInfo;

        public RefferedUi()
        {
            InitializeComponent();
            aRefferedInfoManager=new RefferedInfoManager();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this.panel1, this.Name);
        }

        public void Refresh()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtId.Text = "";
            txtEmail.Text = "";
            txtDesignation.Text = "";

            btnSave.Text = "Save";
            btnDelete.Enabled = false;

            PopulateGridView();
        }

        public void PopulateGridView()
        {
            aRefferedInfoManager = new RefferedInfoManager();
            DataTable dataTable = new DataTable();
            dataTable = aRefferedInfoManager.PopulateGridView();
            gridControlReffered.DataSource = dataTable;
        }

        private void RefferedUi_Load(object sender, EventArgs e)
        {
            PopulateGridView();
            btnDelete.Enabled = false;
       }

        private void btnSave_Click(object sender, EventArgs e)
        {
            aRefferedInfo=new RefferedInfo();
            aRefferedInfo.Name = txtName.Text;
            aRefferedInfo.Address = txtAddress.Text;
            aRefferedInfo.MobileNo = txtMobile.Text;
            aRefferedInfo.UserId = lblUserId.Text;
            aRefferedInfo.Email = txtEmail.Text;
            aRefferedInfo.Designation = txtDesignation.Text;
            aRefferedInfo.Commission = txtCommisionPercent.Text;

            if (btnSave.Text == "Save")
            {
                MessageModel aMessageModel = new MessageModel();
                aMessageModel = aRefferedInfoManager.SaveRefferedInfo(aRefferedInfo);
                if (aMessageModel.MessageTitle == "Successful")
                {
                    MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageModel aMessageModel = new MessageModel();
                aRefferedInfo.Id = Convert.ToInt32(txtId.Text);
                aMessageModel = aRefferedInfoManager.UpdateRefferedInfo(aRefferedInfo);
                if (aMessageModel.MessageTitle == "Successful")
                {
                    MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Refresh();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageTitle, aMessageModel.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void gridViewReffered_DoubleClick(object sender, EventArgs e)
        {
            xtraTabPage1.Show();
            txtId.Text = gridViewReffered.GetFocusedRowCellValue("Id").ToString();
            txtName.Text = gridViewReffered.GetFocusedRowCellValue("Name").ToString();
            txtAddress.Text = gridViewReffered.GetFocusedRowCellValue("Address").ToString();
            txtMobile.Text = gridViewReffered.GetFocusedRowCellValue("MobileNo").ToString();
            txtEmail.Text = gridViewReffered.GetFocusedRowCellValue("Email").ToString();
            txtDesignation.Text = gridViewReffered.GetFocusedRowCellValue("Designation").ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "Are you sure to delete row?", "Confirmation Message",
              MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                aRefferedInfo = new RefferedInfo();
                aRefferedInfo.Id = Convert.ToInt32(txtId.Text);
                MessageModel aMessageModel = new MessageModel();
                aMessageModel = aRefferedInfoManager.DeleteRefferedInfo(aRefferedInfo);
                if (aMessageModel.MessageTitle == "Successfull")
                {
                    MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }





    }
}
