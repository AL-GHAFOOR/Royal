using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    class BedHistoryManager : MessageModel
    {
        public DataTable GetFreeOccupiedBed(string Type, string AddType)
        {
            return new BedHistoryGateWay().GetIpdBedorCabin(Type,AddType);
        }

        public DataTable CountFreeOccupiedBed(string Type, string AddType)
        {
            return new BedHistoryGateWay().Count_Free_OccupiedBed(Type, AddType);
        }

        public DataTable CountOccupiedBed(string Type, string AddType)
        {
            return new BedHistoryGateWay().Count_OccupiedBed(Type, AddType);
        }
        public DataTable GetIpInfo(DateTime admintdate1, DateTime admintdate2, bool chkValue)
        {

            return new BedHistoryGateWay().GetIpInfo(admintdate1, admintdate2, chkValue);
        }

        public DataTable GetOPInfo(DateTime admintdate1, DateTime admintdate2, bool chkValue)
        {

            return new BedHistoryGateWay().GetOPInfo(admintdate1.Date, admintdate2.Date, chkValue);
        }

        public DataTable GetOtInfo(DateTime admintdate1, DateTime admintdate2)
        {

            return new BedHistoryGateWay().GetOtInfo(admintdate1.Date, admintdate2.Date);
        }

        //GetOtInfo
        public DataTable GetIpCabinBedList(string patientID)
        {
            return new BedHistoryGateWay().GetIpBedCabinList(patientID);
        }


        private BedHistoryGateWay aBedHistoryGateWay;
        public MessageModel SaveBedShipment(IPDBedHistory aBedHistory,Patient patient)
        {
            aBedHistoryGateWay = new BedHistoryGateWay();
            MessageModel messageModel = new MessageModel();
            if (aBedHistoryGateWay.SaveIPDBedHistory(aBedHistory) > 0)
            {
                if (aBedHistoryGateWay.UpdatePatientBedIPD(patient) > 0)
                {
                    messageModel.MessageTitle = "Successfull";
                    messageModel.MessageBody = "Indoor Patient Shipment information save successfully!";
                }
               
            }
           return messageModel;
        }


        public DataTable CountIP(DateTime admintdate1, DateTime admintdate2)
        {
            return new BedHistoryGateWay().Countpatient(admintdate1, admintdate2);
        }
    }
}
