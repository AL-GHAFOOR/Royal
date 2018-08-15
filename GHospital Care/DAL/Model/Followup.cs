using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
 public   class Followup
    {
     public string SerialId { get; set; }
     public string OPID { get; set; }
     public DateTime Date { get; set; }
     public string DocId { get; set; }

     public string drug { get; set; }

     public string dose { get; set; }
     public string Bp { get; set; }
     public string ExtraNote { get; set; }
     public string ExtraNoteSpecial { get; set; }
     public string DailyFollowUp { get; set; }
     public string TotalFollowUp { get; set; }
     public string FollowUPItemId { get; set; }
     public string Particulars { get; set; }
     public string ItemType { get; set; }
     public string Shift { get; set; }
     public string Department { get; set; }

     public DataTable ListOfDrug { get; set; }
     public List<Followup> AFollowupList { get; set; }



    }
}
