using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int UserId { get; set; }
    }
}
