using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.Admin
{
    public class ButtonPermissionAccess
    {

        public Control UserButton (Control panel,string formName)
        {
            UserMaster formManager = GlobalPermission.UserPermission.FirstOrDefault(a => a.FormName == formName);
            List<Control> button = panel.Controls.OfType<Control>().ToList();
            try
            {
               foreach (Control control in button)
                {
                    if (control.Tag!=null)
                    {
                        if (control.Tag.ToString() == "1")
                        {
                            if (!formManager.insertPermission)
                            {
                                control.Enabled = false;
                            }
                            
                            
                        }

                        if (control.Tag.ToString() == "2")
                        {
                            if (!formManager.editPermission)
                            {
                                control.Enabled = false;
                            }
                           

                        }

                        if (control.Tag.ToString() == "3")
                        {
                            if (!formManager.deletePermission)
                            {
                                control.Enabled = false;
                            }


                        }
                    }
                   
                }
            }
            catch (Exception)
            {
                

            }
            return panel;
        }
        public Control TabControl(Control panel, string formName)
        {
            System.Windows.Forms.TabControl tabControl = (TabControl)panel;
            UserMaster formManager = GlobalPermission.UserPermission.FirstOrDefault(a => a.FormName == formName);
            List<Control> button = panel.Controls.OfType<Control>().ToList();
            try
            {

               
                foreach (Control control in button)
                {
                    TabPage tabPage = (TabPage)control;

                    if (control.Tag != null)
                    {
                        if (control.Tag.ToString() == "1")
                        {
                            if (formManager.insertPermission)
                            {
                                tabPage.Show();
                            }
                            else
                            {
                                tabPage.Hide();
                            }

                        }


                    }
                    else
                    {
                        tabControl.TabPages.Remove(tabPage);
                    }

                }
            }
            catch (Exception)
            {


            }
            return tabControl;
        }
    }
}
