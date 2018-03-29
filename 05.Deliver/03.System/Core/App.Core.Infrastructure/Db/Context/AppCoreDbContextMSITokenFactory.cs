using System;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;

    // Refer to: https://winterdom.com/2017/10/19/azure-sql-auth-with-msi
    public static class AppCoreDbContextMSITokenFactory
    {
        private const String azureSqlResource = "https://database.windows.net/";

        public static async Task<String> GetAzureSqlResourceTokenAsync()
        {
            var provider = new AzureServiceTokenProvider();
            var result = await provider.GetAccessTokenAsync(azureSqlResource);
            return result;
        }
    }