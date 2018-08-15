using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    class Ward
    {
        public int Id { get; set; }
        public string WardName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }
        public int BedId { get; set; }
        public int Rate { get; set; }
        public int UserId { get; set; }
    }
}
