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
    public partial class CheckUpdate : Form
    {
        public CheckUpdate()
        {
            InitializeComponent();
            string URI = "http://gsoft-bd.com/hms/update/";
            webBrowser1.Navigate(URI);
        }
    }
}
