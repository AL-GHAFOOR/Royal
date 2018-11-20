using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using System.Data.SqlClient;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.Session;
using MetroFramework;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.IndoorPatient
{
    public partial class IPAdmission : Form
    {

        Tools tools = new Tools();
        private OutdoorPatientManager aOutdoorPatientManager;
        private RefferedInfoManager _aRefferedInfoManager;
        SessionData _session = new SessionData();
        
        public IPAdmission()
        {
            aOutdoorPatientManager = new OutdoorPatientManager();
            _aRefferedInfoManager=new RefferedInfoManager();
            InitializeComponent();
           // GetAllCabin();
            //chkCabin.Checked = true;
        }
        private void buttonEnable(bool stat)
        {
            btnSave.Enabled = stat;
            btnEdit.Enabled = !stat;
            btnDelete.Enabled = !stat;
        }

        //Method Start here  //Method Start here  //Method Start here  //Method Start here 
        //Method Start here  //Method Start here  //Method Start here  //Method Start here  

        #region

        private void Permissionchk()
        {
            if (_session.SavePermission == true && _session.EditPermission == true && _session.DeletePermission == true)
            {
                btnSave.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;

            }
            else if (_session.SavePermission == true && _session.EditPermission == false &&
                     _session.DeletePermission == false)
            {
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (_session.SavePermission == true && _session.EditPermission == true &&
                     _session.DeletePermission == false)
            {
                btnSave.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = false;
            }
            else if (_session.SavePermission == false && _session.EditPermission == false &&
                    _session.DeletePermission == false)
            {
                btnSave.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        public void GetIpRegID()
        {
            DataTable data = new DataTable();
            data = new IpdManager().GetIpRegID();
            txtReg.Text = data.Rows[0]["RegNo"].ToString();
        }

        public void GetAllIpdPatient()
        {
            pidSearchLookUpEdit.Properties.DataSource = null;
            pidSearchLookUpEdit.Properties.DataSource = new IpdManager().GetIpdAllIpdPatient();
            pidSearchLookUpEdit.Properties.ValueMember = "OPID";
            pidSearchLookUpEdit.Properties.DisplayMember = "PatientName";
        }
        DataTable data = new DataTable();
        public void GetRefferedInfo()
        {
            data = new RefferedInfoManager().PopulateGridView();
            cmbRefferBy.DataSource = data;
            cmbRefferBy.DisplayMember = "Name";
            cmbRefferBy.ValueMember = "Id";
            //cmbRefferBy.Tag = data.Rows.Contains();

            //pidSearchLookUpEdit.Properties.DataSource = null;
            //pidSearchLookUpEdit.Properties.DataSource = new IpdManager().GetIpdAllIpdPatient();
            //pidSearchLookUpEdit.Properties.ValueMember = "OPID";
            //pidSearchLookUpEdit.Properties.DisplayMember = "PatientName";
        }
        private void GeneratePatientId()
        {
            DataTable data = new DataTable();
            data = aOutdoorPatientManager.GeneratePatientId();
            if (data.Rows.Count > 0)
            {
                txtOpid.Text = data.Rows[0]["OPID"].ToString();
            }
        }

        DataTable Admission = new DataTable();
        private void PatitientInfo()
        {
            Admission = new IpdManager().GetAllIpAdmissionInfo(FromDate.Value, ToDate.Value);
            IndoorPatientRegGridControl.DataSource = Admission;
        }
        //private void GenerateReg()
        //{
        //    DataTable dt = new IpdManager().GetIpRegID();
        //    txtReg.Text = dt.Rows[0][0].ToString();
        //}
        private void GetIpdAllDoctor()
        {
            cmbDutydoctor.DataSource = new IpdManager().GetIpdAllDoctor();
            cmbDutydoctor.DisplayMember = "DoctorName";
            cmbDutydoctor.ValueMember = "DoctorID";
       }
        private void SetNew()
        {
            txtAddress.Text = "";
            txtAge.Text = "";
            //txtID.Text = "";
            txtPhone.Text = "";
            txtName.Text = "";
            txtGurdian.Text = "";
            txtPhone.Text = "";

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            GenerateID();
            LoadData();
            LoadDoctors();
           // GetAllWard();
            LoadRooms();
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlCommand cmd = new SqlCommand("SP_GENERATE_IPID", ob);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader;
            ob.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
        }
        private void LoadData()
        {
            IndoorPatientRegGridControl.DataSource = new IpdManager().GetAllIpAdmissionInfo(FromDate.Value, ToDate.Value);
            //GetAllWard();
            //GetAllCabin();
            GetAllCabin();
            GetRefferedInfo();
            GetIpRegID();
        }
        private void LoadDoctors()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select * from tblDoctors";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        private void GetAllWard()
        {
            IpdManager aIpdManager = new IpdManager();
            cmbwardCabin.DataSource = aIpdManager.GetAllWard();
            cmbwardCabin.DisplayMember = "WardName";
            cmbwardCabin.ValueMember = "Id";
        }



        private void LoadRooms()
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand ds = da.SelectCommand;
                ds.CommandText = "select* from tblRooms where WardNo=@WardNo";
                ds.CommandType = CommandType.Text;
                // ds.Parameters.Add("@WardNo", SqlDbType.Int).Value = cmbWard.SelectedValue;

                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception)
            {
            }
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


        private void GetAllCabin()
        {
            IpdManager aIpdManager = new IpdManager();
            cmbwardCabin.DataSource = aIpdManager.GetAllCabin();
            cmbwardCabin.DisplayMember = "CabinName";
            cmbwardCabin.ValueMember = "Id";
        }

        private void GetAllCabinUpdate()
        {
            IpdManager aIpdManager = new IpdManager();
            cmbwardCabin.DataSource = aIpdManager.GetAllCabinUpdate();
            cmbwardCabin.DisplayMember = "CabinName";
            cmbwardCabin.ValueMember = "Id";
        }
        private void LoadBeds()
        {
            IpdManager aIpdManager = new IpdManager();
            txtseletedBed.DataSource = aIpdManager.GetAllBeds(cmbwardCabin.Text);
            txtseletedBed.DisplayMember = "BedName";
            txtseletedBed.ValueMember = "BedId";
        }
        public void Refresh()
        {
            xtraTabPage1.Show();
            txtName.Clear();
            txtFatherName.Clear();
            txtMother.Clear();
            txtAddress.Clear();
            txtAge.Clear();
            txtPhone.Clear();
            txtGurdian.Clear();
            cmbMaritalStatus.Text = "";
            txtNationality.Text = "";

            txtRelation.Clear();
            GetAllCabin();
            
            cmbGender.Text = "----Select----";
            cmbbloodGroup.Text = "----Select----";
            txtWeight.Clear();
            cmbRefferBy.Text="";
            //comPrimaryDoctor.Text = "----Select----";
            txtPrimaryDoctor.Text = "";
            
            txtPatientCondition.Clear();
            cmbDepartment.Clear();
            txtNationality.Clear();
            txtReg.Clear();
            AdmissionTime.Value = DateTime.Now.ToLocalTime();
            txtNationality.Text = "Bangladeshi";
            //btnSave.Text == "Save";
            id = null;
            GeneratePatientId();
            //btnSave.Enabled = true;
            //btnEdit.Enabled = false;
            //btnDelete.Enabled = false;

            buttonEnable(true);

            //string time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            //GetIpRegID();
            pidSearchLookUpEdit.Enabled = true;
            pidSearchLookUpEdit.Properties.DataSource = null;
            GetAllIpdPatient();
            LoadData();
            GetRefferedInfo();

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
        private void GetBadorCabin()
        {
            DataTable dt = new BedHistoryManager().GetFreeOccupiedBed(FreeOccupied, cmbWardorCabin.Text);
            gridControl2.DataSource = dt;
        }

        #endregion
        //Events Start here //Events Start here //Events Start here //Events Start here //Events Start here //Events Start here 
        //Events Start here //Events Start here //Events Start here //Events Start here //Events Start here //Events Start here 
        #region
        private void IPAdmission_Load(object sender, EventArgs e)
        {
       
            Control buttonControl=new ButtonPermissionAccess().UserButton(this.panel3,this.Name);
           //chkCabin.Checked = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            LoadData();
          //  GetAllCabin();
            this.ActiveControl = txtName;

            cmbWardorCabin.Text = "All Cabin";
            rdFree.Checked = true;
            ChkFreeOccupied();
            

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                //pidSearchLookUpEdit
                Patient patient = new Patient();
                Service service = new Service();
                //patient.RefferedBy = cmbRefferBy.SelectedValue.ToString();
                DAL.Model.OutdoorPatient aOutdoorPatient = new DAL.Model.OutdoorPatient();
                aOutdoorPatient.Opid = txtOpid.Text;
                aOutdoorPatient.ServiceDate = AdmissionDate.Value;
                aOutdoorPatient.TreatementType = "IPD";
                aOutdoorPatient.PatientName = txtName.Text;
                aOutdoorPatient.GurdianName = txtGurdian.Text;
                aOutdoorPatient.Address = txtAddress.Text;

                if (txtAge.Text != null)
                {
                  aOutdoorPatient.Age = Convert.ToInt32(txtAge.Text);
                } 
                aOutdoorPatient.Phone = txtPhone.Text;
                aOutdoorPatient.Mobile = txtPhone.Text;
                aOutdoorPatient.Nationality = txtNationality.Text;
               // aOutdoorPatient.Doctor = comPrimaryDoctor.Text;


                aOutdoorPatient.Fees = txtRegFf.Text;
                aOutdoorPatient.ContactPerson = txtGurdian.Text;
                aOutdoorPatient.Gender = cmbGender.Text;
                if (cmbbloodGroup.Text == "A+" || cmbbloodGroup.Text == "A-" || cmbbloodGroup.Text == "AB+" || cmbbloodGroup.Text == "AB-" || cmbbloodGroup.Text == "B+" || cmbbloodGroup.Text == "B-" || cmbbloodGroup.Text == "O+" || cmbbloodGroup.Text == "O-" || cmbbloodGroup.Text == "N/A")
                {
                   aOutdoorPatient.BloodGroup = cmbbloodGroup.Text;
                }
                patient.OPID = txtOpid.Text;
                patient.PatientName = txtName.Text;
                patient.FatherName = txtFatherName.Text;
                patient.MotherName = txtMother.Text;
                patient.Address = txtAddress.Text;
                patient.Area = cmbArea.Text;
                patient.Age = txtAge.Text;
                patient.Area = cmbArea.Text;
                if (cmbMaritalStatus.Text == "Married" || cmbMaritalStatus.Text == "Single" || cmbMaritalStatus.Text == "Divorced" || txtAge.Text == "Separated" || cmbMaritalStatus.Text == "Widowed")
                {
                    patient.MaritalStatus = cmbMaritalStatus.Text;
                }
                patient.Mobile = txtPhone.Text;
                patient.Gurdian = txtGurdian.Text;
                patient.Phone = txtPhone.Text;
                
                if (cmbGender.Text == "Male" || cmbGender.Text == "Female" || cmbGender.Text == "Neuture")
                {
                    patient.Gender = cmbGender.Text;
                }
                if (cmbbloodGroup.Text == "A+" || cmbbloodGroup.Text == "A-" || cmbbloodGroup.Text == "AB+" || cmbbloodGroup.Text == "AB-" || cmbbloodGroup.Text == "B+" || cmbbloodGroup.Text == "B-" || cmbbloodGroup.Text == "O+" || cmbbloodGroup.Text == "O-" || cmbbloodGroup.Text == "N/A")
                {
                    patient.BloodGroup = cmbbloodGroup.Text;
                }
                patient.Religion = cmbReligion.Text;
                patient.RefferedBy = cmbRefferBy.SelectedValue.ToString();
                //patient.Doctor = comPrimaryDoctor.Text;
                patient.Department = cmbDepartment.Text;
                patient.PatientCondition = txtPatientCondition.Text;
                patient.RegNo = txtReg.Text;


                if (chkCabin.Checked == false)
                {
                    var cabin = cmbwardCabin.SelectedValue;
                    patient.WardOrCabin = cabin.ToString();
                }
                else
                {
                    var bed = txtseletedBed.SelectedValue;
                    patient.SelectedBed = "";
                    patient.PatientCondition = txtPatientCondition.Text;
                    if (bed != null)
                    {
                        patient.SelectedBed = bed.ToString();
                    }
                }
                patient.Weight = txtWeight.Text;
                patient.Nationality = txtNationality.Text;


                patient.InputDate = AdmissionDate.Value;

                DateTime dt = AdmissionTime.Value;
                TimeSpan st = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                patient.AdmissionTime = st;

                patient.DutyDoctorId = cmbDutydoctor.SelectedValue.ToString();
                //patient.Doctor = comPrimaryDoctor.Text;
                patient.RefferedBy = cmbRefferBy.Tag.ToString(); 
                patient.RegNo = txtReg.Text;

                service.OPID = txtOpid.Text;
                service.ServiceId = "I-Serv-01";
                service.Rate = Convert.ToDouble(txtRegFf.Text);
                service.Total = Convert.ToDouble(txtRegFf.Text);
                service.Qty = 1;
                service.IssueDate = AdmissionDate.Value;
                service.Catgory = "Hospital";
                

                MessageModel message = new IpdManager().SaveIpdPatient(patient, service, aOutdoorPatient);
                if (message.MessageTitle == "Successful")
                {
                    MetroFramework.MetroMessageBox.Show(this, message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                    GetAllIpdPatient();
                    LoadData();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }}
            catch (Exception)
            {
                
                //throw;
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                 if (string.IsNullOrEmpty(pidSearchLookUpEdit.Properties.NullValuePrompt))
            {
                MetroFramework.MetroMessageBox.Show(this, "Patient not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "Are you sure to delete row?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                Patient aPatient = new Patient();
                //aPatient.OPID = pidSearchLookUpEdit.Properties.NullValuePrompt;
                aPatient.OPID = txtOpid.Text;

                MessageModel message = new IpdManager().DeleteAdmitedPatient(aPatient);
                MetroFramework.MetroMessageBox.Show(this, message.MessageTitle, message.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refresh();
                GetAllIpdPatient();
                LoadData();
            }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        private void chkCabin_CheckedChanged(object sender, EventArgs e)
        {
            //WardOrCabin();
           
        }
        private void btnNew_Click_1(object sender, EventArgs e)
        {
            Refresh();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.Model.OutdoorPatient aOutdoorPatient = new DAL.Model.OutdoorPatient();
                aOutdoorPatient.Opid = txtOpid.Text;
                aOutdoorPatient.ServiceDate = AdmissionDate.Value;
                aOutdoorPatient.TreatementType = "IPD";
                aOutdoorPatient.PatientName = txtName.Text;
                aOutdoorPatient.GurdianName = txtGurdian.Text;
                aOutdoorPatient.Address = txtAddress.Text;
                aOutdoorPatient.Age = Convert.ToInt32(txtAge.Text);
                aOutdoorPatient.Phone = txtPhone.Text;
                aOutdoorPatient.Mobile = txtPhone.Text;
                aOutdoorPatient.Nationality = txtNationality.Text;
                //aOutdoorPatient.Doctor = comPrimaryDoctor.Text;
                aOutdoorPatient.Fees = txtRegFf.Text;
                aOutdoorPatient.ContactPerson = txtGurdian.Text;

                aOutdoorPatient.Gender = cmbGender.Text;
                if (cmbbloodGroup.Text == "A+" || cmbbloodGroup.Text == "A-" || cmbbloodGroup.Text == "AB+" || cmbbloodGroup.Text == "AB-" || cmbbloodGroup.Text == "B+" || cmbbloodGroup.Text == "B-" || cmbbloodGroup.Text == "O+" || cmbbloodGroup.Text == "O-" || cmbbloodGroup.Text == "N/A")
                {
                    aOutdoorPatient.BloodGroup = cmbbloodGroup.Text;
                }

                Patient patient = new Patient();
                patient.OPID = txtOpid.Text;
                patient.PatientName = txtName.Text;
                patient.FatherName = txtFatherName.Text;
                patient.MotherName = txtMother.Text;
                patient.Address = txtAddress.Text;
                patient.Age = txtAge.Text;
                patient.Mobile = txtPhone.Text;
                patient.Gurdian = txtGurdian.Text;
                patient.Phone = txtPhone.Text;
                patient.Area = cmbArea.Text;
                patient.Gender = cmbGender.Text;
                patient.BloodGroup = cmbbloodGroup.Text;
                patient.Religion = cmbReligion.Text;
                patient.RefferedBy = cmbRefferBy.Tag.ToString();
                patient.Department = cmbDepartment.Text;
                patient.Weight = txtWeight.Text;
                patient.Nationality = txtNationality.Text;
                patient.InputDate = AdmissionDate.Value;
                DateTime dt = AdmissionTime.Value;
                TimeSpan st = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                patient.AdmissionTime = st;patient.DutyDoctorId = cmbDutydoctor.SelectedValue.ToString();
                patient.Doctor = txtPrimaryDoctor.Text;

                MessageModel message = new IpdManager().UpdateAdmissionPatient(patient, aOutdoorPatient);
                if (message.MessageTitle == "Successfull")
                {
                    MetroFramework.MetroMessageBox.Show(this, message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                    GetAllIpdPatient();
                    LoadData();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, message.MessageTitle, message.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
             //throw;
            }
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                xtraTabPage1.Show();
                flag = true;
                GetAllCabinUpdate();
                txtOpid.Text = gridView1.GetFocusedRowCellValue("OPID").ToString();
                AdmissionDate.Text = gridView1.GetFocusedRowCellValue("InputDate").ToString();
                AdmissionTime.Text = gridView1.GetFocusedRowCellValue("AdmissionTime").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("PatientName").ToString();
                txtFatherName.Text = gridView1.GetFocusedRowCellValue("FatherName").ToString();
                txtMother.Text = gridView1.GetFocusedRowCellValue("MotherName").ToString();
                txtAddress.Text = gridView1.GetFocusedRowCellValue("Address").ToString();
                txtAge.Text = gridView1.GetFocusedRowCellValue("Age").ToString();
                txtPhone.Text = gridView1.GetFocusedRowCellValue("Phone").ToString();
                txtGurdian.Text = gridView1.GetFocusedRowCellValue("Gurdian").ToString();
                txtRelation.Text = gridView1.GetFocusedRowCellValue("Relation").ToString();
                txtNationality.Text = gridView1.GetFocusedRowCellValue("Nationality").ToString();
                cmbRefferBy.Text = gridView1.GetFocusedRowCellValue("RefferedBy").ToString();
                //comPrimaryDoctor.Text = gridView1.GetFocusedRowCellValue("Doctor").ToString();
                txtPatientCondition.Text = gridView1.GetFocusedRowCellValue("paitentConditon").ToString();
                cmbDepartment.Text = gridView1.GetFocusedRowCellValue("Department").ToString();
                cmbDutydoctor.SelectedValue = gridView1.GetFocusedRowCellValue("DutyDoctorId").ToString();
                cmbGender.Text = gridView1.GetFocusedRowCellValue("Gender").ToString();
                cmbbloodGroup.Text = gridView1.GetFocusedRowCellValue("BloodGroup").ToString();
                txtWeight.Text = gridView1.GetFocusedRowCellValue("Weight").ToString();
                cmbReligion.Text = gridView1.GetFocusedRowCellValue("Religion").ToString();
                cmbwardCabin.Text = gridView1.GetFocusedRowCellValue("WardOrCabin").ToString();
                txtseletedBed.Text = gridView1.GetFocusedRowCellValue("SelectedBed").ToString();
                txtReg.Text = gridView1.GetFocusedRowCellValue("RegNo").ToString();
                cmbMaritalStatus.Text = gridView1.GetFocusedRowCellValue("MaritalStatus").ToString();
                cmbwardCabin.Text = gridView1.GetFocusedRowCellValue("BedName").ToString();
                cmbArea.Text = gridView1.GetFocusedRowCellValue("Area").ToString();
                
                pidSearchLookUpEdit.Enabled = false;



                _session.ChkPermission(MainWindow.userName);
                if (_session.EditPermission == true && _session.DeletePermission == true)
                {
                    buttonEnable(false);
                }
                if (_session.EditPermission == true && _session.DeletePermission == false)
                {buttonEnable(false);
                    btnDelete.Enabled = _session.DeletePermission;
                }
                if (_session.EditPermission == false && _session.DeletePermission == true)
                {
                    buttonEnable(false);
                    btnEdit.Enabled = _session.EditPermission;
                }
                if (_session.EditPermission == false && _session.DeletePermission == false)
                {
                    buttonEnable(true);
                    btnSave.Enabled = false;
                }



                //for test only

                btnEdit.Enabled = true;

                //for test only
            }
            catch (Exception ex)
            {
                new MailServer.MailServerConnection().SentMail(ex.GetBaseException().ToString());

            }

        }
        private void cmbWardorCabin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkFreeOccupied();
            GetBadorCabin();
        }
        private void rdOccupied_CheckedChanged(object sender, EventArgs e)
        {
            ChkFreeOccupied();
            GetBadorCabin();}
        private bool flag = false;
        public object id;
        private object OpId;
        public void pidSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            id = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtName.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
            cmbGender.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Gender").ToString();
            txtAge.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Age").ToString();
            txtAddress.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Address").ToString();
            cmbbloodGroup.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("BloodGroup").ToString();
            txtPhone.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Phone").ToString();
            txtNationality.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("Nationality").ToString();
            //comPrimaryDoctor.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("DoctorName").ToString();
            txtOpid.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtPrimaryDoctor.Text = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("DoctorName").ToString();


            //comPrimaryDoctor.DisplayMember = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("DoctorName").ToString();
            //comPrimaryDoctor.ValueMember = pidSearchLookUpEdit.Properties.View.GetFocusedRowCellValue("DoctorID").ToString();




            //GenerateReg();
            txtFatherName.Clear();
            txtMother.Clear();
            txtWeight.Clear();
            txtGurdian.Clear();
            txtRelation.Clear();
             cmbRefferBy.Text = "";
            cmbDepartment.Clear();
            txtName.Focus();
        }



        #endregion
        //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   
        //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   //Focuse   
        #region
        private void focus(object sender, KeyPressEventArgs e, TextBox text, ComboBox cmb)
        {
            try
            {
                if (e.KeyChar == 13 && text != null)
                {
                    text.Focus();
                }
                else if (e.KeyChar == 13 && cmb != null)
                {
                    cmb.Focus();
                }
            }
            catch
            {
                //
            }
           
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtFatherName, null);
        }
        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtMother, null);
        }
        private void txtMother_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, cmbArea, null);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtGurdian.Focus();
            }
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtPhone, null);
            CommonValidation.IsNumberCheck(sender, e);
        }


        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonValidation.IsNumberCheck(sender, e);

           focus(sender, null, null, cmbMaritalStatus);
        }
        private void txtGurdian_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtRelation, null);
        }
        private void txtRelation_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtAge, null);
        }
        private void txtNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            //focus(sender, e, txtWeight, null);
        }
        private void cmbRefferBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, txtPatientCondition, null);
        }
        private void cmbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, null, cmbDutydoctor);
        }
        private void txtPinformation_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, cmbDepartment, null);
        }
        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, null, cmbReligion);
            CommonValidation.IsNumberCheck(sender, e);
        }
        private void cmbReligion_KeyPress(object sender, KeyPressEventArgs e)
        {
            focus(sender, e, null, cmbRefferBy);
        }

        #endregion

        private void chkWard_CheckedChanged(object sender, EventArgs e)
        {
            WardOrCabin();
        }
        private void rdFree_CheckedChanged(object sender, EventArgs e)
        {
            ChkFreeOccupied();
            GetBadorCabin();
        }

        private void btnAddReffered_Click(object sender, EventArgs e)
        {
            RefferedUi Form=new RefferedUi();
            Form.ShowDialog(this);
            GetRefferedInfo();

        }

        private void cmbRefferBy_SelectedValueChanged(object sender, EventArgs e)
        {
            //DataTable data = new DataTable();
            //data = new RefferedInfoManager().PopulateGridView();
            ////cmbRefferBy.DataSource = data;
            //cmbRefferBy.DisplayMember = "Name";
            //cmbRefferBy.ValueMember = "Id";

            //cmbRefferBy.AutoCompleteCustomSource =

        }

        private void cmbRefferBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (cmbRefferBy.Text == data.Rows[i][1].ToString())
                {
                    cmbRefferBy.Tag = data.Rows[i][0].ToString();
                }
            }
        }

        private void cmbDutydoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comPrimaryDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmitSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void IPAdmission_Shown(object sender, EventArgs e)
        {
            GetAllIpdPatient();
            GetIpdAllDoctor();
            GetAllCabin();
       
          //  LoadBeds();
            GeneratePatientId();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            PatitientInfo();
        }

        private void gridView1_DragObjectDrop(object sender, DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtGurdian.Text = txtFatherName.Text;
            }
            else
            {
                txtGurdian.Text = "";
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtGurdian.Text = txtMother.Text;
            }
            else
            {
                txtGurdian.Text = "";
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbMaritalStatus.Focus();
            }
        }

        private void cmbMaritalStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNationality.Focus();
            
            }
        }

        private void txtNationality_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
            }

        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbbloodGroup.Focus();
            }

        }

        private void cmbbloodGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeight.Focus();
            }

        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbReligion.Focus();
            }

        }

        private void cmbReligion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRefferBy.Focus();
            }
        }

        private void cmbRefferBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPatientCondition.Focus();
            }
        }

        private void comPrimaryDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPatientCondition.Focus();
            }
        }

        private void txtPatientCondition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDepartment.Focus();
            }
        }

        private void cmbDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDutydoctor.Focus();
            }
        }

        private void cmbDutydoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AdmissionDate.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AdmissionTime.Focus();
            }
        }

        private void dateTimeTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbwardCabin.Focus();
            }
        }

        private void cmbwardCabin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void picBoxAddRefferedBy_Click(object sender, EventArgs e)
        {
            RefferedUi Form = new RefferedUi();
            Form.ShowDialog(this);
            GetRefferedInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            PatitientInfo();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintAdmissionList();
        }
        public void PrintAdmissionList()
        {
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>
            {
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
                new ReportParameter("dtFrom",  FromDate.Text),new ReportParameter("dtTo",  ToDate.Text),
                
            };
            model.ReportDataSource.Name = "IpAdmissionDataSet";

            PatitientInfo();
            model.ReportDataSource.Value = Admission;

            model.ReportPath = "GHospital_Care.Report.rdlcipadmission.rdlc";
            model.Show(model, this);
        }

        private void cmbArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            PatitientInfo();}


        //public void GetPrimaryDoctor()
        //{


        //    //aRefferedInfoManager = new RefferedInfoManager();
        //    //DataTable dataTable = new DataTable();
        //    //dataTable = aRefferedInfoManager.PopulateGridView();
        //}











    }
}
