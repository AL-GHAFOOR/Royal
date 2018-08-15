using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.Session
{
    public partial class Logout : Form
    {
        public Logout()
        {
            InitializeComponent();
            UserMaster aUserMaster = new UserMaster();
            MainWindow frm = new MainWindow("", "", aUserMaster.AllUser);
            frm.Enabled = false;
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i = i + 1;
            if (i == 50)
            {
                Session.SessionData Session = new SessionData();
                Session.DestroySession(this);
            }
        }
    }
}
