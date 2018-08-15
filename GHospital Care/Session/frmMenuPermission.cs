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
    public partial class frmMenuPermission : DevExpress.XtraEditors.XtraForm
    {
        public frmMenuPermission()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void cmbAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkAll.Text = "Deselect All";
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[3].Value = true;
                }}
            else
            {
                chkAll.Text = "Select All";
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[3].Value = false;
                }
            }
        }

        private void frmMenuPermission_Load(object sender, EventArgs e)
        {
            LoadAllUserType();
            

            RoleId();
        }

        private void LoadAllUserType()
        {
            DataTable dt = new UserManager().GetRole();
            cmbRoleUser.DataSource = dt;
            cmbRoleUser.DisplayMember = "RoleName";
            cmbRoleUser.ValueMember = "Id";


        }
        private void formLoad(string role)
        {
            DataTable dt = new UserManager().FormLoad(role);
            foreach ( DataRow row in dt.Rows)
            {
                string fromName = row["FormName"].ToString();
                string caption = row["MenuCaption"].ToString();
                string menuName = row["SubMenu"].ToString();
                dgv.Rows.Add(caption, fromName, menuName);

            }
        }



        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            cmbAccountName.Text = string.Empty;
            chkAll.Checked = false;
            chkSave.Checked = false;
            chkEdit.Checked = false;
            chkDelete.Checked = false;
            chkReporting.Checked = false;

            CheckRoleSelectAll.Checked = false;
        }

        public List<UserMaster> ListOfPermission = new List<UserMaster>();
        public List<UserMaster> ListOfUserRole = new List<UserMaster>();
        public List<UserMaster> ListofMenuPermission()
        {
            ListOfPermission.Clear();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                UserMaster UserAdd = new UserMaster();
                bool s = false;
                if (dgv.Rows[i].Cells[3].Value != null)
                {
                    if (bool.Parse(dgv.Rows[i].Cells["Permission"].Value.ToString()) == true)
                    {
                        s = true;
                        UserAdd.Permission = s;
                        UserAdd.RoleId = (int)cmbRoleUser.SelectedValue;
                        UserAdd.FormName = dgv.Rows[i].Cells["formName"].Value.ToString();
                        UserAdd.MenuName = dgv.Rows[i].Cells["MenuName"].Value.ToString();
                        UserAdd.MenuCaption = dgv.Rows[i].Cells["CaptionName"].Value.ToString();
                        UserAdd.SubMenu = dgv.Rows[i].Cells["MenuName"].Value.ToString();
                        UserAdd.insertPermission = Convert.ToBoolean(dgv.Rows[i].Cells["Insert"].Value);
                        UserAdd.deletePermission = Convert.ToBoolean(dgv.Rows[i].Cells["Update"].Value);
                        UserAdd.editPermission = Convert.ToBoolean(dgv.Rows[i].Cells["Delete"].Value);
                        UserAdd.reportingPermission = Convert.ToBoolean(dgv.Rows[i].Cells["Reporting"].Value);
                        
                        ListOfPermission.Add(UserAdd);
                    }

                }
            }

            return ListOfPermission;
        }




        public List<UserMaster> ListofRole()
        {
            ListOfUserRole.Clear();

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                UserMaster UserAdd = new UserMaster();
                bool s = false;
                if (dataGridViewRole.Rows[i].Cells[3].Value != null)
                {
                    if (bool.Parse(dataGridViewRole.Rows[i].Cells[3].Value.ToString()) == true)
                    {
                        s = true;
                        UserAdd.Permission = s;
                        UserAdd.RoleId = Convert.ToInt32(txtRoleName.Tag);
                        UserAdd.MenuName = dataGridViewRole.Rows[i].Cells[0].Value.ToString();
                        UserAdd.MenuCaption = dataGridViewRole.Rows[i].Cells[2].Value.ToString();
                        UserAdd.SubMenu = dataGridViewRole.Rows[i].Cells[1].Value.ToString();
                        ListOfUserRole.Add(UserAdd);
                    }

                }
            }

            return ListOfUserRole;
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (cmbRoleUser.Text != string.Empty)
            {
                UserMaster UserAdd = new UserMaster();
                UserAdd.MenuPermission = new List<UserMaster>();

                UserAdd.UserId = cmbRoleUser.SelectedValue.ToString();
                
                UserAdd.MenuPermission = ListofMenuPermission();
                UserAdd.UserRoleList = ListofMenuPermission();
                MessageModel message = new UserManager().SaveMenuPermission(UserAdd);
                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancel.PerformClick();
                
                Refresh();
            }
        }

        private void cmbAccountName_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            DataTable dtperm = new UserManager().ChkMenuPermission(cmbAccountName.Text.Trim());
            if (dtperm != null && dtperm.Rows.Count > 0)
            {
                var save = dtperm.Rows[0][0].ToString();
                if (save == "1")
                {
                    chkSave.Checked = true;
                }
                else
                {
                    chkSave.Checked = false;
                }

                var edit = dtperm.Rows[0][1].ToString();
                if (edit == "1")
                {
                    chkEdit.Checked = true;
                }
                else
                {
                    chkEdit.Checked = false;
                }
                var del = dtperm.Rows[0][2].ToString();
                if (del == "1")
                {
                    chkDelete.Checked = true;
                }
                else
                {
                    chkDelete.Checked = false;
                }
                var report = dtperm.Rows[0][3].ToString();
                if (report == "1")
                {
                    chkReporting.Checked = true;
                }
                else
                {
                    chkReporting.Checked = false;
                }

            }
            DataTable dt = new UserManager().ChkMenu(cmbAccountName.Text.Trim());
            if (dt != null && dt.Rows.Count > 0)
            {
                //dgv.Rows.Clear();
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string name = dt.Rows[j][0].ToString();
                        if (dgv.Rows[i].Cells[0].Value.ToString() == name)
                        {
                           dgv.Rows[i].Cells[3].Value = bool.Parse(dt.Rows[j][3].ToString());
                        }
                    }
                }
            }
            else
            {
                chkAll.Checked = true;
                chkAll.Checked = false;
            }
        }

        private void btnRoleRefresh_Click(object sender, EventArgs e)
        {
            cmbAccountName.Text = string.Empty;
            chkAll.Checked = false;
            chkSave.Checked = false;
            chkEdit.Checked = false;
            chkDelete.Checked = false;
            chkReporting.Checked = false;

            
            CheckRoleSelectAll.Text = "Deselect All";
            //for (int i = 0; i < dataGridViewRole.Rows.Count; i++)
            //{
            //    dataGridViewRole.Rows[i].Cells[3].Value = true;
            //}
        }

        private void btnRoleSave_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text != string.Empty)
            {
                UserMaster UserAdd = new UserMaster();
                UserAdd.UserRoleList = new List<UserMaster>();
                
                UserAdd.UserId = cmbAccountName.Text;
                UserAdd.insertPermission = CheckRoleSave.Checked;
                UserAdd.deletePermission = CheckRoleDelete.Checked;
                UserAdd.editPermission = CheckRoleEdit.Checked;
                UserAdd.reportingPermission = CheckRoleReporting.Checked;
                UserAdd.UserRoleList = ListofRole();

                UserAdd.RoleName = txtRoleName.Text;
                UserAdd.RoleDescription = txtRoleDescription.Text;
                UserAdd.RoleId = Convert.ToInt32(txtRoleName.Tag);

                MessageModel message = new UserManager().SaveRole(UserAdd);
                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancel.PerformClick();



                txtRoleName.Text = "";
                txtRoleDescription.Text = "";

                CheckRoleSelectAll.Text = @"Select All";
                CheckRoleSelectAll.Checked = false;

                CheckRoleSave.Checked = false;
                CheckRoleDelete.Checked = false;
                CheckRoleEdit.Checked = false;
                CheckRoleReporting.Checked = false;
                


            }
        }




        private void CheckRoleSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckRoleSelectAll.Checked)
            {
                CheckRoleSelectAll.Text = "Deselect All";
                for (int i = 0; i < dataGridViewRole.Rows.Count; i++)
                {
                    dataGridViewRole.Rows[i].Cells[3].Value = true;
                }
            }
            else
            {
                CheckRoleSelectAll.Text = "Select All";
                for (int i = 0; i < dataGridViewRole.Rows.Count; i++)
                {
                    dataGridViewRole.Rows[i].Cells[3].Value = false;
                    CheckRoleSave.Checked = false;
                    CheckRoleDelete.Checked = false;
                    CheckRoleEdit.Checked = false;
                    CheckRoleReporting.Checked = false;
                }
            }
        }

        public void RoleId()
        {
            DataTable data =new DataTable();
            data=new UserManager().RoleId();
            txtRoleName.Tag=data.Rows[0][0].ToString();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }



        public void Refresh()
        {

            cmbAccountName.Text = string.Empty;
            chkAll.Checked = false;
            chkSave.Checked = false;
            chkEdit.Checked = false;
            chkDelete.Checked = false;
            chkReporting.Checked = false;

            CheckRoleSelectAll.Checked = false;
        }

        private void cmbRoleUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = cmbRoleUser.SelectedValue.ToString();

            formLoad(role);

        }
    }
}