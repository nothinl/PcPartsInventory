using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace PcPartsInventory.Classes
{
    class User
    {
        public static void UserAdd
             (string Username,
             string FirstName,
             string LastName,
             string Contact,
             string Password,
             string Address/*, bool AccStat*/)
        {
             SqlConnection SQLconn = SQLConnection.SQLConnect();
             try
             {
                 using (SqlCommand command = new SqlCommand("dbo.AddUser", SQLconn))
                 {
                     SQLconn.Open();
                     command.CommandType = CommandType.StoredProcedure;
                     command.Parameters.Add("@Username", SqlDbType.VarChar, 100).Value = Username;
                     command.Parameters.Add("@Firstname", SqlDbType.VarChar, 100).Value = FirstName;
                     command.Parameters.Add("@Lastname", SqlDbType.VarChar, 100).Value = LastName;
                     command.Parameters.Add("@Contact", SqlDbType.VarChar, 100).Value = Contact;
                     command.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
                     command.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = Address;
                     //command.Parameters.Add("@AccStat", SqlDbType.Bit).Value = AccStat;
                     command.ExecuteNonQuery();
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("SQL was not able to execute the command. Error: " + ex.ToString(), "SQL Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             SQLConnection.CloseSQLConnect(SQLconn);

            /*try
            {
                using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-2M20CN6; Database=PC_PartsDB; User Id=sa; password=destiny1"))
                {
                    connection.Open();
                    // The database is closed upon Dispose() (or Close()).
                    SqlCommand command = new SqlCommand("dbo.AddUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Username", SqlDbType.VarChar, 100).Value = Username;
                    command.Parameters.Add("@Firstname", SqlDbType.VarChar, 100).Value = FirstName;
                    command.Parameters.Add("@Lastname", SqlDbType.VarChar, 100).Value = LastName;
                    command.Parameters.Add("@Contact", SqlDbType.VarChar, 100).Value = Contact;
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
                    command.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = Address;
                    //command.Parameters.Add("@AccStat", SqlDbType.Bit).Value = AccStat;

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("SQL Connected", "SQLConnection Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL was not able to connect to the database. Error: " + ex.ToString(), "SQL Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

        }


        public static void UserUpdate
            (string Username,
             string FirstName,
             string LastName,
             string Contact,
             string Password,
             string Address/*,
             bool AccStat*/)
        {
            SqlConnection SQLconn = SQLConnection.SQLConnect();
            try
            {
                using (SqlCommand command = new SqlCommand("dbo.UpdateUser", SQLconn))
                {
                    SQLconn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Username", SqlDbType.VarChar, 100).Value = Username;
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar, 100).Value = FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.VarChar, 100).Value = LastName;
                    command.Parameters.Add("@Contact", SqlDbType.VarChar, 100).Value = Contact;
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
                    command.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = Address;
                    //command.Parameters.Add("@AccStat", SqlDbType.Bit).Value = AccStat;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL was not able to execute the command. Error: " + ex.ToString(), "SQL Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SQLConnection.CloseSQLConnect(SQLconn);
        }

        public static string GetUsername(string Username)
        {
            string newUsername = "";
            SqlConnection SQLconn = SQLConnection.SQLConnect();
            try
            {
                using (SqlCommand command = new SqlCommand("dbo.UsernameGet", SQLconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Username1", SqlDbType.VarChar, 100).Value = Username;
                    SQLconn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newUsername = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL was not able to execute the command. Error: " + ex.ToString(), "SQL Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SQLConnection.CloseSQLConnect(SQLconn);
            return newUsername;
        }
        public static string GetPassword(string Username)
        {
            string temp = "";
            SqlConnection SQLconn = SQLConnection.SQLConnect();
            try
            {
                using (SqlCommand command = new SqlCommand("dbo.PasswordGet", SQLconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Username1", SqlDbType.VarChar, 100).Value = Username;
                    SQLconn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temp = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL was not able to execute the command. Error: " + ex.ToString(), "SQL Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SQLConnection.CloseSQLConnect(SQLconn);
            return temp;
        }

        public static bool GetAccountStatus(string Username)
        {
            bool temp = true;
            SqlConnection SQLconn = SQLConnection.SQLConnect();
            try
            {
                using (SqlCommand command = new SqlCommand("dbo.AccountStatus", SQLconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Username1", SqlDbType.VarChar, 100).Value = Username;
                    SQLconn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temp = reader.GetBoolean(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL was not able to execute the command. Error: " + ex.ToString(), "SQL Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SQLConnection.CloseSQLConnect(SQLconn);
            return temp;
        }

        public class UserDeclare
        {
            public string Username;
            public string FirstName;
            public string LastName;
            public string ContactNumber;
            public int GenderID;
            public int UserTypeID;
            public string Address;
            public bool AccountStatus;
        }
    }
}
