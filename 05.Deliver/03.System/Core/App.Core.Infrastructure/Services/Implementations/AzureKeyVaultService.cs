
namespace App.Core.Infrastructure.Services.Implementations
{
        using System.Configuration;
        using System.Linq;
        using System.Threading.Tasks;
        using App;
        using App.Core.Infrastructure.Integration.Azure.KeyVault;
        using App.Core.Infrastructure.Services.Configuration;
        using App.Core.Infrastructure.Services.Configuration.Implementations;
        using App.Core.Shared.Models.Configuration;
        using Microsoft.Azure.KeyVault;
        using Microsoft.Azure.KeyVault.Models;
        using Microsoft.Azure.KeyVault.WebKey;
        using Microsoft.IdentityModel.Clients.ActiveDirectory;
        using Microsoft.Rest.Azure;
        using Microsoft.WindowsAzure.Storage;
        using Microsoft.WindowsAzure.Storage.Auth;
        using Microsoft.WindowsAzure.Storage.Queue;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IAzureKeyVaultService" />
    ///     Infrastructure Service Contract.
    /// <para>
    /// Application's that use Azure KeyVault are hosted in Azure. 
    /// Within Azure Application Registration, when registered, they get an Id. 
    /// Which is automaticall mapped to a Service Principal Name (SPN)
    /// (New-AzureRmADServicePrincipal -ApplicationId <Guid> is invoked behind the scene)
    /// (and for now think of it as a Psuedo User that this not visible in AAD Users).
    /// Then within KeyVault, access is granted to the SPN. 
    /// When you sign in, you're using the AppClientId and AppSecret over a secure line.
    /// That's how Azure recognizes the app (as an SPN, not a proper User or Service Account).
    /// And hence why the App is given acces to the KeyVault to retrieve secrets and keys.
    /// </para>
    /// <para>
    /// Depends on:
    ///  Nuget:
    ///    * Microsoft.Azure.KeyVault
    ///    * Microsoft.IdentityModel.Clients.ActiveDirectory
    ///      * NOTE: Which relieas on ADAL, as oposed to the newer MSAL...
    ///  * Powershell:
    ///    * No longer needed: New-AzureRmADServicePrincipal -ApplicationId <Guid>
    /// </para>
    /// </summary>
    public class AzureKeyVaultService : AppCoreServiceBase, IAzureKeyVaultService
    {
            public  AzureKeyVaultServiceConfiguration Configuration
        {
                get
                {
                    return _azureKeyVaultServiceConfiguration;
                }
            }
            private readonly AzureKeyVaultServiceConfiguration _azureKeyVaultServiceConfiguration;


            public AzureKeyVaultService(AzureKeyVaultServiceConfiguration azureKeyVaultServiceConfiguration)
            {
                this._azureKeyVaultServiceConfiguration = azureKeyVaultServiceConfiguration;

            //Build the client early for use later by operations
                
     
            }

            private KeyVaultClient KeyVaultClient
            {
                get
                {
                    return this._keyVaultClient ?? (this._keyVaultClient = new KeyVaultClientFactory().Build(
                               new ClientCredential(
                                   this._azureKeyVaultServiceConfiguration.AADClientInfo.ClientId,
                                   this._azureKeyVaultServiceConfiguration.AADClientInfo.ClientSecret)));
                }
            }
            KeyVaultClient _keyVaultClient;



        /// <summary>
        /// <para>
        /// Applications that use a key vault must authenticate by using a token from Azure Active Directory. 
        ///  The application must first register the application in their Azure Active Directory,
        ///  get the ApplicationId and AuthenticationKey (the shared secret).
        /// clientID and clientSecret are obtained by registering
        /// the application in Azure AD
        /// </para>
        /// </summary>
        /// <param name="aaDClientInfo"></param>
        /// <param name="vaultUrl"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public async Task<JsonWebKey> RetrieveKeyAsync(string secretKey, string keyVaultUrl = null)
            {
            if (string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                keyVaultUrl = this._azureKeyVaultServiceConfiguration.KeyVaultUrl;
            }
                KeyBundle keyBundle = await this.KeyVaultClient.GetKeyAsync(keyVaultUrl, secretKey);

                return keyBundle.Key;
            }

            public async Task<string> RetrieveSecretAsync(string secretKey, string keyVaultUrl = null)
            {
                if (string.IsNullOrWhiteSpace(keyVaultUrl))
                {
                    keyVaultUrl = this._azureKeyVaultServiceConfiguration.KeyVaultUrl;
                }

                var secret = await this.KeyVaultClient.GetSecretAsync(keyVaultUrl, secretKey);

                return secret.Value;
            }


            public async Task<SecretBundle> SetSecretAsync(string secretKey, string secret, string keyVaultUrl=null)
            {
                if (string.IsNullOrWhiteSpace(keyVaultUrl))
                {
                    keyVaultUrl = this._azureKeyVaultServiceConfiguration.KeyVaultUrl;
                }
                var secrectBundle = await this.KeyVaultClient.SetSecretAsync(keyVaultUrl, secretKey, secret);

                return secrectBundle;
            }


            public async Task<string[]> ListSecretKeysAsync(bool returnFQIdentifier, string keyVaultUrl = null)
            {
                if (string.IsNullOrWhiteSpace(keyVaultUrl))
                {
                    keyVaultUrl = this._azureKeyVaultServiceConfiguration.KeyVaultUrl;
                }
                //More than this and you get an error:
                const int maxAzureAllows = 25;
                IPage<SecretItem> secrets = await this.KeyVaultClient.GetSecretsAsync(keyVaultUrl, maxAzureAllows);

                //return this.KeyVaultClient.GetSecretsAsync(keyVaultUrl, 500).GetAwaiter().GetResult().Select(x=>x.Id).ToArray();


                string[] results = returnFQIdentifier
                    ? secrets.Select(x => x.Identifier.Name).ToArray()
                    : secrets.Select(x => x.Id).ToArray();

                return results;

            }

            //public void Do()
            //{

            //    //Get the storage key as a secret in KeyVault
            //    var storageKey = await GetStorageKey();
            //    string storageAccountName = ConfigurationManager.AppSettings["storageAccountName"];
            //    var creds = new StorageCredentials(storageAccountName, storageKey);
            //    var storageAccount = new CloudStorageAccount(creds, true);
            //    var queueClient = storageAccount.CreateCloudQueueClient();
            //    var queue = queueClient.GetQueueReference("samplequeue");
            //    await queue.CreateIfNotExistsAsync();
            //    await queue.AddMessageAsync(new CloudQueueMessage("Hello keyvault"));

            //}

        }
    }


