using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using Microsoft.Reporting.WinForms;


namespace GHospital_Care.IndoorPatient
{
    internal partial class DischargeBill : Form
    {
        public DischargeBill()
        {
            InitializeComponent();
        }

        public void GetPatient(string pid)
        {
           
                DataTable patienTable = new MedicalManager().DischargeRequestPatient();
                gridControl1.DataSource = patienTable;
        }


        public void GetIPGidchargeBillNo()
        {
            DataTable dt = new MedicalManager().getIPGischargeBillID();
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
            chkPrint.Checked = true;
            if (specialButton1.Text == "Discharge")
            {
                GetIPGidchargeBillNo();    
            }
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            string getBill = gridView1.GetFocusedRowCellValue("OPID").ToString();
            lblPatientID.Text = getBill;
            DAL.Model.DischargeBill patientBill = new DAL.Model.DischargeBill();
            patientBill.OPID = getBill;
            patientBill = new MedicalManager().GetDischargeBill(patientBill);
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
        }
        DischargeMannager dischargeMannager=new DischargeMannager();


        private void BillCalculate()
        {
            try
            {
                DAL.Model.DischargeBill patientBill = new DAL.Model.DischargeBill();
                patientBill.Tax = Convert.ToDouble(txttaxpercent.Text);
                patientBill.discount = Convert.ToDouble(txtdiscount.Text);
                patientBill.AdvancedPayble = Convert.ToDouble(txtadvancePaid.Text);
                patientBill.servicePercent = Convert.ToDouble(txtPrcentService.Text);
                patientBill.TotalBill = Convert.ToDouble(txttotalBill.Text);
                //.....
                patientBill = dischargeMannager.VateCalcule(patientBill);
                txtservicecharge.Text = patientBill.ServiceCharge.ToString("f");
                txtTax.Text = patientBill.Tax.ToString("f");
                txtSubTotal.Text = patientBill.SubTotal.ToString("f");
                txtNetPayble.Text = patientBill.NetPayble.ToString("f");
                var ammount = Spell.SpellAmount.InWrods(Convert.ToDecimal(patientBill.NetPayble));
                lblInward.Text = ammount;

            }catch (Exception)
            {}
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
            DAL.Model.DischargeBill aDischargeBill=new DAL.Model.DischargeBill();
            aDischargeBill.Date = billDate.Value;
            aDischargeBill.BillNo = txtbill.Text;
            aDischargeBill.BillType = cmbBillType.Text;
            aDischargeBill.TotalBill = Convert.ToDouble(txttotalBill.Text);
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
            MessageModel message= new MessageModel();
            if (specialButton1.Text == "Update")
            {
                aDischargeBill.OPID = gridView2.GetFocusedRowCellValue("OPID").ToString();
                message = new DischargeMannager().UpdateDischargeBill(aDischargeBill);
            }
            else
            {
                aDischargeBill.OPID = gridView1.GetFocusedRowCellValue("OPID").ToString();
                message = new DischargeMannager().SaveDischargeBill(aDischargeBill);    
            }
            
            if (message!=null)
            {
               
                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
    
            }
            
        }


        public void Update()
        {
            DAL.Model.DischargeBill aDischargeBill = new DAL.Model.DischargeBill();
            aDischargeBill.Date = billDate.Value;
            aDischargeBill.BillNo = txtbill.Text;
            aDischargeBill.OPID = gridView2.GetFocusedRowCellValue("OPID").ToString();
            aDischargeBill.BillType = cmbBillType.Text;
            aDischargeBill.TotalBill = Convert.ToDouble(txttotalBill.Text);
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
            MessageModel message = new MessageModel();
            if (specialButton1.Text == "Update")
            {
                message = new DischargeMannager().UpdateDischargeBill(aDischargeBill);
            }
            if (message != null)
            {

                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void specialButton1_Click(object sender, EventArgs e)
        {
            if (chkHC.Checked == false || chkCC.Checked == false || chkBC.Checked == false || chkMC.Checked == false ||
                chkPC.Checked == false || ChkOTMC.Checked == false || ChkOTSC.Checked == false)
            {
                MessageBox.Show("Please Check Bill Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              Save();
                if (chkPrint.Checked)
                {
                   PrintBill(lblPatientID.Text);
                }
              clear();
              checkBox1.Checked = false;

            }
               
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            lblPatientID.Text = "";
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
            GetIPGidchargeBillNo();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ViewDischarge();
        }
        private void ViewDischarge()
        {
            DataTable dt = new DischargeMannager().ViewDicharge(FromDate.Value, ToDate.Value);
            gridControl2.DataSource = dt;
        }

       

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
           string  PtientID = gridView2.GetFocusedRowCellValue("OPID").ToString();
           PrintBill(PtientID);
        }


        public void PrintBill(string PtientID)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt = new DischargeMannager().PrintDischare(PtientID);
            dt1 = new DischargeMannager().BedHistory(PtientID);
            dt2 = new DischargeMannager().AdvanceInfo(PtientID);
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
            model.ReportPath = "GHospital_Care.Report.rptIndoorPatientBill.rdlc";
            model.Show(model, this, true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==false)
            {
                chkHC.Checked = false;
                chkCC.Checked = false;
                chkBC.Checked = false;
                chkMC.Checked = false;
                chkPC.Checked = false;
                ChkOTMC.Checked = false;
                ChkOTSC.Checked = false;

            }
            else
            {
                chkHC.Checked = true;
                chkCC.Checked = true;
                chkBC.Checked = true;
                chkMC.Checked = true;
                chkPC.Checked = true;
                ChkOTMC.Checked = true;
                ChkOTSC.Checked = true;
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ((DXMouseEventArgs)e).Handled = true;
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                if (hitInfo.InRow)
                {
                    view.FocusedColumn = hitInfo.Column;
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    view.ShowEditor();
                    contextMenuStrip1.Show(view.GridControl, e.Location);

                }
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            string getBill = gridView2.GetFocusedRowCellValue("OPID").ToString();
            lblPatientID.Text = getBill;
            DAL.Model.DischargeBill patientBill = new DAL.Model.DischargeBill();
            patientBill.OPID = getBill;
            patientBill = new MedicalManager().GetDischargeBill_Update(patientBill);
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
            txtremarks.Text = patientBill.Remarks;
            txtbill.Text = patientBill.BillNo;
            xtraTabPage1.Show();
            specialButton1.Text = "Update";
        }

        private void specialButton3_Click(object sender, EventArgs e)
        {
            if (lblPatientID.Text != "")
            {
                PrintBill(lblPatientID.Text);
            }
        }

    }
}
