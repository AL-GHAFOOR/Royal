using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class RefferedInfoManager
    {

        private RefferedInfoGatway aRefferedInfoGatway;
        public MessageModel SaveRefferedInfo(RefferedInfo aRefferedInfo)
        {
            MessageModel aMessageModel = new MessageModel();
            aRefferedInfoGatway = new RefferedInfoGatway();

            if (aRefferedInfoGatway.SaveRefferedInfo(aRefferedInfo) > 0)
            {
                aMessageModel.MessageTitle = "Successful";
                aMessageModel.MessageBody = "Reffered information saved successfully.";
            }
            return aMessageModel;
        }

        public DataTable PopulateGridView()
        {
            aRefferedInfoGatway = new RefferedInfoGatway();
            DataTable dataTable = aRefferedInfoGatway.PopulateGridView();
            return dataTable;
        }

        public MessageModel UpdateRefferedInfo(RefferedInfo aRefferedInfo)
        {
            MessageModel aMessageModel = new MessageModel();
            aRefferedInfoGatway = new RefferedInfoGatway();

            if (aRefferedInfoGatway.UpdateRefferedInfo(aRefferedInfo) > 0)
            {
                aMessageModel.MessageTitle = "Successful";
                aMessageModel.MessageBody = "Reffered information Updated successfully.";
            }
            return aMessageModel;
        }

        public DataTable GetRefferedIdByName(string RefferedName)
        {
            aRefferedInfoGatway = new RefferedInfoGatway();
            DataTable dataTable = aRefferedInfoGatway.PopulateGridView();
            return dataTable;
        }

        public MessageModel DeleteRefferedInfo(RefferedInfo aRefferedInfo)
        {
            MessageModel aMessageModel = new MessageModel();
            aRefferedInfoGatway = new RefferedInfoGatway();
            if (aRefferedInfoGatway.DeleteRefferedInfo(aRefferedInfo) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Reffered info deleted successfully.";
            }
            return aMessageModel;
        }





    }
}
