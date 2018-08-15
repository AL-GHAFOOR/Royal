using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.IndoorPatient;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.NICU
{
    public partial class NICUBusinessOffice : Form
    {
        public NICUBusinessOffice()
        {
            InitializeComponent();
            rdNotDischarge.Checked = true;
            GetIpInfo();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       // private bool chkValue;

        private bool chkValue()
        {
            Clear();
            if (rdNotDischarge.Checked == true)
            {
                reportName = "Existing NICU Patient";
                return false;
            }
            else if(rdDischarge.Checked== true)
            {
                reportName = "Discharged NICU Patient";
                return true;
            }
            else
            {
                return false;
            }
        }
        private void specialButton9_Click(object sender, EventArgs e)
        {
            GetIpInfo();
          
        }

        private void Clear()
        {
            txtConsult.Text = "0.00";
            txtPharmacy.Text = "0.00"; 
            txtConsult.Text = "0.00";
            txtPathology.Text = "0.00";
            txtHospital.Text = "0.00";
            txtOtService.Text = "0.00";
            txtOTmedicine.Text = "0.00";
            txtTotalDiscount.Text = "0.00";
            txtBedCabin.Text = "0.00";
            txtServiceCharge.Text = "0.00";
            txtAdvance.Text = "0.00";
            txtPaid.Text = "0.00";
            TxtAllTotal.Text = "0.00";
            txtNetAmount.Text = "0.00";
        }
        private void GetIpInfo()
        {
            bool chk = chkValue();
            DataTable dt = new BillCheckingManagerNICU().GetNICUBILLInfo(FromDate.Value, ToDate.Value, chk);
            gridControl1.DataSource = dt;
            Totalcaluclation(gridView1, "C_SubTotal", txtConsult);
            Totalcaluclation(gridView1, "P_SubTotal", txtPharmacy);
            Totalcaluclation(gridView1, "path_Subtotal", txtPathology);
            Totalcaluclation(gridView1, "H_SubTotal", txtHospital);
            Totalcaluclation(gridView1, "OTS_SubTotal", txtOtService);
            Totalcaluclation(gridView1, "OTM_SubTotal", txtOTmedicine);
            Totalcaluclation(gridView1, "DisCount", txtTotalDiscount);
            Totalcaluclation(gridView1, "ServiceCharge", txtServiceCharge);
            Totalcaluclation(gridView1, "A_SubTotal", txtAdvance);
            Totalcaluclation(gridView1, "PaidAmount", txtPaid);
            Totalcaluclation(gridView1, "BC_SubTotal", txtBedCabin);
            double totalBill = Convert.ToDouble(txtConsult.Text) + Convert.ToDouble(txtPharmacy.Text) + Convert.ToDouble(txtServiceCharge.Text) +
                               Convert.ToDouble(txtPathology.Text) + Convert.ToDouble(txtHospital.Text) +Convert.ToDouble(txtBedCabin.Text)+
                               Convert.ToDouble(txtOtService.Text) + Convert.ToDouble(txtOTmedicine.Text);
            TxtAllTotal.Text = (totalBill).ToString("0.00");
            txtNetAmount.Text = (totalBill - Convert.ToDouble(txtTotalDiscount.Text) - Convert.ToDouble(txtAdvance.Text) - Convert.ToDouble(txtPaid.Text)).ToString("0.00");

        }

        private void GetIpBillInfo()
        {
            DataTable dt = new BillCheckingManagerNICU().GetConsultBill(patientID);
            DataTable dt1 = new BillCheckingManagerNICU().GetPharmacyBill(patientID);
            DataTable dt2 = new BillCheckingManagerNICU().GetPathologyBill(patientID);
            DataTable dt3 = new BillCheckingManagerNICU().GetHospitalServiceBill(patientID);
            DataTable dt4 = new BillCheckingManagerNICU().GetOTServiceBill(patientID);
            DataTable dt5 = new BillCheckingManagerNICU().GetOTMedicineBill(patientID);
            
            gridControl5.DataSource = dt;
            gridControl2.DataSource = dt1;
            gridControl3.DataSource = dt2;
            gridControl4.DataSource = dt3;
            gridControl6.DataSource = dt4;
            gridControl7.DataSource = dt5;
            caluclation(gridView5, "SubTotal", txtConsultTotal);
            caluclation(gridView2, "SubTotal", txtPharmacyTotal);
            caluclation(gridView3, "subTotal", txtPathologyTotal);
            caluclation(gridView4, "subTotal", txtHospitalToal);
            caluclation(gridView6, "subTotal", txtTotalOTService);
            caluclation(gridView7, "subTotal", txtOTMedicineTotal);
            txtTotalBill.Text =
                (Convert.ToDecimal(txtConsultTotal.Text) + Convert.ToDecimal(txtPathologyTotal.Text) +Convert.ToDecimal(txtTotalOTService.Text)+Convert.ToDecimal(txtOTMedicineTotal.Text)+
                 Convert.ToDecimal(txtPharmacyTotal.Text) + Convert.ToDecimal(txtHospitalToal.Text)).ToString("0.00");

            //  gridControl4.DataSource = dt3;
        }

        public string patientID = "";
        public string Discuout = "";
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            

        }

       

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            patientID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RegNo").ToString();
            Discuout = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DisCount").ToString();
            GetIpBillInfo();
            IndoorBilllDetails aBilllDetails = new IndoorBilllDetails(patientID, Discuout);
            aBilllDetails.ShowDialog();

        }


      
        private void panelControl5_Paint(object sender, PaintEventArgs e)
        {

        }
        decimal _listTotal=0;
        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "subTotal")
                {
            _listTotal = 0;

                    try
                    {
                        for (int i = 0; i < gridView3.RowCount; i++)
                        {
                            _listTotal += Convert.ToDecimal(gridView3.GetRowCellValue(i, gridView3.Columns["subTotal"]));
                            txtPathologyTotal.Text = _listTotal.ToString("0.00");
                        }
                    }
                    catch
                    {
                        
                    }
            }

         }

        private void caluclation( GridView view,string Value,TextBox text )
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


        private void specialButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl4_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl7_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private string reportName = "";
        private void rdNotDischarge_CheckedChanged(object sender, EventArgs e)
        {
            chkValue();
            GetIpInfo();
        }

        private void rdDischarge_CheckedChanged(object sender, EventArgs e)
        {
            chkValue();
            GetIpInfo();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetIpInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPrintView_Click(object sender, EventArgs e)
        {
            //rdlcIndoorPatientFinalBilling.rdlc
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>{
               new ReportParameter("dtFrom", FromDate.Value.ToString("d")),
                new ReportParameter("dtTo",  ToDate.Value.ToString("d")),
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
                new ReportParameter("reportName",  reportName),
            };
            model.ReportDataSource.Name = "IndoorPatientFinalBilling";

            bool chk = chkValue();
            DataTable dt = new BillCheckingManagerNICU().GetNICUBILLInfo(FromDate.Value, ToDate.Value, chk);
            model.ReportDataSource.Value = dt;

            model.ReportPath = "GHospital_Care.Report.rdlcIndoorPatientFinalBilling.rdlc";
            model.Show(model, this);
        }
    }
}
