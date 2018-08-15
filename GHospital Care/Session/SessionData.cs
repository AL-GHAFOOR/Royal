using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.Session
{
    class SessionData
    {
        public void StartSession(string _SessionID, string _CompanyName, string _UserName)
        {
            this.SessionID = _SessionID;
            this.UserName = _UserName;
            this.CompanyName = _CompanyName;
        }
        public void GetSessionData(Label _ID, Label _COM, ToolStripDropDownButton _UN)
        {
            _ID.Text = this.SessionID;
            _COM.Text = this.CompanyName;
            _UN.Text = this.UserName;}
        public void DestroySession(Form Form)
        {
            Application.Restart();
        }
        #region Properties


        #region TextProperties

        private string mID;
        [Category("Text"),
                 Description("The text that is displayed on the button.")]
        public string SessionID
        {
            get { return mID; }
            set { mID = value; }
        }

        private string cName;
        [Category("Text"),
                 Description("The text that is displayed on the button.")]
        public string CompanyName
        {
            get { return cName; }
            set { cName = value; }
        }

        private string uName;
        [Category("Text"),
                 Description("The text that is displayed on the button.")]
        public string UserName
        {
            get { return uName; }
            set { uName = value; }
        }
        #endregion

        public bool EditPermission;
        public bool SavePermission;
        public bool DeletePermission;
        public bool ReportPermision;

        //string 
        public void ChkPermission(String User)
        {
            DataTable chkpermission = new UserGateway().chkpermission(User);
            if (chkpermission != null && chkpermission.Rows.Count > 0)
            {
                var insert = chkpermission.Rows[0]["insertPermission"].ToString();
                if (insert == "1")
                {
                    SavePermission = true;
                }
                else
                {
                    SavePermission = false;
                }
                var edit = chkpermission.Rows[0][1].ToString();
                if (edit == "1")
                {
                    EditPermission = true;
                }
                else
                {
                    EditPermission = false;
                }
                var del = chkpermission.Rows[0][2].ToString();
                if (del == "1")
                {
                    DeletePermission = true;
                }
                else
                {
                    DeletePermission = false;
                }

            }
        }

        public DataTable MenuCheck(UserMaster userMaster)
        {
            DataTable data=new DataTable();
            data = new UserGateway().MenuCheck(userMaster);
            return data;
        }
        public bool permissionCheck(string formName)
        {
            bool stat = new UserGateway().permissionCheck(formName);
            return stat;
        }


        #endregion
    }
}
