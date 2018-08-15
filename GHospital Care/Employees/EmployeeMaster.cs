using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GHospital_Care.Employees
{
    public partial class EmployeeMaster : Form
    {
        public EmployeeMaster()
        {
            InitializeComponent();
            SetNew();
        }
        private void SearchEmployee(string EmployeeID)
        {
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = ob;
                SqlCommand cmd = da.SelectCommand;
                cmd.CommandText = "Select* From tblEmployees where EmployeeID=@EmployeeID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = EmployeeID;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtCardID.Text = dt.Rows[0]["CardID"].ToString();
                    txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                    txtdateOfBirth.Text = dt.Rows[0]["DateOfBirth"].ToString();
                    txtEmpID.Text = dt.Rows[0]["EmployeeID"].ToString();
                    txtEmpName.Text = dt.Rows[0]["EmployeeName"].ToString();
                    txtfatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    txtJobTitle.Text = dt.Rows[0]["JobTitle"].ToString();
                    txtJoinDate.Text = dt.Rows[0]["JoinDate"].ToString();
                    txtMotherName.Text = dt.Rows[0]["MotherName"].ToString();
                    txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                    txtPresentAddress.Text = dt.Rows[0]["PresentAddress"].ToString();
                    cmbBloodGroup.Text = dt.Rows[0]["BloodGroup"].ToString();
                    cmbDepartment.Text = dt.Rows[0]["Department"].ToString();
                    cmbGender.Text = dt.Rows[0]["Gender"].ToString();
                    cmbGender.Text = dt.Rows[0]["Religion"].ToString();

                    byte[] img = (byte[])dt.Rows[0]["Photograph"];
                    MemoryStream msimage = new MemoryStream(img);
                    Bitmap myImage = (Bitmap)Bitmap.FromStream(msimage);
                    picEmployee.Image = (Image)myImage;

                    btnAdd.Enabled = false;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch
            {
            }
        }
        private void EditPhotograph()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);

                FileInfo file = new FileInfo(filename.Trim());
                byte[] content = new byte[file.Length];
                FileStream imagefile = file.OpenRead();
                imagefile.Read(content, 0, content.Length);
                SqlCommand cmd = new SqlCommand("UPDATE tblEmployees SET Photograph=@Photograph where EmployeeID=@EmployeeID", ob);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Photograph", SqlDbType.Image);

                cmd.Parameters[0].Value = txtEmpID.Text;
                cmd.Parameters[1].Value = content;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                cmd.Parameters.Clear();
                filename = "";
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to save photograph! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void SaveEmployee()
        {
            try
            {
                Conn obCon = new Conn();
                SqlConnection ob = new SqlConnection(obCon.strCon);
                SqlCommand cmd = new SqlCommand("SP_SAVE_tblEmployees", ob);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PermanentAddress", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@PresentAddress", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@FatherName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@MotherName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@JobTitle", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Religion", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@BloodGroup", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@JoinDate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@CardID", SqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = txtEmpID.Text;
                cmd.Parameters[1].Value = txtEmpName.Text;
                cmd.Parameters[2].Value = txtPermanentAddress.Text;
                cmd.Parameters[3].Value = txtPresentAddress.Text;
                cmd.Parameters[4].Value = txtfatherName.Text;
                cmd.Parameters[5].Value = txtMotherName.Text;
                cmd.Parameters[6].Value = cmbDepartment.Text;
                cmd.Parameters[7].Value = txtJobTitle.Text;
                cmd.Parameters[8].Value = txtContactNo.Text;
                cmd.Parameters[9].Value = txtdateOfBirth.Text;
                cmd.Parameters[10].Value = cmbGender.Text;
                cmd.Parameters[11].Value = cmbReligion.Text;
                cmd.Parameters[12].Value = cmbBloodGroup.Text;
                cmd.Parameters[13].Value = txtJoinDate.Text;
                cmd.Parameters[14].Value = txtCardID.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                EditPhotograph();
                MessageBox.Show("Employee has been saved successfully!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNew();
            }
            catch(Exception error)
            {
                MessageBox.Show("Failed to save employee! "+error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        string filename = string.Empty;
        private void SetNew()
        {
            txtCardID.Text = "";
            txtContactNo.Text = "";
            txtEmpID.Text = "";
            txtEmpName.Text = "";
            txtfatherName.Text = "";
            txtJobTitle.SelectedIndex = 0;
            txtMotherName.Text = "";
            txtPermanentAddress.Text = "";
            txtPresentAddress.Text = "";

            cmbReligion.SelectedIndex = 0;
            cmbBloodGroup.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;

            picEmployee.Image = null;

            LoadData();
            LoadDepartments();
            GenerateID();

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void GenerateID()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlCommand cmd = new SqlCommand("SP_GENERATE_EMPID", ob);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader;
            ob.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
            txtEmpID.Text = reader[0].ToString();
        }
        private void LoadData()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblEmployees";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }
        private void LoadDepartments()
        {
            Conn obcon = new Conn();
            SqlConnection ob = new SqlConnection(obcon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand ds = da.SelectCommand;
            ds.CommandText = "select* from tblDepartments";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbDepartment.DataSource = dt;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                ofd.Filter = "JPEG Image|*.jpg*|PNG Files|*.png*";

                DialogResult dr = ofd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    filename = ofd.FileName.ToString();
                    Bitmap bmp = new Bitmap(filename);
                    filename = ofd.FileName.ToString();
                    picEmployee.Image = (Image)bmp;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to upload image! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            picEmployee.Image = null;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveEmployee();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                SearchEmployee(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch
            {
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveEmployee();
        }

        private void txtJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
