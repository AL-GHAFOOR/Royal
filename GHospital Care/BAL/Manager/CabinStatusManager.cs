using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Gatway;

namespace GHospital_Care.BAL.Manager
{
    public class CabinStatusManager
    {

        public DataTable GetDischargeIndoorPatientForCabinStatus(DateTime FromDate, DateTime ToDate)
        {
            return new CabinStatusGateway().GetDischargeIndoorPatientForCabinStatus(FromDate, ToDate);
        }
    }
}
