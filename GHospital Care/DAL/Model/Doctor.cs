using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GHospital_Care.DAL.Model
{
   public class Doctor:ComboBox
    {
       public  string DoctorID { get; set; } 

	public  string DoctorName { get; set; }

	public  string NickName { get; set; }
       
	public  string Gender { get; set; }

	public  DateTime DateOfBirth { get; set; }

	public string Address { get; set; }

	public  string Phone { get; set; }

	public  string Mobile { get; set; }

	public  string License { get; set; }

	public  string Specialization { get; set; }

    public string Notes { get; set; }

    }
}
