namespace App.Core.Infrastructure.IDA.Constants.HostSettingsKeys
{
    public static class B2CKeys
    {
        #region General Tenant 

        public static string Tenant = "App:Core:ida:Tenant";
        public static string AadInstance = "App:Core:ida:AadInstance";
        public static string SignUpPolicyId = "App:Core:ida:SignUpPolicyId";
        public static string SignInPolicyId = "App:Core:ida:SignInPolicyId";
        public static string SignUpSignInPolicyId = "App:Core:ida:SignUpSignInPolicyId";
        public static string UserProfilePolicyId = "App:Core:ida:UserProfilePolicyId";
        public static string EditProfilePolicyId = "App:Core:ida:EditProfilePolicyId";
        public static string ResetPasswordPolicyId = "App:Core:ida:ResetPasswordPolicyId";

        #endregion

        #region Client Specific

        public static string ClientId = "App:Core:ida:ClientId";
        public static string ClientSecret = "App:Core:ida:ClientSecret";
        public static string ClientRedirectUri = "App:Core:ida:RedirectUri";

        #endregion
    }
}