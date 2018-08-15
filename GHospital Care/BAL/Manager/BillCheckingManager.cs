using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;

namespace GHospital_Care.BAL.Manager
{
   public class BillCheckingManager
    {

       public DataTable GetConsultBill(string patientID)
       {
           return new BillCheckingGateway().GetConsultBill(patientID);
       }

    public DataTable GetOTMedicineBill(string patientID)
       {
           return new BillCheckingGateway().GetOTMedicineBill(patientID);
       }
       public DataTable GetPharmacyBill(string patientID)
       {
           return new BillCheckingGateway().GetPharmacyBill(patientID);
       }
       
       public DataTable GetPathologyBill(string patientID)
       {
           return new BillCheckingGateway().GetPathologyBill(patientID);
       }
  
       public DataTable GetHospitalServiceBill(string patientID)
       {
           return new BillCheckingGateway().GetHospitalServiceBill(patientID);
       }
       
       public DataTable GetOTServiceBill(string patientID)
       {
           return new BillCheckingGateway().GetOTServiceBill(patientID);
       }
    }
}
