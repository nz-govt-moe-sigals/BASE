using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Core.Infrastructure.Db.Context.Default
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    public class OpenDbConnectionBuilder
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;


        public OpenDbConnectionBuilder(IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
        }

        public async Task<DbConnection> CreateAsync(string connectionStringName)
        {

            var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            _diagnosticsTracingService.Trace(TraceLevel.Info, "OpenDbConnectionBuilder.CreateAsync: {0}", connectionStringName);
            _diagnosticsTracingService.Trace(TraceLevel.Info,"OpenDbConnectionBuilder.CreateAsync: {0}",connectionStringSettings);

            var dbConnection = DbProviderFactories
                .GetFactory(connectionStringSettings.ProviderName)
                .CreateConnection();

            dbConnection.ConnectionString = connectionStringSettings.ConnectionString;
     

            await AttachAccessTokenToDbConnection(dbConnection);

            // Think DbContext will open it when first used.
            //await dbConnection.OpenAsync();

            return dbConnection;
        }
        async Task AttachAccessTokenToDbConnection(IDbConnection dbConnection)
        {
            SqlConnection sqlConnection = dbConnection as SqlConnection;
            if (sqlConnection == null)
            {
                return;
            }
            string connectionString = dbConnection.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                return;
            }
            // To get around:
            // "Cannot set the AccessToken property if 'UserID', 'UID', 'Password', or 'PWD' has been specified in connection string."
            var terms = new[] {"UserID","Password","PWD=","UID=", "(localdb)\\mssqllocaldb" };
            foreach (var term in terms)
            {
                if (connectionString.Contains(term, StringComparison.InvariantCultureIgnoreCase))
                {
                    _diagnosticsTracingService.Trace(TraceLevel.Info, "OpenDbConnectionBuilder.AttachAccessTokenToDbConnection: Contains UserName or Password");
                    return;
                }
            }

            _diagnosticsTracingService.Trace(TraceLevel.Info, "OpenDbConnectionBuilder.AttachAccessTokenToDbConnection: Attempting to retrieve Token.");
            string accessToken = AppCoreDbContextMSITokenFactory.GetAzureSqlResourceToken();

            _diagnosticsTracingService.Trace(TraceLevel.Info, "OpenDbConnectionBuilder.AttachAccessTokenToDbConnection: AccessToken: {0}", accessToken);

            sqlConnection.AccessToken = accessToken;

            //using (SqlConnection connection = sqlConnection) // test db connection 
            //{
            //    try
            //    {
            //        //connection.AccessToken = accesstoken;
            //        connection.Open();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
        }
    }
}
