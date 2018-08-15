using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class Comission
    {
        public string CommissionId { get; set; }
        public string ReffId { get; set; }
        public DateTime Date { get; set; }
        public string ReffName { get; set; }
        public Decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public string Inword { get; set; }
        public string Status { get; set; }
    }
}
