using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;

namespace GHospital_Care.BAL.Manager
{
   public class BillCheckingManagerNICU
    {

       public DataTable GetConsultBill(string patientID)
       {
           return new BillCheckingGatewayNICU().GetConsultBill(patientID);
       }

    public DataTable GetOTMedicineBill(string patientID)
       {
           return new BillCheckingGatewayNICU().GetOTMedicineBill(patientID);
       }
       public DataTable GetPharmacyBill(string patientID)
       {
           return new BillCheckingGatewayNICU().GetPharmacyBill(patientID);
       }
       
       public DataTable GetPathologyBill(string patientID)
       {
           return new BillCheckingGatewayNICU().GetPathologyBill(patientID);
       }
  
       public DataTable GetHospitalServiceBill(string patientID)
       {
           return new BillCheckingGatewayNICU().GetHospitalServiceBill(patientID);
       }
       
       public DataTable GetOTServiceBill(string patientID)
       {
           return new BillCheckingGatewayNICU().GetOTServiceBill(patientID);
       }

       public DataTable GetNICUBILLInfo(DateTime admintdate1, DateTime admintdate2, bool chkValue)
       {

           return new BillCheckingGatewayNICU().GetNICUBillINFO(admintdate1, admintdate2, chkValue);
       }
    }
}
