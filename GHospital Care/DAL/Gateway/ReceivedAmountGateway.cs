using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    class ReceivedAmountGateway:GatwayConnection
    {
        public int SaveReceivedAmount(ReceivedAmount rcvAmount)
        {
            Command = new SqlCommand("SP_SAVE_tblIPVoucher", Connection) 
                { CommandType = CommandType.StoredProcedure };            
            Command.Parameters.Add("@VoucherNo", SqlDbType.Int);
            Command.Parameters.Add("@PatientId", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@PatientName", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@ColType", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@PayType", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@Discount", SqlDbType.Float, 50);
            Command.Parameters.Add("@NetAmount", SqlDbType.Float);
            Command.Parameters.Add("@Remarks", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@ReceivedBy", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@Status", SqlDbType.VarChar, 50);
            Command.Parameters.Add("@DiscountBy", SqlDbType.Int);
            Command.Parameters.Add("@Inword", SqlDbType.VarChar);

            Command.Parameters[0].Value = rcvAmount.VoucherNo;
            Command.Parameters[1].Value = rcvAmount.PatientId;
            Command.Parameters[2].Value = rcvAmount.PatientName;
            Command.Parameters[3].Value = rcvAmount.AdmissionDate;
            Command.Parameters[4].Value = rcvAmount.BillNo;
            Command.Parameters[5].Value = rcvAmount.ColType;
            Command.Parameters[6].Value = rcvAmount.PayType;
            Command.Parameters[7].Value = rcvAmount.Discount;
            Command.Parameters[8].Value = rcvAmount.NetAmount;
            Command.Parameters[9].Value = rcvAmount.Remarks;
            Command.Parameters[10].Value = rcvAmount.ReceivedBy;
            Command.Parameters[11].Value = rcvAmount.Status;
            Command.Parameters[12].Value = rcvAmount.RefferedBy;
            Command.Parameters[13].Value = rcvAmount.Inword;
                int count = Command.ExecuteNonQuery();
                return count;}

        public DataTable GetPatientIdFrmIndoor()
        {
            Query = "select Id, OPID from tbl_IndoorAdmission where OPID not in(select OPID from tbl_DischargeBill)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable GetPatientIdFrmNICU()
        {
            Query = "select Id, RegNo from NicuAdmission where RegNo not in(select OPID from tbl_DischargeBillNICU)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable PopulateGridViewBillCollection(DateTime FromDate, DateTime ToDate, string Status)
        {
            Query = @"SELECT *  FROM tblIPVoucher IP INNER JOIN tblop O ON O.OPID=IP.PatientId 
            WHERE Convert(date,AdmissionDate) BETWEEN '"+FromDate+"' AND '"+ToDate+"' AND Status ='"+Status+"'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable CollectionReport(string VoucherNo)
        {
            Query = @"SELECT *  FROM MoneyReceipt where VoucherNo = '"+VoucherNo+"'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }




        public DataTable GetPatientIdFrmOutdoor()
        {
            Query = "select Id, OPID from tblOP where OPID not in (select OPID from tbl_IndoorAdmission)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable GetPatientIdFrmDischarge()
        {
            Query = "select Id,OPID from tbl_DischargeBill where OPID not in (select RegNo from NicuInfo)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable GetPatienDischareFrmNICU()
        {
            Query = "select OPID from tbl_DischargeBillNICU where OPID Not in (select PatientID from tblIPVoucher where ColType= 'Settlement')";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetPatientIdFrmOutDoorBill()
        {
            Query = "select Id, OPID,NetPayble from tbl_OutDoorBill where OPID not in (select PatientID from tblIPVoucher)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            if (dtDataTable.Rows.Count > 0)
            {
                return dtDataTable;
            }else
            {
                dtDataTable.Rows.Add();
            }
            return dtDataTable;    
        }

        public DataTable GetPatientNameById(string patientId,string chk)
        {
            if (chk == "Indoor")
            {
                Query = "select PatientName from tbl_IndoorAdmission where OPID = '" + patientId + "'";    
            }
            else if (chk== "Outdoor")
            {

                Query = "select PatientName from tblOP where OPID = '" + patientId + "'"; 
            }
            else if (chk == "NICU")
            {

                Query = "select 'Baby of'+Space(1)+MotherName from NICUAdmission where RegNo = '" + patientId + "'";
            }
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetPatientBillById(string patientId,string chk)
        {
            if (chk == "Indoor")
            {
                Query = "select BillNo,NetPayble from tbl_DischargeBill where OPID = '" + patientId + "'";      
            }
            else if(chk== "Outdoor")
            {
                Query = "select BillNo,NetPayble from tbl_OutDoorBill where OPID = '" + patientId + "'";   
            }
            else if (chk == "NICU")
            {
                Query = "select BillNo,NetPayble from tbl_DischargeBillNICU where OPID = '" + patientId + "'";
            }
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetConsultBill(string patientID)
        {Query = "select Isnull(SUM(SubTotal),0)SubTotal, OPID from ConsultSrviceBill where OPID  ='" + patientID + "' group by OPID  ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable GetPharmacyBill(string patientID)
        {
            Query = "select Isnull(SUM(SubTotal),0)SubTotal,PatientId from IssueMedicineBill where PatientId  ='" + patientID + "' group by PatientId ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetPathologyBill(string patientID)
        {
            Query = "select Isnull(SUM(SubTotal),0)SubTotal, OPID from PatientServiceBill where OPID  ='" + patientID + "' and Catgory= 'Pathology' group by OPID ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetHospitalServiceBill(string patientID)
        {
            Query = "select Isnull(SUM(SubTotal),0)SubTotal, OPID from HospittalService where OPID  ='" + patientID + "' group by OPID ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetHospitalServiceBillNICU(string patientID)
        {
            Query = "select Isnull(SUM(SubTotal),0)SubTotal, OPID from PatientServiceBill where OPID  ='" + patientID + "' and Catgory= 'NICU' group by OPID ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetOTServiceBill(string patientID)
        {
            Query = "select Isnull(SUM(SubTotal),0)SubTotal, OPID from PatientServiceBill where OPID  ='" + patientID + "' and Catgory= 'OT' group by OPID ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable GetOTMedicineBill(string patientID)
        {
            Query = "select Isnull(sum(OT.Rate*OT.Qty),0) SubTotal,PatientId from tbl_OT_SeviceBill OT inner join productList P on p.ProductCode = OT.ProductId where PatientId = '" + patientID + "' group by PatientId ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


        public DataTable GetPatientAdvance(string patientID)
        {
            Query = "select Sum(NetAmount)SubTotal, PatientID from tblIPVoucher where ColType = 'Advance' and PatientID= '" + patientID + "'  group by PatientID";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetOPDMedicineBill(string patientID)
        {
            Query = "select sum(subTotal)Total,PatientId from IssueMedicineBill_OPD  where PatientId = '" + patientID + "' group by PatientId ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public int DeleteeceivedAmount(ReceivedAmount rcvAmount)
        {
            Query = "DELETE FROM tblIPVoucher WHERE VoucherNo='"+rcvAmount.VoucherNo+"'";
            Command=new SqlCommand(Query,Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

    }
}
