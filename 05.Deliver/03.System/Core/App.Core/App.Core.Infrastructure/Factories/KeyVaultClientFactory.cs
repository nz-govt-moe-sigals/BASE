
namespace App.Core.Infrastructure.Integration.Azure.KeyVault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Factories;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.ConfigurationSettings;
    using Microsoft.Azure.KeyVault;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// <para>
    /// Depends on:
    ///  Nuget:
    ///    * Microsoft.Azure.KeyVault
    ///    * Microsoft.IdentityModel.Clients.ActiveDirectory
    ///  * Powershell:
    ///    * No longer needed: New-AzureRmADServicePrincipal -ApplicationId <Guid>    /// </para>
    /// </summary>
    public class KeyVaultClientFactory
    {
        /// <summary>
        /// Application's that use Azure KeyVault are hosted in Azure. 
        /// Within Azure Application Registration, when registered, they get an Id. 
        /// Which is automaticall mapped to a Service Principal Name (SPN)
        /// (New-AzureRmADServicePrincipal -ApplicationId <Guid> is invoked behind the scene)
        /// (and for now think of it as a Psuedo User that this not visible in AAD Users).
        /// Then within KeyVault, access is granted to the SPN. 
        /// When you sign in, you're using the AppClientId and AppSecret over a secure line.
        /// That's how Azure recognizes the app (as an SPN, not a proper User or Service Account).
        /// And hence why the App is given acces to the KeyVault to retrieve secrets and keys.
        /// </summary>
        /// <param name="aadClientInfo"></param>
        /// <returns></returns>
        public KeyVaultClient Build(AadApplicationRegistrationInformationConfigurationSettings aadClientInfo)
        {

            var clientCredential = new ClientCredentialFactory().Build(aadClientInfo);

            return Build(clientCredential);


        }

        public KeyVaultClient Build(ClientCredential clientCredential)
        {
            //Applications that use a key vault must authenticate by using a token from Azure Active Directory. 
            // The application must first register the application in their Azure Active Directory,
            // get the ApplicationId and AuthenticationKey (the shared secret).
            //clientID and clientSecret are obtained by registering
            //the application in Azure AD

            var httpClient = new System.Net.Http.HttpClient();

            KeyVaultClient keyVaultClient =
                new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(
                        (a, r, s) => GetAccessTokenAsync(
                            authority: a,
                            resource: r,
                            scope: s,
                            clientCredential: clientCredential)),
                    httpClient);

            return keyVaultClient;

        }

        // Helper to extract access token.
        private static async Task<string> GetAccessTokenAsync(
            string authority,
            string resource,
            string scope,
            ClientCredential clientCredential)
        {

            var context = new AuthenticationContext(
                authority,
                TokenCache.DefaultShared);

            AuthenticationResult authenticationResult = await context.AcquireTokenAsync(
                resource,
                clientCredential);

            var type = authenticationResult.AccessTokenType;

            return authenticationResult.AccessToken;
        }
    }
}
