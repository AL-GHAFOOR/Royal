using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BABInventory.forms;
using GHospital_Care.Accounts;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.DischargeUI;
using GHospital_Care.Doctors;
using GHospital_Care.IndoorPatient;
using GHospital_Care.NICU;
using GHospital_Care.Nurses;
using GHospital_Care.Operation;
using GHospital_Care.OutdoorPatient;using GHospital_Care.Session;
using GHospital_Care.Settings;
using GHospital_Care.UI;
using DischargeBill = GHospital_Care.IndoorPatient.DischargeBill;
using DoctorWisePatient_IP = GHospital_Care.IndoorPatient.DoctorWisePatient_IP;
using ComssionStauts = GHospital_Care.IndoorPatient.ComssionStauts;
using NICUDischargeRequest = GHospital_Care.NICU.NICUDischargeRequest;
using IPBillingSetup = GHospital_Care.IndoorPatient.IPBillingSetup;
using IPBusinessOffice = GHospital_Care.Operation.OTBusinessOffice;
using NICUBill = GHospital_Care.DischargeUI.NICUBill;
using OperationNote = GHospital_Care.Operation.OperationNote;

namespace GHospital_Care
{
    public partial class MainWindow : Form
    {
        Session.SessionData _Session = new GHospital_Care.Session.SessionData();
        public static string userName = string.Empty;
        public MainWindow(string UserName, string UserRole, UserMaster aUserMaster)
        {
            InitializeComponent();
            lblUserName.Text = UserName;
            lnkUserType.Text = UserRole;
            userName = lblUserName.Text;
            GeneralInfo.User = aUserMaster;
            SetUserRole();
            
        }
        Form masterForm;

        //public MainWindow()
        //{
        //    throw new NotImplementedException();
        //}

