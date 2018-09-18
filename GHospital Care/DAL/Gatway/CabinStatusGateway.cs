using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;

namespace GHospital_Care.DAL.Gatway
{
    public class CabinStatusGateway : GatwayConnection
    {
        public DataTable GetDischargeIndoorPatientForCabinStatus(DateTime FromDate, DateTime ToDate)
        {
            DataTable dtDataTable = new DataTable();
            Query = "select * from HospitalBusinessOffice B where B.InputDate between  '" + FromDate + "' and '" + ToDate + "' and B.OPID NOT IN(SELECT OPID FROM dbo.tbl_DischargeBill) ";

            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }




    }
}
