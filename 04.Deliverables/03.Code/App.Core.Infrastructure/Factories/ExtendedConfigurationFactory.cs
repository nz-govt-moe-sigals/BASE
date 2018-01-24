namespace App.Core.Infrastructure.Factories
{
    using App.Core.Infrastructure.Services;


    /// <summary>
    /// Currently adds no value...(useAppSettingsOnly=true)
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Factories.ConfigurationFactory" />
    public class ExtendedConfigurationFactory : ConfigurationFactory
    {
        //private readonly IAzureKeyVaultService _azureKeyVaultService;

        public ExtendedConfigurationFactory(/*causes recursion IAzureKeyVaultService azureKeyVaultService*/) :
            base(true)
        {
            //this._azureKeyVaultService = azureKeyVaultService;
        }


        //protected virtual bool DoesKeyExist(string key)
        //{

        //}

        //protected string GetAppSetting(string key)
        //{
        //    // Key vault does not allow for same chars that are allowed in app.config
        //    // TOOD: Consider whether app settings should have dash instead?
        //    key = key.Replace(':', '-');

        //    this._azureKeyVaultService.RetrieveSecretAsync(vaultUrl, key);
        //}
    }
}