using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gatway
{
    class RoomGatway:GatwayConnection
    {
        public List<Room> GetAllRooms()
        {
            Query = "SELECT * FROM Room";
            Command = new SqlCommand(Query, Connection);
            
            Reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (Reader.Read())
            {
                Room room = new Room();
                room.Id = (int) Reader["Id"];
                room.RoomName = Reader["RoomName"].ToString();
                rooms.Add(room);
            }
            Reader.Close();

            return rooms;
        }

    }
}
