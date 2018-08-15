using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class UserMaster
    {
        public String ID { get; set; }
        public string UserId { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Date { get; set; }
        public String Type { get; set; }
        public Boolean insertPermission { get; set; }
        public Boolean deletePermission { get; set; }
        public Boolean editPermission { get; set; }
        public Boolean reportingPermission { get; set; }
        public String  UserGroup { get; set; }
        public String machineName { get; set; }
       
        public String MenuName  { get; set; }
        public String MenuCaption  { get; set; }
        public Boolean Permission  { get; set; }
        public string SubMenu  { get; set; }
        

        public string RoleDescription  { get; set; }
        public int RoleId  { get; set; }
        public String RoleName { get; set; }


       public UserMaster  AllUser { get; set; }
       public  List<UserMaster> MenuPermission { get; set; } 
       public  List<UserMaster> UserRoleList { get; set; }
        public string FormName { get; set; }
        public string FormCaption { get; set; }
    }
}
