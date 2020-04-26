using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatcioniAutobisave.DAL
{
    public class SqlHelper
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["BusStationManagment"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine("asdasda");
                throw;

            }
        }
        public static SqlCommand Command(SqlConnection connection,string cmdText,CommandType commandType)
        {
            SqlCommand command = new SqlCommand(cmdText,connection);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
    }
}
