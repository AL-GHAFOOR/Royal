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
    public partial class BloodGroup : Form
    {
        ReportTools.ReportLoader loader = new GHospital_Care.ReportTools.ReportLoader();
        public BloodGroup(string ReportID)
        {
            InitializeComponent();
            loader.LoadBloodGroupReport(crystalReportViewer1, ReportID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
