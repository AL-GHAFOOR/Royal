using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    public class MedicalGatway : GatwayConnection
    {
        public DataTable GetAllDoctor()
        {
            Query = "select * from tblDoctors";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }

        public Doctor GetAllDoctorbyId(string docId)
        {
            Query = "select * from tblDoctors where DoctorID='" + docId + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            Doctor doctor = new Doctor();

            while (Reader.Read())
            {
                doctor.DoctorName = Reader["DoctorName"].ToString();
            }
            Reader.Close();
            return doctor;
        }

        public DataTable GetAllCosultDoctor()
        {
            Query = "select * from tblConsult_Doctors";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable GetAllCosultDoctor(string docId)
        {
            Query = "select * from tblConsult_Doctors where DoctorID='" + docId + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetAllDrug()
        {
            Query = "select ProductCode,ProductName from Master_Medicine";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetFollowCount(string PatientID, DateTime FollowUPdate)
        {
            Query = "select Count(Distinct SerialFollowUp) from tbl_PatientFollowup where OpID = '" + PatientID + "' and Date= '" + FollowUPdate + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetIndoorPatientInformationBySl(string patientSlNo)
        {
            Query = "select * from BedHistoryPatientInfo where OPID='" + patientSlNo + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetTotalFollowCount(string PatientID)
        {
            Query = "select Count(Distinct SerialFollowUp) from tbl_PatientFollowup where OpID = '" + PatientID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetFollowupView(string Department)
        {
            Query = "select * from ViewFollowUpSheet  where DeparmentName = '" + Department + "' order by FollowupId ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public int FOllowUpmaster(Followup followup)
        {
            int count = 0;
            Query = "INSERT INTO [tbl_PatientFollowUPMaster]([PatientId],[FollowUPId],[Date],[ExtraNote],[Doctor],[Shift],[Department])" +
                            "VALUES(@PatientId,@FollowUPId,@Date, @ExtraNote, @Doctor,@Shift, @Department)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue(@"PatientId", followup.OPID);
            Command.Parameters.AddWithValue(@"FollowUPId", followup.SerialId);
            Command.Parameters.AddWithValue(@"Date", followup.Date);
            Command.Parameters.AddWithValue(@"ExtraNote", "");
            Command.Parameters.AddWithValue(@"Doctor", followup.DocId);
            Command.Parameters.AddWithValue(@"Shift", followup.Shift);
            Command.Parameters.AddWithValue(@"Department", followup.Department);
            count += Command.ExecuteNonQuery();
            
            return count;
        }
        public long GetFollowUpSerial(SerailGenerate serial)
        {
            Query = "select Isnull(MAX(Id+1),1) from tbl_PatientFollowupMaster";
            Command = new SqlCommand(Query, Connection);

            long maxId = Convert.ToUInt32(Command.ExecuteScalar());
            return maxId;
        }

        public int SaveFollowUp(Followup followup)
        {

            int count = 0;
            if (followup.ListOfDrug != null)
            {
                foreach (DataRow value in followup.ListOfDrug.Rows)
                {

                    Query = "INSERT INTO [tbl_PatientFollowup]([SerialFollowUp],[OPID],[Drug],[DoctorID],[Dous],[FollowupId],[BP],[ExtraNote],[ExtraNoteSpecial],[Date])" +
                           "VALUES(@SerialFollowUp,@OPID,@Drug, @DoctorID, @Dous,@FollowupId, @BP,@ExtraNote,@ExtraNoteSpecial,@Date)";
                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue(@"SerialFollowUp", followup.SerialId);
                    Command.Parameters.AddWithValue(@"OPID", followup.OPID);
                    Command.Parameters.AddWithValue(@"Drug", value["DrugId"]);
                    Command.Parameters.AddWithValue(@"DoctorID", followup.DocId);
                    Command.Parameters.AddWithValue(@"Dous", value["Dous"]);
                    Command.Parameters.AddWithValue(@"FollowupId", "");
                    Command.Parameters.AddWithValue(@"BP", followup.Bp);
                    Command.Parameters.AddWithValue(@"ExtraNote", value["ExtraNote"]);
                    Command.Parameters.AddWithValue(@"ExtraNoteSpecial", value["ExtraNoteSpecial"]);
                    Command.Parameters.AddWithValue(@"Date", followup.Date);

                    count += Command.ExecuteNonQuery();
                }    
            }
            return count;
        }

        public int SaveRegularFollowUp(Followup followup)
        {
            int count = 0;
            try
            {
              for (int i = 0; i < followup.AFollowupList.Count; i++)
                {
                    Query = "INSERT INTO tbl_PatientFollowUpRegular([FollowUPID],[PatientID],[FollowUpItemID],[Particulars],[ItemType],[DoctorID],[Shift],[Date])" +
                           "VALUES(@FollowUPID,@PatientID,@FollowUpItemID, @Particulars, @ItemType,@DoctorID, @Shift,@Date)";
                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue(@"FollowUPID", followup.SerialId);
                    Command.Parameters.AddWithValue(@"PatientID", followup.OPID);
                    Command.Parameters.AddWithValue(@"FollowUpItemID", followup.AFollowupList[i].FollowUPItemId);
                    Command.Parameters.AddWithValue(@"DoctorID", followup.DocId);
                    Command.Parameters.AddWithValue(@"Particulars", followup.AFollowupList[i].Particulars);
                    Command.Parameters.AddWithValue(@"ItemType", followup.AFollowupList[i].ItemType);
                    Command.Parameters.AddWithValue(@"Shift", followup.Shift);
                    Command.Parameters.AddWithValue(@"Date", followup.Date);
                    count += Command.ExecuteNonQuery();
                }
                
            }
            catch (Exception)
            {
            }
            return count;
        }
        public int UpdateFollowUp(Followup followup)
        {

            int count = 0;
            foreach (DataRow value in followup.ListOfDrug.Rows)
            {
                Query = "UPDATE TABLE tbl_PatientFollowup SET Drug=@Drug,DoctorID=@DoctorID,Dous=@Dous,FollowupId=@FollowupId," +
                        "BP=@BP,ExtraNote=@ExtraNote,ExtraNoteSpecial=@ExtraNoteSpecial,Date=@Date WHERE OPID='" + followup.OPID + "'";
                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;

                Command.Parameters.AddWithValue(@"Drug", value["DrugId"]);
                Command.Parameters.AddWithValue(@"DoctorID", followup.DocId);
                Command.Parameters.AddWithValue(@"Dous", value["Dous"]);
                Command.Parameters.AddWithValue(@"FollowupId", "");
                Command.Parameters.AddWithValue(@"BP", followup.Bp);
                Command.Parameters.AddWithValue(@"ExtraNote", value["ExtraNote"]);
                Command.Parameters.AddWithValue(@"ExtraNoteSpecial", value["ExtraNoteSpecial"]);
                Command.Parameters.AddWithValue(@"Date", followup.Date);

                count += Command.ExecuteNonQuery();
            } return count;
        }


        //Save 

        public int SaveDischargePatient(DischargePatient dischargePatient)
        {
            int count = 0;
            Query = "INSERT INTO [tbl_MasterDischargeForm]" +
                  "([OPID],[RegNo],[weight],[AddmissionOn],[DischargeOn],[DiagOnAdmission],[DiagOnDischarge],[StatusOnDischarge],[Cured],[Improved],[Dor],[Dorb],[NotImproved],[userId],[Status],FatherHusbandName,Gender,Age,BloodGroup,Consult,Cabin_BedNo,ContactNo,DischargeTime)" +
            "VALUES(@OPID,@RegNo,@weight,@AddmissionOn,@DischargeOn,@DiagOnAdmission,@DiagOnDischarge, @StatusOnDischarge,"
            + "@Cured,@Improved,@Dor,@Dorb,@NotImproved,@userId, @Status,@FatherHusbandName,@Gender,@Age,@BloodGroup,@Consult,@Cabin_BedNo,@ContactNo,@DischargeTime)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue(@"OPID", dischargePatient.OPID);
            Command.Parameters.AddWithValue(@"RegNo", dischargePatient.RegNo);
            Command.Parameters.AddWithValue(@"weight", dischargePatient.weight);
            Command.Parameters.AddWithValue(@"AddmissionOn", dischargePatient.AddmissionOn);
            Command.Parameters.AddWithValue(@"DischargeOn", dischargePatient.DischargeOn);
            Command.Parameters.AddWithValue(@"DiagOnAdmission", dischargePatient.DiagOnAdmission);
            Command.Parameters.AddWithValue(@"DiagOnDischarge", dischargePatient.DiagOnDischarge);
            Command.Parameters.AddWithValue(@"StatusOnDischarge", false);
            Command.Parameters.AddWithValue(@"Cured", dischargePatient.Cured);
            Command.Parameters.AddWithValue(@"Improved", dischargePatient.Improved);
            Command.Parameters.AddWithValue(@"Dor", dischargePatient.Dor);
            Command.Parameters.AddWithValue(@"Dorb", dischargePatient.Dorb);
            Command.Parameters.AddWithValue(@"NotImproved", dischargePatient.NotImproved);
            Command.Parameters.AddWithValue(@"userId", dischargePatient.userId ?? "");
            Command.Parameters.AddWithValue(@"Status", "Discharge");

            Command.Parameters.AddWithValue(@"FatherHusbandName", dischargePatient.FatherHusbandName ?? "");
            Command.Parameters.AddWithValue(@"Gender", dischargePatient.Gender ?? "");
            Command.Parameters.AddWithValue(@"Age", dischargePatient.Age ?? "");
            Command.Parameters.AddWithValue(@"BloodGroup", dischargePatient.BloodGroup ?? "");
            Command.Parameters.AddWithValue(@"Consult", dischargePatient.Consult ?? "");
            Command.Parameters.AddWithValue(@"Cabin_BedNo", dischargePatient.Cabin_BedNo ?? "");
            Command.Parameters.AddWithValue(@"ContactNo", dischargePatient.ContactNo ?? "");
            Command.Parameters.AddWithValue(@"DischargeTime", dischargePatient.DischargeTime);


            count += Command.ExecuteNonQuery();


            ////////////  In Drug Detials////////////////////////////
    
                foreach (DataRow dr in dischargePatient.Tempdatatable.Rows)
                {
                    Query = "INSERT INTO tbl_DischargeDrugDetials (OPID,DrugName,Doose,DrugId,Description)"
                   + "VALUES(@OPID,@DrugName,@Doose,@DrugId,@Description)";

                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue(@"OPID", dischargePatient.OPID);
                    Command.Parameters.AddWithValue(@"DrugName", dr["DrugName"]);
                    Command.Parameters.AddWithValue(@"Doose", dr["Doose"]);
                    Command.Parameters.AddWithValue(@"DrugId", dr["DrugId"]);
                    Command.Parameters.AddWithValue(@"Description", dr["Description"]);
                    count+= Command.ExecuteNonQuery();
            }

            return count;
        }

        // Update 
        public int UpdateDischargePatient(DischargePatient dischargePatient)
        {
            try
            {
                int count = 0;
                Query = "UPDATE tbl_MasterDischargeForm SET RegNo=@RegNo,weight=@weight,AddmissionOn=@AddmissionOn," +
                       "DischargeOn=@DischargeOn,DiagOnAdmission=@DiagOnAdmission,DiagOnDischarge=@DiagOnDischarge," +
                       "StatusOnDischarge=@StatusOnDischarge,Cured=@Cured,Improved=@Improved,Dor=@Dor,Dorb=@Dorb," +
                       "NotImproved=@NotImproved,userId=@userId,Status=@Status,FatherHusbandName=@FatherHusbandName," +
                       "Gender=@Gender,Age=@Age,BloodGroup=@BloodGroup,Consult=@Consult,Cabin_BedNo=@Cabin_BedNo," +
                       "ContactNo=@ContactNo WHERE OPID='" + dischargePatient.OPID + "'";

                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue(@"RegNo", dischargePatient.RegNo);
                Command.Parameters.AddWithValue(@"weight", dischargePatient.weight);
                Command.Parameters.AddWithValue(@"AddmissionOn", dischargePatient.AddmissionOn);
                Command.Parameters.AddWithValue(@"DischargeOn", dischargePatient.DischargeOn);
                Command.Parameters.AddWithValue(@"DiagOnAdmission", dischargePatient.DiagOnAdmission);
                Command.Parameters.AddWithValue(@"DiagOnDischarge", dischargePatient.DiagOnDischarge);
                Command.Parameters.AddWithValue(@"StatusOnDischarge", false);
                Command.Parameters.AddWithValue(@"Cured", dischargePatient.Cured);
                Command.Parameters.AddWithValue(@"Improved", dischargePatient.Improved);
                Command.Parameters.AddWithValue(@"Dor", dischargePatient.Dor);
                Command.Parameters.AddWithValue(@"Dorb", dischargePatient.Dorb);
                Command.Parameters.AddWithValue(@"NotImproved", dischargePatient.NotImproved);
                Command.Parameters.AddWithValue(@"userId", dischargePatient.userId ?? "");
                Command.Parameters.AddWithValue(@"Status", "Discharge");

                Command.Parameters.AddWithValue(@"FatherHusbandName", dischargePatient.FatherHusbandName ?? "");
                Command.Parameters.AddWithValue(@"Gender", dischargePatient.Gender ?? "");
                Command.Parameters.AddWithValue(@"Age", dischargePatient.Age ?? "");
                Command.Parameters.AddWithValue(@"BloodGroup", dischargePatient.BloodGroup ?? "");
                Command.Parameters.AddWithValue(@"Consult", dischargePatient.Consult ?? "");
                Command.Parameters.AddWithValue(@"Cabin_BedNo", dischargePatient.Cabin_BedNo ?? "");
                Command.Parameters.AddWithValue(@"ContactNo", dischargePatient.ContactNo ?? "");

                count += Command.ExecuteNonQuery();

                if (count > 0)
                {
                    Query = "DELETE tbl_DischargeDrugDetials WHERE OPID='" + dischargePatient.OPID + "'";
                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;

                    count += Command.ExecuteNonQuery();
                }

                foreach (DataRow dischageDrugDetialse in dischargePatient.Tempdatatable.Rows)
                {
                    Query = "INSERT INTO tbl_DischargeDrugDetials(OPID,DrugName,Doose,DrugId,Description)VALUES(@OPID,@DrugName,@Doose,@DrugId,@Description)";
                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue(@"OPID", dischargePatient.OPID);
                    Command.Parameters.AddWithValue(@"DrugName", dischageDrugDetialse["DrugName"]);
                    Command.Parameters.AddWithValue(@"Doose", dischageDrugDetialse["Doose"]);
                    Command.Parameters.AddWithValue(@"DrugId", dischageDrugDetialse["DrugId"]);
                    Command.Parameters.AddWithValue(@"Description", dischageDrugDetialse["Description"]);
                    count += Command.ExecuteNonQuery();

                }
                return count;
            }

            catch (Exception exception)
            {
                throw exception;
            }
        }
        public int DeleteDischargePatient(DischargePatient dischargePatient)
        {
            int rowAffect2 = 0;

            Query = "DELETE tbl_MasterDischargeForm WHERE OPID='" + dischargePatient.OPID + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();

            if (rowAffect > 0)
            {
                Query = "DELETE tbl_DischargeDrugDetials WHERE OPID='" + dischargePatient.OPID + "'";
                Command = new SqlCommand(Query, Connection);
                rowAffect2 = Command.ExecuteNonQuery();
            }
            return rowAffect2;
        }



        public DataTable GetDischargeBillByPatientId(string OPID)
        {
            Query = "sp_DisChargeTotalBill";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@opid", OPID);
            Reader = Command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Reader);

            return dt;

        }


        public DataTable GetDischargeBillByPatientId_Update(string OPID)
        {
            Query = "sp_DisChargeTotalBill_Update";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@opid", OPID);
            Reader = Command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Reader);

            return dt;

        }
        public DataTable DischargeRequestPatient()
        {
            DataTable dtDataTable = new DataTable();
            Query = "select OPID, PatientName,BedName from BedHistoryPatientInfo where OPID not in(Select OPID from tbl_DischargeBill) and OPID in(select OPID from tbl_MasterDischargeForm)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            
            dtDataTable.Load(Reader); 
            return dtDataTable;
        }



        public DataTable GetDischargeInfo(DischargePatient dischargePatient)
        {
            DataTable dtDataTable = new DataTable();
            Query = "SELECT * FROM ViewGetDischargeInfo WHERE OPID NOT IN (SELECT OPID FROM tbl_DischargeBill) AND OPID='" + dischargePatient.OPID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable GetDischargeInfoMaster()
        {
            Query = "SELECT DISTINCT OPID, PatientName, FatherName, Address, DischargeOn,Gender, Age,InputDate FROM ViewGetDischargeInfo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }


        public DataTable GetDischargeInfoMaster(string FromDate, string ToDate)
        {
            Query = "SELECT DISTINCT OPID, PatientName, FatherName, Address, DischargeOn,Gender, Age,InputDate FROM ViewGetDischargeInfo WHERE DischargeOn BETWEEN '2018-05-22' AND '2018-05-22'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }

        public DataTable IPDischargeBillID()
        {
            Query = "SP_GENERATE_IPBILLID";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        //public DataTable GetDischargeInfo()
        //{
        //    Query = "SELECT * FROM tbl_MasterDischargeForm";
        //    Command = new SqlCommand(Query, Connection);
        //    Command.CommandType = CommandType.Text;
        //    Reader = Command.ExecuteReader();
        //    DataTable data = new DataTable();
        //    data.Load(Reader);
        //    return data;
        //}

        public DataTable GetDischargeDetails(DischargePatient _dischargePatient)
        {
            Query = "SELECT * FROM tbl_DischargeDrugDetials WHERE OPID='" + _dischargePatient.OPID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable UpdatefollowUPSheet(string patientID,string followUpID )
        {
            DataTable dtDataTable = new DataTable();
            try
            {
                Query = "select Particulars,FollowUpItemID from tbl_PatientFollowUpRegular where FollowUPID ='" + followUpID + "' and PatientID= '" + patientID + "'";
                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Reader = Command.ExecuteReader();
                
                dtDataTable.Load(Reader);

            }
            catch (Exception)
            {
                
            }
           
            return dtDataTable;
        }


        public DataTable GetAllPatientFollowup(DateTime FormDate, DateTime ToDate)
        {
            DataTable dtDataTable = new DataTable();
            try
            {
                Query = "SELECT DIStinct SerialFollowUp,OPID,Date,PatientName,BedName,BP,DoctorID,DoctorName,Shift,Deparment FROM ViewGetAllPatientFollowup where Date Between '" + FormDate + "' and '" + ToDate + "' ";
                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Reader = Command.ExecuteReader();
                dtDataTable.Load(Reader);

            }
            catch (Exception)
            {
                
                throw;
            }
       
            return dtDataTable;
        }


        public int DeletePatientFollowup(Followup followup)
        {
            Query = "DELETE tbl_PatientFollowup WHERE SerialFollowUp='" + followup.SerialId + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }
        public int DeletePatientFollowupMaster(Followup followup)
        {
            Query = "DELETE tbl_PatientFollowUPMaster WHERE FollowUPId='" + followup.SerialId + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }
        public int DeletePatientFollowupSheet(Followup followup)
        {
            Query = "DELETE tbl_PatientFollowUpRegular WHERE FollowUPID='" + followup.SerialId + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }
        public DataTable GetPatientFollowupByOpid(Followup followup)
        {
            Query = "SELECT * FROM ViewGetAllPatientFollowup WHERE OPID='" + followup.OPID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

    }
}
