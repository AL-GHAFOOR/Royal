using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
   public class OtSetup
    {
       public string userId { get; set; }
       public int Id { get; set; }
       public string Pid { get; set; }
       public string Paname { get; set; }

       public string OtReffNo { get; set; }
       public string Cabin_Bed { get; set; }
       public DateTime Date { get; set; }
       public string SurgenId { get; set; }
       public string Anstology { get; set; }
       public string FirstAsst { get; set; }
       public string SecondAsst { get; set; }
       public string OpName { get; set; }
       public TimeSpan OT_From { get; set; }
       public TimeSpan OT_To { get; set; }
    }
}
