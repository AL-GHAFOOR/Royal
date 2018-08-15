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

namespace GHospital_Care.UI
{
    public partial class MedicineIndentUi : Form
    {

        public MedicineIndentUi()
        {
            InitializeComponent();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            DataRow row = CartTable.NewRow();
            row["ProductCode"] = searchLookUpMedicine.EditValue.ToString();
            row["ProductName"] = searchLookUpMedicine.Properties.View.GetFocusedDisplayText();
            row["Qty"] = txtQuantity.Text;

            CartTable.Rows.Add(row);
            searchLookUpMedicine.Text="";
            txtQuantity.Text = "";
            searchLookUpMedicine.Focus();
        }

   


        private DataTable CartTable = null;
        public void LoadDatatable()
        {
            CartTable = new DataTable();
            CartTable.Columns.Add("ProductCode");
            CartTable.Columns.Add("ProductName");
            CartTable.Columns.Add("Qty");
            DataGridCart.DataSource = CartTable;
        }

        public void GetIpPatient()
        {
            DataTable dataTable = new DataTable();
            dataTable = new MedicineIndentManager().GetIpPatient();
            if (dataTable.Rows.Count > 0)
            {
                searchLookUpNicuPatient.Properties.DataSource = dataTable;
                searchLookUpNicuPatient.Properties.DisplayMember = "PatientName";
                searchLookUpNicuPatient.Properties.ValueMember = "OPID";
            }
        }

        public void GetNicuPatient()
        {
            DataTable dataTable = new DataTable();
            dataTable = new MedicineIndentManager().GetNicuPatient();
            if (dataTable.Rows.Count > 0)
            {
                searchLookUpNicuPatient.Properties.DataSource = dataTable;
                searchLookUpNicuPatient.Properties.DisplayMember = "MotherName";
                searchLookUpNicuPatient.Properties.ValueMember = "RegNo";
            }

        }



        public void GetMedicine()
        {
            DataTable dataTable = new DataTable();
            dataTable = new MedicineIndentManager().GetMedicine();
            if (dataTable.Rows.Count > 0)
            {
                searchLookUpMedicine.Properties.DataSource = dataTable;
                searchLookUpMedicine.Properties.DisplayMember = "ProductName";
                searchLookUpMedicine.Properties.ValueMember = "ProductCode";
            }
        }


        public void GetIndentNo()
        {
            DataTable dataTable = new DataTable();
            dataTable = new MedicineIndentManager().GetIndentNo();
            if (dataTable.Rows.Count > 0)
            {
                txtIndentNo.Text = dataTable.Rows[0]["IndentNo"].ToString();
            }
        }
        private void MedicineIndent_Load(object sender, EventArgs e)
        {
            radioBtnIndoor.Checked = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetIndentNo();
            GetIpPatient();
            DefaultClear();
        
        }

       

        private void picBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string PatientID = "";
        private void searchLookUpNicuPatient_EditValueChanged(object sender, EventArgs e)
        {
            if (radioBtnIndoor.Checked)
            {
                PatientID = searchLookUpNicuPatient.Properties.View.GetFocusedRowCellValue("PatientId").ToString();
                txtPatientName.Text = searchLookUpNicuPatient.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
                txtCabin.Text = searchLookUpNicuPatient.Properties.View.GetFocusedRowCellValue("Cabin").ToString();
                txtAdmitDate.Text = searchLookUpNicuPatient.Properties.View.GetFocusedRowCellValue("AdmitDate").ToString();
                searchLookUpMedicine.Focus();
            }
            else if(radioBtnNicu.Checked)
            {
                txtPatientName.Text = searchLookUpNicuPatient.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
                txtCabin.Text = "N/A";
                txtAdmitDate.Text = searchLookUpNicuPatient.Properties.View.GetFocusedRowCellValue("AdmitDate").ToString();
            }
        }


        public void DefaultClear()
        {
            txtPatientName.Text = "";
            txtCabin.Text = "";
            txtAdmitDate.Text = "";
            txtQuantity.Text = "";
            
        }

        private void MedicineIndentUi_Shown(object sender, EventArgs e)
        {
            GetNicuPatient();
            GetIndentNo();
            GetIpPatient();
            GetMedicine();
            LoadDatatable();

        }



        private string productCode = "";
        private void searchLookUpMedicine_EditValueChanged(object sender, EventArgs e)
        {
            //productCode = searchLookUpMedicine.GetColumnValue("Id");
            //productCode = searchLookUpMedicine.EditValue.ToString();
            //MessageBox.Show(productCode);
            txtQuantity.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAL.Model.MedicineIndent aMedicineIndent=new  DAL.Model.MedicineIndent();
            aMedicineIndent.IndentNo = txtIndentNo.Text;
            aMedicineIndent.Date = dateTimeIndentDate.Value;
            if (radioBtnIndoor.Checked)
            {
                aMedicineIndent.PatientType = "IPD";
            }
            else if (radioBtnNicu.Checked)
            {
                aMedicineIndent.PatientType = "NICU";
            }
            aMedicineIndent.PatientId = PatientID;
            aMedicineIndent.DrugsDatatable = CartTable;

            MessageModel aMessageModel=new MessageModel();

            aMessageModel = new MedicineIndentManager().SaveMedicineIndent(aMedicineIndent);
            MessageBox.Show(aMessageModel.MessageTitle, aMessageModel.MessageBody, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            btnRefresh_Click(sender,e);


        }

        private void radioBtnNicu_CheckedChanged(object sender, EventArgs e)
        {
            DefaultClear();
            GetNicuPatient();
        }

        private void radioBtnIndoor_CheckedChanged(object sender, EventArgs e)
        {
            DefaultClear();
            GetIpPatient();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddToCart.Focus();
            }
        }

    }
}
