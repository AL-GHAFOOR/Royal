
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class DischargeBillNICU
    {
        
        public int Id { get; set; }
        public string OPID { get; set; }
        public string BillType { get; set; }
        public string BillNo { get; set; }
        public string Remarks { get; set; }
        public string RegNo { get; set; }
        public string InwardText { get; set; }
        public string DiscTime { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeisDate { get; set; }

        //....................................................................


        public string PatientName { get; set; }
        public string Age { get; set; }
        public string BloodGroup { get; set; }
        public string TConsultBill { get; set; }
        public string OT_TOtalBill { get; set; }
        public double PBill { get; set; }
        public string TotalBedCharge { get; set; }
        public string NoOfDay { get; set; }
        public double TotalBill { get; set; }
        public double Tax { get; set; }
        public double SubTotal { get; set; }
        public double NetPayble { get; set; }
        public double AdvancedPayble { get; set; }
        public double discount { get; set; }
        public double servicePercent { get; set; }
        public double HospitalCharge { get; set; }
        public double NurseCharge { get; set; }
        public double DoctorCharge { get; set; }
        public double RoomBedCharge { get; set; }
        public double OTService { get; set; }
        public double OTMedicin { get; set; }
        public double vat { get; set; }
        public double ServiceCharge { get; set; }

        public double MedicalCharge { get; set; }

        public double PathologyBill { get; set; }
        public double PharmacyBill { get; set; }
        public double OTservice { get; set; }
        public double OTMedicine { get; set; }
        public DataTable PatientBill { get; set; }

        public DischargeBillNICU ServiceParticular { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceStatus { get; set; }
        public decimal Total { get; set; }

    }
}
