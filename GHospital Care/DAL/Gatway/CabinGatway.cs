using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CrystalDecisions.ReportAppServer.DataDefModel;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;
using GHospital_Care.DAL.Model.ViewModel;

namespace GHospital_Care.DAL.Gatway
{
    class CabinGatway :GatwayConnection
    {

        //private string conString = ConfigurationManager.ConnectionStrings["HospitalDbConString"].ConnectionString;
        //private SqlConnection connection;
        //private SqlCommand command;
        //private SqlDataReader reader;
        //private string query;

        //public CabinGatway()
        //{
        //    connection = new SqlConnection(conString);
        //}

        public int SaveCabin(Cabin aCabin)
        {
            Query = "INSERT INTO Cabin (CabinName, Description, Rate, CategoryId, FloorId) VALUES(@cabinName, @description, @rate, @categoryId, @floorId)";
            Command = new SqlCommand(Query, Connection);
            //command.Parameters.AddWithValue("@id", aCabin.Id);
            Command.Parameters.AddWithValue("@cabinName", aCabin.CabinName);
            Command.Parameters.AddWithValue("@description", aCabin.Description);
            Command.Parameters.AddWithValue("@rate", aCabin.Rate);
            Command.Parameters.AddWithValue("@categoryId", aCabin.CategoryId);
            Command.Parameters.AddWithValue("@floorId", aCabin.FloorId);
            //Connection.Open();
            var rowAffect = Command.ExecuteNonQuery();
            //Connection.Close();
            return rowAffect;
        }

        public int UpdateCabin(Cabin aCabin)
        {
            Query = "UPDATE Cabin SET CabinName=@cabinName,Description=@description,Rate=@rate, CategoryId=@categoryId, FloorId=@floorId WHERE Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@id", aCabin.Id);
            Command.Parameters.AddWithValue("@cabinName", aCabin.CabinName);
            Command.Parameters.AddWithValue("@description", aCabin.Description);
            Command.Parameters.AddWithValue("@rate", aCabin.Rate);
            Command.Parameters.AddWithValue("@categoryId", aCabin.CategoryId);
            Command.Parameters.AddWithValue("@floorId", aCabin.FloorId);

            //Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            //Connection.Close();
            return rowAffect;
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

       public List<CabinViewModel> GetAllCabinFromView()
        {
            Query = "SELECT * FROM ViewAllCabins ORDER BY CabinName,CategoryName,FloorName";
            Command = new SqlCommand(Query, Connection);
            //Connection.Open();
            Reader = Command.ExecuteReader();
            List<CabinViewModel> cabinViewModels = new List<CabinViewModel>();
            int sl = 0;
            while (Reader.Read())
            {
                sl++;
                CabinViewModel aCabinViewModel = new CabinViewModel();
                
                aCabinViewModel.Sl = Convert.ToInt32(sl);

                aCabinViewModel.Id = (int)Reader["Id"];
                aCabinViewModel.CabinName = Reader["CabinName"].ToString();
                aCabinViewModel.Description = Reader["Description"].ToString();
                aCabinViewModel.FloorName = Reader["FloorName"].ToString();
                aCabinViewModel.CategoryName = Reader["CategoryName"].ToString();
                aCabinViewModel.Rate = Convert.ToInt32(Reader["Rate"]);
                aCabinViewModel.CategoryId = (int)Reader["CategoryId"];
                aCabinViewModel.FloorId = (int)Reader["FloorId"];
           

                cabinViewModels.Add(aCabinViewModel);
            }
            Reader.Close();
            //Connection.Close();
            return cabinViewModels;
        }

        //public bool IsCabinNameExist(Cabin cabin)
        //{
        //    query = "SELECT * FROM Cabin WHERE CabinName=@cabinName AND Id <> @id";
        //    command = new SqlCommand();
        //    command.Parameters.AddWithValue("@cabinName", cabin.CabinName);
        //    command.Parameters.AddWithValue("@id", cabin.Id);
        //    command.CommandText = query;
        //    command.Connection = connection;
        //    command.Connection.Open();
        //    reader = command.ExecuteReader();
        //    bool isExist = reader.HasRows;
        //    reader.Close();
        //    connection.Close();
        //    return isExist;
        //}

    }
}
