using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class IssueMedine
    {
        public DateTime date { get; set; }
        public string OPID { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string M_IssueReff { get; set; }
        public DataTable MedineList { get; set; }
        public string batchId { get; set; }
        public string BatchName { get; set; }
        public string expd { get; set; }
        public string UserId { get; set; }
        public decimal Rate { get; set; }
        public String ServiceTotal { get; set; }
        public int Qty { get; set; }
        public long VoucherNo { get; set; }


    }
}
