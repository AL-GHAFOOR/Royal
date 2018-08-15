using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    class RoomManager
    {RoomGatway aRoomGatway=new RoomGatway();
        public List<Room> GetAllRooms()
        {
            return aRoomGatway.GetAllRooms();
        }
    }
}
