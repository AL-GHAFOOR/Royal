using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.CustomLibry
{
    public class ReportModel
    {
        public List<ReportParameter> Parameters { get; set; }
        public ReportDataSource ReportDataSource { get; set; }
      
        public List<ReportDataSource> MultiReportDataSource { get; set; }

        public string ReportPath { get; set; }
        public String Company = "Royal Hospital";
        public String Address = "Chittagong";
        public  ReportModel()
        {
            Parameters=new List<ReportParameter>();
            ReportDataSource=new ReportDataSource();
           
        }
        public void Show(ReportModel report,Form viewer)
        {
           ReportMethod method=new ReportMethod();
           method.ReportMethodNew(report);
           method.aReportForm.MdiParent = viewer.MdiParent;
           method.aReportForm.WindowState = FormWindowState.Maximized;
           method.aReportForm.Show();
        }
        public void Show1(ReportModel report, Form viewer)
        {
            ReportMethod method = new ReportMethod();
            method.ReportMethodNew(report);
            method.aReportForm.MdiParent = viewer.MdiParent;
            method.aReportForm.WindowState = FormWindowState.Maximized;
            method.aReportForm.Show();
        }
        public void Show(ReportModel report, Form viewer,bool reportType)
        {
            ReportMethod method = new ReportMethod();
            method.ReportMethodNew(report, reportType);
            method.aReportForm.MdiParent = viewer.MdiParent;
            method.aReportForm.WindowState = FormWindowState.Maximized;
            method.aReportForm.Show();
        }
    }
}
