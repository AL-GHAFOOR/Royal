using System.Data;
using System.Data.SqlClient;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gatway
{
    public class DeathInfoGatway : GatwayConnection
    {
        public DataTable GetIndorPatientInfo()
        {
            Query = "SELECT OPID,PatientName, Address,Nationality,Gender,Age,FatherName,MotherName FROM tbl_IndoorAdmission WHERE OPID NOT IN (SELECT OPID FROM DeathInfo)"; 
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public DataTable GetDeathInfo(){
            Query = "SELECT * FROM DeathInfo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public int SaveDeathInfo(DeathInfo aDeathInfo)
        {
            Query = "INSERT INTO DeathInfo (DeathRegNo,Name,IssueDate,FathersName,MothersName,DateOfDeath,DeathTime,Age," +
                    "Gender,MaritalStatus,SpouseName,PresentAddress,PermanentAddress,Nationality,CreateDate,UserId,OPID,Floor,Cabin,Bed,Religion,DateOfAdmission,IntervalBetween) " +
                    "VALUES (@DeathRegNo,@Name,@IssueDate,@FathersName,@MothersName,@DateOfDeath,@DeathTime,@Age,@Gender," +
                    "@MaritalStatus,@SpouseName,@PresentAddress,@PermanentAddress,@Nationality,@CreateDate,@UserId,@OPID,@Floor,@Cabin,@Bed,@Religion,@DateOfAdmission,@IntervalBetween)";
            Command=new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@DeathRegNo", aDeathInfo.DeathRegNo ?? "");
            Command.Parameters.AddWithValue("@Name", aDeathInfo.Name ?? "");
            Command.Parameters.AddWithValue("@IssueDate", aDeathInfo.IssueDate);
            Command.Parameters.AddWithValue("@FathersName", aDeathInfo.FathersName??"");
            Command.Parameters.AddWithValue("@MothersName", aDeathInfo.MothersName ?? "");
            Command.Parameters.AddWithValue("@DateOfDeath", aDeathInfo.DateOfDeath);
            Command.Parameters.AddWithValue("@DeathTime", aDeathInfo.DeathTime);
            Command.Parameters.AddWithValue("@Age", aDeathInfo.Age??"");
            Command.Parameters.AddWithValue("@Gender", aDeathInfo.Gender??"");
            Command.Parameters.AddWithValue("@MaritalStatus", aDeathInfo.MaritalStatus??"");
            Command.Parameters.AddWithValue("@SpouseName", aDeathInfo.SpouseName ?? "");
            Command.Parameters.AddWithValue("@PresentAddress", aDeathInfo.PresentAddress??"");
            Command.Parameters.AddWithValue("@PermanentAddress", aDeathInfo.PermanentAddress??"");
            Command.Parameters.AddWithValue("@Nationality", aDeathInfo.Nationality??"");
            Command.Parameters.AddWithValue("@CreateDate", aDeathInfo.CreateDate);
            Command.Parameters.AddWithValue("@UserId", aDeathInfo.UserId??"");
            Command.Parameters.AddWithValue("@OPID", aDeathInfo.Opid??"");

            Command.Parameters.AddWithValue("@Floor", aDeathInfo.Floor ?? "");
            Command.Parameters.AddWithValue("@Cabin", aDeathInfo.Cabin ?? "");
            Command.Parameters.AddWithValue("@Bed", aDeathInfo.Bed ?? "");
            Command.Parameters.AddWithValue("@Religion", aDeathInfo.Religion ?? "");
            Command.Parameters.AddWithValue("@DateOfAdmission", aDeathInfo.DateOfAdmission);
            Command.Parameters.AddWithValue("@IntervalBetween", aDeathInfo.IntervalBetween??"");




            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }
        public int UpdateDeathInfo(DeathInfo aDeathInfo)
        {
            Query = "UPDATE DeathInfo SET DeathRegNo=@DeathRegNo,Name=@Name,IssueDate=@IssueDate,FathersName=@FathersName," +
                    "MothersName=@MothersName,DateOfDeath=@DateOfDeath,DeathTime=@DeathTime,Age=@Age,Gender=@Gender,MaritalStatus=@MaritalStatus," +
                    "SpouseName=@SpouseName,PresentAddress=@PresentAddress,PermanentAddress=@PermanentAddress,Nationality=@Nationality," +
                    "UpdateDate=@UpdateDate,UserId=@UserId,Floor=@Floor,Cabin=@Cabin,Bed=@Bed,Religion=@Religion,DateOfAdmission=@DateOfAdmission,IntervalBetween=@IntervalBetween WHERE OPID=@OPID";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DeathRegNo", aDeathInfo.DeathRegNo ?? "");
            Command.Parameters.AddWithValue("@Name", aDeathInfo.Name ?? "");
            Command.Parameters.AddWithValue("@IssueDate", aDeathInfo.IssueDate);
            Command.Parameters.AddWithValue("@FathersName", aDeathInfo.FathersName);
            Command.Parameters.AddWithValue("@MothersName", aDeathInfo.MothersName);
            Command.Parameters.AddWithValue("@DateOfDeath", aDeathInfo.DateOfDeath);
            Command.Parameters.AddWithValue("@DeathTime", aDeathInfo.DeathTime);
            Command.Parameters.AddWithValue("@Age", aDeathInfo.Age);
            Command.Parameters.AddWithValue("@Gender", aDeathInfo.Gender);
            Command.Parameters.AddWithValue("@MaritalStatus", aDeathInfo.MaritalStatus);
            Command.Parameters.AddWithValue("@SpouseName", aDeathInfo.SpouseName);
            Command.Parameters.AddWithValue("@PresentAddress", aDeathInfo.PresentAddress);
            Command.Parameters.AddWithValue("@PermanentAddress", aDeathInfo.PermanentAddress);
            Command.Parameters.AddWithValue("@Nationality", aDeathInfo.Nationality);
            Command.Parameters.AddWithValue("@UpdateDate", aDeathInfo.UpdateDate);
            Command.Parameters.AddWithValue("@UserId", aDeathInfo.UserId);
            Command.Parameters.AddWithValue("@OPID", aDeathInfo.Opid);


            Command.Parameters.AddWithValue("@Floor", aDeathInfo.Floor ?? "");
            Command.Parameters.AddWithValue("@Cabin", aDeathInfo.Cabin ?? "");
            Command.Parameters.AddWithValue("@Bed", aDeathInfo.Bed ?? "");
            Command.Parameters.AddWithValue("@Religion", aDeathInfo.Religion ?? "");
            Command.Parameters.AddWithValue("@DateOfAdmission", aDeathInfo.DateOfAdmission);
            Command.Parameters.AddWithValue("@IntervalBetween", aDeathInfo.IntervalBetween ?? "");


            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }
        public int DeleteDeathInfo(DeathInfo aDeathInfo)
        {
            Query = "DELETE DeathInfo WHERE OPID='"+aDeathInfo.Opid+"'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }
  }
}
