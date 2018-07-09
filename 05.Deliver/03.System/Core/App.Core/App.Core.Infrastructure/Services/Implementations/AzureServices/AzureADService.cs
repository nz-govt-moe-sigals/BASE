namespace App.Core.Infrastructure.Services.Implementations.AzureServices
{
    //using ADAL:
    //using Nuget: https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/
    public class AzureADService : IAzureADService
    {
        //public string GetAccessToken(string tenantId, string clientId, string clientSecret)
        //{
        //    string authContextURL = "https://login.windows.net/" + tenantId;
        //    var authenticationContext = new AuthenticationContext(authContextURL);
        //    var credential = new ClientCredential(clientId: , clientSecret: );
        //    var result = authenticationContext.AcquireToken(resource: "https://management.azure.com/", clientCredential: credential);

        //    if (result == null)
        //    {
        //        throw new InvalidOperationException("Failed to obtain the JWT token");
        //    }

        //    string token = result.AccessToken;
        //    return token;
        //}
    }
}
