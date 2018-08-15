using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    class WardManager
    {
        WardGatway aWardGatway = new WardGatway();

        public string SaveWard(Ward aWard)
        {
            //if (aWardGatway.IsWardNameExist(aCabin))
            //{
            //    return "Ward Name already exists";
            //}
         
            int rowAffected = aWardGatway.SaveWard(aWard);
            if (rowAffected > 0)
            {
                return "Saved successfully";
            }
            return "Save failed";
        }


        public DataTable GetAllWard()
        {
            DataTable data = new DataTable();
            data = aWardGatway.GetAllWard();
            return data;
        }

        public MessageModel EditWard(Ward aWard)
        {
            MessageModel messageModel = new MessageModel();
            if (aWardGatway.EditWard(aWard) > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "Ward info updated successfully.";
            }
            return messageModel;
        }
        public MessageModel DeleteWard(Ward aWard)
        {
            MessageModel messageModel = new MessageModel();
            if (aWardGatway.DeleteWard(aWard) > 0)
            {
                messageModel.MessageTitle = "Successfull";
                messageModel.MessageBody = "Ward info Deleted successfully.";
            }
            return messageModel;
        }

        //public string UpdateCabin(Cabin aCabin)
        //{
        //    int isAffect = aCabinGatway.UpdateCabin(aCabin);
        //    if (isAffect > 0)
        //    {
        //        return "Success! cabin has been updated.";
        //    }
        //    return "Error! cabin has not been updated.";
        //}

        //public List<CabinViewModel> GetAllCabinFromView()
        //{
        //    return aCabinGatway.GetAllCabinFromView();
        //}

        //public string DeleteCabin(Cabin aCabin)
        //{

        //    int rowAffect = aCabinGatway.DeleteCabin(aCabin);
        //    if (rowAffect > 0)
        //    {
        //        return "Deleted successfully";
        //    }

        //    return "Sorry! there is not data found.";
        //}




        public List<Ward> GetAllWards()
        {
            return aWardGatway.GetAllWards();
        }
    }
}
