using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CrystalDecisions.ReportAppServer.DataDefModel;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.DAL.Gatway
{
    class CategoryGatway:GatwayConnection
    {
        //private string conString = ConfigurationManager.ConnectionStrings["HospitalDbConString"].ConnectionString;
        //private SqlConnection connection;
        //private SqlCommand command;
        //private SqlDataReader reader;
        //private string query;

        //public CategoryGatway()
        //{
        //    connection = new SqlConnection(conString);
        //}

        public List<Category> GetAllCategories()
        {
            Query = "SELECT * FROM Category";
            Command = new SqlCommand(Query, Connection);
            //Connection.Open();
            Reader = Command.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (Reader.Read())
            {
                Category category = new Category();
                category.Id = (int) Reader["Id"];
                category.CategoryName = Reader["CategoryName"].ToString();

                categories.Add(category);
            }
            Reader.Close();
            //Connection.Close();

            return categories;
        }
    }
}
