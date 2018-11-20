using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CrystalDecisions.ReportAppServer.DataDefModel;
using DevExpress.Xpo.DB.Helpers;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{public class MedicalManager : MessageManager
    {
        private MedicalGatway aMedicalGatway;
        public DataTable GetFollowupViewReport(string Department, string opid)
        {
            return new MedicalGatway().GetFollowupViewReport(Department, opid);
        }

        public DataTable GetAllDoctor()
        {
            return new MedicalGatway().GetAllDoctor();
        }


        public DataTable DischargeRequestPatient()
        {
            return new MedicalGatway().DischargeRequestPatient();
        }


        public DataTable getIPGischargeBillID()
        {
            return new MedicalGatway().IPDischargeBillID();
        }
        public DataTable GetAllCosultDoctor(string docId)
        {
            if (docId == null)
            {

                return new MedicalGatway().GetAllCosultDoctor();
            }
            else
            {
                return new MedicalGatway().GetAllCosultDoctor(docId);
            }

        }
        public Doctor GetAllDoctorbyId(string docId)
        {
            return new MedicalGatway().GetAllDoctorbyId(docId);
        }

        public DataTable GetAllDrug()
        {
            return new MedicalGatway().GetAllDrug();
        }
       
        public DataTable GetFollowUpCount(string PatientID, DateTime FollowUpdate)
        {
            return new MedicalGatway().GetFollowCount(PatientID, FollowUpdate);
        }
        public DataTable GetFollowupView(string Department)
        {
            return new MedicalGatway().GetFollowupView(Department);
        }

        public DataTable GetPatientInfo(string Patient)
        {
            return new MedicalGatway().GetIndoorPatientInformationBySl(Patient);
        }
         public DataTable GetTotalFollowUpCount(string PatientID)
        {
            return new MedicalGatway().GetTotalFollowCount(PatientID);
        }


         public string GetFlowupSerial()
         {
             long serial = new MedicalGatway().GetFollowUpSerial(new SerailGenerate());
             string dt = System.DateTime.Now.Year.ToString();
             if (serial > 0)
             {
                 return "# FSL-"+dt+"/0" + serial;
             }
             return "# FSL 0" + (serial + 1);
         }

        public MessageModel SaveFollowUp(Followup followup)
        {
            MessageModel model = new MessageModel();
            if (followup.DocId == "")
            {
                model.MessageBody = "Please select Doctor";
                model.MessageTitle = "Warning";
                return model;
            }
            else if (followup.Shift == "")
            {
                model.MessageBody = "Please select Shift";
                model.MessageTitle = "Warning";
                return model;
            }
            if (followup.OPID == "")
            {
                model.MessageBody = "Please select Patient";
                model.MessageTitle = "Warning";
                return model;
            }
            else
            {
                int count =  new MedicalGatway().SaveRegularFollowUp(followup);
                if (count > 0)
                {
                    count = new MedicalGatway().FOllowUpmaster(followup);
                }
                if (count > 0)
                {
                  int  count1 = new MedicalGatway().SaveFollowUp(followup);
                    if (count1 > 0)
                    {
                       
                    }
                }
                else
                {
                    model.MessageBody = "Please Input FollowUp Sheet";
                    model.MessageTitle = "Warning";    
                }
                if (count > 0)
                {
                    model.MessageBody = "Follow Up Saved Successfully";
                    model.MessageTitle = "Success";

                }    
            }
            return model;
        }

        public MessageModel SaveRegularFollowUp(Followup followup)
        {
            MessageModel model = new MessageModel();
            if (followup.DocId == "")
            {
                model.MessageBody = "Please select Doctor";
                model.MessageTitle = "Warning";
            }
            else if (followup.Shift == "")
            {
                model.MessageBody = "Please select Shift";
                model.MessageTitle = "Warning"; 
            }
            if (followup.OPID == "")
            {
                model.MessageBody = "Please select Patient";
                model.MessageTitle = "Warning"; 
            }
            else
            {
                int count = new MedicalGatway().SaveRegularFollowUp(followup);
                if (count > 0)
                {
                    model.MessageBody = "Follow Up data Saved";
                    model.MessageTitle = "Success";

                }     
            }
           
            return model;
        }

        public MessageModel UpdateFollowUp(Followup followup)
        {
            MessageModel model = new MessageModel();
            int count = new MedicalGatway().UpdateFollowUp(followup);
            if (count > 0)
            {
                model.MessageBody = "FollowUp data Updated";
                model.MessageTitle = "Success";
            }
            return model;
        }



        public MessageModel SaveDischargePatient(DischargePatient dischargePatient)
        {
            MessageModel model = new MessageModel();

            int count = new MedicalGatway().SaveDischargePatient(dischargePatient);
            if (count > 0)
            {
                model.MessageBody = "Patient is Discharge ";
                model.MessageTitle = "Success";
            }
            return model;
        }




        public MessageModel UpdateDischargePatient(DischargePatient dischargePatient)
        {
            MessageModel model = new MessageModel();

            int count = new MedicalGatway().UpdateDischargePatient(dischargePatient);
            if (count > 0)
            {
                model.MessageBody = "Patient is Discharge ";
                model.MessageTitle = "Success";
            }
            return model;
        }


        public MessageModel DeleteDischargePatient(DischargePatient dischargePatient)
        {
            MessageModel model = new MessageModel();

            int count = new MedicalGatway().DeleteDischargePatient(dischargePatient);
            if (count > 0)
            {
                model.MessageBody = "Discharge patient deleted successfully. \n Thank you.";
                model.MessageTitle = "Successfull";
            }
            return model;
        }


        public DischargeBill GetDischargeBill(DischargeBill opidDischargeBill)
        {
            DataTable dt = new MedicalGatway().GetDischargeBillByPatientId(opidDischargeBill.OPID);
            opidDischargeBill.OPID = dt.Rows[0]["OPID"].ToString();
            opidDischargeBill.PatientName = dt.Rows[0]["PatientName"].ToString();
            opidDischargeBill.DiscTime = dt.Rows[0]["DischargeTime"].ToString();
            opidDischargeBill.DeisDate = Convert.ToDateTime(dt.Rows[0]["DischargeOn"]).Date;
            opidDischargeBill.RegNo = dt.Rows[0]["RegNo"].ToString();
            opidDischargeBill.OTMedicine = Convert.ToDouble(dt.Rows[0]["OT_Med_Total"]);
            opidDischargeBill.HospitalCharge = Convert.ToDouble(dt.Rows[0]["Hsptl_Total"]);
            opidDischargeBill.OTservice = Convert.ToDouble(dt.Rows[0]["OT_Total"]);
            opidDischargeBill.PharmacyBill = Convert.ToDouble(dt.Rows[0]["Phar_Total"]);
            opidDischargeBill.Age = dt.Rows[0]["Age"].ToString();
            opidDischargeBill.BloodGroup = dt.Rows[0]["BloodGroup"].ToString();
          //  opidDischargeBill.OT_TOtalBill = dt.Rows[0]["OT_TOtalBill"].ToString();
            opidDischargeBill.PBill = Convert.ToDouble(dt.Rows[0]["Path_Total"].ToString());
            opidDischargeBill.NoOfDay = dt.Rows[0]["NoOfDay"].ToString();
            opidDischargeBill.TotalBedCharge = dt.Rows[0]["cabin_Total"].ToString();
            opidDischargeBill.TConsultBill = dt.Rows[0]["Con_Total"].ToString();
            opidDischargeBill.TotalBill = Convert.ToDouble(dt.Rows[0]["TotalBill"]);
            opidDischargeBill.AdvancedPayble = Convert.ToDouble(dt.Rows[0]["Advance"]);

            return opidDischargeBill;
        }


        public DischargeBill GetDischargeBill_Update(DischargeBill opidDischargeBill)
        {
            DataTable dt = new MedicalGatway().GetDischargeBillByPatientId_Update(opidDischargeBill.OPID);
            opidDischargeBill.OPID = dt.Rows[0]["OPID"].ToString();
            opidDischargeBill.PatientName = dt.Rows[0]["PatientName"].ToString();
            opidDischargeBill.DiscTime = dt.Rows[0]["DischargeTime"].ToString();
            opidDischargeBill.DeisDate = Convert.ToDateTime(dt.Rows[0]["DischargeOn"]).Date;
            opidDischargeBill.RegNo = dt.Rows[0]["RegNo"].ToString();
            opidDischargeBill.OTMedicine = Convert.ToDouble(dt.Rows[0]["OT_Med_Total"]);
            opidDischargeBill.HospitalCharge = Convert.ToDouble(dt.Rows[0]["Hsptl_Total"]);
            opidDischargeBill.OTservice = Convert.ToDouble(dt.Rows[0]["OT_Total"]);
            opidDischargeBill.PharmacyBill = Convert.ToDouble(dt.Rows[0]["Phar_Total"]);
            opidDischargeBill.Age = dt.Rows[0]["Age"].ToString();
            opidDischargeBill.BloodGroup = dt.Rows[0]["BloodGroup"].ToString();
            //  opidDischargeBill.OT_TOtalBill = dt.Rows[0]["OT_TOtalBill"].ToString();
            opidDischargeBill.PBill = Convert.ToDouble(dt.Rows[0]["Path_Total"].ToString());
            opidDischargeBill.NoOfDay = dt.Rows[0]["NoOfDay"].ToString();
            opidDischargeBill.TotalBedCharge = dt.Rows[0]["cabin_Total"].ToString();
            opidDischargeBill.TConsultBill = dt.Rows[0]["Con_Total"].ToString();
            opidDischargeBill.TotalBill = Convert.ToDouble(dt.Rows[0]["TotalBill"]);
            opidDischargeBill.AdvancedPayble = Convert.ToDouble(dt.Rows[0]["Advance"]);
            opidDischargeBill.Remarks = dt.Rows[0]["Remarks"].ToString();
            opidDischargeBill.BillNo = dt.Rows[0]["BillNo"].ToString();

            return opidDischargeBill;
        }
        private DataTable data;

        //public DataTable GetDischargeInfo()
        //{
        //    DataTable data = new DataTable();
        //    aMedicalGatway = new MedicalGatway();
        //    data = aMedicalGatway.GetDischargeInfo();
        //    return data;
        //}

        public DataTable GetDischargeInfo(DischargePatient dischargePatient)
        {
            DataTable data = new DataTable();
            aMedicalGatway = new MedicalGatway();
            data = aMedicalGatway.GetDischargeInfo(dischargePatient);
            return data;
        }

        public DataTable GetDischargeInfoMaster(string FromDate, string ToDate)
        {
            DataTable data=new DataTable();

            data=new MedicalManager().GetDischargeInfoMaster();
            return data;
        }

        public DataTable GetDischargeInfoMaster()
        {
            DataTable data = new DataTable();
            aMedicalGatway = new MedicalGatway();
            data = aMedicalGatway.GetDischargeInfoMaster();
            return data;
        }
        public DataTable GetDischargeDetails(DischargePatient _dischargePatient)
        {
            DataTable data = new DataTable();
            aMedicalGatway = new MedicalGatway();
            data = aMedicalGatway.GetDischargeDetails(_dischargePatient);
            return data;
        }




        public DataTable GetAllPatientFollowup(DateTime FromDate, DateTime Todate)
        {
            DataTable data = new DataTable();
            aMedicalGatway = new MedicalGatway();
            data = aMedicalGatway.GetAllPatientFollowup(FromDate, Todate);
            return data;
        }

        public DataTable UpdateFollowUpSheet( string patientID, string followUpID)
        {
            DataTable data = new DataTable();
            aMedicalGatway = new MedicalGatway();
            data = aMedicalGatway.UpdatefollowUPSheet( patientID, followUpID);
            return data;
        }

        public MessageModel DeletePatientFollowup(Followup followup)
        {
            MessageModel aMessageModel = new MessageModel();
            aMedicalGatway = new MedicalGatway();
            int count = aMedicalGatway.DeletePatientFollowup(followup);
            if (count > 0)
            {
                count = aMedicalGatway.DeletePatientFollowupMaster(followup);
            }
            if (count > 0)
            {
                count = aMedicalGatway.DeletePatientFollowupSheet(followup);
            }
            if (count > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Patient Followup deleted successfully.";
            }
            return aMessageModel;
        }

        public MessageModel DeletePatientFollowup1(Followup followup)
        {
            MessageModel aMessageModel = new MessageModel();
            aMedicalGatway = new MedicalGatway();
            int count = aMedicalGatway.DeletePatientFollowup(followup);
            if (count > 0)
            {
                count = aMedicalGatway.DeletePatientFollowupMaster(followup);
            }
            if (count > 0)
            {
                count = aMedicalGatway.DeletePatientFollowupSheet(followup);
            }
            if (count > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
               // aMessageModel.MessageBody = "Patient Followup deleted successfully.";
            }
            return aMessageModel;
        }

        public DataTable GetPatientFollowupByOpid(Followup followup)
        {
            DataTable data = new DataTable();
            aMedicalGatway = new MedicalGatway();
            data = aMedicalGatway.GetPatientFollowupByOpid(followup);
            return data;
        }




    }
}
