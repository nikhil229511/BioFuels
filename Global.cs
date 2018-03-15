using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace TechKidBioFuels
{
    class Global
    {
        public SqlConnection con = new SqlConnection(TechKidBioFuels.Properties.Settings.Default.DBCon.ToString());
        public void loginMessage()
        {
            MessageBox.Show("Login Successful.", "Inventory Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void insertMessage()
        {
            MessageBox.Show("Record Saved Successfully.", "Inventory Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void deleteMessage()
        {
            MessageBox.Show("Record Deleted Successfully.", "Inventory Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void updateMessage()
        {
            MessageBox.Show("Record Updated Successfully.", "Inventory Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
