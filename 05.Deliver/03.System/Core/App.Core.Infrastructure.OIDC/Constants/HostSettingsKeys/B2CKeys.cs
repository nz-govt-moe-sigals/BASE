namespace App.Core.Infrastructure.IDA.Constants.HostSettingsKeys
{
    public static class B2CKeys
    {
        #region General Tenant 

        public static string Tenant = "App-Core-Integration-ida-Tenant";
        public static string AadInstance = "App-Core-Integration-ida-AadInstance";
        public static string SignUpPolicyId = "App-Core-Integration-ida-SignUpPolicyId";
        public static string SignInPolicyId = "App-Core-Integration-ida-SignInPolicyId";
        public static string SignUpSignInPolicyId = "App-Core-Integration-ida-SignUpSignInPolicyId";
        public static string UserProfilePolicyId = "App-Core-Integration-ida-UserProfilePolicyId";
        public static string EditProfilePolicyId = "App-Core-Integration-ida-EditProfilePolicyId";
        public static string ResetPasswordPolicyId = "App-Core-Integration-ida-ResetPasswordPolicyId";

        #endregion

        #region Client Specific

        public static string ClientId = "App-Core-Integration-ida-ClientId";
        public static string ClientSecret = "App-Core-Integration-ida-ClientSecret";
        public static string ClientRedirectUri = "App-Core-Integration-ida-RedirectUri";

        #endregion
    }
}