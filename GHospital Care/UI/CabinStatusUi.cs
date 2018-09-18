using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using GHospital_Care.BAL.Manager;

namespace GHospital_Care.UI
{
    public partial class CabinStatusUi : Form
    {
        public CabinStatusUi()
        {
            InitializeComponent();
        }







        public void GetDischargeIndoorPatientForCabinStatus()
        {
            DateTime FromDate = fromDate.Value;
            DateTime ToDate = this.ToDate.Value;
            gridControl1.DataSource = new CabinStatusManager().GetDischargeIndoorPatientForCabinStatus(FromDate, ToDate);
        }


        private void picBoxSearch_Click(object sender, EventArgs e)
        {
            GetDischargeIndoorPatientForCabinStatus();
        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            GetDischargeIndoorPatientForCabinStatus();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            GetDischargeIndoorPatientForCabinStatus();
        }

        private void CabinStatusUi_Shown(object sender, EventArgs e)
        {
            GetDischargeIndoorPatientForCabinStatus();
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFreeCabin_Click(object sender, EventArgs e)
        {
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ((DXMouseEventArgs)e).Handled = true;
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                if (hitInfo.InRow)
                {
                    view.FocusedColumn = hitInfo.Column;
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    view.ShowEditor();
                    contextMenuStrip1.Show(view.GridControl, e.Location);

                }
            }
        }


    }
}
