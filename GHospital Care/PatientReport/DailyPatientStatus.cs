using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.PatientReport
{
    public partial class DailyPatientStatus : Form
    {
        public DailyPatientStatus()
        {
            InitializeComponent();
        }

        ReportMethod aReportMethod = new ReportMethod();

        private void btnShow_Click(object sender, EventArgs e)
        {
         reportShow();
        }

        private void DailyPatientStatus_Load(object sender, EventArgs e)
        {
            reportShow();

            // gridControl1.DataSource = new PatientReportManager().GetAllPatientStatus(dtFrom.Value, dtTo.Value);
            //  this.aReportMethod.RefreshReport();
        }

        public void reportShow()
        {
            panel3.Controls.Clear();

            DataTable dt = new PatientReportManager().GetAllPatientStatus(dtFrom.Value, dtTo.Value);
            aReportMethod.aReportForm = new ReportForm();
            aReportMethod.aSource.Value = dt;
            aReportMethod._reportParameters = new List<ReportParameter>
            {
                //new ReportParameter("Company", aReportMethod.Company),
                //new ReportParameter("Address", aReportMethod.Address),
                //new ReportParameter("FromDate", dateTimeFromDate.Text),
                // new ReportParameter("ToDate", dateTimeToDate.Text),
                //new ReportParameter("ReportName", lblReportName.Text),

            };

            aReportMethod.ReportMethods("GHospital_Care.Report.rptDailyPatientStatus.rdlc", aReportMethod.aSource, "DailyPatientStatus", aReportMethod._reportParameters);


            aReportMethod.aReportForm.MdiParent = this.MdiParent;



            aReportMethod.aReportForm.FormBorderStyle = FormBorderStyle.None; aReportMethod.aReportForm.TopLevel = false; aReportMethod.aReportForm.WindowState = FormWindowState.Maximized;


            panel3.Controls.Add(aReportMethod.aReportForm);
            aReportMethod.aReportForm.Show();
        }

        public void DailyUptoDateProfilePatients()
        {
            panel3.Controls.Clear();

            DataTable dt = new PatientReportManager().GetAllPatientStatus(dtFrom.Value, dtTo.Value);
            aReportMethod.aReportForm = new ReportForm();
            aReportMethod.aSource.Value = dt;

            int occupied = dt.AsEnumerable().Where(a => a["Status"].ToString() == "Existing Paitent").GroupBy(a => a["PatientName"]).ToList().Count;


            int Total = dt.AsEnumerable().GroupBy(a => a["PatientName"]).ToList().Count;

            aReportMethod._reportParameters = new List<ReportParameter>
            {
                new ReportParameter("Total",Total.ToString()),new ReportParameter("Occupied", occupied.ToString()),
                new ReportParameter("Vacant",(Total-occupied).ToString()),
               
                };
            aReportMethod.ReportMethods("GHospital_Care.Report.rptDailyUptodatePatientProfile.rdlc", aReportMethod.aSource, "DailyPatientStatus", aReportMethod._reportParameters);


            aReportMethod.aReportForm.MdiParent = this.MdiParent;



            aReportMethod.aReportForm.FormBorderStyle = FormBorderStyle.None; aReportMethod.aReportForm.TopLevel = false; aReportMethod.aReportForm.WindowState = FormWindowState.Maximized;


            panel3.Controls.Add(aReportMethod.aReportForm);
            aReportMethod.aReportForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DailyUptoDateProfilePatients();
        }
    }
}
