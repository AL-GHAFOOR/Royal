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

namespace GHospital_Care.Nurses
{
    public partial class NurseInfo : Form
    {
        //clsSettings objs = new clsSettings();
        //int n, m, RowIndex;
        //Conn ob;
        //SqlConnection obcon;
        public NurseInfo()
        {
            InitializeComponent();
            SetNew();
            //ob = new Conn();
            //obcon = new SqlConnection(ob.strCon);
        }
        private void New_ID()
        {

            Conn obCon = new Conn();
            SqlConnection ob = new SqlConnection(obCon.strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "select isnull(max(NurseID),1000)+1 as NurseID from NurseInformation";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtNurseID.Text = dt.Rows[0]["NurseID"].ToString();
            }
            else
            {
                txtNurseID.Text = "";
            }

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
                cmd.CommandText = "Select* From NurseInformation where NurseID=@NurseID";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@NurseID", SqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = EmployeeID;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtCardID.Text = dt.Rows[0]["CardID"].ToString();
                    txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                    cmbdateOfBirth.Text = dt.Rows[0]["DateOfBirth"].ToString();
                    txtNurseID.Text = dt.Rows[0]["NurseID"].ToString();
                    txtNurseName.Text = dt.Rows[0]["NurseName"].ToString();
                    txtfatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    cmbPosition.Text = dt.Rows[0]["Position_"].ToString();
                    cmbJoinDate.Text = dt.Rows[0]["JoinDate"].ToString();
                    txtMotherName.Text = dt.Rows[0]["MotherName"].ToString();
                    txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                    txtPresentAddress.Text = dt.Rows[0]["PresentAddress"].ToString();
                    cmbBloodGroup.Text = dt.Rows[0]["BloodGroup"].ToString();

                    cmbGender.Text = dt.Rows[0]["Gender"].ToString();
                    cmbGender.Text = dt.Rows[0]["Religion"].ToString();

                    byte[] img = (byte[])dt.Rows[0]["Photo"];
                    MemoryStream msimage = new MemoryStream(img);
                    Bitmap myImage = (Bitmap)Bitmap.FromStream(msimage);
                    picNurse.Image = (Image)myImage;

                    btnAdd.Enabled = false;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    txtCardID.Text = "";
                    txtContactNo.Text = "";
                    cmbdateOfBirth.Text = "";
                    txtNurseID.Text = "";
                    txtNurseName.Text = "";
                    txtfatherName.Text = "";
                    cmbPosition.Text = "";
                    cmbJoinDate.Text = "";
                    txtMotherName.Text = "";
                    txtPermanentAddress.Text = "";
                    txtPresentAddress.Text = "";
                    cmbBloodGroup.Text = "";

                    cmbGender.SelectedIndex = 0;
                    cmbGender.SelectedIndex = 0;

                    picNurse.Image = null;
                }
            }
            catch
            {
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
            ds.CommandText = "select* from NurseInformation";
            ds.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void Save_Data()
        {
            try
            {
            Conn obCon = new Conn();
            SqlConnection ob = new SqlConnection(obCon.strCon);
            SqlCommand cmd = new SqlCommand("Sp_insert_NurseInfo_from", ob);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@NurseID", SqlDbType.Int);
            cmd.Parameters.Add("@NurseName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@PermanentAddress ", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@PresentAddress", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@FatherName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@MotherName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@Position_", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@DateofBirth", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@Religion", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@BloodGroup", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@JoinDate", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@CardID", SqlDbType.VarChar, 50);

            cmd.Parameters[0].Value = txtNurseID.Text;
            cmd.Parameters[1].Value = txtNurseName.Text;
            cmd.Parameters[2].Value = txtPermanentAddress.Text;
            cmd.Parameters[3].Value = txtPresentAddress.Text;
            cmd.Parameters[4].Value = txtfatherName.Text;
            cmd.Parameters[5].Value = txtMotherName.Text;
            cmd.Parameters[6].Value = cmbPosition.Text;
            cmd.Parameters[7].Value = txtContactNo.Text;
            cmd.Parameters[8].Value = cmbdateOfBirth.Text;
            cmd.Parameters[9].Value = cmbGender.Text;
            cmd.Parameters[10].Value = cmbReligion.Text;
            cmd.Parameters[11].Value = cmbBloodGroup.Text;
            cmd.Parameters[12].Value = cmbJoinDate.Text;
            cmd.Parameters[13].Value = txtCardID.Text;

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
        private void SetNew()
        {
            txtfatherName.Text = "";
            txtMotherName.Text = "";
            txtNurseID.Text = "";
            txtNurseName.Text = "";
            txtPermanentAddress.Text = "";
            txtPresentAddress.Text = "";
            cmbPosition.SelectedValue = 0;
            txtContactNo.Text = "";
            cmbdateOfBirth.Text = "";
            cmbReligion.SelectedIndex = 0;
            cmbBloodGroup.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;
            cmbJoinDate.Text = "";
            txtCardID.Text = "";
            picNurse.Image = null;

            LoadData();
            New_ID();

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        string filename = string.Empty;
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
                SqlCommand cmd = new SqlCommand("UPDATE NurseInformation SET Photo=@Photo where NurseID=@NurseID", ob);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@NurseID", SqlDbType.Int);
                cmd.Parameters.Add("@Photo", SqlDbType.Image);

                cmd.Parameters[0].Value =txtNurseID.Text;
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
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NurseInfo_Load(object sender, EventArgs e)
        {
            New_ID();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Save_Data();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Save_Data();
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
                    picNurse.Image = (Image)bmp;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to upload image! " + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }

        private void Remove_Data()
        {
            Conn obCon = new Conn();
            SqlConnection ob = new SqlConnection(obCon.strCon);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection= ob;
            SqlCommand cmd = da.SelectCommand;
            cmd.CommandText = "Delete From NurseInformation Where NurseID=@NurseID";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@NurseID", SqlDbType.Int);
            
            cmd.Parameters[0].Value = txtNurseID.Text;
           
            ob.Open();
            cmd.ExecuteNonQuery();
            ob.Close();
            MessageBox.Show("Data Removed Successfully!","Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
            SetNew();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Do You Want To Delete Data?";
                MessageBoxButtons butt = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, "Nurse Information", butt, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                   Remove_Data();
                }
            }
            catch
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            picNurse.Image = null;
        }
        
    }
}
