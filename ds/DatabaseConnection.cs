using System;
using MySql.Data.MySqlClient;

namespace ds
{
    public class DatabaseConnection
    {
        MySqlConnection conn;
        static string host = "localhost";
        static string database = "DSusers";
        static string userDB = "root";
        static string password = "password";
  
        public static string strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password +";CharSet=utf8";

        public bool Open()
        {
            try
            {
                
                conn = new MySqlConnection(strProvider);
                conn.Open();
                return true;
            }
            catch (Exception er)
            {
                throw new Exception("Connection Error ! " + er.Message);
            }

        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}