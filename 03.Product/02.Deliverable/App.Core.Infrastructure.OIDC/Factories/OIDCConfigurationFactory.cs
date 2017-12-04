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
//            result.Tenant = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.Tenant);
//            result.TenantAaInstance = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.AadInstance);
//#pragma warning disable CS0612 // Type or member is obsolete
//            result.TenantSignUpPolicyId = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.SignUpPolicyId);
//            result.TenantSignInPolicyId = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.SignInPolicyId);
//#pragma warning restore CS0612 // Type or member is obsolete
//            result.TenantSignUpSignInPolicyId = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.SignUpSignInPolicyId);
//            result.TenantUserProfilePolicyId = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.UserProfilePolicyId);
//            result.TenantEditProfilePolicyId = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.EditProfilePolicyId);
//            result.TenantResetPasswordPolicyId = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.ResetPasswordPolicyId);
//            #endregion

//            #region Client Specific
//            result.ClientId = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.ClientId);
//            result.ClientSecret = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.ClientSecret);
//            result.ClientRedirectUri = ConfigurationManager.AppSettings.Get(prefix + Constants.HostSettingsKeys.B2CKeys.ClientRedirectUri);
//            #endregion

//            return result;
//        }
//    }
//}

