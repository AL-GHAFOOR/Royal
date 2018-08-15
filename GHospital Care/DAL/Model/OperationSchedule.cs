using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class OperationSchedule
    {
        public int Id { get; set; }
        public string OtRefNo { get; set; }
        public string Opid { get; set; }
        public string CabinBed { get; set; }
        public string PatientName { get; set; }
        public string FirstAssist { get; set; }
        public string SurgeonName { get; set; }
        public string SecondAssist { get; set; }
        public string Anaesthesiologist { get; set; }
        public string OperationName { get; set; }
        public TimeSpan OperationTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public DateTime OtDate { get; set; }
        public string UserId { get; set; }

    }
}
