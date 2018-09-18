using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class PathologyMaster
    {
        public string PathologyName { get; set; }
        public string Address { get; set; }
        public string Alias { get; set; }
        public Decimal Amount { get; set; }
        public string PathId { get; set; }
        public string UserId { get; set; }
       
    }
}
