namespace App.Core.Infrastructure.IDA.Constants.HostSettingsKeys
{
    using System;

    public static class AuthorisationSetup
    {
        public const string AuthorisationDemoType = "App-Core-Integration-Oidc-ApproachType";
    }

    public static class B2COIDCKeys /*Adds more on top of AADOIDCKeys*/
    {

        // THe following are urls to Authenticate Tokens:
        public const string AuthorityCookieConfigurationPolicyUri =
            "App-Core-Integration-Oidc-PolicyBased-AuthorityCookieConfigurationPolicyUri";
        public const string AuthorityBearerTokenConfigurationPolicyUri =
            "App-Core-Integration-Oidc-PolicyBased-AuthorityTokenConfigurationPolicyUri";

        #region General Tenant 
        public const string Tenant = "App-Core-Integration-Oidc-PolicyBased-Tenant";
            public const string AadInstance = "App-Core-Integration-Oidc-PolicyBased-AadInstance";

            //Policies:
            public const string DefaultPolicyId = "App-Core-Integration-Oidc-PolicyBased-DefaultPolicyId";
            [Obsolete]
            public const string SignUpPolicyId = "App-Core-Integration-Oidc-PolicyBased-SignUpPolicyId";
            [Obsolete]
            public const string SignInPolicyId = "App-Core-Integration-Oidc-PolicyBased-SignInPolicyId";
            //Replaced by:
            public const string SignUpSignInPolicyId = "App-Core-Integration-Oidc-PolicyBased-SignUpSignInPolicyId";
            public const string UserProfilePolicyId = "App-Core-Integration-Oidc-PolicyBased-UserProfilePolicyId";
            public const string EditProfilePolicyId = "App-Core-Integration-Oidc-PolicyBased-EditProfilePolicyId";
            public const string ResetPasswordPolicyId = "App-Core-Integration-Oidc-PolicyBased-ResetPasswordPolicyId";
        #endregion
    }


    public static class AADOIDCKeys /*Adds more on top of OIDCKeys*/
    {
        public const string AuthorityTenantName = "App-Core-Integration-Oidc-AuthorityTenantName";
        public const string AuthorityUriType = "App-Core-Integration-Oidc-AuthorityUriType";
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
        public const string AuthorityUri = "App-Core-Integration-Oidc-AuthorityUri";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know --- 
        /// but not persisted in web.config code that coudlrtha.
        /// 
        /// </summary>
        public const string ClientId = "App-Core-Integration-Oidc-ClientId";
        //Ensure this settings is persisted in KeyVault, and not the AppHost,
        //even if they are put there during deployment
        public const string ClientSecret = "App-Core-Integration-Oidc-ClientSecret";

        public const string ClientRedirectUri = "App-Core-Integration-Oidc-RedirectUri";
        /// <summary>
        /// The client post logout redirect URI.
        /// If it's just '/' just it's ok to persist it in the code base. 
        /// But if it contains a domain identifier then inject it into the 
        /// AppSettings via the build pipeline. Using the KeyVault would be too heavy.
        /// </summary>
        public const string ClientPostLogoutRedirectUri = "App-Core-Integration-Oidc-PostLogoutRedirectUri";

    }
}