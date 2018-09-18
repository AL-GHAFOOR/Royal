using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CrystalDecisions.ReportAppServer.DataDefModel;
using DevExpress.Xpo.DB.Helpers;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    public class BedHistoryGateWay : GatwayConnection
    {
        public DataTable GetIpdBedorCabin(string Type, string AddType)
        {
            Query = "Free_OccupiedBed '" + Type + "','" + AddType + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }



        public DataTable GetIpdBedorCabinNICU(string Type, string AddType)
        {
            Query = "Free_OccupiedBed_NICU '" + Type + "','" + AddType + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable Count_Free_OccupiedBed(string Type, string AddType)
        {

            Query = "Count_Free_OccupiedBed '" + Type + "','" + AddType + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable Count_Free_OccupiedBed_NICU(string Type, string AddType)
        {

            Query = "Count_Free_OccupiedBed_NICU '" + Type + "','" + AddType + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable Count_OccupiedBed(string Type, string AddType)
        {
            Query = "Count_OccupiedCabinorBed '" + Type + "','" + AddType + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable Count_OccupiedBed_NICU(string Type, string AddType)
        {
            Query = "Count_OccupiedCabinorBed '" + Type + "','" + AddType + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetIpInfo(DateTime AdmintDate1, DateTime AdmintDate2, string chkvalue)
        {
            
            DataTable dtDataTable = new DataTable();
           // Query = "select * from HospitalBusinessOffice B where B.InputDate between  '" + AdmintDate1 + "' and '" + AdmintDate2 + "' and B.OPID NOT IN(SELECT OPID FROM dbo.tbl_DischargeBill) ";
            if (chkvalue == "Discharge")
            {
                Query = "select * from HospitalBusinessOfficeDishcarge B where Convert(date,B.DischargeDate) between  '" + AdmintDate1 + "' and '" + AdmintDate2 + "' and B.OPID IN(SELECT OPID FROM dbo.tbl_DischargeBill) ";

            }
            if (chkvalue == "Running")
            {
                Query = "select * from HospitalBusinessOffice B where B.InputDate between  '" + AdmintDate1 + "' and '" + AdmintDate2 + "' and B.OPID  NOT IN(SELECT OPID FROM dbo.tbl_DischargeBill) ";
            }
            if (chkvalue == "Req")
            {
                Query = "select * from HospitalBusinessOfficeDishcargeRequest B where B.DischargeDate between  '" + AdmintDate1 + "' and '" + AdmintDate2 + "' and B.OPID  NOT IN(SELECT OPID FROM dbo.tbl_DischargeBill) ";
            }
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable GetOPInfo(DateTime AdmintDate1, DateTime AdmintDate2, bool chkvalue)
        {
            DataTable dtDataTable = new DataTable();
            Query = "select * from viewOutDoorBill B where Convert(date,B.ServiceDate) between  '" + AdmintDate1.Date + "' and '" + AdmintDate2.Date + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader); 
            return dtDataTable;
        }


        public DataTable GetIndoorPatientList(DateTime AdmintDate1, DateTime AdmintDate2)
        {
            DataTable dtDataTable = new DataTable();
            Query = "select * from FloorWisePatientIPD B where Convert(date,B.InputDate) between  '" + AdmintDate1.Date + "' and '" + AdmintDate2.Date + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetOtInfo(DateTime AdmintDate1, DateTime AdmintDate2 )
        {
            DataTable dtDataTable = new DataTable();
            Query = "select * from OperationBill B where Convert(date,B.OtDate) between  '" + AdmintDate1.Date + "' and '" + AdmintDate2.Date + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader); return dtDataTable;
        }

        public DataTable Countpatient(DateTime AdmintDate1, DateTime AdmintDate2)
        {
            Query = "select Count(*) from BedHistoryPatientInfo where InputDate between  '" + AdmintDate1 + "' and '" +
                    AdmintDate2 + "'  ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable CountpatientDischarge(DateTime AdmintDate1, DateTime AdmintDate2)
        {
            Query = "SELECT COUNT(*) FROM HospitalBusinessOfficeDishcarge where Convert(date,DischargeDate) between  '" + AdmintDate1 + "' and '" +
                    AdmintDate2 + "'  ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable CountpatientNICU(DateTime AdmintDate1, DateTime AdmintDate2)
        {
            Query = "select Count(*) from BedHistoryPatientInfoNICU where AdmitDate between  '" + AdmintDate1 + "' and '" +
                    AdmintDate2 + "'  ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable CountpatientNICUDischarge(DateTime AdmintDate1, DateTime AdmintDate2)
        {
            Query = "select Count(*) from HospitalBusinessOfficeDichargeNICU where Convert(date,DischargeDate)  between  '" + AdmintDate1 + "' and '" +
                    AdmintDate2 + "'  ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetIpBedCabinList(string patientID)
        {
            Query = "select * from BedHistoryPatientInfo where OPID  ='" + patientID + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable GetIpBedCabinListNICU(string patientID)
        {
            Query = "select * from BedHistoryPatientInfoNICU where RegNo  ='" + patientID + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable GetNICUPatientList(DateTime fromDate, DateTime toDate)
        {
           Query = "select * from FloorWisePatientNICU where AdmitDate between  '" + fromDate + "' and '" + toDate + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public int UpdatePatientBedIPD(Patient patient)
        {
            Query ="Update tbl_IndoorAdmission  set WardOrCabin = @WardOrCabin,SelectedBed =@SelectedBed where OPID= @OPID ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@OPID", patient.OPID);
            Command.Parameters.AddWithValue("@SelectedBed", patient.SelectedBed);
            Command.Parameters.AddWithValue("@WardOrCabin", patient.WardOrCabin);
            int count = Command.ExecuteNonQuery();
            return count;
        }


        public int SaveIPDBedHistory(IPDBedHistory BedHistory)
        {
            Query = "insert into tbl_BedCabinShipment(BedorCabin,fromDate,Todate,PatientID,Rate,DayQty,UserId,TransferDate)  values(@BedorCabin,@fromDate,@Todate,@PatientID,@Rate,@DayQty,@UserId,@TransferDate) ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@BedorCabin", BedHistory.BedorCabin);
            Command.Parameters.AddWithValue("@fromDate", BedHistory.fromDate);
            Command.Parameters.AddWithValue("@Todate", BedHistory.Todate);
            Command.Parameters.AddWithValue("@PatientID", BedHistory.PatientID);
            Command.Parameters.AddWithValue("@Rate", BedHistory.Rate);
            Command.Parameters.AddWithValue("@DayQty", BedHistory.DayQty);
            Command.Parameters.AddWithValue("@UserId", BedHistory.UserId);
            Command.Parameters.AddWithValue("@TransferDate", BedHistory.TransferDate);
            int count = Command.ExecuteNonQuery();
            return count;
        }
    }
}


