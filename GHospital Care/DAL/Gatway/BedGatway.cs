using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CrystalDecisions.ReportAppServer.DataDefModel;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.DAL.Model.ViewModel;

namespace GHospital_Care.DAL.Gatway
{
    class BedGatway:GatwayConnection
    {
        //private string conString = ConfigurationManager.ConnectionStrings["HospitalDbConString"].ConnectionString;
        //private SqlConnection connection;
        //private SqlCommand command;
        //private SqlDataReader reader;
        //private string query;

        //public BedGatway()
        //{
        //    Connection = new SqlConnection(ConnectionString);
        //}

        public int SaveBeds(Bed aBed)
        {
            Query = "INSERT INTO Bed (BedName, Description, Rate, FloorId,CategoryId,RoomId, WardId)VALUES(@bedName,@description,@rate,@floorId,@categoryId,@roomId,@wardId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@bedName", aBed.BedName);
            Command.Parameters.AddWithValue("@description", aBed.Description);
            Command.Parameters.AddWithValue("@rate", aBed.Rate);
            Command.Parameters.AddWithValue("@floorId", aBed.FloorId);
            Command.Parameters.AddWithValue("@categoryId", aBed.CategoryId);
            Command.Parameters.AddWithValue("@roomId", aBed.RoomId);
            Command.Parameters.AddWithValue("@wardId", aBed.WardId);
            
            //Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            //Connection.Close();
            return rowAffect;
        }


        public List<BedViewModel> GetAllBedFromView()
        {
            Query = "SELECT * FROM ViewAllBeds ORDER BY BedName";
            Command = new SqlCommand(Query, Connection);
            //Connection.Open();
            Reader= Command.ExecuteReader();
            List<BedViewModel> bedViewModels = new List<BedViewModel>();
            int sl = 0;
            while (Reader.Read())
            {
                sl++;
                BedViewModel aBedViewModel= new BedViewModel();
                aBedViewModel.Sl = Convert.ToInt32(sl);
                aBedViewModel.Id = Convert.ToInt32(Reader["BedId"]);
                aBedViewModel.BedName = Reader["BedName"].ToString();
                aBedViewModel.Description = Reader["BedDescription"].ToString();
                aBedViewModel.Rate =Convert.ToInt32(Reader["Rate"]);
                aBedViewModel.FloorId = Convert.ToInt32(Reader["FloorId"]);
                aBedViewModel.FloorName = Reader["FloorName"].ToString();
                aBedViewModel.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                aBedViewModel.CategoryName = Reader["CategoryName"].ToString();
                aBedViewModel.WardId = Convert.ToInt32(Reader["WardId"]);
                aBedViewModel.WardName = Reader["WardName"].ToString();
                aBedViewModel.RoomId = Convert.ToInt32(Reader["RoomId"]);
                aBedViewModel.RoomName = Reader["RoomName"].ToString();

                bedViewModels.Add(aBedViewModel);
            }
            Reader.Close();
            //Connection.Close();
            return bedViewModels;
        }

        public int UpdateBed(Bed aBed)
        {
            Query = @"UPDATE Bed SET BedName =@bedName,Description=@description,Rate=@rate,FloorId=@floorId, CategoryId=@categoryId,RoomId=@roomId, WardId=@wardId WHERE Id=@id";
            Command= new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@id", aBed.Id);
            Command.Parameters.AddWithValue("@bedName", aBed.BedName);
            Command.Parameters.AddWithValue("@description", aBed.Description);
            Command.Parameters.AddWithValue("@rate", aBed.Rate);
            Command.Parameters.AddWithValue("@floorId", aBed.FloorId);
            Command.Parameters.AddWithValue("@categoryId", aBed.CategoryId);
            Command.Parameters.AddWithValue("@roomId", aBed.RoomId);
            Command.Parameters.AddWithValue("@wardId", aBed.WardId);

            //Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            //Connection.Close();
            return rowAffect;
        }

        public int DeleteBed(Bed aBed)
        {
            Query = "DELETE FROM Bed WHERE Id = " + aBed.Id;
            Command = new SqlCommand(Query, Connection);
            //Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            //Connection.Close();
            return rowAffect;
        }
    }
}
