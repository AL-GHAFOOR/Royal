using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
  public  class OTGateway:GatwayConnection
    {
      public int SaveOTSetup(OtSetup service)
      {
          Query = "INSERT INTO [tbl_OtSetup]([Pid],[OtReffNo],[Cabin_Bed],[Date],[SurgenId],[Anstology],[FirstAsst],[SecondAsst],[OpName],[OT_From],[OT_To],[userId])"

                  +
                  "VALUES (@Pid,@OtReffNo,@Cabin_Bed,@Date,@SurgenId,@Anstology,@FirstAsst,@SecondAsst,@OpName,@OT_From,@OT_To,@userId)";

          Command = new SqlCommand(Query,Connection);

          Command.CommandType = CommandType.Text;

          Command.Parameters.AddWithValue("@Pid", service.Pid);
          Command.Parameters.AddWithValue("@OtReffNo", service.OtReffNo);
          Command.Parameters.AddWithValue("@Cabin_Bed", service.Cabin_Bed);
          Command.Parameters.AddWithValue("@Date", service.Date);
          Command.Parameters.AddWithValue("@SurgenId", service.SurgenId);
          Command.Parameters.AddWithValue("@Anstology", service.Anstology);
          Command.Parameters.AddWithValue("@FirstAsst", service.FirstAsst);
          Command.Parameters.AddWithValue("@SecondAsst", service.SecondAsst);
          Command.Parameters.AddWithValue("@OpName", service.OpName);
          Command.Parameters.AddWithValue("@OT_From", service.OT_From);
          Command.Parameters.AddWithValue("@OT_To", service.OT_To);
          Command.Parameters.AddWithValue("@userId", service.userId??"");
          

          int count = Command.ExecuteNonQuery();
          return count;
      }

      public DataTable Load_OT_Setup_AllData()
      {
          Query = "Select * from tbl_OtSetup ";
          Command=new SqlCommand(Query,Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }

      public DataTable GetOtSetupByPatientId(string pid)
      {
          //Query = "Select * from OperationSchedule where OPID='" + pid + "'";
          Query = "Select * from OperationSchedule where OPID='" + pid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }
  }
}
