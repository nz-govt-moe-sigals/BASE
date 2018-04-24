namespace App.Core.Infrastructure.IDA.Models
{
    using App.Core.Shared.Attributes;

    /// <summary>
    ///     Client Specific Configuration Variables.
    /// 
    /// </summary>
    public class OidcConfidentialClientConfiguration : IOIDCConfidentialClientConfiguration
    {
        /// <summary>
        ///     Authority is the URL for authority.
        /// <para>
        /// Regarding Source:
        /// although technically not a 'secret', the url most often 
        /// contains a system identifier/name. Hence, best it not be
        /// committed to code via web.settings.
        /// An appopriate solution appears to be a Build Pipeline 
        /// injecting the HostSetting when it's building the Resources.
        /// The Keyvault would be a bit unwieldy as well as slower.
        /// </para>
        ///     <para>
        ///         For AAD V2 and B2C, is composed by Azure Active Directory v2 endpoint combined with the tenant name
        ///     </para>
        ///     <para>
        ///         Note that this is similar but not the same uri root as the AuthorityConfigurationPolicyUri
        ///         {configType} =[common|organisations|consumers|{AuthorityTenantName}|{AuthorityTenantGuid}]
        ///         (e.g. https://login.microsoftonline.com/{configType}/v2.0/.well-known/openid-configuration)
        ///     </para>
        ///     <para>
        ///         App-Core-Integration-Oidc- AadInstance
        ///         eg: https://login.microsoftonline.com/{0}{1}{2}
        ///     </para>
        /// </summary>
        //[Alias("App-Core-Integration-Oidc-PolicyBased-AadInstance")]
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OIDCClientKeys.AuthorityUri)]
        public virtual string AuthorityUri
        {
            get { return this._authorityUri; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                this._authorityUri = value;
            }
        }

        /// <summary>
        ///     The Client application's unique Id.
        ///     <para>eg: 00000000-0000-.....</para>
        ///     <para>Default Host Setting key is 'App-Core-Integration-Oidc-ClientId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OIDCClientKeys.ClientId)]
        public string ClientId
        {
            get; set;
        }




        /// <summary>
        ///     The Client application's unique Id.
        ///     <para>eg: SECRET</para>
        ///     <para>Default Host Setting key is 'App-Core-Integration-Oidc-ClientSecret'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OIDCClientKeys.ClientSecret)]
        public string ClientSecret
        {
            get; set;
        }

        /// <summary>
        ///     The Client application's callback to which the access token is delivered.
        ///     <para>Default Host Setting key is 'App-Core-Integration-Oidc-RedirectUri'</para>
        ///     <para>eg: https://localhost:44311/ </para>
        /// <para>
        /// Since the url contains the domain name, this is a setting that will have to be 
        /// injected via the Build Pipeline.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OIDCClientKeys.ClientRedirectUri)]
        public string ClientRedirectUri
        {
            get; set;
        }

        /// <summary>
        /// After logout (ie clearing out of security token), 
        /// where do we redirect to? (eg: home page at '/').
        /// <para>
        /// The default is "/" get back to the default page within the root.
        /// </para>
        /// <para>
        /// If the Url contains no reference to the domain identifier, 
        /// (ie, is just '/', or something similar) this setting
        /// can be defined in the web.config's appsettings.
        /// </para>
        /// <para>
        /// If the url contains the domain name, this is a setting that will have to be 
        /// injected via the Build Pipeline.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OIDCClientKeys.ClientPostLogoutRedirectUri)]
        public string ClientPostLogoutUri
        {
            get => this._clientPostLogoutUri ?? this.ClientRedirectUri;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "/";
                }
                this._clientPostLogoutUri = value;
            }
        }
        private string _clientPostLogoutUri;
        private string _authorityUri;
    }
}