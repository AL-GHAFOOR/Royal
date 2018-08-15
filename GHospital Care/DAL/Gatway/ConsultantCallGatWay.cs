using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    public class ConsultantCallGatWay:GatwayConnection
    {
        public DataTable GetAllIpAdmissionInfo()
        {
            Query = "SELECT * FROM ViewGetAllIndoorPatient";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable GenerateVoucherNo()
        {
            Query = "EXEC SP_GENERATE_ServiceVchNo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }



        public int SaveConsultantCall(ConsultantCall aConsultantCall)
        {
            Query = "INSERT INTO ConsultantCall (OPID,ConsultantId)VALUES (@OPID,@ConsultantId)";

            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@OPID", aConsultantCall.OpId);
            Command.Parameters.AddWithValue("@ConsultantId", aConsultantCall.ConsultantId);

            int count = Command.ExecuteNonQuery();
            return count;
        }
        public int SaveCosultBilling(ConsultBillService aConsultBillService)
        {
            Query ="INSERT INTO [tbl_ConsultBillService] ([OPID],[ConsultId],[ConsultBillDate],[ConFee],[ConQty],[VchNo])" +
                    "VALUES(@OPID,@ConsultId,@ConsultBillDate,@ConFee,@ConQty,@VchNo)";

                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@OpId", aConsultBillService.OPID);
                Command.Parameters.AddWithValue("@ConsultId", aConsultBillService.ConsultId);
                Command.Parameters.AddWithValue("@ConsultBillDate", aConsultBillService.ConsultBillDate);
                Command.Parameters.AddWithValue("@ConFee", aConsultBillService.ConFee);
                Command.Parameters.AddWithValue("@ConQty", aConsultBillService.ConQty);
                Command.Parameters.AddWithValue("@VchNo", aConsultBillService.VchNo);
               int count = Command.ExecuteNonQuery();
   
            return count;
        }

        //Need to edit.... 
       
        //public int SaveCosultBilling(List<Patient> patient)
        //{
        //    int count = 0;
        //    foreach (Patient consultBillService in patient)
        //    {
        //        Query =
        //            "INSERT INTO [tbl_ConsultBillService] ([OPID],[ConsultId],[ConsultBillDate],[ConFee],[ConQty],[VchNo])" +
        //            "VALUES(@OPID,@ConsultId,@ConsultBillDate,@ConFee,@ConQty,@VchNo)";

        //        Command = new SqlCommand(Query, Connection);
        //        Command.CommandType = CommandType.Text;
        //        Command.Parameters.AddWithValue("@OpId", consultBillService.OPID);
        //        Command.Parameters.AddWithValue("@ConsultId", consultBillService.ConsultBillServices.ConsultId);
        //        Command.Parameters.AddWithValue("@ConsultBillDate", consultBillService.ConsultBillServices.ConsultBillDate);
        //        Command.Parameters.AddWithValue("@ConFee", consultBillService.ConsultBillServices.ConFee);
        //        Command.Parameters.AddWithValue("@ConQty", consultBillService.ConsultBillServices.ConQty);
        //        Command.Parameters.AddWithValue("@VchNo", consultBillService.ConsultBillServices.VchNo);
        //        count += Command.ExecuteNonQuery();
        //    }
        //    return count;
        //}

    }
}
