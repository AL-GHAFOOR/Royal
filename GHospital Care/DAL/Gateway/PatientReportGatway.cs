using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.MailServer;

namespace GHospital_Care.DAL.Gateway
{
    public class PatientReportGatway : GatwayConnection
    {
        public DataTable GetAllPatientStatus(DateTime fromdate, DateTime toDate)
        {
            try
            {
                DataTable dtDataTable = new DataTable();
                Query =
                    String.Format(
                        "select * from DailyPatientStatus where Convert(date,InputDate) between '{0}' and  '{1}'",
                        fromdate.Date, toDate.Date);
                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Reader = Command.ExecuteReader();
                dtDataTable.Load(Reader);
                return dtDataTable;

            }
            catch (Exception ex)
            {
                new MailServerConnection().SentMail(ex.GetBaseException().ToString());
                return null;
            }
        }


    }
}
