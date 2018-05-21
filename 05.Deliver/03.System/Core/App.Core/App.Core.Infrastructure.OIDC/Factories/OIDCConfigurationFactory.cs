//using System;
//using System.Configuration;

//namespace App.Core.Infrastructure.IDA.Models.Factories
//{
//    public static class OIDCConfigurationFactory
//    {
//        // A factory to create a single Model of the Configuration values
//        // related to signing in. An OO approach is more maintainable than
//        // referring to free-floating parts/settings from multiple locations
//        // in the application. 
//        public static OIDCConfiguration Create(String prefix=null)
//        {
//            if (prefix==null)
//            {
//                prefix = string.Empty;
//            }
//            var result = new OIDCConfiguration();

//            #region Tenant Specific
//            result.Tenant = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.Tenant);
//            result.TenantAaInstance = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.AadInstance);
//#pragma warning disable CS0612 // Type or member is obsolete
//            result.TenantSignUpPolicyId = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.SignUpPolicyId);
//            result.TenantSignInPolicyId = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.SignInPolicyId);
//#pragma warning restore CS0612 // Type or member is obsolete
//            result.TenantSignUpSignInPolicyId = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.SignUpSignInPolicyId);
//            result.TenantUserProfilePolicyId = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.UserProfilePolicyId);
//            result.TenantEditProfilePolicyId = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.EditProfilePolicyId);
//            result.TenantResetPasswordPolicyId = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.ResetPasswordPolicyId);
//            #endregion

//            #region Client Specific
//            result.ClientId = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.ClientId);
//            result.ClientSecret = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.ClientSecret);
//            result.ClientRedirectUri = _hostSettingsService.Get(prefix + Constants.HostSettingsKeys.B2CKeys.ClientRedirectUri);
//            #endregion

//            return result;
//        }
//    }
//}

