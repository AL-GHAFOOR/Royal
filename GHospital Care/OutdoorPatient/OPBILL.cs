using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.OutdoorPatient
{
    internal partial class OPBILL : Form
    {
        public OPBILL()
        {
            InitializeComponent();
        }

        public void GetPatient(string pid)
        {
            DataTable patienTable = new OPD_Manager().OutDoorBillPatient();
            gridControl1.DataSource = patienTable;
            
            DataTable existingBillList = new OpdGateway().GetOutdoorPatient();
            gridControl2.DataSource = existingBillList;
        }



        public void ViewBillList()
        {
            DataTable patienTable = new OPD_Manager().OutDoorBillListPatient(FromDate.Value, ToDate.Value);
            gridControl1.DataSource = patienTable;

       }

        public void GetOPBIllID()
        {
            DataTable dt = new OPD_Manager().OPBillID();
            if (dt != null && dt.Rows.Count > 0)
            {
                txtbill.Text = dt.Rows[0][0].ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void DischargeIP_Load(object sender, EventArgs e)
        {
            GetPatient(string.Empty);
            GetOPBIllID();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            string getBill = gridView1.GetFocusedRowCellValue("OPID").ToString();
            DAL.Model.OutDoorBill patientBill = new DAL.Model.OutDoorBill();
            patientBill.OPID = getBill;
            patientBill = new OPD_Manager().GetDischargeBill(patientBill);
            txtdoctorcharge.Text = patientBill.TConsultBill;
            txtservicecharge.Text = patientBill.ServiceCharge.ToString("f");
            lblReg.Text = patientBill.OPID;
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
        }
        DischargeMannager dischargeMannager = new DischargeMannager();

        private void BillCalculate()
        {
            try
            {
                DAL.Model.OutDoorBill patientBill = new DAL.Model.OutDoorBill();
                patientBill.Tax = Convert.ToDouble(txttaxpercent.Text);
                patientBill.discount = Convert.ToDouble(txtdiscount.Text);
                patientBill.AdvancedPayble = Convert.ToDouble(txtadvancePaid.Text);
                patientBill.servicePercent = Convert.ToDouble(txtPrcentService.Text);
                patientBill.TotalBill = Convert.ToDouble(txttotalBill.Text);
                //.....
                patientBill = dischargeMannager.VateCalculeOP(patientBill);
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



        private void txttotalBill_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void txttaxpercent_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void txtadvancePaid_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void txtNetPayble_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
            var ammount = Spell.SpellAmount.InWrods(Convert.ToDecimal(txtNetPayble.Text));
            lblInward.Text = ammount;

        }

        public void Save()
        {
            DAL.Model.OutDoorBill aDischargeBill = new DAL.Model.OutDoorBill();
            aDischargeBill.Date = billDate.Value;
            aDischargeBill.BillNo = txtbill.Text;
            aDischargeBill.OPID = gridView1.GetFocusedRowCellValue("OPID").ToString();
            aDischargeBill.BillType = cmbBillType.Text; aDischargeBill.TotalBill = Convert.ToDouble(txttotalBill.Text);
            aDischargeBill.SubTotal = Convert.ToDouble(txtSubTotal.Text);
            aDischargeBill.discount = Convert.ToDouble(txtdiscount.Text);
            aDischargeBill.AdvancedPayble = Convert.ToDouble(txtadvancePaid.Text);
            aDischargeBill.NetPayble = Convert.ToDouble(txtNetPayble.Text);
            aDischargeBill.HospitalCharge = Convert.ToDouble(txthospitalcharge.Text);
            aDischargeBill.NurseCharge = Convert.ToDouble(txtOTSerivce.Text);
            aDischargeBill.DoctorCharge = Convert.ToDouble(txtdoctorcharge.Text);
            aDischargeBill.RoomBedCharge = Convert.ToDouble(txtBedCharge.Text);
            aDischargeBill.ServiceCharge = Convert.ToDouble(txtservicecharge.Text);
            aDischargeBill.MedicalCharge = Convert.ToDouble(txtmedicaineCharge.Text);
            aDischargeBill.PathologyBill = Convert.ToDouble(txtpathology.Text);
            aDischargeBill.InwardText = lblInward.Text;
            aDischargeBill.Remarks = txtremarks.Text;
            aDischargeBill.OTService = Convert.ToDouble(txtOTSerivce.Text);
            aDischargeBill.OTMedicin = Convert.ToDouble(txtOTMedicine.Text);
            aDischargeBill.vat = Convert.ToDouble(txtTax.Text);

            MessageModel message = new OPD_Manager().SaveDischargeBill(aDischargeBill);
            if (message != null)
            {
                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void specialButton1_Click(object sender, EventArgs e)
        {
            Save();
            if (chkPrint.Checked)
            {
                printBill(lblReg.Text);
            }
            clear();

        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnursecharge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBedCharge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void txtservicecharge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtservicecharge_TextChanged_1(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void txtPrcentService_TextChanged(object sender, EventArgs e)
        {
            BillCalculate();
        }

        private void specialButton2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txttotalBill.Text = "0.00";
            txtSubTotal.Text = "0.00"; ;
            txtdiscount.Text = "0.00";
            txtadvancePaid.Text = "0.00";
            txtNetPayble.Text = "0.00";
            txthospitalcharge.Text = "0.00";
            txtOTSerivce.Text = "0.00";
            txtdoctorcharge.Text = "0.00";
            txtBedCharge.Text = "0.00";
            txtservicecharge.Text = "0.00";
            txtmedicaineCharge.Text = "0.00";
            txtpathology.Text = "0.00";
            lblInward.Text = "";
            txtremarks.Text = "";
            txtOTSerivce.Text = "0.00";
            txtOTMedicine.Text = "0.00";
            txtTax.Text = "0.00";
            lblReg.Text = "";
            lblPatientName.Text = "";
            GetPatient(string.Empty);
            GetOPBIllID();

        }

        private void specialButton3_Click(object sender, EventArgs e)
        {
            
        }


        public void printBill(string getBill)
        {
             getBill = gridView2.GetFocusedRowCellValue("OPID").ToString();
            DataTable dt = new OpdGateway().GetOutdoorPatient(getBill);
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>
            {
               
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
            };
            model.ReportDataSource.Name = "outdoorpatientbill";

            model.ReportDataSource.Value = dt;
            model.ReportPath = "GHospital_Care.Report.rptOutdoorPatientBill.rdlc";
            model.Show(model, this);
        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ViewBillList();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            ViewBillList();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            ViewBillList();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            string PtientID = gridView2.GetFocusedRowCellValue("OPID").ToString();
            printBill(PtientID);
        }
    }
}
