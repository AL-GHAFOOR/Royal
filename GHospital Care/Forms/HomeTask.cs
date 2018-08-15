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

namespace GHospital_Care.Forms
{
    public partial class HomeTask : Form
    {
        public HomeTask()
        {
            InitializeComponent();
            LoadCompany();
        }
        private void NewUser()
        {
            LoadUser();

            txtUserEmail.Text = "";
            txtUserFullName.Text = "";
            txtUserLoginName.Text = "";
            txtUserPassword.Text = "";
            txtUserRepeatPassword.Text = "";
            txtUserTelephone.Text = "";

            optUserActive.Checked = true;

            picUserPhoto.Image = null;

            txtUserLoginName.Focus();
        }
        private void LoadCompany()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblCompany where CompanyID=@CompanyID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                cmd.Parameters[0].Value = "1";
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtCompanyAddress.Text = dt.Rows[0]["StreetAddress"].ToString();
                    txtCompanyEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    txtHotline1.Text = dt.Rows[0]["Hotline1"].ToString();
                    txtHotline2.Text = dt.Rows[0]["Hotline2"].ToString();
                    txtSloganText.Text = dt.Rows[0]["SloganText"].ToString();
                    txtWebsite.Text = dt.Rows[0]["Website"].ToString();

                    byte[] img = (byte[])dt.Rows[0]["Logo"];
                    MemoryStream msimage = new MemoryStream(img);
                    Bitmap myImage = (Bitmap)Bitmap.FromStream(msimage);
                    picCompanyLogo.Image = (Image)myImage;
                }
            }
            catch
            {
                MessageBox.Show("Company Record Not Found!","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void LoadUser()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand ds = da.SelectCommand;
                ds.CommandText = "select* from tblUserAccount";
                ds.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbFindUser.DataSource = dt;
                cmbFindUser.DisplayMember = "LoginName";
            }
            catch
            {
            }
        }
        private void SaveCompany()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_COMPANY_PROFILE", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar, 250);
                cmd.Parameters.Add("@SloganText", SqlDbType.VarChar, 250);
                cmd.Parameters.Add("@Hotline1", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Hotline2", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Website", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = "1";
                cmd.Parameters[1].Value = txtCompanyName.Text;
                cmd.Parameters[2].Value = txtCompanyAddress.Text;
                cmd.Parameters[3].Value = txtSloganText.Text;
                cmd.Parameters[4].Value = txtHotline1.Text;
                cmd.Parameters[5].Value = txtHotline2.Text;
                cmd.Parameters[6].Value = txtCompanyEmail.Text;
                cmd.Parameters[7].Value = txtWebsite.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                UpdateLogo();

                MessageBox.Show("Company Profile Updated Successfully!","Company Profile",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch
            {
            }
        }
        private void UpdateLogo()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);

                FileInfo file = new FileInfo(filename.Trim());
                byte[] content = new byte[file.Length];
                FileStream imagefile = file.OpenRead();
                imagefile.Read(content, 0, content.Length);
                SqlCommand cmd = new SqlCommand("UPDATE tblCompany SET Logo=@Logo where CompanyID=@CompanyID", ob);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                cmd.Parameters.Add("@Logo", SqlDbType.Image);

                cmd.Parameters[0].Value = "1";
                cmd.Parameters[1].Value = content;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                cmd.Parameters.Clear();
                filename = "";
            }
            catch(Exception error)
            {
                MessageBox.Show("Failed to set logo! "+error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string filename = string.Empty;
        private void UploadPicture(PictureBox PicBox)
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
                    PicBox.Image = (Image)bmp;
                }
            }
            catch
            {
            }
        }
        private void RemovePicture(PictureBox PicBox)
        {
            if (PicBox.Image == null)
            {
                MessageBox.Show("No content available to remove!", "No Content", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                PicBox.Image = null;
            }
        }
        private void txxtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtCompanyAddress.Focus();
            }
        }
        private void txtCompanyAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtSloganText.Focus();
            }
        }
        private void txtSloganText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtHotline1.Focus();
            }
        }
        private void txtHotline1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtHotline2.Focus();
            }
        }
        private void txtHotline2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtCompanyEmail.Focus();
            }
        }
        private void txtCompanyEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtWebsite.Focus();
            }
        }
        private void btnUploadLogo_Click(object sender, EventArgs e)
        {
            UploadPicture(picCompanyLogo);
        }
        private void btnRemoveLogo_Click(object sender, EventArgs e)
        {
            RemovePicture(picCompanyLogo);
        }
        private void btnColseCompany_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnSaveCompany_Click(object sender, EventArgs e)
        {
            SaveCompany();
        }
        private void btnUserClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnUserUploadPhoto_Click(object sender, EventArgs e)
        {
            UploadPicture(picUserPhoto);
        }
        private void btnUserRemovePhoto_Click(object sender, EventArgs e)
        {
            RemovePicture(picUserPhoto);
        }
    }
}
