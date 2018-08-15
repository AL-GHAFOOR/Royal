using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
  public  class ConsultBillService
    {
      public int Id { get; set; }
      public string OPID { get; set; }
      public string ConsultId { get; set; }
      public string ConsultBillDate { get; set; }
      public string Specialization { get; set; }public string Degree { get; set; }
      public double ConFee { get; set; }
      public double TotalConsFee { get; set; }
      public int ConQty { get; set; }
      public Int64 VchNo { get; set; }

    }
}
