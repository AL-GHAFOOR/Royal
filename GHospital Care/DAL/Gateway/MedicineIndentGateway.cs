using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gatway
{
    public class MedicineIndentGateway : GatwayConnection
    {
        public DataTable GetIndentNo()
        {
            Query = "EXEC SP_GENERATE_MedicineIndentNo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetIpPatient()
        {
            Query = "SELECT OPID AS PatientId,PatientName,InputDate AS AdmitDate, Address, WardOrCabin AS Cabin FROM HospitalBusinessOffice where OPID Not in (select OPID from tbl_DischargeBill)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public DataTable GetNicuPatient()
        {
            Query = "SELECT RegNo AS PatientId, PatientName AS PatientName,AdmitDate, Address FROM BedHistoryPatientInfoNICU where RegNo not in(select RegNo from tbl_DischargeBillNICU)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable GetMedicine()
        {
            Query = "SELECT * FROM productList_medicine ORDER BY ProductCode";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }



        public DataTable GetIndentMaster(DateTime FromDate, DateTime ToDate)
        {
            Query = "SELECT * FROM ViewIndentMaster where Date between '"+FromDate+"' and '"+ToDate+"'  ORDER BY Date";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }



        public DataTable GetIndentDetails(string Indent)
        {
            Query = "select I.ProductCode, p.ProductName,I.ProductQty, I.IndentNo, I.Note from MedicineIndentDetails I inner join productList_medicine P on p.ProductCode= I.ProductCode where IndentNo= '" + Indent + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public int SaveMedicineIndent(MedicineIndent aMedicineIndent)
        {
            int rowAffect = 0;
            Query = "INSERT INTO MedicineIndentPrimary(IndentNo,Date,PatientType,PatientID)" +
                    "VALUES(@IndentNo,@Date,@PatientType,@PatientID)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@IndentNo", aMedicineIndent.IndentNo??"");
            Command.Parameters.AddWithValue("@Date", aMedicineIndent.Date);
            Command.Parameters.AddWithValue("@PatientType", aMedicineIndent.PatientType??"");
            Command.Parameters.AddWithValue("@PatientID", aMedicineIndent.PatientId ?? "");
            rowAffect = Command.ExecuteNonQuery();

            return rowAffect;
        }


        public int UpdateMedicineIndent(MedicineIndent aMedicineIndent)
        {
            int rowAffect = 0;

            Query = "Update MedicineIndentPrimary set Date = @Date,PatientType = @PatientType,PatientID=@PatientID where IndentNo= @IndentNo ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@IndentNo", aMedicineIndent.IndentNo ?? "");
            Command.Parameters.AddWithValue("@Date", aMedicineIndent.Date);
            Command.Parameters.AddWithValue("@PatientType", aMedicineIndent.PatientType ?? "");
            Command.Parameters.AddWithValue("@PatientID", aMedicineIndent.PatientId ?? "");
            rowAffect = Command.ExecuteNonQuery();

            return rowAffect;
        }


        public int DeleteIndentDetails(MedicineIndent aMedicineIndent)
        {
            int count = 0;
            if (aMedicineIndent.DrugsDatatable != null)
            {
                    Query = "Delete MedicineIndentDetails where IndentNo= @IndentNo";
                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue(@"IndentNo", aMedicineIndent.IndentNo);
                    count += Command.ExecuteNonQuery();
                
            }
            return count;
        }


        public int SaveMedicineIndentDetails(MedicineIndent aMedicineIndent)
        {
            int count = 0;
            if (aMedicineIndent.DrugsDatatable!=null)
            {
                foreach (DataRow value in aMedicineIndent.DrugsDatatable.Rows)
                {
                    Query = "INSERT INTO MedicineIndentDetails(IndentNo,ProductCode,ProductQty)VALUES (@IndentNo,@ProductCode,@ProductQty)";
                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue(@"IndentNo", aMedicineIndent.IndentNo);
                    Command.Parameters.AddWithValue(@"ProductCode", value["ProductCode"]);
                    Command.Parameters.AddWithValue(@"ProductQty", value["Qty"]);
                   
                    count += Command.ExecuteNonQuery();
                }    
            }
            return count;
        }






        /*
          public int SaveFollowUp(Followup followup)
        {

            int count = 0;
            if (followup.ListOfDrug != null)
            {
                foreach (DataRow value in followup.ListOfDrug.Rows)
                {

                    Query = "INSERT INTO [tbl_PatientFollowup]([SerialFollowUp],[OPID],[Drug],[DoctorID],[Dous],[FollowupId],[BP],[ExtraNote],[ExtraNoteSpecial],[Date])" +
                           "VALUES(@SerialFollowUp,@OPID,@Drug, @DoctorID, @Dous,@FollowupId, @BP,@ExtraNote,@ExtraNoteSpecial,@Date)";
                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue(@"SerialFollowUp", followup.SerialId);
                    Command.Parameters.AddWithValue(@"OPID", followup.OPID);
                    Command.Parameters.AddWithValue(@"Drug", value["DrugId"]);
                    Command.Parameters.AddWithValue(@"DoctorID", followup.DocId);
                    Command.Parameters.AddWithValue(@"Dous", value["Dous"]);
                    Command.Parameters.AddWithValue(@"FollowupId", "");
                    Command.Parameters.AddWithValue(@"BP", followup.Bp);
                    Command.Parameters.AddWithValue(@"ExtraNote", value["ExtraNote"]);
                    Command.Parameters.AddWithValue(@"ExtraNoteSpecial", value["ExtraNoteSpecial"]);
                    Command.Parameters.AddWithValue(@"Date", followup.Date);

                    count += Command.ExecuteNonQuery();
                }    
            }
            return count;
        }
         
         
         
         
         */

    }
}
