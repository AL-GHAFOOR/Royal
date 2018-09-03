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


       public DataTable GetIndentMaster(DateTime FromDate, DateTime ToDate)
       {
           DataTable dataTable = new DataTable();
           dataTable = new MedicineIndentGateway().GetIndentMaster(FromDate, ToDate);
           return dataTable;
       }


       public DataTable GetIndentDetails(string Indent)
       {
           DataTable dataTable = new DataTable();
           dataTable = new MedicineIndentGateway().GetIndentDetails(Indent);
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

       public MessageModel UpdateMedicineIndent(MedicineIndent aMedicineIndent)
       {
           int rowAffect = 0;
           int rowAffect2 = 0;
           MessageModel aMessageModel = new MessageModel();

           rowAffect = new MedicineIndentGateway().UpdateMedicineIndent(aMedicineIndent);
           if (rowAffect > 0)
           {
               if (rowAffect>0)
               {
                   rowAffect = new MedicineIndentGateway().DeleteIndentDetails(aMedicineIndent);
               }
               rowAffect2 = new MedicineIndentGateway().SaveMedicineIndentDetails(aMedicineIndent);
           }
           if (rowAffect2 > 0)
           {
               aMessageModel.MessageTitle = "Successfull";
               aMessageModel.MessageBody = "Update Successfully.";
           }
           return aMessageModel;

       }

    }
}
