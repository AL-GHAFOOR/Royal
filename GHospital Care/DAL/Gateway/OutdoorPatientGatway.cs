using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;

namespace GHospital_Care.DAL.Gatway
{
   public class OutdoorPatientGatway:GatwayConnection
    {
       public DataTable GetAllDoctors()
       {
           Query = "SELECT DoctorID, DoctorName, Specialization FROM tblDoctors";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           Reader = Command.ExecuteReader();
           DataTable dataTable = new DataTable();
           dataTable.Load(Reader);return dataTable;
       }
       public DataTable GetAllDoctorsById(string DoctorId)
       {
           Query = "SELECT DoctorID, DoctorName, Specialization FROM tblDoctors WHERE DoctorID='" + DoctorId + "'";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           Reader = Command.ExecuteReader();
           DataTable dataTable = new DataTable();
           dataTable.Load(Reader); return dataTable;
       }
       public DataTable IsExist(Model.OutdoorPatient aOutdoorPatient)
       {
           Query = "SELECT OPID FROM tblop WHERE OPID='" + aOutdoorPatient.Opid + "'";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           Reader = Command.ExecuteReader();
           DataTable dataTable = new DataTable();
           dataTable.Load(Reader); return dataTable;
       }

       public DataTable IsExist_Update(Model.OutdoorPatient aOutdoorPatient)
       {
           Query = "SELECT OPID FROM tblop WHERE OPID <> '"+aOutdoorPatient.Opid+"'";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           Reader = Command.ExecuteReader();
           DataTable dataTable = new DataTable();
           dataTable.Load(Reader); return dataTable;
       }


       public DataTable PopulateGridView(DateTime fromDate, DateTime ToDate)
       {
           Query = "SELECT * FROM tblOP where Convert(date,ServiceDate) between '" + fromDate + "' and '" + ToDate + "' and OPID not in (select OPID from tbl_IndoorAdmission)  ORDER BY OPID DESC";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           Reader = Command.ExecuteReader();
           DataTable dataTable = new DataTable();
           dataTable.Load(Reader);
           return dataTable;
       }
       public DataTable GeneratePatientId()
       {
           Query = "SP_GENERATE_OPID";
           Command=new SqlCommand(Query,Connection);
           Command.CommandType = CommandType.Text;
           Reader = Command.ExecuteReader();
           DataTable data=new DataTable();
           data.Load(Reader);
           return data;
       }

       public int SaveOutdoorPatient(Model.OutdoorPatient aOutdoorPatient)
       {
           Query = "INSERT INTO tblOP (OPID,TreatmentType,PatientName,ServiceDate,Address,Gender,Age,Phone,Mobile,Nationality," +
                   "Doctor,Fees,BloodGroup,GurdianName,ContactPerson,RefferedBy)VALUES(@OPID,@TreatmentType,@PatientName,@ServiceDate,@Address,@Gender,@Age,@Phone,@Mobile,@Nationality,@Doctor,@Fees,@BloodGroup,@GurdianName,@ContactPerson,@RefferedBy)";
           Command=new SqlCommand(Query,Connection);
           Command.Parameters.AddWithValue("@OPID", aOutdoorPatient.Opid??"");
           Command.Parameters.AddWithValue("@TreatmentType", aOutdoorPatient.TreatementType ??"");
           Command.Parameters.AddWithValue("@PatientName", aOutdoorPatient.PatientName ??"");
           Command.Parameters.AddWithValue("@ServiceDate", aOutdoorPatient.ServiceDate);
           Command.Parameters.AddWithValue("@Address", aOutdoorPatient.Address ??"");
           Command.Parameters.AddWithValue("@Gender", aOutdoorPatient.Gender ??"");
           Command.Parameters.AddWithValue("@Age", aOutdoorPatient.Age);
           Command.Parameters.AddWithValue("@Phone", aOutdoorPatient.Phone ??"");
           Command.Parameters.AddWithValue("@Mobile", aOutdoorPatient.Mobile ??"");
           Command.Parameters.AddWithValue("@Nationality", aOutdoorPatient.Nationality ??"");
           Command.Parameters.AddWithValue("@Doctor", aOutdoorPatient.Doctor ??"");
           Command.Parameters.AddWithValue("@Fees", aOutdoorPatient.Fees ??"");
           Command.Parameters.AddWithValue("@BloodGroup", aOutdoorPatient.BloodGroup ??"");
           Command.Parameters.AddWithValue("@GurdianName", aOutdoorPatient.GurdianName ??"");
           Command.Parameters.AddWithValue("@ContactPerson", aOutdoorPatient.ContactPerson ??"");
           Command.Parameters.AddWithValue("@RefferedBy", aOutdoorPatient.RefferedBy ?? "");
           int rowAffect = Command.ExecuteNonQuery();
           return rowAffect;
       
       }
       public int UpdateOutdoorPatient(Model.OutdoorPatient aOutdoorPatient)
       {
           Query =
               "UPDATE tblOP SET TreatmentType=@TreatmentType,PatientName=@PatientName,ServiceDate=@ServiceDate,Address=@Address,Gender=@Gender,Age=@Age,Phone=@Phone,Mobile=@Mobile,Nationality=@Nationality," +
               "Doctor=@Doctor,Fees=@Fees,BloodGroup=@BloodGroup,GurdianName=@GurdianName,ContactPerson=@ContactPerson,RefferedBy=@RefferedBy WHERE OPID='" + aOutdoorPatient.Opid + "'";
           Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@TreatmentType", aOutdoorPatient.TreatementType??"");
           Command.Parameters.AddWithValue("@PatientName", aOutdoorPatient.PatientName ?? "");
           Command.Parameters.AddWithValue("@ServiceDate", aOutdoorPatient.ServiceDate);
           Command.Parameters.AddWithValue("@Address", aOutdoorPatient.Address ?? "");
           Command.Parameters.AddWithValue("@Gender", aOutdoorPatient.Gender ?? "");
           Command.Parameters.AddWithValue("@Age", aOutdoorPatient.Age);
           Command.Parameters.AddWithValue("@Phone", aOutdoorPatient.Phone ?? "");
           Command.Parameters.AddWithValue("@Mobile", aOutdoorPatient.Mobile ?? "");
           Command.Parameters.AddWithValue("@Nationality", aOutdoorPatient.Nationality ?? "");
           Command.Parameters.AddWithValue("@Doctor", aOutdoorPatient.Doctor ?? "");
           Command.Parameters.AddWithValue("@Fees", aOutdoorPatient.Fees ?? "");
           Command.Parameters.AddWithValue("@BloodGroup", aOutdoorPatient.BloodGroup ?? "");
           Command.Parameters.AddWithValue("@GurdianName", aOutdoorPatient.GurdianName ?? "");
           Command.Parameters.AddWithValue("@ContactPerson", aOutdoorPatient.ContactPerson ?? "");
           Command.Parameters.AddWithValue("@RefferedBy", aOutdoorPatient.RefferedBy ?? "");
           int rowAffect = Command.ExecuteNonQuery();
           return rowAffect;
       }
       public int DeleteOutdoorPatient(Model.OutdoorPatient aOutdoorPatient)
       {
           Query = "DELETE FROM tblop WHERE OPID='" + aOutdoorPatient.Opid + "'";
           Command = new SqlCommand(Query, Connection);
           int rowAffect = Command.ExecuteNonQuery();
           return rowAffect;
       }

    }
}
