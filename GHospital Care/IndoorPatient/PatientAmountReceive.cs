using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using DevExpress.XtraRichEdit.Import.Doc;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.IndoorPatient
{
    public partial class PatientAmountReceive : Form
    {
        private RefferedInfoManager aRefferedInfoManager;
        private DiscountAuthorityManager aDiscountAuthorityManager;
        readonly RceivedAmountManager amountManager=new RceivedAmountManager();
        

        public PatientAmountReceive()
        {
            InitializeComponent();
            aRefferedInfoManager = new RefferedInfoManager();
            amountManager=new RceivedAmountManager();
            SetNew();
            PopulateGridViewBillCollection();
           
            Control buttonControl = new ButtonPermissionAccess().UserButton(this.panel7, this.Name);
        }
        public void PopulateGridViewBillCollection()
        {
            string status = "";
            if (rdIndoor.Checked)
            {
                status = "InDoor";
            }
            else
            {
                status = "OutDoor";
            }

            DataTable data=new DataTable();
            data = amountManager.PopulateGridViewBillCollection(dateTimeFromDate.Value, dateTimeToDate.Value, status);
            gridControlPatientAmount.DataSource = data;
        }
        
        DataTable dataTable = new DataTable();
        public void GetRefferedAuthority()
        {
            aDiscountAuthorityManager=new DiscountAuthorityManager();
       
            dataTable = aDiscountAuthorityManager.PopulateGridView();
            dataTable.Rows.Add();
            cmbDiscountBy.DataSource = dataTable;
            
            int row = dataTable.Rows.Count - 1;
            dataTable.Rows[row][1] = "---Select---";
            cmbDiscountBy.SelectedIndex = row;
            
            cmbDiscountBy.DisplayMember = "Name";
            cmbDiscountBy.ValueMember = "Id";
            
            //gridControlReffered.DataSource = dataTable;
        }



        private void SetNew()
        {
            txtNetAmount.Text = @"0";
            cmbPatientId.Text = "";
            txtPatientName.Text = "";
            txtRemarks.Text = "";
            txtRecieveBy.Text = "";
            //txtVoucherNo.Text = "";
            txtBillNo.Text = "";
            txtTotalAmount.Text = "0.00";
            txtRemainingBalance.Text = "0.00";
            txtDiscount.Text = "0.00";
            //txtRefferedBy.Text = "";
            GenerateId();
            PopulateGridViewBillCollection();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void clear()
        {
            txtNetAmount.Text = @"0";
            txtPatientName.Text = "";
            txtRemarks.Text = "";
            txtRecieveBy.Text = "";
            //txtVoucherNo.Text = "";
            txtBillNo.Text = "";
            txtTotalAmount.Text = "0.00";
            txtRemainingBalance.Text = "0.00";
            txtDiscount.Text = "0.00";
            cmbPayType.SelectedIndex = 0;
        }
        //private void SaveVoucher()
        //{
        //    try
        //    {
        //        var obCon = new Conn();
        //        var ob = new SqlConnection(obCon.strCon);
        //        var cmd = new SqlCommand("SP_SAVE_tblIPVoucher", ob) {CommandType = CommandType.StoredProcedure};
                
        //        cmd.Parameters.Add("@VoucherNo", SqlDbType.Int);
        //        cmd.Parameters.Add("@PatientId", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@PatientName", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@ColType", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@PayType", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@Discount", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@Amount", SqlDbType.Float);
        //        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@ReceivedBy", SqlDbType.VarChar, 50);

        //        cmd.Parameters[0].Value = txtVoucherNo.Text;
        //        cmd.Parameters[1].Value = txtPatiantID.Text;
        //        cmd.Parameters[2].Value = txtPatientName.Text;
        //        cmd.Parameters[3].Value = dateVoucher.Text;
        //        cmd.Parameters[4].Value = txtBillNo.Text;
        //        cmd.Parameters[5].Value = cmbColType.Text;
        //        cmd.Parameters[6].Value = cmbPayType.Text;
        //        cmd.Parameters[7].Value = txtDiscount.Text;
        //        cmd.Parameters[8].Value = txtAmount.Text;
        //        cmd.Parameters[9].Value = txtRemarks.Text;
        //        cmd.Parameters[10].Value = txtRecieveBy.Text;

        //        ob.Open();
        //        cmd.ExecuteNonQuery();
        //        ob.Close();

        //        MessageBox.Show(@"Voucher saved successfully!",@"Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
        //        SetNew();
        //    }
        //    catch 
        //    {
        //        // ignored
        //    }
        //}

        //private void GridLoad()
        //{
        //    var obcon = new Conn();
        //    var ob = new SqlConnection(obcon.strCon);
        //    var da = new SqlDataAdapter {SelectCommand = new SqlCommand {Connection = ob}};
        //    var ds = da.SelectCommand;
        //    ds.CommandText = "SELECT * FROM tblIPVoucher where ColType = '"+cmbColType.Text + "'";
        //    ds.CommandType = CommandType.Text;
        //    var dt = new DataTable();
        //    da.Fill(dt);
        //    dataGridView1.AutoGenerateColumns = false;
        //    dataGridView1.DataSource = dt;
        //    lblType.Text = cmbColType.Text + "" + "Amount";


        //    gridControlPatientAmount.DataSource = dt;



        //}

        private void GenerateId()
        {
            var obcon = new Conn();
            var ob = new SqlConnection(obcon.strCon);
            var da = new SqlDataAdapter {SelectCommand = new SqlCommand {Connection = ob}};
            var cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(VoucherNo),0)+1 as VoucherNo from tblIPVoucher";
            cmd.CommandType = CommandType.Text;

            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtVoucherNo.Text = dt.Rows[0]["VoucherNo"].ToString();
            }
        }
        private void txtPatiantID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var obcon = new Conn();
                var ob = new SqlConnection(obcon.strCon);
                var da = new SqlDataAdapter {SelectCommand = new SqlCommand {Connection = ob}};
                var cmd = da.SelectCommand;
                cmd.CommandText = "SELECT* FROM tblIP where IPID=@IPID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@IPID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = cmbPatientId.Text;
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtPatientName.Text = dt.Rows[0]["PatientName"].ToString();
                }
            }
            catch
            {
                // ignored
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ReceivedAmount rcvAmnt = new ReceivedAmount();
            rcvAmnt.VoucherNo = int.Parse(txtVoucherNo.Text);
            rcvAmnt.PatientId = cmbPatientId.Text;
            rcvAmnt.PatientName = txtPatientName.Text;
            rcvAmnt.AdmissionDate = dateVoucher.Text;
            rcvAmnt.BillNo = txtBillNo.Text;
            rcvAmnt.Inword = lblInward.Text;
            rcvAmnt.ReceivedBy = MainWindow.userName;
            if (cmbColType.Text == "Advance" || cmbColType.Text == "Settlement")
            {
                rcvAmnt.ColType = cmbColType.Text;
            }
            rcvAmnt.PayType = cmbPayType.Text;
            rcvAmnt.Discount = double.Parse(txtDiscount.Text);
            rcvAmnt.NetAmount = double.Parse(txtNetAmount.Text);
            rcvAmnt.Remarks = txtRemarks.Text;
            rcvAmnt.ReceivedBy = txtRecieveBy.Text;
            rcvAmnt.RefferedBy = Convert.ToInt32(cmbDiscountBy.Tag);
            if (rdIndoor.Checked)
            {
                rcvAmnt.Status = "InDoor";
            }
            if (rdNICU.Checked)
            {
                rcvAmnt.Status = "NICU";}
            if(rdOutDoor.Checked)
            {
                rcvAmnt.Status = "OutDoor";
            }
            MessageModel message = new RceivedAmountManager().SaveReceivedAmount(rcvAmnt);
            if (message.MessageTitle == "Successful")
            {
                MetroFramework.MetroMessageBox.Show(this, message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateGridViewBillCollection();
                btnRefresh.PerformClick();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void PatientAmountReceive_Load(object sender, EventArgs e)
        {
            cmbPatientId.Text = "";
            rdIndoor.Checked = true;
            txtRecieveBy.Text = MainWindow.userName;
            GetRefferedAuthority();

            //GridLoad();
        }

        private void ChkOPIP()
        {
            SetNew();
            if (rdIndoor.Checked == true)
            {
                rdOutDoor.Checked = false;
                rdNICU.Checked = false;
               // loadPatientID();

            }
            if (rdOutDoor.Checked == true)
            {
                rdIndoor.Checked = false;
                rdNICU.Checked = false;
                //loadPatientID();
            }
            if (rdNICU.Checked == true)
            {
                rdIndoor.Checked = false;
                rdOutDoor.Checked = false;
                //loadPatientID();
            }
        }

        private void cmbColType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPatientID();
        }
        
        private void loadPatientID()
        {
            int row = 0;
            try
            {
              cmbColType.Enabled = true;
              DataTable data = new DataTable();
              //data.Rows.Clear();
              if (rdIndoor.Checked == true)
                {
                    SetNew();
                   if (cmbColType.Text == @"Advance")
                    {
                        data.Rows.Clear();
                        cmbPatientId.DataSource = null;
                        data = new RceivedAmountManager().GetPatientIdFrmIndoorDataTable();
                        if (data != null && data.Rows.Count > 0)
                        {
                            cmbPatientId.DataSource = data;
                            cmbPatientId.DisplayMember = "OPID";
                            cmbPatientId.ValueMember = "Id";
                            data.Rows.Add();
                            row = data.Rows.Count - 1;
                            data.Rows[row][1] = "---Select---";
                            cmbPatientId.SelectedIndex = row;
                        }
                        // GridLoad();
                    }
                    if (cmbColType.Text == @"Settlement")
                    {
                        data.Rows.Clear();
                        cmbPatientId.DataSource = null;
                        data = new RceivedAmountManager().GetPatientIdFrmDischargeDataTable();
                        if (data != null && data.Rows.Count > 0)
                        {
                           cmbPatientId.DataSource = data;
                           // data.Rows[row]["OPID"] = "---Select---";
                            cmbPatientId.DisplayMember = "OPID";
                            cmbPatientId.ValueMember = "Id";
                            data.Rows.Add();
                            row = data.Rows.Count - 1;
                            data.Rows[row][1] = "---Select---";
                            cmbPatientId.SelectedIndex = row;
                        }
                        //GridLoad();
                    }
                }
                if (rdNICU.Checked == true)
                {
                    
                    if (cmbColType.Text == @"Advance")
                    {
                        data.Rows.Clear();
                        cmbPatientId.DataSource = null;
                        data = new RceivedAmountManager().GetPatientIdFrmNICU();
                        if (data != null && data.Rows.Count > 0)
                        {
                            cmbPatientId.DataSource = data;
                            cmbPatientId.DisplayMember = "RegNo";
                            cmbPatientId.ValueMember = "Id";
                            data.Rows.Add();
                            row = data.Rows.Count - 1;
                            data.Rows[row][1] = "---Select---";
                            cmbPatientId.SelectedIndex = row;
                        }
                        // GridLoad();
                    }
                    else if (cmbColType.Text == @"Settlement")
                    {
                        //data.Rows.Clear();
                        data.Rows.Add();
                        cmbPatientId.DataSource = null;
                        data = new RceivedAmountManager().GetPatientIdFrmNICUDischargeDataTable();
                        if (data != null && data.Rows.Count > 0)
                        {
                            cmbPatientId.DataSource = data;

                            // data.Rows[row]["OPID"] = "---Select---";
                            cmbPatientId.DisplayMember = "OPID";
                            cmbPatientId.ValueMember = "Id";
                            row = data.Rows.Count - 1;
                            data.Rows[row][1] = "---Select---";
                            cmbPatientId.SelectedIndex = row;
                        }
                        //GridLoad();
                    }
                }


                if (rdOutDoor.Checked == true)
                {
                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@problem 
                    SetNew();
                    cmbColType.Enabled = false;
                    cmbColType.SelectedIndex = 1;
                    data = new RceivedAmountManager().GetPatientIdFrmOurDoorDataTable();
                      
                        if (data != null && data.Rows.Count > 0)
                        {
                            cmbPatientId.DataSource = data;
                            cmbPatientId.DisplayMember = "OPID";
                            cmbPatientId.ValueMember = "Id";
                            //row = data.Rows.Count - 1;
                            //data.Rows[row][1] = "---Select---";
                            //data.Rows[row][2] = "0";
                            //cmbPatientId.DisplayMember = "OPID";
                            //cmbPatientId.ValueMember = "Id";
                            //cmbPatientId.SelectedIndex = row;
                        }
                    
                }
            }
            catch (Exception)
            {
                //cmbPatientId.SelectedIndex = row;

            }
        }

        private string patientID = "";
        private void cmbPatientId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string chk = "";
                clear();    
                if (rdIndoor.Checked == true)
                {
                    chk = "Indoor";
                    DataTable dtP = new RceivedAmountManager().GetPatientNamebyId(cmbPatientId.Text, chk);
                    txtPatientName.Text = dtP.Rows[0][0].ToString();
                    if (cmbColType.Text == @"Settlement")
                    {
                        DataTable dt2 = new RceivedAmountManager().GetPatientBillbyId(cmbPatientId.Text, chk);
                        txtBillNo.Text = dt2.Rows[0]["BillNo"].ToString();
                        txtRemainingBalance.Text = dt2.Rows[0]["NetPayble"].ToString();
                        txtTotalAmount.Text = dt2.Rows[0]["NetPayble"].ToString();
                        txtNetAmount.Text = dt2.Rows[0]["NetPayble"].ToString();
                        cmbPatientId.Focus();
                    }
                    
                }
                else if(rdOutDoor.Checked== true)
                {
                    chk = "Outdoor";
                    DataTable dtP = new RceivedAmountManager().GetPatientNamebyId(cmbPatientId.Text, chk);
                    txtPatientName.Text = dtP.Rows[0][0].ToString();
                    DataTable dt2 = new RceivedAmountManager().GetPatientBillbyId(cmbPatientId.Text, chk);
                    txtBillNo.Text = dt2.Rows[0]["BillNo"].ToString();
                    txtRemainingBalance.Text = dt2.Rows[0]["NetPayble"].ToString();
                    txtTotalAmount.Text = dt2.Rows[0]["NetPayble"].ToString();
                    txtNetAmount.Text = dt2.Rows[0]["NetPayble"].ToString();cmbPatientId.Focus();
                }
                else if (rdNICU.Checked == true)
                {
                       chk = "NICU";
                        DataTable dtP = new RceivedAmountManager().GetPatientNamebyId(cmbPatientId.Text, chk);
                        txtPatientName.Text = dtP.Rows[0][0].ToString();
                        if (cmbColType.Text == @"Settlement")
                        {
                        DataTable dt2 = new RceivedAmountManager().GetPatientBillbyId(cmbPatientId.Text, chk);
                        txtBillNo.Text = dt2.Rows[0]["BillNo"].ToString();
                        txtRemainingBalance.Text = dt2.Rows[0]["NetPayble"].ToString();
                        txtTotalAmount.Text = dt2.Rows[0]["NetPayble"].ToString();
                        txtNetAmount.Text = dt2.Rows[0]["NetPayble"].ToString();
                        cmbPatientId.Focus();
                    }
                }
                
                
                
                if (cmbColType.Text == @"Advance")
                {     DataTable dt3= new DataTable();
                    DataTable dt = new RceivedAmountManager().GetConsultBill(cmbPatientId.Text);
                    DataTable dt1 = new RceivedAmountManager().GetPharmacyBill(cmbPatientId.Text);
                    DataTable dt2 = new RceivedAmountManager().GetPathologyBill(cmbPatientId.Text);
                    if (rdNICU.Checked)
                    {
                        dt3 = new RceivedAmountManager().GetPatientServiceServiceBillNICU(cmbPatientId.Text);
                    }
                    else
                    {
                       dt3 = new RceivedAmountManager().GetHospitalServiceBill(cmbPatientId.Text);      
                    }
                  
                    DataTable dt4 = new RceivedAmountManager().GetOTServiceBill(cmbPatientId.Text);
                    DataTable dt5 = new RceivedAmountManager().GetOTMedicineBill(cmbPatientId.Text);
                    DataTable dt6 = new RceivedAmountManager().GetOPMedicineBill(cmbPatientId.Text);
                    DataTable dt7 = new RceivedAmountManager().GetPatientAdvance(cmbPatientId.Text);
                   
                    double consultBill=0;
                    double PharmacyBill = 0;
                    double PathologyBill = 0;
                    double HospitalService = 0;
                    double OTService = 0;
                    double OTMedicine = 0;
                    double OPMedicine = 0;
                    double PatientAdvace = 0;

                    if (dt.Rows.Count> 0)
                    {
                       consultBill= Convert.ToDouble(dt.Rows[0]["Subtotal"] );
                    }
                    if (dt1.Rows.Count>0)
                    {
                        PharmacyBill= Convert.ToDouble(dt1.Rows[0]["Subtotal"]);
                    }
                    if (dt2.Rows.Count>0)
                    {
                       PathologyBill= Convert.ToDouble(dt2.Rows[0]["Subtotal"]);
                    }
                    if (dt3.Rows.Count>0 )
                    {
                      HospitalService=Convert.ToDouble( dt3.Rows[0]["Subtotal"]);
                    }
                    if (dt4.Rows.Count>0)
                    {
                      OTService= Convert.ToDouble( dt4.Rows[0]["Subtotal"] );
                    }
                    if (rdIndoor.Checked == true)
                    {
                        if (dt5.Rows.Count > 0)
                        {
                            OTMedicine = Convert.ToDouble(dt5.Rows[0]["Subtotal"]);
                        } 
                    }
                    if (rdOutDoor.Checked == true)
                    {
                        if (dt6.Rows.Count > 0)
                        {
                            OTMedicine = Convert.ToDouble(dt6.Rows[0]["Subtotal"]);
                        } 
                    }
                    if (dt7.Rows.Count > 0)
                    {
                        PatientAdvace = Convert.ToDouble(dt7.Rows[0]["Subtotal"]);
                    }
                    txtRemainingBalance.Text = ((consultBill + PharmacyBill + PathologyBill + HospitalService + OTService + OTMedicine) - PatientAdvace).ToString("0.00");
                    txtBillNo.Text = "NA";
                    txtTotalAmount.Text = txtRemainingBalance.Text;
                    txtDiscount.Text = "0";cmbPatientId.Focus();
                }
            }
            catch (Exception)
            {
              
            }
            
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNetAmount.Text =
                    (Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtDiscount.Text)).ToString("0.00");
            }
            catch (Exception)
            {
                txtNetAmount.Text = txtTotalAmount.Text;
                txtDiscount.Text = "0.00";
            }
        }

        private void cmbPayType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTotalAmount.Focus();}
        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13 && cmbColType.Text == @"Settlement")
            {
                txtDiscount.Focus();
            }
            else if (e.KeyChar == 13 && cmbColType.Text == @"Advance")
            {
                txtRemarks.Focus();
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRemarks.Focus();
            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSave.Focus();
            }
        }

        private void PatientAmountReceive_Shown(object sender, EventArgs e)
        {
            cmbColType.Focus();
        }

        private void cmbColType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbPatientId.Focus();
            } 
        }

        private void cmbPatientId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                cmbPayType.Focus();
            } 
        }

        private void rdIndoor_CheckedChanged(object sender, EventArgs e)
        {
            ChkOPIP();
            loadPatientID();
            PopulateGridViewBillCollection();
        }

        private void rdOutDoor_CheckedChanged(object sender, EventArgs e)
        {
            ChkOPIP();
            loadPatientID();
            PopulateGridViewBillCollection();
        }

        private void cmbRefferedInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (cmbDiscountBy.Text == dataTable.Rows[i][1].ToString())
                    {
                        cmbDiscountBy.Tag = dataTable.Rows[i][0];
                    }
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNetAmount.Text =
                    (Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtDiscount.Text)).ToString("0.00");
            }
            catch (Exception)
            {
                txtNetAmount.Text = txtTotalAmount.Text;
                txtDiscount.Text = "0.00";
            }
        }

        private void txtNetAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNetAmount.Text = (Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtDiscount.Text)).ToString("0.00");
                var ammount = Spell.SpellAmount.InWrods(Convert.ToDecimal(txtNetAmount.Text));
                lblInward.Text = ammount;
            }
            catch (Exception)
            {
                txtNetAmount.Text = txtTotalAmount.Text;
                txtDiscount.Text = "0.00";
                //var ammount = Spell.SpellAmount.InWrods(Convert.ToDecimal(txtNetAmount.Text));
                //lblInward.Text = ammount;
            }
        
        }

        private void gridViewPatientAmount_DoubleClick(object sender, EventArgs e)
        {
            xtraTabPage1.Show();

            //txtOpId.Text = gridViewBirthInfo.GetFocusedRowCellValue("OPID").ToString();

            string CheckBoxValue = gridViewPatientAmount.GetFocusedRowCellValue("Status").ToString();
            

            if (CheckBoxValue=="InDoor")
            {
                rdIndoor.Checked = true;
            }
            else 
            {
                rdOutDoor.Checked = true;
            }
            cmbColType.Text = gridViewPatientAmount.GetFocusedRowCellValue("ColType").ToString();
            cmbPatientId.Text = gridViewPatientAmount.GetFocusedRowCellValue("PatientID").ToString();
            txtPatientName.Text = gridViewPatientAmount.GetFocusedRowCellValue("PatientName").ToString();
            dateVoucher.Text = gridViewPatientAmount.GetFocusedRowCellValue("AdmissionDate").ToString();
            txtBillNo.Text = gridViewPatientAmount.GetFocusedRowCellValue("BillNo").ToString();
            txtVoucherNo.Text = gridViewPatientAmount.GetFocusedRowCellValue("VoucherNo").ToString();
            dateVoucher.Text = gridViewPatientAmount.GetFocusedRowCellValue("AdmissionDate").ToString();
            txtBillNo.Text = gridViewPatientAmount.GetFocusedRowCellValue("BillNo").ToString();
            cmbDiscountBy.Text = gridViewPatientAmount.GetFocusedRowCellValue("DiscountBy").ToString();
            txtRemarks.Text = gridViewPatientAmount.GetFocusedRowCellValue("Remarks").ToString();
            txtRecieveBy.Text = gridViewPatientAmount.GetFocusedRowCellValue("ReceivedBy").ToString();
            

            //MessageBox.Show(dateVoucher.Text);
            //txtPatientName.Text = gridViewPatientAmount.GetFocusedRowCellValue("PatientName").ToString();
            //dateVoucher.Text = gridViewPatientAmount.GetFocusedRowCellValue("AdmissionDate").ToString();
            //txtBillNo.Text = gridViewPatientAmount.GetFocusedRowCellValue("BillNo").ToString();
            ////txtRemainingBalance.Text = gridViewPatientAmount.GetFocusedRowCellValue("").ToString();
            //cmbPayType.Text = gridViewPatientAmount.GetFocusedRowCellValue("PayType").ToString();
            //txtDiscount.Text = gridViewPatientAmount.GetFocusedRowCellValue("Discount").ToString();
            //txtNetAmount.Text = gridViewPatientAmount.GetFocusedRowCellValue("NetAmount").ToString();
            //txtRemarks.Text = gridViewPatientAmount.GetFocusedRowCellValue("Remarks").ToString();
            //txtRecieveBy.Text = gridViewPatientAmount.GetFocusedRowCellValue("ReceivedBy").ToString();
            ////txtRecieveBy.Text = gridViewPatientAmount.GetFocusedRowCellValue("Status").ToString();



            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;




        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetNew();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ReceivedAmount rcvAmnt = new ReceivedAmount();
            MessageModel aMessageModel=new MessageModel();
            rcvAmnt.VoucherNo = int.Parse(txtVoucherNo.Text);
            rcvAmnt.PatientId = cmbPatientId.Text;
            rcvAmnt.PatientName = txtPatientName.Text;
            rcvAmnt.AdmissionDate = dateVoucher.Text;
            rcvAmnt.BillNo = txtBillNo.Text;
            rcvAmnt.ColType = cmbColType.Text;
            rcvAmnt.PayType = cmbPayType.Text;
            rcvAmnt.Discount = double.Parse(txtDiscount.Text);
            rcvAmnt.NetAmount = double.Parse(txtNetAmount.Text);
            rcvAmnt.Remarks = txtRemarks.Text;
            rcvAmnt.ReceivedBy = MainWindow.userName;
            rcvAmnt.Inword = lblInward.Text;
            rcvAmnt.RefferedBy = Convert.ToInt32(cmbDiscountBy.Tag);
            if (rdIndoor.Checked == true)
            {
                rcvAmnt.Status = "InDoor";
            }
            else
            {
                rcvAmnt.Status = "OutDoor";
            }
            
           var Message = amountManager.UpdateReceivedAmount(rcvAmnt);
            MetroFramework.MetroMessageBox.Show(this,Message.MessageBody, Message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRefresh.PerformClick();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            PopulateGridViewBillCollection();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            PopulateGridViewBillCollection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this row?", "Confirmation Message",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ReceivedAmount rcvAmnt = new ReceivedAmount();
                rcvAmnt.VoucherNo = Convert.ToInt32(txtVoucherNo.Text);
                
                MessageModel aMessageModel = new MessageModel();
                aMessageModel = amountManager.DeleteeceivedAmount(rcvAmnt);
                if (aMessageModel.MessageTitle == "Successfull")
                {
                    MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
            }
        }

        private void cmbColType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPatientId.Focus();
            }
        }

        private void cmbPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPayType.Focus();
            }
        }

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalAmount.Focus();
            }
        }

        private void txtTotalAmount_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                txtDiscount.Focus();
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDiscountBy.Focus();
            }
        }

        private void cmbDiscountBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }
        ReportMethod aReportMethod = new ReportMethod();
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string VchNo = gridViewPatientAmount.GetFocusedRowCellValue("VoucherNo").ToString();
            DataTable dt = new DataTable();
            dt = amountManager.CollectionReport(VchNo);
            aReportMethod.aSource.Value = dt;
            aReportMethod.aReportForm = new ReportForm();
            //aStockTransfer.FormClosed += All_FormClosed;
            aReportMethod._reportParameters = new List<ReportParameter>
            {
                new ReportParameter("Company", aReportMethod.Company),
                new ReportParameter("Address", aReportMethod.Address),
                //new ReportParameter("FromDate", dateTimeFromDate.Text),
               // new ReportParameter("ToDate", dateTimeToDate.Text),
                //new ReportParameter("ReportName", lblReportName.Text),
                
                };

            aReportMethod.ReportMethods("GHospital_Care.Report.rptMoneyReceipt.rdlc", aReportMethod.aSource, "DataSet1", aReportMethod._reportParameters);
            aReportMethod.aReportForm.MdiParent = this.MdiParent;
            aReportMethod.aReportForm.WindowState = FormWindowState.Maximized;
            aReportMethod.aReportForm.Show();

        }

        private void rdNICU_CheckedChanged(object sender, EventArgs e)
        {
            ChkOPIP();
            PopulateGridViewBillCollection();
        }





    }
}
