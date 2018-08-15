using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using DevExpress.XtraLayout;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    public class OpdGateway : GatwayConnection
    {
        public DataTable SearchPatient(string PatientID)
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select * From tblOP where OPID=@OPID";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@OPID", SqlDbType.VarChar, 50).Value = PatientID;      //don't know  

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetIpdDischageIp()
        {
            Query = "SELECT * from tbl_IndoorAdmission WHERE OPID NOT IN(SELECT OPID FROM tbl_MasterDischargeForm)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable GetConsultant()
        {
            Query = "select DoctorID, DoctorName from tblConsult_Doctors";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetIpdAllSerialNo()
        {
            Query = "SELECT OPID,PatientName from tbl_IndoorAdmission where OPID not in (select OPID from tbl_DischargeBill)";
            //"SELECT OPID,PatientName from tbl_IndoorAdmission";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }

        public DataTable GetNICUPatienSlNo()
        {

            Query = "select * from BedHistoryPatientInfoNICU where RegNo Not in (select OPID from tbl_DischargeBillNICU)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;}

        public DataTable GetOPMedicineConsumListByPatientId(Service paitentId)
        {
            DataTable dtDataTable = new DataTable();
            try
            {
                Query = "Sp_PatitentWiseMedicineOt_OD";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@godownID", "3");
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

        public DataTable GetPatientInformationBySl(string patientSlNo)
        {
            Query = "select * from tblOP where OPID='" + patientSlNo + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);

            return dtDataTable;
        }

        public int UpdateOPService(Service service)
        {
            int count = 0;
            // vchNo( service);
            foreach (var OPMedicine in service.IssueMedines)
            {
                try
                {
                    Query = "Select * from tbl_OutDoorMedineIssue where PatientId='" + OPMedicine.OPID +
                            "' and VoucherNo= '" + OPMedicine.VoucherNo + "' ";

                    Command = new SqlCommand(Query, Connection);
                    Command.CommandType = CommandType.Text;
                    Reader = Command.ExecuteReader();
                    DataTable dtDataTable = new DataTable();
                    dtDataTable.Load(Reader);
                    for (int i = 0; i < dtDataTable.Rows.Count; i++)
                    {
                        if (OPMedicine.OPID == dtDataTable.Rows[i]["PatientId"].ToString() &&
                            OPMedicine.VoucherNo == Convert.ToInt64(dtDataTable.Rows[i]["VoucherNo"]))
                        {
                            Query = "Delete tbl_OutDoorMedineIssue where PatientId='" + OPMedicine.OPID +
                                    "'  and VoucherNo= '" + OPMedicine.VoucherNo + "'";
                            Command = new SqlCommand(Query, Connection);
                            count += Command.ExecuteNonQuery();
                        }
                        if (count > 0)
                        {
                            Query = "Delete tbl_StockPosting where referenceNo='" + OPMedicine.OPID +
                                    "'  and VoucherType = 'Medicine Issue OP' and VoucherNo = '" + OPMedicine.VoucherNo +
                                    "'";
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

        public int PatientCreate(Patient patient)
        {
            Query = "INSERT INTO tblOP (OPID,TreatmentType,PatientName,ServiceDate,Address,Gender,Age,Phone,Mobile,Nationality,Doctor,Fees,BloodGroup)"
                + "VALUES (@OPID,@TreatmentType,@PatientName,@ServiceDate,@Address,@Gender,@Age,@Phone,@Mobile,@Nationality,@Doctor,@Fees,@BloodGroup)";

            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;

            Command.Parameters.AddWithValue("@OPID", patient.OPID);
            Command.Parameters.AddWithValue("@TreatmentType", patient.TreatmentType);
            Command.Parameters.AddWithValue("@PatientName", patient.PatientName);
            Command.Parameters.AddWithValue("@ServiceDate", patient.ServiceDate);
            Command.Parameters.AddWithValue("@Address", patient.Address);
            Command.Parameters.AddWithValue("@Gender", patient.Gender);
            Command.Parameters.AddWithValue("@Age", patient.Age);
            Command.Parameters.AddWithValue("@Phone", patient.Phone??"");
            Command.Parameters.AddWithValue("@Mobile", patient.Mobile??"");
            Command.Parameters.AddWithValue("@Nationality", patient.Nationality??"");
            Command.Parameters.AddWithValue("@Doctor", patient.Doctor);
            Command.Parameters.AddWithValue("@Fees", patient.Fees);
            Command.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);


            int count = Command.ExecuteNonQuery();

            return count;
        }

        public DataTable GetAllOpdPatienSlNo()
        {

            Query = "SELECT OPID from tblOP where OPID not in(SELECT OPID from tbl_IndoorAdmission) and OPID not in(select OPID from tbl_OutdoorBill)";
                //"SELECT OPID from tblOP where TreatmentType !='IPD'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        


        private Patient _patient;
        public int DeletePatient(string id)
        {
            _patient = new Patient();
            Query = "DELETE FROM tblOP WHERE OPID= '" + id + "'";
            Command = new SqlCommand(Query, Connection);

            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

        public int UpdatePatient(Patient aPatient)
        {

            Query = "UPDATE tblOP SET ServiceDate=@ServiceDate,TreatmentType=@TreatmentType,Phone=@Phone,PatientName=@PatientName,Gurdian=@Gurdian," +
                    "Address=@Address,Age=@Age,Gender=@Gender,BloodGroup=@BloodGroup,Nationality=@Nationality,ContactPerson=@ContactPerson," +
                    "ContactPersonMobile=@ContactPersonMobile,Doctor=@Doctor,Fees=@Fees  Where OPID ='" + aPatient.OPID + "'";
            Command = new SqlCommand(Query, Connection);
            //Command.Parameters.AddWithValue("@OPID", aPatient.OPID);
            Command.Parameters.AddWithValue("@ServiceDate", aPatient.ServiceDate);
            Command.Parameters.AddWithValue("@TreatmentType", aPatient.TreatmentType);
            Command.Parameters.AddWithValue("@Phone", aPatient.Phone);
            Command.Parameters.AddWithValue("@PatientName", aPatient.PatientName);
            Command.Parameters.AddWithValue("@Gurdian", aPatient.Gurdian); 
            Command.Parameters.AddWithValue("@Address", aPatient.Address);
            Command.Parameters.AddWithValue("@Age", aPatient.Age);
            Command.Parameters.AddWithValue("@Gender", aPatient.Gender);
            Command.Parameters.AddWithValue("@BloodGroup", aPatient.BloodGroup);
            Command.Parameters.AddWithValue("@Nationality", aPatient.Nationality);
            Command.Parameters.AddWithValue("@ContactPerson", aPatient.ContactPerson);
            Command.Parameters.AddWithValue("@ContactPersonMobile", aPatient.ContactPersonMobile);
            Command.Parameters.AddWithValue("@Doctor", aPatient.Doctor);
            Command.Parameters.AddWithValue("@Fees", aPatient.Fees);

            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

        public DataTable GetIssueMedineStock()
        {
            Query = "GodownWiseStockStatus ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@godownID","3" );
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);return dtDataTable;
        }

        public int SaveOtIssueMedine(Service aService)
        {
            int count = 0;
            for (int i = 0; i < aService.IssueMedines.Count; i++)
            {
                Query = "Insert into  tbl_OutDoorMedineIssue (PatientId,ProductId,Qty,Date,UserId,VoucherNo,Rate,batchID) VALUES (@PatientId,@ProductId,@Qty,@Date,@UserId,@VoucherNo,@Rate,@batchID)";
                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@ProductId", aService.IssueMedines[i].ProductId);
                Command.Parameters.AddWithValue("@Qty", aService.IssueMedines[i].Qty);
                Command.Parameters.AddWithValue("@PatientId", aService.OPID);
                Command.Parameters.AddWithValue("@Date", aService.IssueMedines[i].date);
                // Command.Parameters.AddWithValue("@M_IssueReff", aService.IssueMedines[i].M_IssueReff);
                Command.Parameters.AddWithValue("@UserId", "");
                Command.Parameters.AddWithValue("@VoucherNo", aService.IssueMedines[i].VoucherNo);
                Command.Parameters.AddWithValue("@Rate", aService.IssueMedines[i].Rate);
                Command.Parameters.AddWithValue("@batchID", aService.IssueMedines[i].batchId);
                count += Command.ExecuteNonQuery();
                if (count > 0)
                {
                    aService.StockPosting = new StockPosting();
                    //aService.StockPosting.StockPostingId = Convert.ToString(service.OtConsump[i].Id);
                    aService.StockPosting.voucherNo = aService.IssueMedines[i].VoucherNo.ToString(); //service.OtConsump[i].VoucherNo.ToString();
                    aService.StockPosting.voucherType = "Medicine Issue OP";
                    aService.StockPosting.branchId = "1";
                    aService.StockPosting.optional = 0;
                    aService.StockPosting.date = aService.IssueMedines[i].date;
                    aService.StockPosting.referenceNo = aService.OPID;
                    aService.StockPosting.outwardQty = aService.IssueMedines[i].Qty;
                    aService.StockPosting.godownId = "3";
                    aService.StockPosting.rate = aService.IssueMedines[i].Rate;
                    aService.StockPosting.productCode = aService.IssueMedines[i].ProductId;
                    //service.StockPosting.batchId = service.OtConsump[i].batchId;              
                    aService.StockPosting.batchId = aService.IssueMedines[i].batchId;
                    StockPostingFor_OT(aService.StockPosting);
                }
                count++;
            }
            return count;
        }

        public int StockPostingFor_OT(StockPosting service)
        {
            Command = new SqlCommand("StockPostingAddIssueMedicine", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Type myClassType = service.GetType(); PropertyInfo[] properties = myClassType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(service, null);
                Command.Parameters.AddWithValue("@" + property.Name, value ?? "");
            }
            return Command.ExecuteNonQuery();
        }


        public DataTable GetAllValueAsToday()
        {
            DateTime today = DateTime.Now;

            Conn obcon = new Conn();
            SqlConnection connection = new SqlConnection(obcon.strCon);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand();
            dataAdapter.SelectCommand.Connection = connection;
            SqlCommand command = dataAdapter.SelectCommand; command.CommandText = "select *  from tblOP where ServiceDate=Convert(date,@ServiceDate)";
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@ServiceDate", today);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt;
        }

        public DataTable GetDischargeBillByPatientId(string OPID)
        {
            Query = "sp_OutDoorTotalBill";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@opid", OPID);
            Reader = Command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Reader);

            return dt;

        }

        public int SaveDischargeBill(OutDoorBill aDischargeBill)
        {
            Query = "INSERT INTO [dbo].[tbl_OutDoorBill]([BillNo],[Date],[OPID],[HospitalCharge],[NurseCharge],[DoctorCharge],[RoomBedCharge],[ServiceCharge]," +
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
            Command.Parameters.AddWithValue(@"Discount", aDischargeBill.discount);
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
        public DataTable OutDoorPatient()
        {
            Query = "select OPID from tblOP where OPID not in(Select OPID from tbl_OutDoorBill) and  OPID Not in(Select OPID from tbl_IndoorAdmission)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable(); dtDataTable.Load(Reader); 
            return dtDataTable;
        }

        public DataTable GetOutdoorPatient(string opid)
        {
            Query = "SP_RptOutdoorBill";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@PatientID", opid);
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable GetOutdoorPatient()
        {
            Query = "select * from viewOutdoorPatientBill";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable(); dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetOutdoorPatientBillList(DateTime fromDate, DateTime ToDate)
        {
            Query = "select * from ViewOutdoorBillList where Date between '"+fromDate+"' and '"+ToDate+"' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetOPBillID()
        {
            Query = "SP_GENERATE_OPBILLID";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable(); 
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

    }
}
