using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    class FollowUPGateway : GatwayConnection
    {

        public DataTable LoadFollowUpSubItem()
        {
            Query = "Select * from viewAllFollupItemWithSubItem ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public DataTable LoadDepartmetnwiseFollowUp(string department)
        {
            Query = "select M.FollowupId ItemID, F.FollowUpItemName, t.DeparmentName, M.DeptId from tblFollowUpSheetMaster M left join tblDeparment_Treatment T on T.Id = M.DeptId " +
                    "left join tblFollowUp F on F.ID = M.FollowupId  where DeparmentName = '" + department + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public int UpdateService(FollowUPMaster followUp)
        {
            int count = 0;

            Command = new SqlCommand("Update dbo.tblFollowUp set FollowUpItemName=@FollowUpItemName,Description=@Description,DepartmentID=@DepartmentID,Rate=@Rate where ID='" + followUp.ID + "'", Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@FollowUpItemName", followUp.FollowUpItemName);
            Command.Parameters.AddWithValue("@Description", followUp.Description);
            Command.Parameters.AddWithValue("@DepartmentID", "");
            Command.Parameters.AddWithValue("@Rate", followUp.Rate);
            count = Command.ExecuteNonQuery();

            Command = new SqlCommand("Delete tblFollowSubItems where  ItemID ='" + followUp.ID + "'", Connection);
            Command.CommandType = CommandType.Text;
            count = Command.ExecuteNonQuery();
            foreach (FollowUpSubItem subItem in followUp.SubItems)
            {
                Command = new SqlCommand("INSERT INTO dbo.tblFollowSubItems (ItemID,SubItemName,Id)"
                 + "VALUES(@ItemID,@SubItemName,@Id)", Connection);

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@ItemID", followUp.ID);
                Command.Parameters.AddWithValue("@SubItemName", subItem.SubItemName);
                Command.Parameters.AddWithValue("@Id", subItem.Id);
                count = Command.ExecuteNonQuery();
            }
            return count;
        }


        public DataTable LoadFollowUp()
        {
            Query = "select ID ItemID,FollowUpItemName, ''DepartmentName, ''DeptId from tblFollowUp  ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public DataTable LoadDepartmetnwiseSubFollowUp(string department, string MasterId)
        {
            Query = "select M.FollowSheetMasterId ItemID, F.SubItemName, t.DeparmentName, M.Department, M.FollowSheetDetailsID SubId from tblFollowUpSheetDetails M left join tblDeparment_Treatment T on T.Id = M.Department " +
                    "left join tblFollowSubItems F on F.ID = M.FollowSheetDetailsID where DeparmentName = '" + department + "' and ItemID = '" + MasterId + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public DataTable SubFollowUp(string MasterId)
        {
            Query = "select ItemId ItemID, SubItemName, ''DeparmentName,''DeptId,Id SubId from tblFollowSubItems where ItemID = '" + MasterId + "' ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }



        public DataTable followUPItemID()
        {
            Query = "select Isnull(Max(ID),0)+1 from tblFollowUp ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }


        public DataTable SubItemID()
        {
            Query = "select Isnull(Max(id),0)+1 from tblFollowSubItems ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public int InsertFollowupSheet(List<FollowUPMaster> FollowUp)
        {
            int count = 0;
            foreach (FollowUPMaster master in FollowUp)
            {
                Query = "Insert into tblFollowUpSheetMaster (DeptId,FollowupId) values(@DeptId,@FollowupId)";
                Command = new SqlCommand(Query, Connection);
                // Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@DeptId", Convert.ToInt16(master.DepartmentId));
                Command.Parameters.AddWithValue("@FollowupId", Convert.ToInt16(master.ID));
                count += Command.ExecuteNonQuery();

                foreach (FollowUpSubItem VARIABLE in master.SubItems)
                {
                    Query = "Insert into tblFollowUpSheetDetails (FollowSheetMasterId,FollowSheetDetailsID,Department) values(@FollowSheetMasterId,@FollowSheetDetailsID,@Department)";
                    // Command.CommandType = CommandType.Text;
                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@FollowSheetMasterId", Convert.ToInt16(master.ID));
                    Command.Parameters.AddWithValue("@FollowSheetDetailsID", Convert.ToInt16(VARIABLE.Id));
                    Command.Parameters.AddWithValue("@Department", Convert.ToInt16(master.DepartmentId)); count += Command.ExecuteNonQuery();


                }
            }
            return count;
        }
        public DataTable FollowMaster()
        {
            Query = "Select * from tblFollowUp ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public DataTable LoadTreatmentDepartment()
        {
            Query = "Select * from tblDeparment_Treatment ";
            Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }
        public int SaveFollowUPSetup(FollowUPMaster followUp)
        {
            int count = 0;

            Command = new SqlCommand("INSERT INTO dbo.tblFollowUp (FollowUpItemName,Description,DepartmentID,Rate, ID)"
                  + "VALUES(@FollowUpItemName,@Description,@DepartmentID,@Rate,@ID)", Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@FollowUpItemName", followUp.FollowUpItemName);
            Command.Parameters.AddWithValue("@Description", followUp.Description);
            Command.Parameters.AddWithValue("@DepartmentID", "");
            Command.Parameters.AddWithValue("@Rate", followUp.Rate);
            Command.Parameters.AddWithValue("@ID", followUp.ID);


            count = Command.ExecuteNonQuery();

            foreach (FollowUpSubItem subItem in followUp.SubItems)
            {
                Command = new SqlCommand("INSERT INTO dbo.tblFollowSubItems (ItemID,SubItemName,Id)"
                 + "VALUES(@ItemID,@SubItemName, @Id)", Connection);

                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@ItemID", followUp.ID);
                Command.Parameters.AddWithValue("@SubItemName", subItem.SubItemName);
                Command.Parameters.AddWithValue("@Id", subItem.Id);
                count = Command.ExecuteNonQuery();
            }






            return count;
        }
    }
}
