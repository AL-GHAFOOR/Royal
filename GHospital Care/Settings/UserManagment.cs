using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GHospital_Care.Settings
{
    public partial class UserManagment : Form
    {
        public UserManagment()
        {
            InitializeComponent();
            cmbRoll.SelectedIndex = 0;
            LoadData();
        }
        private void FindUser(string LoginName)
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblUserAccount where LoginName=@LoginName";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@LoginName", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = LoginName;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtEmail.Text = dt.Rows[0]["UserEmail"].ToString();
                    txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                    txtLoginName.Text = dt.Rows[0]["LoginName"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtRepeatPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();

                    cmbDesignation.Text = dt.Rows[0]["Designation"].ToString();
                    cmbRoll.Text = dt.Rows[0]["UserRoll"].ToString();

                    string userStatus = dt.Rows[0]["Status"].ToString();

                    if (userStatus == "Active")
                    {
                        optActive.Checked = true;
                    }
                    if (userStatus == "Inactive")
                    {
                        optInactive.Checked = true;
                    }
                    txtLoginName.Enabled = false;

                    byte[] img = (byte[])dt.Rows[0]["Photograph"];
                    MemoryStream msimage = new MemoryStream(img);
                    Bitmap myImage = (Bitmap)Bitmap.FromStream(msimage);
                    picPhoto.Image = (Image)myImage;
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
            ds.CommandText = "Select* from tblUserAccount";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbFindUser.DataSource = dt;
            cmbFindUser.DisplayMember = "FullName";
            cmbFindUser.ValueMember = "LoginName";
        }
        bool isExist = false;
        private void CheckExists()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblUserAccount where LoginName=@LoginName";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@LoginName", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = txtLoginName.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    isExist = true;
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Failed to check this existance! "+error.Message.ToString(),"Failed",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        private void SaveUser()
        {
            try
            {
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Blank password is not allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtPassword.Text != txtRepeatPassword.Text)
                {
                    MessageBox.Show("Password dosen't matched!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtLoginName.Text == "")
                {
                    MessageBox.Show("Please enter your login name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblUserAccount", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@LoginName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@FullName", SqlDbType.VarChar, 255);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 255);
                cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@UserRoll", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@UserEmail", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Telephone", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtLoginName.Text;
                cmd.Parameters[1].Value = txtFullName.Text;
                cmd.Parameters[2].Value = txtPassword.Text;
                cmd.Parameters[3].Value = cmbDesignation.Text;
                cmd.Parameters[4].Value = cmbRoll.Text;
                cmd.Parameters[5].Value = txtEmail.Text;
                cmd.Parameters[6].Value = txtTelephone.Text;

                if (optActive.Checked == true)
                {
                    cmd.Parameters[7].Value = "Active";
                }
                else if (optInactive.Checked == true)
                {
                    cmd.Parameters[7].Value = "Inactive";
                }

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                UpdatePhoto();

                MessageBox.Show("User profile update successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

                txtEmail.Text = "";
                txtFullName.Text = "";
                txtLoginName.Text = "";
                txtPassword.Text = "";
                txtRepeatPassword.Text = "";
                txtTelephone.Text = "";
                cmbRoll.SelectedIndex = 0;

                txtLoginName.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save User information! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void UpdatePhoto()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);

                FileInfo file = new FileInfo(filename.Trim());
                byte[] content = new byte[file.Length];
                FileStream imagefile = file.OpenRead();
                imagefile.Read(content, 0, content.Length);
                SqlCommand cmd = new SqlCommand("UPDATE tblUserAccount set Photograph=@Photograph where LoginName=@LoginName", ob);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@LoginName", SqlDbType.VarChar,50);
                cmd.Parameters.Add("@Photograph", SqlDbType.Image);

                cmd.Parameters[0].Value = txtLoginName.Text;
                cmd.Parameters[1].Value = content;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                cmd.Parameters.Clear();
                filename = "";
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to update logo! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtLoginName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtFullName.Focus();
            }
        }
        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtPassword.Focus();
            }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtRepeatPassword.Focus();
            }
        }
        private void txtRepeatPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                cmbDesignation.Focus();
            }
        }
        private void cmbDesignation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                cmbRoll.Focus();
            }
        }
        private void cmbRoll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtEmail.Focus();
            }
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtTelephone.Focus();
            }
        }
        string filename;
        private void btnUserUploadPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                ofd.Filter = "JPEG Image|*.jpg*|PNG Files|*.png*";

                DialogResult dr = ofd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    filename = ofd.FileName.ToString();
                    Bitmap bmp = new Bitmap(filename);
                    picPhoto.Image = (Image)bmp;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to upload logo! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnUserRemovePhoto_Click(object sender, EventArgs e)
        {
            if (picPhoto.Image == null)
            {
                MessageBox.Show("No content available to remove!", "No Content", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                picPhoto.Image = null;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUser();
        }
        private void btnColse_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void txtLoginName_Leave(object sender, EventArgs e)
        {
            if (isExist == true)
            {
                MessageBox.Show("This user name already exists! Please try another name please.","Already Exists",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtLoginName.Focus();
            }
        }
        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {
            isExist = false;
            CheckExists();
        }
        private void cmbFindUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindUser(cmbFindUser.SelectedValue.ToString());
        }
    }
}
