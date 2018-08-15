using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class StockPosting
    {

        public string voucherType { get; set; }
        public string StockPostingId { get; set; }
        public string voucherNo { get; set; }
        public string productCode { get; set; }
        public string batchId { get; set; }
        public string godownId { get; set; }
        public decimal inwardQty { get; set; }
        public decimal outwardQty { get; set; }
        public decimal rate { get; set; }
        public string unitId { get; set; }
        public decimal optional { get; set; }
        public string branchId { get; set; }
        public string extra1 { get; set; }
        public string extra2 { get; set; }
        public string rackId { get; set; }
        public decimal OutwardAltQty { get; set; }
        public string referenceNo { get; set; }
        public DateTime date { get; set; }
        public string DOno { get; set; }


      
    }
}
