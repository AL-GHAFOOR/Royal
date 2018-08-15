using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    public class ServiceGateway : GatwayConnection
    {
        public int DeleteService(Service service)
        {
            Query = "DELETE tblServices WHERE ID='" + service.ID + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

        public DataTable SaveGetOtherServiceByCategory(string Opid, DateTime IssueDate)
        {
            DataTable dtrow = new DataTable();
            Query = "Select * from PatientServiceBill where OPID='" + Opid + "' and Catgory='OT' and convert(date,serviceDate)='" + IssueDate + "'";
            Command = new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            dtrow.Load(Reader);
            Reader.Close();
            return dtrow;
        }


        public int SavePatientOtherService(Service service)
        {
            int count = 0;

            for (int i = 0; i < service.PatientService.Count; i++)
            {
                Command = new SqlCommand("INSERT INTO dbo.tblPatientServiceBill (OPID,ServiceId,Rate,Qty,Total,ServiceDate,userid,VchNo)"
                  + "VALUES(@OPID,@ServiceId,@Rate,@Qty,@Total,@ServiceDate,@userid,@VchNo)", Connection);

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@OPID", service.PatientService[i].OPID);
                Command.Parameters.AddWithValue("@ServiceId", service.PatientService[i].ServiceId);
                Command.Parameters.AddWithValue("@Rate", service.PatientService[i].Rate);
                Command.Parameters.AddWithValue("@Total", service.PatientService[i].Total);
                Command.Parameters.AddWithValue("@Qty", service.PatientService[i].Qty);
                Command.Parameters.AddWithValue("@ServiceDate", service.PatientService[i].IssueDate);
                Command.Parameters.AddWithValue("@userid", "");
                Command.Parameters.AddWithValue("@VchNo", service.PatientService[i].VoucherNo);


                count += Command.ExecuteNonQuery();
            }
            return count;
        }
        public int ServiceSave(Service service)
        {

            Command = new SqlCommand("INSERT INTO tblServices (ServiceName,Description,Rate,ServiceId,Catgory)"
                + "VALUES(@ServiceName,@Description,@Rate,@ServiceId,@Catgory)", Connection);

            Command.CommandType = CommandType.Text;

            Command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
            Command.Parameters.AddWithValue("@Description", service.Description);
            Command.Parameters.AddWithValue("@Rate", service.Rate);
            Command.Parameters.AddWithValue("@ServiceId", service.ServiceId);
            Command.Parameters.AddWithValue("@Catgory", service.Catgory);


            int count = Command.ExecuteNonQuery();
            return count;
        }public int ServiceUpdate(Service service)
        {
            Command = new SqlCommand("UPDATE tblServices SET ServiceName=@ServiceName,Description=@Description,Rate=@Rate," +
                                     "ServiceId=@ServiceId,Catgory=@Catgory WHERE ID='" + service.ID + "'", Connection);

            Command.CommandType = CommandType.Text;

            Command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
            Command.Parameters.AddWithValue("@Description", service.Description);
            Command.Parameters.AddWithValue("@Rate", service.Rate);
            Command.Parameters.AddWithValue("@ServiceId", service.ServiceId);
            Command.Parameters.AddWithValue("@Catgory", service.Catgory);

            int count = Command.ExecuteNonQuery();
            return count;
        }

        public long GetOtMaxValueConsultSrvc()
        {
            Query = "select Max(VchNo) from tbl_ConsultBillService ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            if (Command.ExecuteScalar() == DBNull.Value)
            {
                return 1;
            }
            else
            {
                long lastId = Convert.ToInt64(Command.ExecuteScalar());
                return lastId + 1;
            }
            
        }

        public long GetPateintServiceMaxValue()
        {
            Query = "select Max(VchNo) from tblPatientServiceBill ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            if (Command.ExecuteScalar() == DBNull.Value)
            {
                return 1;
            }
            else
            {
                long lastId = Convert.ToInt64(Command.ExecuteScalar());
                return lastId + 1;
            }


        }
        public DataTable GetIpdAllSerialNo()
        {
            Query = "select OPID,PatientName from tbl_IndoorAdmission ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }

        public DataTable GetPatientBillService()
        {
            Query = "select * from tblServices ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }

        public long GenerateSlNo()
        {

            Query = "select Max(Id) from tbl_IndoorAdmission ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            long lastId = Convert.ToInt64(Command.ExecuteScalar());
            return lastId;
        }

        public long GetOtMaxValue()
        {
            Query = "select Max(VoucherNo) from tbl_OT_SeviceBill ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            if (Command.ExecuteScalar() == DBNull.Value)
            {
                return 1;
            }
            else
            {
                long lastId = Convert.ToInt64(Command.ExecuteScalar());
                return lastId + 1;
            }


        }

        public long GetOPMedMaxValue()
        {
            Query = "select Max(VoucherNo) from tbl_OutDoorMedineIssue ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            if (Command.ExecuteScalar() == DBNull.Value)
            {
                return 1;
            }
            else
            {
                long lastId = Convert.ToInt64(Command.ExecuteScalar());
                return lastId + 1;
            }

          }


        public long GetOtherServiceMaxValue()
        {
            Query = "select Max(VchNo) from tblPatientServiceBill ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            if (Command.ExecuteScalar() == DBNull.Value)
            {
                return 1;
            }
            else
            {
                long lastId = Convert.ToInt64(Command.ExecuteScalar());
                return lastId + 1;
            }

        }

        public DataTable GetAllConsultserviceBill(string opid, string status, string service, DateTime IssueDate)
        {
            Query = "Sp_TotalService";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@opid", opid);
            Command.Parameters.AddWithValue("@status", status);
            Command.Parameters.AddWithValue("@service", "Consult");
            Command.Parameters.AddWithValue("@IssueDate", IssueDate.Date);
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
         }

        public DataTable GetAllPatientserviceBill(string opid, string status, string service, DateTime IssueDate)
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

        public DataTable GetAllPatientservicePathology(string opid, string status, string service, DateTime IssueDate)
        {
            Query = "Sp_TotalService";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@opid", opid);
            Command.Parameters.AddWithValue("@status", status);
            Command.Parameters.AddWithValue("@service", "Pathology");
            Command.Parameters.AddWithValue("@IssueDate", IssueDate.Date);
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;

        }
        public int SaveOtService(Service service)
        {
            int count = 0;
            // vchNo(service);   
            for (int i = 0; i < service.OtConsump.Count; i++)
            {
                Command = new SqlCommand("INSERT INTO tbl_OT_SeviceBill (OT_ReffNo,PatientId,ProductId,Rate,Qty,UserId,IssueDate,VoucherNo)"
                  + "VALUES(@OT_ReffNo,@PatientId,@ProductId,@Rate,@Qty,@UserId,@IssueDate,@VoucherNo)", Connection);

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@OT_ReffNo", service.OtReffNo);
                Command.Parameters.AddWithValue("@PatientId", service.OPID);
                Command.Parameters.AddWithValue("@IssueDate", service.OtConsump[i].IssueDate);
                Command.Parameters.AddWithValue("@ProductId", service.OtConsump[i].ProductId);
                Command.Parameters.AddWithValue("@Rate", service.OtConsump[i].Rate);
                Command.Parameters.AddWithValue("@Qty", service.OtConsump[i].Qty);
                Command.Parameters.AddWithValue("@VoucherNo", service.OtConsump[i].VoucherNo);
                Command.Parameters.AddWithValue("@UserId", "");
                int exeCount = Command.ExecuteNonQuery();
                if (exeCount > 0)
                {
                    service.StockPosting = new StockPosting();
                    service.StockPosting.StockPostingId = Convert.ToString(service.OtConsump[i].Id);
                    service.StockPosting.voucherNo = service.OtConsump[i].VoucherNo.ToString();
                    service.StockPosting.voucherType = "Medicine Issue OT";
                    service.StockPosting.branchId = "1";
                    service.StockPosting.optional = 0;
                    service.StockPosting.date = service.OtConsump[i].IssueDate;
                    service.StockPosting.referenceNo = service.OPID;
                    service.StockPosting.outwardQty = service.OtConsump[i].Qty;
                    service.StockPosting.godownId = "2";
                    service.StockPosting.rate = service.OtConsump[i].Rate;
                    service.StockPosting.productCode = service.OtConsump[i].ProductId;
                    //service.StockPosting.batchId = service.OtConsump[i].batchId;              
                    service.StockPosting.batchId = service.OtConsump[i].batchId;
                    StockPostingFor_OT(service.StockPosting);
                }
                count++;
            }

            return count;
        }

        public int StockPostingFor_OT(StockPosting service)
        {
            Command = new SqlCommand("StockPostingAddIssueMedicine", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Type myClassType = service.GetType();PropertyInfo[] properties = myClassType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value= property.GetValue(service, null);
                Command.Parameters.AddWithValue("@"+property.Name, value??"");
            }
           return Command.ExecuteNonQuery();
        }

        public int SavePatientService(Service service)
        {
            int count = 0;

            for (int i = 0;
                i < service.PatientService.Count; i++)
            {
                Command = new SqlCommand("INSERT INTO dbo.tblPatientServiceBill (OPID,ServiceId,Rate,Qty,Total,ServiceDate,userid,VchNo)"
                 + "VALUES(@OPID,@ServiceId,@Rate,@Qty,@Total,@ServiceDate,@userid,@VchNo)", Connection);

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@OPID", service.OPID);
                Command.Parameters.AddWithValue("@ServiceId", service.PatientService[i].ServiceId);
                Command.Parameters.AddWithValue("@Rate", service.PatientService[i].Rate);
                Command.Parameters.AddWithValue("@Total", service.PatientService[i].Total);
                Command.Parameters.AddWithValue("@Qty", service.PatientService[i].Qty);
                Command.Parameters.AddWithValue("@ServiceDate", service.PatientService[i].IssueDate);
                Command.Parameters.AddWithValue("@userid", "");
                Command.Parameters.AddWithValue("@VchNo", service.PatientService[i].VoucherNo);
                count += Command.ExecuteNonQuery();

            }
            return count;
        }


        public int SavePathologyService(Service service)
        {
            int count = 0;

            for (int i = 0;
                i < service.Path_Service.Count; i++)
            {
                Command = new SqlCommand("INSERT INTO dbo.tblPatientServiceBill (OPID,ServiceId,Rate,Qty,Total,ServiceDate,userid,VchNo,Pathology)"
                 + "VALUES(@OPID,@ServiceId,@Rate,@Qty,@Total,@ServiceDate,@userid,@VchNo,@Pathology)", Connection);

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@OPID", service.OPID);
                Command.Parameters.AddWithValue("@ServiceId", service.Path_Service[i].ServiceId);
                Command.Parameters.AddWithValue("@Rate", service.Path_Service[i].Rate);
                Command.Parameters.AddWithValue("@Total", service.Path_Service[i].Total);
                Command.Parameters.AddWithValue("@Qty", service.Path_Service[i].Qty);
                Command.Parameters.AddWithValue("@ServiceDate", service.Path_Service[i].IssueDate);
                Command.Parameters.AddWithValue("@userid", MainWindow.userName);
                Command.Parameters.AddWithValue("@VchNo", service.Path_Service[i].VoucherNo);
                Command.Parameters.AddWithValue("@Pathology", service.Path_Service[i].PathID);
                count += Command.ExecuteNonQuery();

            }
            return count;
        }
        
        public DataTable GetAllRetriveServiceEditValue(string opid, string status)
        {

            Query = "Sp_TotalService";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@opid", opid);
            Command.Parameters.AddWithValue("@status", status);

            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public int DeleteAllService(string type, Service aService)
        {//Patient aPatient = new Patient();
            int count = 0;
            if (type == "ConsultService")
            {
                foreach (var service in aService.AConsultBill)
                {
                    Query = "Select * from tbl_ConsultBillService where OPID='" + service.OPID + "' and VchNo= '" + service.VchNo + "' ";

                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Reader = Command.ExecuteReader();
                    DataTable dtDataTable = new DataTable();
                    dtDataTable.Load(Reader);
                    for (int i = 0; i < dtDataTable.Rows.Count; i++)
                    {
                        if (service.OPID == dtDataTable.Rows[i]["OPID"].ToString() &&
                               Convert.ToDateTime(service.ConsultBillDate).Date == Convert.ToDateTime(dtDataTable.Rows[i]["ConsultBillDate"]).Date &&
                               service.VchNo == Convert.ToInt64(dtDataTable.Rows[i]["VchNo"]))
                        {

                            Query = "Delete tbl_ConsultBillService where  OPID='" + service.OPID + "' and VchNo = '" + service.VchNo + "'";
                            Command = new SqlCommand(Query, Connection);
                            count += Command.ExecuteNonQuery();
                        }
                    }
                }

            }


            else if (type == "PatientService")
            {

                foreach (var OtService in aService.PatientService)
                {
                    Query = "Select * from tblPatientServiceBill where OPID='" + aService.OPID + "' and VchNo= '" + OtService.VoucherNo + "' ";

                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Reader = Command.ExecuteReader();
                    DataTable dtDataTable = new DataTable();
                    dtDataTable.Load(Reader);

                    for (int i = 0; i < dtDataTable.Rows.Count; i++)
                    {
                        if (aService.OPID == dtDataTable.Rows[i]["OPID"].ToString() && OtService.VoucherNo == Convert.ToInt64(dtDataTable.Rows[i]["VchNo"]))
                        {
                            Query = "Delete tblPatientServiceBill where OPID='" + aService.OPID + "' and VchNo='" + OtService.VoucherNo + "' ";
                            Command = new SqlCommand(Query, Connection);
                            count += Command.ExecuteNonQuery();
                        }
                    }
                }
            }
            else if (type == "Pathology")
            {

                foreach (var OtService in aService.Path_Service)
                {
                    Query = "Select * from tblPatientServiceBill where OPID='" + aService.OPID + "' and VchNo= '" + OtService.VoucherNo + "' ";

                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Reader = Command.ExecuteReader();
                    DataTable dtDataTable = new DataTable();
                    dtDataTable.Load(Reader);
                    for (int i = 0; i < dtDataTable.Rows.Count; i++)
                    {
                        if (aService.OPID == dtDataTable.Rows[i]["OPID"].ToString() && OtService.VoucherNo == Convert.ToInt64(dtDataTable.Rows[i]["VchNo"]))
                        {
                            Query = "Delete tblPatientServiceBill where OPID='" + aService.OPID + "' and VchNo='" + OtService.VoucherNo + "' ";
                            Command = new SqlCommand(Query, Connection);
                            count += Command.ExecuteNonQuery();
                        }
                    }
                }
            }

            else if (type == "OTSERVICE")
            {
                foreach (var OtService in aService.PatientService)
                {
                    Query = "Select * from tblPatientServiceBill where OPID='" + OtService.OPID + "' and VchNo= '" + OtService.VoucherNo + "' ";

                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Reader = Command.ExecuteReader();
                    DataTable dtDataTable = new DataTable();
                    dtDataTable.Load(Reader);
                    for (int i = 0; i < dtDataTable.Rows.Count; i++)
                    {
                        if (OtService.OPID == dtDataTable.Rows[i]["OPID"].ToString() && OtService.VoucherNo == Convert.ToInt64(dtDataTable.Rows[i]["VchNo"]))
                        {
                        Query = "Delete tblPatientServiceBill where OPID='" + OtService.OPID + "' and VchNo='" + OtService.VoucherNo + "'";
                        Command = new SqlCommand(Query, Connection);
                        count += Command.ExecuteNonQuery();
}
                    }
                }

            }

            return count;
        }
        public long MaxValueVoucherNo;
        public void vchNo(Service service)
        {
            int count = 0;
            MaxValueVoucherNo = GetOtMaxValue();
            var voucherNoExist = service.OtConsump.FirstOrDefault(a => a.Id != 0);
            if (voucherNoExist != null && MaxValueVoucherNo != service.VoucherNo)
            {
                MaxValueVoucherNo = voucherNoExist.Id;
            }
            else
            {
                MaxValueVoucherNo = service.VoucherNo;
            }
            service.VoucherNo = MaxValueVoucherNo;
        }
        public int UpdateOtService(Service service)
        {
            int count = 0;
            vchNo(service);
            foreach (var OTMedicine in service.OtConsump)
            {
                try
                {
                    Query = "Select * from tbl_OT_SeviceBill where PatientId='" + OTMedicine.OPID + "' and VoucherNo= '" + OTMedicine.VoucherNo + "' ";

                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Reader = Command.ExecuteReader();
                    DataTable dtDataTable = new DataTable();
                    dtDataTable.Load(Reader);
                    for (int i = 0; i < dtDataTable.Rows.Count; i++)
                    {
                        if (OTMedicine.OPID == dtDataTable.Rows[i]["PatientId"].ToString() &&
                           OTMedicine.VoucherNo == Convert.ToInt64(dtDataTable.Rows[i]["VoucherNo"]))
                        {
                            Query = "Delete tbl_OT_SeviceBill where PatientId='" + OTMedicine.OPID + "'  and VoucherNo= '" + OTMedicine.VoucherNo + "'";
                            Command = new SqlCommand(Query, Connection);
                            count += Command.ExecuteNonQuery();
                        }
                        if (count > 0)
                        {
                            Query = "Delete tbl_StockPosting where referenceNo='" + OTMedicine.OPID + "'  and VoucherType = 'Medicine Issue OT' and VoucherNo = '" + OTMedicine.VoucherNo + "'";
                            Command = new SqlCommand(Query, Connection);
                            count += Command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }


            }

            return count;
        }


        public DataTable GetPatientServiceBillWithoutOT()
        {
            Query = "select * from tblServices where Catgory !='OT'" ;
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;

        }


        public DataTable GetPatientService(string Category)
        {
            Query = "select * from tblServices where Catgory !='OT' AND Catgory='" + Category + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;

        }

        public DataTable GetPathologyMaster()
        {
            Query = "select * from tblPathology";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;

        }


    }
}
