﻿namespace App.Core.Infrastructure.IDA.Models
{
    using System;



    public interface IAuthBearerTokenSettingsConfiguration
    {
        string AuthorityTenantName { get; set; }

        string AuthorityUri { get; set; }

        string ClientId { get; set; }

        string AppIdUrl { get; set; }

        string ClientIdB2C { get; set; }

        string AppIdUrlB2C { get; set; }

        string PolicyIdB2C { get; set; }
    }

    public interface IAadOidcSettingsConfidentialClientConfiguration : IOidcSettingsConfidentialClientConfiguration
    {

    }


    /// <summary>
    ///     Contract for a configuration object for a Confidential (as oppossed to Public)
    ///     Client which can be trusted to secure the ClientSecret issued by the remote B2C
    ///     which is a 'Tenanted IdP'.
    ///     <para>
    ///         Implements
    ///         <see cref="IAadOidcSettingsConfidentialClientConfiguration" /> and
    ///         <see cref="IB2CTenantPolicySettingsConfiguration" />
    ///     </para>
    /// </summary>
    public interface IB2COidcConfidentialClientSettingsConfiguration : IB2CTenantPolicySettingsConfiguration, IOidcSettingsConfidentialClientConfiguration
    {

    }


    /// <summary>
    // As far as I know B2C is unique in their use of 'Policies' to control flow. 
    /// </summary>
    public interface IB2CTenantPolicySettingsConfiguration
    {
        /// <summary>
        ///     Default behaviour is to wrap and return the SignUpSignInPolicyId
        ///     unless set to another policy.
        /// </summary>
        string DefaultPolicyId { get; set; }


        /// <summary>
        ///     The B2C SignUp Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_SignUp_Policy'</para>
        ///     <para>Note: recommended to be same Policy Name as SignIn </para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-SignUpSignInPolicyId'</para>
        /// </summary>
        [Obsolete]
        string TenantSignUpPolicyId { get; set; }

        /// <summary>
        ///     The B2C SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_SignIn_Policy'</para>
        ///     <para>Note: recommended to be same Policy Name is SignUp </para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-SignInPolicyId'</para>
        /// </summary>
        [Obsolete]
        string TenantSignInPolicyId { get; set; }

        /// <summary>
        ///     The B2C SignUp/SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_SignUpSignIn_Policy'</para>
        ///     <para>Note: recommended to be same Policy Name is SignUp </para>
        /// </summary>
        string TenantSignUpSignInPolicyId { get; set; }


        /// <summary>
        ///     The B2C User Profile Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_UserProfile_Policy'</para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-UserProfilePolicyId'</para>
        /// </summary>
        string TenantUserProfilePolicyId { get; set; }


        /// <summary>
        ///     The B2C Edit Profile Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_EditProfile_Policy'</para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-EditProfilePolicyId'</para>
        /// </summary>
        string TenantEditProfilePolicyId { get; set; }


        /// <summary>
        ///     The B2C SignUp/SignIn Policy Name
        ///     <para>eg: 'B2C_1_B2C_Default_ResetPassword_Policy'</para>
        ///     <para>Default Host Seting key is ConfigurationKeys.SystemIntegrationKeyPrefix (ie 'Service-Integration-') + 'Oidc-PolicyBased-ResetPasswordPolicyId'</para>
        /// </summary>
        string TenantResetPasswordPolicyId { get; set; }
    }

 
    /// <summary>
    ///     Confidential (as oppossed to Public) Clients can be trusted
    ///     to secure the ClientSecret issued by the remote IdP.
    ///     <para>
    ///         Suitable for default OAuth flow, and classic Server-side rendered web applications.
    ///     </para>
    /// </summary>
    public interface IOidcSettingsConfidentialClientConfiguration : IOidcSettingsClientConfiguration
    {
        /// <summary>
        ///     The ClientSecret established when then Client
        ///     was registered with the IdP.
        /// </summary>
        string ClientSecret { get; set; }

        /// <summary>
        ///     The uri to return to redirect the user agent to, in order to deliver
        ///     the auth_token or other payload.
        /// </summary>
        string ClientRedirectUri { get; set; }

        /// <summary>
        ///     After logout, where do we redirect to? (eg: home page at '/')
        /// </summary>
        string ClientPostLogoutUri { get; set; }


    }


    /// <summary>
    ///     Contract for basic OIDC configuration of a client.
    ///     <para>
    ///         It is not Confidential (ie, no Secret), so can be used for ImplicitFlow.
    ///     </para>
    /// </summary>
    public interface IOidcSettingsClientConfiguration
    {
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
        /// </summary>
        string AuthorityUri { get; set; }

        /// <summary>
        ///     The OIDC Client's unique Id
        /// </summary>
        string ClientId { get; set; }

        /// <summary>
        ///     Name of individual AAD/B2C Tenant, that is then combined with AD V2 endpoint to make AuthorityUri
        ///     <para>
        ///         Note that this is not the Uri (see AuthorityUri, and in the case B2C, AuthorityConfigurationPolicyUri ).
        ///     </para>
        /// </summary>
        string AuthorityTenantName { get; set; }
    }
}