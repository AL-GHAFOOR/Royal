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

        public DataTable GetFreeOccupiedBedNICU(string Type, string AddType)
        {
            return new BedHistoryGateWay().GetIpdBedorCabinNICU(Type, AddType);
        }

        public DataTable CountFreeOccupiedBed(string Type, string AddType)
        {
            return new BedHistoryGateWay().Count_Free_OccupiedBed(Type, AddType);
        }

        public DataTable CountFreeOccupiedBedNICU(string Type, string AddType)
        {
            return new BedHistoryGateWay().Count_Free_OccupiedBed_NICU(Type, AddType);
        }

        public DataTable CountOccupiedBed(string Type, string AddType)
        {
            return new BedHistoryGateWay().Count_OccupiedBed(Type, AddType);
        }

        public DataTable CountOccupiedBedNICU(string Type, string AddType)
        {
            return new BedHistoryGateWay().Count_OccupiedBed_NICU(Type, AddType);
        }
        public DataTable GetIpInfo(DateTime admintdate1, DateTime admintdate2, string chkValue)
        {

            return new BedHistoryGateWay().GetIpInfo(admintdate1, admintdate2, chkValue);
        }

        public DataTable GetIpDpatientList(DateTime admintdate1, DateTime admintdate2)
        {

            return new BedHistoryGateWay().GetIndoorPatientList(admintdate1, admintdate2);
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

        public DataTable GetIpCabinBedListNICU(string patientID)
        {
            return new BedHistoryGateWay().GetIpBedCabinListNICU(patientID);
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


        public DataTable GetNICUpatientList(DateTime admintdate1, DateTime admintdate2)
        {
            return new BedHistoryGateWay().GetNICUPatientList(admintdate1, admintdate2);
        }

        public DataTable CountIP(DateTime admintdate1, DateTime admintdate2)
        {
            return new BedHistoryGateWay().Countpatient(admintdate1, admintdate2);
        }

        public DataTable CountIPDischarge(DateTime admintdate1, DateTime admintdate2)
        {
            return new BedHistoryGateWay().CountpatientDischarge(admintdate1, admintdate2);
        }

        public DataTable CountNICU(DateTime admintdate1, DateTime admintdate2)
        {
            return new BedHistoryGateWay().CountpatientNICU(admintdate1, admintdate2);
        }
        public DataTable CountNICUDischarge(DateTime admintdate1, DateTime admintdate2)
        {
            return new BedHistoryGateWay().CountpatientNICUDischarge(admintdate1, admintdate2);
        }
    }
}
