using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class DischargeMannager
    {
        public DischargeBill VateCalcule(DischargeBill dischargeBill)
        {
            try
            {
                double totalBill = dischargeBill.TotalBill;
                double serviceCharge = (totalBill * dischargeBill.servicePercent) / 100;
                double taxAmount =( (totalBill + serviceCharge) * dischargeBill.Tax) / 100;
                
                dischargeBill.ServiceCharge = serviceCharge;
                dischargeBill.Tax = taxAmount;
                dischargeBill.SubTotal = taxAmount + dischargeBill.TotalBill+serviceCharge;
                dischargeBill.discount = dischargeBill.discount;
                double afterDiscount = Convert.ToDouble(dischargeBill.SubTotal - dischargeBill.discount - dischargeBill.AdvancedPayble);
                dischargeBill.NetPayble = afterDiscount;
               // dischargeBill.TotalBill = totalBill;
                return dischargeBill;
            }
            catch (Exception)
            {
                
           }
            return dischargeBill;  
        }


        public OutDoorBill VateCalculeOP(OutDoorBill outDoorBill)
        {
            try
            {
                double totalBill = outDoorBill.TotalBill;
                double serviceCharge = (totalBill * outDoorBill.servicePercent) / 100;
                double taxAmount = ((totalBill + serviceCharge) * outDoorBill.Tax) / 100;

                outDoorBill.ServiceCharge = serviceCharge;
                outDoorBill.Tax = taxAmount;
                outDoorBill.SubTotal = taxAmount + outDoorBill.TotalBill + serviceCharge;
                outDoorBill.discount = outDoorBill.discount;
                double afterDiscount = Convert.ToDouble(outDoorBill.SubTotal - outDoorBill.discount - outDoorBill.AdvancedPayble);
                outDoorBill.NetPayble = afterDiscount;
                // dischargeBill.TotalBill = totalBill;
                return outDoorBill;
            }
            catch (Exception)
            {

            }
            return outDoorBill;
        }


        public MessageModel SaveDischargeBill(DischargeBill aDischargeBill)
        {
            MessageModel message=new MessageModel();

            int count = new DischargeGateway().SaveDischargeBill(aDischargeBill);
            if (count>0)
            {
                message.MessageBody = "Save Successfully";
                message.MessageTitle = "Message";
            }
            return message;
            
        }

        public MessageModel UpdateDischargeBill(DischargeBill aDischargeBill)
        {
            MessageModel message = new MessageModel();

            int count = new DischargeGateway().DeleteDischargeBill(aDischargeBill);
            if (count > 0)
            {
                count = new DischargeGateway().SaveDischargeBill(aDischargeBill);
               
            }
            if (count > 0)
            {
                message.MessageBody = " Update Successfully";
                message.MessageTitle = "Message";
            }
            return message;

        }

        public DataTable ViewDicharge(DateTime fromDate, DateTime toDate)
        {
            return new DischargeGateway().ViewDicharge(fromDate, toDate);
        }

        public DataTable PrintDischare(string PatientID)
        {
            return new DischargeGateway().PrintDischarge(PatientID);
        }


        public DataTable PrintHospitalInflow(DateTime FromDate, DateTime ToDate)
        {
            return new DischargeGateway().HospitalInflow(FromDate, ToDate);
        }

        public DataTable PrintHospitalOutflow(DateTime FromDate, DateTime ToDate)
        {
            return new DischargeGateway().HospitalOutflow(FromDate, ToDate);
        }
        public DataTable BedHistory(string PatientID)
        {
            return new DischargeGateway().BedHistory(PatientID);
        }

        public DataTable AdvanceInfo(string PatientID)
        {
            return new DischargeGateway().AdvanceInfo(PatientID);
        }
    }
}
