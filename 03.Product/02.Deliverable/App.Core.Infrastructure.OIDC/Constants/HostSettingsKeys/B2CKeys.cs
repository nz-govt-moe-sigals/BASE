namespace App.Core.Infrastructure.IDA.Constants.HostSettingsKeys
{
    public static class B2CKeys
    {
        #region General Tenant 

        public static string Tenant = "ida:Tenant";
        public static string AadInstance = "ida:AadInstance";
        public static string SignUpPolicyId = "ida:SignUpPolicyId";
        public static string SignInPolicyId = "ida:SignInPolicyId";
        public static string SignUpSignInPolicyId = "ida:SignUpSignInPolicyId";
        public static string UserProfilePolicyId = "ida:UserProfilePolicyId";
        public static string EditProfilePolicyId = "ida:EditProfilePolicyId";
        public static string ResetPasswordPolicyId = "ida:ResetPasswordPolicyId";

        #endregion

        #region Client Specific

        public static string ClientId = "ida:ClientId";
        public static string ClientSecret = "ida:ClientSecret";
        public static string ClientRedirectUri = "ida:RedirectUri";

        #endregion
    }
}