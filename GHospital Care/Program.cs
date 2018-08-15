using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GHospital_Care.DischargeUI;
using GHospital_Care.Doctors;
using GHospital_Care.IndoorPatient;
using GHospital_Care.PatientReport;
using GHospital_Care.Session;
using GHospital_Care.UI;
using NICUBill = GHospital_Care.DischargeUI.NICUBill;

namespace GHospital_Care
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());// Application.Run(new DailyPatientStatus());
        }
    }

}
