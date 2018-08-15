using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    class FollowUPMaster
    {

        public int ID { get; set; }
        public string FollowUpItemName { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public string FollowUpItemId { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Qty { get; set; }
        public long VoucherNo { get; set; }
        public List<FollowUpSubItem> SubItems { get; set; }
 
    }
}
