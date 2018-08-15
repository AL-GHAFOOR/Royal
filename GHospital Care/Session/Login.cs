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
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.Session
{
    public partial class Login : Form
    {
        SessionData Session = new SessionData();
        Conn ob;
        SqlConnection obCon;
        public static string username = string.Empty;
        string password = string.Empty;
        public static string userID = string.Empty;
        public static bool savePermisison = false;
        public static bool editPermission = false;
        public static bool deletePermission = false;
        public static bool reportingPermission = false;
        public static string userType = string.Empty;
        public static UserMaster aUserMaster = new UserMaster();
        public Login()
        {
            InitializeComponent();
            ob = new Conn();
            obCon = new SqlConnection(ob.strCon);
        }
        public DataTable GetCompany()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* from tblCompany";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //------------------------------------

         //var insert = userData.Rows[0][3].ToString();
         //           if (insert == "1")
         //           {
         //               aUserMaster.AllUser.insertPermission = true;
         //           }
         //           else
         //           {
         //                aUserMaster.AllUser.insertPermission = false;
         //           }
         //           var delete = userData.Rows[0][5].ToString();
         //           if (delete == "1")
         //           {
         //               aUserMaster.AllUser.deletePermission = true;
         //           }
         //           else
         //           {
         //               aUserMaster.AllUser.deletePermission = false;
         //           }
         //           var edit = userData.Rows[0][4].ToString();
         //           if (edit == "1")
         //           {
         //               aUserMaster.AllUser.editPermission = true;
         //           }
         //           else
         //           {
         //               aUserMaster.AllUser.editPermission = false;
         //           }
         //           var report = userData.Rows[0][6].ToString();
         //           if (report == "1")
         //           {
         //               aUserMaster.AllUser.reportingPermission = true;
         //           }
         //           else
         //           {
         //               aUserMaster.AllUser.reportingPermission = false;
         //           }
       // ----------------------------------------
        private void TryLogin()
        {
            try
            {
              
                aUserMaster.AllUser = new UserMaster();
                aUserMaster.UserId = txtLoginName.Text;
                aUserMaster.Password = txtPassword.Text;DataTable userData = new UserManager().LoadUser(aUserMaster);
                if (userData != null && userData.Rows.Count > 0)
                {
                    aUserMaster.ID = userData.Rows[0]["Id"].ToString();
                    aUserMaster.Name = userData.Rows[0]["UserId"].ToString();
                    aUserMaster.Password = userData.Rows[0]["Password"].ToString();
                    aUserMaster.AllUser.Name = username;
                    aUserMaster.AllUser.RoleName = userData.Rows[0]["UserRoll"].ToString().Trim();
                    aUserMaster.RoleId =Convert.ToInt16(userData.Rows[0]["Type"]);
                     
                    aUserMaster.AllUser.machineName = System.Environment.MachineName.ToString().Trim();

                    DataTable dtt = GetCompany();

                    string ComanyName = dtt.Rows[0]["CompanyName"].ToString();
                    string _LoginName = aUserMaster.Name;
                    string _UserName = aUserMaster.Name;
                    string _UserRole = aUserMaster.AllUser.RoleName;
                    Session.UserName = _UserName;

                    MainWindow frm = new MainWindow(_UserName, _UserRole, aUserMaster);
                    frm.Show();
                    this.Hide();
                    

                }
                else
                {
                    MessageBox.Show("Invalid User Name or Password!","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Failed to login! " + error.Message.ToString(), "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lnkGSoft_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gsoft-bd.com");
        }
        private void txtLoginName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtPassword.Focus();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {txtLoginName.Text = "";
            txtPassword.Text = "";

            txtLoginName.Focus();
        }
        private void lnkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you really want to exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            TryLogin();
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TryLogin();
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.Font = new System.Drawing.Font("Wingdings", 9.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPassword.PasswordChar = Convert.ToChar("l");
            txtPassword.ForeColor = Color.Black;
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == "")
                {
                    txtPassword.PasswordChar = Convert.ToChar("");
                    txtPassword.Font = new System.Drawing.Font("Tahoma", 9.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    txtPassword.ForeColor = Color.Silver;
                }
            }
            catch
            {
            }
        }
    }
}
