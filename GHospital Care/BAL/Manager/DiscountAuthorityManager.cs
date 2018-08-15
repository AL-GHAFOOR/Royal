using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gatway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class DiscountAuthorityManager
    {
        private DiscountAuthorityGatway aDiscountAuthorityGatway;
        public MessageModel SaveDiscountAuthority(DiscountAuthority aDiscountAuthority)
        {
            MessageModel aMessageModel = new MessageModel();
            aDiscountAuthorityGatway = new DiscountAuthorityGatway();

            if (aDiscountAuthorityGatway.SaveDiscountAuthority(aDiscountAuthority) > 0)
            {
                aMessageModel.MessageTitle = "Successful";
                aMessageModel.MessageBody = "Discount authority information saved successfully.";
                return aMessageModel;
            }
            else
            {
                aMessageModel.MessageTitle = "Error!";
                aMessageModel.MessageBody = "Discount authority Saved to failed.";
            }
            return aMessageModel;
        }

        public DataTable PopulateGridView()
        {
            aDiscountAuthorityGatway = new DiscountAuthorityGatway();
            DataTable dataTable = aDiscountAuthorityGatway.PopulateGridView();
            return dataTable;
        }

        public MessageModel UpdateDiscountAuthority(DiscountAuthority aDiscountAuthority)
        {
            MessageModel aMessageModel = new MessageModel();
            aDiscountAuthorityGatway = new DiscountAuthorityGatway();

            if (aDiscountAuthorityGatway.UpdateDiscountAuthority(aDiscountAuthority) > 0)
            {
                aMessageModel.MessageTitle = "Successful";
                aMessageModel.MessageBody = "Discount authority information Updated successfully.";
            }
            return aMessageModel;
        }

        public MessageModel DeleteDiscountAuthority(DiscountAuthority aDiscountAuthority)
        {
            MessageModel aMessageModel = new MessageModel();
            aDiscountAuthorityGatway = new DiscountAuthorityGatway();
            if (aDiscountAuthorityGatway.DeleteDiscountAuthority(aDiscountAuthority) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Discount authority information deleted successfully.";
            }
            return aMessageModel;
        }
    }
}
