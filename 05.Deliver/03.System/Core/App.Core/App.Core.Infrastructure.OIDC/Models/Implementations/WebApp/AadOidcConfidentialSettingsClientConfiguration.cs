using App.Core.Infrastructure.IDA.Constants.HostSettingsKeys;
using App.Core.Shared.Attributes;

namespace App.Core.Infrastructure.IDA.Models.Implementations.WebApp
{
    /// <summary>
    /// The settings used for AAD Integration via OIDC inherit from the base
    /// OIDC settings common to all OIDC clients.
    /// </summary>
    /// <seealso cref="OidcSettingsConfidentialSettingsClientConfiguration" />
    /// <seealso cref="IAadOidcSettingsConfidentialClientConfiguration" />
    public class AadOidcSettingsConfidentialSettingsClientConfiguration : OidcSettingsConfidentialSettingsClientConfiguration,
        IAadOidcSettingsConfidentialClientConfiguration
    { 
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
        [Alias(WebAppOidcKeys.AuthorityUri)]
        public override string AuthorityUri
        {
            get => base.AuthorityUri
                   ??
                   // The default Uri for AAD V2 is:
                   $"https://login.microsoftonline.com/{AuthorityTenantName}/v2.0/.well-known/openid-configuration";
            set
            {
                //In the base class, if empty, will be converted to null.
                //So will return with the abvoe default value:
                base.AuthorityUri = value;
            }
        }
    }
}