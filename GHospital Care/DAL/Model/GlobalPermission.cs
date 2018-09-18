using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class GlobalPermission
    {
        public static List<UserMaster> UserPermission { get; set; }
        public static List<UserMaster> DefaultMenuNameList { get; set; }
 
    }
}
