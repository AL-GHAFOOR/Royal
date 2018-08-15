using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GHospital_Care.Nurses
{
    public partial class DutyByNurse : Form
    {
        ReportTools.ReportLoader Loader = new GHospital_Care.ReportTools.ReportLoader();
        public DutyByNurse()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(txtNurseID.Text=="")
            {
                MessageBox.Show("Nurse ID can not be empty!","Empty Value",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            Loader.LoadNurseDutySheetByNurse(crystalReportViewer1, dtStartDate.Text, dtEndDate.Text,txtNurseID.Text);
        }
    }
}
