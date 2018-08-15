using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
   public class MedicineIndentManager
    {

       public DataTable GetIndentNo()
       {
           DataTable dataTable=new DataTable();
           dataTable = new MedicineIndentGateway().GetIndentNo();
           return dataTable;
       }


       public DataTable GetIpPatient()
       {
           DataTable dataTable = new DataTable();
           dataTable = new MedicineIndentGateway().GetIpPatient();
           return dataTable;
       }

       public DataTable GetNicuPatient()
       {
           DataTable dataTable = new DataTable();
           dataTable = new MedicineIndentGateway().GetNicuPatient();
           return dataTable;
       }


       public DataTable GetMedicine()
       {
           DataTable dataTable = new DataTable();
           dataTable = new MedicineIndentGateway().GetMedicine();
           return dataTable;
       }



       public MessageModel SaveMedicineIndent(MedicineIndent aMedicineIndent)
       {
           int rowAffect = 0;
           int rowAffect2 = 0;
           MessageModel aMessageModel=new MessageModel();

          rowAffect = new MedicineIndentGateway().SaveMedicineIndent(aMedicineIndent);
           if (rowAffect>0)
           {
             rowAffect2 = new MedicineIndentGateway().SaveMedicineIndentDetails(aMedicineIndent);
           }
           if (rowAffect2>0)
           {
               aMessageModel.MessageTitle = "Successfull";
               aMessageModel.MessageBody = "Saved Successfully.";
           }
           return aMessageModel;

       }

    }
}
