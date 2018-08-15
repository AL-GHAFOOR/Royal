using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
   public class SerialManageGatway:GatwayConnection
    {
       public long GetFollowUpSerial(SerailGenerate serial)
       {
           Query = "select Count(Id) from tbl_PatientFollowup";
           Command=new SqlCommand(Query,Connection);

           long maxId = Convert.ToUInt32(Command.ExecuteScalar());
           return maxId;
       }
    }
}
