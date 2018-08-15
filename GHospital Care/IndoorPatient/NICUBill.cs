using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.IndoorPatient
{
    public partial class NICUBill : DevExpress.XtraEditors.XtraForm
    {
        public NICUBill()
        {
            InitializeComponent();
        }

        private void NICUBill_Load(object sender, EventArgs e)
        {
            var slNo = new NICUBillManager().GetAllNICUPatienSlNo();
            cmbPatient.Properties.DataSource = slNo;
            cmbPatient.Properties.DisplayMember = "PatientName";
            cmbPatient.Properties.ValueMember = "RegNo";
            PathologyMaster();
        }


        public void PathologyMaster()
        {
            DataTable PMaster = new ServiceManager().GetPathologyMaster();
            repositoryItemLookUpEdit2.DataSource = PMaster;
            repositoryItemLookUpEdit2.DisplayMember = "Alias";
            repositoryItemLookUpEdit2.ValueMember = "Alias";

        }

        public void LoadNICUPatientInfo(string PatientID)
        {
            NicuAddmission setup = new NICUBillManager().GetNICUPatientInfo(PatientID);
            cmbPatient.Text=setup.RegNo ;
            txtAge.Text=setup.Age ;
            txtFatherName.Text=setup.FatherName ;
            txtMotherName.Text = setup.MotherName;
            admitDate.Value=  setup.AdmitDate ;
            txtAddress.Text=setup.Address ;
            txtCabinBed.Text = setup.Bed ;
            txtBloodGroup.Text= setup.BabysBloodGroup ;
            txtPhone.Text=setup.ContactNo ;
            txtGender.Text=setup.Sex ;

          }

        private void cmbPatient_EditValueChanged(object sender, EventArgs e)
        {
            LoadNICUPatientInfo(cmbPatient.Text);
        }

        private void repositoryItemSearchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = gridView1.ActiveEditor as LookUpEdit;
            if (edit != null)
            {
                object value = edit.Text;
                DataRow service = new ServiceManager().GetPathologyMaster().AsEnumerable().FirstOrDefault(a => a["Alias"].ToString() == value.ToString());

                var serviceName = service["Alias"].ToString();
                var PathID = service["PathID"].ToString();

                gridView1.SetFocusedRowCellValue("Alias", serviceName);
                gridView1.SetFocusedRowCellValue("PathID", PathID);

            }
        }

        private void btnPathologyEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnMedicineEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnPatientEdit_Click(object sender, EventArgs e)
        {

        }
    }
}