using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EcommerceApp.DBUtil
{
    public class DBConnection
    {
        private static string connectionString;

        static DBConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            connectionString = config.GetConnectionString("LocalConnection");
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

}

