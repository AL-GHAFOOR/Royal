using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
   public  class MedicineIndent
    {

       public string IndentNo { get; set; }
       public DateTime Date { get; set; }
       public string PatientType { get; set; }
       public string PatientId { get; set; }
       public DataTable DrugsDatatable { get; set; }

    }
}
