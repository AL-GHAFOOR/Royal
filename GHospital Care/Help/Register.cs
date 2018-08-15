using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GHospital_Care.Help
{
    public partial class Register : Form
    {
        Form myParent = new Form();
        public Register(Form Form)
        {
            InitializeComponent();
            Form.Enabled = false;
            myParent = Form;
        }
        private void optHave_CheckedChanged(object sender, EventArgs e)
        {
            if (optHave.Checked == true)
            {
                btnOnline.Visible = false;
                btnRegister.Text = "Register";
                panel1.Enabled = true;
            }
        }
        private void optDont_CheckedChanged(object sender, EventArgs e)
        {
            if (optDont.Checked == true)
            {
                btnOnline.Visible = true;
                btnRegister.Text = "Purchase";
                panel1.Enabled = false;
            }
        }
        private void btnOnline_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gsoft-bd.com/ghospital-care/activator/");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            myParent.Enabled = true;
        }
        private void Register_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                myParent.Enabled = true;
            }
        }
    }
}
