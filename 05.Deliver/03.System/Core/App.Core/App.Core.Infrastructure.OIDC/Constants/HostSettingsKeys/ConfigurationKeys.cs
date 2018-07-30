namespace App.Core.Infrastructure.IDA.Constants.HostSettingsKeys
{
    using System;
    using App.Core.Shared.Constants;

    public static class AuthorisationSetup
    {
        public const string AuthorisationType = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-ApproachType";
    }

    public static class ApiOidcKeys
    {
        private const string ApiPrefix = "Api-Oidc-";

        public const string Tenant = ConfigurationKeys.SystemIntegrationKeyPrefix + ApiPrefix + "Client-Tenant";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know ---  but not persisted in web.config code that coudlrtha.
        /// </summary>
        public const string ClientId = ConfigurationKeys.SystemIntegrationKeyPrefix + ApiPrefix + "Client-Id";

        /// <summary>
        /// The OIDC client Identifier.
        /// It should be the API that you 
        /// </summary>
        public const string AppIdUri = ConfigurationKeys.SystemIntegrationKeyPrefix + ApiPrefix + "Client-App-IdUri";
        
        /// <summary>
        /// The URI of the IdP to which the security principal is redirected.
        /// OPTIONAL
        /// </summary>
        public const string AuthorityUri = ConfigurationKeys.SystemIntegrationKeyPrefix + ApiPrefix + "Client-AuthorityUri";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know ---  but not persisted in web.config code that coudlrtha.
        /// </summary>
        public const string ClientIdB2C = ConfigurationKeys.SystemIntegrationKeyPrefix + ApiPrefix + "Client-IdB2C";


        /// <summary>
        /// used when B2C is being used
        /// </summary>
        public const string AppIdUrlB2C = ConfigurationKeys.SystemIntegrationKeyPrefix + ApiPrefix + "Client-App-IdUriB2C";

        //Policies:
        /// <summary>
        /// used when B2C is being used
        /// </summary>
        public const string PolicyIdB2C = ConfigurationKeys.SystemIntegrationKeyPrefix + ApiPrefix + "Policies-PolicyIdB2C";
    }


    public static class WebAppOidcKeys
    {
        private const string WebAppPrefix = "WebApp-Oidc-";


        public const string Tenant = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Client-Tenant";
        // public const string AadInstance = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-AadInstance";

        /// <summary>
        /// The URI of the IdP to which the security principal is redirected.
        /// OPTIONAL
        /// </summary>
        public const string AuthorityUri = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Client-AuthorityUri";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know ---  but not persisted in web.config code that coudlrtha.
        /// </summary>
        public const string ClientId = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Client-Id";

        /// <summary>
        //Ensure this settings is persisted in KeyVault, and not the AppHost,
        //even if they are put there during deployment
        /// </summary>
        public const string ClientSecret = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Client-Secret";


        public const string ClientRedirectUri = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Client-RedirectUri";

        /// <summary>
        /// The client post logout redirect URI.
        /// If it's just '/' just it's ok to persist it in the code base. 
        /// But if it contains a domain identifier then inject it into the 
        /// AppSettings via the build pipeline. Using the KeyVault would be too heavy.
        /// </summary>
        public const string ClientPostLogoutRedirectUri = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Client-PostLogoutRedirectUri";


        //Policies:
        public const string DefaultPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Policies-DefaultPolicyId";
        public const string SignUpSignInPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Policies-SignUpSignInPolicyId";
        public const string UserProfilePolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Policies-UserProfilePolicyId";
        public const string EditProfilePolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Policies-EditProfilePolicyId";
        public const string ResetPasswordPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Policies-ResetPasswordPolicyId";
        //[Obsolete]
        public const string SignUpPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Policies-SignUpnPolicyId";
        //[Obsolete]
        public const string SignInPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + WebAppPrefix + "Policies-SignInPolicyId";
    }



}