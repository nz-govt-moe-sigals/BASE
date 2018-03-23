

namespace App.Core.Infrastructure.Services
{
    using System.Threading.Tasks;
    using App.Core.Shared.Models.Configuration;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.KeyVault.WebKey;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// to manage access to an Azure KeyVault.
    /// </summary>
    public interface IAzureKeyVaultService
    {
        Task<JsonWebKey> RetrieveKeyAsync(string vaultUrl,
            string secretKey);

        Task<string> RetrieveSecretAsync(string vaultUrl,
            string secretKey);

        Task<SecretBundle> SetSecretAsync(string vaultUrl,
            string secretKey, string secret);

        Task<string[]> ListSecretKeysAsync(bool returnFQIdentifier, string keyVaultUrl = null);
    }
}
