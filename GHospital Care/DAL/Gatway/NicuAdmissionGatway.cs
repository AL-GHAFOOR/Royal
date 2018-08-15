using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
//using Microsoft.ReportingServices.DataProcessing;

namespace GHospital_Care.DAL.Gatway
{
    public class NicuAdmissionGatway : GatwayConnection
    {


        public int SaveNicuAdmission(NicuAddmission aNicuAddmission, string actionType, Service service)
        {
            if (actionType == "Save")
            {
                Query = "INSERT INTO NicuAdmission(RegNo,DateofDischarge,AdmitDate,AdmitTime,DateOfBirth,Age,BabysBloodGroup,Sex," +
                      "MotherName,FatherName,ContactNo,MotherAge,FatherAge,FatherOccupation,MotherOccupation,Address," +
                      "RefferedInfo,Remarks,ComplaintsOne,ComplaintsTwo,ComplaintsThree,ComplaintsFour,ComplaintsFive," +
                      "MaternalHistory,LSCS,BadObstetricHistory,Intrapartum,DeliveryPlace,Conduction,AntenatalMode," +
                      "ColorOfLiqouo,Drugs,MothersBloodGroup,MeconiumPassed,MeconiumPassedTime,UrinePassed,UrinePassedTime," +
                      "Breathing,Resuscitaion,ResuscitaionMinute,DelayedCrying,NeonatalMods,Medications,MedicationInjParcent," +
                      "BirthWeight,Length,Ofc,ApgerScoresAtOne,ApgerScoresAtFive,ApgerScoresAtTen,Feeding,FeedingType,Activity," +
                      "Posture,Cry,Temp,Skin,RashSec,HeadNeck,SternoMastoidTumor,AnteriorSize,Tension,PosteriorSize,Face,HeartSound," +
                      "RadioFemoralDelay,Murmur,Chest,RRMin,BreathSound,AddedSound,HeartRate,Shape,Distended,Liver,Sleen,Kidney," +
                      "Umbilicus,Scrotum,Penis,Testis,LabiaMajora,Minora,Clitromegaly,Anus,BackSpine,FootHand,CNS,JitterinessTone," +
                      "Moro,Rooting,Sucking,Fractures,NerveInjury,SoftIssue,Category,GestationalAge,CongenitalAnomalies," +
                      "ProvisionalDiagnosis,SalientFeature,FinalDiagnosis,Bed)" +
                      "VALUES(@RegNo,@DateofDischarge,@AdmitDate,@AdmitTime,@DateOfBirth,@Age,@BabysBloodGroup,@Sex,@MotherName," +
                      "@FatherName,@ContactNo,@MotherAge,@FatherAge,@FatherOccupation,@MotherOccupation,@Address,@RefferedInfo," +
                      "@Remarks,@ComplaintsOne,@ComplaintsTwo,@ComplaintsThree,@ComplaintsFour,@ComplaintsFive,@MaternalHistory," +
                      "@LSCS,@BadObstetricHistory,@Intrapartum,@DeliveryPlace,@Conduction,@AntenatalMode,@ColorOfLiqouo,@Drugs," +
                      "@MothersBloodGroup,@MeconiumPassed,@MeconiumPassedTime,@UrinePassed,@UrinePassedTime,@Breathing," +
                      "@Resuscitaion,@ResuscitaionMinute,@DelayedCrying,@NeonatalMods,@Medications,@MedicationInjParcent," +
                      "@BirthWeight,@Length,@Ofc,@ApgerScoresAtOne,@ApgerScoresAtFive,@ApgerScoresAtTen,@Feeding,@FeedingType," +
                      "@Activity,@Posture,@Cry,@Temp,@Skin,@RashSec,@HeadNeck,@SternoMastoidTumor,@AnteriorSize,@Tension," +
                      "@PosteriorSize,@Face,@HeartSound,@RadioFemoralDelay,@Murmur,@Chest,@RRMin,@BreathSound,@AddedSound," +
                      "@HeartRate,@Shape,@Distended,@Liver,@Sleen,@Kidney,@Umbilicus,@Scrotum,@Penis,@Testis,@LabiaMajora,@Minora," +
                      "@Clitromegaly,@Anus,@BackSpine,@FootHand,@CNS,@JitterinessTone,@Moro,@Rooting,@Sucking,@Fractures," +
                      "@NerveInjury,@SoftIssue,@Category,@GestationalAge,@CongenitalAnomalies,@ProvisionalDiagnosis,@SalientFeature," +
                           "@FinalDiagnosis,@Bed)";
            }
            else if (actionType == "Edit")
            {
                Query = "UPDATE NicuAdmission SET RegNo=@RegNo,DateofDischarge=@DateofDischarge,AdmitDate=@AdmitDate," +
                        "AdmitTime=@AdmitTime,DateOfBirth=@DateOfBirth,Age=@Age, BabysBloodGroup=@BabysBloodGroup,Sex=@Sex," +
                        "MotherName=@MotherName,FatherName=@FatherName,ContactNo=@ContactNo,MotherAge=@MotherAge,FatherAge=@FatherAge," +
                        "FatherOccupation=@FatherOccupation, MotherOccupation = @MotherOccupation,Address=@Address," +
                        "RefferedInfo=@RefferedInfo,Remarks=@Remarks,ComplaintsOne=@ComplaintsOne,ComplaintsTwo=@ComplaintsTwo," +
                        "ComplaintsThree=@ComplaintsThree,ComplaintsFour=@ComplaintsFour,ComplaintsFive=@ComplaintsFive," +
                        "MaternalHistory=@MaternalHistory,LSCS=@LSCS,BadObstetricHistory=@BadObstetricHistory," +
                        "Intrapartum=@Intrapartum,DeliveryPlace=@DeliveryPlace,Conduction=@Conduction,AntenatalMode=@AntenatalMode," +
                        "ColorOfLiqouo=@ColorOfLiqouo,Drugs=@Drugs,MothersBloodGroup=@MothersBloodGroup,MeconiumPassed=@MeconiumPassed," +
                        "MeconiumPassedTime=@MeconiumPassedTime,UrinePassed=@UrinePassed,UrinePassedTime=@UrinePassedTime," +
                        "Breathing=@Breathing,Resuscitaion=@Resuscitaion, ResuscitaionMinute=@ResuscitaionMinute," +
                        "DelayedCrying=@DelayedCrying,NeonatalMods=@NeonatalMods,Medications=@Medications," +
                        "MedicationInjParcent =@MedicationInjParcent,BirthWeight=@BirthWeight,Length=@Length,Ofc=@Ofc," +
                        "ApgerScoresAtOne=@ApgerScoresAtOne,ApgerScoresAtFive=@ApgerScoresAtFive,ApgerScoresAtTen=@ApgerScoresAtTen," +
                        "Feeding=@Feeding,FeedingType=@FeedingType,Activity=@Activity,Posture=@Posture,Cry=@Cry,Temp=@Temp,Skin=@Skin," +
                        "RashSec=@RashSec,HeadNeck=@HeadNeck,SternoMastoidTumor=@SternoMastoidTumor,AnteriorSize=@AnteriorSize," +
                        "Tension=@Tension,PosteriorSize=@PosteriorSize,Face=@Face,HeartSound=@HeartSound,RadioFemoralDelay=@RadioFemoralDelay," +
                        "Murmur=@Murmur,Chest=@Chest,RRMin=@RRMin,BreathSound=@BreathSound,AddedSound=@AddedSound,HeartRate=@HeartRate," +
                        "Shape=@Shape,Distended=@Distended,Liver=@Liver,Sleen=@Sleen,Kidney=@Kidney,Umbilicus=@Umbilicus," +
                        "Scrotum=@Scrotum,Penis=@Penis,Testis=@Testis,LabiaMajora=@LabiaMajora,Minora=@Minora," +
                        "Clitromegaly=@Clitromegaly,Anus=@Anus,BackSpine=@BackSpine,FootHand=@FootHand,CNS=@CNS," +
                        "JitterinessTone=@JitterinessTone,Moro=@Moro,Rooting=@Rooting,Sucking=@Sucking,Fractures=@Fractures," +
                        "NerveInjury=@NerveInjury,SoftIssue=@SoftIssue,Category=@Category,GestationalAge=@GestationalAge," +
                        "CongenitalAnomalies=@CongenitalAnomalies,ProvisionalDiagnosis=@ProvisionalDiagnosis," +
                        "SalientFeature=@SalientFeature,FinalDiagnosis=@FinalDiagnosis,Bed=@Bed WHERE Id='" + aNicuAddmission.Id + "'";
            }

            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@RegNo", aNicuAddmission.RegNo ?? "");
            Command.Parameters.AddWithValue("@DateofDischarge", aNicuAddmission.DateofDischarge);
            Command.Parameters.AddWithValue("@AdmitDate", aNicuAddmission.AdmitDate);
            Command.Parameters.AddWithValue("@AdmitTime", aNicuAddmission.AdmitTime);
            Command.Parameters.AddWithValue("@DateOfBirth", aNicuAddmission.DateOfBirth);
            Command.Parameters.AddWithValue("@Age", aNicuAddmission.Age ?? "");
            Command.Parameters.AddWithValue("@BabysBloodGroup", aNicuAddmission.BabysBloodGroup ?? "");
            Command.Parameters.AddWithValue("@Sex", aNicuAddmission.Sex ?? "");
            Command.Parameters.AddWithValue("@MotherName", aNicuAddmission.MotherName ?? "");
            Command.Parameters.AddWithValue("@FatherName", aNicuAddmission.FatherName ?? "");
            Command.Parameters.AddWithValue("@ContactNo", aNicuAddmission.ContactNo ?? "");
            Command.Parameters.AddWithValue("@MotherAge", aNicuAddmission.MotherAge ?? "");
            Command.Parameters.AddWithValue("@FatherAge", aNicuAddmission.FatherAge ?? "");
            Command.Parameters.AddWithValue("@FatherOccupation", aNicuAddmission.FatherOccupation ?? "");
            Command.Parameters.AddWithValue("@MotherOccupation", aNicuAddmission.MotherOccupation ?? "");
            Command.Parameters.AddWithValue("@Address", aNicuAddmission.Address ?? "");
            Command.Parameters.AddWithValue("@RefferedInfo", aNicuAddmission.RefferedInfo ?? "");
            Command.Parameters.AddWithValue("@Remarks", aNicuAddmission.Remarks ?? "");
            Command.Parameters.AddWithValue("@ComplaintsOne", aNicuAddmission.ComplaintsOne ?? "");
            Command.Parameters.AddWithValue("@ComplaintsTwo", aNicuAddmission.ComplaintsTwo ?? "");
            Command.Parameters.AddWithValue("@ComplaintsThree", aNicuAddmission.ComplaintsThree ?? "");
            Command.Parameters.AddWithValue("@ComplaintsFour", aNicuAddmission.ComplaintsFour ?? "");
            Command.Parameters.AddWithValue("@ComplaintsFive", aNicuAddmission.ComplaintsFive ?? "");
            Command.Parameters.AddWithValue("@MaternalHistory", aNicuAddmission.MaternalHistory ?? "");
            Command.Parameters.AddWithValue("@LSCS", aNicuAddmission.LSCS ?? "");
            Command.Parameters.AddWithValue("@BadObstetricHistory", aNicuAddmission.BadObstetricHistory ?? "");
            Command.Parameters.AddWithValue("@Intrapartum", aNicuAddmission.Intrapartum ?? "");
            Command.Parameters.AddWithValue("@DeliveryPlace", aNicuAddmission.DeliveryPlace ?? "");
            Command.Parameters.AddWithValue("@Conduction", aNicuAddmission.Conduction ?? "");
            Command.Parameters.AddWithValue("@AntenatalMode", aNicuAddmission.AntenatalMode ?? "");
            Command.Parameters.AddWithValue("@ColorOfLiqouo", aNicuAddmission.ColorOfLiqouo ?? "");
            Command.Parameters.AddWithValue("@Drugs", aNicuAddmission.Drugs ?? "");
            Command.Parameters.AddWithValue("@MothersBloodGroup", aNicuAddmission.MothersBloodGroup ?? "");
            Command.Parameters.AddWithValue("@MeconiumPassed", aNicuAddmission.MeconiumPassed ?? "");
            Command.Parameters.AddWithValue("@MeconiumPassedTime", aNicuAddmission.MeconiumPassedTime);
            Command.Parameters.AddWithValue("@UrinePassed", aNicuAddmission.UrinePassed ?? "");
            Command.Parameters.AddWithValue("@UrinePassedTime", aNicuAddmission.UrinePassedTime);
            Command.Parameters.AddWithValue("@Breathing", aNicuAddmission.Breathing ?? "");
            Command.Parameters.AddWithValue("@Resuscitaion", aNicuAddmission.Resuscitaion ?? "");
            Command.Parameters.AddWithValue("@ResuscitaionMinute", aNicuAddmission.ResuscitaionMinute ?? "");
            Command.Parameters.AddWithValue("@DelayedCrying", aNicuAddmission.DelayedCrying ?? "");
            Command.Parameters.AddWithValue("@NeonatalMods", aNicuAddmission.NeonatalMods ?? "");
            Command.Parameters.AddWithValue("@Medications", aNicuAddmission.Medications ?? "");
            Command.Parameters.AddWithValue("@MedicationInjParcent", aNicuAddmission.MedicationInjParcent ?? "");
            Command.Parameters.AddWithValue("@BirthWeight", aNicuAddmission.BirthWeight ?? "");
            Command.Parameters.AddWithValue("@Length", aNicuAddmission.Length ?? "");
            Command.Parameters.AddWithValue("@Ofc", aNicuAddmission.Ofc ?? "");
            Command.Parameters.AddWithValue("@ApgerScoresAtOne", aNicuAddmission.ApgerScoresAtOne ?? "");
            Command.Parameters.AddWithValue("@ApgerScoresAtFive", aNicuAddmission.ApgerScoresAtFive ?? "");
            Command.Parameters.AddWithValue("@ApgerScoresAtTen", aNicuAddmission.ApgerScoresAtTen ?? "");
            Command.Parameters.AddWithValue("@Feeding", aNicuAddmission.Feeding ?? "");
            Command.Parameters.AddWithValue("@FeedingType", aNicuAddmission.FeedingType ?? "");
            Command.Parameters.AddWithValue("@Activity", aNicuAddmission.Activity ?? "");
            Command.Parameters.AddWithValue("@Posture", aNicuAddmission.Posture ?? "");
            Command.Parameters.AddWithValue("@Cry", aNicuAddmission.Cry ?? "");
            Command.Parameters.AddWithValue("@Temp", aNicuAddmission.Temp ?? "");
            Command.Parameters.AddWithValue("@Skin", aNicuAddmission.Skin ?? "");
            Command.Parameters.AddWithValue("@RashSec", aNicuAddmission.RashSec ?? "");
            Command.Parameters.AddWithValue("@HeadNeck", aNicuAddmission.HeadNeck ?? "");
            Command.Parameters.AddWithValue("@SternoMastoidTumor", aNicuAddmission.SternoMastoidTumor ?? "");
            Command.Parameters.AddWithValue("@AnteriorSize", aNicuAddmission.AnteriorSize ?? "");
            Command.Parameters.AddWithValue("@Tension", aNicuAddmission.Tension ?? "");
            Command.Parameters.AddWithValue("@PosteriorSize", aNicuAddmission.PosteriorSize ?? "");
            Command.Parameters.AddWithValue("@Face", aNicuAddmission.Face ?? "");
            Command.Parameters.AddWithValue("@HeartSound", aNicuAddmission.HeartSound ?? "");
            Command.Parameters.AddWithValue("@RadioFemoralDelay", aNicuAddmission.RadioFemoralDelay ?? "");
            Command.Parameters.AddWithValue("@Murmur", aNicuAddmission.Murmur ?? "");
            Command.Parameters.AddWithValue("@Chest", aNicuAddmission.Chest ?? "");
            Command.Parameters.AddWithValue("@RRMin", aNicuAddmission.RrMin ?? "");
            Command.Parameters.AddWithValue("@BreathSound", aNicuAddmission.BreathSound ?? "");
            Command.Parameters.AddWithValue("@AddedSound", aNicuAddmission.AddedSound ?? "");
            Command.Parameters.AddWithValue("@HeartRate", aNicuAddmission.HeartRate ?? "");
            Command.Parameters.AddWithValue("@Shape", aNicuAddmission.Shape ?? "");
            Command.Parameters.AddWithValue("@Distended", aNicuAddmission.Distended ?? "");
            Command.Parameters.AddWithValue("@Liver", aNicuAddmission.Liver ?? "");
            Command.Parameters.AddWithValue("@Sleen", aNicuAddmission.Sleen ?? "");
            Command.Parameters.AddWithValue("@Kidney", aNicuAddmission.Kidney ?? "");
            Command.Parameters.AddWithValue("@Umbilicus", aNicuAddmission.Umbilicus ?? "");
            Command.Parameters.AddWithValue("@Scrotum", aNicuAddmission.Scrotum ?? "");
            Command.Parameters.AddWithValue("@Penis", aNicuAddmission.Penis ?? "");
            Command.Parameters.AddWithValue("@Testis", aNicuAddmission.Testis ?? "");
            Command.Parameters.AddWithValue("@LabiaMajora", aNicuAddmission.LabiaMajora ?? "");
            Command.Parameters.AddWithValue("@Minora", aNicuAddmission.Minora ?? "");
            Command.Parameters.AddWithValue("@Clitromegaly", aNicuAddmission.Clitromegaly ?? "");
            Command.Parameters.AddWithValue("@Anus", aNicuAddmission.Anus ?? "");
            Command.Parameters.AddWithValue("@BackSpine", aNicuAddmission.BackSpine ?? "");
            Command.Parameters.AddWithValue("@FootHand", aNicuAddmission.FootHand ?? "");
            Command.Parameters.AddWithValue("@CNS", aNicuAddmission.CNS ?? "");
            Command.Parameters.AddWithValue("@JitterinessTone", aNicuAddmission.JitterinessTone ?? "");
            Command.Parameters.AddWithValue("@Moro", aNicuAddmission.Moro ?? "");
            Command.Parameters.AddWithValue("@Rooting", aNicuAddmission.Rooting ?? "");
            Command.Parameters.AddWithValue("@Sucking", aNicuAddmission.Sucking ?? "");
            Command.Parameters.AddWithValue("@Fractures", aNicuAddmission.Fractures ?? "");
            Command.Parameters.AddWithValue("@NerveInjury", aNicuAddmission.NerveInjury ?? "");
            Command.Parameters.AddWithValue("@SoftIssue", aNicuAddmission.SoftIssue ?? "");
            Command.Parameters.AddWithValue("@Category", aNicuAddmission.Category ?? "");
            Command.Parameters.AddWithValue("@GestationalAge", aNicuAddmission.GestationalAge ?? "");
            Command.Parameters.AddWithValue("@CongenitalAnomalies", aNicuAddmission.CongenitalAnomalies ?? "");
            Command.Parameters.AddWithValue("@ProvisionalDiagnosis", aNicuAddmission.ProvisionalDiagnosis ?? "");
            Command.Parameters.AddWithValue("@SalientFeature", aNicuAddmission.SalientFeature ?? "");
            Command.Parameters.AddWithValue("@FinalDiagnosis", aNicuAddmission.FinalDiagnosis ?? "");
            Command.Parameters.AddWithValue("@Bed", aNicuAddmission.Bed ?? "");



            int count = Command.ExecuteNonQuery();
            if (count > 0 && actionType == "Edit")
            {
                DeleteNicuRegNoTblPatientServiceBill(service);
                SaveNicuService(service);
                count++;
            }
            else if (actionType == "Save")
            {
                SaveNicuService(service);
                count++;
            }
            return count;
        }
        public int SaveNicuService(Service service)
        {

            int count = 0;
            Command = new SqlCommand("INSERT INTO dbo.tblPatientServiceBill (NicuRegNo,ServiceId,Rate,Qty,Total,userid,serviceDate)"
       + "VALUES(@NicuRegNo,@ServiceId,@Rate,@Qty,@Total,@userid,@serviceDate)", Connection);

            Command.CommandType = CommandType.Text;

            Command.Parameters.AddWithValue("@NicuRegNo", service.NicuRegNo);
            Command.Parameters.AddWithValue("@ServiceId", service.ServiceId);
            Command.Parameters.AddWithValue("@Rate", service.Rate);
            Command.Parameters.AddWithValue("@Total", service.Total);
            Command.Parameters.AddWithValue("@Qty", service.Qty);
            Command.Parameters.AddWithValue("@userid", "");
            Command.Parameters.AddWithValue("@serviceDate", service.IssueDate);
            count = Command.ExecuteNonQuery();

            return count;
        }
        
