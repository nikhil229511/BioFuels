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
    public partial class RptSalesCustomerNamewise : Form
    {
        public RptSalesCustomerNamewise()
        {
            InitializeComponent();
        }

        private void RptSalesCustomerNamewise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.rptSalesCustomerNamewiseTableAdapter.Fill(this.rptSalesCustomerNamewise1.RptSalesCustomerNamewise, Convert.ToInt16(cmbCustomerName.SelectedValue));
                this.rtpCustomerNamewiseSales.RefreshReport();
            }
            catch (Exception x)
            {
                MessageBox.Show("Sorry ! No Records Found.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RptSalesCustomerNamewise_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'salesComboCustomerName._SalesComboCustomerName' table. You can move, or remove it, as needed.
            this.salesComboCustomerNameTableAdapter.Fill(this.salesComboCustomerName._SalesComboCustomerName);

        }
    }
}
