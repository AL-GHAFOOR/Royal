using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class NICUDischargeReqManager
    {
        public DataTable GetAllDischargeNICU()
        {
            return new NICUDischargeReqGateWay().GetIpdDischageNICU();
        }

        public NicuAddmission GetPatientInformationBySl(string selectId)
        {
            DataTable table = new NICUDischargeReqGateWay().GetNICUPatientInformationBySl(selectId);
            NicuAddmission patient = new NicuAddmission();

            if (table.Rows.Count > 0)
            {
                patient.PatientName = table.Rows[0]["PatientName"].ToString();
                patient.Address = table.Rows[0]["Address"].ToString();
                patient.Age = table.Rows[0]["Age"].ToString();
                patient.BabysBloodGroup = table.Rows[0]["BabysBloodGroup"].ToString();
                //string docId = table.Rows[0]["Doctor"].ToString();
                //Doctor doctor = new MedicalManager().GetAllDoctorbyId(docId);
                //patient.RefferedInfo = doctor.DoctorName;
                patient.Sex = table.Rows[0]["Sex"].ToString();
                patient.ContactNo = table.Rows[0]["ContactNo"].ToString();
                //patient.Na = table.Rows[0]["Nationality"].ToString();
                //patient.Phone = table.Rows[0]["Phone"].ToString();
                patient.FatherName = table.Rows[0]["FatherName"].ToString();
                patient.MotherName = table.Rows[0]["MotherName"].ToString();
                //patient.Gender = table.Rows[0]["Gender"].ToString();
                //patient. = table.Rows[0]["Relation"].ToString();
                //patient.Gurdian = table.Rows[0]["Gurdian"].ToString();
                patient.Bed = table.Rows[0]["BedName"].ToString();
                patient.AdmitDate = Convert.ToDateTime(table.Rows[0]["AdmitDate"]).Date;
                patient.RegNo = table.Rows[0]["RegNo"].ToString();
                patient.BirthWeight = table.Rows[0]["BirthWeight"].ToString();
                //patient.SelectedBed = table.Rows[0]["BedName"].ToString();
                patient.RegNo = selectId;

            }
            return patient;
        }

        public MessageModel SaveNICUDischargePatient(DischargeRequestNICU dischargePatient)
        {
            MessageModel model = new MessageModel();

            int count = new NICUDischargeReqGateWay().SaveNICUDischargePatient(dischargePatient);
            if (count > 0)
            {
                model.MessageBody = "Patient is Discharge ";
                model.MessageTitle = "Success";
            }
            return model;
        }
        private NICUDischargeReqGateWay aMedicalGatway;
        public MessageModel UpdateNICUDischargePatient(DischargeRequestNICU dischargePatient)
        {
            MessageModel model = new MessageModel();

            int count = new NICUDischargeReqGateWay().UpdateNICUDischargePatient(dischargePatient);
            if (count > 0)
            {
                model.MessageBody = "Patient is Discharge ";
                model.MessageTitle = "Success";
            }
            return model;
        }

        public DataTable GetDischargeInfoMaster(string FromDate, string ToDate)
        {
            DataTable data = new DataTable();

            data = new NICUDischargeReqManager().GetDischargeInfoMaster();
            return data;
        }

        public DataTable GetDischargeInfoMaster()
        {
            DataTable data = new DataTable();
            aMedicalGatway = new NICUDischargeReqGateWay();
            data = aMedicalGatway.GetDischargeInfoMaster();
            return data;
        }

        public DataTable GetDischargeDetails(DischargeRequestNICU _dischargePatient)
        {
            DataTable data = new DataTable();
            aMedicalGatway = new NICUDischargeReqGateWay();
            data = aMedicalGatway.GetDischargeDetails(_dischargePatient);
            return data;
        }

        public MessageModel DeleteNICUDischargePatient(DischargeRequestNICU dischargePatient)
        {
            MessageModel model = new MessageModel();

            int count = new NICUDischargeReqGateWay().DeleteNICUDischargePatient(dischargePatient);
            if (count > 0)
            {
                model.MessageBody = "NICU Discharge patient deleted successfully. \n Thank you.";
                model.MessageTitle = "Successfull";
            }
            return model;
        }

        public DataTable GetDischargeInfo(DischargeRequestNICU dischargePatient)
        {
            DataTable data = new DataTable();
            aMedicalGatway = new NICUDischargeReqGateWay();
            data = aMedicalGatway.GetDischargeInfo(dischargePatient);
            return data;
        }
    }
}
