using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    class Bed
    {
        public int Id { get; set; }
        public string BedName { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public string Status { get; set; }
        public int FloorId { get; set; }
        public int CategoryId { get; set; }
        public int WardId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }

    }
}
