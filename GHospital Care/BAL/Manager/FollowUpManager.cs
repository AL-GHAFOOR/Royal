using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    class FollowUpManager:MessageModel
    {


        MessageModel messageModel = new MessageModel();
        public DataTable GetDeparmentTreatment()
        {
            return new FollowUPGateway().LoadTreatmentDepartment();
        }

        public string SaveFollowUpSheet(List<FollowUPMaster> masters)
        {
            int count = new FollowUPGateway().InsertFollowupSheet(masters);
            if (count > 0)
            {
                return "Saved Follow Up Sheet";
            }
            return "Saved Failed";
        }

        public DataTable GetSubItemID()
        {
            DataTable Dt = new FollowUPGateway().SubItemID();
            return Dt;
        }

        public DataTable GetMasterItemID()
        {
            DataTable Dt = new FollowUPGateway().followUPItemID();
            return Dt;
        }

        public List<FollowUPMaster> GetALLFollowUpWithSubItems()
        {
            List<FollowUPMaster> ListOfList = new List<FollowUPMaster>();
            DataTable master = new FollowUPGateway().FollowMaster();
            try
            {
                DataTable detials = new FollowUPGateway().LoadFollowUpSubItem().AsEnumerable().Where(a => Convert.ToInt16(a["ItemID"]) != 0).CopyToDataTable();
                foreach (DataRow dataRow in master.Rows)
                {
                    FollowUPMaster followup = new FollowUPMaster(); 
                    followup.SubItems = new List<FollowUpSubItem>();
                    var id = dataRow["ID"];
                    followup.ID = Convert.ToInt16(id);
                    followup.FollowUpItemName = dataRow["FollowUpItemName"].ToString();
                    foreach (DataRow row in detials.Rows)
                    {
                        if (Convert.ToInt16(row["ItemID"]) == followup.ID)
                        {
                            followup.SubItems.Add(new FollowUpSubItem()
                            {
                                ItemId = followup.ID,
                                Id = row["SubId"].ToString(),
                                SubItemName = row["SubItemName"].ToString()
                            });
                        }

                    }
                    ListOfList.Add(followup);
                 }
            }
            catch (Exception ex)
            {

                string messag = ex.Message;
            }


            return ListOfList.ToList();
        }

        public MessageModel UpdateService(FollowUPMaster FollowUP)
        {

            int saveService = new FollowUPGateway().UpdateService(FollowUP);
            if (saveService > 0)
            {
                messageModel.MessageBody = "FollowUP Item Update successfully!";
                messageModel.MessageTitle = "Successfull";

            }
            return messageModel;
        }



        public List<FollowUPMaster> GetALLFollowUpWithSubItemsByDepartment(string Department, string Master)
        {
            List<FollowUPMaster> ListOfList = new List<FollowUPMaster>();
            DataTable master = new FollowUPGateway().LoadDepartmetnwiseFollowUp(Department);
           
            try
            {
                //.AsEnumerable().Where(a => Convert.ToInt16(a["ItemID"]) != 0).CopyToDataTable();
                foreach (DataRow dataRow in master.Rows)
                {
                    DataTable detials = new FollowUPGateway().LoadDepartmetnwiseSubFollowUp(Department, dataRow["ItemID"].ToString());
                    FollowUPMaster followup = new FollowUPMaster();
                    followup.SubItems = new List<FollowUpSubItem>();
                    var id = dataRow["ItemID"];
                    followup.ID = Convert.ToInt16(id);
                    followup.FollowUpItemName = dataRow["FollowUpItemName"].ToString();
                    //followup.DepartmentName = dataRow["DepartmentName"].ToString();

                    foreach (DataRow row in detials.Rows)
                    {
                        if (Convert.ToInt16(row["ItemID"]) == followup.ID )
                        {
                            followup.SubItems.Add(new FollowUpSubItem()
                            {
                                ItemId = followup.ID,
                                Id =row["SubId"].ToString(),
                                SubItemName = row["SubItemName"].ToString()
                            });
                        }

                    }

                    ListOfList.Add(followup);
                }
            }
            catch (Exception ex)
            {

                string messag = ex.Message;
            }


            return ListOfList.ToList();
        }


        public List<FollowUPMaster> GetALLFollowUpWithSubItems( string Master)
        {
            List<FollowUPMaster> ListOfList = new List<FollowUPMaster>();
            DataTable master = new FollowUPGateway().LoadFollowUp();
            try
            {
                //.AsEnumerable().Where(a => Convert.ToInt16(a["ItemID"]) != 0).CopyToDataTable();
                foreach (DataRow dataRow in master.Rows)
                {
                    DataTable detials = new FollowUPGateway().SubFollowUp(dataRow["ItemID"].ToString());
                    FollowUPMaster followup = new FollowUPMaster();
                    followup.SubItems = new List<FollowUpSubItem>();
                    var id = dataRow["ItemID"];
                    followup.ID = Convert.ToInt16(id);
                    followup.FollowUpItemName = dataRow["FollowUpItemName"].ToString();
                    //followup.DepartmentName = dataRow["DepartmentName"].ToString();

                    foreach (DataRow row in detials.Rows)
                    {
                        if (Convert.ToInt16(row["ItemID"]) == followup.ID)
                        {
                            followup.SubItems.Add(new FollowUpSubItem()
                            {
                                ItemId = followup.ID,
                                Id = row["SubId"].ToString(),
                                SubItemName = row["SubItemName"].ToString()
                            });
                        }

                    }

                    ListOfList.Add(followup);
                }
            }
            catch (Exception ex)
            {

                string messag = ex.Message;
            }


            return ListOfList.ToList();
        }

        public MessageModel SaveService(FollowUPMaster FollowUP)
        {

            int saveService = new FollowUPGateway().SaveFollowUPSetup(FollowUP);
            if (saveService > 0)
            {
                messageModel.MessageBody = "FollowUP Item save successfully!";
                messageModel.MessageTitle = "Successfull";

            }
            return messageModel;
        }
    }
}
