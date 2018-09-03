using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
   public class Patient
    {
       public string OPID { get; set;}
       public string PhoneOPID { get; set; }
       public string PatientName { get; set; }
       public string ServiceDate { get; set; }
       public string Address { get; set; }
       public string Gender { get; set; }
       public string Age { get; set; }
       public string Phone { get; set; }
       public string Mobile { get; set; }
       public string Nationality { get; set; }
       public string MaritalStatus { get; set; }
       public string Doctor { get; set; }
       public string Fees { get; set; }
       public string TreatmentType { get; set; }
       public string BloodGroup { get; set; }
       public string FatherName { get; set; }
       public string MotherName { get; set; }
       public string Gurdian { get; set; }
       public string Relation { get; set; }
       public string Area { get; set; }
       public string Religion { get; set; }
       public string WardOrCabin { get; set; }
       public string DutyDoctorId { get; set; }
       public string RefferedBy { get; set; }
       public string SelectedBed { get; set; }
       public DateTime InputDate { get; set; }
       public TimeSpan AdmissionTime { get; set; }
       public string Department { get; set; }
       public string PatientCondition { get; set; }
       public string ContactPersonMobile { get; set; }
       public string ContactPerson { get; set; }
       public ConsultBillService ConsultBillServices { get; set; }
       public string Weight { get; set; }
       public string RegNo { get; set; }
    }
}
