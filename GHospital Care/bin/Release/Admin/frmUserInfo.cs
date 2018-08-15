using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Paragon;


namespace BABInventory.forms
{
    public partial class frmUserInfo : DevExpress.XtraEditors.XtraForm
    {
        financialyr dataconn = new financialyr();     
       private string warnCaption = "BAB Warning.";
        private string errorCaption = "BAB Error.";
        private string infCaption = "BAB Information.";

        public frmUserInfo()
        {
            InitializeComponent();
        }
        
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Today.ToString();
            txtUDate.Text = DateTime.Today.ToString();
           
            userRole();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEnable(bool stat)
        {
            btnSave.Enabled = stat;
            btnEdit.Enabled = !stat;
            btnDelete.Enabled = !stat;
        }

        private void userListFill(string query, ListView lstv)
        {
            DataTable dt = dataconn.dataread(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                lstv.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstv.Items.Add(dt.Rows[i][0].ToString());                    
                }
            }
        }

        private void userRole()
        {
            String query = "select RoleId, RoleName from RoleHospital";
            DataTable dt = dataconn.dataread(query);
            if (dt != null && dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbUserType.Properties.Items.Add(dt.Rows[i][1]);
                    cmbUType.Properties.Items.Add(dt.Rows[i][1]);
                }
            }
        }

        public string GetUserMaxId()
        {
            String query = "SP_GENERATE_User_ID";
            DataTable dt = dataconn.dataread(query);

            string GetUserMaxId=dt.Rows[0][0].ToString();
            return GetUserMaxId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() != string.Empty)
            {
                if (txtPassword.Text.Trim() != string.Empty)
                {
                    if (txtVerifyPassword.Text.Trim() == txtPassword.Text.Trim())
                    {
                        if (txtDate.Text.Trim() != string.Empty)
                        {
                            if (cmbUserType.Text != string.Empty)
                            {
                                string query = "insert into tblUserInfo (UserId,Id,LoginName, Name, Password, extraDate,Date, RoleId) values(@UserId,@Id,@LoginName,@Name,@Password,@extraDate,@Date,@RoleId)";

                                SqlCommand command = new SqlCommand(query, dataconn.Connection);
                                command.Parameters.AddWithValue("@UserId", txtUserId.Text.Trim());
                                command.Parameters.AddWithValue("@Id", GetUserMaxId());
                                command.Parameters.AddWithValue("@LoginName", txtUserId.Text.Trim());
                                command.Parameters.AddWithValue("@Name", txtUserName.Text.Trim());
                                command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                                command.Parameters.AddWithValue("@extraDate", txtDate.Text);
                                command.Parameters.AddWithValue("@RoleId", cmbUserType.Tag);
                                command.Parameters.AddWithValue("@Date", DateTime.Now);
                                
                              int result=  command.ExecuteNonQuery();
                              
                                string message = "Saved Successfully.";
                                if (result==0)
                                    message = "Cannot Save Successfully.";
                                btnCancel.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Please Select User Type.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cmbUserType.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Creation Date.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDate.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Verify Password.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtVerifyPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Password.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Enter User Name.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtUUserId.Tag.ToString().Trim() != string.Empty)
            {
                if (txtUUserId.Text != string.Empty)
                {
                    if (txtUUserName.Text.Trim() != string.Empty)
                    {
                        if (txtOldPassword.Text.Trim() != string.Empty)
                        {
                            if (txtOldPassword.Text.Trim() == txtOldPassword.Tag.ToString())
                            {
                                if (txtUDate.Text.Trim() != string.Empty)
                                {
                                    if (cmbUType.Text != string.Empty)
                                    {
                                        string query = "update tblUserInfo set  LoginName = '" + txtUUserId.Text.Trim() + "', Name = '" + txtUUserName.Text.Trim() + "', Password = '" + txtNewPassword.Text.Trim() + "', extraDate = '" + txtUDate.Text.Trim() + "', RoleId = '" + cmbUType.Tag.ToString().Trim() + "' where  Id = '" + txtUUserId.Tag.ToString().Trim() + "'";
                                        bool stat = dataconn.dataeditTrans(query);
                                        string message = "Update Successfully.";if (!stat)
                                            message = "Cannot Update Successfully.";
                                      
                                        btnUCancel.PerformClick();
                                       
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Select User Type.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        cmbUType.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Enter Creation Date.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtUDate.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Wrong Password. Please Try Again.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnUCancel.PerformClick();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Password.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtOldPassword.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter User Name.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUUserName.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter User ID", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUUserId.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {if (txtUUserId.Tag.ToString().Trim() != string.Empty)
            {
                string query = "delete tblUserInfo where UserId = '" + txtUUserId.Tag.ToString().Trim() + "'";
                bool stat = dataconn.dataeditTrans(query);
                string message = "Delete Successfully.";
                if (!stat)
                    message = "Cannot Delete Successfully.";
             btnUCancel.PerformClick();
                
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
            txtDate.Text = DateTime.Today.ToString().Trim();
            btnSave.Enabled = true;
            //txtUserId.Tag = idg.IdGen("tblUserInfo", "USR-");userRole();
            userListFill("select LoginName from tblUserInfo", lstvUser);
            userListFill("select LoginName from tblUserInfo", lstvUpdate);
            txtUserId.Focus();
        }

        private void frmUserInfo_Shown(object sender, EventArgs e)
        {
            userListFill("select LoginName from tblUserInfo", lstvUser);
            userListFill("select LoginName from tblUserInfo", lstvUpdate);
            txtUserId.Focus();
        }

        private void txtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUserName.Focus();
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtVerifyPassword.Focus();
            }
        }

        private void txtVerifyPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDate.Focus();
            }
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbUserType.Focus();
            }
        }     

        private void cmbUserType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 10 || e.KeyChar == 13 || char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == 10 || char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                    cmbUserType.ShowPopup();
                }
                else if (e.KeyChar == 13)
                {
                    if (btnSave.Enabled)
                    {
                        btnSave.PerformClick();
                    }                                  
                }
            }
        }

        private void lstvUpdate_DoubleClick(object sender, EventArgs e)
        {
            int rowno = lstvUpdate.FocusedItem.Index;
            string UsrId = lstvUpdate.Items[rowno].SubItems[0].Text;
            string query = "select Id,LoginName,Name, Password,extraDate,RoleId from tblUserInfo where LoginName = '" + UsrId + "'";
            DataTable dt = dataconn.dataread(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtUUserId.Tag = dt.Rows[0][0].ToString();
                txtUUserId.Text = dt.Rows[0][1].ToString();
                txtUUserName.Text = dt.Rows[0][2].ToString();
                txtOldPassword.Tag = dt.Rows[0][3].ToString();
                txtUDate.Text = dt.Rows[0][4].ToString();
                cmbUType.SelectedIndex = Convert.ToInt16(dt.Rows[0][5])-1;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                txtUUserId.Focus();
            }
            else
            {
                MessageBox.Show("No Data Found.", warnCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
         
            txtUDate.Text = DateTime.Today.ToString().Trim();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            //txtUUserId.Tag = idg.IdGen("tblUserInfo", "USR-");
            userListFill("select LoginName from tblUserInfo", lstvUser);
            userListFill("select LoginName from tblUserInfo", lstvUpdate);
            txtUUserId.Focus();
        }

        private void btnUExit_Click(object sender, EventArgs e)
        {
            this.Close();}

        private void txtUUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { 
                txtUUserName.Focus();
            }
        }

        private void txtUUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtOldPassword.Focus();
            }
        }

        private void txtUPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNewPassword.Focus();
            }
        }

        private void txtUVerifyPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUDate.Focus();
            }
        }

        private void txtUDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbUType.Focus();
            }
        }

        private void cmbUType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 10 || e.KeyChar == 13 || char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == 10 || char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                    cmbUType.ShowPopup();
                }
                else if (e.KeyChar == 13)
                {                    
                    if (btnEdit.Enabled)
                    {
                        btnEdit.PerformClick();
                    }
                }
            }
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTabPage.Name == "page1")
            {
                txtDate.Text = DateTime.Today.ToString();                
            }
            else if (tabControl.SelectedTabPage.Name == "page2")
            {
                txtUDate.Text = DateTime.Today.ToString();                
            }
        }

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        
        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select RoleId from RoleHospital where RoleName= '" + cmbUserType.Text + "' ";
            DataTable dt = dataconn.dataread(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbUserType.Tag =   dt.Rows[0][0].ToString();
            }
        }

        private void cmbUType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select RoleId from RoleHospital where RoleName= '" + cmbUType.Text + "' ";
            DataTable dt = dataconn.dataread(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbUType.Tag =   dt.Rows[0][0].ToString();
            }
        }

        private void lstvUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}