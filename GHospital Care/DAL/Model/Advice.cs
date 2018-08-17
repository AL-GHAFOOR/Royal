using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
   public class Advice
    {
       public string AdviceName { get; set; }
       public int AdviceId { get; set; }

      public  List<Advice> ListOfAdvice { get; set; }
       public Advice()
       {
           


       }
    }
}
