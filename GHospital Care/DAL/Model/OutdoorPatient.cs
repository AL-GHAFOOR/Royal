using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class OutdoorPatient
    {
        public string Opid { get; set; }
        public DateTime ServiceDate { get; set; }
        public string TreatementType { get; set; }
        public string PatientName { get; set; }
        public string GurdianName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string Doctor { get; set; }
        public string Fees { get; set; }
        public Service AService { get; set; }
        public string RefferedBy { get; set; }




    }
}
