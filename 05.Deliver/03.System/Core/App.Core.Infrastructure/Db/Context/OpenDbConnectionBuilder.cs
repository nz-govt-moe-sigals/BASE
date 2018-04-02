using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Core.Infrastructure.Db.Context
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public static class OpenDbConnectionBuilder
    {
        public static async Task<DbConnection> CreateAsync(string connectionStringName)
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            var dbConnection = DbProviderFactories
                .GetFactory(connectionStringSettings.ProviderName)
                .CreateConnection();
            dbConnection.ConnectionString = connectionStringSettings.ConnectionString;
     

            await AttachAccessTokenToDbConnection(dbConnection);

            // Think DbContext will open it when first used.
            //await dbConnection.OpenAsync();

            return dbConnection;
        }
        static async Task AttachAccessTokenToDbConnection(IDbConnection dbConnection)
        {
            SqlConnection sqlConnection = dbConnection as SqlConnection;
            if (sqlConnection == null)
            {
                return;
            }
            string msiEndpoint = Environment.GetEnvironmentVariable("MSI_ENDPOINT");
            if (string.IsNullOrEmpty(msiEndpoint))
            {
                return;
            }

            var msiSecret = Environment.GetEnvironmentVariable("MSI_SECRET");
            if (string.IsNullOrEmpty(msiSecret))
            {
                return;
            }

            // To get around:
            // "Cannot set the AccessToken property if 'UserID', 'UID', 'Password', or 'PWD' has been specified in connection string."
            var terms = new[] {"UserID","Password","PWD=","UID=" };
            if (terms.Any(term => dbConnection.ConnectionString.Contains(term, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            string accessToken = await AppCoreDbContextMSITokenFactory.GetAzureSqlResourceTokenAsync();
            sqlConnection.AccessToken = accessToken;
        }
    }
}
