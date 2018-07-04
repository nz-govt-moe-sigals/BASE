namespace App.Core.Infrastructure.IDA.Constants.HostSettingsKeys
{
    using System;
    using App.Core.Shared.Constants;

    public static class AuthorisationSetup
    {
        public const string AuthorisationDemoType = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-ApproachType";
    }

    public static class B2COIDCKeys /*Adds more on top of AADOIDCKeys*/
    {

        // THe following are urls to Authenticate Tokens:
        public const string AuthorityCookieConfigurationPolicyUri =
            
            ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-AuthorityCookieConfigurationPolicyUri";
        public const string AuthorityBearerTokenConfigurationPolicyUri =
            ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-AuthorityTokenConfigurationPolicyUri";

        #region General Tenant 
        public const string Tenant = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-Tenant";
           // public const string AadInstance = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-AadInstance";

            //Policies:
            public const string DefaultPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-DefaultPolicyId";
            //[Obsolete]
            //public const string SignUpPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-SignUpPolicyId";
            //[Obsolete]
            //public const string SignInPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-SignInPolicyId";
            //Replaced by:
            public const string SignUpSignInPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-SignUpSignInPolicyId";
            public const string UserProfilePolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-UserProfilePolicyId";
            public const string EditProfilePolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-EditProfilePolicyId";
            public const string ResetPasswordPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-ResetPasswordPolicyId";
        #endregion
    }


    public static class AADOIDCKeys /*Adds more on top of OIDCKeys*/
    {
        public const string AuthorityTenantName = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-AuthorityTenantName";
        public const string AuthorityUriType = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-AuthorityUriType";
    }


    /// <summary>
    /// AppSettings specific to OIDC clients.
    /// Of which apps using AAD or B2C are.
    /// </summary>
    public static class OIDCClientKeys
    {
        /// <summary>
        /// The URI of the IdP to which the security principal is redirected.
        /// </summary>
        public const string AuthorityUri = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oauth-Client-AuthorityUri";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know --- 
        /// but not persisted in web.config code that coudlrtha.
        /// 
        /// </summary>
        public const string ClientId = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oauth-Client-Id";
        //Ensure this settings is persisted in KeyVault, and not the AppHost,
        //even if they are put there during deployment
        public const string ClientSecret = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oauth-Client-Secret";

        public const string ClientRedirectUri = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oauth-Client-RedirectUri";
        /// <summary>
        /// The client post logout redirect URI.
        /// If it's just '/' just it's ok to persist it in the code base. 
        /// But if it contains a domain identifier then inject it into the 
        /// AppSettings via the build pipeline. Using the KeyVault would be too heavy.
        /// </summary>
        public const string ClientPostLogoutRedirectUri = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oauth-Client-PostLogoutRedirectUri";

    }

    public static class OktaOidcClientKeys
    {
        private const string OktaPrefix = "Okta-";

        /// <summary>
        /// The URI of the IdP to which the security principal is redirected.
        /// </summary>
        public const string AuthorityUri = ConfigurationKeys.IntegrationKeyPrefix + OktaPrefix + "Oauth-Client-AuthorityUri";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know --- 
        /// but not persisted in web.config code that coudlrtha.
        /// 
        /// </summary>
        public const string ClientId = ConfigurationKeys.IntegrationKeyPrefix + OktaPrefix + "Oauth-Client-Id";
        //Ensure this settings is persisted in KeyVault, and not the AppHost,
        //even if they are put there during deployment
        public const string ClientSecret = ConfigurationKeys.IntegrationKeyPrefix + OktaPrefix + "Oauth-Client-Secret";

        public const string ClientRedirectUri = ConfigurationKeys.IntegrationKeyPrefix + OktaPrefix + "Oauth-Client-RedirectUri";
        /// <summary>
        /// The client post logout redirect URI.
        /// If it's just '/' just it's ok to persist it in the code base. 
        /// But if it contains a domain identifier then inject it into the 
        /// AppSettings via the build pipeline. Using the KeyVault would be too heavy.
        /// </summary>
        public const string ClientPostLogoutRedirectUri = ConfigurationKeys.IntegrationKeyPrefix + OktaPrefix + "Oauth-Client-PostLogoutRedirectUri";

    }
}