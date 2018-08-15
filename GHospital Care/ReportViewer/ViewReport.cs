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
    public partial class ViewReport : Form
    {
        ReportTools.ReportLoader Loader = new GHospital_Care.ReportTools.ReportLoader();
        public ViewReport(string ReportTitle, string UniqueKey)
        {
            InitializeComponent();
            Title = ReportTitle;
            UniqueID = UniqueKey;
            SetReport();
        }
        string Title = string.Empty;
        string UniqueID = string.Empty;
        private void SetReport()
        {
            if (Title == "OPBill")
            {
                Loader.LoadOPBill(crystalReportViewer1, UniqueID);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
