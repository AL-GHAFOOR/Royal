using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.NICU
{
    public partial class DueBillStatus : Form
    {
        private DoctorWisePatientManager aDoctorWisePatientManager;

        public DueBillStatus()
        {
            InitializeComponent();
            aDoctorWisePatientManager = new DoctorWisePatientManager();
        }

        //Method Start here //Method Start here //Method Start here //Method Start here 
        //Method Start here //Method Start here //Method Start here //Method Start here 

        private DataTable data = new DataTable();

        private void LoadDoctors()
        {
            data = aDoctorWisePatientManager.LoadDoctors();
        }

        private void LoadRefferedInfo()
        {
            data = aDoctorWisePatientManager.LoadRefferedInfo();
            searchLookReffered.Properties.DataSource = data;

            searchLookReffered.Properties.DisplayMember = "Name";
            searchLookReffered.Properties.ValueMember = "Id";
        }


        private void DueStatus()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.DueBillStatus(Chk,FromDate.Value, ToDate.Value);
            gridControlPatient.DataSource = data;
        }

        private void DueStatusByReff()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.DueBillStatusByReff(Chk, FromDate.Value, ToDate.Value, searchLookReffered.Text);
            gridControlPatient.DataSource = data;
        }

        //Events Start here //Events Start here //Events Start here //Events Start here 
        //Events Start here //Events Start here //Events Start here //Events Start here 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPayment();
        }

        public void PrintPayment()
        {
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>
            {
                new ReportParameter("dtFrom", FromDate.Value.ToString("d")),
                new ReportParameter("dtTo", ToDate.Value.ToString("d")),
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address", model.Address),
                new ReportParameter("Ledger", searchLookReffered.Text),

            };
            model.ReportDataSource.Name = "DueBillAll";


            DataTable Payment = aDoctorWisePatientManager.DueBillStatusAllByReff(FromDate.Value, ToDate.Value,searchLookReffered.Text);
            model.ReportDataSource.Value = Payment;

            model.ReportPath = "GHospital_Care.Report.rptDueBillStatus.rdlc";
            model.Show(model, this);
        }

        private string Chk = "";
            
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoctorWisePatient_IP_Load(object sender, EventArgs e)
        {
            rdIndoor.Checked = true;
            LoadRefferedInfo();
            DueStatus();
        }

        private void searchLookUpDoctor_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void searchLookReffered_EditValueChanged(object sender, EventArgs e)
        {
            DueStatusByReff();
        }

        private void rdIndoor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
            
        }

        private void rdNICU_CheckedChanged(object sender, EventArgs e)
        {
            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
            
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {

            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
        
         }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

            if (rdIndoor.Checked)
            {
                Chk = "InDoor";
            }
            if (rdNICU.Checked)
            {
                Chk = "NICU";
            }
            DueStatus();
            
        }
    }
}
