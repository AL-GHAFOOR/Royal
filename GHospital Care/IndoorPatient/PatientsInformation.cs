using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.IndoorPatient
{
    public partial class PatientsInformation : Form
    {
        public PatientsInformation()
        {
            InitializeComponent();
        }
        private void GridLoad()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "SELECT* FROM tblIP WHERE AdmissionDate BETWEEN @STARTDATE AND @ENDDATE";
            ds.CommandType = CommandType.Text;

            ds.Parameters.Add("@STARTDATE", SqlDbType.VarChar, 50).Value = dtStart.Text;
            ds.Parameters.Add("@ENDDATE", SqlDbType.VarChar, 50).Value = dtEnd.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            GridLoad();
        }
    }
}
