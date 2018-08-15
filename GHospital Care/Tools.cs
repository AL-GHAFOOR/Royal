using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GHospital_Care
{
    class Tools
    {
        public string Today = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        public int SearchString(string look, ComboBox cmbItem)
        {
            int total = cmbItem.Items.Count;
            int len = look.Length;
            look = look.ToUpper();
            for (int i = 0; i < total; i++)
            {

                string listitem = cmbItem.GetItemText(cmbItem.Items[i]).ToUpper();
                if (listitem.StartsWith(look))
                    return i + 1;
            }
            return 0;

        }
    }
}
