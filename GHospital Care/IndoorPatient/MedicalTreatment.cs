using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.IndoorPatient
{
    public partial class MedicalTreatment : Form
    {
        private MedicalManager aMedicalManager;
        public MedicalTreatment()
        {
            InitializeComponent();
            aMedicalManager=new MedicalManager();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this.panel5, this.Name);
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        public void  GenerateFollowSerialNo()
        {
            string serialNo = new MedicalManager().GetFlowupSerial();
            txtFollowupSlNo.Text = serialNo;
        }


        public DataTable GetAllPatientFollowup ;
        public void LoadAllData()
        {
            DataTable GetAllPaitentId = new IpdManager().GetAllIpdPatientSl();
            cmbPid.DataSource = GetAllPaitentId;
            cmbPid.DisplayMember = "OPID";
            cmbPid.ValueMember = "OPID";

            //..............................................
            DataTable GetAllDoctor = new MedicalManager().GetAllDoctor();
            cmbDoctor.DataSource = GetAllDoctor;
            cmbDoctor.DisplayMember = "DoctorName";
            cmbDoctor.ValueMember = "DoctorID";

            DataTable GetAllDrug = new MedicalManager().GetAllDrug();
            cmbDrug.DataSource = GetAllDrug;
            cmbDrug.ValueMember = "ProductCode";
            cmbDrug.DisplayMember = "ProductName";

            //**************************************GetAllPatientFollowup
           
        }

        public void ViewFollowUP()
        {
            DataTable GetAllPatientFollowup = new MedicalManager().GetAllPatientFollowup(Fromdate.Value, ToDate.Value);
            gridControlFollowUp.DataSource = GetAllPatientFollowup;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void MedicalTreatment_Load(object sender, EventArgs e)
        {
            LoadDatatable();
            LoadAllData();
            GenerateFollowSerialNo();
            GetDeparment();
        }
        private void GetDeparment()
        {
            cmbDept.DataSource = new FollowUpManager().GetDeparmentTreatment();
            cmbDept.DisplayMember = "DeparmentName";
            cmbDept.ValueMember = "Id";
        }
        List<Followup> aFollowups = new List<Followup>();

        public List<Followup> GetFollowUP()
        {   aFollowups.Clear();
        
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Followup followup = new Followup();
                var ItemValue = gridView1.GetRowCellValue(i, "Value").ToString();
                if (ItemValue != "")
                {
                    followup.SerialId = txtFollowupSlNo.Text;
                    followup.OPID = cmbPid.Text;
                    followup.FollowUPItemId = gridView1.GetRowCellValue(i, "MasterId").ToString();
                    followup.Particulars = gridView1.GetRowCellValue(i, "Value").ToString();
                    followup.ItemType = gridView1.GetRowCellValue(i, "Item").ToString();
                    followup.DocId = cmbDoctor.SelectedValue.ToString();
                    followup.Shift = txtShift.Text;
                    followup.Department = gridView1.GetRowCellValue(i, "DeptId").ToString();
                    aFollowups.Add(followup);
                }
            }
            return aFollowups;
        }
        Followup aFollowup = new Followup();
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            GenerateFollowSerialNo();
            Refresh();
        }
        public void PatientInformationGetByOPID(string opid)
        {
            Patient patient = new IpdManager().GetPatientInformationBySl(opid);
            txtName.Text = patient.PatientName;
            txtGender.Text = patient.Gender;
            txtBloodGroup.Text = patient.BloodGroup;
            txtAdmissionDate.Text = patient.InputDate.ToString("d");
            txtCabibBed.Text = patient.SelectedBed;
            txtAge.Text = patient.Age;
        }
        private void GetFollowCount()
        {
            DataTable dt = new MedicalManager().GetFollowUpCount(cmbPid.Text, FolluwUpDate.Value);
            LblCountDaily.Text= dt.Rows[0][0].ToString();
            DataTable dt1 = new MedicalManager().GetTotalFollowUpCount(cmbPid.Text);
            TotalFollowup.Text = dt1.Rows[0][0].ToString();
        }

        private void getFollowUpView()
        {
            DataTable dt = new MedicalManager().GetFollowupView(cmbDept.Text);
            gridControl1.DataSource = dt;
           
        }

        public void SaveItemValue()
        {
            Followup followup = new Followup();
            followup.OPID = cmbPid.Text;
            followup.SerialId = txtFollowupSlNo.Text;
            followup.Bp = txtBP.Text;
            followup.DocId = cmbDoctor.SelectedValue.ToString();
            followup.Shift = txtShift.Text;
            followup.Date = FolluwUpDate.Value;
            followup.Date = FolluwUpDate.Value;
            followup.AFollowupList = GetFollowUP();
            MessageModel message = new MedicalManager().SaveRegularFollowUp(followup);
            MessageBox.Show(message.MessageBody, message.MessageTitle);
        }
       

        public void Save()
        {
            Followup followup = new Followup();
            followup.OPID = cmbPid.Text;
            followup.SerialId = txtFollowupSlNo.Text;
            followup.Bp = txtBP.Text;
            followup.DocId = cmbDoctor.SelectedValue.ToString();
            followup.Shift = txtShift.Text;
            followup.Date = FolluwUpDate.Value;
            followup.ListOfDrug = drugTable;
            followup.Date = FolluwUpDate.Value;
            followup.Department = cmbDept.SelectedValue.ToString();
            followup.AFollowupList = GetFollowUP();
            MessageModel message = new MedicalManager().SaveFollowUp(followup);
            MessageBox.Show(message.MessageBody, message.MessageTitle);
        }
        private void cmbPid_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientInformationGetByOPID(cmbPid.Text);
            GetFollowCount();
        }
        
        
        private DataTable drugTable=null;

        public void LoadDatatable()
        {
            drugTable = new DataTable();
            drugTable.Columns.Add("DrugId");
            drugTable.Columns.Add("Drug");
            drugTable.Columns.Add("Dous");
            drugTable.Columns.Add("ExtraNote");
            drugTable.Columns.Add("ExtraNoteSpecial");
            dgvServices.DataSource = drugTable;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow row = drugTable.NewRow();
            row["DrugId"] = cmbDrug.SelectedValue;
            row["Drug"] = cmbDrug.Text;
            row["Dous"] = txtDose.Text;
            row["ExtraNote"] = txtExtraNotes.Text;
            row["ExtraNoteSpecial"] = txtSuggetion.Text;
            drugTable.Rows.Add(row);
            clear();
        }
        private void clear()
        {
            
            cmbDrug.Text = "";
            txtDose.Text = "";
            cmbDrug.Focus();
        }
        private void cmbPid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbDoctor.Focus();
            }
        }
        private void cmbDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtExtraNotes.Focus();
            }
        }
        private void txtExtraNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbDrug.Focus();
            }
        }
        private void cmbDrug_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDose.Focus();
            }
        }
        private void txtBP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbDrug.Focus();
            }
        }
        private void txtSuggetion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAdd.Focus();
            }
        }
        private void txtDose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSuggetion.Focus();
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dgvServices.CurrentCell.RowIndex;
                if (row > -1)
                {
                    dgvServices.Rows.RemoveAt(row);
                    dgvServices.Refresh();
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetFollowCount();
            }
            catch (Exception)
            {
            }
        }
       
        public void Refresh()
        {
            cmbPid.Text = "";
            txtAge.Text = "";
            txtGender.Text = "";
            txtBloodGroup.Text = "";
            cmbDoctor.Text = "";
            txtExtraNotes.Text = "";
            txtBP.Text = "";
            txtSuggetion.Text = "";
            getFollowUpView();
            if (dgvServices.Rows.Count > 0)
            {
                //dgvServices.Rows.Clear();
                dgvServices.DataSource = null;
                LoadDatatable();
            }
            LblCountDaily.Text = "";
            clear();
            LoadAllData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void searchLookTreatmentInfo_EditValueChanged(object sender, EventArgs e)
        {
            Followup followup = new Followup();
            followup.OPID = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            //txtName.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
            cmbPid.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtFollowupSlNo.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("SerialFollowUp").ToString();
            //txtFollowupSlNo.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("Drug").ToString();
            txtFollowupSlNo.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("DoctorID").ToString();
            txtName.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
            txtGender.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("Gender").ToString();
            //txtFollowupSlNo.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("Dous").ToString();
            txtFollowupSlNo.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("FollowupId").ToString();
            txtFollowupSlNo.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("BP").ToString();
            txtExtraNotes.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("ExtraNote").ToString();
            txtSuggetion.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("ExtraNoteSpecial").ToString();
            FolluwUpDate.Text = searchLookTreatmentInfo.Properties.View.GetFocusedRowCellValue("Date").ToString();

            aMedicalManager=new MedicalManager();
            //dgvServices.DataSource = null;
            //drugTable.Rows.Clear();
            DataTable dataTable=new DataTable();

            dataTable = new MedicalManager().GetPatientFollowupByOpid(followup);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow rows = drugTable.NewRow();
                rows["DrugId"] = dataTable.Rows[i]["DrugId"];
                rows["Drug"] = dataTable.Rows[i]["Drug"];
                rows["Dous"] = dataTable.Rows[i]["Dous"];
                rows["ExtraNote"] = dataTable.Rows[i]["ExtraNote"];
                rows["ExtraNoteSpecial"] = dataTable.Rows[i]["ExtraNoteSpecial"];

            }
            dgvServices.DataSource = drugTable;

        }
        private void cmbDrug_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
        private void label24_Click(object sender, EventArgs e)
        {

        }
        private void txtGender_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageModel aMessageModel = new MessageModel();
            if (!string.IsNullOrEmpty(cmbPid.Text))
            {
                MessageBox.Show("Select a patient.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message",
               MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Followup followup = new Followup();
                    followup.OPID = cmbPid.Text;
                    followup.SerialId = txtFollowupSlNo.Text;
                    aMessageModel = aMedicalManager.DeletePatientFollowup(followup);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GenerateFollowSerialNo();
                        Refresh();
                    }
                }
            }

            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageModel aMessageModel=new MessageModel();
            Followup followup = new Followup();
            followup.OPID = cmbPid.Text;
            followup.SerialId = txtFollowupSlNo.Text;
            aMessageModel = aMedicalManager.DeletePatientFollowup1(followup);
            if (aMessageModel.MessageTitle == "Successfull")
            {
                Save();
               // MessageBox.Show("Updated Successfully.", aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                GenerateFollowSerialNo();
                Refresh();
            }

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void gridControlFollowUp_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridViewFollowUp_DoubleClick(object sender, EventArgs e)
        {
            xtraTabPage1.Show();
            Followup followup = new Followup();
            string Department = gridViewFollowUp.GetFocusedRowCellValue("Deparment").ToString(); 
            followup.OPID = gridViewFollowUp.GetFocusedRowCellValue("OPID").ToString();
            cmbPid.Text = gridViewFollowUp.GetFocusedRowCellValue("OPID").ToString();
            txtFollowupSlNo.Text = gridViewFollowUp.GetFocusedRowCellValue("SerialFollowUp").ToString();
            followup.SerialId = txtFollowupSlNo.Text;
            txtShift.Text = gridViewFollowUp.GetFocusedRowCellValue("Shift").ToString();
            txtName.Text = gridViewFollowUp.GetFocusedRowCellValue("PatientName").ToString();
            //txtSuggetion.Text = gridViewFollowUp.GetFocusedRowCellValue("ExtraNoteSpecial").ToString();
            //txtExtraNotes.Text = gridViewFollowUp.GetFocusedRowCellValue("ExtraNote").ToString();
            cmbDoctor.Text = gridViewFollowUp.GetFocusedRowCellValue("DoctorName").ToString();
            FolluwUpDate.Text = gridViewFollowUp.GetFocusedRowCellValue("Date").ToString();
            cmbDept.Text = Department;
            aMedicalManager = new MedicalManager();
           DataTable dt = aMedicalManager.UpdateFollowUpSheet( followup.OPID,txtFollowupSlNo.Text);
           //gridControl1.DataSource = dt;

           for (int i = 0; i < gridView1.RowCount; i++)
            {
               //string ItemID =gridView1.GetRowCellValue(i, "MasterId").ToString() ;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["FollowUpItemID"].ToString() == gridView1.GetRowCellValue(i, "MasterId").ToString())
                    {
                        string values = row["Particulars"].ToString();
                        gridView1.SetRowCellValue(i, "Value", values);    
                    }
                }
               
                
            }
            //dgvServices.DataSource = null;
            //drugTable.Rows.Clear();
            DataTable dataTable = new DataTable();

           dataTable = new MedicalManager().GetPatientFollowupByOpid(followup);
            drugTable.Rows.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
               
                DataRow rows1 = drugTable.NewRow();
              
                rows1["DrugId"] = dataTable.Rows[i]["Drug"];
                rows1["Drug"] = dataTable.Rows[i]["ProductName"];
                rows1["Dous"] = dataTable.Rows[i]["Dous"];
                rows1["ExtraNote"] = dataTable.Rows[i]["ExtraNote"];
                rows1["ExtraNoteSpecial"] = dataTable.Rows[i]["ExtraNoteSpecial"];
                drugTable.Rows.Add(rows1);
                
            }

            dgvServices.DataSource = drugTable;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getFollowUpView();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            SaveItemValue();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            getFollowUpView();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ViewFollowUP();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            ViewFollowUP();
        }
    }
}
