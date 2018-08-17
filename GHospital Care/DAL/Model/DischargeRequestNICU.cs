using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class DischargeRequestNICU
    {
        public string Id { get; set; }
        public string OPID { get; set; }
        public string RegNo { get; set; }
        public string FatherHusbandName { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Consult { get; set; }
        public string weight { get; set; }
        public string Cabin_BedNo { get; set; }
        public DateTime AddmissionOn { get; set; }
        public DateTime DischargeOn { get; set; }
        public TimeSpan DischargeTime { get; set; }
        public string ContactNo { get; set; }
        public string DiagOnAdmission { get; set; }
        public string DiagOnDischarge { get; set; }
        public string StatusOnDischarge { get; set; }
        public string userId { get; set; }
        public bool Status { get; set; }
        public string Age { get; set; }
        public bool Cured { get; set; }
        public bool Improved { get; set; }
        public bool Dor { get; set; }
        public bool Dorb { get; set; }
        public bool NotImproved { get; set; }
        public DataTable Tempdatatable { get; set; }
        public string BreffHistory { get; set; }
        public string Route { get; set; }
        public string ReleatedToMeal { get; set; }
        public List<Advice> ListofAdvice { get; set; }

        public List<DischageDrugDetials> DischageDrugDetialses = new List<DischageDrugDetials>(); 
    }
}
