namespace App.Core.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.KeyVault.WebKey;

    /// <summary>
    /// Base Contract for an Infrastructure Service to 
    /// to manage access to an Azure KeyVault.
    /// </summary>
    public interface IAzureKeyVaultService
    {

        /// <summary>
        /// Gets or sets the standard key divider character ('-').
        /// <para>
        /// Whereas AppHost keys can contain ':', etc. -- KeyVault cannot, so 
        /// they must be converted to this character (eg: '-', or '_', or maybe even '')
        /// </para>
        /// </summary>
        string CleanKeyName(string key);

        Task<JsonWebKey> RetrieveKeyAsync(string secretKey, string vaultUrl = null);

        Task<string> RetrieveSecretAsync(string secretKey, string vaultUrl = null);

        Task<SecretBundle> SetSecretAsync(string secretKey, string secret, string vaultUrl);

        Task<IDictionary<string, string>> GetSecretsAsync(bool returnFQIdentifier = false, int pageSize = 0, string keyVaultUrl = null);

        Task<string[]> ListSecretKeysAsync(bool returnFQIdentifier = false, int pageSize = 0, string keyVaultUrl = null);



        /// <summary>
        ///     Create a Configuration object and fill properties from KeyVault Secrets with the same name.
        ///     <para>
        ///         Note that default values are not provided if the property value = default(T)
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix"></param>
        /// <returns></returns>
        T GetObject<T>(string prefix = null, string keyVaultUrl = null) where T : class;
    }
}