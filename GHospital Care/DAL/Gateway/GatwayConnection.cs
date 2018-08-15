using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GHospital_Care.DAL.Gateway
{
   public class GatwayConnection:Conn
    {
       public SqlCommand Command { get; set; }
       public SqlConnection Connection { get; set; }
       public SqlDataReader Reader { get; set; }
       public string Query { get; set; }


       public GatwayConnection()
       {
           string ConnectionString = strCon;
           Connection=new SqlConnection(ConnectionString);
           if (Connection.State == ConnectionState.Closed)
           {
               Connection.Open();
           }
           else
           {
               Connection.Close();
           }

       }
    }
}
