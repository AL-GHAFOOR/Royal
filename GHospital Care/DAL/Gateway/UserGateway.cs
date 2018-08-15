using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    class UserGateway : GatwayConnection
    {
        public DataTable GenerateUserID()
        {
            Query = "SP_GENERATE_User_ID";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        //string query = "select id, UserId, Name, Password, date, Type, insertPermission, deletePermission, editPermission, reportingPermission from tblUserInfo where UserId = '" + UsrId + "'";

       

        public DataTable UserInfo()
        {
            Query = "select UserId from tblUserInfo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable GetRole()
        {
            Query = "SELECT * FROM Role";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable FormLoad(string roleId)
        {
            Query = "select * from tblMenuPermission where RoleId='"+roleId+"'";

            //Query = "select FormName, FormCaption from tblFormName";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable; 
        }

        public DataTable GetUserUpdate(string UserId)
        {
            Query = "sselect U.id, UserId, Name, Password, date, RoleId, R.RoleName from tblUserInfo U left join Role R on R.id = U.RoleId  where U.Id = '" + UserId + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }


       // DataTable dt = dataconn.dataread(String.Format("select ID, UserId, Password, insertPermission, editPermission, deletePermission, reportingPermission, Type from tblUserInfo where UserId = '{0}'", lbluser.Text.Trim()));
        //

        public DataTable ViewUserLoad(UserMaster UserId)
        {
            Query = "select Id, UserId, Password, insertPermission, editPermission, deletePermission, reportingPermission, Type,UserRoll from ViewPermission where UserId = '" + UserId.UserId + "' and Password = '" + UserId.Password + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();dtDataTable.Load(Reader);
            return dtDataTable;
           }

        public DataTable chkpermission(string UserId)
        {
            Query = "select insertPermission, editPermission, deletePermission, reportingPermission, Type from ViewPermission where UserId ='" + UserId + "' ";
           Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;
           
        }
        public DataTable ChkMenu(string UserId)
        {
            Query = "select MenuName, MenuCaption, SubMenu,Permission from tblMenuPermission where UserId ='" + UserId + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;

        }



        public DataTable RoleId()
        {
            Query = "select Isnull(Max(Id),1)Id from Role";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            return dtDataTable;

        }
        public DataTable GetUsreINput(ListView lstv)
        {
            Query = "Select * from tblUserInfo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dtDataTable = new DataTable();
            dtDataTable.Load(Reader);
            if (dtDataTable != null && dtDataTable.Rows.Count > 0)
            {
                lstv.Items.Clear();
                for (int i = 0; i < dtDataTable.Rows.Count; i++)
                {
                    lstv.Items.Add(dtDataTable.Rows[i][0].ToString());
                }
            }
            return dtDataTable;
        }

        


        public int SaveUser(UserMaster User)
        {
            Query = "INSERT INTO tblUserInfo(UserId,Name,Password,Date,RoleId)VALUES(@UserId,@Name,@Password,@Date,@RoleId)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@UserId", User.UserId??"");
            Command.Parameters.AddWithValue("@Name", User.Name ?? "");
            Command.Parameters.AddWithValue("@Password", User.Password ?? "");
            Command.Parameters.AddWithValue("@Date", User.Date ?? "");
            Command.Parameters.AddWithValue("@RoleId", User.RoleId);
            
            int count = Command.ExecuteNonQuery();
            return count;
        }
        public int SaveRole(UserMaster User)
        {

            //Query = "insert into Role (RoleName,RoleDescription,MenuPermission,SavePermission,EditPermission,DeletePermission,ReportPermission) VALUES(@RoleName,@RoleDescription,@MenuPermission,@SavePermission,@EditPermission,@DeletePermission,@ReportPermission)";
            Query = "insert into Role (RoleName,RoleDescription,SavePermission,EditPermission,DeletePermission,ReportPermission) VALUES(@RoleName,@RoleDescription,@SavePermission,@EditPermission,@DeletePermission,@ReportPermission)";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@RoleName", User.RoleName);
            Command.Parameters.AddWithValue("@RoleDescription", User.RoleDescription);
           // Command.Parameters.AddWithValue("@MenuPermission", User.MenuPermission);
            Command.Parameters.AddWithValue("@SavePermission", User.insertPermission);
            Command.Parameters.AddWithValue("@EditPermission", User.editPermission);
            Command.Parameters.AddWithValue("@DeletePermission", User.deletePermission);
            Command.Parameters.AddWithValue("@ReportPermission", User.reportingPermission);
      int count = Command.ExecuteNonQuery();
            return count;
        }


        public int SaveMenuPermission(UserMaster User)
        {
            int count = 0;
            for (int i = 0; i < User.UserRoleList.Count; i++)
            {
                Query = "insert into tblMenuPermission (FormName,RoleId, MenuName, MenuCaption, Permission,SubMenu,ChkInsert,ChkUpdate,ChkDelete,ChkReporting) values ( @FormName,@RoleId, @MenuName, @MenuCaption, @Permission,@SubMenu,@ChkInsert,@ChkUpdate,@ChkDelete,@ChkReporting)";

                Command = new SqlCommand(Query, Connection);
                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@RoleId", User.UserRoleList[i].RoleId);
                Command.Parameters.AddWithValue("@MenuName", User.UserRoleList[i].MenuName);
                Command.Parameters.AddWithValue("@FormName", User.UserRoleList[i].FormName);
                Command.Parameters.AddWithValue("@MenuCaption", User.UserRoleList[i].MenuCaption);
                Command.Parameters.AddWithValue("@Permission", User.UserRoleList[i].Permission);
                Command.Parameters.AddWithValue("@SubMenu", User.UserRoleList[i].SubMenu);
                Command.Parameters.AddWithValue("@ChkInsert", User.UserRoleList[i].insertPermission);
                Command.Parameters.AddWithValue("@ChkUpdate", User.UserRoleList[i].editPermission);
                Command.Parameters.AddWithValue("@ChkDelete", User.UserRoleList[i].deletePermission);
                Command.Parameters.AddWithValue("@ChkReporting", User.UserRoleList[i].reportingPermission);

                count += Command.ExecuteNonQuery();     
            }
           
            return count;
        }

        public int UpdateUser_MenuPermission(UserMaster User)
        {
            Query = "update tblUserInfo Set  insertPermission=@insertPermission, deletePermission=@deletePermission, editPermission=@editPermission, reportingPermission=@reportingPermission where UserId=@UserId";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@UserId", User.UserId);
            Command.Parameters.AddWithValue("@insertPermission", User.insertPermission);
            Command.Parameters.AddWithValue("@deletePermission", User.deletePermission);
            Command.Parameters.AddWithValue("@editPermission", User.editPermission);
            Command.Parameters.AddWithValue("@reportingPermission", User.reportingPermission);
            
            int count = Command.ExecuteNonQuery();
            return count;
        }

        public int DeleteMenuPermission(UserMaster User)
        {
            Query = "delete tblMenuPermission where RoleId = @UserId";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@UserId", User.UserId);
            int count = Command.ExecuteNonQuery();
            return count;
        }

        //string query = "update tblUserInfo set UserId = '" + txtUUserId.Text.Trim() + "', Name = '" + txtUUserName.Text.Trim() + "', Password = '" + txtNewPassword.Text.Trim() + "', Date = '" + txtUDate.Text.Trim() + "', Type = '" + cmbUType.Text.Trim() + "', insertPermission = '" + chkUSave.Checked +"' , deletePermission = '" + chkUDelete.Checked +"', editPermission = '" + chkUEdit.Checked +"', reportingPermission = '" + chkUReporting.Checked +"' where  ID = '" + txtUUserId.Tag.ToString().Trim() + "'";

        public int UpdateUser(UserMaster User)
        {
            Query = "update tblUserInfo Set  UserId=@UserId, Name=@Name, Password=@Password, Date=@Date, Type=@Type, insertPermission=@insertPermission, deletePermission=@deletePermission, editPermission=@editPermission, reportingPermission=@reportingPermission,UserRoll = @RoleName where ID= @ID";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", User.ID);
            Command.Parameters.AddWithValue("@UserId", User.UserId);
            Command.Parameters.AddWithValue("@Name", User.Name);
            Command.Parameters.AddWithValue("@Password", User.Password);
            Command.Parameters.AddWithValue("@Date", User.Date);
            Command.Parameters.AddWithValue("@Type", User.Type);
            Command.Parameters.AddWithValue("@insertPermission", User.insertPermission);
            Command.Parameters.AddWithValue("@deletePermission", User.deletePermission);
            Command.Parameters.AddWithValue("@editPermission", User.editPermission);
            Command.Parameters.AddWithValue("@reportingPermission", User.reportingPermission);
            Command.Parameters.AddWithValue("@UserRoll  ", User.RoleName);

            int count = Command.ExecuteNonQuery();
            return count;
        }
        public DataTable MenuCheck(UserMaster master)
        {
            Query = "select MenuName, Permission,SubMenu from tblMenuPermission where RoleId = '" + master.RoleId + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable tblformpermission = new DataTable();
            tblformpermission.Load(Reader);
            ////bool stat = false;
            //for (int i = 0; i < tblformpermission.Rows.Count; i++)
            //{

            //    if (tblformpermission.Rows[i][2].ToString() == Menu && bool.Parse(tblformpermission.Rows[i][1].ToString()) == true)
            //    {
            //        stat = true;
            //    }
            //}
            return tblformpermission;
        }

        public bool permissionCheck(string formName)
        {
            //Query = "select MenuName, Permission,MenuName from tblMenuPermission where UserId = '" + MainWindow.userName + "'";
            //Command = new SqlCommand(Query, Connection);
            //Command.CommandType = CommandType.Text;
            //Reader = Command.ExecuteReader();
            //DataTable tblformpermission = new DataTable();
            //tblformpermission.Load(Reader);
            //bool stat = false;
            //for (int i = 0; i < tblformpermission.Rows.Count; i++)
            //{
              
            //    if (tblformpermission.Rows[i][2].ToString() == formName && bool.Parse(tblformpermission.Rows[i][1].ToString()) == true)
            //    {
            //        stat = true;
            //    }
            //}
            //return stat;
            return false;
        }
    }
}
