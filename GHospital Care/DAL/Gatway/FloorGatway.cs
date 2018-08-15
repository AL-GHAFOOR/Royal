using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gatway
{
    class FloorGateway:GatwayConnection
    {
        //private string conString = ConfigurationManager.ConnectionStrings["HospitalDbConString"].ConnectionString;
        //private SqlConnection connection;
        //private SqlCommand command;
        //private SqlDataReader reader;
        //private string query;

        //public FloorGateway()
        //{
        //    connection = new SqlConnection(conString);
        //}

        public List<Floor> GetAllFloors()
        {
            Query = "SELECT * FROM Floor";
            Command = new SqlCommand(Query, Connection);
            //Connection.Open();
            Reader = Command.ExecuteReader();
            List<Floor> floors = new List<Floor>();
            while (Reader.Read())
            {
                Floor floor = new Floor();
                floor.Id = (int) Reader["Id"];
                floor.FloorName = Reader["FloorName"].ToString();
                floors.Add(floor);
            }
            Reader.Close();
            //Connection.Close();

            return floors;
        }

    }
}