        private void loadUser()
        {
            
        }
        private void SetUserRole()
        {
            if (lnkUserType.Text == "Administrator")
            {
                mnuAccount.Enabled = true;
                mnuDoctor.Enabled = true;
                mnuEmployee.Enabled = true;
                mnuHospitalProfile.Enabled = true;
                mnuIP.Enabled = true;
                mnuNurses.Enabled = true;
                mnuOP.Enabled = true;
                mnuPathology.Enabled = true;
                mnuPharmacy.Enabled = true;
                mnuReports.Enabled = true;
                mnuUser.Enabled = true;

                return;
            }
            else if (lnkUserType.Text == @"Receiptionist")
            {
                mnuAccount.Enabled = false;
                mnuDoctor.Enabled = true;
                mnuEmployee.Enabled = false;
                mnuHospitalProfile.Enabled = false;
                mnuIP.Enabled = true;
                mnuNurses.Enabled = false;
                mnuOP.Enabled = true;
                mnuPathology.Enabled = true;
                mnuPharmacy.Enabled = false;
                mnuReports.Enabled = true;
                mnuUser.Enabled = false;

                return;
            }
            else if (lnkUserType.Text == @"Accountant")
            {
                mnuAccount.Enabled = true;
                mnuDoctor.Enabled = false;
                mnuEmployee.Enabled = false;
                mnuHospitalProfile.Enabled = false;
                mnuIP.Enabled = false;
                mnuNurses.Enabled = false;
                mnuOP.Enabled = false;
                mnuPathology.Enabled = false;
                mnuPharmacy.Enabled = false;
                mnuReports.Enabled = false;
                mnuUser.Enabled = false;

                return;
            }
            else if (lnkUserType.Text == @"Pathologist")
            {
                mnuAccount.Enabled = false;
                mnuDoctor.Enabled = false;
                mnuEmployee.Enabled = false;
                mnuHospitalProfile.Enabled = false;
                mnuIP.Enabled = false;
                mnuNurses.Enabled = false;
                mnuOP.Enabled = false;
                mnuPathology.Enabled = true;
                mnuPharmacy.Enabled = false;
                mnuReports.Enabled = false;
                mnuUser.Enabled = false;

                return;
            }
            else if (lnkUserType.Text == @"Doctor")
            {
            }
        }
        private void btnHomeTask_Click(object sender, EventArgs e)
        {
            Forms.HomeTask frm = new GHospital_Care.Forms.HomeTask();
            frm.MdiParent = this;
            frm.Show();
        }
        private void mnuHospitalProfile_Click(object sender, EventArgs e)
        {
            Settings.HospitalProfile frm = new GHospital_Care.Settings.HospitalProfile();
            frm.MdiParent = this;
            frm.Show();
        }
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo();
            frm.MdiParent = this;
            frm.Show();




        }
        private void wardSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.WardSetup frm = new UI.WardSetup();
            frm.MdiParent = this;
            frm.Show();
        }
        private void roomSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.RoomSetup frm = new GHospital_Care.Settings.RoomSetup();
            frm.MdiParent = this;
            frm.Show();
        }
        private void departmentSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Departments frm = new GHospital_Care.Settings.Departments();
            frm.MdiParent = this;
            frm.Show();
        }
        private void deseaseSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Deseases frm = new GHospital_Care.Settings.Deseases();
            frm.MdiParent = this;
            frm.Show();
        }
        private void bedSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.BedSetup2 frm = new BedSetup2();
            frm.MdiParent = this;
            frm.Show();
        }
        private void patientInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OutdoorPatient.OutdoorPatientUi frm = new GHospital_Care.OutdoorPatient.OutdoorPatientUi();
            frm.MdiParent = this;frm.Show();}
        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutdoorPatient.OPBILL frm = new GHospital_Care.OutdoorPatient.OPBILL();
            frm.MdiParent = this;
            frm.Show();
        }
        private void doctorSpecializationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.DoctorSpecialization frm = new GHospital_Care.Settings.DoctorSpecialization();
            frm.MdiParent = this;
            frm.Show();
        }
        private void doctorMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doctors.DoctorMaster frm = new GHospital_Care.Doctors.DoctorMaster();
            frm.MdiParent = this;
            frm.Show();
        }
        private void servicesSettingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ServiceSetup frm = new ServiceSetup();
            frm.MdiParent = this;
            frm.Show();
        }private void informationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutdoorPatient.OPInformationReport frm = new GHospital_Care.OutdoorPatient.OPInformationReport();
            frm.MdiParent = this;
            frm.Show();
        }
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Pathology.UrineExamine frm = new GHospital_Care.Pathology.UrineExamine();
            frm.MdiParent = this;
            frm.Show();
        }
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Pathology.StoolExam frm = new GHospital_Care.Pathology.StoolExam();
            frm.MdiParent = this;
            frm.Show();
        }
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Pathology.Ultrasongraphy frm = new GHospital_Care.Pathology.Ultrasongraphy();
            frm.MdiParent = this;
            frm.Show();
        }
        private void patientAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorPatient.IPAdmission frm = new GHospital_Care.IndoorPatient.IPAdmission();
            frm.MdiParent = this;
            frm.Show();

        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Logout frm = new GHospital_Care.Session.Logout(); frm.Show();
            this.Enabled = false;
        }
        private void labsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Labs frm = new GHospital_Care.Settings.Labs();
            frm.MdiParent = this;
            frm.Show();
        }
        private void doctorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doctors.DoctorList frm = new GHospital_Care.Doctors.DoctorList();
            frm.MdiParent = this;
            frm.Show();
        }
        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employees.EmployeeMaster frm = new GHospital_Care.Employees.EmployeeMaster();
            frm.MdiParent = this;
            frm.Show();
        }
        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employees.EmployeeList frm = new GHospital_Care.Employees.EmployeeList();
            frm.MdiParent = this;
            frm.Show();
        }
        private void salarySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employees.SalarySetup frm = new GHospital_Care.Employees.SalarySetup();
            frm.MdiParent = this;
            frm.Show();
        }
        private void salaryGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employees.SalaryGenerator frm = new GHospital_Care.Employees.SalaryGenerator();
            frm.MdiParent = this;
            frm.Show();
        }
        private void salarySheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employees.SalarySheet frm = new GHospital_Care.Employees.SalarySheet();
            frm.MdiParent = this;
            frm.Show();
        }
        private void oPListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutdoorPatient.OPServiceTreatment frm = new GHospital_Care.OutdoorPatient.OPServiceTreatment();
            frm.Show();
        }
        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            Pharmacy.Medicine frm = new GHospital_Care.Pharmacy.Medicine();
            frm.MdiParent = this;
            frm.Show();
        }
        private void accountSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.AccountSetup frm = new GHospital_Care.Accounts.AccountSetup();
            frm.MdiParent = this;
            frm.Show();
        }
        private void bankSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.BankSummary frm = new GHospital_Care.Accounts.BankSummary();
            frm.MdiParent = this;
            frm.Show();
        }
        private void dailyExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.VoucherEntry frm = new GHospital_Care.Accounts.VoucherEntry();
            frm.MdiParent = this;
            frm.Show();
        }
        private void pathologistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Pathologist frm = new GHospital_Care.Settings.Pathologist();
            frm.MdiParent = this;
            frm.Show();
        }
        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you really want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("You are unable to change password!", "Unable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void registerProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.Register frm = new GHospital_Care.Help.Register(this);
            frm.Show();
        }
        private void nurseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nurses.NurseInfo frm = new GHospital_Care.Nurses.NurseInfo();
            frm.MdiParent = this;
            frm.Show();
        }
        private void nurseSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {Nurses.NurseSalary frm = new GHospital_Care.Nurses.NurseSalary();
            frm.MdiParent = this;
            frm.Show();
        }private void nurseGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nurses.NurseGenerator frm = new GHospital_Care.Nurses.NurseGenerator();
            frm.MdiParent = this;
            frm.Show();
        }
        private void salarySheetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nurses.NurseSheet frm = new GHospital_Care.Nurses.NurseSheet();
            frm.MdiParent = this;
            frm.Show();
        }
        private void bedShiftmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorPatient.IPBedShiftment frm = new GHospital_Care.IndoorPatient.IPBedShiftment();
            frm.MdiParent = this;
            frm.Show();
        }
        private void dutyScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nurses.NurseDutySchedule frm = new GHospital_Care.Nurses.NurseDutySchedule();
            frm.MdiParent = this;
            frm.Show();
        }
        private void dutyByCommonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nurses.DutyByCommon frm = new GHospital_Care.Nurses.DutyByCommon();
            frm.MdiParent = this;
            frm.Show();
        }
        private void dutyByNurseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nurses.DutyByNurse frm = new GHospital_Care.Nurses.DutyByNurse();
            frm.MdiParent = this;
            frm.Show();
        }
        private void patientListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorPatient.IPList frm = new GHospital_Care.IndoorPatient.IPList();
            frm.MdiParent = this;
            frm.Show();
        }
        private void patientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoctorWisePatient_IP frm = new DoctorWisePatient_IP();
            frm.MdiParent = this;
            frm.Show();
        }
        private void dischargePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DischargeBill frm = new DischargeBill();
            frm.MdiParent = this;
            frm.Show();
        }
        private void medicalTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void recieveFromPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorPatient.PatientAmountReceive frm = new GHospital_Care.IndoorPatient.PatientAmountReceive();
            frm.MdiParent = this;
            frm.Show();
        }
        private void dailyVisitScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorPatient.IPBilling frm = new GHospital_Care.IndoorPatient.IPBilling();
            frm.MdiParent = this;
            frm.Show();
        }
        private void createDBBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.BackupDatabase frm = new GHospital_Care.Settings.BackupDatabase();
            frm.MdiParent = this;
            frm.Show();
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void oPListByDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutdoorPatient.OPDrWise frm = new GHospital_Care.OutdoorPatient.OPDrWise();
            frm.MdiParent = this;
            frm.Show();
        }
        private void subServiceSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMaster aMaster = new UserMaster();
            masterForm = new MainWindow("", "", aMaster);
            Settings.SubServiceSetup frm = new GHospital_Care.Settings.SubServiceSetup();
            frm.MdiParent = this;
            frm.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTitle.Left = lblTitle.Left - 1;
            //if (lblTitle.Left < -lblTitle.Width)
            //{
            //    lblTitle.Left = pnlTitle.Width;
            //}
        }
        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Session.Logout frm = new GHospital_Care.Session.Logout();
            frm.Show();
            this.Enabled = false;
        }
        private void contentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.Contents frm = new GHospital_Care.Help.Contents();
            frm.MdiParent = this;
            frm.Show();
        }
        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            Settings.UserManagment frm = new GHospital_Care.Settings.UserManagment();
            frm.MdiParent = this;
            frm.Show();
        }
        private void btnIP_Click(object sender, EventArgs e)
        {
            IndoorPatient.IPAdmission frm = new GHospital_Care.IndoorPatient.IPAdmission();
            frm.MdiParent = this;
            frm.Show();

        }
        private void btnOP_Click(object sender, EventArgs e)
        {
            OutdoorPatient.OutpatientBilling frm = new GHospital_Care.OutdoorPatient.OutpatientBilling("");
            frm.MdiParent = this;
            frm.Show();
        }
        private void bloodGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pathology.BloodGroupTest frm = new GHospital_Care.Pathology.BloodGroupTest();
            frm.MdiParent = this;
            frm.Show();
        }
        private void bloodTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pathology.BloodGroupTest frm = new GHospital_Care.Pathology.BloodGroupTest();
            frm.MdiParent = this;
            frm.Show();
        }
        private void serologicalTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pathology.SerologicalTest frm = new GHospital_Care.Pathology.SerologicalTest();
            frm.MdiParent = this;
            frm.Show();
        }
        private void febrilAntigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pathology.FebrilAntigen frm = new GHospital_Care.Pathology.FebrilAntigen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
           // Permission(GeneralInfo.User);
         AccessControl();

        }

        public void AccessControl()
        {
            List<UserMaster> GetAllPermission = new AccessPermissionGateway().AccessPermissionList(GeneralInfo.User.RoleId,GeneralInfo.User.ID).ToList();
            GlobalPermission.UserPermission = GetAllPermission;

            foreach (UserMaster userMaster in GetAllPermission)
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    foreach (object child in item.DropDownItems)
                    {
                        ToolStripMenuItem menuItem = child as ToolStripMenuItem;
                        if (menuItem!=null)
                        {
                            var permission = userMaster.Permission;
                            var Menu = userMaster.MenuName;

                            if (menuItem.Name == Menu && Convert.ToBoolean(permission))
                            {
                                menuItem.Visible = true;

                            }else if (menuItem.Name == Menu && Convert.ToBoolean(permission) == false)
                            {
                                menuItem.Visible = false;
                            }
                        }
                     
                           
                    }
                    }
                }
            }
           

        


        public void Permission(UserMaster user)
        {
            try
            {
                DataTable data = new DataTable();
                data = _Session.MenuCheck(user);


                for (int i = 0; i < data.Rows.Count; i++)
                {
                    foreach (ToolStripMenuItem item in menuStrip1.Items)
                    {
                        foreach (object children in item.DropDownItems)
                        {
                            ToolStripMenuItem menuItem = children as ToolStripMenuItem;

                            if (menuItem != null)
                            {
                                var permission = data.Rows[i][1].ToString();
                                var Menu = data.Rows[i][2].ToString();
                                if (menuItem.Name == Menu && Convert.ToBoolean(permission) == true)
                                {
                                    menuItem.Visible = true;
                                }
                                else if (menuItem.Name == Menu && Convert.ToBoolean(permission) == false)
                                {
                                    menuItem.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }





        private bool OpenForm(string formName)
        {
            bool stat = true;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    stat = true;
                }
                else
                {
                    stat = false;
                }
            }
            return stat;
        }

        private void cashbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cashbook frm = new Cashbook();
            // Pathology.FebrilAntigen frm = new GHospital_Care.Pathology.FebrilAntigen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void iPAdmissionBedHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorPatient.IPDAdmissionBedHistory frm = new GHospital_Care.IndoorPatient.IPDAdmissionBedHistory();
            frm.MdiParent = this;
            frm.Show();
        }

        private void wardCabinCatagorySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.WardCabinCategorySetup frm = new UI.WardCabinCategorySetup();
            frm.MdiParent = this;
            frm.Show();
        }

        private void iPBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPBillingSetup frm = new IPBillingSetup(iPBillingToolStripMenuItem.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void iPAllBillCheckingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorPatient.IPBusinessOffice frm = new IndoorPatient.IPBusinessOffice();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnOTSchedule_Click(object sender, EventArgs e)
        {
            Operation.Operation frm = new Operation.Operation(); 
            frm.MdiParent = this;
            frm.Show();
        }

        private void cabinSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CabinSetup cabinSetup = new CabinSetup();
            cabinSetup.MdiParent = this;
            cabinSetup.Show();
        }

        private void dischargePatientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DischargeUI.OperationNote DischargeForm = new   DischargeUI.OperationNote();
            DischargeForm.MdiParent = this;
            DischargeForm.Show();
        }

        private void iPCollecctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorCollection frm = new IndoorCollection();
            frm.MdiParent = this;
            frm.Show();



        }

        private void outDoorCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutDoorCollection frm = new OutDoorCollection();
            frm.MdiParent = this;
            frm.Show();
        }

        private void billGenerateIPOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPBillingSetup frm = new IPBillingSetup(billGenerateIPOPToolStripMenuItem.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void billCollectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IndoorPatient.PatientAmountReceive frm = new GHospital_Care.IndoorPatient.PatientAmountReceive();
            
                frm.MdiParent = this;
                frm.Show();
           
        }
        private void oPBillCheckingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OPBusinessOffice frm = new OPBusinessOffice();
            frm.MdiParent = this; frm.Show();
        }

        private void birthDeathCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Certificate_UI aCertificateUi = new Certificate_UI();
            aCertificateUi.MdiParent = this;
            aCertificateUi.Show();

        }

        private void addConsultantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultent_UI aConsultentUi = new Consultent_UI();
            aConsultentUi.MdiParent = this;
            aConsultentUi.Show();
        }

        private void addDiscountAuthorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiscountAuthorityUi aDiscountAuthorityUi = new DiscountAuthorityUi();
            aDiscountAuthorityUi.MdiParent = this;
            aDiscountAuthorityUi.Show();
        }

        private void oTBusinessofficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OTBusinessOffice otBusinessOffice = new OTBusinessOffice();
            otBusinessOffice.MdiParent = this;
            otBusinessOffice.Show();
        }

        private void operationScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operation.Operation Operation = new Operation.Operation();
            Operation.MdiParent = this;
            Operation.Show();
        }

        private void operationBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPBillingSetup OtBilling = new IPBillingSetup(operationBillToolStripMenuItem.Name);

            OtBilling.MdiParent = this;
            OtBilling.Show();
            OtBilling.tabControl1.TabPages.Remove(OtBilling.tabPage1);
            OtBilling.tabControl1.TabPages.Remove(OtBilling.tabPage3);
            OtBilling.tabControl1.TabPages.Remove(OtBilling.tabPage4); 
            OtBilling.tabControl1.TabPages.Remove(OtBilling.IssueMedicine);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {


        }

        private void menuPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BABInventory.forms.frmMenuPermission Operation = new BABInventory.forms.frmMenuPermission();
            Operation.MdiParent = this;
            Operation.Show();
        }

        private void followItemSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FollowUPSetup FollowUPSetup = new FollowUPSetup();
            FollowUPSetup.MdiParent = this;
            FollowUPSetup.Show();
        }

        private void followUPListSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FollowupListMaster FollowupListMaster = new FollowupListMaster();
            FollowupListMaster.MdiParent = this;
            FollowupListMaster.Show();
        }

        private void nICUBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NICUBill NicuBill = new NICUBill("");
            NicuBill.MdiParent = this;
            NicuBill.Show();
        }

        private void nICUAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NicuAdmissionUi NicuAdmission = new NicuAdmissionUi();
            NicuAdmission.MdiParent = this;
            NicuAdmission.Show();
           
        }

        private void dischargeBillNICUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NICUDischargeBill nicuDischarge = new NICUDischargeBill();
            nicuDischarge.MdiParent = this;
            nicuDischarge.Show();
            
        }

        private void createBillNICUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NICUBill NicuBill = new NICUBill("");
            NicuBill.MdiParent = this;
            NicuBill.Show();
        }

        private void createBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPBillingSetup frm = new IPBillingSetup(billGenerateIPOPToolStripMenuItem.Name);
            frm.MdiParent = this;
            frm.Show();
        }
        private void consultantServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NursePatientService frm = new NursePatientService(consultantServiceToolStripMenuItem.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void nICUBusinessOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NICUBusinessOffice frm = new NICUBusinessOffice();
            frm.MdiParent = this;
            frm.Show();
        }

        private void viewNICUCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NICUCollection frm = new NICUCollection();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cFFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultantCallUi frm = new ConsultantCallUi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nICUDischargeRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NICUDischargeRequest frm = new NICUDischargeRequest();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dueBillStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DueBillStatus frm = new DueBillStatus();
            frm.MdiParent = this;
            frm.Show();
        }

        private void payCommissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComssionStauts frm = new ComssionStauts();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pathologyPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
             PathologyStatus frm = new PathologyStatus();
            frm.MdiParent = this;
            frm.Show();
        }

        private void medicineIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineIndentUi frm = new MedicineIndentUi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuOP_Click(object sender, EventArgs e)
        {

        }

        private void dailyFollowupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndoorPatient.MedicalTreatment frm = new GHospital_Care.IndoorPatient.MedicalTreatment();
            frm.MdiParent = this;
            frm.Show();
        }

        }
}