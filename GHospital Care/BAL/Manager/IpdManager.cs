using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class IpdManager : MessageModel
    {
        public DataTable GetAllIpAdmissionInfo(DateTime fromdate, DateTime ToDate)
        {

            return new IpdGateway().GetAllIpAdmissionInfo(fromdate, ToDate);
        }
        public DataTable GetIpdAllDoctor()
        {
            return new IpdGateway().GetIpdAllDoctor();
        }

        public DataTable GetIpRegID()
        {
            return new IpdGateway().GetIpGetRegID();
        }

        public MessageModel DeleteAdmitedPatient(Patient aPatient)
        {
            aIpdGateway = new IpdGateway();
            MessageModel messageModel = new MessageModel();
            if (aIpdGateway.DeleteAdmitedPatient(aPatient) > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "Indoor patient information Deleted successfully!";
            }
            return messageModel;
        }
        public DataTable GetAllBeds(string ward)
        {
            aIpdGateway = new IpdGateway();
            DataTable dt = aIpdGateway.GetAllBeds(ward);
            return dt;
        }

        public DataTable GetAllCabin()
        {
            return new IpdGateway().GetAllCabin();
        }

        public DataTable GetAllWard()
        {
            return new IpdGateway().GetAllWard();
        }
        public DataTable GetBeadCabinHistory(String PID)
        {
            return new IpdGateway().GetBedCabinHistory(PID);
        }
        public DataTable GetAllDischargeIP()
        {
            return new OpdGateway().GetIpdDischageIp();
        }

        public DataTable GetAllConsultant()
        {
            return new OpdGateway().GetConsultant();
        }

        public DataTable GetAllIpdPatientSl()
        {
            return new OpdGateway().GetIpdAllSerialNo();
        }

        public DataTable GetAllNICUpatientSl()
        {
            return new OpdGateway().GetNICUPatienSlNo();
        }
        public DataTable GetIpdAllIpdPatient()
        {
            return new IpdGateway().GetIpdAllIpdPatient();
        }
        IpdGateway aIpdGateway=new IpdGateway();
        
        public MessageModel UpdateAdmissionPatient(Patient patient, DAL.Model.OutdoorPatient aOutdoorPatient)
        {
            aIpdGateway = new IpdGateway();
            MessageModel aMessageModel = new MessageModel();
            int saveCount = 0;

            
            OutdoorPatientGatway aOutdoorPatientGatway = new OutdoorPatientGatway();
            DataTable data = new DataTable();
            data = aOutdoorPatientGatway.IsExist(aOutdoorPatient);
            if (data.Rows.Count > 0)
            {
                saveCount = aIpdGateway.UpdateAdmissionPatient(patient);
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Indoor patient information updated successfully!";
                return aMessageModel;
            }
            else
            {
                saveCount = aIpdGateway.UpdateAdmissionPatient(patient);
                saveCount = new OutdoorPatientGatway().UpdateOutdoorPatient(aOutdoorPatient);
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Indoor patient information updated successfully!";

            }
            return aMessageModel;
        }
        private string Ischecked(Patient patient)
        {
            string message = "";
            if (patient.OPID == string.Empty)
            {
                message = "OPID not found, Press the Refresh button.\n Thank You";
            }
            else if (patient.PatientName == String.Empty)
            {
                message = "Please insert patient name. \n Thank You";
            }
            else if (patient.Gurdian == String.Empty)
            {
                message = "Please insert gurdian name. \n Thank You";
            }
            else if (patient.Relation == String.Empty)
            {
                message = "Please insert gurdian relation. \n Thank You";
            }
            else if (string.IsNullOrEmpty(patient.Age) || (Convert.ToInt32(patient.Age) > 150) || (Convert.ToInt32(patient.Age) < 0))
            {
                message = "Please insert valid age. \n Thank You";
            }
            else if (string.IsNullOrEmpty(patient.Phone))
            {
                message = "Please insert valid phone no. \n Thank You";
            }
            else if (string.IsNullOrEmpty(patient.MaritalStatus))
            {
                message = "Please select Marital Status. \n Thank You";
            }
            else if (string.IsNullOrEmpty(patient.Nationality))
            {
                message = "Please write nationality. \n Thank You";
            }
            else if (string.IsNullOrEmpty(patient.Gender))
            {
                message = "Please select Gender. \n Thank You";
            }
            else if (string.IsNullOrEmpty(patient.BloodGroup))
            {
                message = "Please select Blood Group. \n Thank You";
            }
            else
            {
                message = "Checked";
            }
            return message;
        }
        public MessageModel SaveIpdPatient(Patient patient, Service service, DAL.Model.OutdoorPatient aOutdoorPatient)
        {
            int saveCount = 0;
            MessageModel aMessageModel = new MessageModel();
            string message = Ischecked(patient);
            if (message != "Checked")
            {
                aMessageModel.MessageTitle = "Warning";
                aMessageModel.MessageBody = message;
                return aMessageModel;
            }

            
            OutdoorPatientGatway aOutdoorPatientGatway = new OutdoorPatientGatway();
            DataTable data = new DataTable();
            data = aOutdoorPatientGatway.IsExist(aOutdoorPatient);
            if (data.Rows.Count > 0)
            {
                saveCount = new IpdGateway().SaveAdmissionPatient(patient);
                saveCount = new IpdGateway().SavePatientServiceIPD(service);
                if (saveCount > 0)
                {
                    aMessageModel.MessageTitle = "Successful";
                    aMessageModel.MessageBody = "Indoor patient information saved successfully!";
                }
                return aMessageModel;
            }
            else
            {
                saveCount = new IpdGateway().SaveAdmissionPatient(patient);
                saveCount = new IpdGateway().SavePatientServiceIPD(service);
                saveCount = new OutdoorPatientGatway().SaveOutdoorPatient(aOutdoorPatient);
                if (saveCount > 0)
                {
                    aMessageModel.MessageTitle = "Successful";
                    aMessageModel.MessageBody = "Indoor patient information saved successfully!";
                }
                return aMessageModel;
            }
        }



        public Patient GetPatientInformationBySl(string selectId)
        {
            DataTable table = new IpdGateway().GetIndoorPatientInformationBySl(selectId);
            Patient patient = new Patient();

            if (table.Rows.Count > 0)
            {
                patient.PatientName = table.Rows[0]["PatientName"].ToString();
                patient.Address = table.Rows[0]["Address"].ToString();
                patient.Age = table.Rows[0]["Age"].ToString();
                patient.BloodGroup = table.Rows[0]["BloodGroup"].ToString();
                string docId = table.Rows[0]["Doctor"].ToString();
                Doctor doctor = new MedicalManager().GetAllDoctorbyId(docId);
                patient.Doctor = doctor.DoctorName;
                patient.Gender = table.Rows[0]["Gender"].ToString();
                patient.Mobile = table.Rows[0]["Mobile"].ToString();
                patient.Nationality = table.Rows[0]["Nationality"].ToString();
                patient.Phone = table.Rows[0]["Phone"].ToString();
                patient.FatherName = table.Rows[0]["FatherName"].ToString();
                patient.MotherName = table.Rows[0]["MotherName"].ToString();
                patient.Gender = table.Rows[0]["Gender"].ToString();
                patient.Relation = table.Rows[0]["Relation"].ToString();
                patient.Gurdian = table.Rows[0]["Gurdian"].ToString();
                patient.SelectedBed = table.Rows[0]["BedName"].ToString();
                patient.InputDate = Convert.ToDateTime(table.Rows[0]["InputDate"]).Date;
                patient.RegNo = table.Rows[0]["RegNo"].ToString();
                patient.Weight = table.Rows[0]["Weight"].ToString();
                patient.SelectedBed = table.Rows[0]["BedName"].ToString();
                patient.OPID = selectId;

            }
            return patient;
        }
        List<OT_Consump> ConsumeList = new List<OT_Consump>();
        public List<OT_Consump> GetOtServiceConsumListByPatientId(Service paitentId)
        {
            try
            {
                DataTable list = new IpdGateway().GetOtServiceConsumListByPatientId(paitentId);
                foreach (DataRow dataRow in list.Rows)
                {
                    ConsumeList.Add(new OT_Consump { batchId = dataRow["batchId"].ToString(), ProductId = dataRow["ProductId"].ToString(), ProductName = dataRow["ProductName"].ToString(), Qty = Convert.ToInt16(dataRow["Qty"]), Rate = Convert.ToDecimal(dataRow["Rate"]), IssueDate = Convert.ToDateTime(dataRow["IssueDate"]), VoucherNo = Convert.ToInt64(dataRow["voucherNo"]) });

                }
                ConsumeList.Add(new OT_Consump());

                return ConsumeList;
            }
            catch (Exception)
            {
                return null;
            }
           
        }
        public DataTable OT_StockMedicine(Service paitentId)
        {
            DataTable dt = new IpdGateway().GetOtServiceConsumList(paitentId);
            return dt;
        }
        public MessageModel SaveCosultBilling(List<Patient> patient, Service service)
        {
            //Service service = new Service() { OPID = patient[0].OPID };

            //int IsExist = new ServiceManager().UpdateService("ConsultService", service);
            //int saveCount = new IpdGateway().SaveCosultBilling(patient);
            //MessageModel messageModel = new MessageModel();
            //if (saveCount > 0)
            //{

            //    messageModel.MessageTitle = "Successfull";
            //    messageModel.MessageBody = "Indoor Patient Consult Billing  information saved successfully!";

            //}
            //return messageModel;


            int IsExist = new ServiceManager().UpdateService("ConsultService", service);
            int saveCount = new IpdGateway().SaveCosultBilling(patient);
            MessageModel messageModel = new MessageModel();
            if (saveCount > 0)
            {

                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "Indoor Patient Consult Billing  information saved successfully!";
                
            }
            return messageModel;
        }

       
    }
}
