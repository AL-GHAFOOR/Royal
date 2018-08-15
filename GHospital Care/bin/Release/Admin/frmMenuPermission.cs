using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Paragon;

namespace BABInventory.forms
{
    public partial class frmMenuPermission : DevExpress.XtraEditors.XtraForm
    {
        financialyr dataconn = new financialyr();
        public frmMenuPermission()
        {
            InitializeComponent();            
        }

        private void buttongEnable(bool stat)
        {
            btnSave.Enabled = stat;            
        }
        private void cmbAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[5].Value = false;
                dgv.Rows[i].Cells[6].Value = false;
                dgv.Rows[i].Cells[7].Value = false;
                dgv.Rows[i].Cells[8].Value = false;
                dgv.Rows[i].Cells[9].Value = false;
            }
            if (cmbAccountName.SelectedValue.ToString()=="0")
            {
                return;
            }
            

            string query1 = "select RoleId, RoleName, Description from RoleHospital where RoleName = '" + cmbAccountName.Text.Trim() + "'";
            DataTable dt1 = dataconn.dataread(query1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
               txtRoleName.Text = dt1.Rows[0][1].ToString();
                Description.Text = dt1.Rows[0][2].ToString();
            }

            //string queryPerm = "select insertPermission, deletePermission, EditPermission, ReportPermission, Permission from tblUserInfo where UserId = '"+ cmbAccountName.Text.Trim() +"'";
            //DataTable dtperm = dataconn.dataread(queryPerm);
            //if (dtperm != null && dtperm.Rows.Count > 0)
            //{
            //    chkSave.Checked = bool.Parse(dtperm.Rows[0][0].ToString());
            //    chkEdit.Checked = bool.Parse(dtperm.Rows[0][2].ToString());
            //    chkDelete.Checked = bool.Parse(dtperm.Rows[0][1].ToString());
            //    chkReporting.Checked = bool.Parse(dtperm.Rows[0][3].ToString());
            //}
          
            string query = "select F.SlNo, F.formName, F.formCaption, F.MenuName, F.MenuCaption,  M.Permission,M.insertPermission, M.EditPermission,M.deletePermission, M.ReportPermission from tblMenuPermissionHospital M " +
                           "left join tblFormNameHospital F on M.FormID = F.SlNo where M.RoleId = '" + cmbAccountName.SelectedValue + "'";
            
            DataTable dt = dataconn.dataread(query);
           
