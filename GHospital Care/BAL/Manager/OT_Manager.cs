using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class OT_Manager
    {
        public MessageModel SaveOT_Setup(OtSetup _OtSetup)
        {
            int saveCount = new OTGateway().SaveOTSetup(_OtSetup);
            MessageModel messageModel = new MessageModel();
            if (saveCount > 0)
            {

                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "OT Setup information saved successfully!";

            }
            return messageModel;
        }

        public OtSetup GetOtSetupByPatientId(string pid)
        {
          DataTable listOfOtSetup = new OTGateway().GetOtSetupByPatientId(pid);
           OtSetup setup=new OtSetup();
            if (listOfOtSetup.Rows.Count > 0)
            {
                setup.Pid = listOfOtSetup.Rows[0]["OPID"].ToString();
                setup.OtReffNo = listOfOtSetup.Rows[0]["OtRefNo"].ToString();
                setup.Cabin_Bed = listOfOtSetup.Rows[0]["BedName"].ToString();
                setup.Date = Convert.ToDateTime(listOfOtSetup.Rows[0]["OtDate"].ToString());
                setup.SurgenId = listOfOtSetup.Rows[0]["DoctorName"].ToString();
                setup.Anstology = listOfOtSetup.Rows[0]["AnthName"].ToString();
                setup.FirstAsst = listOfOtSetup.Rows[0]["FirstAsstName"].ToString();
                setup.SecondAsst = listOfOtSetup.Rows[0]["SecondAssist"].ToString();
                setup.OpName = listOfOtSetup.Rows[0]["OperationName"].ToString();
                setup.OT_From = TimeSpan.Parse(listOfOtSetup.Rows[0]["OperationTime"].ToString());
                setup.OT_To = TimeSpan.Parse(listOfOtSetup.Rows[0]["ToTime"].ToString());
            }
            return setup;
        }
    }
}
