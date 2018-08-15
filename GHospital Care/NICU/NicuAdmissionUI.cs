using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.UI
{
    public partial class NicuAdmissionUi : Form
    {
        public NicuAdmissionUi()
        {
            InitializeComponent();

        }

        public void GetNicuPatient()
        {
            NicuGridControl.DataSource = new NicuAdmissionManager().GetNicuPatient(FromDate.Value, ToDate.Value);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            NicuAddmission aNicuAddmission = new NicuAddmission();

            aNicuAddmission.Id = Convert.ToInt32(lblId.Text);
            aNicuAddmission.RegNo = txtRegNo.Text;
            string dateString = dateDischargeDate.Value.Date.ToString("yyyy MMMM dd");
            aNicuAddmission.DateofDischarge = Convert.ToDateTime(dateString);

            aNicuAddmission.AdmitDate = dateAdmitDate.Value;

            DateTimeOffset thisDate2 = new DateTimeOffset(dateAdmitTime.Value);
            aNicuAddmission.AdmitTime = thisDate2;

            aNicuAddmission.DateOfBirth = dateDateOfBirth.Value;
            aNicuAddmission.Age = txtAge.Text;
            aNicuAddmission.BabysBloodGroup = txtBabyBloodGroup.Text;
            aNicuAddmission.Sex = txtSex.Text;
            aNicuAddmission.MotherName = txtMothersName.Text;
            aNicuAddmission.FatherName = txtFathersName.Text;
            aNicuAddmission.MotherAge = txtMothersAge.Text;
            aNicuAddmission.FatherAge = txtFathersAge.Text;
            aNicuAddmission.ContactNo = txtContactNo.Text;

            aNicuAddmission.FatherOccupation = txtFathersOccupation.Text;
            aNicuAddmission.MotherOccupation = txtMothersOccupation.Text;
            aNicuAddmission.Address = txtAddress.Text;
            aNicuAddmission.RefferedInfo = txtRefferedInfo.Text;
            aNicuAddmission.Remarks = txtRemarks.Text;
            aNicuAddmission.ComplaintsOne = txtComplaintsOne.Text;
            aNicuAddmission.ComplaintsTwo = txtComplaintsTwo.Text;
            aNicuAddmission.ComplaintsThree = txtComplaintsThree.Text;
            aNicuAddmission.ComplaintsFour = txtComplaintsFour.Text;
            aNicuAddmission.ComplaintsFive = txtComplaintsFive.Text;
            aNicuAddmission.MaternalHistory = txtMaternalHistory.Text;
            aNicuAddmission.LSCS = checkLSCS.Checked ? "1" : "0";
            aNicuAddmission.BadObstetricHistory = checkBadObstetricHistory.Checked ? "1" : "0";
            aNicuAddmission.Intrapartum = cmbIntrapartum.Text;
            aNicuAddmission.DeliveryPlace = cmbDeliveryPlace.Text;
            aNicuAddmission.Conduction = cmbConduction.Text;
            aNicuAddmission.AntenatalMode = cmbAntenatalMode.Text;
            aNicuAddmission.ColorOfLiqouo = cmbColorOfLiqouo.Text;
            aNicuAddmission.Drugs = cmbDrugs.Text;
            aNicuAddmission.MothersBloodGroup = cmbMothersBloodGroup.Text;
            aNicuAddmission.MeconiumPassed = checkMeconiumPassed.Checked ? "1" : "0";

            DateTime meconiumPassedTime = dateMeconiumPassedTime.Value;
            TimeSpan meconiumPassedTimeSet = new TimeSpan(meconiumPassedTime.Hour, meconiumPassedTime.Minute, meconiumPassedTime.Second);
            aNicuAddmission.MeconiumPassedTime = meconiumPassedTimeSet;


            aNicuAddmission.UrinePassed = checkUrinePassed.Checked ? "1" : "0";

            DateTime urinePassedTime = dateUrinePassedTime.Value;
            TimeSpan urinePassedTimeSet = new TimeSpan(urinePassedTime.Hour, urinePassedTime.Minute, urinePassedTime.Second);
            aNicuAddmission.UrinePassedTime = urinePassedTimeSet;

            aNicuAddmission.Breathing = cmbBreathing.Text;
            aNicuAddmission.Resuscitaion = checkResuscitaion.Checked ? "1" : "0";
            aNicuAddmission.ResuscitaionMinute = txtResuscitaionMinute.Text;
            aNicuAddmission.DelayedCrying = checkDelayedCrying.Checked ? "1" : "0";
            aNicuAddmission.NeonatalMods = cmbNeonatalMods.Text;
            aNicuAddmission.Medications = cmbMedications.Text;
            aNicuAddmission.MedicationInjParcent = txtMedicationInjParcent.Text;
            aNicuAddmission.BirthWeight = txtBirthWeight.Text;
            aNicuAddmission.Length = txtLength.Text;
            aNicuAddmission.Ofc = txtOfc.Text;
            aNicuAddmission.ApgerScoresAtOne = txtApgerScoresAtOne.Text;
            aNicuAddmission.ApgerScoresAtFive = txtApgerScoresAtFive.Text;
            aNicuAddmission.ApgerScoresAtTen = txtApgerScoresAtTen.Text;
            aNicuAddmission.Feeding = checkFeeding.Checked ? "1" : "0";
            aNicuAddmission.FeedingType = cmbFeedingType.Text;
            aNicuAddmission.Activity = txtActivity.Text;
            aNicuAddmission.Posture = txtPosture.Text;
            aNicuAddmission.Cry = txtCry.Text;
            aNicuAddmission.Temp = txtTemp.Text;
            aNicuAddmission.Skin = cmbSkin.Text;
            aNicuAddmission.RashSec = txtRashSec.Text;
            aNicuAddmission.HeadNeck = cmbHeadNeck.Text;
            aNicuAddmission.SternoMastoidTumor = txtSternoMastoidTumor.Text;
            aNicuAddmission.AnteriorSize = txtAnteriorSize.Text;
            aNicuAddmission.Tension = txtTension.Text;
            aNicuAddmission.PosteriorSize = txtPosteriorSize.Text;
            aNicuAddmission.Face = cmbFace.Text;
            aNicuAddmission.HeartSound = txtHeartSound.Text;
            aNicuAddmission.RadioFemoralDelay = txtRadioFemoralDelay.Text;
            aNicuAddmission.Murmur = txtMurmur.Text;
            aNicuAddmission.Chest = cmbChest.Text;
            aNicuAddmission.RrMin = txtRRMin.Text;
            aNicuAddmission.BreathSound = txtBreathSound.Text;
            aNicuAddmission.AddedSound = txtAddedSound.Text;
            aNicuAddmission.HeartRate = txtHeartRate.Text;
            aNicuAddmission.Shape = checkShape.Checked ? "1" : "0";
            aNicuAddmission.Distended = checkDistended.Checked ? "1" : "0";
            aNicuAddmission.Liver = txtLiver.Text;
            aNicuAddmission.Sleen = txtSleen.Text;
            aNicuAddmission.Kidney = txtKidney.Text;
            aNicuAddmission.Umbilicus = txtUmbilicus.Text;
            aNicuAddmission.Scrotum = txtScrotum.Text;
            aNicuAddmission.Penis = txtPenis.Text;
            aNicuAddmission.Testis = cmbTestis.Text;
            aNicuAddmission.LabiaMajora = txtLabiaMajora.Text;
            aNicuAddmission.Minora = txtMinora.Text;
            aNicuAddmission.Clitromegaly = txtClitromegaly.Text;
            aNicuAddmission.Anus = cmbAnus.Text;
            aNicuAddmission.BackSpine = cmbBackSpine.Text;
            aNicuAddmission.FootHand = cmbFootHand.Text;
            aNicuAddmission.CNS = cmbCNS.Text;
            aNicuAddmission.JitterinessTone = cmbJitterinessTone.Text;
            aNicuAddmission.Moro = txtMoro.Text;
            aNicuAddmission.Rooting = txtRooting.Text;
            aNicuAddmission.Sucking = txtSucking.Text;
            aNicuAddmission.Fractures = txtFractures.Text;
            aNicuAddmission.NerveInjury = txtNerveInjury.Text;
            aNicuAddmission.SoftIssue = txtSoftIssue.Text;
            aNicuAddmission.Category = cmbCategory.Text;
            aNicuAddmission.GestationalAge = txtGestationalAge.Text;
            aNicuAddmission.CongenitalAnomalies = txtCongenitalAnomalies.Text;
            aNicuAddmission.ProvisionalDiagnosis = txtProvisionalDiagnosis.Text;
            aNicuAddmission.SalientFeature = txtSalientFeature.Text;
            aNicuAddmission.FinalDiagnosis = txtFinalDiagnosis.Text;

            if (cmbBed.Tag != null)
            {
                aNicuAddmission.Bed = cmbBed.Tag.ToString();
            }
            //New Added start 
            Service aService = new Service();
            aService.NicuRegNo = txtRegNo.Text;
            aService.ServiceId = "Serv-02";


            aService.Rate = Convert.ToDouble(txtAdmissionFee.Text);
            aService.Total = Convert.ToDouble(txtAdmissionFee.Text);


            aService.Qty = 1;
            aService.IssueDate = dateAdmitDate.Value;

            //New Added End  

            string actionType = btnSave.Text;

            NicuAdmissionManager aNicuAdmissionManager = new NicuAdmissionManager();

            MessageModel aMessageModel = new MessageModel();
            aMessageModel = aNicuAdmissionManager.SaveNicuAdmission(aNicuAddmission, actionType, aService);

            if (aMessageModel.MessageTitle == "Successfull")
            {
                MessageBox.Show(aMessageModel.MessageBody, aMessageModel.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }


        }

        public void Clear()
        {

            txtAdmissionFee.Text = "700.00"; 
            
            txtRegNo.Text = "";

            dateDischargeDate.Value = DateTime.Now.Date;
            dateAdmitDate.Value = DateTime.Now.Date;

            dateAdmitTime.Value = DateTime.Now;
            dateDateOfBirth.Value = DateTime.Now.Date;
            txtAge.Text = "";
            txtBabyBloodGroup.Text = "";
            txtSex.Text = "";
            txtMothersName.Text = "";
            txtFathersName.Text = "";
            txtMothersAge.Text = "";
            txtFathersAge.Text = "";
            txtFathersOccupation.Text = "";
            txtMothersOccupation.Text = "";
            txtAddress.Text = "";
            txtRefferedInfo.Text = "";
            txtRemarks.Text = "";
            txtComplaintsOne.Text = "";
            txtComplaintsTwo.Text = "";
            txtComplaintsThree.Text = "";
            txtComplaintsFour.Text = "";
            txtComplaintsFive.Text = "";
            txtMaternalHistory.Text = "";
            checkLSCS.Checked = false;
            checkBadObstetricHistory.Checked = false;
            cmbIntrapartum.Text = "";
            cmbDeliveryPlace.Text = "";
            cmbConduction.Text = "";
            cmbAntenatalMode.Text = "";
            cmbColorOfLiqouo.Text = "";
            cmbDrugs.Text = "";
            cmbMothersBloodGroup.Text = ""; checkMeconiumPassed.Checked = false; dateMeconiumPassedTime.Value = DateTime.Now;
            checkUrinePassed.Checked = false;
            dateUrinePassedTime.Value = DateTime.Now;
            cmbBreathing.Text = "";
            checkResuscitaion.Checked = false;
            txtResuscitaionMinute.Text = "";
            checkDelayedCrying.Checked = false;
            cmbNeonatalMods.Text = "";
            cmbMedications.Text = "";
            txtMedicationInjParcent.Text = "";
            txtBirthWeight.Text = "";
            txtLength.Text = "";
            txtOfc.Text = "";
            txtApgerScoresAtOne.Text = "";
            txtApgerScoresAtFive.Text = "";
            txtApgerScoresAtTen.Text = "";
            checkFeeding.Checked = false;
            cmbFeedingType.Text = "";
            txtActivity.Text = "";
            txtPosture.Text = "";
            txtCry.Text = "";
            txtTemp.Text = "";
            cmbSkin.Text = "";
            txtRashSec.Text = "";
            cmbHeadNeck.Text = "";
            txtSternoMastoidTumor.Text = "";
            txtAnteriorSize.Text = "";
            txtTension.Text = "";
            txtPosteriorSize.Text = "";
            cmbFace.Text = "";
            txtHeartSound.Text = "";
            txtRadioFemoralDelay.Text = "";
            txtMurmur.Text = "";
            cmbChest.Text = "";
            txtRRMin.Text = "";
            txtBreathSound.Text = "";
            txtAddedSound.Text = "";
            txtHeartRate.Text = "";
            checkShape.Checked = false;
            checkDistended.Checked = false;
            txtLiver.Text = "";
            txtSleen.Text = "";
            txtKidney.Text = "";
            txtUmbilicus.Text = "";
            txtScrotum.Text = "";
            txtPenis.Text = "";
            cmbTestis.Text = "";
            txtLabiaMajora.Text = "";
            txtMinora.Text = "";
            txtClitromegaly.Text = "";
            cmbAnus.Text = "";
            cmbBackSpine.Text = "";
            cmbFootHand.Text = "";
            cmbCNS.Text = "";
            cmbJitterinessTone.Text = "";
            txtMoro.Text = "";
            txtRooting.Text = "";
            txtSucking.Text = "";
            txtFractures.Text = "";
            txtNerveInjury.Text = "";
            txtSoftIssue.Text = "";
            cmbCategory.Text = "";
            txtGestationalAge.Text = "";
            txtCongenitalAnomalies.Text = "";
            txtProvisionalDiagnosis.Text = "";
            txtSalientFeature.Text = "";
            txtFinalDiagnosis.Text = "";
            txtContactNo.Text = "";


            GetNicuBed();

            GetNicuRegId();
            GetNicuPatient();
            xtraTabPage1.Show();
            btnDelete.Enabled = false;
            btnSave.Text = "Save";



        }



        DataTable bedData = new DataTable();
        public void GetNicuBed()
        {
            bedData = new NicuAdmissionManager().GetNicuBed();
            if (bedData.Rows.Count > 0)
            {
                cmbBed.DataSource = bedData;
                cmbBed.DisplayMember = "BedName";
                cmbBed.ValueMember = "BedId";
            }
        }


        private void label51_Click(object sender, EventArgs e)
        {

        }


        public void GetNicuRegId()
        {
            DataTable data = new DataTable();
            data = new NicuAdmissionManager().GetNicuRegId();

            if (data.Rows.Count > 0)
            {
                txtRegNo.Text = data.Rows[0]["RegNo"].ToString();
            }
        }
        private void NicuAdmissionUI_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            GetNicuRegId();
            GetNicuPatient();
            GetNicuBed();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void picBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                xtraTabPage2.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                xtraTabPage3.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                xtraTabPage4.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
            {
                xtraTabPage5.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage5)
            {
                xtraTabPage6.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage6)
            {
                xtraTabPage7.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage7)
            {
                xtraTabPage6.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage6)
            {
                xtraTabPage5.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage5)
            {
                xtraTabPage4.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
            {
                xtraTabPage3.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                xtraTabPage2.Show();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                xtraTabPage1.Show();
            }
        }

        private void picBoxSearch_Click(object sender, EventArgs e)
        {
            GetNicuPatient();
        }

        public void DefaultButtonSetting(bool Yes)
        {

        }

        private void NicuGridView_DoubleClick(object sender, EventArgs e)
        {
            xtraTabPage1.Show();
            lblId.Text = NicuGridView.GetFocusedRowCellValue("Id").ToString();
            txtRegNo.Text = NicuGridView.GetFocusedRowCellValue("RegNo").ToString();

            dateDischargeDate.Text = NicuGridView.GetFocusedRowCellValue("DateofDischarge").ToString();
            dateAdmitDate.Text = NicuGridView.GetFocusedRowCellValue("AdmitDate").ToString();
            dateAdmitTime.Text = NicuGridView.GetFocusedRowCellValue("AdmitTime").ToString();
            dateDateOfBirth.Text = NicuGridView.GetFocusedRowCellValue("DateOfBirth").ToString();
            txtAge.Text = NicuGridView.GetFocusedRowCellValue("Age").ToString();
            txtBabyBloodGroup.Text = NicuGridView.GetFocusedRowCellValue("BabysBloodGroup").ToString();

            txtSex.Text = NicuGridView.GetFocusedRowCellValue("Sex").ToString();
            txtMothersName.Text = NicuGridView.GetFocusedRowCellValue("MotherName").ToString();
            txtFathersName.Text = NicuGridView.GetFocusedRowCellValue("FatherName").ToString();
            txtMothersAge.Text = NicuGridView.GetFocusedRowCellValue("MotherAge").ToString();
            txtFathersAge.Text = NicuGridView.GetFocusedRowCellValue("FatherAge").ToString();
            txtFathersOccupation.Text = NicuGridView.GetFocusedRowCellValue("FatherOccupation").ToString();
            txtMothersOccupation.Text = NicuGridView.GetFocusedRowCellValue("MotherOccupation").ToString();
            txtContactNo.Text = NicuGridView.GetFocusedRowCellValue("ContactNo").ToString();
            txtAddress.Text = NicuGridView.GetFocusedRowCellValue("Address").ToString();
            txtRefferedInfo.Text = NicuGridView.GetFocusedRowCellValue("RefferedInfo").ToString();
            txtRemarks.Text = NicuGridView.GetFocusedRowCellValue("Remarks").ToString();
            txtComplaintsOne.Text = NicuGridView.GetFocusedRowCellValue("ComplaintsOne").ToString();
            txtComplaintsTwo.Text = NicuGridView.GetFocusedRowCellValue("ComplaintsTwo").ToString();
            txtComplaintsThree.Text = NicuGridView.GetFocusedRowCellValue("ComplaintsThree").ToString();
            txtComplaintsFour.Text = NicuGridView.GetFocusedRowCellValue("ComplaintsFour").ToString();
            txtComplaintsFive.Text = NicuGridView.GetFocusedRowCellValue("ComplaintsFive").ToString();
            txtMaternalHistory.Text = NicuGridView.GetFocusedRowCellValue("MaternalHistory").ToString();


            string checkLscs = NicuGridView.GetFocusedRowCellValue("LSCS").ToString();
            if (checkLscs == "1")
            {
                checkLSCS.Checked = true;
            }
            else
            {
                checkLSCS.Checked = false;
            }


            string ObstetricHistory = NicuGridView.GetFocusedRowCellValue("BadObstetricHistory").ToString();
            if (ObstetricHistory == "1")
            {
                checkBadObstetricHistory.Checked = true;
            }
            else
            {
                checkBadObstetricHistory.Checked = false;
            }
            cmbIntrapartum.Text = NicuGridView.GetFocusedRowCellValue("Intrapartum").ToString();
            cmbDeliveryPlace.Text = NicuGridView.GetFocusedRowCellValue("DeliveryPlace").ToString();
            cmbConduction.Text = NicuGridView.GetFocusedRowCellValue("Conduction").ToString();
            cmbAntenatalMode.Text = NicuGridView.GetFocusedRowCellValue("AntenatalMode").ToString();
            cmbColorOfLiqouo.Text = NicuGridView.GetFocusedRowCellValue("ColorOfLiqouo").ToString();
            cmbDrugs.Text = NicuGridView.GetFocusedRowCellValue("Drugs").ToString();
            cmbMothersBloodGroup.Text = NicuGridView.GetFocusedRowCellValue("MothersBloodGroup").ToString();

            string MeconiumPassed = NicuGridView.GetFocusedRowCellValue("MeconiumPassed").ToString();
            if (MeconiumPassed == "1")
            {
                checkMeconiumPassed.Checked = true;
            }
            else
            {
                checkMeconiumPassed.Checked = false;
            }

            dateMeconiumPassedTime.Text = NicuGridView.GetFocusedRowCellValue("MeconiumPassedTime").ToString();

            string UrinePassed = NicuGridView.GetFocusedRowCellValue("UrinePassed").ToString();

            if (UrinePassed == "1")
            {
                checkUrinePassed.Checked = true;
            }
            else
            {
                checkUrinePassed.Checked = false;
            }

            dateUrinePassedTime.Text = NicuGridView.GetFocusedRowCellValue("UrinePassedTime").ToString();
            cmbBreathing.Text = NicuGridView.GetFocusedRowCellValue("Breathing").ToString();

            string Resuscitaion = NicuGridView.GetFocusedRowCellValue("Resuscitaion").ToString();

            if (Resuscitaion == "1")
            {
                checkResuscitaion.Checked = true;
            }
            else
            {
                checkResuscitaion.Checked = false;
            }
            txtResuscitaionMinute.Text = NicuGridView.GetFocusedRowCellValue("ResuscitaionMinute").ToString();

            string DelayedCrying = NicuGridView.GetFocusedRowCellValue("DelayedCrying").ToString();
            if (DelayedCrying == "1")
            {
                checkDelayedCrying.Checked = true;
            }
            else
            {
                checkDelayedCrying.Checked = false;
            }
            cmbNeonatalMods.Text = NicuGridView.GetFocusedRowCellValue("NeonatalMods").ToString();
            cmbMedications.Text = NicuGridView.GetFocusedRowCellValue("Medications").ToString();
            txtMedicationInjParcent.Text = NicuGridView.GetFocusedRowCellValue("MedicationInjParcent").ToString();
            txtBirthWeight.Text = NicuGridView.GetFocusedRowCellValue("BirthWeight").ToString();
            txtLength.Text = NicuGridView.GetFocusedRowCellValue("Length").ToString();
            txtOfc.Text = NicuGridView.GetFocusedRowCellValue("Ofc").ToString();
            txtApgerScoresAtOne.Text = NicuGridView.GetFocusedRowCellValue("ApgerScoresAtOne").ToString();
            txtApgerScoresAtFive.Text = NicuGridView.GetFocusedRowCellValue("ApgerScoresAtFive").ToString();
            txtApgerScoresAtTen.Text = NicuGridView.GetFocusedRowCellValue("ApgerScoresAtTen").ToString();

            string Feeding = NicuGridView.GetFocusedRowCellValue("Feeding").ToString();
            if (Feeding == "1")
            {
                checkFeeding.Checked = true;
            }
            else
            {
                checkFeeding.Checked = false;
            }

            cmbFeedingType.Text = NicuGridView.GetFocusedRowCellValue("FeedingType").ToString();
            txtActivity.Text = NicuGridView.GetFocusedRowCellValue("Activity").ToString();
            txtPosture.Text = NicuGridView.GetFocusedRowCellValue("Posture").ToString();
            txtCry.Text = NicuGridView.GetFocusedRowCellValue("Cry").ToString();
            txtTemp.Text = NicuGridView.GetFocusedRowCellValue("Temp").ToString();
            cmbSkin.Text = NicuGridView.GetFocusedRowCellValue("Skin").ToString();
            txtRashSec.Text = NicuGridView.GetFocusedRowCellValue("RashSec").ToString();
            cmbHeadNeck.Text = NicuGridView.GetFocusedRowCellValue("HeadNeck").ToString();
            txtSternoMastoidTumor.Text = NicuGridView.GetFocusedRowCellValue("SternoMastoidTumor").ToString();
            txtAnteriorSize.Text = NicuGridView.GetFocusedRowCellValue("AnteriorSize").ToString();
            txtTension.Text = NicuGridView.GetFocusedRowCellValue("Tension").ToString();
            txtPosteriorSize.Text = NicuGridView.GetFocusedRowCellValue("PosteriorSize").ToString();
            cmbFace.Text = NicuGridView.GetFocusedRowCellValue("Face").ToString();
            txtHeartSound.Text = NicuGridView.GetFocusedRowCellValue("HeartSound").ToString();
            txtRadioFemoralDelay.Text = NicuGridView.GetFocusedRowCellValue("RadioFemoralDelay").ToString();
            txtMurmur.Text = NicuGridView.GetFocusedRowCellValue("Murmur").ToString();
            cmbChest.Text = NicuGridView.GetFocusedRowCellValue("Chest").ToString();
            txtRRMin.Text = NicuGridView.GetFocusedRowCellValue("RRMin").ToString();
            txtBreathSound.Text = NicuGridView.GetFocusedRowCellValue("BreathSound").ToString();
            txtAddedSound.Text = NicuGridView.GetFocusedRowCellValue("AddedSound").ToString();
            txtHeartRate.Text = NicuGridView.GetFocusedRowCellValue("HeartRate").ToString();

            string Shape = NicuGridView.GetFocusedRowCellValue("Shape").ToString();
            if (Shape == "1")
            {
                checkShape.Checked = true;
            }
            else
            {
                checkShape.Checked = false;
            }

            string Distended = NicuGridView.GetFocusedRowCellValue("Distended").ToString();
            if (Distended == "1")
            {
                checkDistended.Checked = true;
            }
            else
            {
                checkDistended.Checked = false;
            }

            txtLiver.Text = NicuGridView.GetFocusedRowCellValue("Liver").ToString();
            txtSleen.Text = NicuGridView.GetFocusedRowCellValue("Sleen").ToString();
            txtKidney.Text = NicuGridView.GetFocusedRowCellValue("Kidney").ToString();
            txtUmbilicus.Text = NicuGridView.GetFocusedRowCellValue("Umbilicus").ToString();
            txtScrotum.Text = NicuGridView.GetFocusedRowCellValue("Scrotum").ToString();
            txtPenis.Text = NicuGridView.GetFocusedRowCellValue("Penis").ToString();
            cmbTestis.Text = NicuGridView.GetFocusedRowCellValue("Testis").ToString();
            txtLabiaMajora.Text = NicuGridView.GetFocusedRowCellValue("LabiaMajora").ToString();
            txtMinora.Text = NicuGridView.GetFocusedRowCellValue("Minora").ToString();
            txtClitromegaly.Text = NicuGridView.GetFocusedRowCellValue("Clitromegaly").ToString();
            cmbAnus.Text = NicuGridView.GetFocusedRowCellValue("Anus").ToString();
            cmbBackSpine.Text = NicuGridView.GetFocusedRowCellValue("BackSpine").ToString();
            cmbFootHand.Text = NicuGridView.GetFocusedRowCellValue("FootHand").ToString();
            cmbCNS.Text = NicuGridView.GetFocusedRowCellValue("CNS").ToString();
            cmbJitterinessTone.Text = NicuGridView.GetFocusedRowCellValue("JitterinessTone").ToString();
            txtMoro.Text = NicuGridView.GetFocusedRowCellValue("Moro").ToString();
            txtRooting.Text = NicuGridView.GetFocusedRowCellValue("Rooting").ToString();
            txtSucking.Text = NicuGridView.GetFocusedRowCellValue("Sucking").ToString();
            txtFractures.Text = NicuGridView.GetFocusedRowCellValue("Fractures").ToString();
            txtNerveInjury.Text = NicuGridView.GetFocusedRowCellValue("NerveInjury").ToString();
            txtSoftIssue.Text = NicuGridView.GetFocusedRowCellValue("SoftIssue").ToString();
            cmbCategory.Text = NicuGridView.GetFocusedRowCellValue("Category").ToString(); ;
            txtGestationalAge.Text = NicuGridView.GetFocusedRowCellValue("GestationalAge").ToString();
            txtCongenitalAnomalies.Text = NicuGridView.GetFocusedRowCellValue("CongenitalAnomalies").ToString();
            txtProvisionalDiagnosis.Text = NicuGridView.GetFocusedRowCellValue("ProvisionalDiagnosis").ToString();
            txtSalientFeature.Text = NicuGridView.GetFocusedRowCellValue("SalientFeature").ToString();
            txtFinalDiagnosis.Text = NicuGridView.GetFocusedRowCellValue("FinalDiagnosis").ToString();
            txtAdmissionFee.Text = NicuGridView.GetFocusedRowCellValue("Total").ToString();



            //NIcuEditEnableWindowUI editEnable=new NIcuEditEnableWindowUI();

            //string myRegNo = NicuGridView.GetFocusedRowCellValue("AdmitDate").ToString();

            //DateTime date = new DateTime(Convert.myRegNo);
            //string formatted = date.ToString("dd/M/yyyy");

            //editEnable.lblRegNo.Text = NicuGridView.GetFocusedRowCellValue("RegNo").ToString();
            //editEnable.lblAdmitDate.Text = NicuGridView.GetFocusedRowCellValue("AdmitDate").ToString();
            //editEnable.lblDischargeDate.Text = NicuGridView.GetFocusedRowCellValue("DateofDischarge").ToString();
            //editEnable.lblBabyOf.Text = NicuGridView.GetFocusedRowCellValue("MotherName").ToString();
            //editEnable.lblId.Text = NicuGridView.GetFocusedRowCellValue("Id").ToString();

            //editEnable.ShowDialog();

            btnSave.Text = "Edit";
            btnDelete.Enabled = true;

        }


        public void InitializeAllField()
        {
            var myVariable = NicuGridView.GetFocusedRowCellValue("Id").ToString();
            //MessageBox.Show(myVariable);
            MessageBox.Show(myVariable);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "Do you want to delete this information?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                NicuAddmission aNicuAddmission = new NicuAddmission();
                aNicuAddmission.Id = Convert.ToInt32(lblId.Text);
                MessageModel aMessageModel = new NicuAdmissionManager().DeleteNicuPatient(aNicuAddmission);
                MessageBox.Show(aMessageModel.MessageTitle, aMessageModel.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
        }

        private void btnSave_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            GetNicuPatient();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            GetNicuPatient();
        }

        private void cmbBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < bedData.Rows.Count; i++)
            {
                if (cmbBed.Text == bedData.Rows[i][1].ToString())
                {
                    cmbBed.Tag = bedData.Rows[i][0].ToString();
                }
            }
        }
    }
}
