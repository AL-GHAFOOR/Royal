using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Microsoft.Reporting.WinForms;



namespace GHospital_Care.CustomLibry
{
    class ReportMethod
    {
        public ReportForm aReportForm;

        MainWindow aMainWindow = new MainWindow("", "", null);

        public void ReportMethods(string path, ReportDataSource aSource, string name, List<ReportParameter> parameters)
        {

            aReportForm.reportViewer1.LocalReport.ReportEmbeddedResource = path;
            aSource.Name = name;
            aSource.Value = aSource.Value;
            aReportForm.reportViewer1.LocalReport.DataSources.Clear();
            aReportForm.reportViewer1.LocalReport.DataSources.Add(aSource);
            aReportForm.reportViewer1.LocalReport.SetParameters(parameters.ToList());
            aReportForm.reportViewer1.LocalReport.Refresh();
        }
        public String Company = "Compnay Name";
        public String Address = "Compnay Address";

        public List<ReportParameter> _reportParameters = new List<ReportParameter>();
        public ReportDataSource aSource = new ReportDataSource();

        public void ReportMethodNew(ReportModel reportModel,bool multisource=false)
        {
            aReportForm = new ReportForm();
            if (multisource)
            {
                aReportForm.reportViewer1.LocalReport.ReportEmbeddedResource = reportModel.ReportPath;
                aReportForm.reportViewer1.LocalReport.DataSources.Clear();
                foreach (ReportDataSource dataSource in reportModel.MultiReportDataSource)
                {
                    aReportForm.reportViewer1.LocalReport.DataSources.Add(dataSource);

                }
                aReportForm.reportViewer1.LocalReport.SetParameters(reportModel.Parameters.ToList());
                aReportForm.reportViewer1.LocalReport.Refresh();
            }
            else
            {
                aReportForm.reportViewer1.LocalReport.ReportEmbeddedResource = reportModel.ReportPath;
                aSource = reportModel.ReportDataSource;
                aReportForm.reportViewer1.LocalReport.DataSources.Clear();
                aReportForm.reportViewer1.LocalReport.DataSources.Add(aSource);
                aReportForm.reportViewer1.LocalReport.SetParameters(reportModel.Parameters.ToList());
                aReportForm.reportViewer1.LocalReport.Refresh();
            }
          

        }
        public void ShowReport(Form report)
        {
            aReportForm.MdiParent = report;
            aReportForm.WindowState = FormWindowState.Maximized;
            aReportForm.Show();
        }
    }
}
