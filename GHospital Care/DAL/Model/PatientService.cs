using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
   public class PatientService
    {

        
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public string OPID { get; set; }
        public int Qty { get; set; }
        public double Total { get; set; }
        public DateTime IssueDate { get; set; }
        public string Catgory { get; set; }
        public long VoucherNo { get; set; }
        public string Pathology { get; set; }
        public string PathId { get; set; }
    }
}
