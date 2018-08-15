using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.OutdoorPatient
{
    public partial class OPInformationReport : Form
    {
        public OPInformationReport()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "SELECT* FROM tblOP WHERE ServiceDate BETWEEN @StartDate AND @EndDate";
            ds.CommandType = CommandType.Text;

            ds.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = dtStart.Text;
            ds.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = dtEnd.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you really want to print this?","Print",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string total = dataGridView1.Rows.Count.ToString();
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Bhashani Hospital & Diagonstic Center";
                    printer.SubTitle = "Mohiuddin Plaza, Kagmari Road, Babistand, Tangail" + "\n" + "Outdoor Patient Information" + "\n" + "Total Patient: " + total;
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
                                                  StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Developed By - " + "GSoft Technologies";
                    printer.FooterSpacing = 30;

                    printer.PrintPreviewDataGridView(dataGridView1);
                }
                catch(Exception error)
                {
                    MessageBox.Show("Failed to print data! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void OPInformationReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
