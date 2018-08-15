using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gatway
{
    public class RefferedInfoGatway : GatwayConnection
    {
        public int SaveRefferedInfo(RefferedInfo aRefferedInfo)
        {
            Query = "INSERT INTO RefferedInfo(Name,Address,MobileNo,Email,Designation,UserId,Commission)VALUES(@Name,@Address,@MobileNo,@Email,@Designation,@UserId,@Commission)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Name", aRefferedInfo.Name ?? "");
            Command.Parameters.AddWithValue("@Address", aRefferedInfo.Address ?? "");
            Command.Parameters.AddWithValue("@MobileNo", aRefferedInfo.MobileNo ?? "");
            Command.Parameters.AddWithValue("@Email", aRefferedInfo.Email ?? "");
            Command.Parameters.AddWithValue("@Designation", aRefferedInfo.Designation ?? "");
            Command.Parameters.AddWithValue("@UserId", aRefferedInfo.UserId ?? "");
            Command.Parameters.AddWithValue("@Commission", aRefferedInfo.Commission ?? "");
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }



        public int UpdateRefferedInfo(RefferedInfo aRefferedInfo)
        {
            Query = "UPDATE RefferedInfo SET Name=@Name,Address=@Address,MobileNo=@MobileNo,Email=@Email,Designation=@Designation,UserId=@UserId,Commission=@Commission  WHERE Id='" + aRefferedInfo.Id + "'";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Name", aRefferedInfo.Name ?? "");
            Command.Parameters.AddWithValue("@Address", aRefferedInfo.Address ?? "");
            Command.Parameters.AddWithValue("@MobileNo", aRefferedInfo.MobileNo ?? "");
            Command.Parameters.AddWithValue("@Email", aRefferedInfo.Email ?? "");
            Command.Parameters.AddWithValue("@Designation", aRefferedInfo.Designation ?? "");
            Command.Parameters.AddWithValue("@UserId", aRefferedInfo.UserId ?? "");
            Command.Parameters.AddWithValue("@Commission", aRefferedInfo.Commission ?? "");

            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

        public int DeleteRefferedInfo(RefferedInfo aRefferedInfo)
        {
            Query = "DELETE FROM RefferedInfo WHERE Id='" + aRefferedInfo.Id + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }



        public DataTable PopulateGridView()
        {
            Query = "SELECT * FROM Refferedinfo";
            Command = new SqlCommand(Query, Connection);
            Command.CommandType = CommandType.Text;
            Reader = Command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(Reader);
            return dataTable;
        }




    }
}
