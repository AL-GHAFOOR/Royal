using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GHospital_Care.ReportViewer
{
    public partial class SerologicalReport : Form
    {
        public SerologicalReport(string ReportID)
        {
            InitializeComponent();
            ReportTools.ReportLoader loader = new GHospital_Care.ReportTools.ReportLoader();
            loader.LoadSerologicalReport(crystalReportViewer1, ReportID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
