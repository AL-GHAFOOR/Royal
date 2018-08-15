using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class DeathInfoManager
    {
        private  DeathInfoGatway aDeathInfoGatway;
        public DataTable GetIndorPatientInfo()
        {
            aDeathInfoGatway=new DeathInfoGatway();
            DataTable data=new DataTable();
            data = aDeathInfoGatway.GetIndorPatientInfo();
            return data;
        }
        public MessageModel SaveDeathInfo(DeathInfo aDeathInfo)
        {
            MessageModel aMessageModel=new MessageModel();
            aDeathInfoGatway=new DeathInfoGatway();
            if (aDeathInfoGatway.SaveDeathInfo(aDeathInfo)>0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Death info saved successfully.";
            }
            return aMessageModel;
       }
        public MessageModel UpdateDeathInfo(DeathInfo aDeathInfo)
        {
            MessageModel aMessageModel = new MessageModel();
            aDeathInfoGatway = new DeathInfoGatway();
            if (aDeathInfoGatway.UpdateDeathInfo(aDeathInfo) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Death info updated successfully.";
            }
            return aMessageModel;
        }
        public DataTable GetDeathInfo()
        {

            DataTable data=new DataTable();
            //aDeathInfoGatway=new DeathInfoGatway();
            data=aDeathInfoGatway.GetDeathInfo();
            return data;
        }
        public MessageModel DeleteDeathInfo(DeathInfo aDeathInfo)
        {
            MessageModel aMessageModel = new MessageModel();
            aDeathInfoGatway = new DeathInfoGatway();
            if (aDeathInfoGatway.DeleteDeathInfo(aDeathInfo) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Death info deleted successfully.";
            }
            return aMessageModel;
        }
    }
}
