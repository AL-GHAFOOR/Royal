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
    public class OutdoorPatientManager
    {private OutdoorPatientGatway aOutdoorPatientGatway;
        public DataTable GetAllDoctors()
        {
            aOutdoorPatientGatway = new OutdoorPatientGatway();
            DataTable dataTable = aOutdoorPatientGatway.GetAllDoctors();
            return dataTable;
        }
        //public DataTable GetDoctorById(DAL.Model.OutdoorPatient aOutdoorPatient)
        //{
        //    aOutdoorPatientGatway = new OutdoorPatientGatway();
        //    DataTable dataTable = aOutdoorPatientGatway.GetDoctorById(aOutdoorPatient);
        //    return dataTable;
        //}
        public DataTable GeneratePatientId()
        {
            aOutdoorPatientGatway = new OutdoorPatientGatway();
            DataTable data = aOutdoorPatientGatway.GeneratePatientId();
            return data;
        }
        public DataTable PopulateGridView(DateTime fromDate, DateTime ToDate)
        {
            aOutdoorPatientGatway = new OutdoorPatientGatway();
            DataTable dataTable = aOutdoorPatientGatway.PopulateGridView(fromDate, ToDate);
            return dataTable;
        }
        public MessageModel SaveOutdoorPatient(DAL.Model.OutdoorPatient aOutdoorPatient)
        {
                MessageModel aMessageModel = new MessageModel();
                aOutdoorPatientGatway = new OutdoorPatientGatway();


                DataTable data = new DataTable();
                data = aOutdoorPatientGatway.IsExist(aOutdoorPatient);
                if (data.Rows.Count > 0)
                {
                    aMessageModel.MessageTitle = "Warning";
                    aMessageModel.MessageBody = "This patient already exist. Press the refresh button. \n Thank You.";
                    return aMessageModel;
                }
                string message = Ischecked(aOutdoorPatient);
                if (message != "Checked")
                {
                    aMessageModel.MessageTitle = "Warning";
                    aMessageModel.MessageBody = message;
                    return aMessageModel;
                }

                if (aOutdoorPatientGatway.SaveOutdoorPatient(aOutdoorPatient) > 0)
                {
                  //int  saveCount = new IpdGateway().SavePatientServiceIPD(aOutdoorPatient.AService);
                    aMessageModel.MessageTitle = "Successful";
                    aMessageModel.MessageBody = "Outdoor patient information saved successfully.";
                }
                return aMessageModel;
        }
        public MessageModel UpdateOutdoorPatient(DAL.Model.OutdoorPatient aOutdoorPatient)
        {
            MessageModel aMessageModel = new MessageModel();
            aOutdoorPatientGatway = new OutdoorPatientGatway();

            //DataTable data = new DataTable();
            //data = aOutdoorPatientGatway.IsExist(aOutdoorPatient);
            //if (data.Rows.Count > 0)
            //{
            //    aMessageModel.MessageTitle = "Warning";
            //    aMessageModel.MessageBody = "This patient already exist. Press the refresh button. \n Thank You.";
            //    return aMessageModel;
            //}

            string message = Ischecked(aOutdoorPatient);
            if (message != "Checked")
            {
                aMessageModel.MessageTitle = "Warning";
                aMessageModel.MessageBody = message;
                return aMessageModel;
            }
            if (aOutdoorPatientGatway.UpdateOutdoorPatient(aOutdoorPatient) > 0)
            {
                aMessageModel.MessageTitle = "Successful";
                aMessageModel.MessageBody = "Outdoor patient information updated successfully.";
            }
            return aMessageModel;
        }
        public MessageModel DeleteOutdoorPatient(DAL.Model.OutdoorPatient aOutdoorPatient)
        {
            aOutdoorPatientGatway = new OutdoorPatientGatway();
            MessageModel aMessageModel = new MessageModel();
            if (aOutdoorPatientGatway.DeleteOutdoorPatient(aOutdoorPatient) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Birth info deleted successfully.";
            }
            return aMessageModel;
        }
        public string Ischecked(DAL.Model.OutdoorPatient aOutdoorPatient)
        {
            string message = "";
            if (aOutdoorPatient.Opid == string.Empty)
            {
                message = "OPID not found, Press the Refresh button.\n Thank You";
            }
            else if (aOutdoorPatient.TreatementType == null)
            {
                message = "Please select TreatementType \n Thank You";
            }
            else if (aOutdoorPatient.PatientName == null || aOutdoorPatient.PatientName == "")
            {
                message = "Please insert patient name. \n Thank You";
            }
            else if (aOutdoorPatient.GurdianName == null || aOutdoorPatient.GurdianName == "")
            {
                message = "Please insert gurdian name. \n Thank You";
            }
            else if (string.IsNullOrEmpty(aOutdoorPatient.Address))
            {
                message = "Please insert address. \n Thank You";
            }
            else if (string.IsNullOrEmpty(aOutdoorPatient.Phone))
            {
                message = "Please insert phone. \n Thank You";
            }
            else if (aOutdoorPatient.Age<0 || aOutdoorPatient.Age>150)
            {
                message = "Please insert valid age. \n Thank You";
            } 
            else if (aOutdoorPatient.BloodGroup==null)
            {
                message = "Please select Blood Group. \n Thank You";
            }
            else if (aOutdoorPatient.Gender == null)
            {
                message = "Please select Gender. \n Thank You";
            }
            else
            {
                message = "Checked";
            }
            return message;
        }

        public DataTable GetAllDoctorsById(string DoctorId)
        {
            aOutdoorPatientGatway = new OutdoorPatientGatway();
            DataTable dataTable = aOutdoorPatientGatway.GetAllDoctorsById(DoctorId);
            return dataTable;
        }
    }
}
