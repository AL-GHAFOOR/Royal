using System;
using System.Collections.Generic;
using System.Data;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.NICU
{
    public partial class NICUCollection : DevExpress.XtraEditors.XtraForm
    {
        public NICUCollection()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetCollection();
        }

        private void GetCollection()
        {
            string C_Type = "";
            if (rdAdvance.Checked == true)
            {
                C_Type = "Advance";
            }
            else
            {
                C_Type = "Settlement";
            }
            DataTable dt = new InDoorCollectionManager().GetNICUCollection(FromDate.Value, ToDate.Value,C_Type);
            gridControl1.DataSource = dt;
        }

        private void chk()
        {
            if (rdAdvance.Checked == true)
            {
                rdBill.Checked = false;
                GetCollection();
            }
            else if(rdBill.Checked == true)
            {
                rdAdvance.Checked = false;
                GetCollection();
            }
        }

        private void IndoorCollection_Load(object sender, EventArgs e)
        {
            rdBill.Checked = true;
            GetCollection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdBill_CheckedChanged(object sender, EventArgs e)
        {
            chk();
        }

        private void rdAdvance_CheckedChanged(object sender, EventArgs e)
        {
            chk();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>
            {
                new ReportParameter("dtFrom", FromDate.Value.ToString("d")),
                new ReportParameter("dtTo",  ToDate.Value.ToString("d")),
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
                new ReportParameter("reportName",  "Datewise NICU Collection"),
            };
            model.ReportDataSource.Name = "ipcollection";
            DataTable dt = new InDoorCollectionManager().GetNICUCollection(FromDate.Value, ToDate.Value);
            model.ReportDataSource.Value = dt;

            model.ReportPath = "GHospital_Care.Report.rdlcipcollection.rdlc";
            model.Show(model, this);}
    }
}