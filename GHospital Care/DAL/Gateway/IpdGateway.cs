using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
  public  class IpdGateway:GatwayConnection
    {
      public int DeleteServiceByCategory(string service,string opid, string uniqkey)
      {
        
          if (service=="PService")
          {
              Query = "Delete tblPatientServiceBill where Id='"+uniqkey+"'";

          }else if (service=="Consult")
          {
              Query = "Delete tbl_ConsultBillService where Id='" + uniqkey + "'";
          }else if (service=="Pathology")
          {
              Query = "Delete tblPatientServiceBill where VchNo='" + uniqkey + "'";
          }
          else if (service == "Medicine")
          {
              Query = "Delete tbl_OutDoorMedineIssue where PatientId='" + opid + "' and VoucherNo='" + uniqkey + "';";
              Query += "Delete tbl_StockPosting where voucherType='Medicine Issue OP' and voucherNo='" + uniqkey + "';";


          }
         
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
           return Command.ExecuteNonQuery();
      }



      public DataTable DisChargeSummery_MedicineTakeInHopital(string opid)
      {
          Query = "select * from DisChargeSummery_MedicineTakeInHopital where OPID='"+opid+"'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }

      public DataTable DisChargeSummery(string opid)
      {
          Query = "select * from DisChargeSummery where OPID='" + opid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }

      public DataTable DisChargeSummery_Pathology(string opid)
      {
          Query = "select * from DisChargeSummery_Pathology where OPID='" + opid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }

      public DataTable DisChargeSummery_Treatment(string opid)
      {
          Query = "select * from DisChargeSummery_Treatment where OPID='" + opid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }
      public DataTable DisChargeSummery_ConsultanName(string opid)
      {
          Query = "select * from ConsultSrviceBill where OPID='" + opid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }
      public DataTable GetAllIpAdmissionInfo(DateTime fromdate, DateTime ToDate)
      {
          Query = "SELECT * FROM BedHistoryPatientInfo where OPID not in(select OPID from tbl_DischargeBill) and Convert(date,InputDate) between '" + fromdate + "' and '" + ToDate + "' ORDER BY OPID DESC";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }


      public DataTable GetAllIpAdmissionPatient(DateTime fromdate, DateTime ToDate)
      {
          Query = "SELECT * FROM HospitalBusinessOffice where Convert(date,InputDate) between '" + fromdate + "' and '" + ToDate + "' ORDER BY OPID DESC";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }


      public DataTable GetAllBeds(string ward)
      {
          Query = "select * from ViewAllBeds where BedId not in (select SelectedBed from tbl_IndoorAdmission where SelectedBed  != '')and WardName='"+ward+"'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }


      public DataTable GetAllBedNICU()
      {
          Query = "select * from ViewAllBeds where BedId not in (select Bed from NICUAdmission) and WardName= 'NICU'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }

      public DataTable GetAllCabin()
      {
          Query = "select * from ViewAllCabins where Convert(varchar(50),id) not in (select WardOrCabin from tbl_IndoorAdmission where SelectedBed ='')";
          Command = new SqlCommand(Query, Connection);Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }
      public DataTable GetAllCabinUpdate()
      {
          Query = "select * from ViewAllCabins ";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }

      public DataTable GetAllWard()
      {
          Query = "SELECT Id, WardName FROM Ward";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }

      public DataTable GetBedCabinHistory(string pID)
      {
          Query = "SELECT * FROM PatientBedCabinHistory where OPID = '" + pID + "' ";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }

      public DataTable GetBedCabinHistoryNICU(string pID)
      {
          Query = "SELECT * FROM PatientBedCabinHistoryNICU where OPID = '" + pID + "' ";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }
      public int SaveAdmissionPatient(Patient patient)
      {
          Query = "INSERT INTO tbl_IndoorAdmission (OPID,PatientName,Address,Gender,Age,Phone,Mobile,Nationality,Doctor,BloodGroup,FatherName,MotherName,Gurdian,Relation,WardOrCabin,DutyDoctorId,RefferedBy,SelectedBed,InputDate,paitentConditon,Religion,Department,Weight,RegNo,AdmissionTime,MaritalStatus,Area)"
              + "VALUES (@OPID,@PatientName,@Address,@Gender,@Age,@Phone,@Mobile,@Nationality,@Doctor,@BloodGroup,@FatherName,@MotherName,@Gurdian,@Relation,@WardOrCabin,@DutyDoctorId,@RefferedBy,@SelectedBed,@InputDate,@paitentConditon,@Religion,@Department,@Weight,@RegNo,@AdmissionTime,@MaritalStatus,@Area)";
          
          Command=new SqlCommand(Query,Connection);
          Command.CommandType = CommandType.Text;
          Command.Parameters.AddWithValue("@OPID", patient.OPID);
          Command.Parameters.AddWithValue("@PatientName", patient.PatientName);
          Command.Parameters.AddWithValue("@Address", patient.Address);
          Command.Parameters.AddWithValue("@Gender", patient.Gender);
          Command.Parameters.AddWithValue("@Age", patient.Age);
          Command.Parameters.AddWithValue("@Phone", patient.Mobile);
          Command.Parameters.AddWithValue("@Mobile", patient.Mobile);
          Command.Parameters.AddWithValue("@Nationality", patient.Nationality??"");
          Command.Parameters.AddWithValue("@Doctor", patient.DutyDoctorId??"");
          Command.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup??"");
          Command.Parameters.AddWithValue("@MotherName", patient.MotherName??"");
          Command.Parameters.AddWithValue("@FatherName", patient.FatherName??"");
          Command.Parameters.AddWithValue("@Gurdian", patient.Gurdian??"");
          Command.Parameters.AddWithValue("@DutyDoctorId", patient.DutyDoctorId??"");
          Command.Parameters.AddWithValue("@Relation", patient.Relation??"");
          Command.Parameters.AddWithValue("@WardOrCabin", patient.WardOrCabin??"");
          Command.Parameters.AddWithValue("@RefferedBy", patient.RefferedBy??"");
          Command.Parameters.AddWithValue("@SelectedBed", patient.SelectedBed??"");
          Command.Parameters.AddWithValue("@InputDate", patient.InputDate);
          Command.Parameters.AddWithValue("@paitentConditon", patient.PatientCondition??"");
          Command.Parameters.AddWithValue("@Religion", patient.Religion??"");
          Command.Parameters.AddWithValue("@Department", patient.Department ?? "");
          Command.Parameters.AddWithValue("@Weight", patient.Weight ?? "");
          Command.Parameters.AddWithValue("@RegNo", patient.RegNo ?? "");
          Command.Parameters.AddWithValue("@AdmissionTime", patient.AdmissionTime);
          Command.Parameters.AddWithValue("@MaritalStatus", patient.MaritalStatus);             
          Command.Parameters.AddWithValue("@Area", patient.Area);             
          int count=Command.ExecuteNonQuery();
          return count;
      }
      
      public int SavePatientServiceIPD(Service service)
      {
          int count = 0;
              Command = new SqlCommand("INSERT INTO dbo.tblPatientServiceBill (OPID,ServiceId,Rate,Qty,Total,userid,serviceDate)"
         + "VALUES(@OPID,@ServiceId,@Rate,@Qty,@Total,@userid,@serviceDate)", Connection);

              Command.CommandType = CommandType.Text;

              Command.Parameters.AddWithValue("@OPID", service.OPID);
              Command.Parameters.AddWithValue("@ServiceId", service.ServiceId);
              Command.Parameters.AddWithValue("@Rate", service.Rate);
              Command.Parameters.AddWithValue("@Total", service.Total);
              Command.Parameters.AddWithValue("@Qty", service.Qty);
              Command.Parameters.AddWithValue("@userid", "");
              Command.Parameters.AddWithValue("@serviceDate", service.IssueDate);
              count = Command.ExecuteNonQuery();
          
          return count;
      }
      public DataTable GetIndoorPatientInformationBySl(string patientSlNo)
      {
          Query = "select * from BedHistoryPatientInfo where OPID='" + patientSlNo + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          Reader = Command.ExecuteReader();
          DataTable dtDataTable = new DataTable();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }
      public DataTable GetIpdAllIpdPatient()
      {
          //Query = "SELECT Id, OPID,PatientName,Gender,Age, Address,BloodGroup, Phone,Nationality FROM tblOP WHERE TreatmentType='IPD' and OPID not in(select OPID from tbl_IndoorAdmission i)";
          Query = "SELECT  * FROM ViewAllIpPatientFrom_tblOP ORDER BY OPID DESC";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }
      public int SaveCosultBilling(List<Patient> patient)
      {
          int count = 0;
          foreach (Patient consultBillService in patient)
          {
              Query =
                  "INSERT INTO [tbl_ConsultBillService] ([OPID],[ConsultId],[ConsultBillDate],[ConFee],[ConQty],[VchNo])" +
                  "VALUES(@OPID,@ConsultId,@ConsultBillDate,@ConFee,@ConQty,@VchNo)";

              Command = new SqlCommand(Query, Connection);
              Command.CommandType = CommandType.Text;
              Command.Parameters.AddWithValue("@OpId", consultBillService.OPID);
              Command.Parameters.AddWithValue("@ConsultId", consultBillService.ConsultBillServices.ConsultId);
              Command.Parameters.AddWithValue("@ConsultBillDate", consultBillService.ConsultBillServices.ConsultBillDate);
              Command.Parameters.AddWithValue("@ConFee", consultBillService.ConsultBillServices.ConFee);
              Command.Parameters.AddWithValue("@ConQty", consultBillService.ConsultBillServices.ConQty);
              Command.Parameters.AddWithValue("@VchNo", consultBillService.ConsultBillServices.VchNo);
              count += Command.ExecuteNonQuery();
          }
          return count;
      }


      public DataTable GetOtServiceConsumListByPatientId(Service paitentId)
      {
          DataTable dtDataTable = new DataTable();
          try
          {
              Query = "Sp_PatitentWiseMedicineOt_OD";
              Command = new SqlCommand(Query, Connection);
              Command.Parameters.AddWithValue("@godownID", paitentId.GodownId);
              Command.Parameters.AddWithValue("@Pid", paitentId.OPID);
              Command.Parameters.AddWithValue("@IssueDate", paitentId.IssueDate);
              Command.CommandType = CommandType.StoredProcedure;
              Reader = Command.ExecuteReader();
             
              dtDataTable.Load(Reader);

              

          }
          catch (Exception)
          {
              
              //throw;
          }
          return dtDataTable;
      }

      public DataTable GetOtServiceConsumList(Service paitentId)
      {
          Query = "GodownWiseStockStatus";
          Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@godownID", paitentId.GodownId);
          Command.CommandType = CommandType.StoredProcedure;
          Reader = Command.ExecuteReader();
          DataTable dtDataTable = new DataTable();
          dtDataTable.Load(Reader);
          
          return dtDataTable;
      }

      public int UpdateAdmissionPatient(Patient patient)
      {
          Query = "UPDATE tbl_IndoorAdmission SET PatientName=@PatientName," +
                  "Address=@Address,Gender=@Gender,Age=@Age,Mobile=@mobile,Nationality=@nationality," +
                  "BloodGroup=@bloodGroup,FatherName=@fatherName,MotherName=@motherName," +
                  "Gurdian=@gurdian,Relation=@relation, Religion=@religion,RefferedBy=@refferedBy," +
                  "InputDate=@InputDate,paitentConditon=@paitentConditon, Department=@Department,Weight=@Weight,Doctor=@Doctor,DutyDoctorId=@DutyDoctorId,AdmissionTime=@AdmissionTime,Area=@Area WHERE OPID=@OPID";
          Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@OPID", patient.OPID);
          Command.Parameters.AddWithValue("@PatientName", patient.PatientName);
          Command.Parameters.AddWithValue("@Address", patient.Address);
          Command.Parameters.AddWithValue("@Gender", patient.Gender ?? "");
          Command.Parameters.AddWithValue("@Age", patient.Age ?? "");
          Command.Parameters.AddWithValue("@mobile", patient.Mobile ?? "");
          Command.Parameters.AddWithValue("@nationality", patient.Nationality ?? "");
          Command.Parameters.AddWithValue("@bloodGroup", patient.BloodGroup ?? "");
          Command.Parameters.AddWithValue("@fatherName", patient.FatherName ?? "");
          Command.Parameters.AddWithValue("@motherName", patient.MotherName ?? "");
          Command.Parameters.AddWithValue("@gurdian", patient.Gurdian ?? "");
          Command.Parameters.AddWithValue("@relation", patient.Relation ?? "");
          Command.Parameters.AddWithValue("@religion", patient.Religion ?? "");
          Command.Parameters.AddWithValue("@refferedBy", patient.RefferedBy ?? "");
          Command.Parameters.AddWithValue("@InputDate", patient.InputDate);
          Command.Parameters.AddWithValue("@paitentConditon", patient.PatientCondition ?? "");
          Command.Parameters.AddWithValue("@Department", patient.Department ?? "");
          Command.Parameters.AddWithValue("@Weight", patient.Weight);
          Command.Parameters.AddWithValue("@Doctor", patient.Doctor ?? "");
          Command.Parameters.AddWithValue("@DutyDoctorId", patient.DutyDoctorId);
          Command.Parameters.AddWithValue("@AdmissionTime", patient.AdmissionTime);
          Command.Parameters.AddWithValue("@Area", patient.Area);

          int rowAffect = Command.ExecuteNonQuery();
          return rowAffect;
      }

      public int DeleteAdmitedPatient(Patient aPatient)
      {
          Query = "DELETE FROM tbl_IndoorAdmission WHERE OPID = '" + aPatient.OPID + "'";
          Command = new SqlCommand(Query, Connection);
          int rowAffect = Command.ExecuteNonQuery();
          return rowAffect;
      }
      public DataTable GetIpdAllDoctor()
      {
          Query = "SELECT DoctorID, DoctorName FROM tblDoctors ORDER BY DoctorName ASC";
          Command = new SqlCommand(Query, Connection);
          Command.CommandType = CommandType.Text;
          DataTable dtDataTable = new DataTable();
          Reader = Command.ExecuteReader();
          dtDataTable.Load(Reader);
          return dtDataTable;
      }

      public DataTable GetIpGetRegID()
      {
          DataSet ds = DbSelectQuery("SP_GENERATE_Reg_IpAdmission");
          DataTable dt = ds.Tables[0];
          return dt;
      }


      public  DataSet DbSelectQuery(string strQuery)
{
          var dSet = new DataSet();
          try
          {
                  var da = new SqlDataAdapter(strQuery, Connection);
                  da.Fill(dSet);
                  return dSet;
          }

          catch (Exception)
          {
              return dSet;
          }
      }

      public DataTable DisChargeSummery_MedicineTakeInHopitalNICU(string opid)
      {
          Query = "select * from DisChargeSummery_MedicineTakeInHopital where OPID='" + opid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }

      public DataTable DisChargeSummery_TreatmentNICU(string opid)
      {
          Query = "select * from DisChargeSummery_TreatmentNICU where OPID='" + opid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }

      public DataTable DisChargeSummeryNICU(string opid)
      {
          Query = "select * from DisChargeSummeryNICU where OPID='" + opid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }

      public DataTable DataSetAdvice(string opid)
      {
          Query = "select * from tbl_AdviceRecord where PatientId='" + opid + "'";
          Command = new SqlCommand(Query, Connection);
          Command.CommandText = Query;
          Reader = Command.ExecuteReader();
          DataTable data = new DataTable();
          data.Load(Reader);
          return data;
      }
    }
}

