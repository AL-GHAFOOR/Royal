using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using GHospital_Care.BAL.Manager;

namespace GHospital_Care.IndoorPatient
{
    public partial class IndoorBilllDetails : DevExpress.XtraEditors.XtraForm
    {
        public IndoorBilllDetails(String patientId, string discount)
        {
            InitializeComponent();
            patientID = patientId;
            Discount = discount;
        }

        private String patientID = "";
        private string Discount = "";
        private void IndoorBilllDetails_Load(object sender, EventArgs e)
        {
            GetIpBillInfo();
        }

        decimal _listTotal = 0;
        private void caluclation(GridView view, string Value, TextBox text)
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
                (Convert.ToDecimal(txtConsultTotal.Text) + Convert.ToDecimal(txtPathologyTotal.Text) + Convert.ToDecimal(txtTotalOTService.Text) + Convert.ToDecimal(txtOTMedicineTotal.Text) +
                 Convert.ToDecimal(txtPharmacyTotal.Text) + Convert.ToDecimal(txtHospitalToal.Text)).ToString("0.00");
            txtDiscount.Text = Discount;
            txtNetBill.Text = (Convert.ToDouble(txtTotalBill.Text) - Convert.ToDouble(Discount)).ToString("f");
            //  gridControl4.DataSource = dt3;

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}