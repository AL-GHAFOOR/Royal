using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.Session
{
    public partial class CreateNewUser : DevExpress.XtraEditors.XtraForm
    {
        public CreateNewUser()
        {
            InitializeComponent();
            GetUserID();
        }

        public void GetUserID()
        {
            DataTable dt = new UserManager().getUserID();
            if (dt != null && dt.Rows.Count > 0)
            {
                // txtUserId.Text = dt.Rows[0][0].ToString();
                txtUserId.Tag = dt.Rows[0][0].ToString();
            }
        }

        public void GetRole()
        {
            DataTable dt = new UserManager().GetRole();
            if (dt != null && dt.Rows.Count > 0)
            {
                //cmbUserType.Text = dt.Rows[0][0].ToString();
                searchLookUpUserRole.Properties.DataSource = dt;
                searchLookUpUserRole.Properties.DisplayMember = "RoleName";
                searchLookUpUserRole.Properties.ValueMember = "Id";
                //// txtUserId.Text = dt.Rows[0][0].ToString();
                //txtUserId.Tag = dt.Rows[0][0].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserMaster UserAdd = new UserMaster();

                UserAdd.ID = txtUserId.Tag.ToString().Trim();
                UserAdd.UserId = txtUserName.Text;
                UserAdd.Name = txtUserName.Text;
                
                UserAdd.Type = searchLookUpUserRole.Properties.ValueMember;
                UserAdd.Password = txtPassword.Text;
                UserAdd.Date = txtDate.Text;

                //UserAdd.insertPermission = CheckRoleSave.Checked;
                //UserAdd.deletePermission = CheckRoleDelete.Checked;
                //UserAdd.editPermission = CheckRoleEdit.Checked;
                //UserAdd.reportingPermission = CheckRoleReporting.Checked;



                MessageModel message = new UserManager().SaveUserInfo(UserAdd);
                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancel.PerformClick();
               
            }
            catch (Exception)
            {

                //throw;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserId.Tag = string.Empty;
            txtUserId.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtVerifyPassword.Text = string.Empty;
            cmbUserType.Text = string.Empty;
            CheckRoleSave.Checked = false;
            CheckRoleEdit.Checked = false;
            CheckRoleDelete.Checked = false;
            CheckRoleReporting.Checked = false;
            txtDate.Text = DateTime.Today.ToString().Trim();
            btnSave.Enabled = true;
            txtUUserId.Focus();
            GetUserID();
            getUserInput();
        }
        public void getUserInput()
        {
            DataTable dt = new UserManager().getUserInput(lstvUser);
            dt = new UserManager().getUserInput(lstvUpdate);
           
        }
        private void CreateNewUser_Load(object sender, EventArgs e)
        {
            getUserInput();
            GetRole();}

        private void lstvUpdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rowno = lstvUpdate.FocusedItem.Index;
            string UsrId = lstvUpdate.Items[rowno].SubItems[0].Text;
            DataTable dt = new UserManager().getUserUpdate(UsrId);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtUUserId.Tag = dt.Rows[0][0].ToString();
                txtUUserId.Text = dt.Rows[0][1].ToString();
                txtUUserName.Text = dt.Rows[0][2].ToString();
                txtOldPassword.Tag = dt.Rows[0][3].ToString();
                txtUDate.Text = dt.Rows[0][4].ToString();
                cmbUType.SelectedIndex = Convert.ToInt16(dt.Rows[0][5]);
                
                
                ////var chkSave = dt.Rows[0]["insertPermission"].ToString();
                ////if (chkSave == "1")
                ////{
                ////    chkUSave.Checked = true;
                ////}
                ////else
                ////{
                ////    chkUSave.Checked = false;
                ////}
                ////var chkDelete = dt.Rows[0]["deletePermission"].ToString();

                ////if (chkDelete == "1")
                ////{
                ////    chkUDelete.Checked = true;
                ////}
                ////else
                ////{
                ////    chkUDelete.Checked = false;
                ////}
                ////var chkUpdate = dt.Rows[0]["editPermission"].ToString();
                ////if (chkUpdate == "1")
                ////{
                ////    chkUEdit.Checked = true;
                ////}
                ////else
                ////{
                ////    chkUEdit.Checked = false;
                ////}
                ////var chkReport = dt.Rows[0]["reportingPermission"].ToString();
                ////if (chkReport == "1")
                ////{
                ////    chkUReporting.Checked = true;
                ////}
                ////else
                ////{
                ////    chkUReporting.Checked = false;
                ////}

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;txtUUserId.Focus();
            }
            else
            {
                MessageBox.Show("No Data Found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                UserMaster UserAdd = new UserMaster();

                UserAdd.ID = txtUUserId.Tag.ToString().Trim();
                UserAdd.UserId = txtUUserId.Text;
                UserAdd.Name = txtUUserName.Text;
                UserAdd.Type = cmbUType.Text;
                UserAdd.Password = txtNewPassword.Text;
                UserAdd.Date = txtUDate.Text;
                //UserAdd.insertPermission = chkUSave.Checked;
                //UserAdd.deletePermission = chkUDelete.Checked;
                //UserAdd.editPermission = chkUEdit.Checked;
                //UserAdd.reportingPermission = chkUReporting.Checked;



                MessageModel message = new UserManager().UpdateUser(UserAdd);
                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUCancel.PerformClick();

            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void btnUCancel_Click(object sender, EventArgs e)
        {
            txtUUserId.Tag = string.Empty;
            txtUUserId.Text = string.Empty;
            txtUUserName.Text = string.Empty;
            txtOldPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            cmbUType.Text = string.Empty;
            //chkUSave.Checked = false;
            //chkUEdit.Checked = false;
            //chkUDelete.Checked = false;
            //chkUReporting.Checked = false;
            txtUDate.Text = DateTime.Today.ToString().Trim();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtUUserId.Focus();
            GetUserID();
            getUserInput();
            
            txtUUserId.Focus();
 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRoleSave_Click(object sender, EventArgs e)
        {
            UserMaster UserAdd = new UserMaster();

            UserAdd.RoleName = txtUserName.Text;
            UserAdd.Name = txtUserName.Text;
           
            UserAdd.insertPermission = CheckRoleSave.Checked;
            UserAdd.deletePermission = CheckRoleDelete.Checked;
            UserAdd.editPermission = CheckRoleEdit.Checked;
            UserAdd.reportingPermission = CheckRoleReporting.Checked;
        }

        private void chkMenu_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}