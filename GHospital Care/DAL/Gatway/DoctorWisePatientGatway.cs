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
    public class DoctorWisePatientGatway : GatwayConnection
    {
        public DataTable LoadDoctors()
        {
            Query = "SELECT * FROM tblDoctors";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable LoadRefferedInfo()
        {
            Query = "SELECT * FROM RefferedInfo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }


        public DataTable LoadPathology()
        {
            Query = "SELECT * FROM tblPathology";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable GridLoadDutyDoctor(string Doctor)
        {
            Query = "SELECT * FROM tbl_IndoorAdmission WHERE DutyDoctorId='" + Doctor + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable GridLoadRefferedBy(string RefferedBy)
        {
            Query = "SELECT * FROM ViewPatientByDoctorReffered WHERE RefferedBy='" + RefferedBy + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }



        public DataTable GridLoadDefault()
        {
            Query = "SELECT * FROM ViewPatientByDoctorReffered";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }


        public DataTable DueStatus(string Chk , DateTime FromDate, DateTime Todate)
        {
            if (Chk == "InDoor")
            {
                Query = "SELECT * FROM ViewDueBillStatus where DischargeDate between '"+FromDate+"' and '"+Todate+"'";      
            }
            if (Chk == "NICU")
            {
                Query = "SELECT * FROM ViewDueBillStatusNICU where DischargeDate between '" + FromDate + "' and '" + Todate + "'";  
            }
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable DueStatusAllbyReff(DateTime FromDate, DateTime Todate, string Reff)
        {
            Query = "SELECT * FROM ViewDuebillAll where DischargeDate between '" + FromDate + "' and '" + Todate + "'and RefferedBy = '" + Reff + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable GetPthologyPayment( DateTime FromDate, DateTime Todate)
        {
            Query = "SELECT * FROM viewPathologyPayment where date between '" + FromDate + "' and '" + Todate + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }


        public DataTable DueStatusByReff(string Chk, DateTime FromDate, DateTime Todate, string Reff)
        {
            if (Chk == "InDoor")
            {
                Query = "SELECT * FROM ViewDueBillStatus where DischargeDate between '" + FromDate + "' and '" + Todate + "' and RefferedBy = '" + Reff + "'";
            }
            if (Chk == "NICU")
            {
                Query = "SELECT * FROM ViewDueBillStatusNICU where DischargeDate between '" + FromDate + "' and '" + Todate + "' and RefferedBy = '" + Reff + "'";
            }
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        
        public int SaveCommission(Comission service)
        {
            int count = 0;
            Command = new SqlCommand("INSERT INTO tbl_CommssionMaster (CommissionID,Date,ReffId,Amount,Remarks,UserId,InWord,Status)"
                 + "VALUES(@CommissionID,@Date,@ReffId,@Amount,@Remarks,@UserId,@InWord,@Status)", Connection);
                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@CommissionID", service.CommissionId);
                Command.Parameters.AddWithValue("@Date", service.Date);
                Command.Parameters.AddWithValue("@ReffId", service.ReffId);
                Command.Parameters.AddWithValue("@Amount", service.Amount);
                Command.Parameters.AddWithValue("@Remarks", service.Remarks);
                Command.Parameters.AddWithValue("@UserId", service.UserId);
                Command.Parameters.AddWithValue("@InWord", service.Inword);
                Command.Parameters.AddWithValue("@Status", service.Status);
                count += Command.ExecuteNonQuery();
            
            return count;
        }
        public DataSet DbSelectQuery(string strQuery)
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

        public DataTable GetCommissionReff()
        {
            DataSet ds = DbSelectQuery("SP_GENERATE_Commission_Reff");
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable GetPathologyVch()
        {
            DataSet ds = DbSelectQuery("select Isnull(Max(Convert(int,VoucherNO))+1,1)VchNo from tblPathologyPayment");
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable VewCommission(DateTime FromDate, DateTime Todate, string Reff)
        {
            if (Reff == "All")
            {
                Query = "SELECT * FROM ViewCommission where date between '" + FromDate + "' and '" + Todate + "' ";
            }
            else
            {
                Query = "SELECT * FROM ViewCommission where date between '" + FromDate + "' and '" + Todate +"'" +
                        " and RefferedBy = '" + Reff + "'";
            }
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }


        public int SavePathologyPayment(Model.Pathology service)
        {
            int count = 0;
            Command = new SqlCommand("INSERT INTO tblPathologyPayment (VoucherNo,Date,Particulars,Amount,Description,UserId,InWord)"
                 + "VALUES(@VoucherNo,@Date,@Particulars,@Amount,@Description,@UserId,@InWord)", Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@VoucherNo", service.VoucherNo);
            Command.Parameters.AddWithValue("@Date", service.Date);
            Command.Parameters.AddWithValue("@Particulars", service.Particulars);
            Command.Parameters.AddWithValue("@Amount", service.Amount);
            Command.Parameters.AddWithValue("@Description", service.Description);
            Command.Parameters.AddWithValue("@UserId", service.UserId);
            Command.Parameters.AddWithValue("@InWord", service.Inword);
           count += Command.ExecuteNonQuery();

            return count;
        }

        public DataTable PathologyLedger(DateTime fromDate, DateTime ToDate, string ledger)
        {
            Query = "PathologyLedger '" + fromDate + "','" + ToDate + "','" + ledger + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
    }
}
