using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
  public  class DischargeGateway:GatwayConnection
    {
      public int SaveDischargeBill(DischargeBill aDischargeBill)
      {
          Query = "INSERT INTO [dbo].[tbl_DischargeBill]([BillNo],[Date],[OPID],[HospitalCharge],[NurseCharge],[DoctorCharge],[RoomBedCharge],[ServiceCharge]," +
                  "[MedicalCharge],[PathologyBill],[TotalBill],[SubTotal],[Discount],[AdvancePaid],[NetPayble],[BillType],[Remarks],[InwardText],[OTService],[OTMedicin],[vat])"
              +"VALUES(@BillNo,@Date,@OPID,@HospitalCharge,@NurseCharge,@DoctorCharge,@RoomBedCharge,@ServiceCharge,@MedicalCharge," +
              "@PathologyBill,@TotalBill,@SubTotal,@Discount,@AdvancePaid,@NetPayble,@BillType,@Remarks,@InwardText,@OTService,@OTMedicin,@vat)";
          Command=new SqlCommand(Query,Connection);
          Command.CommandType=CommandType.Text;Command.Parameters.AddWithValue(@"BillNo", aDischargeBill.BillNo);
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
          Command.Parameters.AddWithValue(@"Discount", aDischargeBill.discount);
          Command.Parameters.AddWithValue(@"AdvancePaid", aDischargeBill.AdvancedPayble);
          Command.Parameters.AddWithValue(@"NetPayble", aDischargeBill.NetPayble);
          Command.Parameters.AddWithValue(@"BillType", aDischargeBill.BillType);
          Command.Parameters.AddWithValue(@"Remarks", aDischargeBill.Remarks??"");
          Command.Parameters.AddWithValue(@"InwardText", aDischargeBill.InwardText);
          Command.Parameters.AddWithValue(@"OTService", aDischargeBill.OTService);
          Command.Parameters.AddWithValue(@"OTMedicin", aDischargeBill.OTMedicin);
          Command.Parameters.AddWithValue(@"vat", aDischargeBill.vat);
      
          int count = Command.ExecuteNonQuery();
          return count;


      }

      public int DeleteDischargeBill(DischargeBill aDischargeBill)
      {
          Query = "Delete Tbl_DischargeBill where BillNo = @BillNo";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          Command.Parameters.AddWithValue(@"BillNo", aDischargeBill.BillNo);
          int count = Command.ExecuteNonQuery();
          return count;


      }

      public DataTable ViewDicharge(DateTime fromDate, DateTime toDate)
      {
          DataTable dtDataTable = new DataTable();
          Query = "SELECT p.OPID, p.PatientName, p.BedName, D.* FROM tbl_DischargeBill D left join BedHistoryPatientInfo P on D.OPID = P.OPID   where D.Date between  '" + fromDate + "' and '" + toDate + "'  ";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }

      public DataTable PrintDischarge(string patientID)
      {
          DataTable dtDataTable = new DataTable();
          Query = "Sp_rptDischargeBill '" + patientID + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }


      public DataTable HospitalInflow(DateTime FromDate, DateTime ToDate)
      {
          DataTable dtDataTable = new DataTable();
          Query = " select * from ViewHospitalInflow where Convert(date,Date) between '" + FromDate + "' and '" + ToDate + "' order by Convert(date,Date)";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader); return dtDataTable;
      }


      public DataTable HospitalOutflow(DateTime FromDate, DateTime ToDate)
      {
          DataTable dtDataTable = new DataTable();
          Query = " select * from ViewHospitalOutFlow where Convert(date,Date) between '" + FromDate + "' and '" + ToDate + "' order by Convert(date,Date)";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader); return dtDataTable;
      }
      public DataTable BedHistory(string patientID)
      {
          DataTable dtDataTable = new DataTable();
          Query = "Select * from PatientBedCabinHistoryDischargeInfo where OPID ='" + patientID + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader); return dtDataTable;
      }

      public DataTable AdvanceInfo(string patientID)
      {
          DataTable dtDataTable = new DataTable();
          Query = "select * from tblIPVoucher where ColType = 'Advance' and Status = 'InDoor' and PatientID ='" + patientID + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader); return dtDataTable;
      }
    }
}
