namespace App.Core.Infrastructure.IDA.Models
{
    using App.Core.Shared.Attributes;

    public class AADOidcConfidentialClientConfiguration : OidcConfidentialClientConfiguration,
        IAADOidcConfidentialClientConfiguration
    {
        private string _authorityUri;

        private string _authorityUriType;

        /// <summary>
        ///     Gets or sets the type of the AAD Authority URI type.
        ///     <para>
        ///         Can be set to one of:
        ///         * AAD AuthorityTenantName
        ///         * AAD AuthorityTenant Guid
        ///         * AAD AuthorityTenant Guid
        ///     </para>
        /// </summary>
        /// <value>
        ///     The type of the authority URI.
        /// </value>
        [Alias("ida:AuthorityUriType")]
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

        /// <summary>
        ///     The unique B2C Tenant Name.
        ///     <para>eg: xyz.onmicrosoft.com</para>
        ///     <para>Default Host Setting key is 'ida:Tenant'</para>
        /// </summary>
        [Alias("ida:AuthorityTenantName")]
        public string AuthorityTenantName { get; set; }


        [Alias("ida:AuthorityUri")]
        public override string AuthorityUri
        {
            get => base.AuthorityUri
                   ??
                   // The default Uri for AAD V2 is:
                   $"https://login.microsoftonline.com/{this.AuthorityUriType}/v2.0/.well-known/openid-configuration";
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                base.AuthorityUri = value;
            }
        }
    }
}