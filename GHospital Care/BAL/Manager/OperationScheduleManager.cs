using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class OperationScheduleManager
    {
        private OperationScheduleGateway aOperationScheduleGateway=new OperationScheduleGateway();
        private DataTable data;
        
        public MessageModel SaveOperationSchedule(OperationSchedule operationSchedule)
        {
            int saveCount = new OperationScheduleGateway().SaveOperationSchedule(operationSchedule);
            MessageModel messageModel = new MessageModel();
            if (saveCount > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "OT Setup information saved successfully!";

            }
            return messageModel;
        }

        public MessageModel UpdateOperationSchedule(OperationSchedule operationSchedule)
        {
            MessageModel aMessageModel = new MessageModel();
            if (aOperationScheduleGateway.UpdateOperationSchedule(operationSchedule) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "OT Setup information saved successfully.";
            }
            return aMessageModel;
        }



   
        
        public MessageModel DeleteOperationSchedule(OperationSchedule aOperationSchedule)
        {
            MessageModel aMessageModel = new MessageModel();
            if (aOperationScheduleGateway.DeleteOperationSchedule(aOperationSchedule) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Operaiton Schedule Deleted successfully!";
            }
            return aMessageModel;
        }

        public DataTable GetOpInfo()
        {
            data=new DataTable();
            data = aOperationScheduleGateway.GetOpInfo();
            return data;
        }


        public DataTable GetOTRef()
        {
            data = new DataTable();
            data = aOperationScheduleGateway.GenerateOTRef();
            return data;
        }
        public DataTable GetOperationSchedule(DateTime FromDate, DateTime ToDate)
        {
            data = new DataTable();
            data = aOperationScheduleGateway.GetOperationSchedule(FromDate, ToDate);
            return data;
        }



    }
}
