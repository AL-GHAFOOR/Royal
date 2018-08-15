using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
   public class SerialManageManager
    {
       public string GetFlowupSerial()
       {
           long serial=new SerialManageGatway().GetFollowUpSerial(new SerailGenerate());

           if (serial>0)
           {
               return "# FSL 0" + serial + 1;
           }
           return "# FSL 0" + (serial+1);
       }
    }
}
