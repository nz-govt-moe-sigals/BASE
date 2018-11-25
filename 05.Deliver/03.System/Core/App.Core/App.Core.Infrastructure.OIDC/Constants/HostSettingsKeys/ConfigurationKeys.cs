namespace App.Core.Infrastructure.IDA.Constants.HostSettingsKeys
{
    using System;
    using App.Core.Shared.Constants;

    public static class AuthorisationSetup
    {
        public const string AuthorisationType = ConfigurationKeys.SystemIntegrationKeyPrefix + "OAuth-ApproachType";
    }

    public static class ApiOidcKeys
    {


        public const string Tenant = ConfigurationKeys.SystemIntegrationKeyPrefix + "oauthservice-clienttenant";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know ---  but not persisted in web.config code that coudlrtha.
        /// </summary>
        public const string ClientId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oauthservice-clientid";

        /// <summary>
        /// The OIDC client Identifier.
        /// It should be the API that you 
        /// </summary>
        public const string AppIdUri = ConfigurationKeys.SystemIntegrationKeyPrefix + "oauthservice-clienturi";
        
        /// <summary>
        /// The URI of the IdP to which the security principal is redirected.
        /// OPTIONAL
        /// </summary>
        public const string AuthorityUri = ConfigurationKeys.SystemIntegrationKeyPrefix + "oauthservice-clientauthorityuri";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know ---  but not persisted in web.config code that coudlrtha.
        /// </summary>
        public const string ClientIdB2C = ConfigurationKeys.SystemIntegrationKeyPrefix + "oauthservice-clientid-b2c";


        /// <summary>
        /// used when B2C is being used
        /// </summary>
        public const string AppIdUrlB2C = ConfigurationKeys.SystemIntegrationKeyPrefix + "oauthservice-clienturi-b2c";

        //Policies:
        /// <summary>
        /// used when B2C is being used
        /// </summary>
        public const string PolicyIdB2C = ConfigurationKeys.SystemIntegrationKeyPrefix + "oauthservice-clienturi-policies-policyid-b2c";
    }


    public static class WebAppOidcKeys
    {



        public const string Tenant = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-clienttenant";
        // public const string AadInstance = ConfigurationKeys.SystemIntegrationKeyPrefix + "Oidc-policies-AadInstance";

        /// <summary>
        /// The URI of the IdP to which the security principal is redirected.
        /// OPTIONAL
        /// </summary>
        public const string AuthorityUri = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-clientauthorityuri";

        /// <summary>
        /// The OIDC client Identifier.
        /// It's not exactly a secret, so it's ok for team members to know ---  but not persisted in web.config code that coudlrtha.
        /// </summary>
        public const string ClientId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-clientid";

        /// <summary>
        //Ensure this settings is persisted in KeyVault, and not the AppHost,
        //even if they are put there during deployment
        /// </summary>
        public const string ClientSecret = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-clientsecret";


        public const string ClientRedirectUri = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-clientredirecturi";

        /// <summary>
        /// The client post logout redirect URI.
        /// If it's just '/' just it's ok to persist it in the code base. 
        /// But if it contains a domain identifier then inject it into the 
        /// AppSettings via the build pipeline. Using the KeyVault would be too heavy.
        /// </summary>
        public const string ClientPostLogoutRedirectUri = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-clientpostlogoutredirecturi";


        //Policies:
        public const string DefaultPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-policies-default-policyid";
        public const string SignUpSignInPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-policies-signupsignin-policyid";
        public const string UserProfilePolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-policies-userprofile-policyid";
        public const string EditProfilePolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-policies-editprofile-policyid";
        public const string ResetPasswordPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-policies-resetpassword-policyid";
        //[Obsolete]
        public const string SignUpPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-policies-signup-policyid";
        //[Obsolete]
        public const string SignInPolicyId = ConfigurationKeys.SystemIntegrationKeyPrefix + "oidcservice-policies-signin-policyid";
    }



}