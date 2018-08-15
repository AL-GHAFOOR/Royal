using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.IndoorPatient;
using GHospital_Care.Session;
using LINQtoDataTable;
using IPBillingSetup = GHospital_Care.IndoorPatient.IPBillingSetup;

//using IPBillingSetup = GHospital_Care.IndoorPatient.IPBillingSetup;

namespace GHospital_Care.Operation
{
    public partial class O_TServiceMedicine : Form
    {
        private IPBillingSetup IpBillingSetup;
        SessionData _session = new SessionData();
        public O_TServiceMedicine(IPBillingSetup ipBillingSetup)
        {
            InitializeComponent();
           this.IpBillingSetup = ipBillingSetup;

        }

        public List<OT_Consump> AddProductMedinine()
        {
            List<OT_Consump> List = new List<OT_Consump>();
          
            for (int rowHandle = 0; rowHandle < gridView1.RowCount-1; rowHandle++)
            {
                var ProductId = gridView1.GetRowCellValue(rowHandle, "ProductId");
                var ProductName = gridView1.GetRowCellValue(rowHandle, "ProductName");
                var Rate = gridView1.GetRowCellValue(rowHandle, "Rate");
                var Qty = gridView1.GetRowCellValue(rowHandle, "Qty");
                var VOUCHERNo = gridView1.GetRowCellValue(rowHandle, "Id");
                var batchId = gridView1.GetRowCellValue(rowHandle, "batchId");
                var IsueDate = gridView1.GetRowCellValue(rowHandle, "IssueDate");
                var VouherNo = gridView1.GetRowCellValue(rowHandle, "VoucherNo");
                var PatientID = IpBillingSetup.cmbPid.Text;
                
                if (VOUCHERNo==DBNull.Value)
                {
                    VOUCHERNo = 0;
                }
                if (VouherNo == DBNull.Value)
                {
                    VouherNo = 0;
                }
                if (ProductId != DBNull.Value && Qty != DBNull.Value && Rate != DBNull.Value )
                {
                    List.Add(new OT_Consump() { Id = (int)VOUCHERNo, ProductId = ProductId.ToString(), ProductName = ProductName.ToString(), Rate = Convert.ToDecimal(Rate), Qty = Convert.ToInt16(Qty), batchId = batchId.ToString(), IssueDate = Convert.ToDateTime(IsueDate).Date, VoucherNo = (long)VouherNo, OPID = PatientID});
                }
        
            }
           return List;
        }
        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {
         //   IpBillingSetup.ListOfConsumeList = AddProductMedinine();
            this.Close();
        }

       DataTable dt=new DataTable();
        private void O_TServiceMedicine_Load(object sender, EventArgs e)
        {
           LoadMedicine();
        }

        public void LoadMedicine()
        {
            try
            {
                Service service = new Service();
                service.OPID = IpBillingSetup.cmbPid.Text;
                service.OtReffNo = IpBillingSetup.txtOtReffNo.Text;
                service.IssueDate = Convert.ToDateTime(dateTimePicker1.Text).Date;
                service.GodownId = "2";
                repositoryItemSearchLookUpEdit1.DataSource = new IpdManager().OT_StockMedicine(service);
                repositoryItemSearchLookUpEdit1.DisplayMember = "ProductId";
                repositoryItemSearchLookUpEdit1.ValueMember = "ProductId";
                var list = new IpdManager().GetOtServiceConsumListByPatientId(service);
                dt = new CustomLibry.CustomLibrary().ToDataTable(list);
                gridControl1.DataSource = dt;
                Int64 MaxID = new ServiceGateway().GetOtMaxValue();
                gridView1.SetRowCellValue(gridView1.RowCount - 1, "VoucherNo", MaxID);
            }
            catch (Exception  ex)
            {
                //new MailServer.MailServerConnection().SentMail(ex.Message);
            }
            
        }
         private void repositoryItemSearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            bool flag = false;
            SearchLookUpEdit edit=sender as SearchLookUpEdit;
            var productId = edit.Properties.View.GetFocusedRowCellValue("ProductId");
            var BatchID = edit.Properties.View.GetFocusedRowCellValue("batchId");
            var row = (DataTable) gridControl1.DataSource;
            int rowIndex = gridView1.GetFocusedDataSourceRowIndex();
            
            if (rowIndex == gridView1.RowCount - 1)
            {
                if (row.AsEnumerable().Count(a =>(a["ProductId"].ToString() == productId.ToString() &&a["batchId"].ToString() == BatchID.ToString())) > 0)
                {
                   Int64 vch = (long) gridView1.GetRowCellValue(gridView1.RowCount - 1, "VoucherNo");
                    dt.Rows.RemoveAt(gridView1.GetFocusedDataSourceRowIndex());
                    dt.Rows.Add();
                    gridView1.SetRowCellValue(gridView1.RowCount - 1, "VoucherNo", vch);
                    flag = true;
                    return;
                }
            }
            else
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var PID = gridView1.GetRowCellValue(i, "ProductId").ToString();
                    var Batch = gridView1.GetRowCellValue(i, "batchId").ToString();
                    if (productId.ToString() == PID && BatchID.ToString() == Batch)
                    {
                        productId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductId").ToString();
                        gridView1.SetFocusedRowCellValue("ProductId", productId);
                        return;
                    }
                }
            }

             Int64 MaxID = new ServiceGateway().GetOtMaxValue();
            var qty = edit.Properties.View.GetFocusedRowCellValue("Qty");
                var rate = edit.Properties.View.GetFocusedRowCellValue("Rate");
            var name = edit.Properties.View.GetFocusedRowCellValue("ProductName");
            var batchId = edit.Properties.View.GetFocusedRowCellValue("batchId");
            
            gridView1.SetFocusedRowCellValue("Qty",Convert.ToInt16(qty??1));
            gridView1.SetFocusedRowCellValue("rate",Convert.ToDecimal(rate??0));
            gridView1.SetFocusedRowCellValue("ProductName", name);
            gridView1.SetFocusedRowCellValue("ProductId", productId);
            gridView1.SetFocusedRowCellValue("batchId", batchId);
            
            if (flag == false)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (rowIndex == gridView1.RowCount - 1)
                    {
                        gridView1.SetFocusedRowCellValue("IssueDate", dateTimePicker1.Value);
                        Int64 vch = (long)gridView1.GetRowCellValue(gridView1.RowCount - 1, "VoucherNo");
                        gridView1.SetRowCellValue(gridView1.RowCount - 1, "VoucherNo", vch);
                        dt.Rows.Add();
                        gridView1.SetRowCellValue(gridView1.RowCount - 1, "VoucherNo", vch + 1);
                      }
                    return;
                }
            }
                  
            //string vchNo = MaxID.ToString();
            
           
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadMedicine();
        
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Service> srcv = new List<Service>();Service aService = new Service();

           
                aService.OtReffNo = IpBillingSetup.txtOtReffNo.Text;
                aService.OPID = IpBillingSetup.cmbPid.Text;
                aService.IssueDate = Convert.ToDateTime(dateTimePicker1.Value).Date;
                aService.VoucherNo = Convert.ToInt64(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VoucherNo"));
                      
            aService.OtConsump = AddProductMedinine();
            MessageModel message = new ServiceManager().SaveOtService(aService);
            MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.GetFocusedDataSourceRowIndex());
        }




        private void Patient_buttonEnable(bool stat)
        {
            btnOTservice.Enabled = stat;
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
