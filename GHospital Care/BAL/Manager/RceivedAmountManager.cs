using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    class RceivedAmountManager
    {
        readonly ReceivedAmountGateway rcvAmntGateway = new ReceivedAmountGateway();
        Patient patient = new Patient();

        public MessageModel SaveReceivedAmount(ReceivedAmount rcvAmnt)
        {
            string Message;
            MessageModel aMessageModel = new MessageModel();

            Message = Ischecked(rcvAmnt);

            if (Message != "Checked")
            {
                aMessageModel.MessageBody = Message;
                aMessageModel.MessageTitle = "Warning!";
                return aMessageModel;
            }
            int rowAffected = rcvAmntGateway.SaveReceivedAmount(rcvAmnt);

            if (rowAffected > 0)
            {
                aMessageModel.MessageBody = "Data Saved Successfully. \n Thank You";
                aMessageModel.MessageTitle = "Successful";
                return aMessageModel;
            }
            else
            {
                aMessageModel.MessageBody = "Saved to failed. Try again.";
                aMessageModel.MessageTitle = "Error!";
            }
            return aMessageModel;
        }





        public DataTable GetPatientIdFrmIndoorDataTable()
        {
            return rcvAmntGateway.GetPatientIdFrmIndoor();
        }

        public DataTable GetPatientIdFrmNICU()
        {
            return rcvAmntGateway.GetPatientIdFrmNICU();
        }
        public DataTable GetPatientIdFrmOPDDataTable()
        {
            return rcvAmntGateway.GetPatientIdFrmOutdoor();
        }

        public DataTable GetPatientIdFrmOurDoorDataTable()
        {
            return rcvAmntGateway.GetPatientIdFrmOutDoorBill();
        }


        public DataTable GetPatientIdFrmNICUDischargeDataTable()
        {
            return rcvAmntGateway.GetPatienDischareFrmNICU();
        }
        public DataTable GetPatientIdFrmDischargeDataTable()
        {
            return rcvAmntGateway.GetPatientIdFrmDischarge();
        }
        public DataTable GetPatientNamebyId(string patientId, string chk)
        {
            return rcvAmntGateway.GetPatientNameById(patientId, chk);
        }

        public DataTable GetPatientBillbyId(string patientId, string chk)
        {
            return rcvAmntGateway.GetPatientBillById(patientId, chk);
        }

        public DataTable GetConsultBill(string patientID)
        {
            return new ReceivedAmountGateway().GetConsultBill(patientID);
        }

        public DataTable GetOTMedicineBill(string patientID)
        {
            return new ReceivedAmountGateway().GetOTMedicineBill(patientID);
        }

        public DataTable GetOPMedicineBill(string patientID)
        {
            return new ReceivedAmountGateway().GetOPDMedicineBill(patientID);
        }

        public DataTable GetPatientAdvance(string patientID)
        {
            return new ReceivedAmountGateway().GetPatientAdvance(patientID);
        }

        public DataTable GetPharmacyBill(string patientID)
        {
            return new ReceivedAmountGateway().GetPharmacyBill(patientID);
        }

        public DataTable GetPathologyBill(string patientID)
        {
            return new ReceivedAmountGateway().GetPathologyBill(patientID);
        }

        public DataTable GetHospitalServiceBill(string patientID)
        {
            return new ReceivedAmountGateway().GetHospitalServiceBill(patientID);
        }

        public DataTable GetPatientServiceServiceBillNICU(string patientID)
        {
            return new ReceivedAmountGateway().GetHospitalServiceBillNICU(patientID);
        }

        public DataTable GetOTServiceBill(string patientID)
        {
            return new ReceivedAmountGateway().GetOTServiceBill(patientID);
        }


        public DataTable PopulateGridViewBillCollection(DateTime FromDate, DateTime ToDate, string Status)
        {
            return new ReceivedAmountGateway().PopulateGridViewBillCollection(FromDate, ToDate, Status);
        }

        public DataTable CollectionReport(string voucherNo)
        {
            return new ReceivedAmountGateway().CollectionReport(voucherNo);
        }


        public MessageModel DeleteeceivedAmount(ReceivedAmount rcvAmount)
        {
            MessageModel aMessageModel = new MessageModel();
            int rowAffect = rcvAmntGateway.DeleteeceivedAmount(rcvAmount);

            if (rowAffect > 0)
            {
                aMessageModel.MessageTitle = "Successful";
                aMessageModel.MessageBody = "Data Deleted Successfully.";
            }
            return aMessageModel;

        }



        public MessageModel UpdateReceivedAmount(ReceivedAmount rcvAmount)
        {
            int rowAffect = 0;
            MessageModel aMessageModel = new MessageModel();
            rowAffect = rcvAmntGateway.DeleteeceivedAmount(rcvAmount);

            if (rowAffect > 0)
            {
                if (rcvAmntGateway.SaveReceivedAmount(rcvAmount) > 0)
                {
                    aMessageModel.MessageTitle = "Successful";
                    aMessageModel.MessageBody = "Data Updated Successfully.";
                }
            }
            return aMessageModel;
        }




        private string Ischecked(ReceivedAmount rcvAmnt)
        {
            string message = "";
            if (String.IsNullOrEmpty(rcvAmnt.ColType))
            {
                message = "Please select collection type.\n Thank You";
            }
            else if (rcvAmnt.PatientId == String.Empty)
            {
                message = "Please select a Patient.\n Thank You";
            }
            else if (rcvAmnt.NetAmount == 0 || rcvAmnt.NetAmount == null)
            {
                message = "Please enter an amount. \n Thank You";
            }
            //GetValueOrDefault

            else
            {
                message = "Checked";
            }
            return message;
        }




    }
}
