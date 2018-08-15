using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using GHospital_Care.DAL.Gateway;


namespace Paragon
{
    public class financialyr : GatwayConnection
    {
        private SqlConnection con = null;

        public financialyr()
        {
            con = Connection;
        }
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        public string fromdate, toDate, address, UID, chkform, Name;


        public void chkFinancialYr()
        {
            con.Open();
            command = new SqlCommand("Select fromDate, toDate from tbl_FinancialYear where closed = 'False'", con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                fromdate = reader[0].ToString();
                toDate = reader[1].ToString();
            }
            con.Close();

        }

        public bool dataeditTrans(string query)
        {
            try
            {
               
                command = new SqlCommand(query, con);
                command.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception)
            {

                return false;
                
            }
            
        }
        public void C_Address()
        {
            con.Open();
            command = new SqlCommand("Select Address,branchName from tbl_Branch where branchId = '1'", con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                address = reader[0].ToString();
                Name = reader[1].ToString();

            }
            con.Close();

        }

        

        public void chkCostCenter1(Object LID, ComboBoxEdit cmb, LabelControl lbl, TextEdit txt, Panel plPanel)
        {
            try
            {
                cmb.Visible = false;
                lbl.Visible = false;
                plPanel.Visible = false;
                setting(cost);
                if (cost == "1")
                {
                    SqlDataAdapter sqla = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    // DateTime.ParseExact(dateString, format, provider)
                    sqla.SelectCommand = new SqlCommand(String.Format("Select Isnull(cstNumber,'0')cstNumber from tbl_AccountLedger where  ledgerId = '{0}' ", LID),
                            con);
                    sqla.Fill(ds);
                    DataTable dt;
                    dt = ds.Tables[0];
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //if (dt.Rows[0][0].ToString() == "1")
                    //{
                    cmb.Visible = true;
                    lbl.Visible = true;
                    plPanel.Visible = true;
                    loadCostCenter(cmb);
                    cmb.Focus();
                    //}
                    //else
                    //{
                    //    txt.Focus();
                    //    cmb.Visible = false;
                    //    lbl.Visible = false;

                    //}
                    // }

                }
                else
                {
                    txt.Focus();
                }

            }
            catch (Exception)
            {

            }


        }

        public void effectLederCC(LabelControl lbl, ComboBoxEdit cmb, SimpleButton btn)
        {
            setting(cost);
            if (cost == "1")
            {
                lbl.Visible = true;
                cmb.Visible = true;
                cmb.Focus();
            }
            else
            {
                lbl.Visible = false;
                cmb.Visible = false;
                btn.Focus();
            }
        }

        public string cost;
        public void chkCostCenter(Object LID, ComboBoxEdit cmb, LabelControl lbl, TextEdit txt)
        {
            cmb.Visible = false;
            lbl.Visible = false;
            setting(cost);
            if (cost == "1")
            {
                SqlDataAdapter sqla = new SqlDataAdapter();
                DataSet ds = new DataSet();
                // DateTime.ParseExact(dateString, format, provider)
                sqla.SelectCommand =
                    new SqlCommand(
                        String.Format(
                            "Select Isnull(cstNumber,0)cstNumber from tbl_AccountLedger where  ledgerId = '{0}' ", LID),
                        con);
                sqla.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {

                        cmb.Visible = true;
                        lbl.Visible = true;

                        loadCostCenter(cmb);
                        cmb.Focus();
                    }
                    else
                    {
                        txt.Focus();
                        cmb.Visible = false;
                        lbl.Visible = false;

                    }

                }
            }

        }

