using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Gateway
{
  public  class IPCosultDoctor
    {
      public string DocID { get; set; }
      public string DocName { get; set; }
      public string Degree { get; set; }
      public string ConDate { get; set; }
      public string ConFee { get; set; }
      public string ConQty { get; set; }
      public string TotalConsFee { get; set; }

    }
}
