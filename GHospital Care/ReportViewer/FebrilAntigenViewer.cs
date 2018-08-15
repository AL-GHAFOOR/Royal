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
    public partial class FebrilAntigenViewer : Form
    {
        public FebrilAntigenViewer(string ReportID)
        {
            InitializeComponent();
            ReportTools.ReportLoader loader = new GHospital_Care.ReportTools.ReportLoader();
            loader.LoadFebrilAntigenReport(crystalReportViewer1, ReportID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
