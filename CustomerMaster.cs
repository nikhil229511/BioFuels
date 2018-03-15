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
    public partial class CustomerMaster : Form
    {
        Global query = new Global();
        public CustomerMaster()
        {
            InitializeComponent();
        }

        private void CustomerMaster_KeyDown(object sender, KeyEventArgs e)
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                query.con.Open();
                SqlCommand cmd = new SqlCommand("CustomerMasterInsert", query.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CUSTOMERNAME", txtCustomerName.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@ADDRESS", txtAddress.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@STATENAME", txtStateName.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@STATECODE", txtStateCode.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@GSTINCODE", txtCGSTIN.Text).DbType = DbType.String;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                query.con.Close();
                this.customerMasterSelectTableAdapter.Fill(this.customerMaster1.CustomerMasterSelect);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                query.con.Open();
                SqlCommand cmd = new SqlCommand("CustomerMasterUpdate", query.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CUSTOMERID", txtCustomerName.Tag).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@CUSTOMERNAME", txtCustomerName.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@ADDRESS", txtAddress.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@STATENAME", txtStateName.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@STATECODE", txtStateCode.Text).DbType = DbType.String;
                cmd.Parameters.AddWithValue("@GSTINCODE", txtCGSTIN.Text).DbType = DbType.String;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                query.con.Close();
                this.customerMasterSelectTableAdapter.Fill(this.customerMaster1.CustomerMasterSelect);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                query.con.Open();
                SqlCommand cmd = new SqlCommand("CustomerMasterDelete", query.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CUSTOMERID", txtCustomerName.Tag).DbType = DbType.Int16;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                query.con.Close();
                this.customerMasterSelectTableAdapter.Fill(this.customerMaster1.CustomerMasterSelect);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dgvCustomerMaster_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCustomerName.Tag = dgvCustomerMaster.CurrentRow.Cells[0].Value.ToString();
            txtCustomerName.Text = dgvCustomerMaster.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text=dgvCustomerMaster.CurrentRow.Cells[2].Value.ToString();
            txtStateName.Text = dgvCustomerMaster.CurrentRow.Cells[3].Value.ToString();
            txtStateCode.Text = dgvCustomerMaster.CurrentRow.Cells[4].Value.ToString();
            txtCGSTIN.Text = dgvCustomerMaster.CurrentRow.Cells[5].Value.ToString();
        }

        private void CustomerMaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customerMaster1.CustomerMasterSelect' table. You can move, or remove it, as needed.
            this.customerMasterSelectTableAdapter.Fill(this.customerMaster1.CustomerMasterSelect);

        }
    }
}
