using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;
using GHospital_Care.DAL.Model.ViewModel;

namespace GHospital_Care.BAL.Manager
{
    class BedManager
    {
        BedGatway aBedGatway=new BedGatway();

        //public List<Bed> GetAllFloors()
        //{
        //    return aBedGatway.GetAllFloors();
        //}

        public string SaveBeds(Bed aBed)
        {

            int rowAffected = aBedGatway.SaveBeds(aBed);
            if (rowAffected > 0)
            {
                return "Saved successfully";
            }
            return "Save failed";

        }

        public string UpdateBed(Bed aBed)
        {
            int isAffect = aBedGatway.UpdateBed(aBed);
            if (isAffect > 0)
            {
                return "Updated Successfully.";
            }
            return "Error! item has not been updated.";
        }

        public List<BedViewModel> GetAllBedFromView()
        {


            return aBedGatway.GetAllBedFromView();
        }

        public string DeleteBed(Bed aBed)
        {
            int rowAffect = aBedGatway.DeleteBed(aBed);
            if (rowAffect > 0)
            {
                return "Success! Bed name has been deleted";
            }
            return "Faild to delete.";
        }

    }
}
