using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CrystalDecisions.ReportAppServer.DataDefModel;
using DevExpress.Xpo.DB.Helpers;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gateway
{
    public class IndoorPatientCollectionGateway : GatwayConnection
    {


        public DataTable IPCollection(DateTime fromdate, DateTime toDate, String C_Type)
        {
            Query = "select * from IndoorpatientCollection where Convert(date,Date) between '" + fromdate.Date + "'and '" + toDate.Date + "' and Type = '"+C_Type+"'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable IPCollection(DateTime fromdate, DateTime toDate)
        {
            Query = "select * from IndoorpatientCollection where Convert(date,Date) between '" + fromdate.Date + "'and '" + toDate.Date + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable OPCollection(DateTime fromdate, DateTime toDate, String C_Type)
        {
            Query = "select * from OutdoorpatientCollection where Convert(date,Date) between '" + fromdate.Date + "'and '" + toDate.Date + "'and Type = '" + C_Type + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
        public DataTable OPCollection(DateTime fromdate, DateTime toDate)
        {
            Query = "select * from OutdoorpatientCollection where Convert(date,Date) between '" + fromdate.Date + "'and '" + toDate.Date + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        //**********
        public DataTable NICUCollection(DateTime fromdate, DateTime toDate, String C_Type)
        {
            Query = "select * from NICUpatientCollection where Convert(date,Date) between '" + fromdate.Date + "'and '" + toDate.Date + "' and Type = '" + C_Type + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }

        public DataTable NICUCollection(DateTime fromdate, DateTime toDate)
        {
            Query = "select * from NICUpatientCollection where Convert(date,Date) between '" + fromdate.Date + "'and '" + toDate.Date + "'";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            DataTable dtDataTable = new DataTable();
            Reader = Command.ExecuteReader();
            dtDataTable.Load(Reader);
            return dtDataTable;
        }
    }
}
