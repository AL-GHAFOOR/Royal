using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;

namespace GHospital_Care.BAL.Manager
{
    public class InDoorCollectionManager
    {
        public DataTable GetIpCollection(DateTime fromdate, DateTime todate,string C_Type=null)
        {
            if (C_Type != null)
            {
                return new IndoorPatientCollectionGateway().IPCollection(fromdate, todate, C_Type);

            }
            else
            {
                return new IndoorPatientCollectionGateway().IPCollection(fromdate, todate);
        
            }
        
        }
        public DataTable GetOPCollection(DateTime fromdate, DateTime todate, string C_Type=null)
        {
            if (C_Type==null)
            {
                return new IndoorPatientCollectionGateway().OPCollection(fromdate, todate);
            }
            else
            {
                  return new IndoorPatientCollectionGateway().OPCollection(fromdate, todate, C_Type);
            }
          
        }




        //************

        public DataTable GetNICUCollection(DateTime fromdate, DateTime todate, string C_Type = null)
        {
            if (C_Type != null)
            {
                return new IndoorPatientCollectionGateway().NICUCollection(fromdate, todate, C_Type);

            }
            else
            {
                return new IndoorPatientCollectionGateway().NICUCollection(fromdate, todate);

            }

        }
    }
}
