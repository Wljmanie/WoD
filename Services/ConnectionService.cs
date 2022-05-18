
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace WoD.Services
{
    public class ConnectionService
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            
            var conString = configuration.GetConnectionString("DefaultConnection");
            var databaseUrl = "data source=.\\MSSQLSERVER2019;UID=" +
                configuration.GetSection("DBSHIT")["user"] +
                ";PWD=" +
                configuration.GetSection("DBSHIT")["pass"]
                + ";initial catalog=wod";






            return databaseUrl;
            //return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"? conString : databaseUrl;

        }
    }
}
