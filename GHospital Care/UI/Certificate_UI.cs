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
    public partial class Certificate_UI : Form
    {
        private BirthInfoManager aBirthInfoManager;
        private DeathInfoManager aDeathInfoManager;
        public Certificate_UI()
        {
            InitializeComponent();
            aBirthInfoManager = new BirthInfoManager();
            aDeathInfoManager = new DeathInfoManager();

            btnDelete.Enabled = false;
        }

        public void LoadOpInfo()
        {
            searchLookUpOpInfo.Properties.DataSource = aBirthInfoManager.GetOpInfo();
        }
        public void RefreshBirthInfo()
        {
            txtOpId.Text = "";
            txtName.Text = "";
            dateTimeDateOfBirth.Value = DateTime.Now;
            dateTimeBirthTime.Text = "";
            dateTimeIssueDate.Value = DateTime.Now;
            txtBirthRegNo.Text = "";                         //cmbGender.Text = "";
            cmbGender.Text = "Male";
            txtNationality.Text = "Bangladeshi";txtFathersName.Text = "";
            txtMothersName.Text = "";
            txtFathersNationality.Text = "Bangladeshi";
            txtMothersNationality.Text = "Bangladeshi";
            txtPresentAddress.Text = "";
            txtPermanentAddress.Text = "";
            lblId.Text = "";
            txtWeight.Text = "";
            txtHeight.Text = "";
            txtCabinBed.Text = "";
            txtTypeOfDelivery.Text = "";
            
            GetBirthInfo();
            LoadOpInfo();
            btnSaveAndGenerate.Text = "Save and Generate Certificate";
            btnBirthInfoSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        public void RefreshDeathInfo()
        {
            txtDeathPatientID.Text = "";
            txtDeathName.Text = "";
            dateTimeDateOfDeath.Value = DateTime.Now;
            dateTimeDeathTime.Text = "";
            txtDeathFathersName.Text = "";
            cmbDeathMaritalStatus.Text = "";
            txtDeathPresentAddress.Text = "";
            dateTimeDeathIssueDate.Value = DateTime.Now;
            txtDeathRegNo.Text = "";
            cmbDeathGender.Text = "Male";
            txtDeathAge.Text = "";
            txtDeathNationality.Text = "Bangladeshi";
            txtDeathMothersName.Text = "";
            txtDeathSpouseName.Text = "";
            txtIntervalBetween.Text = "";
            lblId.Text = "";
            GetIndorPatientInfo();

            txtFloor.Text = "";
            txtCabin.Text = "";
            txtBed.Text = "";
            txtReligion.Text = "";
            dateOfAdmission.Text = "";
            txtIntervalBetween.Text = "";
            txtPlaceOfDeath.Text = "";
            txtDeathPermanentAddress.Text = "";
            
            GetDeathInfo();
            btnSaveAndGenerate.Text = "Save and Generate Certificate";
            btnBirthInfoSave.Text = "Save";
            btnDelete.Enabled = false;

        }
        public void GetDeathInfo()
        {
            gridControlDeath.DataSource = aDeathInfoManager.GetDeathInfo();
        }
        public void SaveAndUpdateBirthInfo()
        {
            if (xtraTabControl1.SelectedTabPage == TabBirthInfo)
            {
                MessageModel aMessageModel = new MessageModel();
                BirthInfo aBirthInfo = new BirthInfo();
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    aBirthInfo.Id = Convert.ToInt32(lblId.Text);
                }
                aBirthInfo.OPID = txtOpId.Text;
                aBirthInfo.Name = txtName.Text;
                aBirthInfo.DateOfBirth = dateTimeDateOfBirth.Value;
                aBirthInfo.BirthTime = dateTimeBirthTime.Text;
                aBirthInfo.Weight = txtWeight.Text;
                aBirthInfo.Height = txtHeight.Text;
                aBirthInfo.IssueDate = dateTimeIssueDate.Value;
                aBirthInfo.BirthRegNo = txtBirthRegNo.Text;
                aBirthInfo.Gender = cmbGender.SelectedText;
                aBirthInfo.Nationality = txtNationality.Text;
                aBirthInfo.FathersName = txtFathersName.Text;
                aBirthInfo.MothersName = txtMothersName.Text;
                aBirthInfo.FathersNationality = txtFathersNationality.Text;
                aBirthInfo.MothersNationality = txtMothersNationality.Text;
                aBirthInfo.PresentAddress = txtPresentAddress.Text;
                aBirthInfo.PermanentAddress = txtPermanentAddress.Text;
                aBirthInfo.UserId = lblUserId.Text;
                aBirthInfo.CabinBed = txtCabinBed.Text;
                aBirthInfo.TypeOfDelivery = txtTypeOfDelivery.Text;

                if (btnBirthInfoSave.Text == "Save")
                {
                    aBirthInfo.CreateDate = DateTime.Now;
                    aMessageModel = aBirthInfoManager.SaveBirthInfo(aBirthInfo);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        RefreshBirthInfo();
                    }
                    MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    aBirthInfo.UpdateDate = DateTime.Now;
                    aMessageModel = aBirthInfoManager.UpdateBirthInfo(aBirthInfo);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshBirthInfo();
                    }
                }
            }

            else if (xtraTabControl1.SelectedTabPage == TabDeathInfo)
            {
                DeathInfo aDeathInfo = new DeathInfo();
                aDeathInfo.DeathRegNo = txtDeathRegNo.Text;
                aDeathInfo.Name = txtDeathName.Text;
                aDeathInfo.IssueDate = dateTimeDeathIssueDate.Value;
                aDeathInfo.FathersName = txtDeathFathersName.Text;
                aDeathInfo.MothersName = txtDeathMothersName.Text;
                aDeathInfo.DateOfDeath = dateTimeDateOfDeath.Value;
                aDeathInfo.DeathTime = dateTimeDeathTime.Text;
                aDeathInfo.Gender = cmbGender.Text; aDeathInfo.MaritalStatus = cmbDeathMaritalStatus.Text;
                aDeathInfo.SpouseName = txtDeathSpouseName.Text;
                aDeathInfo.PresentAddress = txtDeathPresentAddress.Text;
                aDeathInfo.PermanentAddress = txtDeathPermanentAddress.Text;
                aDeathInfo.Nationality = txtNationality.Text;
                aDeathInfo.UserId = lblUserId.Text;
                aDeathInfo.Opid = txtDeathPatientID.Text;
                aDeathInfo.Age = txtDeathAge.Text;


                aDeathInfo.Floor = txtFloor.Text;
                aDeathInfo.Cabin = txtCabinBed.Text;
                aDeathInfo.Bed = txtBed.Text;
                aDeathInfo.Religion = txtReligion.Text;
                aDeathInfo.DateOfAdmission = dateOfAdmission.Value;
                aDeathInfo.IntervalBetween = txtIntervalBetween.Text;


                aDeathInfoManager = new DeathInfoManager();
                MessageModel aMessageModel = new MessageModel();
                if (btnBirthInfoSave.Text == "Save")
                {
                    aDeathInfo.CreateDate = DateTime.Now;
                    aMessageModel = aDeathInfoManager.SaveDeathInfo(aDeathInfo);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDeathInfo();
                    }
                }
                else
                {
                    aDeathInfo.UpdateDate = DateTime.Now;
                    aMessageModel = aDeathInfoManager.UpdateDeathInfo(aDeathInfo);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDeathInfo();
                    }
                }
            }
        }
        public void GetBirthInfo()
        {
            DataTable data = new DataTable();
            data = aBirthInfoManager.GetBirthInfo();
            gridControlBirthInfo.DataSource = data;
        }
        public void GetIndorPatientInfo()
        {
            aDeathInfoManager = new DeathInfoManager();
            searchLookUpOpInfoDeath.Properties.DataSource = aDeathInfoManager.GetIndorPatientInfo();
        }
        public void GenerateBirthRegID()
        {


        }
        
        private void Certificate_UI_Load(object sender, EventArgs e)
        {
            LoadOpInfo();
            GetBirthInfo();
            GetIndorPatientInfo();
            GetDeathInfo();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBirthInfo();
            RefreshDeathInfo();
        }

        private void btnBirthInfoSave_Click(object sender, EventArgs e)
        {
            SaveAndUpdateBirthInfo();
        }

        private void searchLookUpOpInfo_EditValueChanged(object sender, EventArgs e)
        {
            txtOpId.Text = searchLookUpOpInfo.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtMothersName.Text = searchLookUpOpInfo.Properties.View.GetFocusedRowCellValue("MothersName").ToString();
            txtPermanentAddress.Text = searchLookUpOpInfo.Properties.View.GetFocusedRowCellValue("PresentAddress").ToString();
            txtMothersNationality.Text = searchLookUpOpInfo.Properties.View.GetFocusedRowCellValue("MothersNationality").ToString();
            LoadOpInfo();

            btnDelete.Enabled = false;
        }

        private void gridViewBirthInfo_DoubleClick(object sender, EventArgs e)
        {
            txtOpId.Text = gridViewBirthInfo.GetFocusedRowCellValue("OPID").ToString();
            txtName.Text = gridViewBirthInfo.GetFocusedRowCellValue("Name").ToString();
            dateTimeDateOfBirth.Text = gridViewBirthInfo.GetFocusedRowCellValue("DateOfBirth").ToString();
            dateTimeBirthTime.Text = gridViewBirthInfo.GetFocusedRowCellValue("BirthTime").ToString();
            dateTimeIssueDate.Text = gridViewBirthInfo.GetFocusedRowCellValue("IssueDate").ToString();
            txtBirthRegNo.Text = gridViewBirthInfo.GetFocusedRowCellValue("BirthRegNo").ToString();
            cmbGender.SelectedText = gridViewBirthInfo.GetFocusedRowCellValue("Gender").ToString();
            txtNationality.Text = gridViewBirthInfo.GetFocusedRowCellValue("Nationality").ToString();
            txtFathersName.Text = gridViewBirthInfo.GetFocusedRowCellValue("FathersName").ToString();
            txtMothersName.Text = gridViewBirthInfo.GetFocusedRowCellValue("MothersName").ToString();
            txtFathersNationality.Text = gridViewBirthInfo.GetFocusedRowCellValue("FathersNationality").ToString();
            txtMothersNationality.Text = gridViewBirthInfo.GetFocusedRowCellValue("MothersNationality").ToString();
            txtPresentAddress.Text = gridViewBirthInfo.GetFocusedRowCellValue("PresentAddress").ToString();
            txtPermanentAddress.Text = gridViewBirthInfo.GetFocusedRowCellValue("PermanentAddress").ToString();
            lblId.Text = gridViewBirthInfo.GetFocusedRowCellValue("Id").ToString();

            btnBirthInfoSave.Text = "Update";
            btnSaveAndGenerate.Text = "Update and Generate Certificate";
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == TabBirthInfo)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message",
                MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    BirthInfo aBirthInfo = new BirthInfo();
                    aBirthInfo.Id = Convert.ToInt32(lblId.Text);
                    MessageModel aMessageModel = new MessageModel();
                    aMessageModel = aBirthInfoManager.DeleteBirthInfo(aBirthInfo);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshBirthInfo();
                    }
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message",
                MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    DeathInfo aDeathInfo = new DeathInfo();
                    aDeathInfo.Opid = txtDeathPatientID.Text;
                    MessageModel aMessageModel = new MessageModel();
                    aMessageModel = aDeathInfoManager.DeleteDeathInfo(aDeathInfo);
                    if (aMessageModel.MessageTitle == "Successfull")
                    {
                        MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDeathInfo();
                    }
                }
            }
        }

        private void searchLookUpOpInfoDeath_EditValueChanged(object sender, EventArgs e)
        {
            txtDeathPatientID.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("OPID").ToString();
            txtDeathName.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("PatientName").ToString();
            txtDeathPresentAddress.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("Address").ToString();
            txtIntervalBetween.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("Address").ToString();
            txtDeathNationality.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("Nationality").ToString();
            cmbDeathGender.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("Gender").ToString();
            txtDeathAge.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("Age").ToString();
            txtDeathFathersName.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("FatherName").ToString();
            txtDeathMothersName.Text = searchLookUpOpInfoDeath.Properties.View.GetFocusedRowCellValue("MotherName").ToString();

            btnDelete.Enabled = false;
        }

        private void cmbDeathMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeathMaritalStatus.Text != "Married")
            {
                txtDeathSpouseName.Text = "N/A";
            }
            else
            {
                txtDeathSpouseName.Text = "";
            }
        }

        private void gridViewDeathInfo_DoubleClick(object sender, EventArgs e)
        {
            txtDeathPatientID.Text = gridViewDeathInfo.GetFocusedRowCellValue("OPID").ToString();
            txtDeathRegNo.Text = gridViewDeathInfo.GetFocusedRowCellValue("DeathRegNo").ToString();
            txtDeathName.Text = gridViewDeathInfo.GetFocusedRowCellValue("Name").ToString();
            dateTimeDeathIssueDate.Text = gridViewDeathInfo.GetFocusedRowCellValue("IssueDate").ToString();
            txtDeathFathersName.Text = gridViewDeathInfo.GetFocusedRowCellValue("FathersName").ToString();
            txtDeathMothersName.Text = gridViewDeathInfo.GetFocusedRowCellValue("MothersName").ToString();
            dateTimeDateOfDeath.Text = gridViewDeathInfo.GetFocusedRowCellValue("DateOfDeath").ToString();
            dateTimeDeathTime.Text = gridViewDeathInfo.GetFocusedRowCellValue("DeathTime").ToString();
            cmbGender.Text = gridViewDeathInfo.GetFocusedRowCellValue("Gender").ToString();
            cmbDeathMaritalStatus.Text = gridViewDeathInfo.GetFocusedRowCellValue("MaritalStatus").ToString();
            txtDeathSpouseName.Text = gridViewDeathInfo.GetFocusedRowCellValue("SpouseName").ToString();
            txtDeathPresentAddress.Text = gridViewDeathInfo.GetFocusedRowCellValue("PresentAddress").ToString();
            txtIntervalBetween.Text = gridViewDeathInfo.GetFocusedRowCellValue("PermanentAddress").ToString();
            txtNationality.Text = gridViewDeathInfo.GetFocusedRowCellValue("Nationality").ToString();
            lblUserId.Text = gridViewDeathInfo.GetFocusedRowCellValue("UserId").ToString();
            lblId.Text = gridViewDeathInfo.GetFocusedRowCellValue("Id").ToString();
            txtDeathAge.Text = gridViewDeathInfo.GetFocusedRowCellValue("Age").ToString();

            btnBirthInfoSave.Text = "Update";
            btnSaveAndGenerate.Text = "Update and Generate Certificate";
            btnDelete.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
