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
    public partial class PrintIPBill : Form
    {
        string BillID;
        public PrintIPBill( string BillNo)
        {
            InitializeComponent();
            BillID = BillNo;
            LoadReport();
        }
        private void LoadReport()
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM ViewIPBill WHERE BillNo=@BillNo";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar, 50).Value = BillID;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "IPBill");
            CrystalReports.IPBill rpt = new GHospital_Care.CrystalReports.IPBill();
            rpt.SetDataSource(dSet);
            crystalReportViewer1.ReportSource = rpt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
