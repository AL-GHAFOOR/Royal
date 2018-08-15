using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class BirthInfoManager
    {
        readonly BirthInfoGatway aBirthInfoGatway = new BirthInfoGatway();

        public DataTable GetOpInfo()
        {
            DataTable data = new DataTable();
            data = aBirthInfoGatway.GetOpInfo();
            return data;
        }
        public DataTable GetBirthInfo()
        {
            DataTable data = new DataTable();
            data = aBirthInfoGatway.GetBirthInfo();
            return data;
        }
        public MessageModel SaveBirthInfo(BirthInfo aBirthInfo)
        {
            MessageModel aMessageModel = new MessageModel();
            string message = IsChecked(aBirthInfo);
            if (message != "Checked")
            {
                aMessageModel.MessageTitle = "Warning";
                aMessageModel.MessageBody = message;
                return aMessageModel;
            }
            if (aBirthInfoGatway.SaveBirthInfo(aBirthInfo) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Birth info saved successfully.";
            }

            return aMessageModel;
        }


        public MessageModel UpdateBirthInfo(BirthInfo aBirthInfo)
        {
            MessageModel aMessageModel = new MessageModel();

            if (aBirthInfoGatway.UpdateBirthInfo(aBirthInfo) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Birth info Updated successfully.";
            }
            return aMessageModel;
        }
        public MessageModel DeleteBirthInfo(BirthInfo aBirthInfo)
        {
            MessageModel aMessageModel = new MessageModel();
            if (aBirthInfoGatway.DeleteBirthInfo(aBirthInfo) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Birth info deleted successfully.";
            }
            return aMessageModel;
        }
       

        public string IsChecked(BirthInfo aBirthInfo)
        {
            string message = "";
            if (aBirthInfo.OPID == string.Empty)
            {
               return "Please Select Patient";
            }
            if (aBirthInfo.Weight == string.Empty)
            {
                return "Weight can't empty. Please insert weight.";
            }
            if (aBirthInfo.Height == string.Empty)
            {
                return "Height can't empty. Please insert Height.";
            }
            message = "Checked";
            return message;
        }

        public DataTable GenerateBirthRegID()
        {
            DataTable dataTable=new DataTable();
            dataTable=aBirthInfoGatway.GenerateBirthRegID();
            return dataTable;
        }
    }
}
