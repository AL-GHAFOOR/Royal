using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.ReportTools
{
    class ReportLoader
    {
        public void LoadOPBill(CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer, string BillID)
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM ViewOPBill WHERE OPBillID=@BillID";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BillID", SqlDbType.VarChar, 50).Value = BillID;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "OPBilling");
            CrystalReports.OPBill rpt = new GHospital_Care.CrystalReports.OPBill();
            rpt.SetDataSource(dSet);
            RPTViewer.ReportSource = rpt;
        }
        public void LoadSalarySheet(CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer, string _Month, string _Year)
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM VW_SALARYSHEET WHERE _Month=@_Month AND _Year=@_Year";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@_Month", SqlDbType.VarChar, 50).Value = _Month;
            cmd.Parameters.Add("@_Year", SqlDbType.VarChar, 50).Value = _Year;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "SalaryTable");
            CrystalReports.SalarySheet rpt = new GHospital_Care.CrystalReports.SalarySheet();
            rpt.SetDataSource(dSet);
            RPTViewer.ReportSource = rpt;
        }
        public void LoadNurseSalarySheet(CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer, string _Month, string _Year)
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM VW_NURSESALARYSHEET WHERE _Month=@_Month AND _Year=@_Year";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@_Month", SqlDbType.VarChar, 50).Value = _Month;
            cmd.Parameters.Add("@_Year", SqlDbType.VarChar, 50).Value = _Year;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "NurseSalarySheet");
            CrystalReports.NurseSalaryReport1 rpt = new GHospital_Care.CrystalReports.NurseSalaryReport1();
            rpt.SetDataSource(dSet);
            RPTViewer.ReportSource = rpt;
        }
        public void LoadNurseDutySheetAll(CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer, string StartDate, string EndDate)
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM VW_NURSEDUTYSCHEDULE WHERE DutyDate BETWEEN @STARTDATE AND @ENDDATE";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@STARTDATE", SqlDbType.VarChar, 50).Value = StartDate;
            cmd.Parameters.Add("@ENDDATE", SqlDbType.VarChar, 50).Value = EndDate;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "NurseDuty");
            CrystalReports.NurseDutyByDate rpt = new GHospital_Care.CrystalReports.NurseDutyByDate();
            rpt.SetDataSource(dSet);
            RPTViewer.ReportSource = rpt;
        }
        public void LoadNurseDutySheetByNurse(CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer, string StartDate, string EndDate, string NurseID)
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM VW_NURSEDUTYSCHEDULE WHERE Nurse=@NURSE AND DutyDate BETWEEN @STARTDATE AND @ENDDATE";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@NURSE", SqlDbType.VarChar, 50).Value = NurseID;
            cmd.Parameters.Add("@STARTDATE", SqlDbType.VarChar, 50).Value = StartDate;
            cmd.Parameters.Add("@ENDDATE", SqlDbType.VarChar, 50).Value = EndDate;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "NurseDuty");
            CrystalReports.NurseDutyByDate rpt = new GHospital_Care.CrystalReports.NurseDutyByDate();
            rpt.SetDataSource(dSet);
            RPTViewer.ReportSource = rpt;
        }
        public void LoadBloodGroupReport(CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer, string ReportNo)
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM tblBloodGrouping WHERE ReportNo=@ReportNo";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@ReportNo", SqlDbType.VarChar, 50).Value = ReportNo;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "BloodGroupTest");
            CrystalReports.BloodGroupTestReport rpt = new GHospital_Care.CrystalReports.BloodGroupTestReport();
            rpt.SetDataSource(dSet);
            RPTViewer.ReportSource = rpt;
        }
        public void LoadSerologicalReport(CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer, string ReportNo)
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM tblSerologicalTest WHERE ReportNo=@ReportNo";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@ReportNo", SqlDbType.VarChar, 50).Value = ReportNo;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "SerologicalReport");
            CrystalReports.SeriologicalReport rpt = new GHospital_Care.CrystalReports.SeriologicalReport();
            rpt.SetDataSource(dSet);
            RPTViewer.ReportSource = rpt;
        }
        public void LoadFebrilAntigenReport(CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer, string ReportNo)
        {
            Conn ob = new Conn();
            SqlConnection obCon = new SqlConnection(ob.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = obCon;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "SELECT* FROM tblFebrilAntigen WHERE ReportNo=@ReportNo";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@ReportNo", SqlDbType.VarChar, 50).Value = ReportNo;

            DataSet dSet = new DataSet();
            da.Fill(dSet, "FebrilAntigenReport");
            CrystalReports.FebrilAntigen rpt = new GHospital_Care.CrystalReports.FebrilAntigen();
            rpt.SetDataSource(dSet);
            RPTViewer.ReportSource = rpt;
        }
    }
}
