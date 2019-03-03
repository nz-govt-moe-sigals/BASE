using System;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;

// Refer to: https://winterdom.com/2017/10/19/azure-sql-auth-with-msi
//https://docs.microsoft.com/en-us/azure/app-service/app-service-web-tutorial-connect-msi
public static class AppCoreDbContextMSITokenFactory
    {
        private const String AzureSqlResource = "https://database.windows.net/";

        public static string GetAzureSqlResourceToken()
        {
            var provider = new AzureServiceTokenProvider();
            var accessToken = Task.Run(() => provider.GetAccessTokenAsync(AzureSqlResource)).Result;
            return accessToken;
        }
    }