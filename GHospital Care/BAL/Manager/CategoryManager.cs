using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class CategoryManager
    {
        CategoryGatway aCategoryGatway=new CategoryGatway();

        public List<Category> GetAllCategories()
        {
            return aCategoryGatway.GetAllCategories();
        }

    }
}
