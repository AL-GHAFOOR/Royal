using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.UI
{
    public partial class WardSetup : Form
    {
        private FloorManager aFloorManager = new FloorManager();
        private CategoryManager aCategoryManager = new CategoryManager();
        readonly private WardManager aWardManager = new WardManager();


        private Ward aWard;

        public WardSetup()
        {
            InitializeComponent();
            ActiveControl = wardNameTextBox;ResetAllData();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            aWard = new Ward();

            aWard.WardName = wardNameTextBox.Text;
            aWard.FloorId = Convert.ToInt32(floorComboBox.SelectedValue);
            aWard.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            aWard.Description = descriptionTextBox.Text;

            if (saveButton.Text == "Save")
            {
                string message = aWardManager.SaveWard(aWard);
                MessageBox.Show(message, "Saved Successfully.");
            }
            else
            {
                     //
            }
            ResetAllData();
            PopulateWardGridView();
        }

        private void PopulateWardGridView()
        {
            gridControlWard.DataSource = aWardManager.GetAllWard();
        }


        private void ResetAllData()
        {
            IdTextBox.Text = "";
            wardNameTextBox.Clear();
            floorComboBox.SelectedValue = -1;
            categoryComboBox.SelectedValue = -1;
            descriptionTextBox.Clear();
            saveButton.Enabled = true;
            editButton.Enabled = false;
            deleteButton.Enabled = false;
            PopulateWardGridView();
        }

       
        private void txtBedID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                wardNameTextBox.Focus();
            }
        }
        private void txtBedName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                descriptionTextBox.Focus();
            }
        }


        private void WardSetup_Load_1(object sender, EventArgs e)
        {
            LoadFloor();
            LoadCategory();
            PopulateWardGridView();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gridViewWard_DoubleClick(object sender, EventArgs e)
        {
            IdTextBox.Text = gridViewWard.GetFocusedRowCellValue("Id").ToString();
            wardNameTextBox.Text = gridViewWard.GetFocusedRowCellValue("WardName").ToString();
            floorComboBox.Text = gridViewWard.GetFocusedRowCellValue("FloorName").ToString();
            categoryComboBox.Text = gridViewWard.GetFocusedRowCellValue("CategoryName").ToString();

            descriptionTextBox.Text = gridViewWard.GetFocusedRowCellValue("Description").ToString();

            editButton.Enabled = true;
            deleteButton.Enabled = true;
            saveButton.Enabled = false;
            newButton.Enabled = true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            ResetAllData();
        }

        private void LoadFloor()
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
        }

        private void LoadCategory()
        {
            Category defaultCategory = new Category();
            defaultCategory.CategoryName = "--Select--";
            defaultCategory.Id = -1;
            List<Category> categories = new List<Category>();

            categories.Add(defaultCategory);
            categories.AddRange(aCategoryManager.GetAllCategories());
            categoryComboBox.DisplayMember = "CategoryName";
            categoryComboBox.ValueMember = "Id";
            categoryComboBox.DataSource = categories;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            aWard = new Ward();
            aWard.Id = Convert.ToInt32(IdTextBox.Text);
            aWard.WardName = wardNameTextBox.Text;
            aWard.FloorId = Convert.ToInt32(floorComboBox.SelectedValue);
            aWard.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            aWard.Description = descriptionTextBox.Text;

            MessageModel myMessage = new WardManager().EditWard(aWard);
            MessageBox.Show(myMessage.MessageTitle, myMessage.MessageBody, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (myMessage.MessageTitle == "Successfull")
            {
                ResetAllData();

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IdTextBox.Text))
            {
                MessageBox.Show("Ward info not found.");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure to delete this information?", "Confirmation Message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Ward aWard = new Ward();
                aWard.Id = Convert.ToInt32(IdTextBox.Text);

                MessageModel message = new WardManager().DeleteWard(aWard);
                if (message.MessageTitle == "Successfull")
                {
                    MessageBox.Show(message.MessageBody, message.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetAllData();
                    LoadFloor();
                    LoadCategory();
                    Refresh();
                }
            }
        }









    }
}
