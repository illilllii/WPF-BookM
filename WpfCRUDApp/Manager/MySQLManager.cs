using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace WpfCRUDApp.Manager
{
    class MySQLManager
    {
        static readonly string strConn = $"SERVER=localhost;DATABASE=book;UID=bookuser;PASSWORD=book1234";
        public static int ExecuteQuery(string query)
        {
            int rowCount;
            App.connection = new MySqlConnection(strConn);

            MySqlCommand sqlCommand = new MySqlCommand(query, App.connection);

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandTimeout = 12 * 3600;

                App.connection.Open();
                rowCount = sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                App.connection.Close();
                App.connection.Dispose();
            }
            return rowCount;

        }

        public static DataSet Select(string query)
        {
            DataSet ds = new DataSet();
            App.connection = new MySqlConnection(strConn);

            try
            {
                App.connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, App.connection);
                adapter.Fill(ds);

                adapter.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                App.connection.Close();
                App.connection.Dispose();
            }

            return ds;
        }
    }
}
