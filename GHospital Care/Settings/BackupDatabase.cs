using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GHospital_Care.Settings
{
    public partial class BackupDatabase : Form
    {
        string Extention = ".gs";
        public BackupDatabase()
        {
            InitializeComponent();
        }
        private void CreateBackup()
        {
            string path = string.Empty;
            string file = string.Empty;
            string fullroot = string.Empty;

            if (optDefault.Checked == true)
            {
                path = Application.StartupPath.ToString() + "\\backup\\";
                file = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + Extention;
                fullroot = path + file;
            }
            else if (optSelect.Checked == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "GSoft Backup File|*.*";
                DialogResult dr = sfd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    fullroot = sfd.FileName.ToString() + Extention;
                }
            }
            try
            {
                Conn obcon = new Conn();
                SqlConnection ob = new SqlConnection(obcon.strCon);
                SqlCommand cmd = new SqlCommand("BACKUP DATABASE masterHMS TO DISK='" + fullroot + "'", ob);
                cmd.CommandType = CommandType.Text;

                ob.Open();
                cmd.ExecuteNonQuery();
                ob.Close();

                MessageBox.Show("Backup successfully created!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception error)
            {
                MessageBox.Show("An error occured to create backup! " + error.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            CreateBackup();
        }
        private void optBAK_CheckedChanged(object sender, EventArgs e)
        {
            if (optBAK.Checked == true)
            {
                Extention = ".bak";
            }
        }
        private void optGS_CheckedChanged(object sender, EventArgs e)
        {
            if (optGS.Checked == true)
            {
                Extention = ".gs";
            }
        }
        private void optXLS_CheckedChanged(object sender, EventArgs e)
        {
            if (optXLS.Checked == true)
            {
                Extention = ".xls";
            }
        }
        private void optPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (optPDF.Checked == true)
            {
                Extention = ".pdf";
            }
        }
    }
}
