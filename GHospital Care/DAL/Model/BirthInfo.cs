using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class BirthInfo
    {
        public int Id { get; set; }
        public string BirthRegNo { get; set; }
        public string Name { get; set; }
        public DateTime IssueDate { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string FathersNationality { get; set; }
        public string MothersNationality { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthTime { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserId { get; set; }
        public string CabinBed { get; set; }
        public string TypeOfDelivery { get; set; }



        public string OPID { get; set; }




    }
}
