using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
  public  class OT_Consump
    {
      public string batchId { get; set; }
      public int Id { get; set; }
    
     
      public string ProductId { get; set; }
      public string OPID { get; set; }
      public string ProductName { get; set; }
      public long VoucherNo { get; set; }
      public decimal     Rate { get; set; }
      public DateTime     IssueDate { get; set; }
      public int Qty { get; set; }
    }
}
