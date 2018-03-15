using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechKidBioFuels
{
    public partial class RptSalesDatewise : Form
    {
        public RptSalesDatewise()
        {
            InitializeComponent();
        }
        DateTime fd, td;
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            fd = Convert.ToDateTime(dtpFromDate.Text.Substring(3, 2) + "/" + dtpFromDate.Text.Substring(0, 2) + "/" + dtpFromDate.Text.Substring(6, 4));
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            td = Convert.ToDateTime(dtpToDate.Text.Substring(3, 2) + "/" + dtpToDate.Text.Substring(0, 2) + "/" + dtpToDate.Text.Substring(6, 4));
        }

        private void RptSalesDatewise_Load(object sender, EventArgs e)
        {
            fd = Convert.ToDateTime(dtpFromDate.Text.Substring(3, 2) + "/" + dtpFromDate.Text.Substring(0, 2) + "/" + dtpFromDate.Text.Substring(6, 4));
            td = Convert.ToDateTime(dtpToDate.Text.Substring(3, 2) + "/" + dtpToDate.Text.Substring(0, 2) + "/" + dtpToDate.Text.Substring(6, 4));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime fd = Convert.ToDateTime(dtpFromDate.Text.Substring(3, 2) + "/" + dtpFromDate.Text.Substring(0, 2) + "/" + dtpFromDate.Text.Substring(6, 4));
            DateTime td = Convert.ToDateTime(dtpToDate.Text.Substring(3, 2) + "/" + dtpToDate.Text.Substring(0, 2) + "/" + dtpToDate.Text.Substring(6, 4));
            this.rptSalesDatewiseTableAdapter.Fill(this.rptSalesDatewise1._RptSalesDatewise, fd, td);

            ReportParameter rp1 = new ReportParameter("FROMDATE", dtpFromDate.Text);
            ReportParameter rp2 = new ReportParameter("TODATE", dtpToDate.Text);
            this.rtpDatewiseSales.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2 });
            this.rtpDatewiseSales.RefreshReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RptSalesDatewise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {
                this.Close();
            }
        }
    }
}
