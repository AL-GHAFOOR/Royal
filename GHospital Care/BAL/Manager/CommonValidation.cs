using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace GHospital_Care.BAL.Manager
{
    static class CommonValidation
    {
        public static void IsNumberCheck(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -2)
                {
                    e.Handled = true;
                }

            }
            catch
            {
                
            }
           




        }
    }
}
