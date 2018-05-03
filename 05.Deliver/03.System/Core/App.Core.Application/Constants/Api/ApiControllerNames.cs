namespace App.Core.Application.Constants.Api
{


    public static class ApiControllerNames
    {
        public static string PathRoot = Infrastructure.Constants.Module.Names.ModuleKey.ToLower();

        public const string DtoSuffix = ""/*"dto"*/;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// information about the Application (Name, Desc, Creator, Distributor) for UX to render as it sees fit.        
        /// </summary>
        public const string ApplicationDescription = "applicationdescription" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set of DataClassifications (for User Agent to cache as it sees best)
        /// </summary>
        public const string DataClassification = "dataclassification" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set of last Records of Exception 
        /// </summary>
        public const string ExceptionRecord = "exceptionrecord" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set of last in mem recordings of steps taken during StartupUp: 
        /// </summary>
        public const string ConfigurationStepRecord = "configurationsteprecord" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set of last Records of Exception 
        /// </summary>
        public const string Tenant = "tenant" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set Properties belonging to Tenants.
        /// </summary>
        public const string TenantProperty = "tenantproperty" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// set Claims belonging to Tenants.
        /// </summary>
        public const string TenantClaim = "tenantclaim" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Principals known to this system.
        /// </summary>
        public const string Principal = "principal" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Categories Principals can belong to.
        /// </summary>
        public const string PrincipalCategory = "principalcategory" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Tags Principals can be tagged with.
        /// </summary>
        public const string PrincipalTag = "principaltag" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Properties belonging to Principals.
        /// </summary>
        public const string PrincipalProperty = "principalproperty" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Claims belonging to Principals.
        /// </summary>
        public const string PrincipalClaim = "principalclaim" + DtoSuffix;
        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Roles Principals can belong to.
        /// </summary>
        public const string Role = "role" + DtoSuffix;
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Notifications for Principals.
        public const string Notification = "notification" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Sessions.
        /// </summary>
        public const string Session = "session" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// Operations recorded against Sessions.
        /// </summary>
        public const string SessionOperation = "sessionoperation" + DtoSuffix;

        /// <summary>
        /// Path to Appropriately Accessible (ie RBAC'ed) Queryable API returning 
        /// metadata about media uploaded by users.
        /// </summary>
        public const string MediaMetadata = "mediametadata" + DtoSuffix;
    }
}
 