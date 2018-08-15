using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;

namespace GHospital_Care.DAL.Gatway
{
    class ParentGatway:Conn
    {
       
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        public ParentGatway()
        {
            string connection = new Conn().strCon;
            Connection = new SqlConnection(connection);
        }
    }
}
