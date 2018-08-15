using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{

    public class NicuAdmissionManager
    {
        private MessageModel aMessageModel;
        private NicuAdmissionGatway aNicuAdmissionGatway;


        public MessageModel SaveNicuAdmission(NicuAddmission aNicuAddmission, string actionType, Service service)
        {
            aMessageModel = new MessageModel();
            aNicuAdmissionGatway = new NicuAdmissionGatway();
            int saveCount = aNicuAdmissionGatway.SaveNicuAdmission(aNicuAddmission, actionType, service);
            if (saveCount > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Nicu Admission Saved Successfull";
            }
            return aMessageModel;
        }


        public MessageModel DeleteNicuPatient(NicuAddmission aNicuAddmission)
        {
            MessageModel aMessageModel = new MessageModel();

            int rowCount = new NicuAdmissionGatway().DeleteNicuPatient(aNicuAddmission);
            if (rowCount > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Your data successfully deleted.";
                return aMessageModel;
            }
            else
            {
                aMessageModel.MessageTitle = "Warning!";
                aMessageModel.MessageBody = "Your data delete to faild.";
            }
            return aMessageModel;
        }

        public DataTable GetNicuRegId()
        {
            DataTable data = new DataTable();
            data = new NicuAdmissionGatway().GetNicuRegId();
            return data;
        }

        public DataTable GetNicuPatient(DateTime fromdate, DateTime ToDate)
        {
            DataTable data = new DataTable();
            data = new NicuAdmissionGatway().GetNicuPatients(fromdate, ToDate);
            return data;
        }

        public DataTable GetNicuBed()
        {
            DataTable data = new DataTable();
            data = new NicuAdmissionGatway().GetNicuBed();
            return data;
        }






    }
}
