using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace GHospital_Care.MailServer
{
   public class MailServerConnection
    {
       public void SentMail(string message)
       {
           MessageBox.Show(message);
       }
   }
}
