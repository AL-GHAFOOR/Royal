using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GHospital_Care.BAL.Manager;

namespace GHospital_Care.IndoorPatient
{
    public partial class DoctorWisePatient_IP : Form
    {
        private DoctorWisePatientManager aDoctorWisePatientManager;

        public DoctorWisePatient_IP()
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
            searchLookUpDoctor.Properties.DataSource = data;

            searchLookUpDoctor.Properties.DisplayMember = "DoctorName";
            searchLookUpDoctor.Properties.ValueMember = "DoctorID";
        }

        private void LoadRefferedInfo()
        {
            data = aDoctorWisePatientManager.LoadRefferedInfo();
            searchLookReffered.Properties.DataSource = data;
            searchLookReffered.Properties.DisplayMember = "Name";
            searchLookReffered.Properties.ValueMember = "Id";
        }


        private void GridLoadDefault()
        {
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.GridLoadDefault();
            gridControlPatient.DataSource = data;
        }

        //Events Start here //Events Start here //Events Start here //Events Start here 
        //Events Start here //Events Start here //Events Start here //Events Start here 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Are you really want to print this?", "Print", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    try
            //    {
            //        //string total = dataGridView1.Rows.Count.ToString();
            //        DGVPrinter printer = new DGVPrinter();
            //        printer.Title = "Bhashani Hospital & Diagonstic Center";
            //        printer.SubTitle = "Mohiuddin Plaza, Kagmari Road, Babistand, Tangail" + "\n" +
            //                           "Doctor Wise Patient List" + "\n" + "Total Patient: " + total;
            //        printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
            //                                      StringFormatFlags.NoClip;
            //        printer.PageNumbers = true;
            //        printer.PageNumberInHeader = false;
            //        printer.PorportionalColumns = true;
            //        printer.HeaderCellAlignment = StringAlignment.Near;
            //        printer.Footer = "Developed By - " + "GSoft Technologies";
            //        printer.FooterSpacing = 30;

            //        //printer.PrintPreviewDataGridView(dataGridView1);
            //    }catch (Exception error)
            //    {
            //        MessageBox.Show("Failed to print data! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK,
            //            MessageBoxIcon.Exclamation);
            //    }
            //}
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridLoadDefault();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoctorWisePatient_IP_Load(object sender, EventArgs e)
        {
            LoadDoctors();
            LoadRefferedInfo();
            GridLoadDefault();
        }

        private void searchLookUpDoctor_EditValueChanged(object sender, EventArgs e)
        {
            string DoctorId = searchLookUpDoctor.Properties.View.GetFocusedRowCellValue("DoctorID").ToString();
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.GridLoadDutyDoctor(DoctorId);
            gridControlPatient.DataSource = data;
        }

        private void searchLookReffered_EditValueChanged(object sender, EventArgs e)
        {
            string RefferedId = searchLookReffered.Properties.View.GetFocusedRowCellValue("Id").ToString();
            DataTable data = new DataTable();
            data = aDoctorWisePatientManager.GridLoadRefferedBy(RefferedId);
            gridControlPatient.DataSource = data;
        }
    }
}
