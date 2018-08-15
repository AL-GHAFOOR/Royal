using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GHospital_Care
{
    public class Conn
    {
        public string strCon;
        public Conn()
        {
            string filename = Application.StartupPath.ToString() + "\\config\\dbConn.con";
            StreamReader sr = new StreamReader(filename);
            strCon = sr.ReadToEnd();
        }
    }
}
