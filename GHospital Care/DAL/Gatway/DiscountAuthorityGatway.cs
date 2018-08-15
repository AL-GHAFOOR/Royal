using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CrystalDecisions.ReportAppServer.DataDefModel;
using DevExpress.Xpo.DB.Helpers;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gatway
{
    public class DiscountAuthorityGatway : GatwayConnection
    {
        public int SaveDiscountAuthority(DiscountAuthority aDiscountAuthority)
        {
            Query = "INSERT INTO DiscountAuthority (Name,Address,MobileNo,Email,Designation,UserId) VALUES (@Name,@Address,@MobileNo,@Email,@Designation,@UserId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Name", aDiscountAuthority.Name ?? "");
            Command.Parameters.AddWithValue("@Address", aDiscountAuthority.Address ?? "");
            Command.Parameters.AddWithValue("@MobileNo", aDiscountAuthority.MobileNo ?? "");
            Command.Parameters.AddWithValue("@Email", aDiscountAuthority.Email ?? "");
            Command.Parameters.AddWithValue("@Designation", aDiscountAuthority.Designation ?? "");
            Command.Parameters.AddWithValue("@UserId", aDiscountAuthority.UserId ?? "");
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }



        public int UpdateDiscountAuthority(DiscountAuthority aDiscountAuthority)
        {
            Query = "UPDATE DiscountAuthority SET Name=@Name,Address=@Address,MobileNo=@MobileNo,Email=@Email,Designation=@Designation,UserId=@UserId  WHERE Id='" + aDiscountAuthority.Id + "'";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Name", aDiscountAuthority.Name ?? "");
            Command.Parameters.AddWithValue("@Address", aDiscountAuthority.Address ?? "");
            Command.Parameters.AddWithValue("@MobileNo", aDiscountAuthority.MobileNo ?? "");
            Command.Parameters.AddWithValue("@Email", aDiscountAuthority.Email ?? "");
            Command.Parameters.AddWithValue("@Designation", aDiscountAuthority.Designation ?? "");
            Command.Parameters.AddWithValue("@UserId", aDiscountAuthority.UserId ?? "");
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

        public int DeleteDiscountAuthority(DiscountAuthority aDiscountAuthority)
        {
            Query = "DELETE FROM DiscountAuthority WHERE Id='" + aDiscountAuthority.Id + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }



        public DataTable PopulateGridView()
        {
            Query = "SELECT * FROM DiscountAuthority";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(Reader);
            return dataTable;
        }




    }
}
