using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;


namespace App.Core.Infrastructure.Startup.Spikes
{
    using System.Threading.Tasks;

    public class msiTokenRetrievalFromDev
    {

        public async Task<string> DoAsync()
        {

            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            string accessToken = await azureServiceTokenProvider.GetAccessTokenAsync("https://management.azure.com/").ConfigureAwait(false);
            return accessToken;
        }

    }
}