using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.Admin
{
    public class ButtonPermissionAccess
    {

        public Control UserButton(Control panel, string formName)
        {
            UserMaster formManager = GlobalPermission.UserPermission.FirstOrDefault(a => a.FormName == formName);

            List<Control> button = panel.Controls.OfType<Control>().ToList();
            try
            {
                foreach (Control control in button)
                {
                    if (control.Tag != null)
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
            System.Windows.Forms.TabControl tabControl = (TabControl) panel;
            UserMaster formManager = GlobalPermission.UserPermission.FirstOrDefault(a => a.FormName == formName);
            List<Control> button = panel.Controls.OfType<Control>().ToList();
            try
            {
                foreach (Control control in button)
                {
                    TabPage tabPage = (TabPage) control;
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

        



        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        public void Permissionchek(Control btn, Type type, string formName, string menuName)
        {
            UserMaster formManager = GlobalPermission.UserPermission.FirstOrDefault(a => a.FormName == formName && a.Permission && a.MenuName == menuName);
            var c = GetAll(btn, typeof (Button));
            var d = GetAll(btn, typeof (DevExpress.XtraEditors.SimpleButton));

            foreach (Control c1 in c)
            {
                if (c1.Tag != null)
                {
                    if (c1.Tag.ToString() == "1")
                    {
                        if (!formManager.insertPermission)
                        {
                            c1.Enabled = false;
                        }
                    }
                    if (c1.Tag.ToString() == "2")
                    {
                        if (!formManager.editPermission)
                        {
                            c1.Enabled = false;
                        }
                    }
                    if (c1.Tag.ToString() == "3")
                    {
                        if (!formManager.deletePermission)
                        {
                            c1.Enabled = false;
                        }
                    }
                }

                foreach (Control c2 in d)
                {
                    if (c2.Tag != null)
                    {
                        if (c2.Tag.ToString() == "1")
                        {
                            if (!formManager.insertPermission)
                            {
                                c2.Enabled = false;
                            }
                        }
                        if (c2.Tag.ToString() == "2")
                        {
                            if (!formManager.editPermission)
                            {
                                c2.Enabled = false;
                            }
                        }
                        if (c2.Tag.ToString() == "3")
                        {
                            if (!formManager.deletePermission)
                            {
                                c2.Enabled = false;
                            }
                        }
                    }

                }
            }
        }
    }
}
