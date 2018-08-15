using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Model;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.NICU
{
    public partial class NICUDischargeBill : Form
    {
        public NICUDischargeBill()
        {
            InitializeComponent();
        }

        public void GetNICUPatient(string pid)
        {

            DataTable patienTable = new NICUBillManager().DischargeRequestNICU();
            gridControl1.DataSource = patienTable;
        }

        private void NICUDischargeBill_Load(object sender, EventArgs e)
        {
            GetNICUPatient(string.Empty);
            GetIPGidchargeBillNo();
            chkPrint.Checked = true;}

        private decimal _listTotal = 0;

        private void Totalcaluclation(GridView view, string Value, TextBox text)
        {
            try
            {
                _listTotal = 0;
                for (int i = 0; i < view.RowCount; i++)
                {
                    _listTotal += Convert.ToDecimal(view.GetRowCellValue(i, view.Columns[Value]));
                    text.Text = _listTotal.ToString("0.00");
                }
            }
            catch (Exception)
            {


            }

        }

        public void GetIPGidchargeBillNo()
        {
            DataTable dt = new NICUBillManager().getNICUBillID();
            if (dt != null && dt.Rows.Count > 0)
            {
                txtbill.Text = dt.Rows[0][0].ToString();
            }

        }

        private void BillCalculate()
        {
            try
            {
                DAL.Model.DischargeBillNICU patientBill = new DAL.Model.DischargeBillNICU();
                patientBill.Tax = Convert.ToDouble(txttaxpercent.Text);
                patientBill.discount = Convert.ToDouble(txtdiscount.Text);
                patientBill.AdvancedPayble = Convert.ToDouble(txtadvancePaid.Text);
                patientBill.servicePercent = Convert.ToDouble(txtPrcentService.Text);
                patientBill.TotalBill = Convert.ToDouble(txttotalBill.Text);
                //.....
                patientBill = NICUBillManager.VateCalcule(patientBill);
                txtservicecharge.Text = patientBill.ServiceCharge.ToString("f");
                txtTax.Text = patientBill.Tax.ToString("f");
                txtSubTotal.Text = patientBill.SubTotal.ToString("f");
                txtNetPayble.Text = patientBill.NetPayble.ToString("f");
                var ammount = Spell.SpellAmount.InWrods(Convert.ToDecimal(patientBill.NetPayble));
                lblInward.Text = ammount;

            }
            catch (Exception)
            {
            }
            //MessageBox.Show(ex.Message);

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            string getBill = gridView1.GetFocusedRowCellValue("OPID").ToString();
            DAL.Model.DischargeBillNICU patientBill = new DAL.Model.DischargeBillNICU();
            patientBill.OPID = getBill;
            patientBill = new NICUBillManager().GetDischargeBillNICU(patientBill);
            txtdoctorcharge.Text = patientBill.TConsultBill;
            txtservicecharge.Text = patientBill.ServiceCharge.ToString("f");
            lblReg.Text = patientBill.RegNo;
            txtpathology.Text = patientBill.PBill.ToString("f");
            txtdischargeTime.Text = patientBill.DiscTime;
            txtdischargedate.Text = Convert.ToDateTime(patientBill.DeisDate).ToString("d");
            lblPatientName.Text = patientBill.PatientName;
            txtBedCharge.Text = patientBill.TotalBedCharge;
            txtmedicaineCharge.Text = patientBill.PharmacyBill.ToString("f");
            txtOTSerivce.Text = patientBill.OTservice.ToString("f");
            txtOTMedicine.Text = patientBill.OTMedicine.ToString("f");
            txthospitalcharge.Text = patientBill.HospitalCharge.ToString("f");
            txtnoofdays.Text = patientBill.NoOfDay;
            txttotalBill.Text = patientBill.TotalBill.ToString("f");
            txtadvancePaid.Text = patientBill.AdvancedPayble.ToString("f");
            gridControlNICU.DataSource = patientBill.PatientBill;
            Totalcaluclation(gridView3, "Total", txttotalBill);
        }

        private void txtPrcentService_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void txtservicecharge_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void txttotalBill_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void specialButton1_Click(object sender, EventArgs e)
        {
            Save();
            if (chkPrint.Checked)
            {
                PrintBill(lblReg.Text);
            }
            Clear();
        }

        List<DischargeBillNICU> aBillNicus = new List<DischargeBillNICU>();


        public void Save()
        {
            DAL.Model.DischargeBillNICU aDischargeBill = new DAL.Model.DischargeBillNICU();
            List<DischargeBillNICU> aDischargeBillNicus = new List<DischargeBillNICU>();
            aDischargeBill.Date = billDate.Value;
            aDischargeBill.BillNo = txtbill.Text;
            aDischargeBill.OPID = gridView1.GetFocusedRowCellValue("OPID").ToString();
            aDischargeBill.BillType = cmbBillType.Text;
            aDischargeBill.TotalBill = Convert.ToDouble(txttotalBill.Text);
            aDischargeBill.SubTotal = Convert.ToDouble(txtSubTotal.Text);
            aDischargeBill.discount = Convert.ToDouble(txtdiscount.Text);
            aDischargeBill.AdvancedPayble = Convert.ToDouble(txtadvancePaid.Text);
            aDischargeBill.NetPayble = Convert.ToDouble(txtNetPayble.Text);
            //aDischargeBill.HospitalCharge = Convert.ToDouble(txthospitalcharge.Text);
            //aDischargeBill.NurseCharge = Convert.ToDouble(txtOTSerivce.Text);
            //aDischargeBill.DoctorCharge = Convert.ToDouble(txtdoctorcharge.Text);
            //aDischargeBill.RoomBedCharge = Convert.ToDouble(txtBedCharge.Text);
            aDischargeBill.ServiceCharge = Convert.ToDouble(txtservicecharge.Text);
            //aDischargeBill.MedicalCharge = Convert.ToDouble(txtmedicaineCharge.Text);
            //aDischargeBill.PathologyBill = Convert.ToDouble(txtpathology.Text);
            aDischargeBill.InwardText = lblInward.Text;
            aDischargeBill.Remarks = txtremarks.Text;
            aDischargeBill.OTService = Convert.ToDouble(txtOTSerivce.Text);
            aDischargeBill.OTMedicin = Convert.ToDouble(txtOTMedicine.Text);
            aDischargeBill.vat = Convert.ToDouble(txtTax.Text);

            for (int i = 0; i < gridView3.RowCount; i++)
            {
                DAL.Model.DischargeBillNICU aDischargeBills = new DAL.Model.DischargeBillNICU();
                aDischargeBills.BillNo = txtbill.Text;
                aDischargeBills.ServiceId = gridView3.GetRowCellValue(i, gridView3.Columns["ServiceID"]).ToString();
                aDischargeBills.ServiceName = gridView3.GetRowCellValue(i, gridView3.Columns["Particulars"]).ToString();
                aDischargeBills.ServiceStatus = gridView3.GetRowCellValue(i, gridView3.Columns["Status"]).ToString();
                aDischargeBills.Total = Convert.ToDecimal(gridView3.GetRowCellValue(i, gridView3.Columns["Total"]));
                aDischargeBills.RegNo = lblReg.Text;
                aDischargeBillNicus.Add(aDischargeBills);
            }
            MessageModel message = new NICUBillManager().SaveDischargeBill(aDischargeBill, aDischargeBillNicus);
            if (message != null)
            {
                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            Clear();
        }

        private void Clear()
        {
            gridControlNICU.DataSource = null;
            txtSubTotal.Text = "0.00";
            txttotalBill.Text = "0.00";
            txtdischargeTime.Text = "0.00";
            txtdischargedate.Text = string.Empty;
            lblInward.Text = string.Empty;
            lblPatientName.Text = string.Empty;
            lblReg.Text = string.Empty;
            txtnoofdays.Text = string.Empty;
            txtservicecharge.Text = "0.00";
            txtremarks.Text = string.Empty;
            GetNICUPatient(string.Empty);
            GetIPGidchargeBillNo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
           string PtientID = gridView2.GetFocusedRowCellValue("OPID").ToString();
           PrintBill(PtientID);
        }

        public void PrintBill(string PtientID)
        {
           
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt = new NICUBillManager().PrintDischare(PtientID);
            dt1 = new NICUBillManager().BedHistory(PtientID);
            dt2 = new NICUBillManager().AdvanceInfo(PtientID);
            ReportModel model = new ReportModel();

            model.Parameters = new List<ReportParameter>
            {
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address)
            };
            //  model.ReportDataSource.Name = "indoorpatientbill";

            model.MultiReportDataSource = new List<ReportDataSource>()
            {
                new ReportDataSource("indoorpatientbill",dt),
                new ReportDataSource("BedHistory",dt1),
                new ReportDataSource("AdvanceInfo",dt2),
               
            };
            // model.ReportDataSource.Value = dt;
            model.ReportPath = "GHospital_Care.Report.rptNICUPatientBill.rdlc";
            model.Show(model, this, true);
        }
        private void ViewDischarge()
        {
            DataTable dt = new NICUBillManager().ViewDicharge(FromDate.Value, ToDate.Value);
            gridControl2.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ViewDischarge();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
