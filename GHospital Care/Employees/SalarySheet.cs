using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GHospital_Care.Employees
{
    public partial class SalarySheet : Form
    {
        ReportTools.ReportLoader Loader = new GHospital_Care.ReportTools.ReportLoader();
        public SalarySheet()
        {
            InitializeComponent();
            cmbMonth.SelectedIndex = 0;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Loader.LoadSalarySheet(crystalReportViewer1, cmbMonth.Text, txtYear.Text);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