        public void setting(string cst)
        {
            SqlDataAdapter sqla = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sqla.SelectCommand = new SqlCommand("Select cst from tblSetting ", con);
            sqla.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                cst = dt.Rows[0][0].ToString();
                cost = cst;
            }

        }

        public void loadParty(ComboBoxEdit cmb)
        {
            SqlDataAdapter sqla = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sqla.SelectCommand = new SqlCommand("select PartyName from tblPartyInfo ", con);
            sqla.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmb.Properties.Items.Add(dt.Rows[i][0]);

                }
            }

        }

        public void loadCostCenter(ComboBoxEdit cmb)
        {
            SqlDataAdapter sqla = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sqla.SelectCommand = new SqlCommand("Select CostCenter from tblCostcenter ", con);
            sqla.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmb.Properties.Items.Add(dt.Rows[i][0]);
                }
            }

        }

        public void loadCostCenter_new(RepositoryItemSearchLookUpEdit cmb)
        {
            SqlDataAdapter sqla = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sqla.SelectCommand = new SqlCommand("Exec CostCenterLoad", con);//select s.id, c.CostCenter, s.ShipmentSl from tblShipmentInfo S left join tblCostcenter c on c.id =s.LCno 
            sqla.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmb.DataSource = dt;
                    cmb.DisplayMember = "ShipmentSl";
                    cmb.ValueMember = "ShipmentSl";

                }
            }

        }
        public void loadCostCenter_new_report(SearchLookUpEdit cmb)
        {
            SqlDataAdapter sqla = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sqla.SelectCommand = new SqlCommand("exec CostCenterLoad ", con);
            sqla.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmb.Properties.DataSource = dt;
                    cmb.Properties.DisplayMember = "ShipmentSl";
                    cmb.Properties.ValueMember = "ShipmentSl";

                }
            }

        }
        public void textChange_event(ComboBoxEdit cmb, LabelControl lbl, TextEdit txt, Panel panel)
        {

            if (cmb.Text == String.Empty)
            {
                cmb.Focus();
            }
            else
            {
                lbl.Visible = false;
                cmb.Visible = false;
                panel.Visible = false;
                txt.Focus();
            }
        }
        public void partyID(ComboBoxEdit cmb)
        {
            SqlDataAdapter sqla = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sqla.SelectCommand = new SqlCommand(String.Format("Select id from tblPartyInfo where PartyName = '{0}' ", cmb.Text), con);
            sqla.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                cmb.Tag = dt.Rows[0][0].ToString();
            }
        }

        public void costID(ComboBoxEdit cmb)
        {
            SqlDataAdapter sqla = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sqla.SelectCommand = new SqlCommand("Select id from tblCostcenter where CostCenter = '" + cmb.Text + "' ", con);
            sqla.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                cmb.Tag = dt.Rows[0][0].ToString();
            }
        }
        public void costID_new(RepositoryItemSearchLookUpEdit cmb)
        {
            SqlDataAdapter sqla = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sqla.SelectCommand = new SqlCommand("Select id from tblCostcenter where CostCenter = '" + cmb.DisplayMember + "' ", con);
            sqla.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                cmb.Tag = dt.Rows[0][0].ToString();


            }
        }

        public SqlTransaction transaction;
        SqlCommand comm;
        SqlDataAdapter adapter;
        public bool beginConnection()
        {
            try
            {
                con.Open();
                transaction = con.BeginTransaction();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                transaction.Rollback();
                return false;
            }
        }
        


        public DataTable dataread(string query)
        {
            DataSet dataset;
            DataTable dt;
           
                try
                {
                    //SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                    adapter = new SqlDataAdapter(query, con);
                    dataset = new DataSet();
                    adapter.Fill(dataset, "Virtual");
                    dt = dataset.Tables["Virtual"];
                   
                    return dt;
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                  
                    return null;
                }

            

        }

        string errorCaption = "RB Error.";
        string infCaption = "RB Information.";
        string warnCaption = "RB Warning.";
        
       

        


        public void delete(string TableName, string vchtype, string vchNo, bool statdelete)
        {
            string query = "delete from " + TableName + " where vouchertype = '" + vchtype + "'and voucherNo= '" + vchNo + "'";
            statdelete = dataeditTrans(query);
        }

    
        public bool insrtpermission = false;
        public bool Editpermission = false;
        public bool deletepermission = false;
        public bool reportpermission = false;

        //public DataTable PermissionCheckAll(string Name)
        //{
        //    string query =
        //        " select F.formName, M.insertPermission, M.EditPermission, M.deletePermission, M.ReportPermission from tblMenuPermissionAccounts M left join tblFormNameAccounts F " +
        //        "on F.SlNo= M.FormId left join tbl_User U on U.RoleId= M.RoleId where U.userId ='" + Dashboard.UserId + "' and F.formName = '"+Name+"'";
        //        DataTable dt = dataread(query);
        //    if (dt!= null && dt.Rows.Count>0)
        //    {
        //         insrtpermission = Convert.ToBoolean(dt.Rows[0][1]);
        //         Editpermission = Convert.ToBoolean(dt.Rows[0][2]);
        //         deletepermission = Convert.ToBoolean(dt.Rows[0][3]);
        //         reportpermission = Convert.ToBoolean(dt.Rows[0][4]);
        //    }
        //        return dt;
        //}

        //public void PermissionCheck(string Name)
        //{
        //    string query =
        //        " select F.formName, M.insertPermission, M.EditPermission, M.deletePermission, M.ReportPermission from tblMenuPermissionAccounts M left join tblFormNameAccounts F " +
        //        "on F.SlNo= M.FormId left join tbl_User U on U.RoleId= M.RoleId where U.userId ='" + Dashboard.UserId + "' and F.formName = '" + Name + "'";
        //    DataTable dt = dataread(query);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        insrtpermission = Convert.ToBoolean(dt.Rows[0][1]);
        //        Editpermission = Convert.ToBoolean(dt.Rows[0][2]);
        //        deletepermission = Convert.ToBoolean(dt.Rows[0][3]);
        //        reportpermission = Convert.ToBoolean(dt.Rows[0][4]);
        //    }

        //}

    }
}
