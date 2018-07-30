using App.Core.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.IDA.Models.Implementations
{
    public class AuthBearerTokenSettingsConfiguration : IAuthBearerTokenSettingsConfiguration
    {
        private string _authorityConfigurationPolicyUri;


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.ApiOidcKeys.Tenant)]
        public string AuthorityTenantName { get; set; }


        /// <summary>
        ///     OPTIONAL SETTING
        ///     In addition to the base Uri to the OIDC IdP (ie, AuthorityUri),
        ///     B2C uses a more complex Uri that includes the Policy Id, in order to
        ///     to retrieve Config
        ///     <para>
        ///         "https://login.microsoftonline.com/tfp/{tenant}/{defaultPolicyId}/v2.0/.well-known/openid-configuration"
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.ApiOidcKeys.AuthorityUri)]
        public string AuthorityUri
        {
            get => this._authorityConfigurationPolicyUri
                   ??
                   $"https://login.microsoftonline.com/{this.AuthorityTenantName}/v2.0/.well-known/openid-configuration";
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._authorityConfigurationPolicyUri = value;
                }
            }
        }

        /// <summary>
        ///     The Client application's unique Id.
        ///     <para>eg: 00000000-0000-.....</para>
        ///     <para>Default Host Setting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-') + 'Oidc-ClientId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.ApiOidcKeys.ClientId)]
        public string ClientId { get; set; }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.ApiOidcKeys.AppIdUri)]
        public string AppIdUrl { get; set; }



        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.ApiOidcKeys.ClientIdB2C)]
        public string ClientIdB2C { get; set; }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.ApiOidcKeys.AppIdUrlB2C)]
        public string AppIdUrlB2C { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.ApiOidcKeys.PolicyIdB2C)]
        public string PolicyIdB2C { get; set; }

    }
}
