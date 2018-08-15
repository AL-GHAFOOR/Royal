using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;
using GHospital_Care.DAL.Model.ViewModel;

namespace GHospital_Care.UI
{
    public partial class BedSetup2 : Form
    {
        private FloorManager aFloorManager = new FloorManager();
        private CategoryManager aCategoryManager = new CategoryManager();
        private RoomManager aRoomManager = new RoomManager();
        private WardManager aWardManager = new WardManager();

        private BedManager aBedManager = new BedManager();
        //private Bed aBed;

        public BedSetup2()
        {
            InitializeComponent();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this, this.Name);
        }

        private void BedSetup2_Load(object sender, EventArgs e)
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



            Ward defaultWard = new Ward();
            defaultWard.WardName = "--Select--";
            defaultWard.Id = -1;
            List<Ward> wards = new List<Ward>();
            wards.Add(defaultWard);
            wards.AddRange(aWardManager.GetAllWards());
            wardComboBox.DisplayMember = "WardName";
            wardComboBox.ValueMember = "Id";
            wardComboBox.DataSource = wards;


            Room defaultRoom = new Room();
            defaultRoom.RoomName = "--Select--";
            defaultRoom.Id = -1;
            List<Room> rooms = new List<Room>();
            rooms.Add(defaultRoom);
            rooms.AddRange(aRoomManager.GetAllRooms());
            roomComboBox.DisplayMember = "RoomName";
            roomComboBox.ValueMember = "Id";
            roomComboBox.DataSource = rooms;


            PopulateItemsListView();
            editButton.Enabled = false;
            deleteButton.Enabled = false;

           
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //private void InitialAllField()
        //{
            //Bed aBed = new Bed();
         
            //aBed.BedName = bedNameTextBox.Text;
            //aBed.FloorId = Convert.ToInt32(floorComboBox.SelectedValue);
            //aBed.CategoryId = Convert.ToInt32(floorComboBox.SelectedValue);
            //aBed.WardId = Convert.ToInt32(floorComboBox.SelectedValue);
            //aBed.RoomId = Convert.ToInt32(floorComboBox.SelectedValue);
            //aBed.Description = descriptionTextBox.Text;
            //aBed.Rate = rateTextBox.Text;
        //}

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bedNameTextBox.Text))
            {
                MessageBox.Show("Please, input an Bed name.");
                return;
            }

            if (Convert.ToInt32(floorComboBox.SelectedValue) == -1)
            {
                MessageBox.Show("Please, select a Floor name");
                return;
            }
            if (Convert.ToInt32(categoryComboBox.SelectedValue) == -1)
            {
                MessageBox.Show("Please, select a category");
                return;
            }
            if (Convert.ToInt32(wardComboBox.SelectedValue) == -1)
            {
                MessageBox.Show("Please, input an ward name.");
                return;
            }
            //if (Convert.ToInt32(roomComboBox.SelectedValue)==-1)
            //{
            //    MessageBox.Show("Please, input a room.");
            //    return;
            //}
            if (string.IsNullOrEmpty(rateTextBox.Text))
            {
                MessageBox.Show("Please, input an Bed Rate.");
                return;
            }


            Bed aBed = new Bed();


            //aBed.Id = Convert.ToInt16(IdTextBox.Text);

            aBed.BedName = bedNameTextBox.Text;
            aBed.FloorId = Convert.ToInt32(floorComboBox.SelectedValue);
            aBed.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            aBed.WardId = Convert.ToInt32(wardComboBox.SelectedValue);
            aBed.RoomId = 1;//Convert.ToInt32(roomComboBox.SelectedValue);
            aBed.Description = descriptionTextBox.Text;
            aBed.Rate = rateTextBox.Text;

            if (saveButton.Text == "Save")
            {
                string message = aBedManager.SaveBeds(aBed);
                MessageBox.Show(message);
            }
            else
            {
                aBed.Id = Convert.ToInt16(bedIdTextBox.Text);
                string message = aBedManager.UpdateBed(aBed);
                MessageBox.Show(message);
            }
            ResetAllData();
            PopulateItemsListView();

        }

        private void PopulateItemsListView()
        {
            bedListView.Items.Clear();
            List<BedViewModel> bedViewModels = aBedManager.GetAllBedFromView();
            foreach (BedViewModel aBedViewModel in bedViewModels)
            {
                ListViewItem item = new ListViewItem(aBedViewModel.Sl.ToString());
                //item.Text = aItem.Sl.ToString();
                item.SubItems.Add(aBedViewModel.BedName);
                item.SubItems.Add(aBedViewModel.FloorName);
                item.SubItems.Add(aBedViewModel.CategoryName);
                item.SubItems.Add(aBedViewModel.WardName);
                item.SubItems.Add(aBedViewModel.RoomName);
                item.SubItems.Add(aBedViewModel.Description);
                item.SubItems.Add(aBedViewModel.Rate.ToString());
               
               
                item.SubItems.Add(aBedViewModel.RoomName);
                
                item.Tag = aBedViewModel;

                bedListView.Items.Add(item);
            }
        }

        private void bedListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BedViewModel aBedViewModel= bedListView.SelectedItems[0].Tag as BedViewModel;

            if (aBedViewModel != null)
            {
                //itemIdTextBox.Text = aItemViewModel.Id.ToString();
                bedIdTextBox.Text = aBedViewModel.Id.ToString();
                bedNameTextBox.Text = aBedViewModel.BedName;
                floorComboBox.SelectedValue = aBedViewModel.FloorId;
                categoryComboBox.SelectedValue = aBedViewModel.CategoryId;
                wardComboBox.SelectedValue = aBedViewModel.WardId;
                roomComboBox.SelectedValue = aBedViewModel.RoomId;
                descriptionTextBox.Text = aBedViewModel.Description;
                rateTextBox.Text = aBedViewModel.Rate.ToString();

                deleteButton.Enabled = true;
                saveButton.Text = "Update";
                

            }
            deleteButton.Enabled = true;
        }

        private void rateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonValidation.IsNumberCheck(sender, e);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bedIdTextBox.Text))
            {
                MessageBox.Show("There is no Bed name found");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation Message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Bed aBed = new Bed();
                aBed.Id = Convert.ToInt32(bedIdTextBox.Text);

                string message = aBedManager.DeleteBed(aBed);
                MessageBox.Show(message);
                ResetAllData();
                PopulateItemsListView();
            }
            else
            {
                //Nothing to do
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            ResetAllData();
        }


        private void ResetAllData()
        {
            bedIdTextBox.Clear();
            bedNameTextBox.Clear();

            floorComboBox.SelectedValue = -1;
            categoryComboBox.SelectedValue = -1;

            wardComboBox.SelectedValue = -1;
            roomComboBox.SelectedValue = -1;

            descriptionTextBox.Clear();
            rateTextBox.Clear();

            saveButton.Text = "Save";
            deleteButton.Enabled = false;
            editButton.Enabled = false;
            PopulateItemsListView();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
