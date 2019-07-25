using System.Data.SqlClient;
 
 
namespace Nedo_net.Database
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-VFMKQ4N\SQLEXPRESS";

            string database = "studentdb";
            string username = "";
            string password = "";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }

}