        public int DeleteNicuRegNoTblPatientServiceBill(Service service)
        {
            Query = "DELETE FROM tblPatientServiceBill WHERE NicuRegNo = '" + service.NicuRegNo + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

        public int DeleteNicuPatient(NicuAddmission aNicuAddmission)
        {
            Query = "DELETE FROM nicuadmission WHERE Id = '" + aNicuAddmission.Id + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }


        public DataTable GetNicuRegId()
        {
            Query = "SP_GENERATE_Reg_NicuAdmission";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader(); DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable GetNicuPatients(DateTime fromdate, DateTime ToDate)
        {
            Query = "SELECT * FROM ViewGetNicuPatient where Convert(date,AdmitDate) between '" + fromdate + "' and '" + ToDate + "' ORDER BY RegNo ASC";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }


        public DataTable GetNicuBed()
        {
            Query = "SELECT * FROM ViewAllBeds WHERE WardId='9' AND WardName='NICU'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }





        //public int SaveNicuAdmission(NicuAddmission aNicuAddmission, string actionType)
        //{
        //    if (actionType == "Save")
        //    {
        //        Query = "INSERT INTO NicuAdmission(RegNo,DateofDischarge,AdmitDate,AdmitTime,DateOfBirth,Age,BabysBloodGroup,Sex," +
        //           "MotherName,FatherName,ContactNo,MotherAge,FatherAge,FatherOccupation,MotherOccupation,Address," +
        //           "RefferedInfo,Remarks,ComplaintsOne,ComplaintsTwo,ComplaintsThree,ComplaintsFour,ComplaintsFive," +
        //           "MaternalHistory,LSCS,BadObstetricHistory,Intrapartum,DeliveryPlace,Conduction,AntenatalMode," +
        //           "ColorOfLiqouo,Drugs,MothersBloodGroup,MeconiumPassed,MeconiumPassedTime,UrinePassed,UrinePassedTime," +
        //           "Breathing,Resuscitaion,ResuscitaionMinute,DelayedCrying,NeonatalMods,Medications,MedicationInjParcent," +
        //           "BirthWeight,Length,Ofc,ApgerScoresAtOne,ApgerScoresAtFive,ApgerScoresAtTen,Feeding,FeedingType,Activity," +
        //           "Posture,Cry,Temp,Skin,RashSec,HeadNeck,SternoMastoidTumor,AnteriorSize,Tension,PosteriorSize,Face,HeartSound," +
        //           "RadioFemoralDelay,Murmur,Chest,RRMin,BreathSound,AddedSound,HeartRate,Shape,Distended,Liver,Sleen,Kidney," +
        //           "Umbilicus,Scrotum,Penis,Testis,LabiaMajora,Minora,Clitromegaly,Anus,BackSpine,FootHand,CNS,JitterinessTone," +
        //           "Moro,Rooting,Sucking,Fractures,NerveInjury,SoftIssue,Category,GestationalAge,CongenitalAnomalies," +
        //           "ProvisionalDiagnosis,SalientFeature,FinalDiagnosis,Bed,AdmissionFee)" +
        //           "VALUES(@RegNo,@DateofDischarge,@AdmitDate,@AdmitTime,@DateOfBirth,@Age,@BabysBloodGroup,@Sex,@MotherName," +
        //           "@FatherName,@ContactNo,@MotherAge,@FatherAge,@FatherOccupation,@MotherOccupation,@Address,@RefferedInfo," +
        //           "@Remarks,@ComplaintsOne,@ComplaintsTwo,@ComplaintsThree,@ComplaintsFour,@ComplaintsFive,@MaternalHistory," +
        //           "@LSCS,@BadObstetricHistory,@Intrapartum,@DeliveryPlace,@Conduction,@AntenatalMode,@ColorOfLiqouo,@Drugs," +
        //           "@MothersBloodGroup,@MeconiumPassed,@MeconiumPassedTime,@UrinePassed,@UrinePassedTime,@Breathing," +
        //           "@Resuscitaion,@ResuscitaionMinute,@DelayedCrying,@NeonatalMods,@Medications,@MedicationInjParcent," +
        //           "@BirthWeight,@Length,@Ofc,@ApgerScoresAtOne,@ApgerScoresAtFive,@ApgerScoresAtTen,@Feeding,@FeedingType," +
        //           "@Activity,@Posture,@Cry,@Temp,@Skin,@RashSec,@HeadNeck,@SternoMastoidTumor,@AnteriorSize,@Tension," +
        //           "@PosteriorSize,@Face,@HeartSound,@RadioFemoralDelay,@Murmur,@Chest,@RRMin,@BreathSound,@AddedSound," +
        //           "@HeartRate,@Shape,@Distended,@Liver,@Sleen,@Kidney,@Umbilicus,@Scrotum,@Penis,@Testis,@LabiaMajora,@Minora," +
        //           "@Clitromegaly,@Anus,@BackSpine,@FootHand,@CNS,@JitterinessTone,@Moro,@Rooting,@Sucking,@Fractures," +
        //           "@NerveInjury,@SoftIssue,@Category,@GestationalAge,@CongenitalAnomalies,@ProvisionalDiagnosis,@SalientFeature," +
        //                "@FinalDiagnosis,@Bed,@AdmissionFee)";
        //    }
        //    else if (actionType == "Edit")
        //    {
        //        Query = "UPDATE NicuAdmission SET RegNo=@RegNo,DateofDischarge=@DateofDischarge,AdmitDate=@AdmitDate," +
        //                "AdmitTime=@AdmitTime,DateOfBirth=@DateOfBirth,Age=@Age, BabysBloodGroup=@BabysBloodGroup,Sex=@Sex," +
        //                "MotherName=@MotherName,FatherName=@FatherName,ContactNo=@ContactNo,MotherAge=@MotherAge,FatherAge=@FatherAge," +
        //                "FatherOccupation=@FatherOccupation, MotherOccupation = @MotherOccupation,Address=@Address," +
        //                "RefferedInfo=@RefferedInfo,Remarks=@Remarks,ComplaintsOne=@ComplaintsOne,ComplaintsTwo=@ComplaintsTwo," +
        //                "ComplaintsThree=@ComplaintsThree,ComplaintsFour=@ComplaintsFour,ComplaintsFive=@ComplaintsFive," +
        //                "MaternalHistory=@MaternalHistory,LSCS=@LSCS,BadObstetricHistory=@BadObstetricHistory," +
        //                "Intrapartum=@Intrapartum,DeliveryPlace=@DeliveryPlace,Conduction=@Conduction,AntenatalMode=@AntenatalMode," +
        //                "ColorOfLiqouo=@ColorOfLiqouo,Drugs=@Drugs,MothersBloodGroup=@MothersBloodGroup,MeconiumPassed=@MeconiumPassed," +
        //                "MeconiumPassedTime=@MeconiumPassedTime,UrinePassed=@UrinePassed,UrinePassedTime=@UrinePassedTime," +
        //                "Breathing=@Breathing,Resuscitaion=@Resuscitaion, ResuscitaionMinute=@ResuscitaionMinute," +
        //                "DelayedCrying=@DelayedCrying,NeonatalMods=@NeonatalMods,Medications=@Medications," +
        //                "MedicationInjParcent =@MedicationInjParcent,BirthWeight=@BirthWeight,Length=@Length,Ofc=@Ofc," +
        //                "ApgerScoresAtOne=@ApgerScoresAtOne,ApgerScoresAtFive=@ApgerScoresAtFive,ApgerScoresAtTen=@ApgerScoresAtTen," +
        //                "Feeding=@Feeding,FeedingType=@FeedingType,Activity=@Activity,Posture=@Posture,Cry=@Cry,Temp=@Temp,Skin=@Skin," +
        //                "RashSec=@RashSec,HeadNeck=@HeadNeck,SternoMastoidTumor=@SternoMastoidTumor,AnteriorSize=@AnteriorSize," +
        //                "Tension=@Tension,PosteriorSize=@PosteriorSize,Face=@Face,HeartSound=@HeartSound,RadioFemoralDelay=@RadioFemoralDelay," +
        //                "Murmur=@Murmur,Chest=@Chest,RRMin=@RRMin,BreathSound=@BreathSound,AddedSound=@AddedSound,HeartRate=@HeartRate," +
        //                "Shape=@Shape,Distended=@Distended,Liver=@Liver,Sleen=@Sleen,Kidney=@Kidney,Umbilicus=@Umbilicus," +
        //                "Scrotum=@Scrotum,Penis=@Penis,Testis=@Testis,LabiaMajora=@LabiaMajora,Minora=@Minora," +
        //                "Clitromegaly=@Clitromegaly,Anus=@Anus,BackSpine=@BackSpine,FootHand=@FootHand,CNS=@CNS," +
        //                "JitterinessTone=@JitterinessTone,Moro=@Moro,Rooting=@Rooting,Sucking=@Sucking,Fractures=@Fractures," +
        //                "NerveInjury=@NerveInjury,SoftIssue=@SoftIssue,Category=@Category,GestationalAge=@GestationalAge," +
        //                "CongenitalAnomalies=@CongenitalAnomalies,ProvisionalDiagnosis=@ProvisionalDiagnosis," +
        //                "SalientFeature=@SalientFeature,FinalDiagnosis=@FinalDiagnosis,Bed=@Bed,AdmissionFee=@AdmissionFee WHERE Id='" + aNicuAddmission.Id + "'";
        //    }


           
        //    Command = new SqlCommand(Query, Connection);
        //    Command.CommandType = CommandType.Text;
        //    Command.Parameters.AddWithValue("@RegNo", aNicuAddmission.RegNo ?? "");
        //    Command.Parameters.AddWithValue("@DateofDischarge", aNicuAddmission.DateofDischarge);
        //    Command.Parameters.AddWithValue("@AdmitDate", aNicuAddmission.AdmitDate);
        //    Command.Parameters.AddWithValue("@AdmitTime", aNicuAddmission.AdmitTime);
        //    Command.Parameters.AddWithValue("@DateOfBirth", aNicuAddmission.DateOfBirth);
        //    Command.Parameters.AddWithValue("@Age", aNicuAddmission.Age ?? "");
        //    Command.Parameters.AddWithValue("@BabysBloodGroup", aNicuAddmission.BabysBloodGroup ?? "");
        //    Command.Parameters.AddWithValue("@Sex", aNicuAddmission.Sex ?? "");
        //    Command.Parameters.AddWithValue("@MotherName", aNicuAddmission.MotherName ?? "");
        //    Command.Parameters.AddWithValue("@FatherName", aNicuAddmission.FatherName ?? "");
        //    Command.Parameters.AddWithValue("@ContactNo", aNicuAddmission.ContactNo ?? "");
        //    Command.Parameters.AddWithValue("@MotherAge", aNicuAddmission.MotherAge ?? "");
        //    Command.Parameters.AddWithValue("@FatherAge", aNicuAddmission.FatherAge ?? "");
        //    Command.Parameters.AddWithValue("@FatherOccupation", aNicuAddmission.FatherOccupation ?? "");
        //    Command.Parameters.AddWithValue("@MotherOccupation", aNicuAddmission.MotherOccupation ?? "");
        //    Command.Parameters.AddWithValue("@Address", aNicuAddmission.Address ?? "");
        //    Command.Parameters.AddWithValue("@RefferedInfo", aNicuAddmission.RefferedInfo ?? "");
        //    Command.Parameters.AddWithValue("@Remarks", aNicuAddmission.Remarks ?? "");
        //    Command.Parameters.AddWithValue("@ComplaintsOne", aNicuAddmission.ComplaintsOne ?? "");
        //    Command.Parameters.AddWithValue("@ComplaintsTwo", aNicuAddmission.ComplaintsTwo ?? "");
        //    Command.Parameters.AddWithValue("@ComplaintsThree", aNicuAddmission.ComplaintsThree ?? "");
        //    Command.Parameters.AddWithValue("@ComplaintsFour", aNicuAddmission.ComplaintsFour ?? "");
        //    Command.Parameters.AddWithValue("@ComplaintsFive", aNicuAddmission.ComplaintsFive ?? "");
        //    Command.Parameters.AddWithValue("@MaternalHistory", aNicuAddmission.MaternalHistory ?? "");
        //    Command.Parameters.AddWithValue("@LSCS", aNicuAddmission.LSCS ?? "");
        //    Command.Parameters.AddWithValue("@BadObstetricHistory", aNicuAddmission.BadObstetricHistory ?? "");
        //    Command.Parameters.AddWithValue("@Intrapartum", aNicuAddmission.Intrapartum ?? "");
        //    Command.Parameters.AddWithValue("@DeliveryPlace", aNicuAddmission.DeliveryPlace ?? "");
        //    Command.Parameters.AddWithValue("@Conduction", aNicuAddmission.Conduction ?? "");
        //    Command.Parameters.AddWithValue("@AntenatalMode", aNicuAddmission.AntenatalMode ?? "");
        //    Command.Parameters.AddWithValue("@ColorOfLiqouo", aNicuAddmission.ColorOfLiqouo ?? "");
        //    Command.Parameters.AddWithValue("@Drugs", aNicuAddmission.Drugs ?? "");
        //    Command.Parameters.AddWithValue("@MothersBloodGroup", aNicuAddmission.MothersBloodGroup ?? "");
        //    Command.Parameters.AddWithValue("@MeconiumPassed", aNicuAddmission.MeconiumPassed ?? "");
        //    Command.Parameters.AddWithValue("@MeconiumPassedTime", aNicuAddmission.MeconiumPassedTime);
        //    Command.Parameters.AddWithValue("@UrinePassed", aNicuAddmission.UrinePassed ?? "");
        //    Command.Parameters.AddWithValue("@UrinePassedTime", aNicuAddmission.UrinePassedTime);
        //    Command.Parameters.AddWithValue("@Breathing", aNicuAddmission.Breathing ?? "");
        //    Command.Parameters.AddWithValue("@Resuscitaion", aNicuAddmission.Resuscitaion ?? "");
        //    Command.Parameters.AddWithValue("@ResuscitaionMinute", aNicuAddmission.ResuscitaionMinute ?? "");
        //    Command.Parameters.AddWithValue("@DelayedCrying", aNicuAddmission.DelayedCrying ?? "");
        //    Command.Parameters.AddWithValue("@NeonatalMods", aNicuAddmission.NeonatalMods ?? "");
        //    Command.Parameters.AddWithValue("@Medications", aNicuAddmission.Medications ?? "");
        //    Command.Parameters.AddWithValue("@MedicationInjParcent", aNicuAddmission.MedicationInjParcent ?? "");
        //    Command.Parameters.AddWithValue("@BirthWeight", aNicuAddmission.BirthWeight ?? "");
        //    Command.Parameters.AddWithValue("@Length", aNicuAddmission.Length ?? "");
        //    Command.Parameters.AddWithValue("@Ofc", aNicuAddmission.Ofc ?? "");
        //    Command.Parameters.AddWithValue("@ApgerScoresAtOne", aNicuAddmission.ApgerScoresAtOne ?? "");
        //    Command.Parameters.AddWithValue("@ApgerScoresAtFive", aNicuAddmission.ApgerScoresAtFive ?? "");
        //    Command.Parameters.AddWithValue("@ApgerScoresAtTen", aNicuAddmission.ApgerScoresAtTen ?? "");
        //    Command.Parameters.AddWithValue("@Feeding", aNicuAddmission.Feeding ?? "");
        //    Command.Parameters.AddWithValue("@FeedingType", aNicuAddmission.FeedingType ?? "");
        //    Command.Parameters.AddWithValue("@Activity", aNicuAddmission.Activity ?? "");
        //    Command.Parameters.AddWithValue("@Posture", aNicuAddmission.Posture ?? "");
        //    Command.Parameters.AddWithValue("@Cry", aNicuAddmission.Cry ?? "");
        //    Command.Parameters.AddWithValue("@Temp", aNicuAddmission.Temp ?? "");
        //    Command.Parameters.AddWithValue("@Skin", aNicuAddmission.Skin ?? "");
        //    Command.Parameters.AddWithValue("@RashSec", aNicuAddmission.RashSec ?? "");
        //    Command.Parameters.AddWithValue("@HeadNeck", aNicuAddmission.HeadNeck ?? "");
        //    Command.Parameters.AddWithValue("@SternoMastoidTumor", aNicuAddmission.SternoMastoidTumor ?? "");
        //    Command.Parameters.AddWithValue("@AnteriorSize", aNicuAddmission.AnteriorSize ?? "");
        //    Command.Parameters.AddWithValue("@Tension", aNicuAddmission.Tension ?? "");
        //    Command.Parameters.AddWithValue("@PosteriorSize", aNicuAddmission.PosteriorSize ?? "");
        //    Command.Parameters.AddWithValue("@Face", aNicuAddmission.Face ?? "");
        //    Command.Parameters.AddWithValue("@HeartSound", aNicuAddmission.HeartSound ?? "");
        //    Command.Parameters.AddWithValue("@RadioFemoralDelay", aNicuAddmission.RadioFemoralDelay ?? "");
        //    Command.Parameters.AddWithValue("@Murmur", aNicuAddmission.Murmur ?? "");
        //    Command.Parameters.AddWithValue("@Chest", aNicuAddmission.Chest ?? "");
        //    Command.Parameters.AddWithValue("@RRMin", aNicuAddmission.RrMin ?? "");
        //    Command.Parameters.AddWithValue("@BreathSound", aNicuAddmission.BreathSound ?? "");
        //    Command.Parameters.AddWithValue("@AddedSound", aNicuAddmission.AddedSound ?? "");
        //    Command.Parameters.AddWithValue("@HeartRate", aNicuAddmission.HeartRate ?? "");
        //    Command.Parameters.AddWithValue("@Shape", aNicuAddmission.Shape ?? "");
        //    Command.Parameters.AddWithValue("@Distended", aNicuAddmission.Distended ?? "");
        //    Command.Parameters.AddWithValue("@Liver", aNicuAddmission.Liver ?? "");
        //    Command.Parameters.AddWithValue("@Sleen", aNicuAddmission.Sleen ?? "");
        //    Command.Parameters.AddWithValue("@Kidney", aNicuAddmission.Kidney ?? "");
        //    Command.Parameters.AddWithValue("@Umbilicus", aNicuAddmission.Umbilicus ?? "");
        //    Command.Parameters.AddWithValue("@Scrotum", aNicuAddmission.Scrotum ?? "");
        //    Command.Parameters.AddWithValue("@Penis", aNicuAddmission.Penis ?? "");
        //    Command.Parameters.AddWithValue("@Testis", aNicuAddmission.Testis ?? "");
        //    Command.Parameters.AddWithValue("@LabiaMajora", aNicuAddmission.LabiaMajora ?? "");
        //    Command.Parameters.AddWithValue("@Minora", aNicuAddmission.Minora ?? "");
        //    Command.Parameters.AddWithValue("@Clitromegaly", aNicuAddmission.Clitromegaly ?? "");
        //    Command.Parameters.AddWithValue("@Anus", aNicuAddmission.Anus ?? "");
        //    Command.Parameters.AddWithValue("@BackSpine", aNicuAddmission.BackSpine ?? "");
        //    Command.Parameters.AddWithValue("@FootHand", aNicuAddmission.FootHand ?? "");
        //    Command.Parameters.AddWithValue("@CNS", aNicuAddmission.CNS ?? "");
        //    Command.Parameters.AddWithValue("@JitterinessTone", aNicuAddmission.JitterinessTone ?? "");
        //    Command.Parameters.AddWithValue("@Moro", aNicuAddmission.Moro ?? "");
        //    Command.Parameters.AddWithValue("@Rooting", aNicuAddmission.Rooting ?? "");
        //    Command.Parameters.AddWithValue("@Sucking", aNicuAddmission.Sucking ?? "");
        //    Command.Parameters.AddWithValue("@Fractures", aNicuAddmission.Fractures ?? "");
        //    Command.Parameters.AddWithValue("@NerveInjury", aNicuAddmission.NerveInjury ?? "");
        //    Command.Parameters.AddWithValue("@SoftIssue", aNicuAddmission.SoftIssue ?? "");
        //    Command.Parameters.AddWithValue("@Category", aNicuAddmission.Category ?? "");
        //    Command.Parameters.AddWithValue("@GestationalAge", aNicuAddmission.GestationalAge ?? "");
        //    Command.Parameters.AddWithValue("@CongenitalAnomalies", aNicuAddmission.CongenitalAnomalies ?? "");
        //    Command.Parameters.AddWithValue("@ProvisionalDiagnosis", aNicuAddmission.ProvisionalDiagnosis ?? "");
        //    Command.Parameters.AddWithValue("@SalientFeature", aNicuAddmission.SalientFeature ?? "");
        //    Command.Parameters.AddWithValue("@FinalDiagnosis", aNicuAddmission.FinalDiagnosis ?? "");
        //    Command.Parameters.AddWithValue("@Bed", aNicuAddmission.Bed ?? "1");
        //    Command.Parameters.AddWithValue("@AdmissionFee", aNicuAddmission.AdmissionFee ?? "");

        //    int count = Command.ExecuteNonQuery();
        //    return count;
        //}

        //public int DeleteNicuPatient(NicuAddmission aNicuAddmission)
        //{
        //    Query = "DELETE FROM nicuadmission WHERE Id = '" + aNicuAddmission.Id + "'";
        //    Command = new SqlCommand(Query, Connection);
        //    int rowAffect = Command.ExecuteNonQuery();
        //    return rowAffect;
        //}

        //public DataTable GetNicuRegId()
        //{
        //    Query = "SP_GENERATE_Reg_NicuAdmission";
        //    Command = new SqlCommand(Query, Connection);
        //    Command.CommandType = CommandType.Text;
        //    Reader = Command.ExecuteReader(); DataTable data = new DataTable();
        //    data.Load(Reader);
        //    return data;
        //}

        //public DataTable GetNicuPatients(DateTime fromdate, DateTime ToDate)
        //{
        //    Query = "SELECT * FROM nicuadmission where Convert(date,AdmitDate) between '" + fromdate + "' and '" + ToDate + "' ORDER BY RegNo ASC";
        //    Command = new SqlCommand(Query, Connection);
        //    Command.CommandText = Query;
        //    Reader = Command.ExecuteReader();
        //    DataTable data = new DataTable();
        //    data.Load(Reader);
        //    return data;
        //}

        //public DataTable GetNicuBed()
        //{
        //    Query = "SELECT * FROM ViewAllBeds WHERE WardId='9' AND WardName='NICU'";
        //    Command = new SqlCommand(Query, Connection);
        //    Command.CommandText = Query;
        //    Reader = Command.ExecuteReader();
        //    DataTable data = new DataTable();
        //    data.Load(Reader);
        //    return data;
        //}

    }
}
