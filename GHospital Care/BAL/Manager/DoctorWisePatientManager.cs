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

    public class DoctorWisePatientManager : MessageModel
     {
         private DoctorWisePatientGatway aDoctorWisePatientGatway;

         public DataTable LoadDoctors()
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway=new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.LoadDoctors();
             return data;
         }
         public DataTable LoadPathology()
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.LoadPathology();
             return data;
         }

         public DataTable LoadRefferedInfo()
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.LoadRefferedInfo();
             return data;
         }
         public DataTable GridLoadRefferedBy(string RefferedBy)
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.GridLoadRefferedBy(RefferedBy);
             return data;
         }


         public DataTable GridLoadDutyDoctor(string Doctor)
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.GridLoadDutyDoctor(Doctor);
             return data;
         }
         public DataTable GridLoadDefault()
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.GridLoadDefault();
             return data;
         }

         public DataTable DueBillStatus(string Chk, DateTime FromDate, DateTime Todate)
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.DueStatus( Chk , FromDate, Todate);
             return data;
         }


         public DataTable DueBillStatusAllByReff( DateTime FromDate, DateTime Todate, string Reff)
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.DueStatusAllbyReff(FromDate, Todate, Reff);
             return data;
         }
         public DataTable GetPathologyPayment(DateTime FromDate, DateTime Todate)
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.GetPthologyPayment( FromDate, Todate);
             return data;
         }
         public DataTable GetCommissionReff()
         {
             return new DoctorWisePatientGatway().GetCommissionReff();
         }

         public DataTable GetPathologyVch()
         {
             return new DoctorWisePatientGatway().GetPathologyVch();
         }
         public DataTable DueBillStatusByReff(string Chk, DateTime FromDate, DateTime Todate, string Reff)
         {
             DataTable data = new DataTable();
             aDoctorWisePatientGatway = new DoctorWisePatientGatway();
             data = aDoctorWisePatientGatway.DueStatusByReff(Chk, FromDate, Todate,Reff);
             return data;
         }

         MessageModel messageModel = new MessageModel();
         public MessageModel SaveCommission(Comission aService)
         {
             
             int saveService = new DoctorWisePatientGatway().SaveCommission(aService);
             if (saveService > 0)
             {
                 messageModel.MessageBody = " save successfully!";
                 messageModel.MessageTitle = "Successfull";

             }
             return messageModel;
         }

         public MessageModel SavePathologyPayment(DAL.Model.Pathology aService)
         {

             int saveService = new DoctorWisePatientGatway().SavePathologyPayment(aService);
             if (saveService > 0)
             {
                 messageModel.MessageBody = " save successfully!";
                 messageModel.MessageTitle = "Successfull";

             }
             return messageModel;
         }

         public DataTable VewCommission(DateTime FromDate, DateTime Todate, string Reff)
         {
             return new DoctorWisePatientGatway().VewCommission(FromDate, Todate, Reff);
         }

         public DataTable PathologyLedger(DateTime FromDate, DateTime Todate, string Ledger)
         {
             return new DoctorWisePatientGatway().PathologyLedger(FromDate, Todate, Ledger);
         }
     }
}
