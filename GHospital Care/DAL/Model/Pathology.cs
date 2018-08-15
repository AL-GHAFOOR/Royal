using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class Pathology
    {

        public string VoucherNo { get; set; }
        public string Particulars { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Decimal Amount { get; set; }
        public string InWord { get; set; }
        public string UserId { get; set; }
        public string Inword { get; set; }
        public string Status { get; set; }
    }
}
