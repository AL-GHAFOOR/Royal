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


        public DataTable ViewConsultent(DateTime FromDate, DateTime ToDate)
        {
            Query = "select * from ViewCF_Form where Date between '" + FromDate + "' and '" + ToDate + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }


        public int SaveConsultantCall(ConsultantCall aConsultantCall)
        {
            Query = "INSERT INTO ConsultantCall (OPID,ConsultantId,VoucherNo)VALUES (@OPID,@ConsultantId,@VoucherNo)";

            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@OPID", aConsultantCall.OpId);
            Command.Parameters.AddWithValue("@ConsultantId", aConsultantCall.ConsultantId);
            Command.Parameters.AddWithValue("@VoucherNo", aConsultantCall.Id);

            int count = Command.ExecuteNonQuery();
            return count;
        }

        public int UpdateConsultantCall(ConsultantCall aConsultantCall)
        {
            Query = "Update ConsultantCall set OPID= @OPID,ConsultantId= @ConsultantId where VoucherNo= @VoucherNo";

            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@OPID", aConsultantCall.OpId);
            Command.Parameters.AddWithValue("@ConsultantId", aConsultantCall.ConsultantId);
            Command.Parameters.AddWithValue("@VoucherNo", aConsultantCall.Id);

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

        public int UpdateCosultBilling(ConsultBillService aConsultBillService)
        {
            Query = "Update tbl_ConsultBillService set OPID = @OPID ,ConsultId= @ConsultId,ConsultBillDate= @ConsultBillDate,ConFee= @ConFee,ConQty= @ConQty where VchNo = @VchNo ";

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

        public DataTable GetNicuPatient()
        {
            Query = "SELECT RegNo AS OPID,  PatientName,AdmitDate, Address FROM BedHistoryPatientInfoNICU where RegNo not in(select RegNo from tbl_DischargeBillNICU)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
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
