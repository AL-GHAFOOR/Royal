using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class ReceivedAmount
    {
        public int VoucherNo { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string AdmissionDate { get; set; }
        public string BillNo { get; set; }
        public string ColType { get; set; }
        public string PayType { get; set; }
        public double Discount { get; set; }
        public double NetAmount { get; set; }
        public string Remarks { get; set; }
        public string ReceivedBy { get; set; }
        public string Status { get; set; }
        public string Inword { get; set; }
        public string User { get; set; }
        public int RefferedBy { get; set; }


    }
}
