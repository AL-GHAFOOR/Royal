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
    public partial class Contents : Form
    {
        public Contents()
        {
            InitializeComponent();
            webBrowser1.Navigate(Application.StartupPath.ToString() + "\\help\\help.html");
        }
    }
}
