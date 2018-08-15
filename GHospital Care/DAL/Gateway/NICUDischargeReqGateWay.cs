using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    public class NICUDischargeReqGateWay : GatwayConnection
    {
        public DataTable GetIpdDischageNICU()
        {
            Query = "SELECT * from HospitalBusinessOfficeNICU WHERE RegNo NOT IN(SELECT OPID FROM tbl_MasterDischargeFormNICU)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetNICUPatientInformationBySl(string patientSlNo)
        {
            Query = "select * from HospitalBusinessOfficeNICU where RegNo='" + patientSlNo + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public int SaveNICUDischargePatient(DischargeRequestNICU dischargePatient)
        {
            int count = 0;
            Query = "INSERT INTO [tbl_MasterDischargeFormNICU]" +
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
                Query = "INSERT INTO tbl_DischargeDrugDetialsNICU (OPID,DrugName,Doose,DrugId,Description)"
               + "VALUES(@OPID,@DrugName,@Doose,@DrugId,@Description)";

                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue(@"OPID", dischargePatient.OPID);
                Command.Parameters.AddWithValue(@"DrugName", dr["DrugName"]);
                Command.Parameters.AddWithValue(@"Doose", dr["Doose"]);
                Command.Parameters.AddWithValue(@"DrugId", dr["DrugId"]);
                Command.Parameters.AddWithValue(@"Description", dr["Description"]);
                count += Command.ExecuteNonQuery();
            }

            return count;
        }

        public int UpdateNICUDischargePatient(DischargeRequestNICU dischargePatient)
        {
            try
            {
                int count = 0;
                Query = "UPDATE tbl_MasterDischargeFormNICU SET RegNo=@RegNo,weight=@weight,AddmissionOn=@AddmissionOn," +
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
                    Query = "DELETE tbl_DischargeDrugDetialsNICU WHERE OPID='" + dischargePatient.OPID + "'";
                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;

                    count += Command.ExecuteNonQuery();
                }

                foreach (DataRow dischageDrugDetialse in dischargePatient.Tempdatatable.Rows)
                {
                    Query = "INSERT INTO tbl_DischargeDrugDetialsNICU(OPID,DrugName,Doose,DrugId,Description)VALUES(@OPID,@DrugName,@Doose,@DrugId,@Description)";
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

        public int DeleteNICUDischargePatient(DischargeRequestNICU dischargePatient)
        {
            int rowAffect2 = 0;

            Query = "DELETE tbl_MasterDischargeFormNICU WHERE OPID='" + dischargePatient.OPID + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();

            if (rowAffect > 0)
            {
                Query = "DELETE tbl_DischargeDrugDetialsNICU WHERE OPID='" + dischargePatient.OPID + "'";
                Command = new SqlCommand(Query, Connection);
                rowAffect2 = Command.ExecuteNonQuery();
            }
            return rowAffect2;
        }

        public DataTable GetDischargeInfoMaster()
        {
            Query = "SELECT DISTINCT OPID, PatientName, FatherName, Address, DischargeOn,Gender, Age,InputDate FROM ViewGetDischargeInfoNICU";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }

        public DataTable GetDischargeDetails(DischargeRequestNICU _dischargePatient)
        {
            Query = "SELECT * FROM tbl_DischargeDrugDetialsNICU WHERE OPID='" + _dischargePatient.OPID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable GetDischargeInfo(DischargeRequestNICU dischargePatient)
        {
            DataTable dtDataTable = new DataTable();
            Query = "SELECT * FROM ViewGetDischargeInfoNICU WHERE RegNo NOT IN (SELECT OPID FROM tbl_DischargeBillNICU) AND RegNo='" + dischargePatient.OPID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
    }
}
