using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class OPD_Manager : MessageModel
    {
        OpdGateway opdGateway = new OpdGateway();
     
          public MessageModel PatientCreate(Patient patient)
        {
            MessageModel messageModel = new MessageModel();
            string message = Ischecked(patient);
            if (message != "Checked"){messageModel.MessageTitle = "Warning";messageModel.MessageBody = message;
                return messageModel;
            }

            if (opdGateway.PatientCreate(patient) > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "Outdoor patient information saved successfully!";return messageModel;
            }
            return messageModel;
        }


   public string Ischecked(Patient oPatient)
        {
            string message = "";
            if (oPatient.PatientName == string.Empty)
            {
                message = "Please Checked Patient Name";
            }
            else if (oPatient.Doctor == string.Empty)
            {
                message = "Please Checked Doctor";
            }
            else if (oPatient.Phone==string.Empty)
            {
                message = "Please Checked Phone Number.";
            }
            else if (oPatient.TreatmentType == string.Empty)
            {
                message = "Please Checked Treatment Type";
            }
            else if (oPatient.Address == string.Empty)
            {
                message = "Please Checked Address.";
            }
            else if (oPatient.BloodGroup == string.Empty)
            {
                message = "Please Checked Blood Group.";
            }
            else if (oPatient.Fees == string.Empty)
            {
                message = "Please Checked Doctor's Fees.";
            }
            else
            {
                message = "Checked";
            }

            return message;
        }

  public MessageModel UpdatePatient(Patient aPatient)
        {
            MessageModel messageModel = new MessageModel();
            string message = Ischecked(aPatient);
            if (message != "Checked")
            {
                messageModel.MessageTitle = "Warning";
                messageModel.MessageBody = message;
                return messageModel;
            }

            int rowEffect = opdGateway.UpdatePatient(aPatient);
            if (rowEffect > 0)
            {
                messageModel.MessageTitle = "Success!";
                messageModel.MessageBody = " Patient has been updated.";
                return messageModel;
            }
            messageModel.MessageTitle = "Error";
            messageModel.MessageBody = "Patient has not been updated.";
            return messageModel;
        }




        public Patient GetPatientInformationBySl(string patientSlNo)
        {
            DataTable table = new OpdGateway().GetPatientInformationBySl(patientSlNo);
            Patient patient = new Patient();

            if (table.Rows.Count > 0)
            {
                patient.PatientName = table.Rows[0]["PatientName"].ToString();
                patient.Address = table.Rows[0]["Address"].ToString();
                patient.Age = table.Rows[0]["Age"].ToString();
                patient.BloodGroup = table.Rows[0]["BloodGroup"].ToString();
                string docId = table.Rows[0]["Doctor"].ToString();
                Doctor doctor = new MedicalManager().GetAllDoctorbyId(docId);
                patient.Doctor = doctor.DoctorName; patient.Gender = table.Rows[0]["Gender"].ToString();
                patient.Mobile = table.Rows[0]["Mobile"].ToString();
                patient.Nationality = table.Rows[0]["Nationality"].ToString();
                patient.Phone = table.Rows[0]["Phone"].ToString();


            }
            return patient;
        }
        public string DeletePatient(Patient aPatient)
        {
            int rowAffect = opdGateway.DeletePatient(aPatient.OPID);
            if (rowAffect > 0)
            {
                return "Success! Patient has been deleted.";
            }
            return "Sorry! there is not found any Patient.";
        }

    public DataTable LoadSaveData()
        {
            return new OTGateway().Load_OT_Setup_AllData();
        }

        public DataTable GetAllOpdPatienSlNo()
        {
            return opdGateway.GetAllOpdPatienSlNo();
        }

        public DataTable GetIssueMedineStock()
        {
            return opdGateway.GetIssueMedineStock();
        }

        public MessageModel SaveOtIssueMedine(Service service)
        {
            int update = new OpdGateway().UpdateOPService(service);
            int cout = new OpdGateway().SaveOtIssueMedine(service);
            MessageModel messageModel = new MessageModel();
            if (cout > 0)
            {
                messageModel.MessageBody = "Save Issue Medinine";
                messageModel.MessageTitle = "Sucess";

            }

            return messageModel;


        }

        public DataTable SearchPatient(string PatientID)
        {
            DataTable dt = opdGateway.SearchPatient(PatientID);
            return dt;
        }
        public DataTable GetAllValueAsToday()
        {
            DataTable dt = opdGateway.GetAllValueAsToday();
            return dt;
        }


        public OutDoorBill GetDischargeBill(OutDoorBill outDoor)
        {

            DataTable dt = new OpdGateway().GetDischargeBillByPatientId(outDoor.OPID);
            if (dt != null && dt.Rows.Count > 0)
            {
                outDoor.OPID = dt.Rows[0]["OPID"].ToString();
                outDoor.PatientName = dt.Rows[0]["PatientName"].ToString();
                outDoor.DiscTime = "";
                //outDoor.DeisDate = Convert.ToDateTime(dt.Rows[0]["DischargeOn"]).Date;
                //outDoor.RegNo = dt.Rows[0]["RegNo"].ToString();
                outDoor.OTMedicine = Convert.ToDouble(dt.Rows[0]["OT_Med_Total"]);
                outDoor.HospitalCharge = Convert.ToDouble(dt.Rows[0]["Hsptl_Total"]);
                outDoor.OTservice = Convert.ToDouble(dt.Rows[0]["OT_Total"]);
                outDoor.PharmacyBill = Convert.ToDouble(dt.Rows[0]["Phar_Total"]);
                outDoor.Age = dt.Rows[0]["Age"].ToString();
                outDoor.BloodGroup = dt.Rows[0]["BloodGroup"].ToString();
                //  opidDischargeBill.OT_TOtalBill = dt.Rows[0]["OT_TOtalBill"].ToString();
                outDoor.PBill = Convert.ToDouble(dt.Rows[0]["Path_Total"].ToString());
                outDoor.NoOfDay = dt.Rows[0]["NoOfDay"].ToString();
                outDoor.TotalBedCharge = dt.Rows[0]["cabin_Total"].ToString();
                outDoor.TConsultBill = dt.Rows[0]["Con_Total"].ToString();
                outDoor.TotalBill = Convert.ToDouble(dt.Rows[0]["TotalBill"]);
                outDoor.AdvancedPayble = Convert.ToDouble(dt.Rows[0]["Advance"]); 
            }
           

            return outDoor;
        }

        public DataTable OutDoorBillPatient()
        {
            return new OpdGateway().OutDoorPatient();
        }

        public DataTable OutDoorBillListPatient(DateTime fromDate, DateTime ToDate)
        {
            return new OpdGateway().GetOutdoorPatientBillList(fromDate, ToDate);
        }

        public DataTable OPBillID()
        {
            return new OpdGateway().GetOPBillID();
        }

        public MessageModel SaveDischargeBill(OutDoorBill aDischargeBill)
        {
            MessageModel message = new MessageModel();

            int count = new OpdGateway().SaveDischargeBill(aDischargeBill);
            if (count > 0)
            {
                message.MessageBody = "OutDoor BILL Submited";
                message.MessageTitle = "Message";
            }
            return message;

        }
    }
}
