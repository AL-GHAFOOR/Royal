using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Model
{
  public  class DischageDrugDetials
    {
       public int Id { get; set; }
        public string DrugName { get; set; }
       public string Doose { get; set; }
       public string DrugId { get; set; }
       public string Description { get; set; }
       public string Route { get; set; }
       public string RelatedToMeal { get; set; }
     


    }
}
