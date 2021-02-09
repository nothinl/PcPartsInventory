using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PcPartsInventory.Classes
{
    class SQLConnection
    {
        public static SqlConnection SQLConnect()
        {
            SqlConnection connection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PcPartsDB"]?.ConnectionString;
                connection = new SqlConnection(connectionString);
                MessageBox.Show("Account Update Successful", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL was not able to connect to the database. Error: " + ex.ToString(), "SQL Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }
        public static void CloseSQLConnect(SqlConnection SQLconn)
        {
            if (SQLconn != null)
            {
                SQLconn.Close();
            }
        }
    }
}
