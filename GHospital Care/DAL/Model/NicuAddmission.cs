using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class NicuAddmission
    {

        public int Id { get; set; }
        public string RegNo { get; set; }
        public DateTime DateofDischarge { get; set; }
        public DateTime AdmitDate { get; set; }
        public DateTimeOffset AdmitTime { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public string BabysBloodGroup { get; set; }
        public string Sex { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string ContactNo { get; set; }
        public string MotherAge { get; set; }
        public string FatherAge { get; set; }
        public string PatientName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOccupation { get; set; }
        public string Address { get; set; }
        public string RefferedInfo { get; set; }
        public string Remarks { get; set; }
        public string ComplaintsOne { get; set; }
        public string ComplaintsTwo { get; set; }
        public string ComplaintsThree { get; set; }public string ComplaintsFour { get; set; }
        public string ComplaintsFive { get; set; }
        public string MaternalHistory { get; set; }
        public string LSCS { get; set; }
        public string BadObstetricHistory { get; set; }
        public string Intrapartum { get; set; }
        public string DeliveryPlace { get; set; }
        public string Conduction { get; set; }
        public string AntenatalMode { get; set; }
        public string ColorOfLiqouo { get; set; }
        public string Drugs { get; set; }
        public string MothersBloodGroup { get; set; }
        public string MeconiumPassed { get; set; }
        public TimeSpan MeconiumPassedTime { get; set; }
        public string UrinePassed { get; set; }
        public TimeSpan UrinePassedTime { get; set; }
        public string Breathing { get; set; }
        public string Resuscitaion { get; set; }
        public string ResuscitaionMinute { get; set; }
        public string DelayedCrying { get; set; }
        public string NeonatalMods { get; set; }
        public string Medications { get; set; }
        public string MedicationInjParcent { get; set; }
        public string BirthWeight { get; set; }
        public string Length { get; set; }
        public string Ofc { get; set; }
        public string ApgerScoresAtOne { get; set; }
        public string ApgerScoresAtFive { get; set; }
        public string ApgerScoresAtTen { get; set; }
        public string Feeding { get; set; }
        public string FeedingType { get; set; }
        public string Activity { get; set; }
        public string Posture { get; set; }
        public string Cry { get; set; }
        public string Temp { get; set; }
        public string Skin { get; set; }
        public string RashSec { get; set; }
        public string HeadNeck { get; set; }
        public string SternoMastoidTumor { get; set; }
        public string AnteriorSize { get; set; }
        public string Tension { get; set; }
        public string PosteriorSize { get; set; }
        public string Face { get; set; }
        public string HeartSound { get; set; }
        public string RadioFemoralDelay { get; set; }
        public string Murmur { get; set; }
        public string Chest { get; set; }
        public string RrMin { get; set; }
        public string BreathSound { get; set; }
        public string AddedSound { get; set; }
        public string HeartRate { get; set; }
        public string Shape { get; set; }
        public string Distended { get; set; }
        public string Liver { get; set; }
        public string Sleen { get; set; }
        public string Kidney { get; set; }
        public string Umbilicus { get; set; }
        public string Scrotum { get; set; }
        public string Penis { get; set; }
        public string Testis { get; set; }
        public string LabiaMajora { get; set; }
        public string Minora { get; set; }
        public string Clitromegaly { get; set; }
        public string Anus { get; set; }
        public string BackSpine { get; set; }
        public string FootHand { get; set; }
        public string CNS { get; set; }
        public string JitterinessTone { get; set; }
        public string Moro { get; set; }
        public string Rooting { get; set; }
        public string Sucking { get; set; }
        public string Fractures { get; set; }
        public string NerveInjury { get; set; }
        public string SoftIssue { get; set; }
        public string Category { get; set; }
        public string GestationalAge { get; set; }
        public string CongenitalAnomalies { get; set; }
        public string ProvisionalDiagnosis { get; set; }
        public string SalientFeature { get; set; }
        public string FinalDiagnosis { get; set; }
        public string Bed { get; set; }
        public string AdmissionFee { get; set; }
        
    }
}
