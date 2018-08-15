using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    class FloorManager
    {
        private FloorGateway floorGateway = new FloorGateway();

        public List<Floor> GetAllFloors()
        {
            return floorGateway.GetAllFloors();
        }
    }
}