            if (dt != null && dt.Rows.Count > 0)
            {
               // dgv.Rows.Clear();
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string name = dt.Rows[j][0].ToString();
                        if (dgv.Rows[i].Cells[0].Value.ToString() == name)
                        {
                            dgv.Rows[i].Cells[5].Value = bool.Parse(dt.Rows[j][5].ToString());
                            dgv.Rows[i].Cells[6].Value = bool.Parse(dt.Rows[j][6].ToString());
                            dgv.Rows[i].Cells[7].Value = bool.Parse(dt.Rows[j][7].ToString());
                            dgv.Rows[i].Cells[8].Value = bool.Parse(dt.Rows[j][8].ToString());
                            dgv.Rows[i].Cells[9].Value = bool.Parse(dt.Rows[j][9].ToString());
                        }
                        
                        
                    }
                }
            }
            else
            {
                chkAll.Checked = true;
                chkAll.Checked = false;
            }
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
        }

        protected internal void frmMenuPermission_Load(object sender, EventArgs e)
        {   
            //buttongEnable(true);
           RoleId();
            userLoad();
            formLoad();
            btnEdit.Enabled = false;

        }

        private void userLoad()
        {
            string query = "select RoleId,RoleName from RoleHospital";
            DataTable dt = dataconn.dataread(query);

            DataRow row = dt.NewRow();
            row["RoleId"] = 0;
            row["RoleName"] = "Select User";
            dt.Rows.Add(row);

            cmbAccountName.DisplayMember = "RoleName";
            cmbAccountName.ValueMember = "RoleId";
            var table = dt.AsEnumerable().OrderBy(a => Convert.ToInt16(a["RoleId"])).CopyToDataTable();
            cmbAccountName.DataSource = table;

        }

        private void RoleId()
        {
            string query = "select Max(Isnull(RoleId,1)) from RoleHospital";
            DataTable dt = dataconn.dataread(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtRoleName.Tag = dt.Rows[0][0].ToString();
            }
        }

        private void formLoad()
        {
            string query = "select SlNo, FormName, FormCaption,MenuName,MenuCaption from tblFormNameHospital";
            DataTable dt = dataconn.dataread(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv.Rows.Add(dt.Rows[i]["SlNo"].ToString(),dt.Rows[i]["FormName"].ToString(),
                        dt.Rows[i]["FormCaption"].ToString(),dt.Rows[i]["MenuName"].ToString(),
                        dt.Rows[i]["MenuCaption"].ToString()
                        );
                }                
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text != string.Empty)
            {
               // string query = "delete tblMenuPermission where UserId = '" + cmbAccountName.Text.Trim() + "'";
                string queryperm = "insert into RoleHospital(RoleName, Description) values('" + txtRoleName.Text + "','" + Description.Text + "')";
                //bool stat = dataconn.dataedit(query);
                bool statperm = dataconn.dataeditTrans(queryperm);
                if (statperm)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        bool permission = false;
                        bool insertPermission = false;
                        bool editPermission = false;
                        bool deletePermission = false;
                        bool reportPermission = false;
                        if (dgv.Rows[i].Cells[5].Value != null)
                        {
                            if (bool.Parse(dgv.Rows[i].Cells[5].Value.ToString()) == true)
                            {
                                permission = true;
                            }
                            if (bool.Parse(dgv.Rows[i].Cells[6].Value.ToString()) == true)
                            {
                                insertPermission = true;
                            }
                            if (bool.Parse(dgv.Rows[i].Cells[7].Value.ToString()) == true)
                            {
                                editPermission = true;
                            }
                            if (bool.Parse(dgv.Rows[i].Cells[8].Value.ToString()) == true)
                            {
                                deletePermission = true;
                            }
                            if (bool.Parse(dgv.Rows[i].Cells[9].Value.ToString()) == true)
                            {
                                reportPermission = true;}
                            string query1 = "insert into tblMenuPermissionHospital (RoleId , FormId, Permission,insertPermission,EditPermission,deletePermission,ReportPermission) values(" +
                                            "'" + cmbAccountName.SelectedValue + "'" +
                                            ", '" + dgv.Rows[i].Cells[0].Value.ToString() + "'" +
                                            ", '" + permission + "' " +
                                            ", '" + insertPermission + "' " +
                                            ", '" + editPermission + "' " +
                                            ", '" + deletePermission + "' " +
                                            ", '" + reportPermission + "' )";
                            statperm = dataconn.dataeditTrans(query1);
                           
                        }
                    }
                    string message = "Saved Successfully.";
                    if (!statperm)
                        message = "Cannot Save Successfully.";
                  
                    btnCancel.PerformClick();}
            }
            else{
                MessageBox.Show("Please select Account Name.","Rashed Brothers",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                cmbAccountName.Focus();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkAll.Text = "Deselect All";
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[5].Value = true;
                    dgv.Rows[i].Cells[6].Value = true;
                    dgv.Rows[i].Cells[7].Value = true;
                    dgv.Rows[i].Cells[8].Value = true;
                    dgv.Rows[i].Cells[9].Value = true;
                }
            }
            else
            {
                chkAll.Text = "Select All";
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[5].Value = false;
                    dgv.Rows[i].Cells[6].Value = false;
                    dgv.Rows[i].Cells[7].Value = false;
                    dgv.Rows[i].Cells[8].Value = false;
                    dgv.Rows[i].Cells[9].Value = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cmbAccountName.Text = string.Empty;
            txtRoleName.Text = string.Empty;
            Description.Text = string.Empty;
            chkAll.Checked = false;
            chkAll.Text = "Select All";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[5].Value = false;
                dgv.Rows[i].Cells[6].Value = false;
                dgv.Rows[i].Cells[7].Value = false;
                dgv.Rows[i].Cells[8].Value = false;
                dgv.Rows[i].Cells[9].Value = false;
            }
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text != string.Empty)
            {
                string query = "delete tblMenuPermissionHospital where RoleId = '" + cmbAccountName.SelectedValue + "'";
                string queryperm = "Update  RoleHospital set RoleName='" + txtRoleName.Text + "' , Description='" + Description.Text + "' where RoleId= '" + cmbAccountName.SelectedValue + "'";
                bool statperm = dataconn.dataeditTrans(query);
                if (statperm)
                {
                    statperm = dataconn.dataeditTrans(queryperm);
                }
                if (statperm)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        bool permission = false;
                        bool insertPermission = false;
                        bool editPermission = false;
                        bool deletePermission = false;
                        bool reportPermission = false;
                        if (dgv.Rows[i].Cells[5].Value != null)
                        {if (bool.Parse(dgv.Rows[i].Cells[5].Value.ToString()) == true)
                            {
                                permission = true;
                            }
                            if (bool.Parse(dgv.Rows[i].Cells[6].Value.ToString()) == true)
                            {
                                insertPermission = true;
                            }
                            if (bool.Parse(dgv.Rows[i].Cells[7].Value.ToString()) == true)
                            {
                                editPermission = true;
                            }
                            if (bool.Parse(dgv.Rows[i].Cells[8].Value.ToString()) == true)
                            {
                                deletePermission = true;
                            }
                            if (bool.Parse(dgv.Rows[i].Cells[9].Value.ToString()) == true)
                            {
                                reportPermission = true;
                            }
                            string query1 = "insert into tblMenuPermissionHospital (RoleId , FormId, Permission,insertPermission,EditPermission,deletePermission,ReportPermission) " +
                                            "values(" +
                                            "'" + cmbAccountName.SelectedValue + "'" +
                                            ", '" + dgv.Rows[i].Cells[0].Value.ToString() + "'" +
                                            ", '" + permission + "' " +
                                            ", '" + insertPermission + "' " +
                                            ", '" + editPermission + "' " +
                                            ", '" + deletePermission + "' " +
                                            ", '" + reportPermission + "' )";
                            statperm = dataconn.dataeditTrans(query1);

                        }
                    }
                    string message = "Update Successfully.";
                    if (!statperm)
                        message = "Cannot Update Successfully.";
                  
                    btnCancel.PerformClick();

                }
            }
            else
            {
                MessageBox.Show("Please select Account Name.", "Rashed Brothers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAccountName.Focus();
            }
        }
    }
}