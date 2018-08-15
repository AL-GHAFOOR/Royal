using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using GHospital_Care.BAL.Manager;
using GHospital_Care.IndoorPatient;

namespace GHospital_Care.OutdoorPatient
{
    public partial class OPBusinessOffice : Form
    {
        public OPBusinessOffice()
        {
            InitializeComponent();
            rdNotDischarge.Checked = true;
            GetOPInfo();
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
            if (rdNotDischarge.Checked == true)
            {
                return true;
            }
            else if(rdDischarge.Checked== true)
            {
                return false;
            }else
            {
                return true;
            }
        }
        private void specialButton9_Click(object sender, EventArgs e)
        {
            GetOPInfo();
          
        }

        private void GetOPInfo()
        {
            bool chk = chkValue();
            DataTable dt = new BedHistoryManager().GetOPInfo(FromDate.Value, ToDate.Value, chk);
            gridControl1.DataSource = dt;
            Totalcaluclation(gridView1, "C_SubTotal", txtConsult);
            Totalcaluclation(gridView1, "P_SubTotal", txtPharmacy);
            Totalcaluclation(gridView1, "path_Subtotal", txtPathology);
            Totalcaluclation(gridView1, "H_SubTotal", txtHospital);
            Totalcaluclation(gridView1, "OTS_SubTotal", txtOtService);
            Totalcaluclation(gridView1, "OTM_SubTotal", txtOTmedicine);
            Totalcaluclation(gridView1, "DisCount", txtTotalDiscount);
            Totalcaluclation(gridView1, "A_SubTotal", txtAdvance);
            Totalcaluclation(gridView1, "PaidAmount", txtPaid);
            double totalBill = Convert.ToDouble(txtConsult.Text) + Convert.ToDouble(txtPharmacy.Text) +
                               Convert.ToDouble(txtPathology.Text) + Convert.ToDouble(txtHospital.Text) +
                               Convert.ToDouble(txtOtService.Text) + Convert.ToDouble(txtOTmedicine.Text);
            TxtAllTotal.Text = (totalBill).ToString("0.00");
            txtNetAmount.Text = (totalBill - Convert.ToDouble(txtTotalDiscount.Text) - Convert.ToDouble(txtAdvance.Text) - Convert.ToDouble(txtPaid.Text)).ToString("0.00");

        }

        private void GetIpBillInfo()
        {
            DataTable dt = new BillCheckingManager().GetConsultBill(patientID);
            DataTable dt1 = new BillCheckingManager().GetPharmacyBill(patientID);
            DataTable dt2 = new BillCheckingManager().GetPathologyBill(patientID);
            DataTable dt3 = new BillCheckingManager().GetHospitalServiceBill(patientID);
            DataTable dt4 = new BillCheckingManager().GetOTServiceBill(patientID);
            DataTable dt5 = new BillCheckingManager().GetOTMedicineBill(patientID);
            
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
            patientID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OPID").ToString();
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

        private void rdNotDischarge_CheckedChanged(object sender, EventArgs e)
        {
            chkValue();
            GetOPInfo();
        }

        private void rdDischarge_CheckedChanged(object sender, EventArgs e)
        {
            chkValue();
            GetOPInfo();}

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
