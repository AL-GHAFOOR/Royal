using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    class Cabin
    {
        public int Id { get; set; }
        public string CabinName { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int CategoryId { get; set; }
        public int FloorId { get; set; }
        public int UserId { get; set; }
    }
}
