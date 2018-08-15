using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.Settings
{
    public partial class FollowupListMaster : Form
    {
        public FollowupListMaster()
        {
            InitializeComponent();
        }
        private void GetDeparment()
        {

            cmbDept.DataSource = new FollowUpManager().GetDeparmentTreatment();
            cmbDept.DisplayMember = "DeparmentName";
            cmbDept.ValueMember = "Id";
        }
        private void FollowupListMaster_Load(object sender, EventArgs e)
        {
            //FollowUpManager manager = new FollowUpManager();
            //List<FollowUPMaster> List = manager.GetALLFollowUpWithSubItems();
            //gridControl1.DataSource = List;
            GetDeparment();
            ItemWiseFollowupItem();
        }

        public void DepartmentWiseFollowupItem()
        {
            try
            {
                var MaterID = "";
                List<FollowUPMaster> List = new List<FollowUPMaster>();
                FollowUpManager manager = new FollowUpManager();
                List = manager.GetALLFollowUpWithSubItemsByDepartment(cmbDept.Text, MaterID);
                gridControl1.DataSource = List;
            }
            catch 
            {
                
               
            }  
           
            
        }


        public void ItemWiseFollowupItem()
        {
            try
            {
                var MaterID = "";
                List<FollowUPMaster> List = new List<FollowUPMaster>();
                FollowUpManager manager = new FollowUpManager();

                List = manager.GetALLFollowUpWithSubItems(MaterID);
                gridControl1.DataSource = List;
            }
            catch
            {


            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<FollowUPMaster> List = new List<FollowUPMaster>();

            foreach (int row in gridView1.GetSelectedRows())
            {
                FollowUPMaster master = new FollowUPMaster();
                master.SubItems = new List<FollowUpSubItem>();
                var followupItem = gridView1.GetRowCellValue(row, "ID");
                master.ID = Convert.ToInt16(followupItem.ToString());
                master.DepartmentId = cmbDept.SelectedValue.ToString();
                bool wasExpanded = gridView1.GetMasterRowExpanded(row);
                if (!wasExpanded)
                    gridView1.ExpandMasterRow(row);
                GridView detail = gridView1.GetDetailView(row, 0) as GridView;
                if (detail != null)
                {
                    foreach (int child in detail.GetSelectedRows())
                    {
                        var subItem = detail.GetRowCellValue(child, "Id");
                        master.SubItems.Add(new FollowUpSubItem
                        {
                            ItemId = Convert.ToInt16(followupItem),
                            Id = Convert.ToInt16(subItem)

                        });
                    }
                }

                List.Add(master);
            }

            string msage = new FollowUpManager().SaveFollowUpSheet(List);
            MessageBox.Show(msage);
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DepartmentWiseFollowupItem();
        }
        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
