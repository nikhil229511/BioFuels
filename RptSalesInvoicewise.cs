using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TechKidBioFuels
{
    public partial class RptSalesInvoicewise : Form
    {
        Global query = new Global();
        public RptSalesInvoicewise()
        {
            InitializeComponent();
        }

        private void RptSalesInvoicewise_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RptSalesInvoicewise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.rptSalesInvoicewiseTableAdapter.Fill(this.rptSalesInvoicewise1._RptSalesInvoicewise, txtInvoiceNo.Text);
                this.rtpInvoicewiseSales.RefreshReport();
            }
            catch (Exception x)
            {
                MessageBox.Show("Sorry ! No Records Found.","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "admin456")
            {
                try
                {
                    query.con.Open();
                    SqlCommand cmd = new SqlCommand("SalesInvoiceDelete", query.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@INVOICENO", txtInvoiceNo.Text).DbType = DbType.String;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    query.con.Close();
                    MessageBox.Show("Delete Successful.");
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            else
            {
                MessageBox.Show("Incorrect Password.");
            }
        }
    }
}
