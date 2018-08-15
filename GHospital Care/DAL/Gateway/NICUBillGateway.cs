using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using DevExpress.XtraLayout;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL
{
    class NICUBillGateway : GatwayConnection
    {

        public DataTable GetNICUAllSerialNo()
        {
            Query = "select * from BedHistoryPatientInfoNICU";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }

        public DataTable GetAllNICUserviceBill(string opid, string status, string service, DateTime IssueDate)
        {
            Query = "Sp_TotalService";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@opid", opid);
            Command.Parameters.AddWithValue("@status", status);
            Command.Parameters.AddWithValue("@service", service);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate.Date);
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;

        }

        public DataTable GetNICUPatientByID(string pid)
        {
            //Query = "Select * from OperationSchedule where OPID='" + pid + "'";
            Query = "select * from BedHistoryPatientInfoNICU where RegNo='" + pid + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }


        public DataTable NICUBillID()
        {
            Query = "SP_GENERATE_NICUBILLID";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable DischargeRequestNICU()
        {
            DataTable dtDataTable = new DataTable();
            Query = "select OPID from tbl_MasterDischargeFormNICU where OPID not in(Select OPID from tbl_DischargeBillNICU)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();

            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetDischargeBillNICUByPatient(string OPID)
        {
            Query = "sp_DisChargeTotalBillNICU";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@opid", OPID);
            Reader = Command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Reader);

            return dt;
        }


        public int SaveDischargeBill(DischargeBillNICU aDischargeBill)
        {
            Query = "INSERT INTO [dbo].[tbl_DischargeBillNICU]([BillNo],[Date],[OPID],[HospitalCharge],[NurseCharge],[DoctorCharge],[RoomBedCharge],[ServiceCharge]," +
                    "[MedicalCharge],[PathologyBill],[TotalBill],[SubTotal],[Discount],[AdvancePaid],[NetPayble],[BillType],[Remarks],[InwardText],[OTService],[OTMedicin],[vat])"
                + "VALUES(@BillNo,@Date,@OPID,@HospitalCharge,@NurseCharge,@DoctorCharge,@RoomBedCharge,@ServiceCharge,@MedicalCharge," +
                "@PathologyBill,@TotalBill,@SubTotal,@Discount,@AdvancePaid,@NetPayble,@BillType,@Remarks,@InwardText,@OTService,@OTMedicin,@vat)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text; Command.Parameters.AddWithValue(@"BillNo", aDischargeBill.BillNo);
            Command.Parameters.AddWithValue(@"Date", aDischargeBill.Date);
            Command.Parameters.AddWithValue(@"OPID", aDischargeBill.OPID);
            Command.Parameters.AddWithValue(@"HospitalCharge", aDischargeBill.HospitalCharge);
            Command.Parameters.AddWithValue(@"NurseCharge", aDischargeBill.NurseCharge);
            Command.Parameters.AddWithValue(@"DoctorCharge", aDischargeBill.DoctorCharge);
            Command.Parameters.AddWithValue(@"RoomBedCharge", aDischargeBill.RoomBedCharge);
            Command.Parameters.AddWithValue(@"ServiceCharge", aDischargeBill.ServiceCharge);
            Command.Parameters.AddWithValue(@"MedicalCharge", aDischargeBill.MedicalCharge);
            Command.Parameters.AddWithValue(@"PathologyBill", aDischargeBill.PathologyBill);
            Command.Parameters.AddWithValue(@"TotalBill", aDischargeBill.TotalBill);
            Command.Parameters.AddWithValue(@"SubTotal", aDischargeBill.SubTotal);
            Command.Parameters.AddWithValue(@"Discount", aDischargeBill.discount );
            Command.Parameters.AddWithValue(@"AdvancePaid", aDischargeBill.AdvancedPayble);
            Command.Parameters.AddWithValue(@"NetPayble", aDischargeBill.NetPayble);
            Command.Parameters.AddWithValue(@"BillType", aDischargeBill.BillType);
            Command.Parameters.AddWithValue(@"Remarks", aDischargeBill.Remarks ?? "");
            Command.Parameters.AddWithValue(@"InwardText", aDischargeBill.InwardText);
            Command.Parameters.AddWithValue(@"OTService", aDischargeBill.OTService);
            Command.Parameters.AddWithValue(@"OTMedicin", aDischargeBill.OTMedicin);
            Command.Parameters.AddWithValue(@"vat", aDischargeBill.vat);

            int count = Command.ExecuteNonQuery();
            return count;
            
        }

        public int SaveParticular( List<DischargeBillNICU> aBillNicu)
        {
            int count = 0;
            for (int i = 0; i < aBillNicu.Count; i++)
            {
                Query = "INSERT INTO [dbo].[tbl_DischargeNIcuDetails]([BillNo],[ServiceId],[ServiceName],[Status],[Total],[OPID])VALUES(@BillNo,@ServiceId,@ServiceName,@Status,@Total,@OPID)";
                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue(@"BillNo", aBillNicu[i].BillNo);
                Command.Parameters.AddWithValue(@"ServiceId", aBillNicu[i].ServiceId);
                Command.Parameters.AddWithValue(@"ServiceName", aBillNicu[i].ServiceName);
                Command.Parameters.AddWithValue(@"Status", aBillNicu[i].ServiceStatus);
                Command.Parameters.AddWithValue(@"Total", aBillNicu[i].Total);
                Command.Parameters.AddWithValue(@"OPID", aBillNicu[i].RegNo);
                count = Command.ExecuteNonQuery();
                
            }
            return count;
        }


        public DataTable PrintDischarge(string patientID)
        {
            DataTable dtDataTable = new DataTable();
            Query = "Sp_rptDischargeBillNICU '" + patientID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader); return dtDataTable;
        }


        public DataTable BedHistory(string patientID)
        {
            DataTable dtDataTable = new DataTable();
            Query = "Select * from PatientBedCabinHistoryDischargeInfoNICU where OPID ='" + patientID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader); return dtDataTable;
        }

        public DataTable AdvanceInfo(string patientID)
        {
            DataTable dtDataTable = new DataTable();
            Query = "select * from tblIPVoucher where ColType = 'Advance' and Status = 'NICU' and PatientID ='" + patientID + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader); return dtDataTable;
        }


        public DataTable ViewDicharge(DateTime fromDate, DateTime toDate)
        {
            DataTable dtDataTable = new DataTable();
            Query = "SELECT p.RegNo OPID, p.PatientName, p.BedName, D.* FROM tbl_DischargeBillNICU D inner join HospitalBusinessOfficeNICU P on D.OPID = P.RegNo where D.Date between  '" + fromDate + "' and '" + toDate + "'  ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

    }
}
