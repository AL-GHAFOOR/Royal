using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;

namespace GHospital_Care.BAL.Manager
{
   public class PatientReportManager
    {
       public DataTable GetAllPatientStatus(DateTime fromDateTime,DateTime toDateTime)
       {
           return  new PatientReportGatway().GetAllPatientStatus(fromDateTime, toDateTime);

       }
    }
}
