using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.IndoorPatient
{
    public partial class frmRcvPayment : DevExpress.XtraEditors.XtraForm
    {
        public frmRcvPayment()
        {
            InitializeComponent();
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            PrintBill(FromDate.Value, ToDate.Value);
        }


        public void PrintBill(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt = new DischargeMannager().PrintHospitalInflow(fromDate, toDate);
            dt1 = new DischargeMannager().PrintHospitalOutflow(fromDate, toDate);
          
            ReportModel model = new ReportModel();

            model.Parameters = new List<ReportParameter>
            {
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
                new ReportParameter("dtFrom",  fromDate.ToString("d")),
                new ReportParameter("dtTo", toDate.ToString("d"))
            };
            //  model.ReportDataSource.Name = "indoorpatientbill";

            model.MultiReportDataSource = new List<ReportDataSource>()
            {
                new ReportDataSource("Collection",dt),
                new ReportDataSource("Payment",dt1),
               
            };
            // model.ReportDataSource.Value = dt;
            model.ReportPath = "GHospital_Care.Report.rptHospitalRvcPayment.rdlc";
            model.Show(model, this, true);
        }
    }
}