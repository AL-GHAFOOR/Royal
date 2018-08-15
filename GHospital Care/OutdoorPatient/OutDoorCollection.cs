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

namespace GHospital_Care.OutdoorPatient
{
    public partial class OutDoorCollection : DevExpress.XtraEditors.XtraForm
    {
        public OutDoorCollection()
        {
            InitializeComponent();
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
            DataTable dt = new InDoorCollectionManager().GetOPCollection(FromDate.Value, ToDate.Value, C_Type);
            gridControl1.DataSource = dt;
        }

        private void OutDoorCollection_Load(object sender, EventArgs e)
        {
            rdBill.Checked = true;
            GetCollection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void chk()
        {
            if (rdAdvance.Checked == true)
            {
                rdBill.Checked = false;
                GetCollection();
            }
            else if (rdBill.Checked == true)
            {
                rdAdvance.Checked = false;
                GetCollection();
            }
        }
        private void rdBill_CheckedChanged(object sender, EventArgs e)
        {
            chk();
        }

        private void rdAdvance_CheckedChanged(object sender, EventArgs e)
        {
            chk();}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>
            {
               new ReportParameter("dtFrom", FromDate.Value.ToString("d")),
                new ReportParameter("dtTo",  ToDate.Value.ToString("d")),
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
            };
            model.ReportDataSource.Name = "opcollection";
            DataTable dt = new InDoorCollectionManager().GetOPCollection(FromDate.Value, ToDate.Value);
            model.ReportDataSource.Value = dt;
            model.ReportPath = "GHospital_Care.Report.rdlcopcollection.rdlc";
            model.Show(model, this);
        }
    }
}