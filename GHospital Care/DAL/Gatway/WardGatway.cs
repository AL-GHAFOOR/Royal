using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.DAL.Model.ViewModel;

namespace GHospital_Care.DAL.Gatway
{
    class WardGatway:GatwayConnection
    {
        //private string conString = ConfigurationManager.ConnectionStrings["HospitalDbConString"].ConnectionString;
        //private SqlConnection connection;
        //private SqlCommand command;
        //private SqlDataReader reader;
        //private string query;


        //public WardGatway()
        //{
        //    connection = new SqlConnection(conString);
        //}

        public int EditWard(Ward aWard)
        {
            Query = "UPDATE Ward SET WardName=@WardName,Description=@Description,CategoryId=@CategoryId,FloorId=@FloorId WHERE Id=@Id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", aWard.Id);
            Command.Parameters.AddWithValue("@WardName", aWard.WardName);
            Command.Parameters.AddWithValue("@Description", aWard.Description);
            Command.Parameters.AddWithValue("@CategoryId", aWard.CategoryId);
            Command.Parameters.AddWithValue("@FloorId", aWard.FloorId);


            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

        public int DeleteWard(Ward aWard)
        {
            Query = "DELETE FROM Ward WHERE Id='" + aWard.Id + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }

        public int SaveWard(Ward aWard)
        {
            Query = "INSERT INTO Ward(WardName,Description,CategoryId,FloorId)VALUES (@WardName,@Description,@CategoryId,@FloorId)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@WardName", aWard.WardName);
            Command.Parameters.AddWithValue("@Description", aWard.Description);
            Command.Parameters.AddWithValue("@CategoryId", aWard.CategoryId);
            Command.Parameters.AddWithValue("@FloorId", aWard.FloorId);


            int rowAffect = Command.ExecuteNonQuery();
            return rowAffect;
        }



        public int UpdateCabin(Cabin aCabin)
        {
            Query ="UPDATE Cabin SET CabinName=@cabinName,Description=@description,Rate=@rate, CategoryId=@categoryId, FloorId=@floorId WHERE Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@id", aCabin.Id);
            Command.Parameters.AddWithValue("@cabinName", aCabin.CabinName);
            Command.Parameters.AddWithValue("@description", aCabin.Description);
            Command.Parameters.AddWithValue("@rate", aCabin.Rate);
            Command.Parameters.AddWithValue("@categoryId", aCabin.CategoryId);
            Command.Parameters.AddWithValue("@floorId", aCabin.FloorId);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public DataTable GetAllWard(){
            Query = "SELECT * FROM ViewGetWard";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.CommandText = Query;
            Reader = Command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(Reader);
            return data;
        }

        public List<Ward> GetAllWards()
        {
            Query = "SELECT * FROM Ward";
            Command = new SqlCommand(Query, Connection);
            //Connection.Open();
            Reader = Command.ExecuteReader();
            List<Ward> wards = new List<Ward>();
            while (Reader.Read())
            {
                Ward ward = new Ward();
                ward.Id = (int)Reader["Id"];
                ward.WardName = Reader["WardName"].ToString();

                wards.Add(ward);
            }
            Reader.Close();
            //Connection.Close();

            return wards;
        }

        public int DeleteCabin(Cabin aCabin)
        {
            Query = "DELETE FROM Cabin WHERE Id = " + aCabin.Id;
            Command = new SqlCommand(Query, Connection);
            //Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            //Connection.Close();
            return rowAffect;
        }

        //public List<WardViewModel> GetAllWardFromView()
        //{
            //query = "SELECT * FROM ViewAllWards";
            //command = new SqlCommand(query, connection);
            //connection.Open();
            //reader = command.ExecuteReader();
            //List<WardViewModel> wardViewModels = new List<WardViewModel>();
            //int sl = 0;
            //while (reader.Read())
            //{
            //    sl++;
            //    WardViewModel aWardViewModel = new WardViewModel();

            //    aWardViewModel.Sl = Convert.ToInt32(sl);

            //    aWardViewModel.Id = (int)reader["Id"];
            //    aWardViewModel.WardName = reader["WardName"].ToString();
            //    aWardViewModel.Description = reader["Description"].ToString();
            //    aWardViewModel.FloorId = (int)reader["FloorId"];
            //    aWardViewModel.FloorName = reader["FloorName"].ToString();
            //    aWardViewModel.CategoryId = (int)reader["CategoryId"];
            //    aWardViewModel.CategoryName =reader["CategoryName"].ToString();
            //    aWardViewModel.Rate = (int)reader["Rate"];
            //    aWardViewModel.RoomId = (int)reader["RoomId"];
            //    aWardViewModel.RoomName = (reader["RoomName"].ToString();
            //    aWardViewModel.BedId = (int)reader["FloorId"];
            //    aWardViewModel.BedName = reader["FloorId"].ToString();

                
            //    wardViewModels.Add(wardViewModels);
            //}
            //reader.Close();
            //connection.Close();
            //return wardViewModels;
        //}




        //public int SaveUpdateWards(Ward aWard)
        //{
        //    Conn obCon = new Conn();
        //    SqlConnection ob = new SqlConnection(obCon.strCon);
        //    SqlCommand cmd = new SqlCommand("SP_SAVE_Ward", ob);

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    //cmd.Parameters.Add("@id", SqlDbType.Int);
        //    cmd.Parameters.Add("@wardName", SqlDbType.VarChar, 50);
        //    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 255);
        //    cmd.Parameters.Add("@categoryId", SqlDbType.Int);
        //    cmd.Parameters.Add("@floorId", SqlDbType.Int);
        //    cmd.Parameters.Add("@roomId", SqlDbType.Int);
        //    cmd.Parameters.Add("@bedId", SqlDbType.Int);
        //    cmd.Parameters.Add("@rate", SqlDbType.Int);

        //    //cmd.Parameters[0].Value = aWard.Id;
        //    cmd.Parameters[0].Value = aWard.WardName;
        //    cmd.Parameters[1].Value = aWard.Description;
        //    cmd.Parameters[2].Value = aWard.CategoryId;
        //    cmd.Parameters[3].Value = aWard.FloorId;
        //    cmd.Parameters[4].Value = aWard.RoomId;
        //    cmd.Parameters[5].Value = aWard.BedId;
        //    cmd.Parameters[6].Value = aWard.Rate;

        //    ob.Open();
        //    int rowAffect = cmd.ExecuteNonQuery();
        //    ob.Close();

        //    return rowAffect;






    }
}
