namespace App.Core.Infrastructure.IDA.Models
{
    using App.Core.Shared.Attributes;

    /// <summary>
    ///     Client Specific Configuration Variables
    /// </summary>
    public class OidcConfidentialClientConfiguration : IOIDCConfidentialClientConfiguration
    {
        private string _clientPostLogoutUri;


        /// <summary>
        ///     Authority is the URL for authority.
        ///     <para>
        ///         For AAD V2 and B2C, is composed by Azure Active Directory v2 endpoint combined with the tenant name
        ///     </para>
        ///     <para>
        ///         Note that this is similar but not the same uri root as the AuthorityConfigurationPolicyUri
        ///         {configType} =[common|organisations|consumers|{AuthorityTenantName}|{AuthorityTenantGuid}]
        ///         (e.g. https://login.microsoftonline.com/{configType}/v2.0/.well-known/openid-configuration)
        ///     </para>
        ///     <para>
        ///         App-Core-Integration-ida- AadInstance
        ///         eg: https://login.microsoftonline.com/{0}{1}{2}
        ///     </para>
        /// </summary>
        //[Alias("App-Core-Integration-ida-AadInstance")]
        [Alias("App-Core-Integration-ida-AuthorityUri")]
        public virtual string AuthorityUri { get; set; }

        /// <summary>
        ///     The Client application's unique Id.
        ///     <para>eg: 00000000-0000-.....</para>
        ///     <para>Default Host Setting key is 'App-Core-Integration-ida-ClientId'</para>
        /// </summary>
        [Alias("App-Core-Integration-ida-ClientId")]
        public string ClientId { get; set; }


        /// <summary>
        ///     The Client application's unique Id.
        ///     <para>eg: SECRET</para>
        ///     <para>Default Host Setting key is 'App-Core-Integration-ida-ClientSecret'</para>
        /// </summary>
        [Alias("App-Core-Integration-ida-ClientSecret")]
        public string ClientSecret { get; set; }

        /// <summary>
        ///     The Client application's callback to which the access token is delivered.
        ///     <para>Default Host Setting key is 'App-Core-Integration-ida-RedirectUri'</para>
        ///     <para>eg: https://localhost:44311/ </para>
        /// </summary>
        [Alias("App-Core-Integration-ida-RedirectUri")]
        public string ClientRedirectUri { get; set; }

        [Alias("App-Core-Integration-ida-ClientPostLogoutUri")]
        public string ClientPostLogoutUri
        {
            get => this._clientPostLogoutUri ?? this.ClientRedirectUri;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                this._clientPostLogoutUri = value;
            }
        }
    }
}