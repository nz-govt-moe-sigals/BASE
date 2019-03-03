using System;
using App.Core.Shared.Attributes;

namespace App.Core.Infrastructure.IDA.Models.Implementations.WebApp
{
    public class B2COidcConfidentialSettingsClientConfiguration : OidcSettingsConfidentialSettingsClientConfiguration,
        IB2COidcConfidentialClientSettingsConfiguration, IB2CTenantPolicySettingsConfiguration
    {
        private string _defaultPolicyId;
        private string _authorityConfigurationPolicyUri;

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
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.WebAppOidcKeys.AuthorityUri)]
        public override string AuthorityUri
        {
            get => this._authorityConfigurationPolicyUri
                   ??
                   $"https://login.microsoftonline.com/tfp/{this.AuthorityTenantName}/{this.DefaultPolicyId}/v2.0/.well-known/openid-configuration";
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._authorityConfigurationPolicyUri = value;
                }
            }
        }



        #region Policy Ids
        /// <summary>
        ///     If not set, defaults to SignUp/SignIn policy.
        /// 
        ///     <para>eg: 'B2C_1_B2C_Default_SignUp_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_SU'</para>
        ///     <para>Note: recommended to be same Policy Name as SignIn </para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-SignUpSignInPolicyId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.WebAppOidcKeys.DefaultPolicyId)]
        public string DefaultPolicyId
        {
            get => this._defaultPolicyId ?? this.TenantSignUpSignInPolicyId;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._defaultPolicyId = value;
                }
                
            }
        }

        /// <summary>
        ///     The B2C SignUp/SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_SignUpSignIn_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_SUSI'</para>
        ///     <para>Note: recommended to be same Policy Name as SignUp </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.WebAppOidcKeys.SignUpSignInPolicyId)]
        public string TenantSignUpSignInPolicyId { get; set; }


        /// <summary>
        ///     The B2C User Profile Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_UserProfile_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_UP'</para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-UserProfilePolicyId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.WebAppOidcKeys.UserProfilePolicyId)]
        public string TenantUserProfilePolicyId { get; set; }


        /// <summary>
        ///     The B2C Edit Profile Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_EditProfile_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_EP'</para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-EditProfilePolicyId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.WebAppOidcKeys.EditProfilePolicyId)]
        public string TenantEditProfilePolicyId { get; set; }

        /// <summary>
        ///     The B2C SignUp/SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_ResetPassword_Policy'</para>
        ///     <para>eg: 'B2C_1_B2C_RP'</para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-ResetPasswordPolicyId'</para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.WebAppOidcKeys.ResetPasswordPolicyId)]
        public string TenantResetPasswordPolicyId { get; set; }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.HostSettingsKeys.WebAppOidcKeys.SignUpPolicyId)]
        [Obsolete]
        public string TenantSignUpPolicyId { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.HostSettingsKeys.WebAppOidcKeys.SignInPolicyId)]
        [Obsolete]
        public string TenantSignInPolicyId { get; set; }

        #endregion


    }
}