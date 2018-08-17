using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.CustomLibry;
using GHospital_Care.DAL.Model;
using GHospital_Care.DAL.Model.ViewModel;
using Microsoft.Reporting.WinForms;

namespace GHospital_Care.UI
{
    public partial class CabinSetup : Form
    {
        private FloorManager aFloorManager = new FloorManager();
        private CategoryManager aCategoryManager = new CategoryManager();
        private CabinManager aCabinManager=new CabinManager();
        private Cabin aCabin;
        public CabinSetup()
        {
            InitializeComponent();
        }

        //private void GenerateID()
        //{
        //    Conn obcon = new Conn();
        //    SqlConnection ob = new SqlConnection(obcon.strCon);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = new SqlCommand();
        //    da.SelectCommand.Connection = ob;
        //    SqlCommand cmd = da.SelectCommand;
        //    cmd.CommandText = "Select isnull(max(ID),0)+1 as ID from Cabin";
        //    cmd.CommandType = CommandType.Text;

        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        idTextBox.Text = dt.Rows[0]["Id"].ToString();
        //    }
        //}

        private void CabinSetup_Load(object sender, EventArgs e)
        {
            Floor defaultFloor = new Floor();
            defaultFloor.FloorName = "--Select--";
            defaultFloor.Id = -1;
            List<Floor> floors = new List<Floor>();
            floors.Add(defaultFloor);
            floors.AddRange(aFloorManager.GetAllFloors());
            floorComboBox.DisplayMember = "FloorName";
            floorComboBox.ValueMember = "Id";
            floorComboBox.DataSource = floors;


            Category defaultCategory = new Category();
            defaultCategory.CategoryName = "--Select--";
            defaultCategory.Id = -1;
            List<Category> categories = new List<Category>();
            categories.Add(defaultCategory);
            categories.AddRange(aCategoryManager.GetAllCategories());
            categoryComboBox.DisplayMember = "CategoryName";
            categoryComboBox.ValueMember = "Id";
            categoryComboBox.DataSource = categories;

            PopulateCabinListView();
          
            Control buttonControl = new ButtonPermissionAccess().UserButton(this.groupBox1, this.Name);
           
            //GenerateID();
            //GetAllFloor();
            //GetAllCategory();
        }

        private void PopulateCabinListView()
        {
            cabinListView.Items.Clear();

            List<CabinViewModel> cabinViewModels = aCabinManager.GetAllCabinFromView();
            foreach (CabinViewModel aCabinViewModel in cabinViewModels)
            {
                ListViewItem item = new ListViewItem(aCabinViewModel.Sl.ToString());
                //item.Text = aItem.Sl.ToString();
                item.SubItems.Add(aCabinViewModel.CabinName);
                item.SubItems.Add(aCabinViewModel.FloorName);
                item.SubItems.Add(aCabinViewModel.CategoryName);
                item.SubItems.Add(aCabinViewModel.Description);
                item.SubItems.Add(aCabinViewModel.Rate.ToString());

                item.Tag = aCabinViewModel;
                cabinListView.Items.Add(item);
            }
        }

        private void ResetAllData()
        {
            idTextBox.Clear();
            cabinNameTextBox.Clear();
            floorComboBox.SelectedValue = -1;
            categoryComboBox.SelectedValue = -1;
            descriptionTextBox.Clear();
            rateTextBox.Clear();

            saveButton.Text = "Save";
            deleteButton.Enabled = false;
            PopulateCabinListView();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cabinNameTextBox.Text))
                {
                    MessageBox.Show("Please enter cabin name");
                    return;
                }
                if (Convert.ToInt32(floorComboBox.SelectedValue) == -1)
                {
                    MessageBox.Show("Please select floor.");
                    return;
                }
                if (Convert.ToInt32(categoryComboBox.SelectedValue) == -1)
                {
                    MessageBox.Show("Please select a category.");
                    return;
                }

                if (rateTextBox.Text == "" || Convert.ToInt32(rateTextBox.Text) <= 0)
                {
                    MessageBox.Show("Please enter the valid rate of this Cabin!", "Invalid", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                if (saveButton.Text == "Save")
                {
                    aCabin = new Cabin();
                    aCabin.CabinName = cabinNameTextBox.Text;
                    aCabin.Description = descriptionTextBox.Text;

                    aCabin.FloorId = Convert.ToInt32(floorComboBox.SelectedValue);
                    aCabin.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                    aCabin.Rate = Convert.ToDecimal(rateTextBox.Text);

                    string message = aCabinManager.SaveCabin(aCabin);
                    MessageBox.Show(message);
                }
                else
                {
                    aCabin = new Cabin();

                    aCabin.Id = Convert.ToInt32(idTextBox.Text);
                    aCabin.CabinName = cabinNameTextBox.Text;
                    aCabin.Description = descriptionTextBox.Text;
                    aCabin.FloorId = Convert.ToInt32(floorComboBox.SelectedValue);
                    aCabin.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                    aCabin.Rate = Convert.ToDecimal(rateTextBox.Text);

                    string message = aCabinManager.UpdateCabin(aCabin);
                    MessageBox.Show(message);
                }
                ResetAllData();
                PopulateCabinListView();
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }

    private void cabinListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CabinViewModel aCabinViewModel = cabinListView.SelectedItems[0].Tag as CabinViewModel;

            if (aCabinViewModel != null)
            {
                idTextBox.Text = aCabinViewModel.Id.ToString();
                cabinNameTextBox.Text = aCabinViewModel.CabinName;
                floorComboBox.SelectedValue = aCabinViewModel.FloorId;
                categoryComboBox.SelectedValue = aCabinViewModel.CategoryId;
                descriptionTextBox.Text = aCabinViewModel.Description;
                rateTextBox.Text = aCabinViewModel.Rate.ToString();

                deleteButton.Enabled = true;
                saveButton.Text = "Update";
            }
            deleteButton.Enabled = true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            ResetAllData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("There is no item found");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Cabin aCabin = new Cabin();
                aCabin.Id = Convert.ToInt32(idTextBox.Text);
                string message= aCabinManager.DeleteCabin(aCabin);

                //string message = aCabinManager.DeleteCabin(aCabin);
                MessageBox.Show(message);
                ResetAllData();
                PopulateCabinListView();
            }
            else
            {
                //Nothing to do
            }
        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                cabinNameTextBox.Focus();
            }
        }

        private void cabinNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                floorComboBox.Focus();
            }
        }

        private void rateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonValidation.IsNumberCheck(sender,e);
            this.AcceptButton = saveButton;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintService();
        }

        public void PrintService()
        {
            ReportModel model = new ReportModel();
            model.Parameters = new List<ReportParameter>
            {
                new ReportParameter("Company", model.Company.ToUpper()),
                new ReportParameter("Address",  model.Address),
                
            };
            model.ReportDataSource.Name = "CabinList";

            DataTable dt = new CabinManager().CabinList();
            model.ReportDataSource.Value = dt;

            model.ReportPath = "GHospital_Care.Report.rptCabinList.rdlc";
            model.Show(model, this);
        }
    }
}
