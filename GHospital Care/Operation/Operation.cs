using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;
using GHospital_Care.Doctors;
using GHospital_Care.Session;

namespace GHospital_Care.Operation
{
    public partial class Operation : DevExpress.XtraEditors.XtraForm
    {
        private OperationScheduleManager aOperationScheduleManager;
        SessionData _session = new SessionData();
        public Operation()
        {
            InitializeComponent();
            ActiveControl = cmbPatienId;
            aOperationScheduleManager = new OperationScheduleManager();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this.groupBox3, this.Name);
        }


        private void CosulultDoctor()
        {
            DataTable AllDoctor = new MedicalManager().GetAllCosultDoctor(null);
            searchLookSurgeonName.Properties.DataSource = AllDoctor;
            searchLookSurgeonName.Properties.DisplayMember = "DoctorName";
            searchLookSurgeonName.Properties.ValueMember = "DoctorID";

            txtAnastheisLogist.Properties.DataSource = AllDoctor;
            txtAnastheisLogist.Properties.DisplayMember = "DoctorName";
            txtAnastheisLogist.Properties.ValueMember = "DoctorID";


        }

        private void New()
        {
            txtCabinName.Text = "";
            txtName.Text = "";
            txtFistAsst.Text = "";
        txtSecondAsst.Text = "";
            txtAnastheisLogist.Text = "";
            txtOpName.Text = "";
            dateOtDate.Text = Convert.ToString(DateTime.Now);
            txtId.Text = "";txtOtReffNo.Text = "";
            dateOperationTime.Value = DateTime.Now;
            dateToTime.Value = DateTime.Now;

            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;

            searchLookSurgeonName.Properties.NullText = "Select";
            searchLookSurgeonName.Text = null;


            GetOpInfo();
            GetOperationSchedule();
            GetOTRef();cmbPatienId.Properties.NullText = "Select Patient";
        }
        public void GetOpInfo()
        {
            cmbPatienId.Properties.DataSource = aOperationScheduleManager.GetOpInfo();
            cmbPatienId.Properties.DisplayMember = "PatientName";
            cmbPatienId.Properties.ValueMember = "OPID";

        }

        public void GetOTRef()
        {
            DataTable Dt = new OperationScheduleManager().GetOTRef();
            if (Dt != null && Dt.Rows.Count > 0)
            {
                txtOtReffNo.Text = Dt.Rows[0][0].ToString();
            }
        }
        public void GetOperationSchedule()
        {
            gridControl1.DataSource = aOperationScheduleManager.GetOperationSchedule();
        }private void btnSave_Click(object sender, EventArgs e)
        {
            OperationSchedule schedule = new DAL.Model.OperationSchedule();
            schedule.OtRefNo = txtOtReffNo.Text;
            schedule.OtDate = dateOtDate.Value;
            schedule.Opid = cmbPatienId.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            schedule.CabinBed = txtCabinName.Text;
            schedule.PatientName = txtName.Text;
            schedule.FirstAssist = txtFistAsst.Text;
            schedule.SurgeonName = searchLookSurgeonName.EditValue.ToString();
            schedule.SecondAssist = txtSecondAsst.Text;
            schedule.Anaesthesiologist = txtAnastheisLogist.EditValue.ToString();
            schedule.OperationName = txtOpName.Text;
            DateTime dt = dateOperationTime.Value;
            TimeSpan st = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            //patient.AdmissionTime = st;

            schedule.OperationTime = st;

            DateTime todate = dateToTime.Value;
            TimeSpan toTime = new TimeSpan(todate.Hour, todate.Minute, todate.Second);
            schedule.ToTime = toTime;

            schedule.UserId = lblUserId.Text;
            MessageModel messageModel = new OperationScheduleManager().SaveOperationSchedule(schedule);
            MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            New();



          }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OperationSchedule schedule = new DAL.Model.OperationSchedule();
            schedule.Id = Convert.ToInt32(txtId.Text);
            schedule.OtRefNo = txtOtReffNo.Text;
            schedule.OtDate = dateOtDate.Value;schedule.Opid = PatientID; //cmbPatienId.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            schedule.CabinBed = txtCabinName.Text;
            schedule.PatientName = txtName.Text;
            schedule.FirstAssist = txtFistAsst.Text;
            schedule.SurgeonName = searchLookSurgeonName.EditValue.ToString();
            schedule.SecondAssist = txtSecondAsst.Text;
            schedule.Anaesthesiologist = txtAnastheisLogist.Text;
            schedule.OperationName = txtOpName.Text;


