using System;
using System.Data;
using System.Data.SqlClient;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gatway
{
    public class BirthInfoGatway : GatwayConnection
    {
        public DataTable GetOpInfo()
        {
            Query = "SELECT OPID,PatientName AS MothersName,Address AS PresentAddress,Nationality AS MothersNationality FROM tbl_IndoorAdmission WHERE OPID NOT IN (SELECT OPID FROM BirthInfo) AND Gender='Female'";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }public int SaveBirthInfo(BirthInfo aBirthInfo)
        {
            Query = "INSERT INTO BirthInfo(BirthRegNo,Name,IssueDate,FathersName,MothersName,FathersNationality," +
                    "MothersNationality,PresentAddress,PermanentAddress,DateOfBirth,BirthTime,Weight,Height,Gender,Nationality," +
                    "UserId,OPID,CabinBed,TypeOfDelivery)VALUES(@BirthRegNo,@Name,@IssueDate,@FathersName,@MothersName," +
                    "@FathersNationality,@MothersNationality,@PresentAddress,@PermanentAddress,@DateOfBirth," +
                    "@BirthTime,@Weight,@Height,@Gender,@Nationality,@UserId,@OPID,@CabinBed,@TypeOfDelivery)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@BirthRegNo", aBirthInfo.BirthRegNo ?? "");
            Command.Parameters.AddWithValue("@Name", aBirthInfo.Name ?? "");
            Command.Parameters.AddWithValue("@IssueDate", aBirthInfo.IssueDate);
            Command.Parameters.AddWithValue("@FathersName", aBirthInfo.FathersName ?? "");
            Command.Parameters.AddWithValue("@MothersName", aBirthInfo.MothersName);
            Command.Parameters.AddWithValue("@FathersNationality", aBirthInfo.FathersNationality ?? "");
            Command.Parameters.AddWithValue("@MothersNationality", aBirthInfo.MothersNationality ?? "");
            Command.Parameters.AddWithValue("@PresentAddress", aBirthInfo.PresentAddress ?? "");
            Command.Parameters.AddWithValue("@PermanentAddress", aBirthInfo.PermanentAddress ?? "");
            Command.Parameters.AddWithValue("@DateOfBirth", aBirthInfo.DateOfBirth);
            Command.Parameters.AddWithValue("@BirthTime", aBirthInfo.BirthTime);
            Command.Parameters.AddWithValue("@Weight", aBirthInfo.Weight??"");
            Command.Parameters.AddWithValue("@Height", aBirthInfo.Height??"");
            Command.Parameters.AddWithValue("@Gender", aBirthInfo.Gender ?? "");
            Command.Parameters.AddWithValue("@Nationality", aBirthInfo.Nationality ?? "");
            Command.Parameters.AddWithValue("@UserId", aBirthInfo.UserId??"");
            Command.Parameters.AddWithValue("@OPID", aBirthInfo.OPID??"");
            Command.Parameters.AddWithValue("@CabinBed", aBirthInfo.CabinBed ?? "");
            Command.Parameters.AddWithValue("@TypeOfDelivery", aBirthInfo.TypeOfDelivery ?? "");

            int rowAffect = Command.ExecuteNonQuery();

            return rowAffect;
        }
        public int UpdateBirthInfo(BirthInfo aBirthInfo)
        {
            Query = "UPDATE BirthInfo SET BirthRegNo=@BirthRegNo,Name=@Name,IssueDate=@IssueDate,FathersName=@FathersName," +
                    "MothersName=@MothersName,FathersNationality=@FathersNationality,MothersNationality=@MothersNationality," +
                    "PresentAddress=@PresentAddress,PermanentAddress=@PermanentAddress,DateOfBirth=@DateOfBirth," +
                    "BirthTime=@BirthTime,Gender=@Gender,Nationality=@Nationality,UpdateDate=@UpdateDate," +
                    "UserId=@UserId,CabinBed=@CabinBed,TypeOfDelivery=@TypeOfDelivery WHERE OPID=@OPID";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@BirthRegNo", aBirthInfo.BirthRegNo ?? "");
            Command.Parameters.AddWithValue("@Name", aBirthInfo.Name ?? "");
            Command.Parameters.AddWithValue("@IssueDate", aBirthInfo.IssueDate);
            Command.Parameters.AddWithValue("@FathersName", aBirthInfo.FathersName ?? "");
            Command.Parameters.AddWithValue("@MothersName", aBirthInfo.MothersName);
            Command.Parameters.AddWithValue("@FathersNationality", aBirthInfo.FathersNationality ?? "");
            Command.Parameters.AddWithValue("@MothersNationality", aBirthInfo.MothersNationality ?? "");
            Command.Parameters.AddWithValue("@PresentAddress", aBirthInfo.PresentAddress ?? "");
            Command.Parameters.AddWithValue("@PermanentAddress", aBirthInfo.PermanentAddress ?? "");
            Command.Parameters.AddWithValue("@DateOfBirth", aBirthInfo.DateOfBirth);
            Command.Parameters.AddWithValue("@BirthTime", aBirthInfo.BirthTime);
            Command.Parameters.AddWithValue("@Gender", aBirthInfo.Gender ?? "");
            Command.Parameters.AddWithValue("@Nationality", aBirthInfo.Nationality ?? "");
            Command.Parameters.AddWithValue("@UpdateDate", aBirthInfo.UpdateDate);
            Command.Parameters.AddWithValue("@UserId", aBirthInfo.UserId);
            Command.Parameters.AddWithValue("@OPID", aBirthInfo.OPID);
            Command.Parameters.AddWithValue("@CabinBed", aBirthInfo.CabinBed ?? "");
            Command.Parameters.AddWithValue("@TypeOfDelivery", aBirthInfo.TypeOfDelivery ?? "");

            int rowAffect = Command.ExecuteNonQuery();

            return rowAffect;
        }
        public DataTable GetBirthInfo()
        {
            Query = "SELECT * FROM BirthInfo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public int DeleteBirthInfo(BirthInfo aBirthInfo)
        {
            Query = "DELETE FROM BirthInfo WHERE Id='" + aBirthInfo.Id + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }


        public DataTable GenerateBirthRegID()
        {
            DataSet ds = DbSelectQuery("SP_GENERATE_BirthRegNo");
            DataTable dt = ds.Tables[0];
            return dt;
        }


        public DataSet DbSelectQuery(string strQuery)
        {
            var dSet = new DataSet();
            try
            {
                var da = new SqlDataAdapter(strQuery, Connection);
                da.Fill(dSet);
                return dSet;
            }

            catch (Exception)
            {
                return dSet;
            }
        }





    }
}