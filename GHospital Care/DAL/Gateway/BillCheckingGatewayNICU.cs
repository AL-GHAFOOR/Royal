using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Gateway
{
   public class BillCheckingGatewayNICU:GatwayConnection
    {
       public DataTable GetConsultBill(string patientID)
       {
           Query = "select * from ConsultSrviceBill where OPID  ='" + patientID + "' ";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           DataTable dtDataTable = new DataTable();Reader = Command.ExecuteReader();
           dtDataTable.Load(Reader);
           return dtDataTable;
       }
       public DataTable GetPharmacyBill(string patientID)
       {
           Query = "select * from IssueMedicineBill where PatientId  ='" + patientID + "' ";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           DataTable dtDataTable = new DataTable();
           Reader = Command.ExecuteReader();
           dtDataTable.Load(Reader);
           return dtDataTable;
      }

       public DataTable GetPathologyBill(string patientID)
       {
           Query = "select * from PatientServiceBill where OPID  ='" + patientID + "' and Catgory= 'Pathology' ";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           DataTable dtDataTable = new DataTable();
           Reader = Command.ExecuteReader();
           dtDataTable.Load(Reader);
           return dtDataTable;
       }
       
       public DataTable GetHospitalServiceBill(string patientID)
       {
           Query = "select * from HospittalService where OPID  ='" + patientID + "' ";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           DataTable dtDataTable = new DataTable();
           Reader = Command.ExecuteReader();
           dtDataTable.Load(Reader);
           return dtDataTable;
       }

       public DataTable GetOTServiceBill(string patientID)
       {
           Query = "select * from PatientServiceBill where OPID  ='" + patientID + "' and Catgory= 'OT' ";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           DataTable dtDataTable = new DataTable();
           Reader = Command.ExecuteReader();
           dtDataTable.Load(Reader);
           return dtDataTable;
       }


       public DataTable GetOTMedicineBill(string patientID)
       {
           Query = "select OT.*,OT.Rate*OT.Qty subTotal,P.* from tbl_OT_SeviceBill OT inner join productList P on p.ProductCode = OT.ProductId where PatientId = '" + patientID + "' ";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           DataTable dtDataTable = new DataTable();
           Reader = Command.ExecuteReader();
           dtDataTable.Load(Reader);
           return dtDataTable;
       }

       public DataTable GetNICUBillINFO(DateTime AdmintDate1, DateTime AdmintDate2, bool chkvalue)
       {
           DataTable dtDataTable = new DataTable();
           // Query = "select * from HospitalBusinessOffice B where B.InputDate between  '" + AdmintDate1 + "' and '" + AdmintDate2 + "' and B.OPID NOT IN(SELECT OPID FROM dbo.tbl_DischargeBill) ";
           if (chkvalue == true)
           {
               Query = "select * from HospitalBusinessOfficeDichargeNICU B where Convert(date,B.DischargeDate) between  '" + AdmintDate1 + "' and '" + AdmintDate2 + "' and B.RegNo IN(SELECT OPID FROM dbo.tbl_DischargeBillNICU) ";

           }
           if (chkvalue == false)
           {
               Query = "select * from HospitalBusinessOfficeNICU B where B.AdmitDate between  '" + AdmintDate1 + "' and '" + AdmintDate2 + "' and B.RegNo  NOT IN(SELECT OPID FROM dbo.tbl_DischargeBillNICU) ";
           }
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           Reader = Command.ExecuteReader();
           dtDataTable.Load(Reader);
           return dtDataTable;
       }

    }
}