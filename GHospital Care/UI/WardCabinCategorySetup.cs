using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GHospital_Care.Admin;
using GHospital_Care.BAL.Manager;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.UI
{
    public partial class WardCabinCategorySetup : Form
    {

        public WardCabinCategorySetup()
        {
            InitializeComponent();
            Control buttonControl = new ButtonPermissionAccess().UserButton(this.categorygroupBox, this.Name);
        }



        //All Method Start : 
        private void SetNew()
        {
            txtId.Text = "";
            txtCategory.Text = "";

            GenerateID();
            LoadData();

            txtCategory.Focus();

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void SaveCategory()
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategory.Text))
                {
                    MessageBox.Show("Please insert a category name.");
                    return;
                }

                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblWardCabinCategory", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtId.Text;
                cmd.Parameters[1].Value = txtCategory.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Category save successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save Category! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadData()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "SELECT * FROM Category";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            categoryDataGridView.AutoGenerateColumns = false;
            categoryDataGridView.DataSource = dt;
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Select isnull(max(Id),0)+1 as Id from Category";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtId.Text = dt.Rows[0]["Id"].ToString();
            }
        }

        private void DeleteCategory()
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you really want to delete this category?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Conn obcon = new Conn();
                    SqlConnection ob = new SqlConnection(obcon.strCon);
                    SqlCommand cmd = new SqlCommand("Delete from Category where Id=@ID", ob);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters[0].Value = txtId.Text;

                    ob.Open();
                    cmd.ExecuteNonQuery();
                    ob.Close();

                    MessageBox.Show("Your category has been deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetNew();
                }
            }
            catch
            {
            }
        }

        //All Method End : 


        //All Event Start : 

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void WardCabinCategorySetup_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnColse_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void categoryDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtId.Text = categoryDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCategory.Text = categoryDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtCategory.Text = ""))
            //{
            //    MessageBox.Show("Please insert a category name.");
            //    return;
            //}
            SaveCategory();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveCategory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }

        //All Event End : 
    }
}
