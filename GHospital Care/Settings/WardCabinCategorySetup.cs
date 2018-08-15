using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.Admin;

namespace GHospital_Care.Settings
{
    public partial class WardCabinCategorySetup : Form
    {
        public WardCabinCategorySetup()
        {
            InitializeComponent();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
