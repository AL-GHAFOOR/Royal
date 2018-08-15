using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.Nurses
{
    public partial class DutyByCommon : Form
    {
        ReportTools.ReportLoader Loader = new GHospital_Care.ReportTools.ReportLoader();
        public DutyByCommon()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Loader.LoadNurseDutySheetAll(crystalReportViewer1, dtStartDate.Text, dtEndDate.Text);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
