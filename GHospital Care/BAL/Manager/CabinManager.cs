using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;
using GHospital_Care.DAL.Model.ViewModel;

namespace GHospital_Care.BAL.Manager
{
    class CabinManager
    {
        CabinGatway aCabinGatway = new CabinGatway();

        public string SaveCabin(Cabin aCabin)
        {
            //if (aCabinGatway.IsCabinNameExist(aCabin))
            //{
            //    return "Cabin Name already exists";
            //}
            int rowAffected = aCabinGatway.SaveCabin(aCabin);
            if (rowAffected > 0)
            {
                return "Saved successfully";
            }
            return "Save failed";
        }


        public string UpdateCabin(Cabin aCabin)
        {
            int isAffect = aCabinGatway.UpdateCabin(aCabin);
            if (isAffect > 0)
            {
                return "Success! cabin has been updated.";
            }
            return "Error! cabin has not been updated.";
        }

        public List<CabinViewModel> GetAllCabinFromView()
        {
            return aCabinGatway.GetAllCabinFromView();
        }

        public string DeleteCabin(Cabin aCabin)
        {

            int rowAffect = aCabinGatway.DeleteCabin(aCabin);
            if (rowAffect > 0)
            {
                return "Deleted successfully";
            }

            return "Sorry! there is not data found.";
        }

    }
}
