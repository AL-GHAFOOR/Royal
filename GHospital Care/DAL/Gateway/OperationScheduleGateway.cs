using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
  public  class OperationScheduleGateway:GatwayConnection
    {
      public int SaveOperationSchedule(OperationSchedule aOperationSchedule)
      {
          Query = "INSERT INTO OperationSchedule (OtRefNo,OtDate,OPID,CabinBed,PatientName,FirstAssist,SurgeonName,SecondAssist," +
                  "Anaesthesiologist,OperationName,OperationTime,ToTime,UserId) VALUES (@OtRefNo,@OtDate,@OPID,@CabinBed,@PatientName,@FirstAssist,@SurgeonName,@SecondAssist,@Anaesthesiologist,@OperationName,@OperationTime,@ToTime,@UserId)";
          Command = new SqlCommand(Query,Connection);
          Command.CommandType = CommandType.Text;
          Command.Parameters.AddWithValue("@OtRefNo", aOperationSchedule.OtRefNo ?? "");
          Command.Parameters.AddWithValue("@OtDate", aOperationSchedule.OtDate);
          Command.Parameters.AddWithValue("@OPID", aOperationSchedule.Opid??"");
          Command.Parameters.AddWithValue("@CabinBed", aOperationSchedule.CabinBed??"");
          Command.Parameters.AddWithValue("@PatientName", aOperationSchedule.PatientName??"");
          Command.Parameters.AddWithValue("@FirstAssist", aOperationSchedule.FirstAssist??"");
          Command.Parameters.AddWithValue("@SurgeonName", aOperationSchedule.SurgeonName??"");
          Command.Parameters.AddWithValue("@SecondAssist", aOperationSchedule.SecondAssist??"");
          Command.Parameters.AddWithValue("@Anaesthesiologist", aOperationSchedule.Anaesthesiologist??"");
          Command.Parameters.AddWithValue("@OperationName", aOperationSchedule.OperationName??"");
          Command.Parameters.AddWithValue("@OperationTime", aOperationSchedule.OperationTime);
          Command.Parameters.AddWithValue("@ToTime", aOperationSchedule.ToTime);
          Command.Parameters.AddWithValue("@UserId", aOperationSchedule.UserId??"");
          int rowAffect=Command.ExecuteNonQuery();
          return rowAffect;
      }

      public int UpdateOperationSchedule(OperationSchedule aOperationSchedule)
      {
          Query = "UPDATE OperationSchedule SET OtDate=@OtDate,OPID=@OPID,CabinBed=@CabinBed,PatientName=@PatientName,FirstAssist=@FirstAssist,SurgeonName=@SurgeonName,SecondAssist=@SecondAssist,Anaesthesiologist=@Anaesthesiologist,OperationName=@OperationName,OperationTime=@OperationTime,ToTime=@ToTime,UserId=@UserId WHERE OtRefNo='" + aOperationSchedule.OtRefNo + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;

         // Command.Parameters.AddWithValue("@OtRefNo", aOperationSchedule.OtRefNo??"");
          Command.Parameters.AddWithValue("@OtDate", aOperationSchedule.OtDate);
          Command.Parameters.AddWithValue("@OPID", aOperationSchedule.Opid ?? "");
          Command.Parameters.AddWithValue("@CabinBed", aOperationSchedule.CabinBed??"");
          Command.Parameters.AddWithValue("@PatientName", aOperationSchedule.PatientName??"");
          Command.Parameters.AddWithValue("@FirstAssist", aOperationSchedule.FirstAssist ?? "");
          Command.Parameters.AddWithValue("@SurgeonName", aOperationSchedule.SurgeonName ?? "");
          Command.Parameters.AddWithValue("@SecondAssist", aOperationSchedule.SecondAssist ?? "");
          Command.Parameters.AddWithValue("@Anaesthesiologist", aOperationSchedule.Anaesthesiologist?? "");

          Command.Parameters.AddWithValue("@OperationName", aOperationSchedule.OperationName??"");
          Command.Parameters.AddWithValue("@OperationTime", aOperationSchedule.OperationTime);
          Command.Parameters.AddWithValue("@ToTime", aOperationSchedule.ToTime);
          Command.Parameters.AddWithValue("@UserId", aOperationSchedule.UserId??"");

          int rowAffect = Command.ExecuteNonQuery();
          return rowAffect;
      }
      public int DeleteOperationSchedule(OperationSchedule aOperationSchedule)
      {
          Query = "DELETE OperationSchedule WHERE OtRefNo=@Id";
          Command=new SqlCommand(Query,Connection);
          Command.CommandType = CommandType.Text;
          Command.Parameters.AddWithValue("@Id", 
              aOperationSchedule.OtRefNo);
          int rowAffect = Command.ExecuteNonQuery();
          return rowAffect;
      }
      public DataTable GetOpInfo()
      {
          Query = "SELECT * FROM tblOP ORDER BY OPID DESC";SqlCommand Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }

      public DataTable GenerateOTRef()
      {
          Query = "SP_GENERATE_OtReffNo"; 
          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }
      public DataTable GetOperationSchedule()
      {
          Query = "SELECT * FROM ViewGetConsultDoctor ORDER BY Id DESC";
          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }






    }
}
