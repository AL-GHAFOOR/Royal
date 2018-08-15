using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class Service
    {
        public string  GodownId { get; set; }
        public int ID { get; set; }
        public string ServiceId { get; set; }
        public string BatchID { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public string OtReffNo { get; set; }
        public string OPID { get; set; }
        public int Qty { get; set; }
        public long VoucherNo { get; set; }
        public string PathID { get; set; }

        public double Total { get; set; }
        public DateTime IssueDate { get; set; }
        public List<OT_Consump> OtConsump { get; set; }
        public List<IssueMedine> IssueMedines { get; set; }
        public List<Service> PatientService { get; set; }
        public List<Service> Path_Service { get; set; }
        public string Catgory { get; set; }
        public List<ConsultBillService> AConsultBill { get; set; }
        public List<PatientService> GetPatientServices { get; set; }
        public List<PatientService> GetPathologyServices { get; set; }
        public StockPosting StockPosting { get; set; }




        //new added 
        public string NicuRegNo { get; set; }
    }
}
