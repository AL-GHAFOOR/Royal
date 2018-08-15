using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
    public class DeathInfo
    {
        public int Id { get; set; }
        public string DeathRegNo { get; set; }
        public string Name { get; set; }
        public DateTime IssueDate { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string DeathTime { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Nationality { get; set; }
        public string UserId { get; set; }
        public string Opid { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string Floor { get; set; }
        public string Cabin { get; set; }
        public string Bed { get; set; }
        public string Religion { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string IntervalBetween { get; set; }



    }
}
