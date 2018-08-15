using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.IndoorPatient
{
    public partial class DiscountAuthorityUi : MetroFramework.Forms.MetroForm
    {
        private DiscountAuthorityManager aDiscountAuthorityManager;
        private DiscountAuthority aDiscountAuthority;
        public DiscountAuthorityUi()
        {
            InitializeComponent();
            aDiscountAuthorityManager =new DiscountAuthorityManager();
            aDiscountAuthority=new DiscountAuthority();
        }


        public void PopulateGridView()
        {
            aDiscountAuthorityManager = new DiscountAuthorityManager();
            DataTable dataTable = new DataTable();
            dataTable = aDiscountAuthorityManager.PopulateGridView();
            gridControlDiscount.DataSource = dataTable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //DiscountAuthority aDiscountAuthority=new DiscountAuthority();
            aDiscountAuthority.Name = txtName.Text;
            aDiscountAuthority.Address = txtAddress.Text;
            aDiscountAuthority.MobileNo = txtMobile.Text;
            aDiscountAuthority.Email = txtEmail.Text;
            aDiscountAuthority.Designation=txtDesignation.Text;
            aDiscountAuthority.UserId = lblUserId.Text;

            if (btnSave.Text == "Save")
            {
                MessageModel aMessageModel = new MessageModel();
                aMessageModel = aDiscountAuthorityManager.SaveDiscountAuthority(aDiscountAuthority);
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
                aDiscountAuthority.Id = Convert.ToInt32(txtId.Text);
                aMessageModel = aDiscountAuthorityManager.UpdateDiscountAuthority(aDiscountAuthority);
                if (aMessageModel.MessageTitle == "Successful")
                {
                    MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, aMessageModel.MessageTitle, aMessageModel.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "Are you sure to delete row?", "Confirmation Message",
              MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                aDiscountAuthority = new DiscountAuthority();
                aDiscountAuthority.Id = Convert.ToInt32(txtId.Text);
                MessageModel aMessageModel = new MessageModel();
                aMessageModel = aDiscountAuthorityManager.DeleteDiscountAuthority(aDiscountAuthority);
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

        private void DiscountAuthorityUi_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void gridViewDiscount_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = gridViewDiscount.GetFocusedRowCellValue("Id").ToString();
            txtName.Text = gridViewDiscount.GetFocusedRowCellValue("Name").ToString();
            txtAddress.Text = gridViewDiscount.GetFocusedRowCellValue("Address").ToString();
            txtMobile.Text = gridViewDiscount.GetFocusedRowCellValue("MobileNo").ToString();
            txtEmail.Text = gridViewDiscount.GetFocusedRowCellValue("Email").ToString();
            txtDesignation.Text = gridViewDiscount.GetFocusedRowCellValue("Designation").ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
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
            btnDelete.Enabled = false;PopulateGridView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();}
    }
}
