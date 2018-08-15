using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    public class AccessPermissionGateway : GatwayConnection
    {
        public List<UserMaster> AccessPermissionList(int roleId,string uid)
        {
            List<UserMaster> list=new List<UserMaster>();

            Query = "Select * from viewAccessPermissionControl where RoleId='" + roleId + "' and id='" + uid + "'";
            Command=new SqlCommand(Query,Connection);
           
            Reader= Command.ExecuteReader();
            while (Reader.Read())
            {
                list.Add(new UserMaster()
                {
                    FormName = Reader["formName"].ToString(),
                    MenuName = Reader["MenuName"].ToString(),
                    FormCaption = Reader["formCaption"].ToString(),
                    
                    Permission = Convert.ToBoolean(Reader["FormPermission"]),
                    insertPermission = Convert.ToBoolean(Reader["insertPermission"]),
                    editPermission = Convert.ToBoolean(Reader["EditPermission"]),
                    deletePermission = Convert.ToBoolean(Reader["deletePermission"]),
                    reportingPermission = Convert.ToBoolean(Reader["ReportPermission"])
                   
                }
                );
            }
            return list;
        }
    }
}
