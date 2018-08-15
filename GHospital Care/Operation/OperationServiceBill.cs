using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Mask;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.IndoorPatient;
using GHospital_Care.Session;
using IPBillingSetup = GHospital_Care.IndoorPatient.IPBillingSetup;

//using IPBillingSetup = GHospital_Care.IndoorPatient.IPBillingSetup;

namespace GHospital_Care.Operation
{
    public partial class OperationServiceBill : Form
    {
        private IPBillingSetup BillingSetup;
        SessionData _session = new SessionData();
        public OperationServiceBill(IndoorPatient.IPBillingSetup ipBillingSetup)
        {
            InitializeComponent();
            this.BillingSetup = ipBillingSetup;
        }
        DataTable dtTable=new DataTable();
        public void LoadAllGridview()
        {
            try
            {
                dtTable = new DataTable();
                dtTable = new ServiceManager().GetPatientServiceByPatient(BillingSetup.cmbPid.Text, dateTimePicker1.Value);
                dtTable.Rows.Add();gridControl1.DataSource = dtTable;
                Int64 MaxID = new ServiceGateway().GetOtherServiceMaxValue();
                gridView1.SetRowCellValue(gridView1.RowCount - 1, "VchNo", MaxID);
        
            }
            catch (Exception)
            {
                
             //   throw;
            }
           
        }

        public void LoadGridView()
        {
            DataTable billservice = BillingSetup.LoadOperationService();
            repositoryItemSearchLookUpEdit2.DataSource = billservice;
            repositoryItemSearchLookUpEdit2.DisplayMember = "ServiceName";
            repositoryItemSearchLookUpEdit2.ValueMember = "ServiceName";
            LoadAllGridview();  
        }
        private void OperationServiceBill_Load(object sender, EventArgs e)
        {
            LoadGridView();
            ChkPermission();
        }
        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void repositoryItemSearchLookUpEdit2_Click(object sender, EventArgs e)
        {
        
        }

        private void repositoryItemSearchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

            SearchLookUpEdit editor = gridView1.ActiveEditor as SearchLookUpEdit;
            int index = editor.Properties.GetIndexByKeyValue(editor.EditValue);

            DataTable dataTable = editor.Properties.DataSource as DataTable;

            if (dataTable != null)
            {
                DataRow row = dataTable.Rows[index];
                if (dtTable.AsEnumerable().Count(a => a["ServiceId"].ToString() == row["ServiceId"].ToString()) > 0)
                {
                    Int64 vch = Convert.ToInt64(gridView1.GetRowCellValue(gridView1.RowCount - 1, "VchNo"));
                    dtTable.Rows.RemoveAt(gridView1.GetFocusedDataSourceRowIndex());
                    dtTable.Rows.Add();
                    gridView1.SetRowCellValue(gridView1.RowCount - 1, "VchNo", vch);
                    return;
                }
                gridView1.SetFocusedRowCellValue("Description", row["Description"]);
                gridView1.SetFocusedRowCellValue("Rate", row["rate"]);
                gridView1.SetFocusedRowCellValue("ServiceId", row["ServiceId"]);
                gridView1.SetFocusedRowCellValue("Qty",1);
                
            }
            int rowIndex = gridView1.GetFocusedDataSourceRowIndex();
            if (rowIndex == gridView1.RowCount - 1)
            {
                gridView1.SetFocusedRowCellValue("serviceDate", dateTimePicker1.Value);
                Int64 vch = Convert.ToInt64(gridView1.GetRowCellValue(gridView1.RowCount - 1, "VchNo"));
                gridView1.SetRowCellValue(gridView1.RowCount - 1, "VchNo", vch);
                DataRow rows = dtTable.NewRow();
                dtTable.Rows.Add(rows);
                gridView1.SetRowCellValue(gridView1.RowCount - 1, "VchNo", vch + 1);
            }
          
        }
        public List<Service> GetAllListSaveService()
        {
            List<Service> List=new List<Service>();
            for (int i = 0; i < gridView1.RowCount-1; i++)
            {
                var ServiceName = Convert.ToString(gridView1.GetRowCellValue(i, "SName"));
                var ServiceId = Convert.ToString(gridView1.GetRowCellValue(i, "ServiceId"));
                var Qty = Convert.ToInt16(gridView1.GetRowCellValue(i, "Qty"));
                var Rate = Convert.ToDouble(gridView1.GetRowCellValue(i, "Rate"));
                DateTime IssueDate = Convert.ToDateTime(gridView1.GetRowCellValue(i, "serviceDate")).Date;
                var VchNo = gridView1.GetRowCellValue(i, "VchNo");

                if (VchNo == DBNull.Value)
                {
                    VchNo = 0;
                }
                List.Add(new Service { ServiceId = ServiceId, ServiceName = ServiceName, Qty = Qty, Rate = Rate, OPID = BillingSetup.cmbPid.Text,IssueDate = IssueDate,VoucherNo = Convert.ToInt64(VchNo)});
            }
            return List;
        } 
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Service aService = new Service();
            aService.PatientService = GetAllListSaveService();
          
            MessageModel save = new ServiceManager().SavePatientOT_OtherService(aService, null);
            MessageBox.Show(save.MessageBody, save.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAllGridview();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {

        }

        private void Patient_buttonEnable(bool stat)
        {
            btnOTSave.Enabled = stat;
            btnOTEdit.Enabled = !stat;
            gridView1.Columns["Remove"].Visible = !stat;

        }

        private void ChkPermission()
        {
            _session.ChkPermission(MainWindow.userName);

            if (_session.SavePermission == true && _session.EditPermission == false &&
                _session.DeletePermission == false)
            {
                Patient_buttonEnable(true);
            }
            if (_session.SavePermission == true && _session.EditPermission == true &&
                _session.DeletePermission == false)
            {
                Patient_buttonEnable(true);
                btnOTEdit.Enabled = true;
            }
            if (_session.SavePermission == true && _session.EditPermission == false &&
                _session.DeletePermission == true)
            {
                Patient_buttonEnable(true);
                gridView1.Columns["Remove"].Visible = true;
            }
            if (_session.SavePermission == false && _session.EditPermission == true &&
                _session.DeletePermission == false)
            {
                Patient_buttonEnable(false);
                gridView1.Columns["Remove"].Visible = false;
            }
        }
    }
}
