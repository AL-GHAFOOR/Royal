using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model.ViewModel
{
    class BedViewModel
    {

        public int Sl { get; set; }
        public int Id { get; set; }
        public string BedName { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public int FloorId { get; set; }
        public string FloorName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int WardId { get; set; }
        public string WardName { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }

    }
}
