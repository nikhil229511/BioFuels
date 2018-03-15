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
    public partial class MainTerminal : Form
    {
        
        public MainTerminal()
        {
            InitializeComponent();
        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMaster frm = new CustomerMaster();
            frm.ShowDialog();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales frm = new Sales();
            frm.ShowDialog();
        }

        private void salesInvoiceNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptSalesInvoicewise frm = new RptSalesInvoicewise();
            frm.ShowDialog();
        }

        private void salesPartyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptSalesCustomerNamewise frm = new RptSalesCustomerNamewise();
            frm.ShowDialog();
        }

        private void salesDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptSalesDatewise frm = new RptSalesDatewise();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
