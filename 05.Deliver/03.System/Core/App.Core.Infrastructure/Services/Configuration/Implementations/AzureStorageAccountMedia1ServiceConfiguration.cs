namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Contracts;
    using App.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// 
    /// <para>
    /// Inherits from <see cref="ICoreServiceConfigurationObject"/>
    /// whic inherits from <see cref="IHasSingletonLifecycle"/>
    /// to hint at startup that the Configuration object should be 
    /// IoC registered for the duration of the application (not the thread).
    /// as some configuration hits remote services (eg: Azure KeyVault)
    /// which would be rather slow.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.Configuration.ICoreServiceConfigurationObject" />
    /// <seealso cref="App.Core.Infrastructure.Services.Configuration.Implementations.AzureStorageAccountServiceConfigurationBase" />
    public class AzureStorageAccountMedia1ServiceConfiguration : AzureStorageAccountServiceConfigurationBase
    {
        public AzureStorageAccountMedia1ServiceConfiguration(IAzureKeyVaultService keyVaultService) : base(keyVaultService)
        {

            var configuration =
                keyVaultService.GetObject<AzureStorageAccountMedia1ConfigurationSettings>();

            Initialize(configuration);
        }
    }
}