namespace App.Core.Infrastructure.IDA.Models
{
    using System;
    using App.Core.Shared.Attributes;

    public class B2COidcConfidentialClientConfiguration : AADOidcConfidentialClientConfiguration,
        IB2COidcConfidentialClientConfiguration, IB2CTenantPolicyConfiguration
    {
        private string _authorityBearerTokenConfigurationPolicyUri;
        private string _authorityCookieConfigurationPolicyUri;

        /// <summary>
        ///     In addition to the base Uri to the OIDC IdP (ie, AuthorityUri),
        ///     B2C uses a more complex Uri that includes the Policy Id, in order to
        ///     to retrieve Config
        ///     <para>
        ///         "https://login.microsoftonline.com/tfp/{tenant}/{defaultPolicyId}/v2.0/.well-known/openid-configuration"
        ///     </para>
        /// </summary>
        [Alias("App-Core-Integration-ida-AuthorityCookieConfigurationPolicyUri")]
        public string AuthorityCookieConfigurationPolicyUri
        {
            get => this._authorityCookieConfigurationPolicyUri
                   ??
                   $"https://login.microsoftonline.com/tfp/{this.AuthorityTenantName}/{this.DefaultPolicyId}/v2.0/.well-known/openid-configuration"
            ;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                this._authorityCookieConfigurationPolicyUri = value;
            }
        }


        [Alias("App-Core-Integration-ida-AuthorityTokenConfigurationPolicyUri")]
        public string AuthorityBearerTokenConfigurationPolicyUri
        {
            get => this._authorityBearerTokenConfigurationPolicyUri
                   ??
                   $"https://login.microsoftonline.com/{this.AuthorityTenantName}/v2.0/.well-known/openid-configuration?p={this.DefaultPolicyId}"
            ;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                this._authorityBearerTokenConfigurationPolicyUri = value;
            }
        }


        #region Policie Ids

        [Alias("App-Core-Integration-ida-DefaultPolicyId")]
        public string DefaultPolicyId
        {
            get => this._defaultPolicyId ?? this.TenantSignUpSignInPolicyId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                this._defaultPolicyId = value;
            }
        }

        private string _defaultPolicyId;


        /// <summary>
        ///     The B2C SignUp Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_SignUp_Policy'</para>
        ///     <para>Note: recommended to be same Policy Name as SignIn </para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-ida-SignUpSignInPolicyId'</para>
        /// </summary>
        [Obsolete]
        [Alias("App-Core-Integration-ida-SignUpPolicyId")]
        public string TenantSignUpPolicyId
        {
            get => this._signUpPolicyId ?? this.TenantSignUpSignInPolicyId;
            set

            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                this._signUpPolicyId = value;
            }
        }

        private string _signUpPolicyId;

        /// <summary>
        ///     The B2C SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_SignIn_Policy'</para>
        ///     <para>Note: recommended to be same Policy Name is SignUp </para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-ida-SignInPolicyId'</para>
        /// </summary>
        [Obsolete]
        [Alias("App-Core-Integration-ida-SignInPolicyId")]
        public string TenantSignInPolicyId
        {
            get => this._signInPolicyId ?? this.TenantSignUpSignInPolicyId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = null;
                }
                this._signInPolicyId = value;
            }
        }

        private string _signInPolicyId;

        /// <summary>
        ///     The B2C SignUp/SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_SignUpSignIn_Policy'</para>
        ///     <para>Note: recommended to be same Policy Name is SignUp </para>
        /// </summary>
        [Alias("App-Core-Integration-ida-SignUpSignInPolicyId")]
        public string TenantSignUpSignInPolicyId { get; set; }


        /// <summary>
        ///     The B2C User Profile Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_UserProfile_Policy'</para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-ida-UserProfilePolicyId'</para>
        /// </summary>
        [Alias("App-Core-Integration-ida-UserProfilePolicyId")]
        public string TenantUserProfilePolicyId { get; set; }


        /// <summary>
        ///     The B2C Edit Profile Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_EditProfile_Policy'</para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-ida-EditProfilePolicyId'</para>
        /// </summary>
        [Alias("App-Core-Integration-ida-EditProfilePolicyId")]
        public string TenantEditProfilePolicyId { get; set; }


        /// <summary>
        ///     The B2C SignUp/SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_ResetPassword_Policy'</para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-ida-ResetPasswordPolicyId'</para>
        /// </summary>
        [Alias("App-Core-Integration-ida-ResetPasswordPolicyId")]
        public string TenantResetPasswordPolicyId { get; set; }

        #endregion
    }
}