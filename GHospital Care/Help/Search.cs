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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        private void Search_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }
    }
}
