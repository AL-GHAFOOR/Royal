using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.Operation
{
    public partial class OperationNote : Form
    {
        private MedicalManager aMedicalManager;
        public OperationNote()
        {
            InitializeComponent();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this.groupControl1, this.Name);

        }

        private void PatientLoad()
        {
            var GetAllPatient = new IpdManager().GetAllDischargeIP();
            cmbPatient.Properties.DataSource = GetAllPatient;
            cmbPatient.Properties.ValueMember = "OPID";
            cmbPatient.Properties.DisplayMember = "PatientName";
        }

        public void GetDischargeInfo()
        {
            aMedicalManager = new MedicalManager();
            DataTable data = new DataTable();
            data = aMedicalManager.GetDischargeInfoMaster();
            gridControlDischarge.DataSource = data;
        
        }

        public void GetDischargeInfoMaster()
        {
            string FromDate = Convert.ToString(dataFromDate.Value);
            string ToDate = Convert.ToString(DateToDate.Value);
            DataTable data=new DataTable();
            data = new MedicalManager().GetDischargeInfoMaster(FromDate, ToDate);
            gridControlDischarge.DataSource = data;
        }

        private void ConsultantLoad()
        {
            var GetConsultant = new IpdManager().GetAllConsultant();
            txtConsult.DataSource = GetConsultant;
            txtConsult.ValueMember = "DoctorID";
            txtConsult.DisplayMember = "DoctorName";
        }

        private void DrugListLoad()
        {
            var AllDrug = new MedicalManager().GetAllDrug();
         }


        private void PatientByOPID(string pid)
        {
            Patient patient = new IpdManager().GetPatientInformationBySl(pid);

            txtFahterHusbandName.Text = patient.Gurdian;
            txtOperationName.Text = patient.Address;
            txtAge.Text = patient.Age;
            txtGender.Text = patient.Gender;
            txtBebyGender.Text = patient.BloodGroup;
            txtContactNo.Text = patient.Mobile;
            txtConsult.Text = patient.Doctor;
            txtCabinBedNo.Text = patient.SelectedBed;
            txtAdmissionOnDate.Text = patient.InputDate.ToString("d");
            txtRegNo.Text = patient.RegNo;
            txtWeight.Text = patient.Weight;


        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DischargeForm_Load(object sender, EventArgs e)
        {
            PatientLoad();
            DrugListLoad();
            LoadTempList();
            ConsultantLoad();
            //SetNew();

            GetDischargeInfo();
            Refresh();

        }

        private void cmbPatient_EditValueChanged(object sender, EventArgs e)
        {
            if(flag == false)
               {
                   PatientByOPID(cmbPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString());
                   txtDiagonsisAdmisson.Focus(); 
                }
           
        }

        private DataTable tempDrug = null;
        public void LoadTempList()
        {
            tempDrug = null;
            tempDrug = ToDataTable(new DischargePatient().DischageDrugDetialses);
           
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (cmbDrug.Text == string.Empty || cmbPatient.Text == string.Empty || txtDoose.Text == string.Empty || txtDescription.Text == string.Empty)
            //{
            //    return;
            //}

           // tempDrug.Rows.Clear();
            //tempDrug.Rows.Clear();
            
            DataRow row = tempDrug.NewRow();
            
       
            tempDrug.Rows.Add(row);

          
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
           
            //tempDrug.Rows.RemoveAt(gridView1.GetFocusedDataSourceRowIndex());
        }
        public void reset()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextEdit)
                {
                    x.Text = string.Empty;
                }
            }

            foreach (Control y in this.Controls)
            {
                if (y is CheckBox)
                {
                    ((CheckBox)y).Checked = false;
                }
            }
        }

        public void SetNew()
        {
            reset();
            txtAdmissionOnDate.Text = DateTime.Now.ToString("d");
            txtDischargeOnDate.Text = DateTime.Now.ToString("d");


        }
        public void SaveAndUpdateDischargePatient()
        {
          // DischargePatient _dischargePatients = new DischargePatient();
            try
            {
                _dischargePatient.FatherHusbandName = txtFahterHusbandName.Text;
                _dischargePatient.Gender = txtGender.Text;
                _dischargePatient.Age = txtAge.Text;
                _dischargePatient.BloodGroup = txtBebyGender.Text;
                _dischargePatient.Consult = txtConsult.SelectedValue.ToString();
                _dischargePatient.Cabin_BedNo = txtCabinBedNo.Text;
                _dischargePatient.ContactNo = txtContactNo.Text;
                _dischargePatient.AddmissionOn = Convert.ToDateTime(txtAdmissionOnDate.Text);
                _dischargePatient.DiagOnAdmission = txtDiagonsisAdmisson.Text;
                _dischargePatient.OPID = cmbPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString();
                _dischargePatient.DischargeOn = Convert.ToDateTime(txtDischargeOnDate.Text);

                DateTime dt = txtDischareTime.Value;
                TimeSpan st = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                _dischargePatient.DischargeTime = st;

                _dischargePatient.RegNo = txtRegNo.Text;
                _dischargePatient.StatusOnDischarge = txtBreafHistory.Text;
                _dischargePatient.weight = txtWeight.Text;
                _dischargePatient.DiagOnDischarge = txtDiagOnDischarge.Text;
               
                _dischargePatient.BreffHistory = txtBreafHistory.Text;
                _dischargePatient.Tempdatatable = tempDrug;
              
                
                if (btnSave.Enabled)
                {
                    MessageModel messageModel = new MedicalManager().SaveDischargePatient(_dischargePatient);
                    MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    reset();
                }
                else if (btnEdit.Enabled)
                {
                    MessageModel messageModel = new MedicalManager().UpdateDischargePatient(_dischargePatient);
                    MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception ex){
                //throw;
            }

           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //DischargePatient _dischargePatient = new DischargePatient();
            SaveAndUpdateDischargePatient();
            Refresh();
        }



        //******************************************************************************************************



        #region
        public DataTable ToDataTable<T>(List<T> items)
        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {

                //Setting column names as Property names

                dataTable.Columns.Add(prop.Name);

            }

            foreach (T item in items)
            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {

                    //inserting property values to datatable rows

                    values[i] = Props[i].GetValue(item, null);

                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable

            return dataTable;

        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        #endregion

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDiagonsisAdmisson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiagOnDischarge.Focus();
            }
        }

        private void txtDiagOnDischarge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtBreafHistory.Focus();
            }
        }

        private void txtStatusOnDischarge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDischargeOnDate.Focus();
            }
        }

        private void cmbDrug_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDoose_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                simpleButton1.Focus();
            }
        }


        private void Refresh()
        {
            txtFahterHusbandName.Text = string.Empty;
            txtOperationName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtGender.Text = string.Empty;
            txtBebyGender.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtConsult.Text = string.Empty;
            txtCabinBedNo.Text = string.Empty;
            txtAdmissionOnDate.Text = string.Empty;
            txtRegNo.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtDischareTime.Text = string.Empty;
            txtDiagonsisAdmisson.Text = string.Empty;
            txtDiagOnDischarge.Text = string.Empty;
            txtBreafHistory.Text = string.Empty;

            //tempDrug = null;
            //cmbPatient.Properties.DataSource = null;
            cmbPatient.Properties.NullValuePrompt = null;

            cmbPatient.Properties.NullText = "Select Patient";
            PatientLoad();
            GetDischargeInfo();
            
            tempDrug.Rows.Clear();


            btnSave.Enabled = true;
            btnEdit.Enabled = false;



       


          }

        private void txtDischargeOnDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDischareTime.Focus();
            }
        }

        private void txtDischareTime_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbDrug_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
            reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void searchLookUpGetDischargeInfo_EditValueChanged(object sender, EventArgs e)
        {
            //PatientByOPID(cmbPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString());
            //txtDiagonsisAdmisson.Focus();

            DischargePatient _dischargePatient = new DischargePatient();
            _dischargePatient.OPID = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtFahterHusbandName.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("FatherHusbandName").ToString();
            txtRegNo.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("RegNo").ToString();
            txtFahterHusbandName.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("FatherHusbandName").ToString();
            txtGender.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("Gender").ToString();
            txtAge.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("Age").ToString();
            txtBebyGender.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("BloodGroup").ToString();
            txtConsult.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("Consult").ToString();
            txtWeight.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("weight").ToString();
            txtCabinBedNo.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("Cabin_BedNo").ToString();
            txtContactNo.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("ContactNo").ToString();
            txtDiagonsisAdmisson.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("DiagOnAdmission").ToString();
            txtDiagOnDischarge.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("DiagOnDischarge").ToString();
            txtAdmissionOnDate.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("AddmissionOn").ToString();
            txtDischargeOnDate.Text = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("DischargeOn").ToString();


            aMedicalManager = new MedicalManager();
            DataTable dataTable = new DataTable();
            

            dataTable = aMedicalManager.GetDischargeDetails(_dischargePatient);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow rows = tempDrug.NewRow();
                tempDrug.Rows.Add(rows);
                rows["DrugId"] = dataTable.Rows[i]["DrugId"];
                rows["DrugName"] = dataTable.Rows[i]["DrugName"];
                rows["Doose"] = dataTable.Rows[i]["Doose"];
                rows["Description"] = dataTable.Rows[i]["Description"];
                rows["Id"] = dataTable.Rows[i]["Id"];

            }
           


            btnSave.Enabled = false;
            btnEdit.Enabled = true;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveAndUpdateDischargePatient();
            //gridControl1.DataSource = null;
            Refresh();
            flag = false;

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this row?", "Confirmation Message",MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DischargePatient _dischargePatient = new DischargePatient();

                _dischargePatient.OPID = searchLookUpGetDischargeInfo.Properties.View.GetFocusedRowCellValue("OPID").ToString();
                MessageModel aMessageModel = new MessageModel();
                aMessageModel = aMedicalManager.DeleteDischargePatient(_dischargePatient);
                if (aMessageModel.MessageTitle == "Successfull")
                {
                    MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
            }}

        private void txtConsult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        DischargePatient _dischargePatient = new DischargePatient();
        private bool flag = false;
        private void gridViewDischarge_DoubleClick(object sender, EventArgs e)
        {
            flag = true;
            xtraTabPage1.Show();
          
            _dischargePatient.OPID = gridViewDischarge.GetFocusedRowCellValue("OPID").ToString();
            cmbPatient.Properties.NullValuePrompt = gridViewDischarge.GetFocusedRowCellValue("PatientName").ToString();
 
            DataTable data = new DataTable();
            data = new MedicalManager().GetDischargeInfo(_dischargePatient);
            //data = aMedicalManager.GetDischargeInfoMaster();
            //gridControlDischarge.DataSource = data;
            if(data.Rows.Count > 0)
            {
                txtFahterHusbandName.Text = data.Rows[0]["FatherName"].ToString();
                txtRegNo.Text = data.Rows[0]["RegNo"].ToString();
                txtGender.Text = data.Rows[0]["Gender"].ToString();
                txtGender.Text = data.Rows[0]["Gender"].ToString();txtAge.Text = data.Rows[0]["Age"].ToString();
                txtBebyGender.Text = data.Rows[0]["BloodGroup"].ToString();
                //txtConsult.Text = data.Rows[0]["Consult"].ToString();
                txtWeight.Text = data.Rows[0]["weight"].ToString();
                txtContactNo.Text = data.Rows[0]["Phone"].ToString();
                txtDiagonsisAdmisson.Text = data.Rows[0]["DiagOnAdmission"].ToString();
                txtDiagOnDischarge.Text = data.Rows[0]["DiagOnDischarge"].ToString();
                txtAdmissionOnDate.Text = data.Rows[0]["InputDate"].ToString();
                txtDischargeOnDate.Text = data.Rows[0]["DischargeOn"].ToString();
                txtOperationName.Text = data.Rows[0]["Address"].ToString();
                txtCabinBedNo.Text = data.Rows[0]["BedName"].ToString();

                bool Crued =Convert.ToBoolean(data.Rows[0]["Cured"]);
             
                bool dor = Convert.ToBoolean(data.Rows[0]["Dor"]);
               
                bool Improved = Convert.ToBoolean(data.Rows[0]["Improved"]);
                
                bool dorb = Convert.ToBoolean(data.Rows[0]["Dorb"]);
                
                bool notImproved = Convert.ToBoolean(data.Rows[0]["NotImproved"]);
                

            }

            //Grid view start here 
            aMedicalManager = new MedicalManager();
            DataTable dataTable = new DataTable();
           

            dataTable = aMedicalManager.GetDischargeDetails(_dischargePatient);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                DataRow rows = tempDrug.NewRow();
                tempDrug.Rows.Add(rows);
                rows["DrugId"] = dataTable.Rows[i]["DrugId"];
                rows["DrugName"] = dataTable.Rows[i]["DrugName"];
                rows["Doose"] = dataTable.Rows[i]["Doose"];
                rows["Description"] = dataTable.Rows[i]["Description"];
                rows["Route"] = dataTable.Rows[i]["Route"];
                rows["RelatedToMeal"] = dataTable.Rows[i]["RelatedToMeal"];
                rows["Id"] = dataTable.Rows[i]["Id"];

            }
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
        }



        private void gridControlDischarge_DoubleClick(object sender, EventArgs e)
        {
            //string opId = gridView1.GetFocusedRowCellValue("OPID").ToString();
            //MessageBox.Show(opId);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GetDischargeInfoMaster();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportModel model=new ReportModel();
            model.Parameters = new List<ReportParameter>
            {
               
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
            };
            var opid = cmbPatient.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            var DisChargeSummery = new IpdGateway().DisChargeSummery(opid);
            var ConsultSrviceBill = new IpdGateway().DisChargeSummery_ConsultanName(opid);
            var DisChargeSummery_MedicineTakeInHopital = new IpdGateway().DisChargeSummery_MedicineTakeInHopital(opid);
            var DisChargeSummery_Pathology = new IpdGateway().DisChargeSummery_Pathology(opid);
            var DisChargeSummery_Treatment = new IpdGateway().DisChargeSummery_Treatment(opid);

            model.MultiReportDataSource=new List<ReportDataSource>()
            {
                new ReportDataSource("DisChargeSummery",DisChargeSummery),
                new ReportDataSource("ConsultSrviceBill",ConsultSrviceBill),
                 new ReportDataSource("DisChargeSummery_MedicineTakeInHopital",DisChargeSummery_MedicineTakeInHopital),
                  new ReportDataSource("DisChargeSummery_Pathology",DisChargeSummery_Pathology),
                   new ReportDataSource("DisChargeSummery_Treatment",DisChargeSummery_Treatment),
                   new ReportDataSource("DisChargeSummery_Treatment",DisChargeSummery_Treatment),
                  
            };
            model.ReportPath = "GHospital_Care.Report.rdlcDischargeSummery.rdlc";
            model.Show(model,this,true);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>
            {
               
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
            };
            var opid = gridViewDischarge.GetFocusedRowCellValue("OPID").ToString();

            var DisChargeSummery = new IpdGateway().DisChargeSummery(opid);
            var ConsultSrviceBill = new IpdGateway().DisChargeSummery_ConsultanName(opid);

            var DisChargeSummery_MedicineTakeInHopital = new IpdGateway().DisChargeSummery_MedicineTakeInHopital(opid);
            var DisChargeSummery_Pathology = new IpdGateway().DisChargeSummery_Pathology(opid);
            var DisChargeSummery_Treatment = new IpdGateway().DisChargeSummery_Treatment(opid);
           
            model.MultiReportDataSource = new List<ReportDataSource>()
            {
                new ReportDataSource("DisChargeSummery",DisChargeSummery),
                new ReportDataSource("ConsultSrviceBill",ConsultSrviceBill),
                new ReportDataSource("DisChargeSummery_MedicineTakeInHopital",DisChargeSummery_MedicineTakeInHopital),
                new ReportDataSource("DisChargeSummery_Pathology",DisChargeSummery_Pathology),
                new ReportDataSource("DisChargeSummery_Treatment",DisChargeSummery_Treatment),

            };
            model.ReportPath = "GHospital_Care.Report.rdlcDischargeSummery.rdlc";
            model.Show(model, this, true);
        }

        private void cured_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}
