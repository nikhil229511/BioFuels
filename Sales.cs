using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechKidBioFuels
{
    public partial class Sales : Form
    {
        DateTime dt;
        Global qry = new Global();
        public Sales()
        {
            InitializeComponent();
        }
        decimal amt,cgstamt,sgstamt,igstamt,totalgst,grandtotal;
        private void dtpSalesDate_ValueChanged(object sender, EventArgs e)
        {
            dt = Convert.ToDateTime(dtpSalesDate.Text.Substring(3, 2) + "/" + dtpSalesDate.Text.Substring(0, 2) + "/" + dtpSalesDate.Text.Substring(6, 4));
        }

        private void Sales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                qry.con.Open();
                SqlCommand cmd = new SqlCommand("SalesMasterInsert", qry.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CUSTOMERID",cmbCustomerName.SelectedValue).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@SALESDATE", dt).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@INVOICENO", txtInvoiceNo.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@VEHICLENO", txtVehicleNo.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@INWORDS", txtInWords.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@QUANTITY", txtQuantity.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@RATE", txtRate.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@TAXABLEAMT", txtTaxableAmt.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@CGSTRATE", txtCGSTRate.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@CGSTAMT", txtCGSTAmt.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@SGSTRATE", txtSGSTRate.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@SGSTAMT", txtSGSTAmt.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@IGSTRATE", txtIGSTRate.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@IGSTAMT", txtIGSTAmt.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@TOTALGST", txtTotalGST.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@GRANDTOTAL", txtGrandTotal.Text).DbType = DbType.String;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                qry.insertMessage();
                qry.con.Close();

                cmbCustomerName.SelectedValue = 0;
                txtInvoiceNo.Text = "";
                txtVehicleNo.Text = "";
                txtQuantity.Text = "";
                txtRate.Text = "";
                txtInWords.Text = "";
                txtCGSTRate.Text = "0";
                txtSGSTRate.Text = "0";
                txtIGSTRate.Text = "0";
                txtCGSTAmt.Text = "0";
                txtSGSTAmt.Text = "0";
                txtIGSTAmt.Text = "0";
                txtTaxableAmt.Text = "0";
                txtTotalGST.Text = "0";
                txtGrandTotal.Text = "0";

                this.Close();        
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerName.SelectedValue = 0;

                this.salesComboCustomerNameTableAdapter.Fill(this.salesComboCustomerName._SalesComboCustomerName);
                dt = Convert.ToDateTime(dtpSalesDate.Text.Substring(3, 2) + "/" + dtpSalesDate.Text.Substring(0, 2) + "/" + dtpSalesDate.Text.Substring(6, 4));
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Text != "" && txtQuantity.Text != "")
            {
                amt = Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text);
                txtTaxableAmt.Text = Convert.ToString(amt);
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Text != "" && txtQuantity.Text != "")
            {
                amt = Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text);
                txtTaxableAmt.Text = Convert.ToString(amt);
            }
        }

        private void txtCGSTRate_TextChanged(object sender, EventArgs e)
        {
            if (txtCGSTRate.Text != "")
            {
                cgstamt = (Convert.ToDecimal(txtCGSTRate.Text) / Convert.ToDecimal(100)) * Convert.ToDecimal(amt);
                txtCGSTAmt.Text = Convert.ToString(cgstamt);

                totalgst = Convert.ToDecimal(cgstamt) + Convert.ToDecimal(sgstamt) + Convert.ToDecimal(igstamt);
                txtTotalGST.Text = Convert.ToString(totalgst);


                grandtotal = Convert.ToDecimal(totalgst) + Convert.ToDecimal(amt);
                txtGrandTotal.Text = Convert.ToString(grandtotal);
            }
        }

        private void txtSGSTRate_TextChanged(object sender, EventArgs e)
        {
            if (txtSGSTRate.Text != "")
            {
                sgstamt = (Convert.ToDecimal(txtSGSTRate.Text) / Convert.ToDecimal(100)) * Convert.ToDecimal(amt);
                txtSGSTAmt.Text = Convert.ToString(sgstamt);

                totalgst = Convert.ToDecimal(cgstamt) + Convert.ToDecimal(sgstamt) + Convert.ToDecimal(igstamt);
                txtTotalGST.Text = Convert.ToString(totalgst);


                grandtotal = Convert.ToDecimal(totalgst) + Convert.ToDecimal(amt);
                txtGrandTotal.Text = Convert.ToString(grandtotal);
            }
        }

        private void txtIGSTRate_TextChanged(object sender, EventArgs e)
        {
            if (txtIGSTRate.Text != "")
            {
                igstamt = (Convert.ToDecimal(txtIGSTRate.Text) / Convert.ToDecimal(100)) * Convert.ToDecimal(amt);
                txtIGSTAmt.Text = Convert.ToString(igstamt);

                totalgst = Convert.ToDecimal(cgstamt) + Convert.ToDecimal(sgstamt) + Convert.ToDecimal(igstamt);
                txtTotalGST.Text = Convert.ToString(totalgst);


                grandtotal = Convert.ToDecimal(totalgst) + Convert.ToDecimal(amt);
                txtGrandTotal.Text = Convert.ToString(grandtotal);
            }
        }
    }
}
