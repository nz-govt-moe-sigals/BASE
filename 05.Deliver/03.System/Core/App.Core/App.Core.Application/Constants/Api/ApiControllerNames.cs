namespace App.Core.Application.Constants.Api
{
    /// <summary>
    /// YES CASE MATTERS
    /// </summary>
    public static class ApiControllerNames
    {
        public static string PathRoot = Core.Infrastructure.Constants.Module.Names.ModuleKey.ToLower();

        public const string DtoSuffix = ""/*"dto"*/;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// information about the Application (Name, Desc, Creator, Distributor) for UX to render as it sees fit.        
        /// </summary>
        public const string ApplicationDescription = "ApplicationDescription" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set of DataClassifications (for User Agent to cache as it sees best)
        /// </summary>
        public const string DataClassification = "DataClassification" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set of last Records of Exception 
        /// </summary>
        public const string ExceptionRecord = "ExceptionRecord" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set of last in mem recordings of steps taken during StartupUp: 
        /// </summary>
        public const string ConfigurationStepRecord = "ConfigurationStepRecord" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set of last Records of Exception 
        /// </summary>
        public const string Tenant = "Tenant" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set Properties belonging to Tenants.
        /// </summary>
        public const string TenantProperty = "TenantProperty" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set Claims belonging to Tenants.
        /// </summary>
        public const string TenantClaim = "TenantClaim" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Principals known to this system.
        /// </summary>
        public const string Principal = "Principal" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Categories Principals can belong to.
        /// </summary>
        public const string PrincipalCategory = "PrincipalCategory" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Tags Principals can be tagged with.
        /// </summary>
        public const string PrincipalTag = "PrincipalTag" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Properties belonging to Principals.
        /// </summary>
        public const string PrincipalProperty = "PrincipalProperty" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Claims belonging to Principals.
        /// </summary>
        public const string PrincipalClaim = "PrincipalClaim" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Roles Principals can belong to.
        /// </summary>
        public const string Role = "Role" + DtoSuffix;
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Notifications for Principals.
        public const string Notification = "Notification" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Sessions.
        /// </summary>
        public const string Session = "Session" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Operations recorded against Sessions.
        /// </summary>
        public const string SessionOperation = "SessionOperation" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// metadata about media uploaded by users.
        /// </summary>
        public const string MediaMetadata = "MediaMetadata" + DtoSuffix;


        public const string UserProfile = "UserProfile" + DtoSuffix;

        public const string TenantedNavigationRouteItem = "TenantedNavigationRouteItem" + DtoSuffix;

        public const string NavigationRouteItem = "NavigationRouteItem" + DtoSuffix;

        public const string NotificationUpdate = "NotificationUpdate" + DtoSuffix;

        public const string Search = "Search" + DtoSuffix;

        public const string SystemDeveloper = "SystemDeveloper" + DtoSuffix;

        public const string SystemDocumentation = "SystemDocumentation" + DtoSuffix;

        public const string SystemInformation = "SystemInformation" + DtoSuffix;
    }
}
 