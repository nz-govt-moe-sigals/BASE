namespace App.Core.Infrastructure.IDA.Models
{
    using App.Core.Infrastructure.IDA.Constants.HostSettingsKeys;
    using App.Core.Shared.Attributes;

    /// <summary>
    /// The settings used for AAD Integration via OIDC inherit from the base
    /// OIDC settings common to all OIDC clients.
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.IDA.Models.OidcConfidentialClientConfiguration" />
    /// <seealso cref="App.Core.Infrastructure.IDA.Models.IAADOidcConfidentialClientConfiguration" />
    public class AADOidcConfidentialClientConfiguration : OidcConfidentialClientConfiguration,
        IAADOidcConfidentialClientConfiguration
    {

        /// <summary>
        ///     Gets or sets the type of the AAD Authority URI type.
        ///     <para>
        ///         Can be set to one of:
        ///         * AAD AuthorityTenantName
        ///         * AAD AuthorityTenant Guid
        ///         * AAD AuthorityTenant Guid
        ///     </para>
        /// <para>
        /// Define the value using the Build Pipeline injecting the value into AppSettings.
        /// </para>
        /// </summary>
        /// <value>
        ///     The type of the authority URI.
        /// </value>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(AADOIDCKeys.AuthorityUriType)]
        public string AuthorityUriType
        {
            get => this._authorityUriType ?? this.AuthorityTenantName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                this._authorityUriType = value;
            }
        }
        private string _authorityUriType;

        /// <summary>
        ///     The unique B2C Tenant Name.
        ///     <para>eg: xyz.onmicrosoft.com</para>
        ///     <para>Default Host Setting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-Tenant'</para>
        /// <para>
        /// Define the value using the Build Pipeline injecting the value into AppSettings.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(AADOIDCKeys.AuthorityTenantName)]
        public string AuthorityTenantName { get; set;
        }



        /// <summary>
        /// Override of the base OIDC Parameter
        /// to provide a default settings, as it can be 
        /// calculated from the values provided within this class.
        /// <para>
        /// Regarding Source:
        /// although technically not a 'secret', the url most often
        /// contains a system identifier/name. Hence, best it not be
        /// committed to code via web.settings.
        /// An appopriate solution appears to be a Build Pipeline
        /// injecting the HostSetting when it's building the Resources.
        /// The Keyvault would be a bit unwieldy as well as slower.
        /// </para><para>
        /// For AAD V2 and B2C, is composed by Azure Active Directory v2 endpoint combined with the tenant name
        /// </para><para>
        /// Note that this is similar but not the same uri root as the AuthorityConfigurationPolicyUri
        /// {configType} =[common|organisations|consumers|{AuthorityTenantName}|{AuthorityTenantGuid}]
        /// (e.g. https://login.microsoftonline.com/{configType}/v2.0/.well-known/openid-configuration)
        /// </para><para>
        /// ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc- AadInstance
        /// eg: https://login.microsoftonline.com/{0}{1}{2}
        /// </para>
        /// <para>
        /// Define the value using the Build Pipeline injecting the value into AppSettings.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(OIDCClientKeys.AuthorityUri)]
        public override string AuthorityUri
        {
            get => base.AuthorityUri
                   ??
                   // The default Uri for AAD V2 is:
                   $"https://login.microsoftonline.com/{this.AuthorityUriType}/v2.0/.well-known/openid-configuration";
            set
            {
                //In the base class, if empty, will be converted to null.
                //So will return with the abvoe default value:
                base.AuthorityUri = value;
            }
        }
    }
}