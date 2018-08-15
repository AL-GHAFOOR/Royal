using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.IndoorPatient
{
    public partial class IPDAdmissionBedHistory : Form
    {
        public IPDAdmissionBedHistory()
        {
            InitializeComponent();
            GetIpInfo();
        }

        private void GetBadorCabin()
        {
            DataTable dt = new BedHistoryManager().GetFreeOccupiedBed(FreeOccupied,cmbWardorCabin.Text);
            gridControl2.DataSource = dt;
            //txtReg.Text = dt.Rows[0][0].ToString();
            CountBadorCabin();
            CountOccupiedBadorCabin();
        }

        private void CountBadorCabin()
        {
            DataTable dt = new BedHistoryManager().CountFreeOccupiedBed(FreeOccupied, cmbWardorCabin.Text);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtOccupied.Text = dt.Rows[0][0].ToString(); 
            }
            
        }

        private void CountOccupiedBadorCabin()
        {
            DataTable dt = new BedHistoryManager().CountOccupiedBed(FreeOccupied, cmbWardorCabin.Text);
            if (dt != null && dt.Rows.Count > 0)
            {
               txtFreeBed.Text = dt.Rows[0][0].ToString();
            }

        }
        private void GetIpInfo()
        {
            DataTable dt = new BedHistoryManager().GetIpInfo(FromDate.Value, ToDate.Value,false);
            gridControl1.DataSource = dt;
            CountPatient();
        }
        
        private void GetBedCabinList()
        {
            DataTable dt = new BedHistoryManager().GetIpCabinBedList(patientID);
            //gridControl3.DataSource = dt;
            txtCurrentBed.Text = dt.Rows[0]["BedName"].ToString();
            txtRate.Text = dt.Rows[0]["Rate"].ToString();
            txtAdmissionDate.Text = Convert.ToDateTime(dt.Rows[0]["TransferDate"]).ToString("d");
        }
        private void CountPatient()
        {
            DataTable dt = new BedHistoryManager().CountIP(FromDate.Value, ToDate.Value);
            DataTable dt1 = new BedHistoryManager().CountIP(System.DateTime.Today, System.DateTime.Today);

            txtTotalPatient.Text = dt.Rows[0][0].ToString();
            txtTodayAdmit.Text = dt1.Rows[0][0].ToString();
            //txtReg.Text = dt.Rows[0][0].ToString();
        }

        public string FreeOccupied = "";
        private void ChkFreeOccupied()
        {
            if (cmbWardorCabin.Text == "All Cabin" && rdFree.Checked == true)
            {
                FreeOccupied = "C_Free";
            }
            else if (cmbWardorCabin.Text == "All Cabin" && rdOccupied.Checked == true)
            {
                FreeOccupied = "C_Occupied";
            }
            else if (cmbWardorCabin.Text == "All Ward" && rdOccupied.Checked == true)
            {
                FreeOccupied = "B_Occupied";
            }
            else if (cmbWardorCabin.Text == "All Ward" && rdFree.Checked == true)
            {
                FreeOccupied = "B_Free";
            }
        }

        private void IPDAdmissionBedHistory_Load(object sender, EventArgs e)
        {
            cmbWardorCabin.SelectedIndex = 0;
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridControl2_Click_1(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void rdFree_CheckedChanged(object sender, EventArgs e)
        {
            ChkFreeOccupied();
            GetBadorCabin();
        }

        private void rdOccupied_CheckedChanged(object sender, EventArgs e)
        {
            ChkFreeOccupied();
            GetBadorCabin();
        }

        private void cmbWardorCabin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkFreeOccupied();
            GetBadorCabin();
            freeouccupiedTotal();
        }

        public void freeouccupiedTotal()
        {
            if (cmbWardorCabin.Text == "All Ward")
            {
                lblFree.Text = "Free Bed";
                lblOccupied.Text = "Occupied Bed";
                txtTotal.Text = (Convert.ToInt32(txtOccupied.Text) + Convert.ToInt32(txtFreeBed.Text)).ToString();

            }
            if (cmbWardorCabin.Text == "All Cabin")
            {
                lblFree.Text = "Free Cabin";
                lblOccupied.Text = "Occupied Cabin";
                txtTotal.Text = (Convert.ToInt32(txtOccupied.Text) + Convert.ToInt32(txtFreeBed.Text)).ToString();
            }
        }

        private void specialButton1_Click(object sender, EventArgs e)
        {
            GetIpInfo();
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void specialButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void specialButton2_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = null;
            rdFree.Checked = false;
            rdOccupied.Checked = false;
            cmbWardorCabin.Text = "";

        }

        private string patientID = "";
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
           patientID= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OPID").ToString();
           GetBedHistory(patientID);
           GetBedCabinList();
            DateTime trsDate = TransferDate.Value;
            decimal dt = (trsDate - Convert.ToDateTime(txtAdmissionDate.Text)).Days;
            txtdays.Text = dt.ToString("0.00");
        }

        private void GetBedHistory(string PID)
        {
            DataTable dt = new IpdManager().GetBeadCabinHistory(PID);
            gridControl3.DataSource = dt;
        }
        private void GetAllWard()
        {
            IpdManager aIpdManager = new IpdManager();
            cmbwardCabin.DataSource = aIpdManager.GetAllWard();
            cmbwardCabin.DisplayMember = "WardName";
            cmbwardCabin.ValueMember = "ID";
        }
        private void GetAllCabin()
        {
            IpdManager aIpdManager = new IpdManager();
            cmbwardCabin.DataSource = aIpdManager.GetAllCabin();
            cmbwardCabin.DisplayMember = "CabinName";
            cmbwardCabin.ValueMember = "Id";
        }
        public void WardOrCabin()
        {
            if (chkCabin.Checked)
            {
                GetAllWard();
            }
            else
            {
                GetAllCabin();
            }
        }

        private void chkCabin_CheckedChanged(object sender, EventArgs e)
        {
            WardOrCabin();
        }

        private void LoadBeds()
        {

            IpdManager aIpdManager = new IpdManager();
            txtseletedBed.DataSource = aIpdManager.GetAllBeds(cmbwardCabin.Text);
            txtseletedBed.DisplayMember = "BedName";
            txtseletedBed.ValueMember = "BedId";

        }

        private void cmbwardCabin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkCabin.Checked)
            {
                txtseletedBed.Enabled = true;
                txtseletedBed.Text = "";
                LoadBeds();
            }
            else
            {
                txtseletedBed.DataSource = null;
                txtseletedBed.Enabled = false;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           Patient aPatient = new Patient();
            IPDBedHistory aBedHistory = new IPDBedHistory();
            aBedHistory.BedorCabin = gridView3.GetRowCellValue(0, "BedCabinID").ToString(); ;
            aBedHistory.fromDate = Convert.ToDateTime(txtAdmissionDate.Text);
            aBedHistory.Todate = DateTime.Today;
            aBedHistory.Rate = Convert.ToDecimal(txtRate.Text);
            aBedHistory.TransferDate = Convert.ToDateTime(txtAdmissionDate.Text); 
            aBedHistory.DayQty = (DateTime.Today-Convert.ToDateTime(txtAdmissionDate.Text) ).Days;
            aBedHistory.PatientID = gridView3.GetRowCellValue(0, "OPID").ToString();

            aBedHistory.UserId = "";

            if (chkCabin.Checked == true)
            {
                aPatient.SelectedBed = txtseletedBed.SelectedValue.ToString();
                aPatient.WardOrCabin = "";
            }
            else if (chkCabin.Checked == false)
            {
                aPatient.SelectedBed = "";
                aPatient.WardOrCabin = cmbwardCabin.SelectedValue.ToString(); 
            }
           aPatient.OPID = gridView1.GetFocusedRowCellValue("OPID").ToString();
           MessageModel message = new BedHistoryManager().SaveBedShipment(aBedHistory,aPatient);
           MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
           specialButton4_Click(sender,e);
           WardOrCabin();
           GetIpInfo();
           ChkFreeOccupied();
           GetBadorCabin();
        }




        private void specialButton4_Click(object sender, EventArgs e)
        {
            txtCurrentBed.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtAdmissionDate.Text= String.Empty;
            gridControl3.DataSource = null;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetIpInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCurrentBed.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtAdmissionDate.Text = String.Empty;
            gridControl3.DataSource = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                Patient aPatient = new Patient();
                IPDBedHistory aBedHistory = new IPDBedHistory();
                aBedHistory.BedorCabin = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BedCabinID").ToString(); ;
                aBedHistory.fromDate = Convert.ToDateTime(txtAdmissionDate.Text);
                aBedHistory.Todate = TransferDate.Value;
                aBedHistory.Rate = Convert.ToDecimal(txtRate.Text);
                aBedHistory.TransferDate = Convert.ToDateTime(txtAdmissionDate.Text);
                aBedHistory.DayQty = Convert.ToDecimal(txtdays.Text);
                aBedHistory.PatientID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OPID").ToString();

                DateTime dt = dateTransferTime.Value;
                TimeSpan st = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                aBedHistory.TransferTime = st;


                aBedHistory.UserId = "";

                if (chkCabin.Checked == true)
                {
                    aPatient.SelectedBed = txtseletedBed.SelectedValue.ToString();
                    aPatient.WardOrCabin = "";
                }
                else if (chkCabin.Checked == false)
                {
                    aPatient.SelectedBed = "";
                    aPatient.WardOrCabin = cmbwardCabin.SelectedValue.ToString();
                }
                aPatient.OPID = gridView1.GetFocusedRowCellValue("OPID").ToString();
                MessageModel message = new BedHistoryManager().SaveBedShipment(aBedHistory, aPatient);
                MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                specialButton4_Click(sender, e);
                WardOrCabin();
                GetIpInfo();
                ChkFreeOccupied();
                GetBadorCabin();}
            catch (Exception)
            {
                
                //throw;
            }
            
        }

        private void txtCurrentBed_TextChanged(object sender, EventArgs e)
        {

        }

        private void TransferDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime trsDate = TransferDate.Value;
                decimal dt = (trsDate - Convert.ToDateTime(txtAdmissionDate.Text)).Days;
                txtdays.Text = dt.ToString("0.00");}
            catch (Exception)
            {
                
              }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
