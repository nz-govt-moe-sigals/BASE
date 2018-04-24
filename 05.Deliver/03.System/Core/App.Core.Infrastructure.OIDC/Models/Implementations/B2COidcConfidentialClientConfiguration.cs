namespace App.Core.Infrastructure.IDA.Models
{
    using System;
    using App.Core.Shared.Attributes;

    public class B2COidcConfidentialClientConfiguration : AADOidcConfidentialClientConfiguration,
        IB2COidcConfidentialClientConfiguration, IB2CTenantPolicyConfiguration
    {
        /// <summary>
        ///     In addition to the base Uri to the OIDC IdP (ie, AuthorityUri),
        ///     B2C uses a more complex Uri that includes the Policy Id, in order to
        ///     to retrieve Config
        ///     <para>
        ///         "https://login.microsoftonline.com/tfp/{tenant}/{defaultPolicyId}/v2.0/.well-known/openid-configuration"
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.AuthorityCookieConfigurationPolicyUri)]
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
        private string _authorityCookieConfigurationPolicyUri;


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.AuthorityBearerTokenConfigurationPolicyUri)]
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
        private string _authorityBearerTokenConfigurationPolicyUri;


        #region Policie Ids

        /// <summary>
        ///     If not set, defaults to SignUp/SignIn policy.
        /// 
        ///     <para>eg: 'B2C_1_B2C_Default_SignUp_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_SU'</para>
        ///     <para>Note: recommended to be same Policy Name as SignIn </para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-Oidc-PolicyBased-SignUpSignInPolicyId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.DefaultPolicyId)]
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
        ///     <para>eg: 'B2C_1_B2C_SU'</para>
        ///     <para>Note: recommended to be same Policy Name as SignIn </para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-Oidc-PolicyBased-SignUpSignInPolicyId'</para>
        /// </summary>
        [Obsolete]
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
#pragma warning disable CS0612 // Type or member is obsolete
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.SignInPolicyId)]
#pragma warning restore CS0612 // Type or member is obsolete
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
        ///     <para>eg: 'B2C_1_B2C_SI'</para>
        ///     <para>Note: recommended to be same Policy Name is SignUp </para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-Oidc-PolicyBased-SignInPolicyId'</para>
        /// </summary>
        [Obsolete]
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
#pragma warning disable CS0612 // Type or member is obsolete
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.SignInPolicyId)]
#pragma warning restore CS0612 // Type or member is obsolete
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
        ///     <para>eg: 'B2C_1_B2C_SUSI'</para>
        ///     <para>Note: recommended to be same Policy Name as SignUp </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.SignUpSignInPolicyId)]
        public string TenantSignUpSignInPolicyId { get; set; }


        /// <summary>
        ///     The B2C User Profile Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_UserProfile_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_UP'</para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-Oidc-PolicyBased-UserProfilePolicyId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.UserProfilePolicyId)]
        public string TenantUserProfilePolicyId { get; set; }


        /// <summary>
        ///     The B2C Edit Profile Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_EditProfile_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_EP'</para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-Oidc-PolicyBased-EditProfilePolicyId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.EditProfilePolicyId)]
        public string TenantEditProfilePolicyId { get; set; }





        /// <summary>
        ///     The B2C SignUp/SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_ResetPassword_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_RP'</para>
        ///     <para>Default Host Seting key is 'App-Core-Integration-Oidc-PolicyBased-ResetPasswordPolicyId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.B2COIDCKeys.ResetPasswordPolicyId)]
        public string TenantResetPasswordPolicyId { get; set; }
        
        #endregion
    }
}