            DateTime dt = dateOperationTime.Value;
            TimeSpan st = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            schedule.OperationTime = st;
            
            DateTime todate = dateToTime.Value;
            TimeSpan toTime = new TimeSpan(todate.Hour, todate.Minute, todate.Second);
            schedule.ToTime = toTime;

            schedule.UserId = lblUserId.Text;
            MessageModel messageModel = new OperationScheduleManager().UpdateOperationSchedule(schedule);
            MessageBox.Show(messageModel.MessageBody, messageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            New();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OperationSchedule aOperationSchedule = new OperationSchedule();
            aOperationSchedule.OtRefNo = txtOtReffNo.Text;
            if (aOperationSchedule.Id != null)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //OperationSchedule aOperationSchedule = new OperationSchedule();
                    //aOperationSchedule.Id = Convert.ToInt32(txtId.Text);
                    MessageModel aMessageModel = new MessageModel();

                    aMessageModel = aOperationScheduleManager.DeleteOperationSchedule(aOperationSchedule);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        New();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbPatienId_EditValueChanged(object sender, EventArgs e)
        {
            txtName.Text = cmbPatienId.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
        }

        private void Operation_Load(object sender, EventArgs e)
        {
            GetOTRef();
            GetOpInfo();
            GetOperationSchedule();
            CosulultDoctor();
            _session.ChkPermission(MainWindow.userName);
            if (_session.SavePermission == false)
            {
                Operation_buttonEnable(true);
                btnSave.Enabled = false;
            }
            else
            {
                Operation_buttonEnable(true);
            }
        }

        public string PatientID = "";
        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtOtReffNo.Text = gridView1.GetFocusedRowCellValue("OtRefNo").ToString();
            dateOtDate.Text = gridView1.GetFocusedRowCellValue("OtDate").ToString();
            txtCabinName.Text = gridView1.GetFocusedRowCellValue("CabinBed").ToString();
            txtName.Text = gridView1.GetFocusedRowCellValue("PatientName").ToString();
            txtFistAsst.Text = gridView1.GetFocusedRowCellValue("FirstAssist").ToString();
            
            
           searchLookSurgeonName.Properties.NullText = gridView1.GetFocusedRowCellValue("DoctorName").ToString();
          
            txtSecondAsst.Text = gridView1.GetFocusedRowCellValue("SecondAssist").ToString();
            txtAnastheisLogist.Text = gridView1.GetFocusedRowCellValue("Anaesthesiologist").ToString();
            txtOpName.Text = gridView1.GetFocusedRowCellValue("OperationName").ToString();
            dateOperationTime.Text = gridView1.GetFocusedRowCellValue("OperationTime").ToString();
            dateToTime.Text = gridView1.GetFocusedRowCellValue("ToTime").ToString();

            PatientID = gridView1.GetFocusedRowCellValue("OPID").ToString();
            cmbPatienId.Properties.View.SetFocusedRowCellValue("OPID", PatientID);

            var PatientName = gridView1.GetFocusedRowCellValue("PatientName").ToString();
            cmbPatienId.Properties.NullText = PatientName;
            ChkPermission();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnAddSurgeon_Click(object sender, EventArgs e)
        {
            Consultent_UI Form=new Consultent_UI();
            Form.ShowDialog(this);
            CosulultDoctor();
        }
        
        private void Operation_buttonEnable(bool stat)
        {
            btnSave.Enabled = stat;
            btnEdit.Enabled = !stat;
            btnDelete.Enabled = !stat;
        }

        private void ChkPermission()
        {
            _session.ChkPermission(MainWindow.userName);
            if (_session.EditPermission == true && _session.DeletePermission == true)
            {
                Operation_buttonEnable(false);
            }
            if (_session.EditPermission == true && _session.DeletePermission == false)
            {
                Operation_buttonEnable(false);
                btnDelete.Enabled = _session.DeletePermission;
            }
            if (_session.EditPermission == false && _session.DeletePermission == true)
            {
                Operation_buttonEnable(false);
                btnEdit.Enabled = _session.EditPermission;
            }
            if (_session.EditPermission == false && _session.DeletePermission == false)
            {
                Operation_buttonEnable(true);
                btnSave.Enabled = false;
            }

            if (_session.SavePermission == false && _session.EditPermission == true &&
                _session.DeletePermission == false)
            {
                Operation_buttonEnable(false);
               btnDelete.Enabled= false;
            }
        }
    }
}