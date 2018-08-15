using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Gateway
{
   public class BillCheckingGateway:GatwayConnection
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
           Query = "select OT.*,OT.Rate*OT.Qty subTotal,P.* from tbl_OT_SeviceBill OT inner join productList_medicine P on p.ProductCode = OT.ProductId where PatientId = '" + patientID + "' ";
           Command = new SqlCommand(Query, Connection);
           Command.CommandType = CommandType.Text;
           DataTable dtDataTable = new DataTable();
           Reader = Command.ExecuteReader();
           dtDataTable.Load(Reader);
           return dtDataTable;
       }

    }
}
