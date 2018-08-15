using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class UserManager : MessageModel
    {

        public DataTable getUserID()
        {
            return new UserGateway().GenerateUserID();
        }
        public DataTable GetRole()
        {
            return new UserGateway().GetRole();
        }
        public DataTable getUserInput(ListView lstv)
        {
            return new UserGateway().GetUsreINput(lstv);
        }

        public DataTable getUserInfo()
        {
            return new UserGateway().UserInfo();
        }

        public DataTable FormLoad(string roleId)
        {
            return new UserGateway().FormLoad(roleId);
        }

        public DataTable getUserUpdate(string UsrID)
        {
            return new UserGateway().GetUserUpdate(UsrID);
        }

        public DataTable ChkMenuPermission(string UsrID)
        {
            return new UserGateway().chkpermission(UsrID);
        }

        public DataTable ChkMenu(string UsrID)
        {
            return new UserGateway().ChkMenu(UsrID);
        }

        public DataTable LoadUser(UserMaster UsrID)
        {
            return new UserGateway().ViewUserLoad(UsrID);
        }

        public DataTable RoleId()
        {
            return new UserGateway().RoleId();
        }

        private UserGateway UserMaster;
        public MessageModel SaveUserInfo(UserMaster aUserMaster)
        {
            UserMaster = new UserGateway();
            MessageModel messageModel = new MessageModel();
            if (UserMaster.SaveUser(aUserMaster) > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "User Information save successfully!";
            }
            return messageModel;
        }


        public MessageModel SaveMenuPermission(UserMaster aUserMaster)
        {
            UserMaster = new UserGateway();
            MessageModel messageModel = new MessageModel();
            int count = UserMaster.DeleteMenuPermission(aUserMaster);
            //count = UserMaster.UpdateUser_MenuPermission(aUserMaster);
            if (UserMaster.SaveMenuPermission(aUserMaster) > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "User Permission Save successfully!";
            }
            return messageModel;
        }



        public MessageModel SaveRole(UserMaster aUserMaster)
        {
            int count = 0;
            UserMaster = new UserGateway();
            MessageModel messageModel = new MessageModel();
            //int count = UserMaster.DeleteMenuPermission(aUserMaster);
            count = UserMaster.SaveRole(aUserMaster);
            if (UserMaster.SaveMenuPermission(aUserMaster) > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "Role Save successfully!";
            }

            return messageModel;
        }




        public MessageModel UpdateUser(UserMaster aUserMaster)
        {
            UserMaster = new UserGateway();
            MessageModel messageModel = new MessageModel();
            if (UserMaster.UpdateUser(aUserMaster) > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "User Information Update successfully!";
            }
            return messageModel;
        }

    }
}
